Imports System.Data.SqlClient
Imports OJT_InOut_System.ServiceLibrary

Public Class DetailOut
    Inherits System.Web.UI.Page
    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand
    Dim strSQLEmp, strSQLLot, strSQLTranLot, strSQLQYI, strSQLUpcase, strSQLLY, strSQLIC, strSQLStepNo, strSQLBackupNo As String
    Dim dtAdapterEmp, dtAdapterLot, dtTranLot, dtAdapterQYI, dtAdapterLY, dtAdapterIC, dtStepNo, dtBackupNo As SqlDataAdapter
    Dim dtEmp, dtLot, dtLotID, dtQYI, dtLY, dtIC, dtStepNoID, dtBackup As New DataTable

    Public C_iLibgrarySevice As ServiceiLibraryClient

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        C_iLibgrarySevice = New ServiceiLibraryClient()
        Dim strConnString As String
        strConnString = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=DBx;Max Pool Size=400;Connect Timeout=600;"
        objConn = New SqlConnection(strConnString)
        objConn.Open()

        Dim strConnStringPro As String
        strConnStringPro = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=APCSProDB;Max Pool Size=400;Connect Timeout=600;"
        objConnPro = New SqlConnection(strConnStringPro)
        objConnPro.Open()

        txtLotno.Text = Session("Lot")
        txtEmpNo.Text = Session("Emp")

        'txtLotno.Text = "1938A1049V"
        'txtEmpNo.Text = "007952"

    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        'Check Lot ใน TranLot 
        strSQLTranLot = "Select * FROM [APCSProDB].[trans].[lots] Where lot_no ='" & txtLotno.Text & "'"
        dtTranLot = New SqlDataAdapter(strSQLTranLot, objConnPro)
        dtTranLot.Fill(dtLotID)
        If dtLotID.Rows.Count > 0 Then
            Session("LotId") = dtLotID.Rows(0)("id")
        End If

        'Check StepNo / BackupNo
        strSQLStepNo = "select lot_no , [APCSProDB].[method].[device_flows].device_slip_id, [APCSProDB].[method].[device_flows].step_no,name
   from [APCSProDB].[trans].[lots] INNER JOIN [APCSProDB].[method].[device_flows] ON [APCSProDB].[trans].[lots].device_slip_id  = [APCSProDB].[method].[device_flows].device_slip_id 
   INNER JOIN  [APCSProDB].[method].[jobs] ON [APCSProDB].[method].[device_flows].job_id = [APCSProDB].[method].[jobs].id
   where lot_no='" & txtLotno.Text & "' and name='AUTO(3)'"
        dtStepNo = New SqlDataAdapter(strSQLStepNo, objConnPro)
        dtStepNo.Fill(dtStepNoID)
        If dtStepNoID.Rows.Count > 0 Then
            Session("StepNo") = dtStepNoID.Rows(0)("step_no")
        End If

        strSQLBackupNo = "select lot_no , [APCSProDB].[method].[device_flows].device_slip_id, [APCSProDB].[method].[device_flows].step_no,name
   from [APCSProDB].[trans].[lots] INNER JOIN [APCSProDB].[method].[device_flows] ON [APCSProDB].[trans].[lots].device_slip_id  = [APCSProDB].[method].[device_flows].device_slip_id 
   INNER JOIN  [APCSProDB].[method].[jobs] ON [APCSProDB].[method].[device_flows].job_id = [APCSProDB].[method].[jobs].id
   where lot_no='" & txtLotno.Text & "' and name='AUTO(4)'"
        dtBackupNo = New SqlDataAdapter(strSQLBackupNo, objConnPro)
        dtBackupNo.Fill(dtBackup)
        If dtBackup.Rows.Count > 0 Then
            Session("BackupNo") = dtBackup.Rows(0)("step_no")
        End If


        If RadioButton1.Checked = True And txtOSNG1.Text <> "" Then
            ' OS NG
            If txtOSNG1.Text > 2 Then
                Session("NG") = txtOSNG1.Text
                Response.Redirect("OSNG_Over.aspx")
            Else
                ''End Lot โดย WCF และ Add special Flow โดย Storage2201 
                Dim LotID As String = Session("LotId")
                Dim StepNo As Integer = Session("StepNo") + 1
                Dim BackupNo As Integer = Session("BackupNo")
                Dim UserId As String = txtEmpNo.Text
                Dim FlowPattern As Decimal = 1514
                Dim SpecialFlow As Decimal = 1

                C_iLibgrarySevice.EndLotNoCheckLicenser(txtLotno.Text, "TE-QYI-01", txtEmpNo.Text, 0, 0)

                Dim Command As SqlCommand = New SqlCommand()
                Command.Connection = objConnPro
                Command.CommandText = "[StoredProcedureDB].[atom].[sp_set_trans_special_flow]"
                Command.CommandType = CommandType.StoredProcedure
                Command.Parameters.AddWithValue("@lot_id", LotID)
                Command.Parameters.AddWithValue("@step_no", StepNo)
                Command.Parameters.AddWithValue("@back_step_no", BackupNo)
                Command.Parameters.AddWithValue("@user_id", UserId)
                Command.Parameters.AddWithValue("@is_special_flow", SpecialFlow)
                Command.Parameters.AddWithValue("@flow_pattern_id", FlowPattern)
                Command.ExecuteNonQuery()

                'Check Lot ใน QYI 
                strSQLQYI = "Select Top(1) * FROM [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "'  order By TimeIn DESC"
                dtAdapterQYI = New SqlDataAdapter(strSQLQYI, objConn)
                dtAdapterQYI.Fill(dtQYI)
                If dtQYI.Rows.Count > 0 Then
                    If dtQYI.Rows(0)("UserIDOut").ToString.Trim() = "" Then
                        Session("QYINo") = dtQYI.Rows(0)("No")
                        Session("GOto") = "Retest Auto3 Bin19"
                        'Update ข้อมูลลงใน QYICase
                        strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut = '" & txtEmpNo.Text & "' " &
                        " ,TimeOut = '" & Now() & "',GotoProcess = '" & Session("GOto") & "',OSNG1='" & txtOSNG1.Text & "' Where No ='" & Session("QYINo") & "'"
                        objCmd = New SqlCommand(strSQLUpcase, objConn)
                        objCmd.ExecuteNonQuery()

                        If Session("Menu") = "FQI" Then
                            Response.Redirect("http://beerserver/FQI_REC/MainForm.aspx")
                        ElseIf Session("Menu") = "FYI" Then
                            Response.Redirect("http://beerserver/LSI/FYI/mainmenu.aspx")
                        End If
                    Else
                        Session("QYINo") = dtQYI.Rows(0)("No")
                        Session("GOto") = "Retest Auto3 Bin19"
                        'Update ข้อมูลลงใน QYICase
                        strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & txtEmpNo.Text & "' " &
                        " ,TimeOut2 = '" & Now() & "',GotoProcess2 = '" & Session("GOto") & "',OSNG2='" & txtOSNG1.Text & "' Where No ='" & Session("QYINo") & "'"
                        objCmd = New SqlCommand(strSQLUpcase, objConn)
                        objCmd.ExecuteNonQuery()

                        If Session("Menu") = "FQI" Then
                            Response.Redirect("http://beerserver/FQI_REC/MainForm.aspx")
                        ElseIf Session("Menu") = "FYI" Then
                            Response.Redirect("http://beerserver/LSI/FYI/mainmenu.aspx")
                        End If
                    End If

                Else
                    MsgBox("No Data")
                End If
            End If
        ElseIf RadioButton2.Checked = True Then
            'OS All Pass
            C_iLibgrarySevice.EndLotNoCheckLicenser(txtLotno.Text, "TE-QYI-01", txtEmpNo.Text, 0, 0)

            'Check Lot ใน QYI 
            strSQLQYI = "Select Top(1) * FROM [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "'  order By TimeIn DESC"
            dtAdapterQYI = New SqlDataAdapter(strSQLQYI, objConn)
            dtAdapterQYI.Fill(dtQYI)
            If dtQYI.Rows.Count > 0 Then
                Session("QYINo") = dtQYI.Rows(0)("No")
                Session("GOto") = "AUTO(4)"
                'Update ข้อมูลลงใน QYICase
                strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut = '" & txtEmpNo.Text & "' " &
                    " ,TimeOut = '" & Now() & "',GotoProcess = '" & Session("GOto") & "',OSNG1='0' Where No ='" & Session("QYINo") & "'"
                objCmd = New SqlCommand(strSQLUpcase, objConn)
                objCmd.ExecuteNonQuery()

                If Session("Menu") = "FQI" Then
                    Response.Redirect("http://beerserver/FQI_REC/MainForm.aspx")
                ElseIf Session("Menu") = "FYI" Then
                    Response.Redirect("http://beerserver/LSI/FYI/mainmenu.aspx")
                End If
            Else
                MsgBox("No Data")
            End If
        ElseIf RadioButton1.Checked = True And txtOSNG1.Text = "" Then
            MsgBox("Input OS NG ")
        ElseIf RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("Select Manual OS Test 1st")
        End If

    End Sub

End Class