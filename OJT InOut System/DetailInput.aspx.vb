Imports System.Data.SqlClient
Imports OJT_InOut_System.ServiceLibrary
Public Class DetailInput
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

        LotNo.Text = Session("CheckLotNo")
        'Package.Text = Session("InsertPackage")
        txtPackage.Text = Session("InsertPackage")
        'Device.Text = Session("InsertDevice")
        txtDevice.Text = Session("InsertDevice")
        Process.Text = Session("Process")

        If Session("Process") = "FT" Then
            Process.Text = Session("Process")
            Machine.Text = Session("InsertMCNoFT")
            LotStartTime.Text = Session("InsertLotStartTimeFT")
        ElseIf Session("Process") = "FL" Then
            Process.Text = Session("Process")
            Machine.Text = Session("InsertMCNoFL")
            LotStartTime.Text = Session("InsertLotStartTimeFL")
        ElseIf Session("Process") = "MAP" Then
            Process.Text = Session("Process")
            Machine.Text = Session("InsertMCNoMAP")
            LotStartTime.Text = Session("InsertLotStartTimeMAP")
        End If

        Program.Text = Session("InsertProgramName")
        WaferLotNo.Text = Session("InsertWaferLotNo")
        MarkNo.Text = Session("InsertMarkNo")
        TestFlow.Text = Session("InsertTestFlowName")
        FinalYield.Text = Session("InsertTestFinalYield")
        TesterName.Text = Session("InsertTesterName")
        TestBoxName.Text = Session("InsertBoxName")
        Mode.Text = Session("Mode")
        Input.Text = Session("Input")
        WaferNo.Text = Session("WaferNo")
        ShipmentDate.Text = Session("Shipment")

        'If Session("Mode") = "LCL" Or Session("Mode") = "Yield < 80 %" Then
        'RadioButton10.Enabled = True
        'RadioButton11.Enabled = True
        'End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strSQLInsert, strSQLNo, strSQLInIC, lot, Op_No, strSQLLot, ret, Pack, strSQLPackages As String
        Dim dtAdapterNo, dtAdapterLot, dtAdapterPackages As SqlDataAdapter
        Dim dt, dtpro, dtNo, dtEmp, dtLot, dtFT, dtFL, dtMAP, dtPackages As New DataTable

        'Check Packages ใน Database ของ APCSPro
        strSQLPackages = "Select name From [APCSProDB].[method].[packages] Where short_name='" & Session("Package") & "'"
        dtAdapterPackages = New SqlDataAdapter(strSQLPackages, objConnPro)
        dtAdapterPackages.Fill(dtPackages)
        If dtPackages.Rows.Count > 0 Then
            Session("PackagePro") = dtPackages.Rows(0)("name")
        End If

        lot = Session("CheckLotNo")
        Op_No = Session("Input")
        Pack = Session("PackagePro")

        Dim kb As Date
        kb = Date.Now.AddDays(180)
        Session("InsertKanban") = kb

        'ALL Lot no
        If txtLotNo16.Text <> "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString() & " " & Session("txtLotNo7.Text").ToString() & " " & Session("txtLotNo8.Text").ToString() & " " & Session("txtLotNo9.Text").ToString() & " " & Session("txtLotNo10.Text").ToString() & " " &
                Session("txtLotNo11.Text").ToString() & " " & Session("txtLotNo12.Text").ToString() & " " & Session("txtLotNo13.Text").ToString() & " " & Session("txtLotNo14.Text").ToString() & " " & Session("txtLotNo15.Text").ToString() & " " & Session("txtLotNo16.Text").ToString()

        ElseIf txtLotNo15.Text <> "" And txtLotNo16.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString() & " " & Session("txtLotNo7.Text").ToString() & " " & Session("txtLotNo8.Text").ToString() & " " & Session("txtLotNo9.Text").ToString() & " " & Session("txtLotNo10.Text").ToString() & " " &
                Session("txtLotNo11.Text").ToString() & " " & Session("txtLotNo12.Text").ToString() & " " & Session("txtLotNo13.Text").ToString() & " " & Session("txtLotNo14.Text").ToString() & " " & Session("txtLotNo15.Text").ToString()

        ElseIf txtLotNo14.Text <> "" And txtLotNo15.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString() & " " & Session("txtLotNo7.Text").ToString() & " " & Session("txtLotNo8.Text").ToString() & " " & Session("txtLotNo9.Text").ToString() & " " & Session("txtLotNo10.Text").ToString() & " " &
                Session("txtLotNo11.Text").ToString() & " " & Session("txtLotNo12.Text").ToString() & " " & Session("txtLotNo13.Text").ToString() & " " & Session("txtLotNo14.Text").ToString()

        ElseIf txtLotNo13.Text <> "" And txtLotNo14.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString() & " " & Session("txtLotNo7.Text").ToString() & " " & Session("txtLotNo8.Text").ToString() & " " & Session("txtLotNo9.Text").ToString() & " " & Session("txtLotNo10.Text").ToString() & " " &
                Session("txtLotNo11.Text").ToString() & " " & Session("txtLotNo12.Text").ToString() & " " & Session("txtLotNo13.Text").ToString()

        ElseIf txtLotNo12.Text <> "" And txtLotNo13.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString() & " " & Session("txtLotNo7.Text").ToString() & " " & Session("txtLotNo8.Text").ToString() & " " & Session("txtLotNo9.Text").ToString() & " " & Session("txtLotNo10.Text").ToString() & " " &
                Session("txtLotNo11.Text").ToString() & " " & Session("txtLotNo12.Text").ToString()

        ElseIf txtLotNo11.Text <> "" And txtLotNo12.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString() & " " & Session("txtLotNo7.Text").ToString() & " " & Session("txtLotNo8.Text").ToString() & " " & Session("txtLotNo9.Text").ToString() & " " & Session("txtLotNo10.Text").ToString() & " " &
                Session("txtLotNo11.Text").ToString()

        ElseIf txtLotNo10.Text <> "" And txtLotNo11.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString() & " " & Session("txtLotNo7.Text").ToString() & " " & Session("txtLotNo8.Text").ToString() & " " & Session("txtLotNo9.Text").ToString() & " " & Session("txtLotNo10.Text").ToString()

        ElseIf txtLotNo9.Text <> "" And txtLotNo10.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString() & " " & Session("txtLotNo7.Text").ToString() & " " & Session("txtLotNo8.Text").ToString() & " " & Session("txtLotNo9.Text").ToString()

        ElseIf txtLotNo8.Text <> "" And txtLotNo9.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString() & " " & Session("txtLotNo7.Text").ToString() & " " & Session("txtLotNo8.Text").ToString()

        ElseIf txtLotNo7.Text <> "" And txtLotNo9.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString() & " " & Session("txtLotNo7.Text").ToString()

        ElseIf txtLotNo6.Text <> "" And txtLotNo7.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString() & " " &
                Session("txtLotNo6.Text").ToString()

        ElseIf txtLotNo5.Text <> "" And txtLotNo6.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString() & " " & Session("txtLotNo5.Text").ToString()

        ElseIf txtLotNo4.Text <> "" And txtLotNo5.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString() & " " & Session("txtLotNo4.Text").ToString()

        ElseIf txtLotNo3.Text <> "" And txtLotNo4.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString() & " " & Session("txtLotNo3.Text").ToString()

        ElseIf txtLotNo2.Text <> "" And txtLotNo3.Text = "" Then
            Session("ScanInput1") = Session("txtLotNo1.Text") & " " & Session("txtLotNo2.Text").ToString()

        ElseIf LotNo.Text <> "" And txtLotNo2.Text = "" Then
            Session("ScanInput1") = Session("CheckLotNo")
        End If

        'Status Flow FYI
        If RadioButton10.Checked = True Then
            Session("StatusFlowFYI") = "FYI"
        ElseIf RadioButton11.Checked = True Then
            Session("StatusFlowFYI") = "Finish"
        Else
            Session("StatusFlowFYI") = ""
        End If

        'Check Lot No ใน QYI
        strSQLLot = "Select No,LotNo,CONVERT(varchar, TimeOut, 101) As Out1,CASE WHEN TimeOut2 IS NULL THEN ''
   ELSE CONVERT(varchar, TimeOut2, 101) End As Out2,GotoProcess,Mode From [DBx].[QYI].[QYICase] Where LotNo ='" & Session("CheckLotNo") & "'"
        dtAdapterLot = New SqlDataAdapter(strSQLLot, objConn)
        dtAdapterLot.Fill(dtLot)

        'WCF Check Packge 
        Dim CheckPackge = C_iLibgrarySevice.CheckPackageOnlyApcsPro("TE-QYI-01", Pack, Op_No, lot)
        If CheckPackge = False Then

            'Packge นี้ไม่มีใน APCSPro ไม่ต้องเรียกใช้ WCF

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


            If dtLot.Rows.Count > 0 Then
                'Check เข้ามารอบที่1 Mode ตรงกับ Mode ที่เรียกเข้ามาใหม่หรือไม่ ?
                ''ถ้าไม่ให้ทำการ Insert 
                If dtLot.Rows(0)("Mode") <> Session("Mode") Then
                    'Insert Data ลง QYICase
                    If Session("Process") = "FT" Then
                        strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "'
,'" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                        objCmd = New SqlCommand(strSQLInsert, objConn)
                        objCmd.ExecuteNonQuery()
                    ElseIf Session("Process") = "FL" Then
                        strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FLMCNo,FLLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFL") & "','" & Session("InsertLotStartTimeFL") & "'
,'" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                        objCmd = New SqlCommand(strSQLInsert, objConn)
                        objCmd.ExecuteNonQuery()
                    ElseIf Session("Process") = "MAP" Then
                        strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,MAPMCNo,MAPLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "'
,'" & Session("InsertMCNoMAP") & "','" & Session("InsertLotStartTimeMAP") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                        objCmd = New SqlCommand(strSQLInsert, objConn)
                        objCmd.ExecuteNonQuery()
                    End If

                    If Mode.Text = "LCL" Or Mode.Text = "Yield < 80 %" Or Mode.Text = "ASI 100% Lot" Then
                        'Insert Data ลง QYILowYield
                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                        objCmd = New SqlCommand(strSQLInIC, objConn)
                        objCmd.ExecuteNonQuery()

                        Response.Write("<script>window.close();</script>")

                    ElseIf Mode.Text = "BIN28" Or Mode.Text = "BIN29,BIN30,BIN31" Then
                        'Insert Data ลง QYIICBurn
                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                        objCmd = New SqlCommand(strSQLInIC, objConn)
                        objCmd.ExecuteNonQuery()
                        Response.Write("<script>window.close();</script>")
                    ElseIf Mode.Text = "BIN13,BIN14" Then
                        'Insert Data ลง QYIICBurn
                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                        objCmd = New SqlCommand(strSQLInIC, objConn)
                        objCmd.ExecuteNonQuery()
                        Response.Write("<script>window.close();</script>")
                    ElseIf Mode.Text = "Lot Eva Test Equipment" Or Mode.Text = "Lot Eva New Device" Then
                        'Insert Data ลง LotEva
                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILotEva] (No)  VALUES ('" & Session("InsertCaseNo") & "')"
                        objCmd = New SqlCommand(strSQLInIC, objConn)
                        objCmd.ExecuteNonQuery()
                        Response.Write("<script>window.close();</script>")
                    End If

                Else
                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                    objCmd = New SqlCommand(strSQLInsert, objConn)
                    objCmd.ExecuteNonQuery()
                End If
            Else
                'Insert Data ลง QYICase
                If Session("Process") = "FT" Then
                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "'
,'" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                    objCmd = New SqlCommand(strSQLInsert, objConn)
                    objCmd.ExecuteNonQuery()
                ElseIf Session("Process") = "FL" Then
                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FLMCNo,FLLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFL") & "','" & Session("InsertLotStartTimeFL") & "'
,'" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                    objCmd = New SqlCommand(strSQLInsert, objConn)
                    objCmd.ExecuteNonQuery()
                ElseIf Session("Process") = "MAP" Then
                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,MAPMCNo,MAPLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "'
,'" & Session("InsertMCNoMAP") & "','" & Session("InsertLotStartTimeMAP") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                    objCmd = New SqlCommand(strSQLInsert, objConn)
                    objCmd.ExecuteNonQuery()
                End If

                If Mode.Text = "LCL" Or Mode.Text = "Yield < 80 %" Or Mode.Text = "ASI 100% Lot" Then
                    'Insert Data ลง QYILowYield
                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                    objCmd = New SqlCommand(strSQLInIC, objConn)
                    objCmd.ExecuteNonQuery()

                    Response.Write("<script>window.close();</script>")
                ElseIf Mode.Text = "BIN28" Or Mode.Text = "BIN29,BIN30,BIN31" Then
                    'Insert Data ลง QYIICBurn
                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                    objCmd = New SqlCommand(strSQLInIC, objConn)
                    objCmd.ExecuteNonQuery()

                    Response.Write("<script>window.close();</script>")
                ElseIf Mode.Text = "BIN13,BIN14" Then
                    'Insert Data ลง QYIICBurn
                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                    objCmd = New SqlCommand(strSQLInIC, objConn)
                    objCmd.ExecuteNonQuery()

                    Response.Write("<script>window.close();</script>")
                ElseIf Mode.Text = "Lot Eva Test Equipment" Or Mode.Text = "Lot Eva New Device" Then
                    'Insert Data ลง LotEva
                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILotEva] (No)  VALUES ('" & Session("InsertCaseNo") & "')"
                    objCmd = New SqlCommand(strSQLInIC, objConn)
                    objCmd.ExecuteNonQuery()

                    Response.Write("<script>window.close();</script>")
                End If
            End If
        ElseIf CheckPackge = True Then
            'Packge นี้มีใน APCSPro เรียกใช้ WCF
            If Session("Process") = "FT" And Session("Mode") = "LCL" Then
                Try
                    Dim Cinfo As CarrierInfo = C_iLibgrarySevice.GetCarrierInfo("TE-QYI-01", lot, Op_No)
                    Dim result = C_iLibgrarySevice.SetupLotPhase2(lot, "TE-QYI-01", Op_No, "QYI", Licenser.NoCheck, Cinfo, New SetupLotSpecialParametersEventArgs())
                    If result.IsPass = SetupLotResult.Status.NotPass Then
                        ret = result.Type.ToString + "" + result.Cause
                        lblerror.Text = ret
                    ElseIf result.IsPass = SetupLotResult.Status.Pass Or result.IsPass = SetupLotResult.Status.Warning Then
                        C_iLibgrarySevice.StartLotPhase2(lot, "TE-QYI-01", Op_No, result.Recipe, Cinfo, New StartLotSpecialParametersEventArgs())

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


                        If dtLot.Rows.Count > 0 Then
                            'Check เข้ามารอบที่1 Mode ตรงกับ Mode ที่เรียกเข้ามาใหม่หรือไม่ ?
                            ''ถ้าไม่ให้ทำการ Insert 
                            If dtLot.Rows(0)("Mode") <> Session("Mode") Then
                                'Insert Data ลง QYICase
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()

                                If Mode.Text = "LCL" Then
                                    'Insert Data ลง QYILowYield
                                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                                    objCmd = New SqlCommand(strSQLInIC, objConn)
                                    objCmd.ExecuteNonQuery()

                                    Response.Write("<script>window.close();</script>")
                                End If
                            Else
                                If dtLot.Rows(0)("GotoProcess") = "Retest FT Auto1" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto2" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto3" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto4" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                Else
                                    'Insert Data ลง QYICase
                                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                    VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()

                                    If Mode.Text = "LCL" Then
                                        'Insert Data ลง QYILowYield
                                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                                        objCmd = New SqlCommand(strSQLInIC, objConn)
                                        objCmd.ExecuteNonQuery()

                                        Response.Write("<script>window.close();</script>")
                                    End If
                                End If
                            End If
                        Else
                            'Insert Data ลง QYICase
                            strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                            VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                            objCmd = New SqlCommand(strSQLInsert, objConn)
                            objCmd.ExecuteNonQuery()

                            If Mode.Text = "LCL" Then
                                'Insert Data ลง QYILowYield
                                strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                                objCmd = New SqlCommand(strSQLInIC, objConn)
                                objCmd.ExecuteNonQuery()

                                Response.Write("<script>window.close();</script>")
                            End If

                        End If
                    End If
                Catch ex As Exception
                    ret = ex.Message
                End Try

            ElseIf Session("Process") = "FT" And Session("Mode") = "Yield < 80 %" Then
                Try
                    'Dim result = C_iLibgrarySevice.SetupLotNoCheckLicenser(lot, "TE-QYI-01", Op_No, "QYI", "")
                    Dim Cinfo As CarrierInfo = C_iLibgrarySevice.GetCarrierInfo("TE-QYI-01", lot, Op_No)
                    Dim result = C_iLibgrarySevice.SetupLotPhase2(lot, "TE-QYI-01", Op_No, "QYI", Licenser.NoCheck, Cinfo, New SetupLotSpecialParametersEventArgs())
                    If result.IsPass = SetupLotResult.Status.NotPass Then
                        ret = result.Type.ToString + "" + result.Cause
                        lblerror.Text = ret
                    ElseIf result.IsPass = SetupLotResult.Status.Pass Or result.IsPass = SetupLotResult.Status.Warning Then

                        C_iLibgrarySevice.StartLotPhase2(lot, "TE-QYI-01", Op_No, result.Recipe, Cinfo, New StartLotSpecialParametersEventArgs())


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


                        If dtLot.Rows.Count > 0 Then
                            'Check เข้ามารอบที่1 Mode ตรงกับ Mode ที่เรียกเข้ามาใหม่หรือไม่ ?
                            ''ถ้าไม่ให้ทำการ Insert 
                            If dtLot.Rows(0)("Mode") <> Session("Mode") Then
                                'Insert Data ลง QYICase
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()

                                If Mode.Text = "Yield < 80 %" Then
                                    'Insert Data ลง QYILowYield
                                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                                    objCmd = New SqlCommand(strSQLInIC, objConn)
                                    objCmd.ExecuteNonQuery()

                                    Response.Write("<script>window.close();</script>")
                                End If
                            Else
                                If dtLot.Rows(0)("GotoProcess") = "Retest FT Auto1" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto2" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto3" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto4" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                Else
                                    'Insert Data ลง QYICase
                                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                    VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()

                                    If Mode.Text = "Yield < 80 %" Then
                                        'Insert Data ลง QYILowYield
                                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                                        objCmd = New SqlCommand(strSQLInIC, objConn)
                                        objCmd.ExecuteNonQuery()

                                        Response.Write("<script>window.close();</script>")
                                    End If
                                End If
                            End If
                        Else
                            'Insert Data ลง QYICase
                            If Session("Process") = "FT" Then
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "'
,'" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()
                            End If

                            If Mode.Text = "Yield < 80 %" Then
                                'Insert Data ลง QYILowYield
                                strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                                objCmd = New SqlCommand(strSQLInIC, objConn)
                                objCmd.ExecuteNonQuery()

                                Response.Write("<script>window.close();</script>")
                            End If

                        End If
                    End If
                Catch ex As Exception
                    ret = ex.Message
                End Try
            ElseIf Session("Process") = "FT" And Session("Mode") = "ASI 100% Lot" Then
                Try
                    Dim Cinfo As CarrierInfo = C_iLibgrarySevice.GetCarrierInfo("TE-QYI-01", lot, Op_No)
                    Dim result = C_iLibgrarySevice.SetupLotPhase2(lot, "TE-QYI-01", Op_No, "QYI", Licenser.NoCheck, Cinfo, New SetupLotSpecialParametersEventArgs())
                    If result.IsPass = SetupLotResult.Status.NotPass Then
                        ret = result.Type.ToString + "" + result.Cause
                        lblerror.Text = ret
                    ElseIf result.IsPass = SetupLotResult.Status.Pass Or result.IsPass = SetupLotResult.Status.Warning Then
                        C_iLibgrarySevice.StartLotPhase2(lot, "TE-QYI-01", Op_No, result.Recipe, Cinfo, New StartLotSpecialParametersEventArgs())

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


                        If dtLot.Rows.Count > 0 Then
                            'Check เข้ามารอบที่1 Mode ตรงกับ Mode ที่เรียกเข้ามาใหม่หรือไม่ ?
                            ''ถ้าไม่ให้ทำการ Insert 
                            If dtLot.Rows(0)("Mode") <> Session("Mode") Then
                                'Insert Data ลง QYICase
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()

                                If Mode.Text = "ASI 100% Lot" Then
                                    'Insert Data ลง QYILowYield
                                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                                    objCmd = New SqlCommand(strSQLInIC, objConn)
                                    objCmd.ExecuteNonQuery()

                                    Response.Write("<script>window.close();</script>")
                                End If
                            Else
                                If dtLot.Rows(0)("GotoProcess") = "Retest FT Auto1" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto2" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto3" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto4" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                Else
                                    'Insert Data ลง QYICase
                                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                    VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()

                                    If Mode.Text = "ASI 100% Lot" Then
                                        'Insert Data ลง QYILowYield
                                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                                        objCmd = New SqlCommand(strSQLInIC, objConn)
                                        objCmd.ExecuteNonQuery()

                                        Response.Write("<script>window.close();</script>")
                                    End If
                                End If
                            End If
                        Else
                            'Insert Data ลง QYICase
                            If Session("Process") = "FT" Then
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "'
,'" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()
                            End If

                            If Mode.Text = "ASI 100% Lot" Then
                                'Insert Data ลง QYIICBurn
                                strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                                objCmd = New SqlCommand(strSQLInIC, objConn)
                                objCmd.ExecuteNonQuery()

                                Response.Write("<script>window.close();</script>")
                            End If
                        End If
                    End If
                Catch ex As Exception
                    ret = ex.Message
                End Try
            ElseIf Session("Process") = "FT" And Session("Mode") = "BIN29,BIN30,BIN31" Then
                Try
                    Dim Cinfo As CarrierInfo = C_iLibgrarySevice.GetCarrierInfo("TE-QYI-01", lot, Op_No)
                    Dim result = C_iLibgrarySevice.SetupLotPhase2(lot, "TE-QYI-01", Op_No, "QYI", Licenser.NoCheck, Cinfo, New SetupLotSpecialParametersEventArgs())
                    If result.IsPass = SetupLotResult.Status.NotPass Then
                        ret = result.Type.ToString + "" + result.Cause
                        lblerror.Text = ret
                    ElseIf result.IsPass = SetupLotResult.Status.Pass Or result.IsPass = SetupLotResult.Status.Warning Then
                        C_iLibgrarySevice.StartLotPhase2(lot, "TE-QYI-01", Op_No, result.Recipe, Cinfo, New StartLotSpecialParametersEventArgs())

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


                        If dtLot.Rows.Count > 0 Then
                            'Check เข้ามารอบที่1 Mode ตรงกับ Mode ที่เรียกเข้ามาใหม่หรือไม่ ?
                            ''ถ้าไม่ให้ทำการ Insert 
                            If dtLot.Rows(0)("Mode") <> Session("Mode") Then
                                'Insert Data ลง QYICase
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()

                                If Mode.Text = "BIN29,BIN30,BIN31" Then
                                    'Insert Data ลง QYIICBurn
                                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                                    objCmd = New SqlCommand(strSQLInIC, objConn)
                                    objCmd.ExecuteNonQuery()

                                    Response.Write("<script>window.close();</script>")
                                End If
                            Else
                                If dtLot.Rows(0)("GotoProcess") = "Retest FT Auto1" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto2" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto3" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto4" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                Else
                                    'Insert Data ลง QYICase
                                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                    VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()

                                    If Mode.Text = "BIN29,BIN30,BIN31" Then
                                        'Insert Data ลง QYIICBurn
                                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                                        objCmd = New SqlCommand(strSQLInIC, objConn)
                                        objCmd.ExecuteNonQuery()

                                        Response.Write("<script>window.close();</script>")
                                    End If
                                End If
                            End If
                        Else
                            'Insert Data ลง QYICase
                            If Session("Process") = "FT" Then
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()
                            End If

                            If Mode.Text = "BIN29,BIN30,BIN31" Then
                                'Insert Data ลง QYIICBurn
                                strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                                objCmd = New SqlCommand(strSQLInIC, objConn)
                                objCmd.ExecuteNonQuery()

                                Response.Write("<script>window.close();</script>")
                            End If
                        End If
                    End If
                Catch ex As Exception
                    ret = ex.Message
                End Try

            ElseIf Session("Process") = "FT" And Session("Mode") = "BIN28" Then

                Try
                    Dim Cinfo As CarrierInfo = C_iLibgrarySevice.GetCarrierInfo("TE-QYI-01", lot, Op_No)
                    Dim result = C_iLibgrarySevice.SetupLotPhase2(lot, "TE-QYI-01", Op_No, "QYI", Licenser.NoCheck, Cinfo, New SetupLotSpecialParametersEventArgs())
                    If result.IsPass = SetupLotResult.Status.NotPass Then
                        ret = result.Type.ToString + "" + result.Cause
                        lblerror.Text = ret
                    ElseIf result.IsPass = SetupLotResult.Status.Pass Or result.IsPass = SetupLotResult.Status.Warning Then
                        C_iLibgrarySevice.StartLotPhase2(lot, "TE-QYI-01", Op_No, result.Recipe, Cinfo, New StartLotSpecialParametersEventArgs())

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


                        If dtLot.Rows.Count > 0 Then
                            'Check เข้ามารอบที่1 Mode ตรงกับ Mode ที่เรียกเข้ามาใหม่หรือไม่ ?
                            ''ถ้าไม่ให้ทำการ Insert 
                            If dtLot.Rows(0)("Mode") <> Session("Mode") Then
                                'Insert Data ลง QYICase
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()

                                If Mode.Text = "BIN29,BIN30,BIN31" Then
                                    'Insert Data ลง QYIICBurn
                                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                                    objCmd = New SqlCommand(strSQLInIC, objConn)
                                    objCmd.ExecuteNonQuery()

                                    Response.Write("<script>window.close();</script>")
                                End If
                            Else
                                If dtLot.Rows(0)("GotoProcess") = "Retest FT Auto1" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto2" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto3" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto4" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                Else
                                    'Insert Data ลง QYICase
                                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                    VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()

                                    If Mode.Text = "BIN29,BIN30,BIN31" Then
                                        'Insert Data ลง QYIICBurn
                                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                                        objCmd = New SqlCommand(strSQLInIC, objConn)
                                        objCmd.ExecuteNonQuery()

                                        Response.Write("<script>window.close();</script>")
                                    End If
                                End If
                            End If

                        Else
                            'Insert Data ลง QYICase
                            If Session("Process") = "FT" Then
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()
                            End If

                            If Mode.Text = "BIN29,BIN30,BIN31" Then
                                'Insert Data ลง QYIICBurn
                                strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                                objCmd = New SqlCommand(strSQLInIC, objConn)
                                objCmd.ExecuteNonQuery()

                                Response.Write("<script>window.close();</script>")
                            End If
                        End If
                    End If
                Catch ex As Exception
                    ret = ex.Message
                End Try
            ElseIf Session("Process") = "FT" And (Session("Mode") = "Lot Eva Test Equipment" Or Session("Mode") = "Lot Eva New Device") Then

                '*** ADD 2020-09-12 ***'
                Try
                    Dim Cinfo As CarrierInfo = C_iLibgrarySevice.GetCarrierInfo("TE-QYI-01", lot, Op_No)
                    Dim result = C_iLibgrarySevice.SetupLotPhase2(lot, "TE-QYI-01", Op_No, "QYI", Licenser.NoCheck, Cinfo, New SetupLotSpecialParametersEventArgs())
                    If result.IsPass = SetupLotResult.Status.NotPass Then
                        ret = result.Type.ToString + "" + result.Cause
                        lblerror.Text = ret
                    ElseIf result.IsPass = SetupLotResult.Status.Pass Or result.IsPass = SetupLotResult.Status.Warning Then
                        C_iLibgrarySevice.StartLotPhase2(lot, "TE-QYI-01", Op_No, result.Recipe, Cinfo, New StartLotSpecialParametersEventArgs())

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


                        If dtLot.Rows.Count > 0 Then
                            'Check เข้ามารอบที่1 Mode ตรงกับ Mode ที่เรียกเข้ามาใหม่หรือไม่ ?
                            ''ถ้าไม่ให้ทำการ Insert 
                            If dtLot.Rows(0)("Mode") <> Session("Mode") Then
                                'Insert Data ลง QYICase
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()

                                If Mode.Text = "Lot Eva Test Equipment" Or Mode.Text = "Lot Eva New Device" Then
                                    'Insert Data ลง LotEva
                                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILotEva] (No)  VALUES ('" & Session("InsertCaseNo") & "')"
                                    objCmd = New SqlCommand(strSQLInIC, objConn)
                                    objCmd.ExecuteNonQuery()

                                    Response.Write("<script>window.close();</script>")
                                End If
                            Else
                                If dtLot.Rows(0)("GotoProcess") = "Retest FT Auto1" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto2" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto3" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto4" Then
                                    strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                Else
                                    'Insert Data ลง QYICase
                                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                                    VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()

                                    If Mode.Text = "Lot Eva Test Equipment" Or Mode.Text = "Lot Eva New Device" Then
                                        'Insert Data ลง LotEva
                                        strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILotEva] (No)  VALUES ('" & Session("InsertCaseNo") & "')"
                                        objCmd = New SqlCommand(strSQLInIC, objConn)
                                        objCmd.ExecuteNonQuery()

                                        Response.Write("<script>window.close();</script>")
                                    End If
                                End If
                            End If
                        Else
                            'Insert Data ลง QYICase
                            strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
                            VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "','" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                            objCmd = New SqlCommand(strSQLInsert, objConn)
                            objCmd.ExecuteNonQuery()

                            If Mode.Text = "Lot Eva Test Equipment" Or Mode.Text = "Lot Eva New Device" Then
                                'Insert Data ลง LotEva
                                strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILotEva] (No)  VALUES ('" & Session("InsertCaseNo") & "')"
                                objCmd = New SqlCommand(strSQLInIC, objConn)
                                objCmd.ExecuteNonQuery()

                                Response.Write("<script>window.close();</script>")
                            End If

                        End If
                    End If
                Catch ex As Exception
                    ret = ex.Message
                End Try
            ElseIf (Session("Process") = "MAP" Or Session("Process") = "FL") And (Session("Mode") = "Lot Eva Test Equipment" Or Session("Mode") = "Lot Eva New Device") Then
                'ADD 2020-12-10 
                Try
                    Dim Cinfo As CarrierInfo = C_iLibgrarySevice.GetCarrierInfo("TE-QYI-01", lot, Op_No)
                    Dim result = C_iLibgrarySevice.SetupLotPhase2(lot, "TE-QYI-01", Op_No, "QYI", Licenser.NoCheck, Cinfo, New SetupLotSpecialParametersEventArgs())
                    If result.IsPass = SetupLotResult.Status.NotPass Then
                        ret = result.Type.ToString + "" + result.Cause
                        lblerror.Text = ret
                    ElseIf result.IsPass = SetupLotResult.Status.Pass Or result.IsPass = SetupLotResult.Status.Warning Then
                        C_iLibgrarySevice.StartLotPhase2(lot, "TE-QYI-01", Op_No, result.Recipe, Cinfo, New StartLotSpecialParametersEventArgs())
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
                            If dtLot.Rows.Count > 0 Then
                                If dtLot.Rows(0)("Out1") = "" Or dtLot.Rows(0)("Out2") = "" Then
                                    If dtLot.Rows(0)("GotoProcess") = "Retest FT Auto1" Then
                                        strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                        objCmd = New SqlCommand(strSQLInsert, objConn)
                                        objCmd.ExecuteNonQuery()
                                    ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto2" Then
                                        strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                        objCmd = New SqlCommand(strSQLInsert, objConn)
                                        objCmd.ExecuteNonQuery()
                                    ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto3" Then
                                        strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                        objCmd = New SqlCommand(strSQLInsert, objConn)
                                        objCmd.ExecuteNonQuery()
                                    ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto4" Then
                                        strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                                        objCmd = New SqlCommand(strSQLInsert, objConn)
                                        objCmd.ExecuteNonQuery()
                                    Else
                                        'Insert Data ลง QYICase
                                        If Session("Process") = "MAP" Then
                                            strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,MAPMCNo,MAPLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "'
,'" & Session("InsertMCNoMAP") & "','" & Session("InsertLotStartTimeMAP") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                            objCmd = New SqlCommand(strSQLInsert, objConn)
                                            objCmd.ExecuteNonQuery()
                                        End If
                                    End If
                                End If
                            Else
                                'Insert Data ลง QYICase
                                If Session("Process") = "MAP" Then
                                    strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,MAPMCNo,MAPLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "'
,'" & Session("InsertMCNoMAP") & "','" & Session("InsertLotStartTimeMAP") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                    objCmd = New SqlCommand(strSQLInsert, objConn)
                                    objCmd.ExecuteNonQuery()
                                End If
                            End If

                            If Mode.Text = "LCL" Or Mode.Text = "Yield < 80 %" Or Mode.Text = "ASI 100% Lot" Then
                                'Insert Data ลง QYIICBurn
                                strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                                objCmd = New SqlCommand(strSQLInIC, objConn)
                                objCmd.ExecuteNonQuery()

                                Response.Write("<script>window.close();</script>")

                            ElseIf Mode.Text = "BIN28" Or Mode.Text = "BIN29,BIN30,BIN31" Then
                                'Insert Data ลง QYIICBurn
                                strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                                objCmd = New SqlCommand(strSQLInIC, objConn)
                                objCmd.ExecuteNonQuery()

                                Response.Write("<script>window.close();</script>")
                            ElseIf Mode.Text = "BIN13,BIN14" Then
                                'Insert Data ลง QYIICBurn
                                strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                                objCmd = New SqlCommand(strSQLInIC, objConn)
                                objCmd.ExecuteNonQuery()

                                Response.Write("<script>window.close();</script>")
                            ElseIf Mode.Text = "Lot Eva Test Equipment" Or Mode.Text = "Lot Eva New Device" Then
                                'Insert Data ลง LotEva
                                strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILotEva] (No)  VALUES ('" & Session("InsertCaseNo") & "')"
                                objCmd = New SqlCommand(strSQLInIC, objConn)
                                objCmd.ExecuteNonQuery()

                                Response.Write("<script>window.close();</script>")
                            End If
                        End If
                    End If
                Catch ex As Exception
                    ret = ex.Message
                End Try
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


                If dtLot.Rows.Count > 0 Then
                    If dtLot.Rows(0)("Out1") = "" Or dtLot.Rows(0)("Out2") = "" Then
                        If dtLot.Rows(0)("GotoProcess") = "Retest FT Auto1" Then
                            strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                            objCmd = New SqlCommand(strSQLInsert, objConn)
                            objCmd.ExecuteNonQuery()
                        ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto2" Then
                            strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                            objCmd = New SqlCommand(strSQLInsert, objConn)
                            objCmd.ExecuteNonQuery()
                        ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto3" Then
                            strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                            objCmd = New SqlCommand(strSQLInsert, objConn)
                            objCmd.ExecuteNonQuery()
                        ElseIf dtLot.Rows(0)("GotoProcess") = "Retest FT Auto4" Then
                            strSQLInsert = "Update [DBx].[QYI].[QYICase] Set UserIDIn2 = '" & Session("Input") & "',TimeIn2 ='" & Now() & "',Mode2='" & Session("Mode") & "' Where No='" & dtLot.Rows(0)("No") & "'"
                            objCmd = New SqlCommand(strSQLInsert, objConn)
                            objCmd.ExecuteNonQuery()
                        Else

                            'Insert Data ลง QYICase
                            If Session("Process") = "FT" Then
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "'
,'" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()
                            ElseIf Session("Process") = "FL" Then
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FLMCNo,FLLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFL") & "','" & Session("InsertLotStartTimeFL") & "'
,'" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()
                            ElseIf Session("Process") = "MAP" Then
                                strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,MAPMCNo,MAPLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "'
,'" & Session("InsertMCNoMAP") & "','" & Session("InsertLotStartTimeMAP") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                                objCmd = New SqlCommand(strSQLInsert, objConn)
                                objCmd.ExecuteNonQuery()
                            End If
                        End If
                    End If
                Else
                    'Insert Data ลง QYICase
                    If Session("Process") = "FT" Then
                        strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FTMCNo,FTLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFT") & "','" & Session("InsertLotStartTimeFT") & "'
,'" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                        objCmd = New SqlCommand(strSQLInsert, objConn)
                        objCmd.ExecuteNonQuery()
                    ElseIf Session("Process") = "FL" Then
                        strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,FLMCNo,FLLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "','" & Session("InsertMCNoFL") & "','" & Session("InsertLotStartTimeFL") & "'
,'" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                        objCmd = New SqlCommand(strSQLInsert, objConn)
                        objCmd.ExecuteNonQuery()
                    ElseIf Session("Process") = "MAP" Then
                        strSQLInsert = "INSERT INTO [DBx].[QYI].[QYICase] (No,Process,LotNo,MAPMCNo,MAPLotStartTime,Program,TestNo,BoxNo,FTYield,TestFlow,OldDeviceName,OldPackage,Mode,TimeIn,UserIDIn,StatusFlowFYI)  
VALUES ('" & Session("InsertCaseNo") & "','" & Session("Process") & "','" & Session("CheckLotNo") & "'
,'" & Session("InsertMCNoMAP") & "','" & Session("InsertLotStartTimeMAP") & "','" & Program.Text & "','" & TesterName.Text & "','" & TestBoxName.Text & "','" & FinalYield.Text & "'
,'" & TestFlow.Text & "','" & txtDevice.Text & "','" & Session("PackagePro") & "','" & Session("Mode") & "','" & Now() & "','" & Session("Input") & "','" & Session("StatusFlowFYI") & "')"
                        objCmd = New SqlCommand(strSQLInsert, objConn)
                        objCmd.ExecuteNonQuery()
                    End If
                End If

                If Mode.Text = "LCL" Or Mode.Text = "Yield < 80 %" Or Mode.Text = "ASI 100% Lot" Then
                    'Insert Data ลง QYIICBurn
                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILowYield] (No,WaferLotNo,WaferNo,LotNo1,Rank,Kanbandate)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("ScanInput1") & "','" & Session("Rank") & "','" & Session("InsertKanban") & "')"
                    objCmd = New SqlCommand(strSQLInIC, objConn)
                    objCmd.ExecuteNonQuery()

                    Response.Write("<script>window.close();</script>")

                ElseIf Mode.Text = "BIN28" Or Mode.Text = "BIN29,BIN30,BIN31" Then
                    'Insert Data ลง QYIICBurn
                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                    objCmd = New SqlCommand(strSQLInIC, objConn)
                    objCmd.ExecuteNonQuery()

                    Response.Write("<script>window.close();</script>")
                ElseIf Mode.Text = "BIN13,BIN14" Then
                    'Insert Data ลง QYIICBurn
                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYIICBurn] (No,WaferLotNo,WaferNo,Rank)  VALUES ('" & Session("InsertCaseNo") & "','" & Session("InsertWaferLotNo") & "','" & Session("WaferNo") & "','" & Session("Rank") & "')"
                    objCmd = New SqlCommand(strSQLInIC, objConn)
                    objCmd.ExecuteNonQuery()

                    Response.Write("<script>window.close();</script>")
                ElseIf Mode.Text = "Lot Eva Test Equipment" Or Mode.Text = "Lot Eva New Device" Then
                    'Insert Data ลง LotEva
                    strSQLInIC = "INSERT INTO [DBx].[QYI].[QYILotEva] (No)  VALUES ('" & Session("InsertCaseNo") & "')"
                    objCmd = New SqlCommand(strSQLInIC, objConn)
                    objCmd.ExecuteNonQuery()

                    Response.Write("<script>window.close();</script>")
                End If
            End If
        End If

    End Sub
End Class