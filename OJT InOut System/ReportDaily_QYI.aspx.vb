Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class ReportDaily_QYI
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
        Dim strSQL, strSQL1, strSQL3, strSQLWeek, strSQLIN1, strSQLIN2, strSQLIN3 As String
        Session("Start") = Date.Today.ToString("yyyy/MM/dd") & " 10:00"
        Session("End") = Now.AddDays(+1).ToString("yyyy/MM/dd") & " 09:59:59"
        Session("StratWIP") = Date.Today.ToString("yyyy/MM/dd") & " 09:59:59"
        Session("ToDate") = Date.Today.ToString("yyyy/MM/dd")
        Session("Out1") = Now.AddDays(-1).ToString("yyyy/MM/dd") & " 10:00"
        Session("Out2") = Date.Today.ToString("yyyy/MM/dd") & " 09:59:59"

        '-----WIP - IN - OUT 1
        strSQLIN1 = "SELECT sum(case when (TimeIn <= '" & Session("StratWIP") & "' and TimeOut IS NULL) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "') then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("Start") & "' and '" & Session("End") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("StratWIP") & "' and TimeOut IS NULL) then 1 else 0 end) + sum(case when TimeIn between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end)) - sum(case when TimeOut between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='Yield < 80 %'"
        'And (TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "' or TimeOut IS NULL)"
        Dim dtReaderIN1 As SqlDataReader
        objCmd = New SqlCommand(strSQLIN1, objConn)
        dtReaderIN1 = objCmd.ExecuteReader()

        '*** BindData to Repeater ***'
        'MyGridViewIN1.DataSource = dtReaderIN1
        'MyGridViewIN1.DataBind()

        dtReaderIN1.Close()
        dtReaderIN1 = Nothing



        '*** RIST Daily Low Yield Report (BELOW 80%) ***'
        '-------ALL Data 

        strSQL = "SELECT QYICase.No,OldDeviceName,Process +','+TestFlow As Process,Rank,OldPackage,LotNo1,WaferLotNo,WaferNo,TestNo,FTYield,
CONVERT(varchar(5), TimeIn,101) As FYIIN,CONVERT(varchar(5), ShipmentDate,101) As ShipDate,ShipmentDate,
FirstName,IssueNo,CONVERT(varchar(5), RKDate,101) As RKDate1,RKDate,CONVERT(varchar(5), SampleDate,101) As SampleDate1,SampleDate,SampleDesigner,InvoiceNo,  
datediff(day, ShipmentDate , GETDATE()) as ShipmentDela,
datediff(day, TimeIn , GETDATE()) as FYLDela,
CONVERT(varchar(5), PlanAnswer,101) As PlanAnswer1,PlanAnswer,CONVERT(varchar(5), ReviseShipmentDate,101) As ReviseShipmentDate1,ReviseShipmentDate,
                CASE 
	                WHEN GotoProcess   IS NULL THEN '-' 
	                ELSE GotoProcess END As NextProcess,
				CASE
	                WHEN TimeOut   IS NULL THEN '-' 
	                ELSE CONVERT(varchar(5), TimeOut,101) END As FYIOUT,
QYILowYield.Mode As RISTRemark,LotStatus As Remark,QYICase.Mode
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='Yield < 80 %' And TimeOut IS NULL order by TimeIn ASC"
        'And TimeIn <= '" & Session("End") & "' and  (Timeout Between '" & Session("Out1") & "' and '" & Session("Out2") & "' or TimeOut Is NULL) "


        Dim dtReader As SqlDataReader
        objCmd = New SqlCommand(strSQL, objConn)
        dtReader = objCmd.ExecuteReader()

        '*** BindData to Repeater ***'
        myGridView.DataSource = dtReader
        myGridView.DataBind()

        dtReader.Close()
        dtReader = Nothing


        '-----WIP - IN - OUT 2
        strSQLIN2 = "SELECT sum(case when (TimeIn <= '" & Session("StratWIP") & "' and TimeOut IS NULL) then 1 else 0 end) SUMWIP,
sum(case when TimeIn between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end) SUMIN,
sum(case when TimeOut between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("StratWIP") & "' and TimeOut IS NULL) then 1 else 0 end) + sum(case when TimeIn between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end)) - sum(case when TimeOut between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='LCL' "
        'And (TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "' or TimeOut IS NULL)"
        Dim dtReaderIN2 As SqlDataReader
        objCmd = New SqlCommand(strSQLIN2, objConn)
        dtReaderIN2 = objCmd.ExecuteReader()

        '*** BindData to Repeater ***'
        'MyGridViewIN2.DataSource = dtReaderIN2
        'MyGridViewIN2.DataBind()

        dtReaderIN2.Close()
        dtReaderIN2 = Nothing



        '*** RIST Daily Low Yield Report (BELOW LCL  ABOVE 80%) ***'
        strSQL1 = "SELECT QYICase.No,OldDeviceName,Process +','+TestFlow As Process,Rank,OldPackage,LotNo1,WaferLotNo,WaferNo,TestNo,FTYield,
CONVERT(varchar(5), TimeIn,101) As FYIIN,CONVERT(varchar(5), ShipmentDate,101) As ShipDate,ShipmentDate,
FirstName,IssueNo,CONVERT(varchar(5), RKDate,101) As RKDate1,RKDate,CONVERT(varchar(5), SampleDate,101) As SampleDate1,SampleDate,SampleDesigner,InvoiceNo,  
datediff(day, ShipmentDate , GETDATE()) as ShipmentDela,
datediff(day, TimeIn , GETDATE()) as FYLDela,
CONVERT(varchar(5), PlanAnswer,101) As PlanAnswer1,PlanAnswer,CONVERT(varchar(5), ReviseShipmentDate,101) As ReviseShipmentDate1,ReviseShipmentDate,
                CASE 
	                WHEN GotoProcess   IS NULL THEN '-' 
	                ELSE GotoProcess END As NextProcess,
				CASE
	                WHEN TimeOut   IS NULL THEN '-' 
	                ELSE CONVERT(varchar(5), TimeOut,101) END As FYIOUT,
QYILowYield.Mode As RISTRemark,LotStatus As Remark
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='LCL' And TimeOut IS NULL order by TimeIn ASC"
        'And TimeIn <= '" & Session("End") & "' and  (Timeout Between '" & Session("Out1") & "' and '" & Session("Out2") & "' or TimeOut Is NULL)  "


        Dim dtReader1 As SqlDataReader
            objCmd = New SqlCommand(strSQL1, objConn)
            dtReader1 = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            MyGridView1.DataSource = dtReader1
            MyGridView1.DataBind()

            dtReader1.Close()
            dtReader1 = Nothing


        '*** RIST Daily Low Yield Report (issued QAR,wait QC answer) ***'


        '-----WIP - IN - OUT 3
        strSQLIN3 = "SELECT sum(case when (TimeIn <= '" & Session("StratWIP") & "' and TimeOut IS NULL) then 1 else 0 end) SUMWIP,
sum(case when TimeIn between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end) SUMIN,
sum(case when TimeOut between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("StratWIP") & "' and TimeOut IS NULL) then 1 else 0 end) + sum(case when TimeIn between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end)) - sum(case when TimeOut between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYIICBurn],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYIICBurn.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='BIN29,BIN30,BIN31' "
        'And (TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "' or TimeOut IS NULL)"
        Dim dtReaderIN3 As SqlDataReader
        objCmd = New SqlCommand(strSQLIN3, objConn)
        dtReaderIN3 = objCmd.ExecuteReader()

        '*** BindData to Repeater ***'
        'MyGridViewIN3.DataSource = dtReaderIN3
        'MyGridViewIN3.DataBind()

        dtReaderIN3.Close()
        dtReaderIN3 = Nothing


        '*** RIST Daily IC Burn Report. ***'
        strSQL3 = "SELECT QYICase.No,OldDeviceName,Process +','+TestFlow As Process,Rank,OldPackage,LotNo,WaferLotNo,WaferNo,OST1,OST2,OST3,OST4,OST5,OST6,FTYield,
CONVERT(varchar(5), TimeIn,101) As FQIIN,CONVERT(varchar(5), ShipmentDate,101) As ShipDate,ShipmentDate,
FirstName,AbNo,CONVERT(varchar(5), RKDate,101) As RKDate1,RKDate,CONVERT(varchar(5), SampleDate,101) As SampleDate1,SampleDate,SampleDesigner,InvoiceNo,  
datediff(day, ShipmentDate , GETDATE()) as ShipmentDela,
datediff(day, TimeIn , GETDATE()) as FQLDela,
CONVERT(varchar(5), PlanAnswer,101) As PlanAnswer1,PlanAnswer,CONVERT(varchar(5), ReviseShipmentDate,101) As ReviseShipmentDate1,ReviseShipmentDate,
                CASE 
	                WHEN GotoProcess   IS NULL THEN '-' 
	                ELSE GotoProcess END As NextProcess,
				CASE
	                WHEN TimeOut   IS NULL THEN '-' 
	                ELSE CONVERT(varchar(5), TimeOut,101) END As FQIOUT,
CONVERT(varchar(5), AQIToQC,101) As AQIToQC1,AQIToQC,LotStatus As Remark
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYIICBurn],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYIICBurn.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='BIN29,BIN30,BIN31' And TimeOut IS NULL order by TimeIn ASC"
            'And TimeIn <= '" & Session("End") & "' and  (Timeout Between '" & Session("Out1") & "' and '" & Session("Out2") & "' or TimeOut Is NULL) "


            Dim dtReader3 As SqlDataReader
            objCmd = New SqlCommand(strSQL3, objConn)
            dtReader3 = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            MyGridView3.DataSource = dtReader3
            MyGridView3.DataBind()

            dtReader3.Close()
            dtReader3 = Nothing



        '*** RIST Low Yield Weekly Report ***'
        strSQLWeek = "SELECT CONVERT(varchar(8), TimeIn,105) As WeekDate,
sum(case when (TimeIn <= '" & Session("StratWIP") & "' and TimeOut IS NULL) then 1 else 0 end) SUMWIP,
sum(case when TimeIn between '" & Session("Start") & "' and '" & Session("End") & "'  then 1 else 0 end) SUMIN,
sum(case when TimeOut between '" & Session("Start") & "' and '" & Session("End") & "' then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("Start") & "' and TimeOut IS NULL) then 1 else 0 end) + sum(case when TimeIn between '" & Session("Start") & "'  and '" & Session("End") & "' then 1 else 0 end)) - sum(case when TimeOut between '" & Session("Start") & "'  and '" & Session("End") & "' then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %') and DATEPART(ww,TimeIn) = DATEPART(ww,'" & Session("ToDate") & "')
GRoup By CONVERT(varchar(8), TimeIn,105)"
        Dim dtReaderWeek As SqlDataReader
        objCmd = New SqlCommand(strSQLWeek, objConn)
        dtReaderWeek = objCmd.ExecuteReader()

        '*** BindData to Repeater ***'
        'MyGridViewWeek.DataSource = dtReaderWeek
        'MyGridViewWeek.DataBind()

        dtReaderWeek.Close()
        dtReaderWeek = Nothing

    End Sub

    Sub Page_UnLoad()
        objConn.Close()
        objConn = Nothing
    End Sub

    '*** myGridView ***'
    Sub modEditCommand(sender As Object, e As GridViewEditEventArgs)
        myGridView.EditIndex = e.NewEditIndex
        myGridView.ShowFooter = False
        BindData()
    End Sub

    Sub modCancelCommand(sender As Object, e As GridViewCancelEditEventArgs)
        myGridView.EditIndex = -1
        myGridView.ShowFooter = True
        BindData()
    End Sub

    Sub modDeleteCommand(sender As Object, e As GridViewDeleteEventArgs)

    End Sub

    Sub myGridView_RowCommand(source As Object, e As GridViewCommandEventArgs)

    End Sub


    Sub modUpdateCommand(s As Object, e As GridViewUpdateEventArgs)
        Dim strSQL, strSQLQYICase As String

        '*** Device Name ***'
        Dim txtDevice As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditDevice"), TextBox)
        '*** PKG ***'
        Dim txtPKG As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditPKG"), TextBox)
        '*** WaferLotNo ***'
        Dim txtWaferLotNo As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditWaferLotNo"), TextBox)
        '*** TestNo ***'
        Dim txtTestNo As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditTestNo"), TextBox)
        '*** Yield ***'
        Dim txtYield As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditYield"), TextBox)
        '*** Rank ***'
        Dim txtRank As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditRank"), TextBox)
        '*** Wafer No ***'
        Dim txtWaferNo As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditWaferNo"), TextBox)
        '*** RKDate ***'
        Dim txtRKDate As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditRKDate"), TextBox)
        '*** SampleSentDate ***'
        Dim txtSample As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditSample"), TextBox)
        '*** SampleSantDesigner ***'
        Dim txtSampleDesigner As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditSampleDesigner"), TextBox)
        '*** Invoice No ***'
        Dim txtInv As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditInv"), TextBox)
        '*** Plan Answer ***'
        Dim txtplanAnswer As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditplanAnswer"), TextBox)
        '*** Revise Shipment Date ***'
        Dim txtRevise As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditRevise"), TextBox)
        '*** Remark ***'
        Dim txtRemark As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditRemark"), TextBox)

        strSQLQYICase = "UPDATE [DBx].[QYI].[QYICase] SET  OldDeviceName = '" & txtDevice.Text & "'" &
        " ,OldPackage = '" & txtPKG.Text & "'" &
        " ,FTYield = '" & txtYield.Text & "'" &
        "WHERE No = '" & myGridView.DataKeys.Item(e.RowIndex).Value & "'"
        objCmd = New SqlCommand(strSQLQYICase, objConn)
        objCmd.ExecuteNonQuery()

        strSQL = "UPDATE [DBx].[QYI].[QYILowYield] SET  Rank = '" & txtRank.Text & "'" &
        " ,WaferNo = '" & txtWaferNo.Text & "'" &
        " ,ShipmentDate = '" & Request.Form("txtEditShipmentDate") & "'" &
        " ,RKDate = '" & Request.Form("txtEditRKDate") & "'" &
        " ,SampleDate = '" & Request.Form("txtEditSample") & "'" &
        " ,SampleDesigner = '" & txtSampleDesigner.Text & "'" &
        " ,InvoiceNo = '" & txtInv.Text & "'" &
        " ,PlanAnswer = '" & Request.Form("txtEditplanAnswer") & "'" &
        " ,ReviseShipmentDate = '" & Request.Form("txtEditRevise") & "'" &
        " ,LotStatus = '" & txtRemark.Text & "'" &
        " ,WaferLotNo = '" & txtWaferLotNo.Text & "'" &
        " ,NGTestNo = '" & txtTestNo.Text & "'" &
        "WHERE No = '" & myGridView.DataKeys.Item(e.RowIndex).Value & "'"
        objCmd = New SqlCommand(strSQL, objConn)
        objCmd.ExecuteNonQuery()

        myGridView.EditIndex = -1
        myGridView.ShowFooter = True
        BindData()
    End Sub

    '*** myGridView1 ***'
    Sub modEditCommand1(sender As Object, e As GridViewEditEventArgs)
        MyGridView1.EditIndex = e.NewEditIndex
        MyGridView1.ShowFooter = False
        BindData()
    End Sub

    Sub modCancelCommand1(sender As Object, e As GridViewCancelEditEventArgs)
        MyGridView1.EditIndex = -1
        MyGridView1.ShowFooter = True
        BindData()
    End Sub

    Sub modDeleteCommand1(sender As Object, e As GridViewDeleteEventArgs)

    End Sub

    Sub myGridView1_RowCommand(source As Object, e As GridViewCommandEventArgs)

    End Sub


    Sub modUpdateCommand1(s As Object, e As GridViewUpdateEventArgs)
        Dim strSQLMyGridView1, strSQLQYICase1 As String

        '*** Device Name ***'
        Dim txtDevice As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditDevice1"), TextBox)
        '*** PKG ***'
        Dim txtPKG As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditPKG1"), TextBox)
        '*** WaferLotNo ***'
        Dim txtWaferLotNo As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditWaferLotNo1"), TextBox)
        '*** TestNo ***'
        Dim txtTestNo As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditTestNo1"), TextBox)
        '*** Yield ***'
        Dim txtYield As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditYield1"), TextBox)
        '*** Rank ***'
        Dim txtRank As TextBox = CType(MyGridView1.Rows(e.RowIndex).FindControl("txtEditRank1"), TextBox)
        '*** Wafer No ***'
        Dim txtWaferNo As TextBox = CType(MyGridView1.Rows(e.RowIndex).FindControl("txtEditWaferNo1"), TextBox)
        '*** Shipment Date ***'
        Dim txtShipmentDate As TextBox = CType(MyGridView1.Rows(e.RowIndex).FindControl(Request.Form("txtEditShipmentDate1")), TextBox)
        '*** RKDate ***'
        Dim txtRKDate As TextBox = CType(MyGridView1.Rows(e.RowIndex).FindControl("txtEditRKDate1"), TextBox)
        '*** SampleSentDate ***'
        Dim txtSample As TextBox = CType(MyGridView1.Rows(e.RowIndex).FindControl("txtEditSample1"), TextBox)
        '*** SampleSantDesigner ***'
        Dim txtSampleDesigner As TextBox = CType(MyGridView1.Rows(e.RowIndex).FindControl("txtEditSampleDesigner1"), TextBox)
        '*** Invoice No ***'
        Dim txtInv As TextBox = CType(MyGridView1.Rows(e.RowIndex).FindControl("txtEditInv1"), TextBox)
        '*** Plan Answer ***'
        Dim txtplanAnswer As TextBox = CType(MyGridView1.Rows(e.RowIndex).FindControl("txtEditplanAnswer1"), TextBox)
        '*** Revise Shipment Date ***'
        Dim txtRevise As TextBox = CType(MyGridView1.Rows(e.RowIndex).FindControl("txtEditRevise1"), TextBox)
        '*** Remark ***'
        Dim txtRemark As TextBox = CType(MyGridView1.Rows(e.RowIndex).FindControl("txtEditRemark1"), TextBox)

        strSQLQYICase1 = "UPDATE [DBx].[QYI].[QYICase] SET  OldDeviceName = '" & txtDevice.Text & "'" &
        " ,OldPackage = '" & txtPKG.Text & "'" &
        " ,FTYield = '" & txtYield.Text & "'" &
        "WHERE No = '" & myGridView.DataKeys.Item(e.RowIndex).Value & "'"
        objCmd = New SqlCommand(strSQLQYICase1, objConn)
        objCmd.ExecuteNonQuery()

        strSQLMyGridView1 = "UPDATE [DBx].[QYI].[QYILowYield] SET  Rank = '" & txtRank.Text & "'" &
        " ,WaferNo = '" & txtWaferNo.Text & "'" &
        " ,ShipmentDate = '" & Request.Form("txtEditShipmentDate") & "'" &
        " ,RKDate = '" & Request.Form("txtEditRKDate") & "'" &
        " ,SampleDate = '" & Request.Form("txtEditSample") & "'" &
        " ,SampleDesigner = '" & txtSampleDesigner.Text & "'" &
        " ,InvoiceNo = '" & txtInv.Text & "'" &
        " ,PlanAnswer = '" & Request.Form("txtEditplanAnswer") & "'" &
        " ,ReviseShipmentDate = '" & Request.Form("txtEditRevise") & "'" &
        " ,LotStatus = '" & txtRemark.Text & "'" &
        " ,WaferLotNo = '" & txtWaferLotNo.Text & "'" &
        " ,NGTestNo = '" & txtTestNo.Text & "'" &
        "WHERE No = '" & myGridView.DataKeys.Item(e.RowIndex).Value & "'"
        objCmd = New SqlCommand(strSQLMyGridView1, objConn)
        objCmd.ExecuteNonQuery()


        MyGridView1.EditIndex = -1
        MyGridView1.ShowFooter = True
        BindData()
    End Sub

    '*** myGridView3 ***'
    Sub modEditCommand3(sender As Object, e As GridViewEditEventArgs)
        MyGridView3.EditIndex = e.NewEditIndex
        MyGridView3.ShowFooter = False
        BindData()
    End Sub

    Sub modCancelCommand3(sender As Object, e As GridViewCancelEditEventArgs)
        MyGridView3.EditIndex = -1
        MyGridView3.ShowFooter = True
        BindData()
    End Sub

    Sub modDeleteCommand3(sender As Object, e As GridViewDeleteEventArgs)

    End Sub

    Protected Sub MyGridView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MyGridView3.SelectedIndexChanged

    End Sub

    Sub myGridView3_RowCommand(source As Object, e As GridViewCommandEventArgs)

    End Sub

    Sub modUpdateCommand3(s As Object, e As GridViewUpdateEventArgs)
        Dim strSQLMyGridView3, strSQLQYICase3 As String

        '*** Device Name ***'
        Dim txtDevice As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditDevice3"), TextBox)
        '*** PKG ***'
        Dim txtPKG As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditPKG3"), TextBox)
        '*** WaferLotNo ***'
        Dim txtWaferLotNo As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditWaferLotNo3"), TextBox)
        '*** TestNo ***'
        Dim txtTestNo As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditTestNo3"), TextBox)
        '*** Yield ***'
        Dim txtYield As TextBox = CType(myGridView.Rows(e.RowIndex).FindControl("txtEditYield3"), TextBox)
        '*** Rank ***'
        Dim txtRank As TextBox = CType(MyGridView3.Rows(e.RowIndex).FindControl("txtEditRank3"), TextBox)
        '*** Wafer No ***'
        Dim txtWaferNo As TextBox = CType(MyGridView3.Rows(e.RowIndex).FindControl("txtEditWaferNo3"), TextBox)
        '*** Shipment Date ***'
        Dim txtShipmentDate As TextBox = CType(MyGridView3.Rows(e.RowIndex).FindControl(Request.Form("txtEditShipmentDate3")), TextBox)
        '*** RKDate ***'
        Dim txtRKDate As TextBox = CType(MyGridView3.Rows(e.RowIndex).FindControl("txtEditRKDate3"), TextBox)
        '*** SampleSentDate ***'
        Dim txtSample As TextBox = CType(MyGridView3.Rows(e.RowIndex).FindControl("txtEditSample3"), TextBox)
        '*** SampleSantDesigner ***'
        Dim txtSampleDesigner As TextBox = CType(MyGridView3.Rows(e.RowIndex).FindControl("txtEditSampleDesigner3"), TextBox)
        '*** Invoice No ***'
        Dim txtInv As TextBox = CType(MyGridView3.Rows(e.RowIndex).FindControl("txtEditInv3"), TextBox)
        '*** Plan Answer ***'
        Dim txtplanAnswer As TextBox = CType(MyGridView3.Rows(e.RowIndex).FindControl("txtEditplanAnswer3"), TextBox)
        '*** Revise Shipment Date ***'
        Dim txtRevise As TextBox = CType(MyGridView3.Rows(e.RowIndex).FindControl("txtEditRevise3"), TextBox)
        '*** Remark ***'
        Dim txtRemark As TextBox = CType(MyGridView3.Rows(e.RowIndex).FindControl("txtEditRemark3"), TextBox)

        strSQLQYICase3 = "UPDATE [DBx].[QYI].[QYICase] SET  OldDeviceName = '" & txtDevice.Text & "'" &
        " ,OldPackage = '" & txtPKG.Text & "'" &
        " ,FTYield = '" & txtYield.Text & "'" &
        "WHERE No = '" & myGridView.DataKeys.Item(e.RowIndex).Value & "'"
        objCmd = New SqlCommand(strSQLQYICase3, objConn)
        objCmd.ExecuteNonQuery()

        strSQLMyGridView3 = "UPDATE [DBx].[QYI].[QYIICBurn] SET  Rank = '" & txtRank.Text & "' " &
        " ,WaferNo = '" & txtWaferNo.Text & "' " &
        " ,ShipmentDate = '" & Request.Form("txtEditShipmentDate3") & "' " &
        " ,RKDate = '" & Request.Form("txtEditRKDate3") & "' " &
        " ,SampleDate = '" & Request.Form("txtEditSample3") & "' " &
        " ,SampleDesigner = '" & txtSampleDesigner.Text & "' " &
        " ,InvoiceNo = '" & txtInv.Text & "' " &
        " ,PlanAnswer = '" & Request.Form("txtEditplanAnswer3") & "' " &
        " ,ReviseShipmentDate = '" & Request.Form("txtEditRevise3") & "' " &
        " ,AQIToQC = '" & Request.Form("txtEditAQIToQC3") & "' " &
        " ,WaferLotNo = '" & txtWaferLotNo.Text & "'" &
        "WHERE No = '" & MyGridView3.DataKeys.Item(e.RowIndex).Value & "'"
        objCmd = New SqlCommand(strSQLMyGridView3, objConn)
        objCmd.ExecuteNonQuery()

        MyGridView3.EditIndex = -1
        MyGridView3.ShowFooter = True
        BindData()
    End Sub



    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered 
    End Sub


End Class