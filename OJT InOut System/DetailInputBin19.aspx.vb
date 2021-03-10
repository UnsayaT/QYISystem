Imports System.Data.SqlClient
Imports OJT_InOut_System.ServiceLibrary

Public Class DetailInputBin19
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

        LotNo.Text = Session("LotNo")
        Process.Text = Session("Process")
        Package.Text = Session("Package")
        Device.Text = Session("Device")
        If Session("UserIDIn") <> "" Then
            Input1.Text = Session("UserIDIn")
        End If
        If Session("UserIDIn2") <> "" Then
            Input2.Text = Session("UserIDIn2")
        End If
        If Session("UserIDIn3") <> "" Then
            Input3.Text = Session("UserIDIn3")
        End If

        If Session("Bin19_1").ToString.Trim() <> "" Then
            txtBIN19_1.Text = Session("Bin19_1")
        End If
        If Session("Bin19_2").ToString.Trim() <> "" Then
            txtBIN19_2.Text = Session("Bin19_2")
        End If
        If Session("Bin19_3").ToString.Trim() <> "" Then
            txtBIN19_3.Text = Session("Bin19_3")
        End If

        If Session("Tester1").ToString.Trim() <> "" Then
            txtTester1.Text = Session("Tester1")
        End If
        If Session("Tester2").ToString.Trim() <> "" Then
            txtTester2.Text = Session("Tester2")
        End If
        If Session("Tester3").ToString.Trim() <> "" Then
            txtTester3.Text = Session("Tester3")
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strSQLInsert, strSQLNo, strSQLInIC, strSQLLot, strSQLStepNo, strSQLBackupNo, strSQLQYI, strSQLUpcase, Op_No, ret As String
        Dim dtAdapterNo, dtAdapterLot, dtStepNo, dtBackupNo, dtAdapterQYI As SqlDataAdapter
        Dim dt, dtpro, dtNo, dtEmp, dtLot, dtTran, dtFT, dtFL, dtMAP, dtStepNoID, dtBackup, dtQYI As New DataTable

        strSQLLot = "Select No,LotNo,Mode,
CASE WHEN TestFlow   IS NULL THEN '-' ELSE TestFlow END As Auto,
CASE WHEN TimeOut   IS NULL THEN '-' ELSE CONVERT(varchar, TimeOut, 101) END As DataOut,
CASE WHEN TimeOut2   IS NULL THEN '-' ELSE CONVERT(varchar, TimeOut2, 101) END As DataOut2,
CASE WHEN TimeOut3   IS NULL THEN '-' ELSE CONVERT(varchar, TimeOut3, 101) END As DataOut3
From [DBx].[QYI].[QYICase] Where LotNo ='" & Session("LotNo") & "' order by TimeIn DESC"
        dtAdapterLot = New SqlDataAdapter(strSQLLot, objConn)
        dtAdapterLot.Fill(dtLot)

        If Session("UserIDIn3") <> "" Then
            Op_No = Session("UserIDIn3")
        ElseIf Session("UserIDIn2") <> "" Then
            Op_No = Session("UserIDIn2")
        Else
            Op_No = Session("UserIDIn")
        End If

        Try
            '1.Set Up Lot ไปที่ APCS Pro
            Dim result = C_iLibgrarySevice.SetupLotNoCheckLicenser(Session("LotNo"), "TE-QYI-01", Op_No, "QYI", "")
            If result.IsPass = SetupLotResult.Status.NotPass Then
                ret = result.Type.ToString + "" + result.Cause
                Session("Error") = ret
                lblerror.Text = ret
            ElseIf result.IsPass = SetupLotResult.Status.Pass Then
                '2.Start Lot ไปที่ APCS Pro
                C_iLibgrarySevice.StartLot(Session("LotNo"), "TE-QYI-01", Op_No, result.Recipe)

                If dtLot.Rows.Count > 0 Then
                    'Add 2020-03-16 
                    If dtLot.Rows(0)("Mode") <> "BIN19" Then
                        '****เคยมี Lotนี้อยู่ที่ Qyi แล้ว แต่ Mode ไม่ตรงกัน ******ให้ทำการ Insert 
                        'คำนวณ No(primary key) 
                        Dim CountNo As String
                        Dim cheakyear As String
                        Dim countnext As Integer
                        Dim myDate As Date = Date.Now
                        Dim myYear As Int32 = myDate.Year
                        Session("InsertCaseNo") = myYear & "0001"

                        strSQLNo = "Select TOP (1) No FROM [DBx].[QYI].[QYICase] ORDER BY No DESC"
                        dtAdapterNo = New SqlDataAdapter(strSQLNo, objConn)
                        dtAdapterNo.Fill(dtNo)
                        If dtNo.Rows.Count > 0 Then
                            CountNo = dtNo.Rows(0)("No")
                            cheakyear = CountNo
                            cheakyear = Mid(cheakyear, 1, 4)
                            If myYear = cheakyear Then
                                countnext = CountNo + 1
                                Session("InsertCaseNo") = countnext
                            Else
                                Session("InsertCaseNo") = myYear & "00001"
                            End If
                        End If

                        'Insert Data ลง QYICase
                        strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,LotNo,Mode,TimeIn,UserIDIn,OldDeviceName,OldPackage,Bin19_1,Tester1)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("LotNo") & "','" & Session("Mode") & "','" & Now() & "','" & Op_No & "','" & Session("Device") & "','" & Session("Package") & "','" & txtBIN19_1.Text & "','" & txtTester1.Text & "')"
                        objCmd = New SqlCommand(strSQLInsert, objConn)
                        objCmd.ExecuteNonQuery()

                        'Insert Data ลง QYIICBurn
                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No)  VALUES ('" & Session("InsertCaseNo") & "')"
                        objCmd = New SqlCommand(strSQLInIC, objConn)
                        objCmd.ExecuteNonQuery()
                    Else
                        'แสดงว่ามี LotNoนี้อยู่แล้ว
                        If dtLot.Rows(0)("DataOut2") = "-" Then
                            'แสดงว่าเข้ารอบที่2 
                            strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Op_No & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "',BIN19_2='" & txtBIN19_2.Text & "',Tester2='" & txtTester2.Text & "' Where No='" & dtLot.Rows(0)("No") & "'"
                            objCmd = New SqlCommand(strSQLInsert, objConn)
                            objCmd.ExecuteNonQuery()
                        ElseIf dtLot.Rows(0)("DataOut2") <> "-" And dtLot.Rows(0)("DataOut3") = "-" Then
                            'แสดงว่าเข้ารอบที่3
                            strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn3 = '" & Op_No & "',TimeIn3 ='" & Now() & "',Mode3='" & Session("Mode") & "',BIN19_3='" & txtBIN19_3.Text & "',Tester3='" & txtTester3.Text & "' Where No='" & dtLot.Rows(0)("No") & "'"
                            objCmd = New SqlCommand(strSQLInsert, objConn)
                            objCmd.ExecuteNonQuery()
                        End If
                    End If
                Else
                    '****ไม่มีLot No ใน QYI******ให้ทำการ Insert 
                    'คำนวณ No(primary key) 
                    Dim CountNo As String
                    Dim cheakyear As String
                    Dim countnext As Integer
                    Dim myDate As Date = Date.Now
                    Dim myYear As Int32 = myDate.Year
                    Session("InsertCaseNo") = myYear & "0001"

                    strSQLNo = "Select TOP (1) No FROM [DBx].[QYI].[QYICase] ORDER BY No DESC"
                    dtAdapterNo = New SqlDataAdapter(strSQLNo, objConn)
                    dtAdapterNo.Fill(dtNo)
                    If dtNo.Rows.Count > 0 Then
                        CountNo = dtNo.Rows(0)("No")
                        cheakyear = CountNo
                        cheakyear = Mid(cheakyear, 1, 4)
                        If myYear = cheakyear Then
                            countnext = CountNo + 1
                            Session("InsertCaseNo") = countnext
                        Else
                            Session("InsertCaseNo") = myYear & "00001"
                        End If
                    End If

                    'Insert Data ลง QYICase
                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,LotNo,Mode,TimeIn,UserIDIn,OldDeviceName,OldPackage,Bin19_1,Tester1)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("LotNo") & "','" & Session("Mode") & "','" & Now() & "','" & Op_No & "','" & Session("Device") & "','" & Session("Package") & "','" & txtBIN19_1.Text & "','" & txtTester1.Text & "')"
                    objCmd = New SqlCommand(strSQLInsert, objConn)
                    objCmd.ExecuteNonQuery()

                    'Insert Data ลง QYIICBurn
                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No)  VALUES ('" & Session("InsertCaseNo") & "')"
                    objCmd = New SqlCommand(strSQLInIC, objConn)
                    objCmd.ExecuteNonQuery()
                End If



                'หา StepNo / BackupNo
                strSQLStepNo = "select lot_no , [APCSProDB].[method].[device_flows].device_slip_id, [APCSProDB].[method].[device_flows].step_no,name
   from [APCSProDB].[trans].[lots] INNER JOIN [APCSProDB].[method].[device_flows] ON [APCSProDB].[trans].[lots].device_slip_id  = [APCSProDB].[method].[device_flows].device_slip_id 
   INNER JOIN  [APCSProDB].[method].[jobs] ON [APCSProDB].[method].[device_flows].job_id = [APCSProDB].[method].[jobs].id
   where lot_no='" & Session("LotNo") & "' and name='AUTO(3)'"
                dtStepNo = New SqlDataAdapter(strSQLStepNo, objConnPro)
                dtStepNo.Fill(dtStepNoID)
                If dtStepNoID.Rows.Count > 0 Then
                    Session("StepNo") = dtStepNoID.Rows(0)("step_no")
                End If

                strSQLBackupNo = "select lot_no , [APCSProDB].[method].[device_flows].device_slip_id, [APCSProDB].[method].[device_flows].step_no,name
   from [APCSProDB].[trans].[lots] INNER JOIN [APCSProDB].[method].[device_flows] ON [APCSProDB].[trans].[lots].device_slip_id  = [APCSProDB].[method].[device_flows].device_slip_id 
   INNER JOIN  [APCSProDB].[method].[jobs] ON [APCSProDB].[method].[device_flows].job_id = [APCSProDB].[method].[jobs].id
   where lot_no='" & Session("LotNo") & "' and name='AUTO(4)'"
                dtBackupNo = New SqlDataAdapter(strSQLBackupNo, objConnPro)
                dtBackupNo.Fill(dtBackup)
                If dtBackup.Rows.Count > 0 Then
                    Session("BackupNo") = dtBackup.Rows(0)("step_no")
                End If

                If dtLot.Rows.Count > 0 Then
                    If dtLot.Rows(0)("DataOut2") = "-" And dtLot.Rows(0)("Mode") = "BIN19" Then
                        If (txtBIN19_2.Text <> txtTester2.Text) Then
                            ''End Lot โดย WCF และ Add special Flow โดย Storage2201 
                            Dim LotID As String = Session("LotNo")
                            Dim StepNo As Integer = Session("StepNo") + 1
                            Dim BackupNo As Integer = Session("BackupNo")
                            Dim UserId As String = Op_No
                            Dim FlowPattern As Decimal = 1514
                            Dim SpecialFlow As Decimal = 1

                            C_iLibgrarySevice.EndLotNoCheckLicenser(Session("LotNo"), "TE-QYI-01", Op_No, 0, 0)

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
                            strSQLQYI = "Select Top(1) * FROM [DBx].[QYI].[QYICase] Where LotNo ='" & Session("LotNo") & "'  order By TimeIn DESC"
                            dtAdapterQYI = New SqlDataAdapter(strSQLQYI, objConn)
                            dtAdapterQYI.Fill(dtQYI)
                            If dtQYI.Rows.Count > 0 Then
                                Session("QYINo") = dtQYI.Rows(0)("No")
                                'Update ข้อมูลลงใน QYICase
                                strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & Op_No & "' " &
                                " ,TimeOut2 = '" & Now() & "',GotoProcess2 = 'Retest Auto3 Bin19',Reason2 = 'Counter Inconsistent' Where No ='" & Session("QYINo") & "'"
                                objCmd = New SqlCommand(strSQLUpcase, objConn)
                                objCmd.ExecuteNonQuery()

                                Page.RegisterClientScriptBlock("OnLoad", "<script>alert('ระบบได้ทำการ Out Lotเรียบร้อยแล้ว กรูณายกLot ไปยัง Process ถัดไป')</script>")
                                'Response.Redirect("~/Default.aspx")
                                Response.Write("<script>window.open('/Default.aspx,'_self');</script>")
                            End If
                        Else
                            'Response.Redirect("~/Default.aspx")
                            Response.Write("<script>window.open('/Default.aspx,'_self');</script>")
                        End If
                    Else
                        'เข้ามารอบแรก จำนวนทั้ง3 จำนวน FTNG / BIN19 / Tester เท่ากันไหม ถ้าไม่เท่ากันให้ทำการRetest ทันที
                        If (txtBIN19_3.Text <> txtTester3.Text) Then
                            ''End Lot โดย WCF และ Add special Flow โดย Storage2201 
                            Dim LotID As String = Session("LotNo")
                            Dim StepNo As Integer = Session("StepNo") + 1
                            Dim BackupNo As Integer = Session("BackupNo")
                            Dim UserId As String = Op_No
                            Dim FlowPattern As Decimal = 1514

                            Dim SpecialFlow As Decimal = 1

                            C_iLibgrarySevice.EndLotNoCheckLicenser(Session("LotNo"), "TE-QYI-01", Op_No, 0, 0)

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
                            strSQLQYI = "Select Top(1) * FROM [DBx].[QYI].[QYICase] Where LotNo ='" & Session("LotNo") & "'  order By TimeIn DESC"
                            dtAdapterQYI = New SqlDataAdapter(strSQLQYI, objConn)
                            dtAdapterQYI.Fill(dtQYI)
                            If dtQYI.Rows.Count > 0 Then
                                Session("QYINo") = dtQYI.Rows(0)("No")
                                'Update ข้อมูลลงใน QYICase
                                strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut = '" & Op_No & "' " &
                            " ,TimeOut = '" & Now() & "',GotoProcess = 'Retest Auto3 Bin19',Reason1='Counter Inconsistent' Where No ='" & Session("QYINo") & "'"
                                objCmd = New SqlCommand(strSQLUpcase, objConn)
                                objCmd.ExecuteNonQuery()

                                Page.RegisterClientScriptBlock("OnLoad", "<script>alert('ระบบได้ทำการ Out Lotเรียบร้อยแล้ว กรูณายกLot ไปยัง Process ถัดไป')</script>")
                                Response.Write("<script>window.open('/Default.aspx,'_self');</script>")
                            End If
                        Else
                            Response.Write("<script>window.open('/Default.aspx,'_self');</script>")
                        End If
                    End If
                Else
                    'เข้ามารอบแรก จำนวนทั้ง3 จำนวน FTNG / BIN19 / Tester เท่ากันไหม ถ้าไม่เท่ากันให้ทำการRetest ทันที
                    If (txtBIN19_1.Text <> txtTester1.Text) Then
                        ''End Lot โดย WCF และ Add special Flow โดย Storage2201 
                        Dim LotID As String = Session("LotNo")
                        Dim StepNo As Integer = Session("StepNo") + 1
                        Dim BackupNo As Integer = Session("BackupNo")
                        Dim UserId As String = Op_No
                        Dim FlowPattern As Decimal = 1514

                        Dim SpecialFlow As Decimal = 1

                        C_iLibgrarySevice.EndLotNoCheckLicenser(Session("LotNo"), "TE-QYI-01", Op_No, 0, 0)

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
                        strSQLQYI = "Select Top(1) * FROM [DBx].[QYI].[QYICase] Where LotNo ='" & Session("LotNo") & "'  order By TimeIn DESC"
                        dtAdapterQYI = New SqlDataAdapter(strSQLQYI, objConn)
                        dtAdapterQYI.Fill(dtQYI)
                        If dtQYI.Rows.Count > 0 Then
                            Session("QYINo") = dtQYI.Rows(0)("No")
                            'Update ข้อมูลลงใน QYICase
                            strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut = '" & Op_No & "' " &
                        " ,TimeOut = '" & Now() & "',GotoProcess = 'Retest Auto3 Bin19',Reason1='Counter Inconsistent' Where No ='" & Session("QYINo") & "'"
                            objCmd = New SqlCommand(strSQLUpcase, objConn)
                            objCmd.ExecuteNonQuery()

                            Page.RegisterClientScriptBlock("OnLoad", "<script>alert('ระบบได้ทำการ Out Lotเรียบร้อยแล้ว กรูณายกLot ไปยัง Process ถัดไป')</script>")
                            Response.Write("<script>window.open('/Default.aspx,'_self');</script>")
                        End If
                    Else
                        Response.Write("<script>window.open('/Default.aspx,'_self');</script>")
                    End If
                End If
            End If
        Catch ex As Exception
            ret = ex.Message
        End Try
    End Sub

End Class