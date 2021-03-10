Imports System.Data.SqlClient
Imports OJT_InOut_System.ServiceLibrary

Public Class OutputFQI
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
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim lot, Op_No, strSQLEmp, strSQLLot, strSQLIssue As String
        Dim dtAdapterEmp, dtAdapterLot, dtAdapterIssue As SqlDataAdapter
        Dim dtQYI, dtLY, dtIC, dtNo, dtEmp, dtLotID, dtLot, dtIssue As New DataTable

        lot = txtLotno.Text
        Op_No = txtEmpNo.Text
        Session("Menu") = "FQI"
        Session("Emp") = txtEmpNo.Text

        'Check Lot No ใน QYI
        strSQLLot = "Select Top(1) No,LotNo,Process,OSNG1,OSNG2,OSNG3,GotoProcess,Mode,UserIDIn,UserIDIn2,UserIDIn3,UserIDOut,UserIDOut2,UserIDOut3,Remark1,OldDeviceName,OldPackage,TimeOut,TestFlow From [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "' and Mode IS Not NULL order By TimeIn DESC"
        dtAdapterLot = New SqlDataAdapter(strSQLLot, objConn)
        dtAdapterLot.Fill(dtLot)

        'Check Emp No ใน Database ของ APCSPro
        strSQLEmp = "Select role_id From [APCSProDB].[man].[users],[APCSProDB].[man].[user_roles] Where users.id=user_roles.user_id and  emp_num='" & txtEmpNo.Text & "' and role_id='2' "
        dtAdapterEmp = New SqlDataAdapter(strSQLEmp, objConnPro)
        dtAdapterEmp.Fill(dtEmp)


        If dtEmp.Rows.Count > 0 Then
            If dtLot.Rows.Count > 0 Then
                If dtLot.Rows(0)("Mode") = "BIN19" Then
                    If dtLot.Rows(0)("UserIDIn").ToString.Trim() <> "" And dtLot.Rows(0)("UserIDOut").ToString.Trim() = "" Then
                        If IsDBNull(dtLot.Rows(0)("OSNG1")) Then
                            Session("Lot") = txtLotno.Text
                            Session("Emp") = txtEmpNo.Text
                            Response.Redirect("DetailOut.aspx")
                        Else
                            If dtLot.Rows(0)("GotoProcess") = "QC" Then
                                Session("Lot") = txtLotno.Text
                                Session("Emp") = txtEmpNo.Text
                                Session("NG1") = dtLot.Rows(0)("OSNG1")
                                Response.Redirect("DetailOut2.aspx")
                            Else
                                Session("Lot") = txtLotno.Text
                                Session("Emp") = txtEmpNo.Text
                                Session("NG1") = dtLot.Rows(0)("OSNG1")
                                Response.Redirect("DetailOut2.aspx")
                            End If
                        End If
                    ElseIf dtLot.Rows(0)("UserIDIn2").ToString.Trim() <> "" And dtLot.Rows(0)("UserIDOut2").ToString.Trim() = "" Then
                        If IsDBNull(dtLot.Rows(0)("OSNG1")) Then
                            Session("Lot") = txtLotno.Text
                            Session("Emp") = txtEmpNo.Text
                            Response.Redirect("DetailOut.aspx")
                        Else
                            If dtLot.Rows(0)("GotoProcess") = "QC" Then
                                Session("Lot") = txtLotno.Text
                                Session("Emp") = txtEmpNo.Text
                                Session("NG1") = dtLot.Rows(0)("OSNG1")
                                Response.Redirect("DetailOut2.aspx")
                            Else
                                Session("Lot") = txtLotno.Text
                                Session("Emp") = txtEmpNo.Text
                                Session("NG1") = dtLot.Rows(0)("OSNG1")
                                Response.Redirect("DetailOut2.aspx")
                            End If
                        End If
                    ElseIf dtLot.Rows(0)("UserIDIn3").ToString.Trim() <> "" And dtLot.Rows(0)("UserIDOut3").ToString.Trim() = "" Then
                        If IsDBNull(dtLot.Rows(0)("OSNG2")) Then
                            Session("Lot") = txtLotno.Text
                            Session("Emp") = txtEmpNo.Text
                            Response.Redirect("DetailOut.aspx")
                        Else
                            If dtLot.Rows(0)("GotoProcess") = "QC" Then
                                Session("Lot") = txtLotno.Text
                                Session("Emp") = txtEmpNo.Text
                                Session("NG1") = dtLot.Rows(0)("OSNG2")
                                Response.Redirect("DetailOut2.aspx")
                            Else
                                Session("Lot") = txtLotno.Text
                                Session("Emp") = txtEmpNo.Text
                                Session("NG1") = dtLot.Rows(0)("OSNG2")
                                Response.Redirect("DetailOut2.aspx")
                            End If
                        End If
                    Else
                        Page.RegisterClientScriptBlock("OnLoad", "<script>alert('กรุณา Input LotNo ก่อน ')</script>")
                    End If
                ElseIf dtLot.Rows(0)("Mode") = "LCL" Or dtLot.Rows(0)("Mode") = "Yield < 80 %" Or dtLot.Rows(0)("Mode") = "ASI 100% Lot" Then
                    'Check Issue No ใน LowYield
                    strSQLIssue = "Select IssueNo,SUBSTRING(IssueNo,0,10) As No From [DBx].[QYI].[QYILowYield] Where No ='" & dtLot.Rows(0)("No") & "'"
                    dtAdapterIssue = New SqlDataAdapter(strSQLIssue, objConn)
                    dtAdapterIssue.Fill(dtIssue)
                    If dtIssue.Rows.Count > 0 Then
                        If IsDBNull(dtIssue.Rows(0)("IssueNo")) Then
                            Session("Lot") = txtLotno.Text
                            Session("Emp") = txtEmpNo.Text
                            Session("No") = dtLot.Rows(0)("No")
                            Session("Process") = dtLot.Rows(0)("Process")
                            Session("Flow") = dtLot.Rows(0)("TestFlow")
                            Session("Remark") = dtLot.Rows(0)("Remark1")
                            Session("Device") = dtLot.Rows(0)("OldDeviceName").ToString.Trim()
                            Session("Package") = dtLot.Rows(0)("OldPackage")
                            Session("TimeKeyOut") = dtLot.Rows(0)("TimeOut")
                            Session("InsertYear") = dtIssue.Rows(0)("No")
                            Session("Menu") = "FQI"
                            Response.Redirect("DetailNextFlow.aspx")
                        Else
                            Session("IssueNo") = dtIssue.Rows(0)("IssueNo")
                            Session("InsertYear") = dtIssue.Rows(0)("No")
                            Session("No") = dtLot.Rows(0)("No")
                            Session("Process") = dtLot.Rows(0)("Process")
                            Session("Flow") = dtLot.Rows(0)("TestFlow")
                            Session("Remark") = dtLot.Rows(0)("Remark1")
                            Session("Device") = dtLot.Rows(0)("OldDeviceName").ToString.Trim()
                            Session("Package") = dtLot.Rows(0)("OldPackage")
                            Session("TimeKeyOut") = dtLot.Rows(0)("TimeOut")
                            Session("Lot") = txtLotno.Text
                            Session("Emp") = txtEmpNo.Text
                            Session("Menu") = "FQI"
                            Response.Redirect("DetailOutLowYield.aspx")
                        End If
                    Else
                        Page.RegisterClientScriptBlock("OnLoad", "<script>alert('Lot. No Permission')</script>")
                    End If
                ElseIf dtLot.Rows(0)("Mode") = "BIN28" Or dtLot.Rows(0)("Mode") = "BIN29,BIN30,BIN31" Then
                    'Check AbNo ใน ICBurn
                    strSQLIssue = "Select AbNo , SUBSTRING(AbNo,0,10) As No From [DBx].[QYI].[QYIICBurn] Where No ='" & dtLot.Rows(0)("No") & "'"
                    dtAdapterIssue = New SqlDataAdapter(strSQLIssue, objConn)
                    dtAdapterIssue.Fill(dtIssue)
                    If dtIssue.Rows.Count > 0 Then
                        If IsDBNull(dtIssue.Rows(0)("AbNo")) Then
                            Session("No") = dtLot.Rows(0)("No")
                            Session("Lot") = txtLotno.Text
                            Session("Emp") = txtEmpNo.Text
                            Session("Process") = dtLot.Rows(0)("Process")
                            Session("Remark") = dtLot.Rows(0)("Remark1")
                            Session("Flow") = dtLot.Rows(0)("TestFlow")
                            Session("Device") = dtLot.Rows(0)("OldDeviceName").ToString.Trim()
                            Session("Package") = dtLot.Rows(0)("OldPackage")
                            Session("TimeKeyOut") = dtLot.Rows(0)("TimeOut")
                            Session("InsertYear") = dtIssue.Rows(0)("No")
                            Session("Menu") = "FQI"
                            Response.Redirect("DetailNextFlow.aspx")
                        Else
                            Session("IssueNo") = dtIssue.Rows(0)("AbNo")
                            Session("InsertYear") = dtIssue.Rows(0)("No")
                            Session("No") = dtLot.Rows(0)("No")
                            Session("Process") = dtLot.Rows(0)("Process")
                            Session("Lot") = txtLotno.Text
                            Session("Emp") = txtEmpNo.Text
                            Session("Remark") = dtLot.Rows(0)("Remark1")
                            Session("Flow") = dtLot.Rows(0)("TestFlow")
                            Session("Device") = dtLot.Rows(0)("OldDeviceName").ToString.Trim()
                            Session("Package") = dtLot.Rows(0)("OldPackage")
                            Session("TimeKeyOut") = dtLot.Rows(0)("TimeOut")
                            Session("Menu") = "FQI"
                            Response.Redirect("DetailOutICBurn.aspx")
                        End If
                    Else
                        Page.RegisterClientScriptBlock("OnLoad", "<script>alert('Lot. No Permission')</script>")
                    End If
                ElseIf dtLot.Rows(0)("Mode") = "Lot Eva Test Equipment" Or dtLot.Rows(0)("Mode") = "Lot Eva New Device" Then
                    'Session("IssueNo") = dtLot.Rows(0)("IssueNo")
                    Session("No") = dtLot.Rows(0)("No")
                    Session("Process") = dtLot.Rows(0)("Process")
                    Session("Remark") = dtLot.Rows(0)("Remark1")
                    Session("Flow") = dtLot.Rows(0)("TestFlow")
                    Session("Device") = dtLot.Rows(0)("OldDeviceName").ToString.Trim()
                    Session("Package") = dtLot.Rows(0)("OldPackage")
                    Session("TimeKeyOut") = dtLot.Rows(0)("TimeOut")
                    Session("Lot") = txtLotno.Text
                    Session("Emp") = txtEmpNo.Text
                    Session("Menu") = "FQI"
                    Response.Redirect("DetailNextFlow.aspx")
                End If
            Else
                'MsgBox("EmpNo. No Permission")
                Page.RegisterClientScriptBlock("OnLoad", "<script>alert('Lot. No Permission')</script>")
            End If
        Else
            'MsgBox("EmpNo. No Permission")
            Page.RegisterClientScriptBlock("OnLoad", "<script>alert('EmpNo. No Permission')</script>")
        End If
    End Sub
End Class