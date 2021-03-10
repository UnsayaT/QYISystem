Imports System.IO
Public Class UploadFileIssueNo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'แสดงไฟล์
        Label1.Text = "Issue No. : " & Session("InsertIssueNo") & "<br/><br/>" & "Device Name : " & Session("Device")
        If Not IsPostBack Then
            Dim filePaths() As String = Directory.GetFiles("\\172.16.0.115/NewCenterPoint/QYI/" & Session("InsertYear") & "/" & Session("InsertIssueNo") & "(" & Session("Device") & ")/")
            Dim files As List(Of ListItem) = New List(Of ListItem)
            For Each filePath As String In filePaths
                files.Add(New ListItem(Path.GetFileName(filePath), filePath))
            Next
            GridView2.DataSource = files
            GridView2.DataBind()
        End If
    End Sub
    Protected Sub UploadFile(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload.Click
        Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
        FileUpload1.PostedFile.SaveAs("\\172.16.0.115/NewCenterPoint/QYI/" & Session("InsertYear") & "/" & Session("InsertIssueNo") & "(" & Session("Device") & ")/" + FileName)
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
        Session.Remove("InsertNextIssueNo")
        Session.Remove("InsertUploadIssueNo")
        Session.Remove("InsertPackage")
        Session.Remove("InsertLotNo")
        Session.Remove("InsertDeviceName")
        Session.Remove("InsertUploadName")
        Session.Remove("InsertWafer")
        Session.Remove("InsertIssueDate")
        Session.Remove("InsertKanban")
        Session.Remove("InsertProcess")
        Session.Remove("InsertNgtNo")
        Session.Remove("InsertNgtDate")
        Session.Remove("InsertMode")
        Session.Remove("InsertYield")
        Session.Remove("InsertProcessMode")

        Session.Remove("CheckIssueDateold")
        Session.Remove("InsertIssueNo")
        Session.Remove("CheckLotNo")
        Session.Remove("ID")
        Response.Redirect("Default.aspx")
    End Sub
End Class