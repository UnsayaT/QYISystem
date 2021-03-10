Imports System.IO
Public Class UploadFileQC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'แสดงไฟล์
        Label1.Text = "LotNo. : " & Session("Lot") & ""
        If Not IsPostBack Then
            Dim filePaths() As String = Directory.GetFiles("\\172.16.0.115/NewCenterPoint/QYI/QC/" & Session("Lot") & "")
            Dim files As List(Of ListItem) = New List(Of ListItem)
            For Each filePath As String In filePaths
                files.Add(New ListItem(Path.GetFileName(filePath), filePath))
            Next
            GridView2.DataSource = files
            GridView2.DataBind()
        End If
    End Sub

    Protected Sub UploadFile(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload.Click
        My.Computer.FileSystem.CreateDirectory("\\172.16.0.115/NewCenterPoint/QYI/QC/" & Session("Lot") & "")
        Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
        FileUpload1.PostedFile.SaveAs("\\172.16.0.115/NewCenterPoint/QYI/QC/" & Session("Lot") & "/" + FileName)
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub DownloadFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim FilePath As String = CType(sender, LinkButton).CommandArgument
        Response.ContentType = ContentType
        Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(FilePath)))
        Response.WriteFile(FilePath)
        Response.End()
    End Sub
    Protected Sub DeleteFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim FilePath As String = CType(sender, LinkButton).CommandArgument
        File.Delete(FilePath)
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("ProcessQC.aspx")
    End Sub
End Class