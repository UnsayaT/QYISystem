Imports System.Data.SqlClient
Imports System.IO

Public Class DetailFile
    Inherits System.Web.UI.Page
    Dim strConnString, strSQL As String
    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Using connObj As New SqlClient.SqlConnection("Server=172.16.0.102;Database=DBx;User=System;Password=p@$$w0rd;")
            Using cmdObj As New SqlClient.SqlCommand("
                SELECT   TOP (1) QYILowYield.No, QYILowYield.IssueNo, QYILowYield.IssueDate, TransactionData.Device, QYICase.No AS Expr1
                FROM     [DBx].[QYI].QYICase INNER JOIN
                         [DBx].[QYI].QYILowYield ON QYICase.No = QYILowYield.No INNER JOIN
                         TransactionData ON QYICase.LotNo = TransactionData.LotNo
                WHERE    (QYILowYield.IssueNo LIKE '" & Request.QueryString("IssueNo") & "%')
                ORDER BY TransactionData.LotNo DESC", connObj)
                connObj.Open()
                Using readerObj As SqlClient.SqlDataReader = cmdObj.ExecuteReader
                    While readerObj.Read

                        Dim myDate As Date = readerObj("IssueDate").ToString
                        Dim myYear As Int32 = myDate.Year
                        Session("DetailYear") = "RIST" & "-" & myYear
                        Session("DetailDeivce") = readerObj("Device").ToString
                    End While
                End Using
                connObj.Close()
            End Using

            Using cmdObj1 As New SqlClient.SqlCommand("
                SELECT   TOP (1) QYIICBurn.No, QYIICBurn.AbNo, ICBurnDate,TransactionData.Device, QYICase.No AS Expr1
                FROM     [DBx].[QYI].QYICase INNER JOIN
                         [DBx].[QYI].QYIICBurn ON QYICase.No = QYIICBurn.No INNER JOIN
                         TransactionData ON QYICase.LotNo = TransactionData.LotNo
                WHERE    (QYIICBurn.AbNo LIKE '" & Request.QueryString("IssueNo") & "%')
                ORDER BY TransactionData.LotNo DESC", connObj)
                connObj.Open()
                Using readerObj As SqlClient.SqlDataReader = cmdObj1.ExecuteReader
                    While readerObj.Read

                        Dim myDate As Date = readerObj("ICBurnDate").ToString
                        Dim myYear As Int32 = myDate.Year
                        Session("DetailYear") = "RIST" & "-" & myYear
                        Session("DetailDeivce") = readerObj("Device").ToString
                    End While
                End Using
                connObj.Close()
            End Using

        End Using

        Label1.Text = "Issue No. : " & Request.QueryString("IssueNo")

        If Not IsPostBack Then
            Dim filePaths() As String = Directory.GetFiles("\\172.16.0.115/NewCenterPoint/QYI/" & Session("DetailYear") & "/" & Request.QueryString("IssueNo") & "(" & Session("DetailDeivce") & ")")
            Dim files As List(Of ListItem) = New List(Of ListItem)
            For Each filePath As String In filePaths
                files.Add(New ListItem(Path.GetFileName(filePath), filePath))
            Next
            GridView2.DataSource = files
            GridView2.DataBind()
        End If
    End Sub

    Protected Sub DownloadFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim filePath As String = CType(sender, LinkButton).CommandArgument
        Response.ContentType = ContentType
        Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(filePath)))
        Response.WriteFile(filePath)
        Response.End()
    End Sub

End Class