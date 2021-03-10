Imports System.Data.SqlClient
Imports System.IO

Public Class DetailOutLowYield
    Inherits System.Web.UI.Page
    Dim objConn As SqlConnection
    Dim objCmd As SqlCommand
    Dim strConnString, strSQLUpdate As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strConnString = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=DBx;Max Pool Size=400;Connect Timeout=600;"
        objConn = New SqlConnection(strConnString)
        objConn.Open()
        FNDate.Text = Now()
        Session("FNDate") = FNDate.Text
        lblIssueNo.Text = Session("IssueNo")
        Session("Type") = "LCL"

        If Not IsPostBack Then
            Dim filePaths() As String = Directory.GetFiles("\\172.16.0.115/NewCenterPoint/QYI/" & Session("InsertYear") & "/" & Session("IssueNo") & "(" & Session("Device") & ")/")
            Dim files As List(Of ListItem) = New List(Of ListItem)
            For Each filePath As String In filePaths
                files.Add(New ListItem(Path.GetFileName(filePath), filePath))
            Next
            GridView2.DataSource = files
            GridView2.DataBind()
        End If

    End Sub

    Protected Sub InputButton_Click(sender As Object, e As EventArgs) Handles InputButton.Click
        If GoodProductSHIP1.Checked Then
            Session("GoodProductSHIP") = "O"
        Else
            Session("GoodProductSHIP") = "-"
        End If

        If GoodProductSCRAP1.Checked Then
            Session("GoodProductSCRAP") = "O"
        Else
            Session("GoodProductSCRAP") = "-"
        End If

        If NgProductBBANK1.Checked Then
            Session("NgProductBBANK") = "O"
        Else
            Session("NgProductBBANK") = "-"
        End If

        If NgProductSCRAP1.Checked Then
            Session("NgProductSCRAP") = "O"
        Else
            Session("NgProductSCRAP") = "-"
        End If

        If NgProducttime1.Checked Then
            Session("UpdateOneTimeReTestScrap") = "O"
        Else
            Session("UpdateOneTimeReTestScrap") = "-"
        End If

        If DeviceGoodcheck1.Checked Then
            If DeviceGoodRadioButtontextbox.Text = "" Then
                Session("UpdateAnswerDeviceGood") = "O"
            Else
                Session("UpdateAnswerDeviceGood") = DeviceGoodRadioButtontextbox.Text
            End If
        Else
            Session("UpdateAnswerDeviceGood") = "-"
        End If

        If DeviceNGcheck1.Checked Then
            If DeviceNGRadioButtontextbox.Text = "" Then
                Session("UpdateAnswerDeviceNG") = "O"
            Else
                Session("UpdateAnswerDeviceNG") = DeviceNGRadioButtontextbox.Text
            End If
        Else
            Session("UpdateAnswerDeviceNG") = "-"
        End If

        If Cause1.Checked = True Then
            Session("UpdateCause1") = "Repair"
        End If
        If Cause2.Checked = True Then
            Session("UpdateCause2") = "Assy"
        End If
        If Cause3.Checked = True Then
            Session("UpdateCause3") = "Test"
        End If
        If Cause4.Checked = True Then
            Session("UpdateCause4") = "Fab"
        End If
        If Cause5.Checked = True Then
            Session("UpdateCause5") = "Spec"
        End If
        If Cause6.Checked = True Then
            Session("UpdateCause6") = "Etc"
        End If
        If Cause7.Checked = True Then
            Session("UpdateCause7") = "Analysis"
        End If

        If IsDBNull(Session("TimeKeyOut")) Then
            strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set FNDate = '" & Session("FNDate") & "'
,GoodProductShip='" & Session("GoodProductSHIP") & "'
,GoodProductScrap='" & Session("GoodProductSCRAP") & "'
,NGProductBBank='" & Session("NgProductBBANK") & "'
,NGProductScrap='" & Session("NgProductSCRAP") & "'
,OneTimeReTestScrap='" & Session("UpdateOneTimeReTestScrap") & "'
,Cause='" & Session("UpdateCause1") & " " & Session("UpdateCause2") & " " & Session("UpdateCause3") & " " & Session("UpdateCause4") & " " & Session("UpdateCause5") & " " & Session("UpdateCause6") & " " & Session("UpdateCause7") & "'
,AnswerDeviceGood='" & Session("UpdateAnswerDeviceGood") & "'
,AnswerDeviceNG='" & Session("UpdateAnswerDeviceNG") & "'
WHERE IssueNo='" & Session("IssueNo") & "'"
            objCmd = New SqlCommand(strSQLUpdate, objConn)
            objCmd.ExecuteNonQuery()
            Response.Redirect("DetailNextFlow.aspx")
        Else
            strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set FNDate = '" & Session("TimeKeyOut") & "'
,GoodProductShip='" & Session("GoodProductSHIP") & "'
,GoodProductScrap='" & Session("GoodProductSCRAP") & "'
,NGProductBBank='" & Session("NgProductBBANK") & "'
,NGProductScrap='" & Session("NgProductSCRAP") & "'
,OneTimeReTestScrap='" & Session("UpdateOneTimeReTestScrap") & "'
,Cause='" & Session("UpdateCause1") & " " & Session("UpdateCause2") & " " & Session("UpdateCause3") & " " & Session("UpdateCause4") & " " & Session("UpdateCause5") & " " & Session("UpdateCause6") & " " & Session("UpdateCause7") & "'
,AnswerDeviceGood='" & Session("UpdateAnswerDeviceGood") & "'
,AnswerDeviceNG='" & Session("UpdateAnswerDeviceNG") & "'
WHERE IssueNo='" & Session("IssueNo") & "'"
            objCmd = New SqlCommand(strSQLUpdate, objConn)
            objCmd.ExecuteNonQuery()
            Response.Redirect("DetailNextFlow.aspx")
        End If

    End Sub


    Protected Sub UploadFile(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload.Click
        Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
        FileUpload1.PostedFile.SaveAs("\\172.16.0.115/NewCenterPoint/QYI/" & Session("InsertYear") & "/" & Session("IssueNo") & "(" & Session("Device") & ")/" + FileName)
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
End Class