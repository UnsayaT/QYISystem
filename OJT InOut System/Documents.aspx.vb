Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports Microsoft.Office.Interop

Public Class Documents
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If RadioButtonList1.Text = "All" Then
            Session("SelectProcessmode") = "%"
            Session("SelectPackage") = "%"

            If DropDownList1.Text = "" Then
                Session("SelectPackage") = "%"
            ElseIf DropDownList1.Text = "Select" Then
                Session("SelectPackage") = "%"
            Else
                If DropDownList1.Text = "All Package" Then
                    Session("SelectPackage") = "%"
                Else
                    Session("SelectPackage") = DropDownList1.Text
                End If
            End If
        Else
            If RadioButtonList1.Text = "FT" Then
                Session("SelectProcessmode") = RadioButtonList1.Text
                If DropDownList1.Text = "Select" Then
                    Session("SelectPackage") = "%"
                Else
                    If DropDownList1.Text = "All Package" Then
                        Session("SelectPackage") = "%"
                    Else
                        Session("SelectPackage") = DropDownList1.Text
                    End If
                End If
            ElseIf RadioButtonList1.Text = "FL" Then
                Session("SelectProcessmode") = RadioButtonList1.Text
                Session("SelectPackage") = "%"
                If DropDownList1.Text = "Select" Then
                    Session("SelectPackage") = "%"
                Else
                    If DropDownList1.Text = "All Package" Then
                        Session("SelectPackage") = "%"
                    Else
                        Session("SelectPackage") = DropDownList1.Text
                    End If
                End If
            Else
                Session("SelectProcessmode") = RadioButtonList1.Text
                If DropDownList1.Text = "Select" Then
                    Session("SelectPackage") = "%"
                Else
                    If DropDownList1.Text = "All Package" Then
                        Session("SelectPackage") = "%"
                    Else
                        Session("SelectPackage") = DropDownList1.Text
                    End If
                End If
            End If
        End If

        Using connObj As New SqlClient.SqlConnection("Server=172.16.0.102;Database=DBx;User=System;Password=p@$$w0rd;")
            'New Data
            Using cmdObj As New SqlClient.SqlCommand("
             SELECT      TOP (100) QYILowYield.IssueNo, QYILowYield.IssueDate, QYILowYield.Kanbandate, QYILowYield.FNDate, QYILowYield.Mode, QYILowYield.GoodProductShip, QYILowYield.GoodProductScrap, QYILowYield.NGProductBBank, 
                         QYILowYield.NGProductScrap, QYILowYield.OneTimeReTestScrap, QYILowYield.Cause, QYILowYield.NGTestNo, QYILowYield.NGTestData, QYILowYield.AnswerDeviceGood, QYILowYield.AnswerDeviceNG, QYICase.Process, 
                         QYICase.LotNo, QYICase.Program, QYICase.FTYield, QYICase.TestFlow, QYICase.Remark, QYICase.UserIDOut, dbo.TransactionData.Package, dbo.TransactionData.Device, dbo.TransactionData.WaferLotNo, 
                         dbo.TransactionData.MarkNo, CONVERT(VARCHAR(11), QYILowYield.IssueDate, 106) AS Date, CONVERT(VARCHAR(11), QYILowYield.FNDate, 106) AS NewFNDate, QYICase.UserIDIn, QYILowYield.LotNo1
            FROM         [DBx].[QYI].QYICase INNER JOIN
                         [DBx].[QYI].QYILowYield ON QYICase.No = QYILowYield.No INNER JOIN
                         dbo.TransactionData ON QYICase.LotNo = dbo.TransactionData.LotNo
           WHERE        (QYILowYield.IssueNo LIKE '%" & Session("SelectIssueno") & "%') AND (QYICase.Process LIKE '" & Session("SelectProcessmode") & "%') AND (QYICase.LotNo <> '-') AND 
                         (dbo.TransactionData.Device LIKE '%" & Session("SelectDevice") & "%') AND (dbo.TransactionData.Package LIKE '" & Session("SelectPackage") & "') AND (QYICase.No LIKE '" & Session("YearNow") & "%')
            ORDER       BY QYILowYield.IssueNo DESC", connObj)
                connObj.Open()
                Dim ds As New DataSet()
                Dim data = New SqlDataAdapter(cmdObj)

                data.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                connObj.Close()
            End Using

            Using cmdObj As New SqlClient.SqlCommand("  
                SELECT         DISTINCT(Package)
                FROM          DBx.dbo.TransactionData,[DBx].[QYI].QYICase INNER JOIN [DBx].[QYI].QYILowYield ON QYICase.No = QYILowYield.No  
                Where         Package <> '' AND Issueno <> ''
                              AND Process like '" & Session("SelectProcessmode") & "%'
                Order         by Package ASC", connObj)
                cmdObj.CommandType = CommandType.Text
                cmdObj.Connection = connObj
                connObj.Open()
                DropDownList1.DataSource = cmdObj.ExecuteReader()
                DropDownList1.DataTextField = "Package"
                DropDownList1.DataBind()
                connObj.Close()
                DropDownList1.Items.Insert(0, New ListItem("Select"))
                DropDownList1.Items.Insert(1, New ListItem("All Package"))
            End Using
        End Using
    End Sub

    Private Sub myGridView_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        '*** LotNo ***'
        Dim lblLotNo1 As Label = CType(e.Row.FindControl("lblLotNo1"), Label)
        If Not IsNothing(lblLotNo1) Then
            lblLotNo1.Text = e.Row.DataItem("LotNo1")
        End If
    End Sub
    Protected Sub btnIssueNo_Click(sender As Object, e As EventArgs) Handles btnIssueNo.Click
        Session("SelectIssueno") = txtIssueNo.Text
        Session.Remove("SelectDevice")
        Session.Remove("YearNow")
        Response.Redirect("Documents.aspx")
    End Sub

    Protected Sub btnDevice_Click(sender As Object, e As EventArgs) Handles btnDevice.Click
        Session("SelectDevice") = txtDevice.Text
        Session.Remove("SelectIssueno")
        Session.Remove("YearNow")
        Response.Redirect("Documents.aspx")
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered 
    End Sub


    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Using connObj As New SqlClient.SqlConnection("Server=172.16.0.102;Database=DBx;User=QYIUser;")
            Using cmdObj As New SqlClient.SqlCommand("
             SELECT      QYILowYield.IssueNo, QYILowYield.IssueDate, QYILowYield.Kanbandate, QYILowYield.FNDate, QYILowYield.Mode, QYILowYield.GoodProductShip, QYILowYield.GoodProductScrap, QYILowYield.NGProductBBank, 
                         QYILowYield.NGProductScrap, QYILowYield.OneTimeReTestScrap, QYILowYield.Cause, QYILowYield.NGTestNo, QYILowYield.NGTestData, QYILowYield.AnswerDeviceGood, QYILowYield.AnswerDeviceNG,QYILowYield.LotNo1, QYICase.Process, 
                         QYICase.LotNo, QYICase.Program, QYICase.FTYield, QYICase.TestFlow, QYICase.Remark, QYICase.UserIDOut, dbo.TransactionData.Package, dbo.TransactionData.Device, dbo.TransactionData.WaferLotNo, 
                         dbo.TransactionData.MarkNo, CONVERT(VARCHAR(11), QYILowYield.IssueDate, 106) AS Date, CONVERT(VARCHAR(11), QYILowYield.FNDate, 106) AS NewFNDate, QYICase.UserIDIn
            FROM         QYICase INNER JOIN
                         QYILowYield ON QYICase.No = QYILowYield.No INNER JOIN
                         dbo.TransactionData ON QYICase.LotNo = dbo.TransactionData.LotNo
            WHERE        (QYILowYield.IssueNo LIKE '%" & Session("SelectIssueno") & "%') AND (QYICase.Process LIKE '" & Session("SelectProcessmode") & "%') AND (QYICase.LotNo <> '-') AND 
                         (dbo.TransactionData.Device LIKE '%" & Session("SelectDevice") & "%') AND (dbo.TransactionData.Package LIKE '" & Session("SelectPackage") & "') AND (QYICase.No LIKE '" & Session("YearNow") & "%')
            ORDER       BY QYILowYield.IssueNo DESC", connObj)
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

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub btnYear_Click(sender As Object, e As EventArgs) Handles btnYear.Click
        If Len(txtYear.Text) = 4 Then
            Session("YearNow") = txtYear.Text
            Session.Remove("SelectDevice")
            Session.Remove("SelectIssueno")
            Response.Redirect("Documents.aspx")
        Else
            txtYear.Text = String.Empty
        End If
    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Session.Remove("SelectDevice")
        Session.Remove("SelectIssueno")
        Session.Remove("YearNow")
        Response.Redirect("Documents.aspx")
    End Sub

End Class