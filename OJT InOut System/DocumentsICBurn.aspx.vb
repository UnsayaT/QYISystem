Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports Microsoft.Office.Interop
Public Class DocumentsICBurn
    Inherits System.Web.UI.Page
    Dim strConnString, strSQL As String
    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand

    Public Property myRepeater As Object
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If RadioButton1.Text = "All" Then
            Using connObj As New SqlClient.SqlConnection("Server=172.16.0.102;Database=DBx;User=System;Password=p@$$w0rd;")
                Using cmdObj As New SqlClient.SqlCommand("
                SELECT        TOP (100) QYIICBurn.*, QYICase.*,Package,Device,TransactionData.WaferLotNo,MarkNo,CONVERT(VARCHAR(11),ICBurnDate,106)as Date
                FROM          [DBx].[QYI].QYICase INNER JOIN [DBx].[QYI].QYIICBurn  ON QYICase.No = QYIICBurn.No, TransactionData 
                WHERE         AbNo like '" & Session("SelectupAbNo") & "%'  and QYICase.LotNo = TransactionData.LotNo and Device like '" & Session("SelectupDeviceName") & "%' 
                                AND QYICase.No like '" & Session("YearNow") & "%'
                ORDER         by AbNo DESC", connObj)
                    connObj.Open()
                    Dim ds As New DataSet()
                    Dim data = New SqlDataAdapter(cmdObj)
                    data.Fill(ds)
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                    connObj.Close()
                End Using
            End Using
        Else
            Using connObj As New SqlClient.SqlConnection("Server=172.16.0.102;Database=DBx;User=System;Password=p@$$w0rd;")
                Using cmdObj As New SqlClient.SqlCommand("
                SELECT        TOP (100) QYIICBurn.*, QYICase.*,Package,Device,TransactionData.WaferLotNo,MarkNo,CONVERT(VARCHAR(11),ICBurnDate,106)as Date
                FROM          [DBx].[QYI].QYICase INNER JOIN [DBx].[QYI].QYIICBurn  ON QYICase.No = QYIICBurn.No, TransactionData 
                WHERE         AbNo like '" & Session("SelectupAbNo") & "%'  and QYICase.LotNo = TransactionData.LotNo and Device like '" & Session("SelectupDeviceName") & "%' 
                              And Finished <> 'OK' 
                              AND QYICase.No like '" & Session("YearNow") & "%'
                ORDER         by AbNo DESC", connObj)
                    connObj.Open()
                    Dim ds As New DataSet()
                    Dim data = New SqlDataAdapter(cmdObj)
                    data.Fill(ds)
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                    connObj.Close()
                End Using
            End Using
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Session("SelectuploadIssuenoout") = GridView1.SelectedRow.Cells(0).Text
        Session("SelectuploadIssuedateout") = GridView1.SelectedRow.Cells(4).Text
        Session("Selectuploadnameout") = GridView1.SelectedRow.Cells(1).Text
        Dim myDate As Date = Session("SelectuploadIssuedateout")
        Dim myYear As Int32 = myDate.Year
        Session("SelectuploadIssuedateout") = "RIST " & "- " & myYear
    End Sub

    Protected Sub SearchAbNoButton_Click(sender As Object, e As EventArgs) Handles SearchAbNoButton.Click
        Session("SelectupAbNo") = txtAbNo.Text
        Response.Redirect("DocumentsICBurn.aspx")
    End Sub

    Protected Sub SearchdeviecnameButton_Click(sender As Object, e As EventArgs) Handles SearchdeviecnameButton.Click
        Session("SelectupDeviceName") = txtDevice.Text
        Response.Redirect("DocumentsICBurn.aspx")
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub btnYear_Click(sender As Object, e As EventArgs) Handles btnYear.Click
        If Len(txtYear.Text) = 4 Then
            Session("YearNow") = txtYear.Text
            Response.Redirect("DocumentsICBurn.aspx")
        Else
            txtYear.Text = String.Empty
        End If
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Using connObj As New SqlClient.SqlConnection("Server=172.16.0.102;Database=DBx;User=System;Password=p@$$w0rd;")
            Using cmdObj As New SqlClient.SqlCommand("
                SELECT        QYIICBurn.*, QYICase.*,Package,Device,TransactionData.WaferLotNo,MarkNo,CONVERT(VARCHAR(11),ICBurnDate,106)as Date
                FROM          [DBx].[QYI].QYICase INNER JOIN [DBx].[QYI].QYIICBurn  ON QYICase.No = QYIICBurn.No, TransactionData 
                WHERE         AbNo like '" & Session("SelectupAbNo") & "%'  and QYICase.LotNo = TransactionData.LotNo and Device like '" & Session("SelectupDeviceName") & "%' 
                                AND QYICase.No like '" & Session("YearNow") & "%'
                ORDER         by AbNo DESC", connObj)
                connObj.Open()
                Dim ds As New DataSet()
                Dim data = New SqlDataAdapter(cmdObj)
                data.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                connObj.Close()
            End Using
        End Using

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            GridView1.AllowPaging = False

            GridView1.HeaderRow.BackColor = Color.White
            For Each cell As TableCell In GridView1.HeaderRow.Cells
                cell.BackColor = GridView1.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridView1.Rows
                row.BackColor = Color.White
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridView1.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next

            GridView1.RenderControl(hw)
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

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Session.Remove("SelectDevice")
        Session.Remove("SelectIssueno")
        Session.Remove("YearNow")
        Response.Redirect("DocumentsICBurn.aspx")
    End Sub

End Class