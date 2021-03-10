Imports System.Data.SqlClient
Public Class DetailIssueNoICBrun
    Inherits System.Web.UI.Page
    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strConnString, strSQLCheck As String
        Dim dtAdapterCheck As SqlDataAdapter
        Dim dt, dtpro, dtNo, dtEmp, dtIssue, dtFT, dtFL, dtMAP, dtCheck As New DataTable

        strConnString = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=DBx;Max Pool Size=400;Connect Timeout=600;"
        objConn = New SqlConnection(strConnString)
        objConn.Open()

        ' ** Calculate Ab No. **

        Dim nextAbNo As String
        Dim cheakyear As String
        Dim countnext As Integer
        Dim countnext2 As String
        Dim myDate As Date = Date.Now
        Dim myYear As Int32 = myDate.Year
        Session("InsertYear") = "RIST" & "-" & myYear
        Label1.Text = "RIST" & "-" & myYear & "-" & "Ab" & "-" & "001"
        Session("InsertAbNo") = Label1.Text
        strSQLCheck = "
                SELECT      TOP (1) AbNo
                FROM        [DBx].[QYI].QYIICBurn
                WHERE       (AbNo <> 'TEMPORARY')
                ORDER       BY AbNo DESC"
        dtAdapterCheck = New SqlDataAdapter(strSQLCheck, objConn)
        dtAdapterCheck.Fill(dtCheck)
        If dtCheck.Rows.Count > 0 Then
            nextAbNo = dtCheck.Rows(0)("AbNo")
            cheakyear = nextAbNo
            cheakyear = Mid(cheakyear, 6, 4)

            If myYear = cheakyear Then
                nextAbNo = Mid(nextAbNo, 14, 3)
                countnext = nextAbNo.Trim()
                countnext = countnext + 1
                countnext2 = String.Format("{0,3:D3}", countnext)
                Session("InsertAbNo") = "RIST" & "-" & myYear & "-" & "Ab" & "-" & countnext2
                Label1.Text = "Ab.No " & Session("InsertAbNo")
            Else
                Session("InsertAbNo") = "RIST" & "-" & myYear & "-" & "Ab" & "-" & "001"
                Label1.Text = "Ab.No " & Session("InsertAbNo")
            End If
        End If
    End Sub
    Protected Sub DropDownList3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList3.SelectedIndexChanged
        ' ** Case Type IC Burn **
        If DropDownList3.Text = "Bin31" Then
            OtherValue.Visible = False
            Session("InsertDeviceType") = "Bin31"
        ElseIf DropDownList3.Text = "Bin29" Then
            OtherValue.Visible = False
            Session("InsertDeviceType") = "Bin29"
        ElseIf DropDownList3.Text = "QA" Then
            OtherValue.Visible = False
            Session("InsertDeviceType") = "QA"
        ElseIf DropDownList3.Text = "LCL" Then
            OtherValue.Visible = False
            Session("InsertDeviceType") = "LCL"
        ElseIf DropDownList3.Text = "Eva" Then
            OtherValue.Visible = False
            Session("InsertDeviceType") = "Eva"
        ElseIf DropDownList3.Text = "Other" Then
            OtherValue.Visible = True
            Session("InsertDeviceType") = "Other"
        End If
    End Sub
    Protected Sub InputButton_Click(sender As Object, e As EventArgs) Handles InputButton.Click
        Dim strSQLUpdate As String
        Dim thisDay As DateTime = Date.Now
        Session("InsertDateOccur") = thisDay
        Dim myDate As Date = Session("InsertDateOccur")
        Dim myYear As Int32 = myDate.Year

        If DropDownList3.Text = "Bin31" Then
            Session("InsertDeviceType") = "Bin31"
        ElseIf DropDownList3.Text = "Bin29" Then
            Session("InsertDeviceType") = "Bin29"
        ElseIf DropDownList3.Text = "QA" Then
            Session("InsertDeviceType") = "QA"
        ElseIf DropDownList3.Text = "LCL" Then
            Session("InsertDeviceType") = "LCL"
        ElseIf DropDownList3.Text = "Eva" Then
            Session("InsertDeviceType") = "Eva"
        ElseIf DropDownList3.Text = "Other" Then
            Session("InsertDeviceType") = "Other"
        End If

        Session("InsertOccur") = "RIST" & "-" & myYear
        Session("InsertIssueNo") = Session("InsertAbNo") & "-" & Session("InsertDeviceType")

        Using connObj As New SqlClient.SqlConnection("Server=172.16.0.102;Database=APCSDB;User=dbxuser;")
            Using cmdObj As New SqlClient.SqlCommand("
            SELECT       CONVERT(VARCHAR(5),OUT_DAY,110) as ShipDate
            FROM         [APCSDB].[dbo].[LOT1_TABLE]
            WHERE        (LOT_NO = '" & Session("LotNo1") & "')", connObj)
                connObj.Open()
                Using readerObj As SqlClient.SqlDataReader = cmdObj.ExecuteReader
                    While readerObj.Read
                        Session("Shipment") = readerObj("ShipDate").ToString()
                    End While
                End Using
                connObj.Close()
            End Using
        End Using

        strSQLUpdate = "Update [DBx].[QYI].[QYIICBurn] Set AbNo='" & Session("InsertIssueNo") & "',ICBurnDate='" & Session("InsertDateOccur") & "',LotStatus='" & LotstatusValue.Text & "',GoodProductShip='-',OSCheck='" & OSCheckValue.Text & "',OST1='" & OSTTValue.Text & "',OST2='" & OSTTValue0.Text & "',OST3='" & OSTTValue1.Text & "',OST4='" & OSTTValue2.Text & "',OST5='" & OSTTValue3.Text & "',OST6='" & OSTTValue4.Text & "',LowVoltPIN1='" & LV1PINTValue.Text & "',LowVoltPIN2='" & LV1PINTValue0.Text & "',LowVoltPIN3='" & LV1PINTValue1.Text & "',LowVoltPIN4='" & LV1PINTValue2.Text & "',LowVoltPIN5='" & LV1PINTValue3.Text & "',LowVoltPIN6='" & LV1PINTValue4.Text & "',MeasurePIN1='" & ME1PINTValue.Text & "',MeasurePIN2='" & ME1PINTValue0.Text & "',MeasurePIN3='" & ME1PINTValue1.Text & "',MeasurePIN4='" & ME1PINTValue2.Text & "',MeasurePIN5='" & ME1PINTValue3.Text & "',MeasurePIN6='" & ME1PINTValue4.Text & "',Finished='-',ShipmentDate='" & Session("Shipment") & "' WHERE No ='" & Session("No") & "'"
        objCmd = New SqlCommand(strSQLUpdate, objConn)
        objCmd.ExecuteNonQuery()



        My.Computer.FileSystem.CreateDirectory("\\172.16.0.115/NewCenterPoint/QYI/" & Session("InsertOccur") & "\" & Session("InsertIssueNo") & "(" & Session("Device") & ")")
        Response.Redirect("UploadFileIssueNo.aspx")
    End Sub
End Class