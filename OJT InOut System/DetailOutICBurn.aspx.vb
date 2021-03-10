Imports System.Data.SqlClient
Public Class DetailOutICBurn
    Inherits System.Web.UI.Page
    Dim objConn As SqlConnection
    Dim objCmd As SqlCommand
    Dim strConnString, strSQLUpdate As String

    Dim lot, Op_No, strSQLEmp, strSQLLot, strSQLIssue As String
    Dim dtAdapterEmp, dtAdapterLot, dtAdapterIssue As SqlDataAdapter
    Dim dtQYI, dtLY, dtIC, dtNo, dtEmp, dtLotID, dtLot, dtIssue As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strConnString = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=DBx;Max Pool Size=400;Connect Timeout=600;"
        objConn = New SqlConnection(strConnString)
        objConn.Open()
        Session("Type") = "IC"

        'Check Lot No ใน QYI
        strSQLLot = "Select QYICase.*,QYIICBurn.* From [DBx].[QYI].[QYICase],[DBx].[QYI].[QYIICBurn] Where QYICase.No=QYIICBurn.No and  LotNo ='" & Session("Lot") & "'"
        dtAdapterLot = New SqlDataAdapter(strSQLLot, objConn)
        dtAdapterLot.Fill(dtLot)
        If dtLot.Rows.Count > 0 Then
            OSCheckValue.Text = dtLot.Rows(0)("OSCheck")
            TesterNoValue.Text = dtLot.Rows(0)("TestNo")
            LotstatusValue.Text = dtLot.Rows(0)("LotStatus")
            BoxNoValue.Text = dtLot.Rows(0)("BoxNo")
            If dtLot.Rows(0)("GoodProductShip") = "O         " Then
                GoodProductSHIP1.Checked = True
            Else
                GoodProductSHIP1.Checked = False
            End If

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

        If FinishedCB.Checked Then
            Session("FinishedCB") = "OK"
        Else
            Session("FinishedCB") = "-"
        End If

        Session("UpdateOSCheck") = OSCheckValue.Text
        Session("UpdateLotstatus") = LotstatusValue.Text
        Session("UpdateTesterNo") = TesterNoValue.Text
        Session("UpdateBoxNo") = BoxNoValue.Text
        Session("UpdateOST1") = OSTTValue1.Text
        Session("UpdateOST2") = OSTTValue2.Text
        Session("UpdateOST3") = OSTTValue3.Text
        Session("UpdateOST4") = OSTTValue4.Text
        Session("UpdateOST5") = OSTTValue5.Text
        Session("UpdateOST6") = OSTTValue6.Text

        Session("UpdateLowVoltPIN1") = LV1PINTValue1.Text
        Session("UpdateLowVoltPIN2") = LV1PINTValue2.Text
        Session("UpdateLowVoltPIN3") = LV1PINTValue3.Text
        Session("UpdateLowVoltPIN4") = LV1PINTValue4.Text
        Session("UpdateLowVoltPIN5") = LV1PINTValue5.Text
        Session("UpdateLowVoltPIN6") = LV1PINTValue6.Text

        Session("UpdateMeasurePIN1") = ME1PINTValue1.Text
        Session("UpdateMeasurePIN2") = ME1PINTValue2.Text
        Session("UpdateMeasurePIN3") = ME1PINTValue3.Text
        Session("UpdateMeasurePIN4") = ME1PINTValue4.Text
        Session("UpdateMeasurePIN5") = ME1PINTValue5.Text
        Session("UpdateMeasurePIN6") = ME1PINTValue6.Text
       ' Session("FinishedCB") = FinishedCB.Checked

        strSQLUpdate = "Update [DBx].[QYI].[QYIICBurn] Set LotStatus ='" & Session("UpdateLotstatus") & "'
,GoodProductShip = '" & Session("GoodProductSHIP") & "'
,GoodProductScrap='" & Session("GoodProductSCRAP") & "'
,NGProductBBank='" & Session("NgProductBBANK") & "'
,NGProductScrap='" & Session("NgProductSCRAP") & "'
,OneTimeReTestScrap='" & Session("UpdateOneTimeReTestScrap") & "'
,AnswerDeviceNG='" & Session("UpdateAnswerDeviceGood") & "'
,AnswerDeviceGood='" & Session("UpdateAnswerDeviceNG") & "'
,Cause=''
,OSCheck='" & Session("UpdateOSCheck") & "'
,OST1='" & Session("UpdateOST1") & "'
,OST2='" & Session("UpdateOST2") & "'
,OST3='" & Session("UpdateOST3") & "'
,OST4='" & Session("UpdateOST4") & "'
,OST5='" & Session("UpdateOST5") & "'
,OST6='" & Session("UpdateOST6") & "'
,LowVoltPIN1='" & Session("UpdateLowVoltPIN1") & "'
,LowVoltPIN2='" & Session("UpdateLowVoltPIN2") & "'
,LowVoltPIN3='" & Session("UpdateLowVoltPIN3") & "'
,LowVoltPIN4='" & Session("UpdateLowVoltPIN4") & "'
,LowVoltPIN5='" & Session("UpdateLowVoltPIN5") & "'
,LowVoltPIN6='" & Session("UpdateLowVoltPIN6") & "'
,MeasurePIN1='" & Session("UpdateMeasurePIN1") & "'
,MeasurePIN2='" & Session("UpdateMeasurePIN2") & "'
,MeasurePIN3='" & Session("UpdateMeasurePIN3") & "'
,MeasurePIN4='" & Session("UpdateMeasurePIN4") & "'
,MeasurePIN5='" & Session("UpdateMeasurePIN5") & "'
,MeasurePIN6='" & Session("UpdateMeasurePIN6") & "'
,Finished='" & Session("FinishedCB") & "'
WHERE No='" & Session("No") & "'"
        objCmd = New SqlCommand(strSQLUpdate, objConn)
        objCmd.ExecuteNonQuery()


        Response.Redirect("DetailNextFlow.aspx")

    End Sub
End Class