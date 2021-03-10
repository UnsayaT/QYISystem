Imports System.Data.SqlClient

Public Class DailyReport
    Inherits System.Web.UI.Page
    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strConnString As String
        strConnString = "Server=172.16.0.102;Uid=TEuser;PASSWORD=lsi;database=DBx;Max Pool Size=400;Connect Timeout=600;"
        objConn = New SqlConnection(strConnString)
        objConn.Open()

        If Not Page.IsPostBack() Then
            BindData()
        End If
    End Sub

    Sub BindData()
        Dim strSQL As String
        If Request.Form("txtStart") = "" And Request.Form("txtEnd") = "" And Request.Form("txtDaily") = "" Then
            Session("Start") = Date.Today.ToString("yyyy/MM/dd") & " 08:00"
            Session("End") = Now.AddDays(+1).ToString("yyyy/MM/dd") & " 07:59"
        ElseIf Request.Form("txtStart") <> "" And Request.Form("txtEnd") <> "" And Request.Form("txtDaily") = "" Then
            Session("Start") = Request.Form("txtStart") & " 08:00"
            Session("End") = Request.Form("txtEnd") & " 07:59"
        ElseIf Request.Form("txtStart") = "" And Request.Form("txtEnd") = "" And Request.Form("txtDaily") <> "" Then
            Session("Start") = Request.Form("txtDaily") & " 08:00"
            Session("End") = DateAdd(DateInterval.Day, 1, Session("Start")).ToString("yyyy/MM/dd") & " 07:59"
        End If
    End Sub
End Class