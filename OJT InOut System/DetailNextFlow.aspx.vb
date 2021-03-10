Imports System.Data.SqlClient
Imports OJT_InOut_System.ServiceLibrary

Public Class DetailNextFlow
    Inherits System.Web.UI.Page
    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand
    Dim strSQLUpcase, strSQLRecoed, strSQLStepNo, strSQLBackupNo, strSQLTran, Pack, strSQLPackages, strSQLTranlots As String
    Dim dtAdapterRecoed, dtStepNo, dtBackupNo, dtAdapterTran, dtAdapterPackages, dtAdapterTranlots As SqlDataAdapter
    Dim dtRecoed, dtStepNoID, dtBackup, dtTran, dtPackages, dtlots As New DataTable

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
        txtOPNO.Text = Session("Emp")
        If IsDBNull(Session("Remark")) Then
            lblRemark.Text = ""
        Else
            lblRemark.Text = Session("Remark")
        End If


    End Sub

    Protected Sub btnconfirm_Click(sender As Object, e As EventArgs) Handles btnconfirm.Click
        'Check Lot No ใน TransactionData
        strSQLTran = "Select Top(1) OldPackage,OldDeviceName,Process,TestFlow,Mode From [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "'  and  Mode IS Not NULL order By TimeIn DESC "
        dtAdapterTran = New SqlDataAdapter(strSQLTran, objConn)
        dtAdapterTran.Fill(dtTran)
        If dtTran.Rows.Count > 0 Then
            Session("Device") = dtTran.Rows(0)("OldDeviceName")
            Session("Package") = dtTran.Rows(0)("OldPackage")
            Session("Process") = dtTran.Rows(0)("Process")
            Session("Flow") = dtTran.Rows(0)("TestFlow").Trim()
            Session("Mode") = dtTran.Rows(0)("Mode")
        End If


        'Check StepNo จาก [trans].[lots]
        strSQLTranlots = "Select id,step_no From[APCSProDB].[trans].[lots]  Where lot_no ='" & txtLotno.Text & "'"
        dtAdapterTranlots = New SqlDataAdapter(strSQLTranlots, objConnPro)
        dtAdapterTranlots.Fill(dtlots)
        If dtlots.Rows.Count > 0 Then
            Session("BackupNo") = dtlots.Rows(0)("step_no")
            Session("LotId") = dtlots.Rows(0)("id")
        End If

        'Check LotNo นี้มีFlow ของ Insp หรือไม่
        Dim objConnInsp As New SqlConnection()
        Dim objCmdInsp As New SqlCommand()
        Dim dtAdapterInsp As New SqlDataAdapter()
        Dim dsInsp As New DataSet()
        Dim dtInsp As DataTable
        Dim strConnStringInsp As String, strStoredInsp As String


        strConnStringInsp = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=StoredProcedureDB;Max Pool Size=400;Connect Timeout=600;"
        strStoredInsp = "[atom].[sp_get_trans_lot_flows]"
        objCmdInsp.Parameters.Add(New SqlParameter("@lot_id", SqlDbType.Int)).Value = Session("LotId")
        objConnInsp.ConnectionString = strConnStringInsp
        objConnInsp.Open()
        objCmdInsp.Connection = objConnInsp
        objCmdInsp.CommandText = strStoredInsp
        objCmdInsp.CommandType = CommandType.StoredProcedure
        ' Get Select
        dtAdapterInsp.SelectCommand = objCmdInsp
        dtAdapterInsp.Fill(dsInsp)
        ' Loop Data Table
        dtInsp = dsInsp.Tables(0)
        For i As Integer = 0 To dtInsp.Rows.Count - 1
            Console.Write(dtInsp.Rows(i)("job_name"))
            If dtInsp.Rows(i)("job_name") = "100% INSP." Then
                Session("valueInsp") = dtInsp.Rows(i)("job_name")
                Session("valueInsp_StepNo") = dtInsp.Rows(i)("step_no")
            ElseIf dtInsp.Rows(i)("job_name") = "100% INSP." Then
                Session("valueInsp") = dtInsp.Rows(i)("job_name")
                Session("valueInsp_StepNo") = dtInsp.Rows(i)("step_no")
            End If
        Next

        'Check StepNo / BackupNo
        If Session("Flow") = "AUTO1" Then
            Session("Flow1") = "AUTO(2)"
            Session("Flow2") = "AUTO(1)"
        ElseIf Session("Flow") = "AUTO2" Then
            Session("Flow1") = "AUTO(3)"
            Session("Flow2") = "AUTO(2)"
        ElseIf Session("Flow") = "AUTO3" Then
            Session("Flow1") = "AUTO(4)"
            Session("Flow2") = "AUTO(3)"
        ElseIf Session("Flow") = "AUTO4" Then
            Session("Flow1") = "TP"
            Session("Flow2") = "AUTO(4)"
        End If

        strSQLStepNo = "select lot_no , [APCSProDB].[method].[device_flows].device_slip_id, [APCSProDB].[method].[device_flows].step_no,name
   from [APCSProDB].[trans].[lots] INNER JOIN [APCSProDB].[method].[device_flows] ON [APCSProDB].[trans].[lots].device_slip_id  = [APCSProDB].[method].[device_flows].device_slip_id 
   INNER JOIN  [APCSProDB].[method].[jobs] ON [APCSProDB].[method].[device_flows].job_id = [APCSProDB].[method].[jobs].id
   where lot_no='" & txtLotno.Text & "' and name='" & Session("Flow2") & "'"
        dtStepNo = New SqlDataAdapter(strSQLStepNo, objConnPro)
        dtStepNo.Fill(dtStepNoID)
        If dtStepNoID.Rows.Count > 0 Then
            Session("StepNo") = dtStepNoID.Rows(0)("step_no")
        End If



        If RadioButton1.Checked = True Then
            Session("GOto") = "EDS"
        ElseIf RadioButton2.Checked = True Then
            Session("GOto") = "DC"
        ElseIf RadioButton3.Checked = True Then
            Session("GOto") = "DB"
        ElseIf RadioButton4.Checked = True Then
            Session("GOto") = "WB"
        ElseIf RadioButton5.Checked = True Then
            Session("GOto") = "MP"
        ElseIf RadioButton6.Checked = True Then
            Session("GOto") = "TC"
        ElseIf RadioButton7.Checked = True Then
            Session("GOto") = "PL"
        ElseIf RadioButton8.Checked = True Then
            Session("GOto") = "FL"
        ElseIf RadioButton9.Checked = True Then
            Session("GOto") = "FT" & " " & "Auto" & txtAuto.Text
        ElseIf RadioButton10.Checked = True Then
            Session("GOto") = "TP"
        ElseIf RadioButton11.Checked = True Then
            Session("GOto") = "MAP"
        ElseIf RadioButton12.Checked = True Then
            Session("GOto") = "X-ray"
        ElseIf RadioButton13.Checked = True Then
            Session("GOto") = "QA"
        ElseIf RadioButton14.Checked = True Then
            Session("GOto") = "Retest FT" & " " & "Auto" & txtRetestAuto.Text
        ElseIf RadioButton15.Checked = True Then
            Session("GOto") = "TRAY CHANGE"
        ElseIf RadioButton16.Checked = True Then
            Session("GOto") = "100 % Insp"
        ElseIf RadioButton17.Checked = True Then
            Session("GOto") = "Low Yield"
        ElseIf RadioButton18.Checked = True Then
            Session("GOto") = "IC Burn"
        End If

        Pack = Session("Package")


        'WCF Check Packge 
        Dim CheckPackge = C_iLibgrarySevice.CheckPackageOnlyApcsPro("TE-QYI-01", Pack, Session("Emp"), txtLotno.Text)


        If CheckPackge = False Then

        ElseIf CheckPackge = True Then

            If Session("Process") = "FT" And (Session("Mode") = "LCL" Or Session("Mode") = "Yield < 80 %" Or Session("Mode") = "ASI 100% Lot" Or Session("Mode") = "BIN29,BIN30,BIN31" Or Session("Mode") = "BIN28" Or Session("Mode") = "Lot Eva Test Equipment" Or Session("Mode") = "Lot Eva New Device") Then
                Dim Cinfo As CarrierInfo = C_iLibgrarySevice.GetCarrierInfo("TE-QYI-01", txtLotno.Text, Session("Emp"))
                C_iLibgrarySevice.EndLotPhase2(txtLotno.Text, "TE-QYI-01", Session("Emp"), 0, 0, Licenser.NoCheck, Cinfo, New EndLotSpecialParametersEventArgs())

                '' Add special Flow โดย Storage2201 
                Dim LotID As String = Session("LotId")
                Dim StepNo As Integer = Session("StepNo") + 1
                Dim BackupNo As Integer = Session("BackupNo")
                Dim UserId As String = Session("Emp")
                Dim SpecialFlow As Decimal = 1
                Dim FlowPattern As Decimal


                If (Session("Mode") = "LCL" Or Session("Mode") = "Yield < 80 %" Or Session("Mode") = "ASI 100% Lot") Then
                    If Session("GOto") = "Retest FT Auto1" And Session("valueInsp") = "SAMPLING INSP" Then
                        FlowPattern = 1719
                    ElseIf Session("GOto") = "Retest FT Auto2" And Session("valueInsp") = "SAMPLING INSP" Then
                        FlowPattern = 1720
                    ElseIf Session("GOto") = "Retest FT Auto3" And Session("valueInsp") = "SAMPLING INSP." Then
                        FlowPattern = 1721
                    ElseIf Session("GOto") = "Retest FT Auto4" And Session("valueInsp") = "SAMPLING INSP" Then
                        FlowPattern = 1722
                    ElseIf Session("GOto") = "Retest FT Auto1" And Session("valueInsp") <> "SAMPLING INSP" Then
                        FlowPattern = 1652
                    ElseIf Session("GOto") = "Retest FT Auto2" And Session("valueInsp") <> "SAMPLING INSP" Then
                        FlowPattern = 1653
                    ElseIf Session("GOto") = "Retest FT Auto3" And Session("valueInsp") <> "SAMPLING INSP" Then
                        FlowPattern = 1654
                    ElseIf Session("GOto") = "Retest FT Auto4" And Session("valueInsp") <> "SAMPLING INSP" Then
                        FlowPattern = 1655
                    End If
                ElseIf (Session("Mode") = "BIN29,BIN30,BIN31" Or Session("Mode") = "BIN28") Then
                    If Session("GOto") = "Retest FT Auto1" And Session("valueInsp") = "SAMPLING INSP" Then
                        FlowPattern = 1723
                    ElseIf Session("GOto") = "Retest FT Auto2" And Session("valueInsp") = "SAMPLING INSP" Then
                        FlowPattern = 1724
                    ElseIf Session("GOto") = "Retest FT Auto3" And Session("valueInsp") = "SAMPLING INSP" Then
                        FlowPattern = 1725
                    ElseIf Session("GOto") = "Retest FT Auto4" And Session("valueInsp") = "SAMPLING INSP" Then
                        FlowPattern = 1726
                    ElseIf Session("GOto") = "Retest FT Auto1" And Session("valueInsp") <> "SAMPLING INSP" Then
                        FlowPattern = 1677
                    ElseIf Session("GOto") = "Retest FT Auto2" And Session("valueInsp") <> "SAMPLING INSP" Then
                        FlowPattern = 1676
                    ElseIf Session("GOto") = "Retest FT Auto3" And Session("valueInsp") <> "SAMPLING INSP" Then
                        FlowPattern = 1769
                    ElseIf Session("GOto") = "Retest FT Auto4" And Session("valueInsp") <> "SAMPLING INSP" Then
                        FlowPattern = 1770
                    End If
                End If

                'Retest
                If RadioButton14.Checked = True Then
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


                End If
            ElseIf (Session("Process") = "MAP" Or Session("Process") = "FL") And (Session("Mode") = "Lot Eva Test Equipment" Or Session("Mode") = "Lot Eva New Device") Then
                Dim Cinfo As CarrierInfo = C_iLibgrarySevice.GetCarrierInfo("TE-QYI-01", txtLotno.Text, Session("Emp"))
                C_iLibgrarySevice.EndLotPhase2(txtLotno.Text, "TE-QYI-01", Session("Emp"), 0, 0, Licenser.NoCheck, Cinfo, New EndLotSpecialParametersEventArgs())
            End If
        End If

        Dim strSQLLot As String
        Dim dtAdapterLot As SqlDataAdapter
        Dim dtLot As New DataTable
        If txtRemark.Text <> "" Then
            Session("DataRemark") = txtRemark.Text
        Else
            Session("DataRemark") = "-"
        End If
        If txtRemark1.Text <> "" Then
            Session("DataRemark1") = txtRemark1.Text
        Else
            Session("DataRemark1") = "-"
        End If



        'Check Lot No ใน QYI
        strSQLLot = "Select No,LotNo,Mode,TimeOut, CASE WHEN TimeOut   IS NULL THEN '-' ELSE CONVERT(varchar, TimeOut, 101) END As DataOut From [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "' order by TimeIn DESC"
        dtAdapterLot = New SqlDataAdapter(strSQLLot, objConn)
        dtAdapterLot.Fill(dtLot)

        If dtLot.Rows.Count > 0 And dtLot.Rows(0)("DataOut") <> "-" Then
            If Session("IssueNo") <> "" Then
                If (Session("Mode") = "LCL" Or Session("Mode") = "Yield < 80 %" Or Session("Mode") = "ASI 100% Lot") Then
                    strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & Session("Emp") & "',TimeOut2 = '" & Now() & "',GotoProcess2 = '" & Session("GOto") & "',Remark1 = '" & Session("DataRemark") & "',Remark2 = '" & Session("DataRemark1") & "',OPNO = '" & Session("Emp") & "' Where No ='" & dtLot.Rows(0)("NO") & "'"
                    objCmd = New SqlCommand(strSQLUpcase, objConn)
                    objCmd.ExecuteNonQuery()
                ElseIf (Session("Mode") = "BIN29,BIN30,BIN31" Or Session("Mode") = "BIN28") Then
                    strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & Session("Emp") & "',TimeOut2 = '" & Now() & "',GotoProcess2 = '" & Session("GOto") & "',Remark1 = '" & Session("DataRemark") & "',Remark2 = '" & Session("DataRemark1") & "',OPNO = '" & Session("Emp") & "' Where No ='" & dtLot.Rows(0)("NO") & "'"
                    objCmd = New SqlCommand(strSQLUpcase, objConn)
                    objCmd.ExecuteNonQuery()
                End If
            Else
                'Update ข้อมูลลงใน QYICase
                strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & Session("Emp") & "',TimeOut2 = '" & Now() & "',GotoProcess2 = '" & Session("GOto") & "',Remark1 = '" & Session("DataRemark") & "',Remark2 = '" & Session("DataRemark1") & "',OPNO = '" & Session("Emp") & "' Where No ='" & dtLot.Rows(0)("NO") & "'"
                objCmd = New SqlCommand(strSQLUpcase, objConn)
                objCmd.ExecuteNonQuery()
            End If
        Else
            If Session("IssueNo") <> "" Then
                If (Session("Mode") = "LCL" Or Session("Mode") = "Yield < 80 %" Or Session("Mode") = "ASI 100% Lot") Then

                    strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut = '" & Session("Emp") & "',TimeOut = '" & Now() & "',GotoProcess = '" & Session("GOto") & "',Remark1 = '" & Session("DataRemark") & "',Remark2 = '" & Session("DataRemark1") & "',OPNO = '" & Session("Emp") & "' Where No ='" & dtLot.Rows(0)("NO") & "'"
                    objCmd = New SqlCommand(strSQLUpcase, objConn)
                    objCmd.ExecuteNonQuery()
                ElseIf (Session("Mode") = "BIN29,BIN30,BIN31" Or Session("Mode") = "BIN28") Then

                    strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut = '" & Session("Emp") & "',TimeOut = '" & Now() & "',GotoProcess = '" & Session("GOto") & "',Remark1 = '" & Session("DataRemark") & "',Remark2 = '" & Session("DataRemark1") & "',OPNO = '" & Session("Emp") & "' Where No ='" & dtLot.Rows(0)("NO") & "'"
                    objCmd = New SqlCommand(strSQLUpcase, objConn)
                    objCmd.ExecuteNonQuery()
                End If
            Else
                'Update ข้อมูลลงใน QYICase
                strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut = '" & Session("Emp") & "',TimeOut = '" & Now() & "',GotoProcess = '" & Session("GOto") & "',Remark1 = '" & Session("DataRemark") & "',Remark2 = '" & Session("DataRemark1") & "',OPNO = '" & Session("Emp") & "' Where No ='" & dtLot.Rows(0)("NO") & "'"
                objCmd = New SqlCommand(strSQLUpcase, objConn)
                objCmd.ExecuteNonQuery()
            End If
        End If


        Response.Redirect("Default.aspx")

    End Sub

End Class