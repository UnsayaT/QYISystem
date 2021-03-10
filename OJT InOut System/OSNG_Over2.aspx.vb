Imports System.Data.SqlClient
Imports OJT_InOut_System.ServiceLibrary
Public Class OSNG_Over2
    Inherits System.Web.UI.Page
    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand

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
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim ret, lot, Op_No, strSQLQYI, strSQLLY, strSQLIC, strSQLUpcase, strSQLTranLot As String
        Dim dtAdapterQYI, dtAdapterLY, dtAdapterIC, dtTranLot As SqlDataAdapter
        Dim dtQYI, dtLY, dtIC, dtNo, dtEmp, dtLotID As New DataTable

        lot = txtLotno.Text
        Op_No = txtEmpNo.Text

        If RadioButton1.Checked = True Then
            Session("GOto") = "QC"
        ElseIf RadioButton2.Checked = True Then
            Session("GOto") = "Next Process"
        ElseIf RadioButton3.Checked = True And txtAutoNo.Text = "" Then
            MsgBox("Input Auto Number")
        ElseIf RadioButton3.Checked = True Then
            Session("GOto") = "Retest Auto" & "" & txtAutoNo.Text
        End If

        If Session("GOto") = "Retest Auto1" Then
            Session("StepNo") = 2101
            Session("BackupNo") = 2200
        ElseIf Session("GOto") = "Retest Auto2" Then
            Session("StepNo") = 2201
            Session("BackupNo") = 2300
        ElseIf Session("GOto") = "Retest Auto3" Then
            Session("StepNo") = 2301
            Session("BackupNo") = 2400
        ElseIf Session("GOto") = "Retest Auto4" Then
            Session("StepNo") = 2401
            Session("BackupNo") = 2500
        ElseIf Session("GOto") = "Retest Auto5" Then
            Session("StepNo") = 2501
            Session("BackupNo") = 2700
        End If

        If RadioButton3.Checked = True Then
            'Check Lot ใน TranLot 
            strSQLTranLot = "Select * FROM [APCSProDB].[trans].[lots] Where lot_no ='" & txtLotno.Text & "' "
            dtTranLot = New SqlDataAdapter(strSQLTranLot, objConnPro)
            dtTranLot.Fill(dtLotID)
            If dtLotID.Rows.Count > 0 Then
                Session("LotId") = dtLotID.Rows(0)("id")
            End If
            'เลือกเมนูNext Process
            Try

                C_iLibgrarySevice.EndLotNoCheckLicenser(lot, "TE-QYI-01", Op_No, 0, 0)

                'Add special Flow โดย Storage 
                Dim LotID As String = Session("LotId")
                Dim StepNo As String = Session("StepNo")
                Dim BackupNo As String = Session("BackupNo")
                Dim UserId As String = txtEmpNo.Text
                Dim FlowPattern As Decimal = 1514
                Dim SpecialFlow As Decimal = 1


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
                strSQLQYI = "Select Top(1) *  FROM [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "' order By TimeIn DESC"
                dtAdapterQYI = New SqlDataAdapter(strSQLQYI, objConn)
                dtAdapterQYI.Fill(dtQYI)
                If dtQYI.Rows.Count > 0 Then
                    Session("QYINo") = dtQYI.Rows(0)("No")
                    'Update ข้อมูลลงใน QYICase
                    strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & txtEmpNo.Text & "' " &
                    " ,TimeOut2 = '" & Now() & "' ,GotoProcess2 = '" & Session("GOto") & "',OSNG2='" & Session("NG") & "' Where No ='" & Session("QYINo") & "'"
                    objCmd = New SqlCommand(strSQLUpcase, objConn)
                    objCmd.ExecuteNonQuery()


                    '**Check Issue No ใน QYILowYield
                    strSQLLY = "Select * FROM [DBx].[QYI].[QYILowYield] Where No ='" & Session("QYINo") & "'"
                    dtAdapterLY = New SqlDataAdapter(strSQLLY, objConn)
                    dtAdapterLY.Fill(dtLY)
                    If dtLY.Rows.Count > 0 Then
                        'Update ข้อมูลลงใน QYILowYield
                        strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & txtEmpNo.Text & "' " &
                    " ,TimeOut2 = '" & Now() & "' ,GotoProcess2 = '" & Session("GOto") & "',OSNG2='" & Session("NG") & "' Where No ='" & Session("QYINo") & "'"
                        objCmd = New SqlCommand(strSQLUpcase, objConn)
                        objCmd.ExecuteNonQuery()
                        Response.Redirect("http://webserv.thematrix.net/QYISystem/QYI/QYIMaster.aspx")
                    Else
                        'Check Issue No ใน QYIICBurn
                        strSQLIC = "Select * FROM [DBx].[QYI].[QYIICBurn] Where No ='" & Session("QYINo") & "'"
                        dtAdapterIC = New SqlDataAdapter(strSQLIC, objConn)
                        dtAdapterIC.Fill(dtIC)
                        If dtIC.Rows.Count > 0 Then
                            'Update ข้อมูลลงใน QYIICBurn
                            Response.Redirect("http://webserv.thematrix.net/QYISystem/QYI/QYIMaster.aspx")
                        Else
                            'แสดงว่าเป็นAlram Mist
                            If Session("Menu") = "FQI" Then
                                Response.Redirect("http://beerserver/FQI_REC/MainForm.aspx")
                            ElseIf Session("Menu") = "FYI" Then
                                Response.Redirect("http://beerserver/LSI/FYI/mainmenu.aspx")
                            End If
                        End If
                    End If
                Else
                    MsgBox("No Data")
                End If
            Catch ex As Exception
                ret = ex.Message
            End Try
        ElseIf RadioButton2.Checked = True Then
            'Add Flow โดยStorage
            Try
                C_iLibgrarySevice.EndLotNoCheckLicenser(lot, "TE-QYI-01", Op_No, 0, 0)

                'Check Lot ใน QYI 
                strSQLQYI = "Select Top(1) *  FROM [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "' order By TimeIn DESC"
                dtAdapterQYI = New SqlDataAdapter(strSQLQYI, objConn)
                dtAdapterQYI.Fill(dtQYI)
                If dtQYI.Rows.Count > 0 Then
                    Session("QYINo") = dtQYI.Rows(0)("No")
                    'Update ข้อมูลลงใน QYICase
                    strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & txtEmpNo.Text & "' " &
                    " ,TimeOut2 = '" & Now() & "' ,GotoProcess2 = '" & Session("GOto") & "',OSNG2='" & Session("NG") & "' Where No ='" & Session("QYINo") & "' "
                    objCmd = New SqlCommand(strSQLUpcase, objConn)
                    objCmd.ExecuteNonQuery()


                    '**Check Issue No ใน QYILowYield
                    strSQLLY = "Select * FROM [DBx].[QYI].[QYILowYield] Where No ='" & Session("QYINo") & "'"
                    dtAdapterLY = New SqlDataAdapter(strSQLLY, objConn)
                    dtAdapterLY.Fill(dtLY)
                    If dtLY.Rows.Count > 0 Then
                        'Update ข้อมูลลงใน QYILowYield
                        strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & txtEmpNo.Text & "' " &
                    " ,TimeOut2 = '" & Now() & "' ,GotoProcess2 = '" & Session("GOto") & "',OSNG2='" & Session("NG") & "' Where No ='" & Session("QYINo") & "'"
                        objCmd = New SqlCommand(strSQLUpcase, objConn)
                        objCmd.ExecuteNonQuery()
                        Response.Redirect("http://webserv.thematrix.net/QYISystem/QYI/QYIMaster.aspx")
                    Else
                        'Check Issue No ใน QYIICBurn
                        strSQLIC = "Select * FROM [DBx].[QYI].[QYIICBurn] Where No ='" & Session("QYINo") & "'"
                        dtAdapterIC = New SqlDataAdapter(strSQLIC, objConn)
                        dtAdapterIC.Fill(dtIC)
                        If dtIC.Rows.Count > 0 Then
                            'Update ข้อมูลลงใน QYIICBurn
                            Response.Redirect("http://webserv.thematrix.net/QYISystem/QYI/QYIMaster.aspx")
                        Else
                            If Session("Menu") = "FQI" Then
                                Response.Redirect("http://beerserver/FQI_REC/MainForm.aspx")
                            ElseIf Session("Menu") = "FYI" Then
                                Response.Redirect("http://beerserver/LSI/FYI/mainmenu.aspx")
                            End If
                        End If

                    End If
                Else
                    MsgBox("No Data")
                End If
            Catch ex As Exception
                ret = ex.Message
            End Try
        ElseIf RadioButton1.Checked = True Then
            'Check Lot ใน QYI 
            strSQLQYI = "Select * FROM [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "'"
            dtAdapterQYI = New SqlDataAdapter(strSQLQYI, objConn)
            dtAdapterQYI.Fill(dtQYI)
            If dtQYI.Rows.Count > 0 Then
                Session("QYINo") = dtQYI.Rows(0)("No")
                'Update ข้อมูลลงใน QYICase
                strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET GotoProcess2 = 'QC' ,OSNG2='" & Session("NG") & "' Where No ='" & Session("QYINo") & "' "
                objCmd = New SqlCommand(strSQLUpcase, objConn)
                objCmd.ExecuteNonQuery()
            End If
            lblerror.Text = "กรูณานำงาน NG ส่งให้ QC เพื่อทำการตรวจสอบต่อไป"
        End If
    End Sub
End Class