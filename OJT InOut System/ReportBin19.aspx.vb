Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports OfficeOpenXml


Public Class ReportBin19
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
            Excel()
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
        strSQL = "SELECT FORMAT(TimeIn, 'dd/MM/yyyy HH:mm:ss') As DateIn,
CASE WHEN FORMAT(TimeOut, 'dd/MM/yyyy HH:mm:ss') IS NULL THEN FORMAT(TimeOut2, 'dd/MM/yyyy HHh:mm:ss') ELSE FORMAT(TimeOut, 'dd/MM/yyyy HH:mm:ss') END As DateOut,
OldDeviceName,OldPackage,LotNo,BeforeOSNG1,BeforeOSNG2,
CASE 
	WHEN CONVERT(varchar(5), OSNG1)  IS NULL THEN '' 
	WHEN CONVERT(varchar(5), OSNG1) = '0' THEN 'OK' 
	ELSE CONVERT(varchar(5), OSNG1) END As NG1,
CASE 
	WHEN CONVERT(varchar(5), OSNG2)  IS NULL THEN '' 
	WHEN CONVERT(varchar(5), OSNG2)  ='0' THEN 'OK' 
	ELSE CONVERT(varchar(5), OSNG2) END As NG2,
GotoProcess,GotoProcess2,QCJugdement
FROM [DBx].[QYI].[QYICase] WHERE Mode='BIN19'  and TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "'"

        Dim dtReader As SqlDataReader
        objCmd = New SqlCommand(strSQL, objConn)
        dtReader = objCmd.ExecuteReader()

        '*** BindData to Repeater ***'
        myRepeater.DataSource = dtReader
        myRepeater.DataBind()

        dtReader.Close()
        dtReader = Nothing

        'Me.lblText.Text = "Excel Created <a href=" & FileName & ">Click here</a> to Download."
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindData()
        Excel()
    End Sub


    'Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
    Sub Excel()
        Dim template As New FileInfo(Server.MapPath("MyXls/Template.xlsx"))
        Dim FileName As String = "MyXls/myExcel.xlsx"
        Using package = New ExcelPackage(template)
            Dim workbook = package.Workbook

            '*** Sheet 1
            Dim worksheet = workbook.Worksheets.First()
            Dim lblDateIn, lblDateOut, lblPackage, lblDeviceName, lblLotNo, lblBeforeOSNG1, lblBeforeOSNG2, lblNG1, lblNG2, lbl1stjug, lblafterjug, lblqcjug As System.Web.UI.WebControls.Label
            Dim i, intRows As Integer

            intRows = 1
            Dim startRows As Integer = 10

            For i = 0 To myRepeater.Items.Count - 1

                lblDateIn = myRepeater.Items(i).FindControl("lblDateIn")
                lblDateOut = myRepeater.Items(i).FindControl("lblDateOut")
                lblPackage = myRepeater.Items(i).FindControl("lblPackage")
                lblDeviceName = myRepeater.Items(i).FindControl("lblDeviceName")
                lblLotNo = myRepeater.Items(i).FindControl("lblLotNo")
                lblBeforeOSNG1 = myRepeater.Items(i).FindControl("lblBeforeOSNG1")
                lblNG1 = myRepeater.Items(i).FindControl("lblNG1")
                lbl1stjug = myRepeater.Items(i).FindControl("lbl1stJug")
                lblBeforeOSNG2 = myRepeater.Items(i).FindControl("lblBeforeOSNG2")
                lblNG2 = myRepeater.Items(i).FindControl("lblNG2")
                lblafterjug = myRepeater.Items(i).FindControl("lblAfterJug")
                lblqcjug = myRepeater.Items(i).FindControl("lblQCJug")

                worksheet.Cells("A" & (startRows)).Value = lblDateIn.Text
                worksheet.Cells("B" & (startRows)).Value = lblDateOut.Text
                worksheet.Cells("C" & (startRows)).Value = lblPackage.Text
                worksheet.Cells("D" & (startRows)).Value = lblDeviceName.Text
                worksheet.Cells("E" & (startRows)).Value = lblLotNo.Text
                worksheet.Cells("F" & (startRows)).Value = lblBeforeOSNG1.Text
                worksheet.Cells("G" & (startRows)).Value = lblNG1.Text
                worksheet.Cells("H" & (startRows)).Value = lbl1stjug.Text
                worksheet.Cells("I" & (startRows)).Value = lblBeforeOSNG2.Text
                worksheet.Cells("J" & (startRows)).Value = lblNG2.Text
                worksheet.Cells("K" & (startRows)).Value = lblafterjug.Text
                worksheet.Cells("L" & (startRows)).Value = lblqcjug.Text
                startRows = startRows + 1
            Next

            package.SaveAs(New FileInfo(Server.MapPath(FileName)))

            Me.lblText.Text = "<a href=" & FileName & ">Click here</a> to Download Excel."
        End Using
    End Sub

    Sub Page_UnLoad()
        objConn.Close()
        objConn = Nothing
    End Sub


End Class