Imports System.Data.SqlClient
Public Class IssueNo
    Inherits System.Web.UI.Page
    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strConnString As String
        strConnString = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=DBx;Max Pool Size=400;Connect Timeout=600;"
        objConn = New SqlConnection(strConnString)
        objConn.Open()
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim strSQLLot, strSQLLot1 As String
        Dim dtAdapterLot, dtAdapterLot1 As SqlDataAdapter
        Dim dt, dtpro, dtNo, dtEmp, dtLot, dtLot1, dtFT, dtFL, dtMAP As New DataTable

        Session("LotNo1") = txtLotno1.Text
        Session("Process") = DropDownList1.SelectedValue

        'เช็ค Textbox ถ้าไม่มีข้อมูลจะกลับมาหน้าเดิม
        If txtLotno1.Text = "" Or DropDownList1.SelectedValue = "Select Process" Then
            Page.RegisterClientScriptBlock("OnLoad", "<script>alert('Please Input LotNo Or Select Process')</script>")
        Else
            'Check Lot No ใน QYI QYILowYield
            strSQLLot = "Select Top(1) QYICase.No,OldDeviceName,QYICase.Mode,LotNo,QYILowYield.LotNo1,GotoProcess From [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield] Where QYICase.No=QYILowYield.No and LotNo ='" & Session("LotNo1") & "'  and QYICase.Mode IS Not NULL order By TimeIn DESC"
            dtAdapterLot = New SqlDataAdapter(strSQLLot, objConn)
            dtAdapterLot.Fill(dtLot)

            strSQLLot1 = "Select Top(1) QYICase.No,OldDeviceName,QYICase.Mode,LotNo From [DBx].[QYI].[QYICase],[DBx].[QYI].[QYIICBurn] Where QYICase.No=QYIICBurn.No and LotNo ='" & Session("LotNo1") & "'  and QYICase.Mode IS Not NULL order By TimeIn DESC"
            dtAdapterLot1 = New SqlDataAdapter(strSQLLot1, objConn)
            dtAdapterLot1.Fill(dtLot1)

            If dtLot.Rows.Count > 0 Then
                If dtLot.Rows(0)("Mode") = "LCL" Or dtLot.Rows(0)("Mode") = "Yield < 80 %" Then
                    Session("Device") = dtLot.Rows(0)("OldDeviceName")
                    Session("No") = dtLot.Rows(0)("No")
                    'Session("LotAll") = dtLot.Rows(0)("LotNo")
                    Session("LotAll") = dtLot.Rows(0)("LotNo1")

                    If IsDBNull(dtLot.Rows(0)("GotoProcess")) Then
                        Response.Redirect("DetailIssueNo.aspx")
                    Else
                        If dtLot.Rows(0)("GotoProcess") = "IC Burn" Then
                            Session("Device") = dtLot.Rows(0)("OldDeviceName")
                            Session("No") = dtLot.Rows(0)("No")
                            Response.Redirect("DetailIssueNoICBrun.aspx")
                        Else
                            Response.Redirect("DetailIssueNo.aspx")
                        End If
                    End If

                        If dtLot.Rows(0)("Mode") = "BIN13,BIN14" Or dtLot.Rows(0)("Mode") = "BIN28" Or dtLot.Rows(0)("Mode") = "BIN29,BIN30,BIN31" Then
                            Session("Device") = dtLot.Rows(0)("OldDeviceName")
                            Session("No") = dtLot.Rows(0)("No")
                            Response.Redirect("DetailIssueNoICBrun.aspx")
                        End If
                    End If
                ElseIf dtLot1.Rows.Count > 0 Then
                If dtLot1.Rows(0)("Mode") = "BIN13,BIN14" Or dtLot1.Rows(0)("Mode") = "BIN28" Or dtLot1.Rows(0)("Mode") = "BIN29,BIN30,BIN31" Then
                    Session("Device") = dtLot1.Rows(0)("OldDeviceName")
                    Session("No") = dtLot1.Rows(0)("No")
                    Response.Redirect("DetailIssueNoICBrun.aspx")
                End If
            End If
        End If
    End Sub


End Class