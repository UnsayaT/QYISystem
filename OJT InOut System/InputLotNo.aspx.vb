Imports System.Data.SqlClient
Imports OJT_InOut_System.ServiceLibrary

Public Class InputLotNo
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

        lblerror.Text = ""
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim strSQLEmp, strSQLLot, strSQLTran, strSQLFT, strSQLFL, strSQLMAP, lot, Op_No, TimeOut, strSQLTranlots, strSQLWork As String
        Dim dtAdapterEmp, dtAdapterLot, dtAdapterTran, dtAdapterFT, dtAdapterFL, dtAdapterMAP, dtAdapterTranlots, dtAdapterWork As SqlDataAdapter
        Dim dt, dtpro, dtNo, dtEmp, dtLot, dtTran, dtFT, dtFL, dtMAP, dtlots, dtWork As New DataTable

        lot = txtLotno.Text
        Op_No = txtEmpNo.Text
        Session("LotNo") = txtLotno.Text
        Session("Op_No") = txtEmpNo.Text
        'If DropDownList1.Text = "FT" Then
        '    Session("Process") = "FT"
        'ElseIf DropDownList1.Text = "FL" Then
        '    Session("Process") = "FL"
        'ElseIf DropDownList1.Text = "MAP" Then
        '    Session("Process") = "MAP"
        'End If

        If RadioButton2.Checked = True Then
            Session("Mode") = "BIN19"
        ElseIf RadioButton3.Checked = True Then
            Session("Mode") = "BIN28"
        ElseIf RadioButton4.Checked = True Then
            Session("Mode") = "BIN29,BIN30,BIN31"
        ElseIf RadioButton5.Checked = True Then
            Session("Mode") = "LCL"
        ElseIf RadioButton6.Checked = True Then
            Session("Mode") = "Yield < 80 %"
        ElseIf RadioButton7.Checked = True Then
            Session("Mode") = "Lot Eva Test Equipment"
        ElseIf RadioButton8.Checked = True Then
            Session("Mode") = "Lot Eva New Device"
        ElseIf RadioButton9.Checked = True Then
            Session("Mode") = "ASI 100% Lot"
        End If

        'Check Lot No ใน QYI
        strSQLLot = "Select No,LotNo,Bin19_1,Bin19_2,Bin19_3,Tester1,Tester2,Tester3,UserIDIn,UserIDIn2,UserIDIn3,GotoProcess,CASE WHEN TimeOut   IS NULL THEN '-' ELSE CONVERT(varchar, TimeOut, 101) END As DataOut From [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "' order by TimeIn DESC"
        dtAdapterLot = New SqlDataAdapter(strSQLLot, objConn)
        dtAdapterLot.Fill(dtLot)
        If dtLot.Rows.Count > 0 Then

            If dtLot.Rows(0)("Bin19_1").ToString.Trim() <> "" Then
                Session("Bin19_1") = dtLot.Rows(0)("Bin19_1")
            Else
                Session("Bin19_1") = ""
            End If
            If dtLot.Rows(0)("Bin19_2").ToString.Trim() <> "" Then
                Session("Bin19_2") = dtLot.Rows(0)("Bin19_2")
            Else
                Session("Bin19_2") = ""
            End If
            If dtLot.Rows(0)("Bin19_3").ToString.Trim() <> "" Then
                Session("Bin19_3") = dtLot.Rows(0)("Bin19_3")
            Else
                Session("Bin19_3") = ""
            End If
            If dtLot.Rows(0)("Tester1").ToString.Trim() <> "" Then
                Session("Tester1") = dtLot.Rows(0)("Tester1")
            Else
                Session("Tester1") = ""
            End If
            If dtLot.Rows(0)("Tester2").ToString.Trim() <> "" Then
                Session("Tester2") = dtLot.Rows(0)("Tester2")
            Else
                Session("Tester2") = ""
            End If
            If dtLot.Rows(0)("Tester3").ToString.Trim() <> "" Then
                Session("Tester3") = dtLot.Rows(0)("Tester3")
            Else
                Session("Tester3") = ""
            End If
            If dtLot.Rows(0)("UserIDIn").ToString.Trim() <> "" Then
                Session("UserIDIn") = dtLot.Rows(0)("UserIDIn")
            Else
                Session("UserIDIn") = txtEmpNo.Text
            End If
            If dtLot.Rows(0)("UserIDIn2").ToString.Trim() <> "" Then
                Session("UserIDIn2") = dtLot.Rows(0)("UserIDIn2")
            Else
                Session("UserIDIn2") = txtEmpNo.Text
            End If
            If dtLot.Rows(0)("UserIDIn3").ToString.Trim() <> "" Then
                Session("UserIDIn3") = dtLot.Rows(0)("UserIDIn3")
            Else
                Session("UserIDIn3") = txtEmpNo.Text
            End If
            Session("GotoProcess1") = dtLot.Rows(0)("GotoProcess")
        Else
            Session("UserIDIn") = txtEmpNo.Text
            Session("Bin19_1") = ""
            Session("Bin19_2") = ""
            Session("Bin19_3") = ""
            Session("Tester1") = ""
            Session("Tester2") = ""
            Session("Tester3") = ""
            Session("GotoProcess1") = ""
        End If
        'Check Lot No ใน TransactionData
        strSQLTran = "Select Package,Device From [DBx].[dbo].[TransactionData] Where LotNo ='" & txtLotno.Text & "'"
        dtAdapterTran = New SqlDataAdapter(strSQLTran, objConn)
        dtAdapterTran.Fill(dtTran)
        If dtTran.Rows.Count > 0 Then
            Session("Device") = dtTran.Rows(0)("Device")
            Session("Package") = dtTran.Rows(0)("Package")
        End If

        'Check Emp No ใน Database ของ APCSPro
        strSQLEmp = "Select role_id From [APCSProDB].[man].[users],[APCSProDB].[man].[user_roles] Where users.id=user_roles.user_id and  emp_num='" & txtEmpNo.Text & "' and role_id='2' "
        dtAdapterEmp = New SqlDataAdapter(strSQLEmp, objConnPro)
        dtAdapterEmp.Fill(dtEmp)

        'Query Data จาก LCQW_UNION_WORK_DENPYO_PRINT
        strSQLWork = "Select LOT_NO_FOR_PRINT,ASSY_MODEL_NAME_1,FORM_NAME_1,THROW_RANK_5,NOKI,SUBSTRING(PERETTO_NO_1,CHARINDEX(' ',PERETTO_NO_1),LEN(PERETTO_NO_1) ) AS WaferNo FROM [APCSDB].[dbo].[LCQW_UNION_WORK_DENPYO_PRINT] WHERE LOT_NO_2='" & txtLotno.Text & "' "
        dtAdapterWork = New SqlDataAdapter(strSQLWork, objConnPro)
        dtAdapterWork.Fill(dtWork)
        If dtWork.Rows.Count > 0 Then
            Session("CheckLotNo") = txtLotno.Text
            Session("InsertPackage") = dtWork.Rows(0)("FORM_NAME_1")
            Session("InsertDevice") = dtWork.Rows(0)("ASSY_MODEL_NAME_1")
            Session("Shipment") = dtWork.Rows(0)("NOKI")
            Session("Rank") = dtWork.Rows(0)("THROW_RANK_5")
            Session("WaferNo") = dtWork.Rows(0)("WaferNo")
        End If
        'Check Flow ก่อนหน้า กับ Mode ที่เลือกจากหน้า Web
        strSQLTranlots = " select name,[APCSProDB].[trans].[lots].special_flow_id,[APCSProDB].[trans].[lots].step_no,job_id
        FROM [APCSProDB].[trans].[lots] INNER JOIN [APCSProDB].[trans].[lot_special_flows] ON [APCSProDB].[trans].[lots].special_flow_id=[APCSProDB].[trans].[lot_special_flows].special_flow_id
        INNER JOIN [APCSProDB].[method].[jobs] On [APCSProDB].[method].[jobs].id=[APCSProDB].[trans].[lot_special_flows].job_id Where lot_no ='" & txtLotno.Text & "'"
        dtAdapterTranlots = New SqlDataAdapter(strSQLTranlots, objConnPro)
        dtAdapterTranlots.Fill(dtlots)
        If dtlots.Rows.Count = 1 Then
            Session("jobNo") = dtlots.Rows(0)("job_id")
            Session("name") = dtlots.Rows(0)("name")
        ElseIf dtlots.Rows.Count = 2 Then
            Session("jobNo1") = dtlots.Rows(0)("job_id")
            Session("name1") = dtlots.Rows(0)("name")
            Session("jobNo2") = dtlots.Rows(1)("job_id")
            Session("name2") = dtlots.Rows(1)("name")
            If Session("jobNo1") = "328" And Session("jobNo2") = "327" And Session("GotoProcess1") <> "Low Yield" Then
                'แสดงว่าLotนี้ ADD Flow IC+LY มาพร้อมกัน
                Session("jobNo") = Session("jobNo1")
                Session("name") = Session("name1")
            ElseIf Session("jobNo1") = "328" And Session("jobNo2") = "327" And Session("GotoProcess1") = "Low Yield" Then
                Session("jobNo") = Session("jobNo2")
                Session("name") = Session("name2")
            Else
                Session("jobNo") = Session("jobNo2")
                Session("name") = Session("name2")
            End If
        End If


        If Session("Mode") = "BIN19" Then
            Response.Write("<script>window.open('DetailInputBin19.aspx','_self');</script>")
        Else
            If dtLot.Rows.Count > 0 Then
                Session("TimeOut") = dtLot.Rows(0)("DataOut")
                TimeOut = dtLot.Rows(0)("DataOut")
            Else
                Session("TimeOut") = ""
                TimeOut = ""
            End If

            If dtLot.Rows.Count > 0 And Session("TimeOut") = "-" Then
                Page.RegisterClientScriptBlock("OnLoad", "<script>alert('Lot No นี้ยังมีได้ทำการ Out ออกจากระบบ ไม่สามารถทำการ Input Lot เพิ่มได้')</script>")
            Else
                Session("Emp") = Trim(dtEmp.Rows(0)("role_id"))
                Session("Input") = txtEmpNo.Text

                'Process FT
                strSQLFT = "
                  Select TOP(1)FTData.MCNo, FTData.LotStartTime, TransactionData.WaferLotNo, TransactionData.MarkNo, FTData.TestFlowName, FTData.ProgramName, 
                               FTData.FinalYield
                      From TransactionData INNER Join
                        FTData On TransactionData.LotNo = FTData.LotNo
                  Where (TransactionData.LotNo Like '" & txtLotno.Text & "') and TestFlowName != 'AUTO2ASISAMPLE'
                  ORDER BY FTData.LotStartTime DESC"
                    dtAdapterFT = New SqlDataAdapter(strSQLFT, objConn)
                    dtAdapterFT.Fill(dtFT)

                'Process FL
                strSQLFL = "
                  SELECT      TOP (1)  TransactionData.WaferLotNo, TransactionData.MarkNo, FLData.MCNo, FLData.LotStartTime, FLData.TestFlow, FLData.FTProgram, 
                              FLData.TempFTYield
                  FROM        TransactionData INNER JOIN
                              FLData ON TransactionData.LotNo = FLData.LotNo
                  WHERE       (TransactionData.LotNo LIKE '" & txtLotno.Text & "') 
                  ORDER       BY FLData.LotStartTime DESC"
                    dtAdapterFL = New SqlDataAdapter(strSQLFL, objConn)
                    dtAdapterFL.Fill(dtFL)

                'Process MAP
                strSQLMAP = "
                  SELECT      TOP (1) TransactionData.WaferLotNo, TransactionData.MarkNo, MAPOSFTData.MCNo, MAPOSFTData.LotStartTime, MAPOSFTData.Process, 
                              MAPOSFTData.ProgramName, MAPOSFTData.BoxNo, MAPOSFTData.FTYield, MAPOSFTData.TesterName
                  FROM        TransactionData INNER JOIN
                              MAPOSFTData ON TransactionData.LotNo = MAPOSFTData.LotNo
                  WHERE       (MAPOSFTData.Process = 'FT' OR  MAPOSFTData.Process = 'OSFT' OR  MAPOSFTData.Process = 'OS' OR MAPOSFTData.Process = 'AUTO1')  AND (TransactionData.LotNo LIKE '" & txtLotno.Text & "')
                  ORDER BY    MAPOSFTData.LotStartTime DESC"
                    dtAdapterMAP = New SqlDataAdapter(strSQLMAP, objConn)
                    dtAdapterMAP.Fill(dtMAP)


                If dtFT.Rows.Count > 0 Then
                    Session("Process") = "FT"
                    Session("InsertMCNoFT") = dtFT.Rows(0)("MCNo")
                    Session("InsertLotStartTimeFT") = dtFT.Rows(0)("LotStartTime")
                    Session("InsertMCNoFL") = ""
                    Session("InsertLotStartTimeFL") = ""
                    Session("InsertMCNoMAP") = ""
                    Session("InsertLotStartTimeMAP") = ""

                    Session("InsertWaferLotNo") = dtFT.Rows(0)("WaferLotNo")

                    If dtFT.Rows(0)("MarkNo").ToString.Trim() <> "" Then
                        Session("InsertMarkNo") = dtFT.Rows(0)("MarkNo")
                    Else
                        Session("InsertMarkNo") = "-"
                    End If


                    If dtFT.Rows(0)("TestFlowName").ToString.Trim() <> "" Then
                        Session("InsertTestFlowName") = dtFT.Rows(0)("TestFlowName")
                    Else
                        Session("InsertTestFlowName") = "-"
                    End If

                    Session("InsertProgramName") = dtFT.Rows(0)("ProgramName")
                    Session("InsertTestFinalYield") = dtFT.Rows(0)("FinalYield")
                    Session("InsertTesterName") = "-"
                    Session("InsertProcess") = "FT"
                    Session("InsertBoxName") = "-"

                    'Add 2020-02-20 เช็คว่า Packages ของ Lot นี้เป็นAPCSProไหม ถ้าเป็นให้เช็ค JobNo ว่าตรงกับMode ที่เลทอกไหม
                    Dim strSQLPackages As String
                    Dim dtAdapterPackages As SqlDataAdapter
                    Dim dtPackages As New DataTable

                    'Check Packages ใน Database ของ APCSPro
                    strSQLPackages = "Select name From [APCSProDB].[method].[packages] Where short_name='" & Session("Package") & "'"
                    dtAdapterPackages = New SqlDataAdapter(strSQLPackages, objConnPro)
                    dtAdapterPackages.Fill(dtPackages)
                    If dtPackages.Rows.Count > 0 Then
                        Session("PackagePro") = dtPackages.Rows(0)("name")
                    End If

                    'WCF Check Packge 
                    Dim CheckPackge = C_iLibgrarySevice.CheckPackageOnlyApcsPro("TE-QYI-01", Session("PackagePro"), Op_No, lot)

                    If CheckPackge = False Then
                        Response.Write("<script>window.open('DetailInput.aspx','_self');</script>")
                    ElseIf CheckPackge = True Then
                        If (Session("jobNo") = "327" And (Session("Mode") = "LCL" Or Session("Mode") = "Yield < 80 %" Or Session("Mode") = "ASI 100% Lot")) Then
                            Response.Write("<script>window.open('DetailInput.aspx','_self');</script>")
                        ElseIf (Session("jobNo") = "328" And (Session("Mode") = "BIN29,BIN30,BIN31" Or Session("Mode") = "BIN28")) Then
                            Response.Write("<script>window.open('DetailInput.aspx','_self');</script>")
                        ElseIf ((Session("Mode") = "Lot Eva Test Equipment" Or Session("Mode") = "Lot Eva New Device")) Then
                            Response.Write("<script>window.open('DetailInput.aspx','_self');</script>")
                        ElseIf IsDBNull(Session("jobNo")) Then
                            lblerror.Text = "Lot No นี้ไม่ได้ถูก Add Flow Low Yield หรือ Flow IC Burn มาให้"
                        Else
                            Page.RegisterClientScriptBlock("OnLoad", "<script> กรุณาเลือก Mode ให้ตรงกับ Flow</script>")
                            lblerror.Text = "Mode  " & Session("name")
                        End If
                    End If

                ElseIf dtFL.Rows.Count > 0 Then

                    Session("Process") = "FL"
                    Session("InsertMCNoFT") = ""
                    Session("InsertLotStartTimeFT") = ""
                    Session("InsertMCNoFL") = dtFL.Rows(0)("MCNo")
                    Session("InsertLotStartTimeFL") = dtFL.Rows(0)("LotStartTime")
                    Session("InsertMCNoMAP") = ""
                    Session("InsertLotStartTimeMAP") = ""


                    Session("InsertWaferLotNo") = dtFL.Rows(0)("WaferLotNo")
                    Session("InsertMarkNo") = dtFL.Rows(0)("MarkNo")
                    If dtFL.Rows(0)("TestFlow").ToString.Trim() <> "" Then
                        Session("InsertTestFlowName") = dtFL.Rows(0)("TestFlow")
                    Else
                        Session("InsertTestFlowName") = "-"
                    End If

                    If dtFL.Rows(0)("FTProgram").ToString.Trim() <> "" Then
                        Session("InsertProgramName") = dtFL.Rows(0)("FTProgram")
                    Else
                        Session("InsertProgramName") = "-"
                    End If

                    Session("InsertBoxName") = "-"
                    Session("InsertTesterName") = "-"
                    If dtFL.Rows(0)("TempFTYield").ToString.Trim() <> "" Then
                        Session("InsertTestFinalYield") = dtFL.Rows(0)("TempFTYield")
                    Else
                        Session("InsertTestFinalYield") = "-"
                    End If

                    Session("InsertProcess") = "FL"
                    Response.Write("<script>window.open('DetailInput.aspx','_self');</script>")


                ElseIf dtMAP.Rows.Count > 0 Then

                    Session("Process") = "MAP"
                    Session("InsertMCNoFT") = ""
                    Session("InsertLotStartTimeFT") = ""
                    Session("InsertMCNoFL") = ""
                    Session("InsertLotStartTimeFL") = ""
                    Session("InsertMCNoMAP") = dtMAP.Rows(0)("MCNo")
                    Session("InsertLotStartTimeMAP") = dtMAP.Rows(0)("LotStartTime")

                    Session("InsertWaferLotNo") = dtMAP.Rows(0)("WaferLotNo")
                    Session("InsertMarkNo") = dtMAP.Rows(0)("MarkNo")
                    Session("InsertProgramName") = dtMAP.Rows(0)("ProgramName")

                    If dtMAP.Rows(0)("FTYield").ToString.Trim() <> "" Then
                        Session("InsertTestFinalYield") = dtMAP.Rows(0)("FTYield")
                    Else
                        Session("InsertTestFinalYield") = "-"
                    End If


                    Session("InsertBoxName") = dtMAP.Rows(0)("BoxNo")
                    Session("InsertProcess") = "MAP"
                    Session("InsertTesterName") = "-"
                    Session("InsertTestFlowName") = dtMAP.Rows(0)("Process")

                    Response.Write("<script>window.open('DetailInput.aspx','_self');</script>")
                Else
                    Page.RegisterClientScriptBlock("OnLoad", "<script>alert('ไม่พบข้อมูลใน FT/FL/MAP Data')</script>")
                End If
            End If
        End If
    End Sub

End Class