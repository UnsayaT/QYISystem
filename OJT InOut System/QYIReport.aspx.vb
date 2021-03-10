Imports System.Data.SqlClient
Imports System.IO

Public Class QYIReport
    Inherits System.Web.UI.Page
    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strConnString As String
        strConnString = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=DBx;Max Pool Size=400;Connect Timeout=600;"
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
        Me.lblStart.Text = Session("Start")
        Me.lblEnd.Text = Session("End")

        If RadioButton1.Checked = True Then
            strSQL = "SELECT QYICase.Mode,OldDeviceName AS Device,Process,TestFlow AS Flow,OldPackage As Package ,LotNo As Lot,TestNo,FTYield As Yield, FORMAT(TimeIn, 'dd/MM/yyyy HH:mm:ss') As DateIn,FORMAT(TimeOut, 'dd/MM/yyyy HH:mm:ss') As DateOut,IssueNo,
CASE
    WHEN GotoProcess3 IS NOT NULL THEN GotoProcess3
	WHEN GotoProcess2 IS NOT NULL THEN GotoProcess2
	ELSE GotoProcess 
	END AS GotoProcess
,Remark1,Remark2,OPNO
              FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield]
              WHERE QYICase.NO=QYILowYield.No 
              AND (QYICase.Mode='LCL' or QYICase.Mode='Yield < 80 %') and Timeout Between '" & Session("Start") & "' and '" & Session("End") & "'"
        ElseIf RadioButton2.Checked = True Then
            strSQL = "SELECT QYICase.Mode,OldDeviceName AS Device,Process,TestFlow AS Flow,OldPackage As Package,LotNo As Lot,TestNo,FTYield As Yield, FORMAT(TimeIn, 'dd/MM/yyyy HH:mm:ss') As DateIn,FORMAT(TimeOut, 'dd/MM/yyyy HH:mm:ss') As DateOut,AbNo,
CASE
    WHEN GotoProcess3 IS NOT NULL THEN GotoProcess3
	WHEN GotoProcess2 IS NOT NULL THEN GotoProcess2
	ELSE GotoProcess 
	END AS GotoProcess
,Remark1,Remark2,OPNO
              FROM [DBx].[QYI].[QYICase], [DBx].[QYI].[QYIICBurn]
              WHERE QYICase.NO=QYIICBurn.No 
              AND (QYICase.Mode='BIN29,BIN30,BIN31' or QYICase.Mode='BIN13,BIN14' or QYICase.Mode='BIN28')  and TimeOut Between '" & Session("Start") & "' and '" & Session("End") & "'"
        ElseIf RadioButton3.Checked = True Then
            strSQL = "SELECT QYICase.Mode,OldDeviceName AS Device,Process,TestFlow AS Flow,OldPackage As Package,LotNo As Lot,TestNo,FTYield As Yield, FORMAT(TimeIn, 'dd/MM/yyyy HH:mm:ss') As DateIn,FORMAT(TimeOut, 'dd/MM/yyyy HH:mm:ss') As DateOut,AbNo,
CASE
    WHEN GotoProcess3 IS NOT NULL THEN GotoProcess3
	WHEN GotoProcess2 IS NOT NULL THEN GotoProcess2
	ELSE GotoProcess 
	END AS GotoProcess
,Remark1,Remark2,OPNO
              FROM [DBx].[QYI].[QYICase], [DBx].[QYI].[QYIICBurn]
              WHERE QYICase.NO=QYIICBurn.No 
              AND (QYICase.Mode='BIN19')  and Timeout Between '" & Session("Start") & "' and '" & Session("End") & "'"
        ElseIf RadioButton4.Checked = True And Request.Form("txtLotNo") = "" Then
            strSQL = "SELECT Mode,OldDeviceName AS Device,Process,TestFlow AS Flow,OldPackage As Package,LotNo As Lot,TestNo,FTYield As Yield, FORMAT(TimeIn, 'dd/MM/yyyy HH:mm:ss') As DateIn,FORMAT(TimeOut, 'dd/MM/yyyy HH:mm:ss') As DateOut,
CASE
    WHEN GotoProcess3 IS NOT NULL THEN GotoProcess3
	WHEN GotoProcess2 IS NOT NULL THEN GotoProcess2
	ELSE GotoProcess 
	END AS GotoProcess
,Remark1,Remark2,OPNO
                FROM [DBx].[QYI].[QYICase] WHERE Timeout Between '" & Session("Start") & "' and '" & Session("End") & "'"
        ElseIf RadioButton4.Checked = True And Request.Form("txtLotNo") <> "" Then
            strSQL = "SELECT Mode,OldDeviceName AS Device,Process,TestFlow AS Flow,OldPackage As Package,LotNo As Lot,TestNo,FTYield As Yield, FORMAT(TimeIn, 'dd/MM/yyyy HH:mm:ss') As DateIn,FORMAT(TimeOut, 'dd/MM/yyyy HH:mm:ss') As DateOut,
CASE
    WHEN GotoProcess3 IS NOT NULL THEN GotoProcess3
	WHEN GotoProcess2 IS NOT NULL THEN GotoProcess2
	ELSE GotoProcess 
	END AS GotoProcess
,Remark1,Remark2,OPNO
                FROM [DBx].[QYI].[QYICase] WHERE LotNo like'%" & Request.Form("txtLotNo") & "%'"
        End If


        Dim dtReader As SqlDataReader
        objCmd = New SqlCommand(strSQL, objConn)
        dtReader = objCmd.ExecuteReader()

        '*** BindData to Repeater ***'
        MyGridViewLCL.DataSource = dtReader
        MyGridViewLCL.DataBind()

        dtReader.Close()
        dtReader = Nothing
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindData()
    End Sub

    Protected Sub ExportToExcel(sender As Object, e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport1.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            MyGridViewLCL.AllowPaging = False
            For Each cell As TableCell In MyGridViewLCL.HeaderRow.Cells
                cell.BackColor = MyGridViewLCL.HeaderStyle.BackColor
            Next

            For Each row As GridViewRow In MyGridViewLCL.Rows
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = MyGridViewLCL.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = MyGridViewLCL.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next

            MyGridViewLCL.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()
        End Using

    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered 
    End Sub
End Class