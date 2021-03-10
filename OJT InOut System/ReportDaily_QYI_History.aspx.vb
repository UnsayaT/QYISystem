Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class ReportDaily_QYI_History
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

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindData()
    End Sub

    Sub BindData()
        Dim strSQL, strSQL1, strSQL3, strSQLWeek, strSQLIN1, strSQLIN2, strSQLIN3, strSQLCOUNTWeek, strSQLWeek1, strSQLWeek2, strSQLWeek3, strSQLWeek4, strSQLWeek5, strSQLWeek6, strSQLWeek7 As String
        Dim dtCOUNTWeek, dtWeek1, dtWeek2, dtWeek3, dtWeek4, dtWeek5, dtWeek6, dtWeek7 As SqlDataAdapter
        Dim dtCOUNTWeekly, dtWeekly1, dtWeekly2, dtWeekly3, dtWeekly4, dtWeekly5, dtWeekly6, dtWeekly7 As New DataTable
        If Request.Form("txtDaily") = "" Then
            Session("Start") = Date.Today.ToString("yyyy/MM/dd") & " 10:00"
            Session("End") = Now.AddDays(+1).ToString("yyyy/MM/dd") & " 09:59:59"
            Session("StratWIP") = Date.Today.ToString("yyyy/MM/dd") & " 09:59:59"
            Session("ToDate") = Date.Today.ToString("yyyy/MM/dd")
            Session("Out1") = Now.AddDays(-1).ToString("yyyy/MM/dd") & " 10:00"
            Session("Out2") = Date.Today.ToString("yyyy/MM/dd") & " 09:59:59"

            Session("x") = Now.AddDays(-1).ToString("yyyy/MM/dd") & " 10:00"
            Session("y") = Date.Today.ToString("yyyy/MM/dd") & " 09:59:59"
            Session("z1") = Date.Today.ToString("yyyy/MM/dd") & " 10:00"
            Session("z2") = Now.AddDays(+1).ToString("yyyy/MM/dd") & " 09:59:59"


            '*** RIST Daily Low Yield Report (BELOW 80%) ***'

            '-----WIP - IN - OUT 1
            strSQLIN1 = "SELECT sum(case when (TimeIn <= '" & Session("y") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("z1") & "' and '" & Session("z2") & "' and TimeOut >='" & Session("z2") & "') then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("y") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end) + sum(case when (TimeIn Between '" & Session("z1") & "' and '" & Session("z2") & "' and (TimeOut >='" & Session("z2") & "' Or TimeOut Is NULL)) then 1 else 0 end)) - sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='Yield < 80 %'"
            'And (TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "' or TimeOut IS NULL)"
            Dim dtReaderIN1 As SqlDataReader
            objCmd = New SqlCommand(strSQLIN1, objConn)
            dtReaderIN1 = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            MyGridViewIN1.DataSource = dtReaderIN1
            MyGridViewIN1.DataBind()

            dtReaderIN1.Close()
            dtReaderIN1 = Nothing


            '-------ALL Data 
            strSQL = "SELECT QYICase.No,OldDeviceName,Process +','+TestFlow As Process,Rank,OldPackage,
CASE 
    WHEN LotNo1 IS NULL THEN LotNo
    ELSE LotNo1 END As Lot,WaferLotNo,WaferNo,TestNo,FTYield,
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
And QYICase.Mode ='Yield < 80 %' 
And (TimeOut >='" & Session("x") & "' or TimeOut IS NULL) 
And TimeIn <='" & Session("z2") & "'
order by TimeIn ASC"

            Dim dtReader As SqlDataReader
            objCmd = New SqlCommand(strSQL, objConn)
            dtReader = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            myGridView.DataSource = dtReader
            myGridView.DataBind()

            dtReader.Close()
            dtReader = Nothing




            '-----WIP - IN - OUT 2
            strSQLIN2 = "SELECT sum(case when (TimeIn <= '" & Session("y") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("z1") & "' and '" & Session("z2") & "' and (TimeOut >='" & Session("z2") & "' Or TimeOut Is NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("y") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end) + sum(case when (TimeIn Between '" & Session("z1") & "' and '" & Session("z2") & "' and (TimeOut >='" & Session("z2") & "' Or TimeOut Is NULL)) then 1 else 0 end)) - sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='LCL'"
            'And (TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "' or TimeOut IS NULL)"
            Dim dtReaderIN2 As SqlDataReader
            objCmd = New SqlCommand(strSQLIN2, objConn)
            dtReaderIN2 = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            MyGridViewIN2.DataSource = dtReaderIN2
            MyGridViewIN2.DataBind()

            dtReaderIN2.Close()
            dtReaderIN2 = Nothing

            '*** RIST Daily Low Yield Report (BELOW LCL  ABOVE 80%) ***'
            strSQL1 = "SELECT QYICase.No,OldDeviceName,Process +','+TestFlow As Process,Rank,OldPackage,
CASE 
    WHEN LotNo1 IS NULL THEN LotNo
    ELSE LotNo1 END As Lot,WaferLotNo,WaferNo,TestNo,FTYield,
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
And QYICase.Mode ='LCL' 
And (TimeOut >='" & Session("x") & "' or TimeOut IS NULL) 
And TimeIn <='" & Session("z2") & "'
order by TimeIn ASC"



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
            strSQLIN3 = "SELECT sum(case when (TimeIn <= '" & Session("y") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("z1") & "' and '" & Session("z2") & "' and (TimeOut >='" & Session("z2") & "' Or TimeOut Is NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("y") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end) + sum(case when (TimeIn Between '" & Session("z1") & "' and '" & Session("z2") & "' and (TimeOut >='" & Session("z2") & "' Or TimeOut Is NULL)) then 1 else 0 end)) - sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYIICBurn],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYIICBurn.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='BIN29,BIN30,BIN31'"
            'And (TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "' or TimeOut IS NULL)"
            Dim dtReaderIN3 As SqlDataReader
            objCmd = New SqlCommand(strSQLIN3, objConn)
            dtReaderIN3 = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            MyGridViewIN3.DataSource = dtReaderIN3
            MyGridViewIN3.DataBind()

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
And QYICase.Mode ='BIN29,BIN30,BIN31' 
And (TimeOut >='" & Session("x") & "' or TimeOut IS NULL) 
And TimeIn <='" & Session("z2") & "'
order by TimeIn ASC"


            Dim dtReader3 As SqlDataReader
            objCmd = New SqlCommand(strSQL3, objConn)
            dtReader3 = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            MyGridView3.DataSource = dtReader3
            MyGridView3.DataBind()

            dtReader3.Close()
            dtReader3 = Nothing




            '*** RIST Low Yield Weekly Report ***'
            Session("COUNTWeek1") = ""
            Session("COUNTWeek2") = ""
            Session("COUNTWeek3") = ""
            Session("COUNTWeek4") = ""
            Session("COUNTWeek5") = ""
            Session("COUNTWeek6") = ""
            Session("COUNTWeek7") = ""

            strSQLCOUNTWeek = "SELECT convert(datetime,convert(varchar(10), TimeIn, 120) + ' 00:00:00') As WeekDate
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %') and DATEPART(ww,TimeIn) = DATEPART(ww,'" & Date.Today.ToString("yyyy/MM/dd") & "')
GRoup By convert(datetime,convert(varchar(10), TimeIn, 120) + ' 00:00:00')"
            dtCOUNTWeek = New SqlDataAdapter(strSQLCOUNTWeek, objConn)
            dtCOUNTWeek.Fill(dtCOUNTWeekly)
            If dtCOUNTWeekly.Rows.Count > 0 Then

                For i = 1 To dtCOUNTWeekly.Rows.Count - 1
                    Session("COUNTWeek" & i) = dtCOUNTWeekly.Rows(i)("WeekDate")
                Next

                If Session("COUNTWeek1").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek1")).ToString("yyyy/MM/dd") & " 08:00"
                    Session("B") = Session("COUNTWeek1") & " 07:59:59"
                    Session("C") = Session("COUNTWeek1") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek1")).ToString("yyyy/MM/dd") & " 07:59:59"

                    strSQLWeek1 = "SELECT sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) + sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end)) - sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek1 = New SqlDataAdapter(strSQLWeek1, objConn)
                    dtWeek1.Fill(dtWeekly1)
                    If dtWeekly1.Rows.Count > 0 Then
                        lbldate1.Text = Session("COUNTWeek1")
                        lblWip1.Text = dtWeekly1.Rows(0)("SUMWIP")
                        lblIn1.Text = dtWeekly1.Rows(0)("SUMIN")
                        lblOut1.Text = dtWeekly1.Rows(0)("SUMOUT")
                        lblRemain1.Text = dtWeekly1.Rows(0)("SUMREMAIN")
                    End If

                End If

                If Session("COUNTWeek2").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek2")).ToString("yyyy/MM/dd") & " 08:00"
                    Session("B") = Session("COUNTWeek2") & " 07:59:59"
                    Session("C") = Session("COUNTWeek2") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek2")).ToString("yyyy/MM/dd") & " 07:59:59"

                    strSQLWeek2 = "SELECT sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) + sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end)) - sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek2 = New SqlDataAdapter(strSQLWeek2, objConn)
                    dtWeek2.Fill(dtWeekly2)
                    If dtWeekly2.Rows.Count > 0 Then
                        lbldate2.Text = Session("COUNTWeek2")
                        lblWip2.Text = dtWeekly2.Rows(0)("SUMWIP")
                        lblIn2.Text = dtWeekly2.Rows(0)("SUMIN")
                        lblOut2.Text = dtWeekly2.Rows(0)("SUMOUT")
                        lblRemain2.Text = dtWeekly2.Rows(0)("SUMREMAIN")
                    End If

                End If

                If Session("COUNTWeek3").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek3")).ToString("yyyy/MM/dd") & " 08:00"
                    Session("B") = Session("COUNTWeek3") & " 07:59:59"
                    Session("C") = Session("COUNTWeek3") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek3")).ToString("yyyy/MM/dd") & " 07:59:59"

                    strSQLWeek3 = "SELECT sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) + sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end)) - sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek3 = New SqlDataAdapter(strSQLWeek3, objConn)
                    dtWeek3.Fill(dtWeekly3)
                    If dtWeekly3.Rows.Count > 0 Then
                        lbldate3.Text = Session("COUNTWeek3")
                        lblWip3.Text = dtWeekly3.Rows(0)("SUMWIP")
                        lblIn3.Text = dtWeekly3.Rows(0)("SUMIN")
                        lblOut3.Text = dtWeekly3.Rows(0)("SUMOUT")
                        lblRemain3.Text = dtWeekly3.Rows(0)("SUMREMAIN")
                    End If

                End If

                If Session("COUNTWeek4").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek4")).ToString("yyyy/MM/dd") & " 08:00"
                    Session("B") = Session("COUNTWeek4") & " 07:59:59"
                    Session("C") = Session("COUNTWeek4") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek4")).ToString("yyyy/MM/dd") & " 07:59:59"

                    strSQLWeek4 = "SELECT sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) + sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end)) - sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek4 = New SqlDataAdapter(strSQLWeek4, objConn)
                    dtWeek4.Fill(dtWeekly4)
                    If dtWeekly4.Rows.Count > 0 Then
                        lbldate4.Text = Session("COUNTWeek4")
                        lblWip4.Text = dtWeekly4.Rows(0)("SUMWIP")
                        lblIn4.Text = dtWeekly4.Rows(0)("SUMIN")
                        lblOut4.Text = dtWeekly4.Rows(0)("SUMOUT")
                        lblRemain4.Text = dtWeekly4.Rows(0)("SUMREMAIN")
                    End If

                End If

                If Session("COUNTWeek5").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek5")).ToString("yyyy/MM/dd") & " 08:00"
                    Session("B") = Session("COUNTWeek5") & " 07:59:59"
                    Session("C") = Session("COUNTWeek5") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek5")).ToString("yyyy/MM/dd") & " 07:59:59"

                    strSQLWeek5 = "SELECT sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) + sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end)) - sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek5 = New SqlDataAdapter(strSQLWeek5, objConn)
                    dtWeek5.Fill(dtWeekly5)
                    If dtWeekly5.Rows.Count > 0 Then
                        lbldate5.Text = Session("COUNTWeek5")
                        lblWip5.Text = dtWeekly5.Rows(0)("SUMWIP")
                        lblIn5.Text = dtWeekly5.Rows(0)("SUMIN")
                        lblOut5.Text = dtWeekly5.Rows(0)("SUMOUT")
                        lblRemain5.Text = dtWeekly5.Rows(0)("SUMREMAIN")
                    End If
                End If

                If Session("COUNTWeek6").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek6")).ToString("yyyy/MM/dd") & " 08:00"
                    Session("B") = Session("COUNTWeek6") & " 07:59:59"
                    Session("C") = Session("COUNTWeek6") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek6")).ToString("yyyy/MM/dd") & " 07:59:59"

                    strSQLWeek6 = "SELECT sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) + sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end)) - sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek6 = New SqlDataAdapter(strSQLWeek6, objConn)
                    dtWeek6.Fill(dtWeekly6)
                    If dtWeekly6.Rows.Count > 0 Then
                        lbldate6.Text = Session("COUNTWeek6")
                        lblWip6.Text = dtWeekly6.Rows(0)("SUMWIP")
                        lblIn6.Text = dtWeekly6.Rows(0)("SUMIN")
                        lblOut6.Text = dtWeekly6.Rows(0)("SUMOUT")
                        lblRemain6.Text = dtWeekly6.Rows(0)("SUMREMAIN")
                    End If
                End If
                If Session("COUNTWeek7").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek7")).ToString("yyyy/MM/dd") & " 08:00"
                    Session("B") = Session("COUNTWeek7") & " 07:59:59"
                    Session("C") = Session("COUNTWeek7") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek7")).ToString("yyyy/MM/dd") & " 07:59:59"

                    strSQLWeek7 = "SELECT sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("B") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) + sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("D") & "' and (TimeOut >='" & Session("D") & "' Or TimeOut IS NULL)) then 1 else 0 end)) - sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek7 = New SqlDataAdapter(strSQLWeek7, objConn)
                    dtWeek7.Fill(dtWeekly7)
                    If dtWeekly7.Rows.Count > 0 Then
                        lbldate7.Text = Session("COUNTWeek6")
                        lblWip7.Text = dtWeekly7.Rows(0)("SUMWIP")
                        lblIn7.Text = dtWeekly7.Rows(0)("SUMIN")
                        lblOut7.Text = dtWeekly7.Rows(0)("SUMOUT")
                        lblRemain7.Text = dtWeekly7.Rows(0)("SUMREMAIN")
                    End If
                End If

            End If


        ElseIf Request.Form("txtDaily") <> "" Then

            Session("Start") = Request.Form("txtDaily")
            Session("End") = DateAdd(DateInterval.Day, 1, Session("Start")).ToString("yyyy/MM/dd")
            Session("StratWIP") = Request.Form("txtDaily")
            Session("ToDate") = Request.Form("txtDaily")

            Session("x") = DateAdd(DateInterval.Day, -1, Session("Start")).ToString("yyyy/MM/dd") & " 10:00"
            Session("y") = Request.Form("txtDaily") & " 09:59:59"
            Session("z1") = Request.Form("txtDaily") & " 10:00"
            Session("z2") = DateAdd(DateInterval.Day, +1, Session("Start")).ToString("yyyy/MM/dd") & " 09:59:59"

            Session("D1") = DateAdd(DateInterval.Day, -1, Session("Start")).ToString("yyyy/MM/dd") & " 10:00"
            Session("D2") = Request.Form("txtDaily") & " 07:59:59"
            Session("D3") = Request.Form("txtDaily") & " 08:00"
            Session("D4") = DateAdd(DateInterval.Day, +1, Session("Start")).ToString("yyyy/MM/dd") & " 09:59:59"

            'Session("x") = Now.AddDays(-1).ToString("yyyy/MM/dd") & " 10:00"
            'Session("y") = Date.Today.ToString("yyyy/MM/dd") & " 09:59:59"
            'Session("z1") = Date.Today.ToString("yyyy/MM/dd") & " 10:00"
            'Session("z2") = Now.AddDays(+1).ToString("yyyy/MM/dd") & " 09:59:59"

            '*** RIST Daily Low Yield Report (BELOW 80%) ***'
            '-----WIP - IN - OUT 1
            strSQLIN1 = "SELECT sum(case when (TimeIn <= '" & Session("D2") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("D3") & "' and '" & Session("y") & "' and ((TimeOut between '" & Session("D3") & "' and '" & Session("y") & "') Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("D2") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end)+sum(case when (TimeIn Between '" & Session("D3") & "' and '" & Session("y") & "' and ((TimeOut between '" & Session("D3") & "' and '" & Session("y") & "') Or TimeOut IS NULL)) then 1 else 0 end)-sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end)) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='Yield < 80 %'"
            Dim dtReaderIN1 As SqlDataReader
            objCmd = New SqlCommand(strSQLIN1, objConn)
            dtReaderIN1 = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            MyGridViewIN1.DataSource = dtReaderIN1
            MyGridViewIN1.DataBind()

            dtReaderIN1.Close()
            dtReaderIN1 = Nothing
            '-------ALL Data 

            strSQL = "SELECT QYICase.No,OldDeviceName,Process +','+TestFlow As Process,Rank,OldPackage,
CASE 
    WHEN LotNo1 IS NULL THEN LotNo
    ELSE LotNo1 END As Lot,
WaferLotNo,WaferNo,TestNo,FTYield,
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
And QYICase.Mode ='Yield < 80 %' 
And ((TimeOut between '" & Session("x") & "' and '" & Session("y") & "') or TimeOut IS NULL) 
And TimeIn <='" & Session("y") & "'
order by TimeIn ASC"
            'And TimeIn <='" & Session("z2") & "'
            'And (TimeOut between '" & Session("x") & "' and '" & Session("y") & "' Or TimeOut IS NULL)
            'order by TimeIn ASC"


            Dim dtReader As SqlDataReader
            objCmd = New SqlCommand(strSQL, objConn)
            dtReader = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            myGridView.DataSource = dtReader
            myGridView.DataBind()

            dtReader.Close()
            dtReader = Nothing




            '-----WIP - IN - OUT 2
            strSQLIN2 = "SELECT sum(case when (TimeIn <= '" & Session("D2") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("D3") & "' and '" & Session("y") & "' and ((TimeOut between '" & Session("D3") & "' and '" & Session("y") & "') Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("D2") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end)+sum(case when (TimeIn Between '" & Session("D3") & "' and '" & Session("y") & "' and ((TimeOut between '" & Session("D3") & "' and '" & Session("y") & "') Or TimeOut IS NULL)) then 1 else 0 end)-sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end)) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='LCL'"
            'And (TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "' or TimeOut IS NULL)"
            Dim dtReaderIN2 As SqlDataReader
            objCmd = New SqlCommand(strSQLIN2, objConn)
            dtReaderIN2 = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            MyGridViewIN2.DataSource = dtReaderIN2
            MyGridViewIN2.DataBind()

            dtReaderIN2.Close()
            dtReaderIN2 = Nothing

            '*** RIST Daily Low Yield Report (BELOW LCL  ABOVE 80%) ***'
            strSQL1 = "SELECT QYICase.No,OldDeviceName,Process +','+TestFlow As Process,Rank,OldPackage,
CASE 
    WHEN LotNo1 IS NULL THEN LotNo
    ELSE LotNo1 END As Lot,
WaferLotNo,WaferNo,TestNo,FTYield,
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
And QYICase.Mode ='LCL'
And ((TimeOut between '" & Session("x") & "' and '" & Session("y") & "') or TimeOut IS NULL) 
And TimeIn <='" & Session("y") & "'
order by TimeIn ASC"

            'And TimeIn <='" & Session("z2") & "'
            'And (TimeOut between '" & Session("x") & "' and '" & Session("y") & "' Or TimeOut IS NULL)
            'order by TimeIn ASC"
            ''and (TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "' and TimeOut IS NULL) "


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
            strSQLIN3 = "SELECT sum(case when (TimeIn <= '" & Session("D2") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("D3") & "' and '" & Session("y") & "' and ((TimeOut between '" & Session("D3") & "' and '" & Session("y") & "') Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("D2") & "' and (TimeOut between '" & Session("x") & "' And '" & Session("y") & "' or TimeOut IS NULL)) then 1 else 0 end)+sum(case when (TimeIn Between '" & Session("D3") & "' and '" & Session("y") & "' and ((TimeOut between '" & Session("D3") & "' and '" & Session("y") & "') Or TimeOut IS NULL)) then 1 else 0 end)-sum(case when (TimeOut Between '" & Session("x") & "' and '" & Session("y") & "') then 1 else 0 end)) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYIICBurn],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYIICBurn.No And QYICase.UserIDIn=MyUser.ID
And QYICase.Mode ='BIN29,BIN30,BIN31'"
            'And (TimeIn Between '" & Session("Start") & "' and '" & Session("End") & "' or TimeOut IS NULL)"
            Dim dtReaderIN3 As SqlDataReader
            objCmd = New SqlCommand(strSQLIN3, objConn)
            dtReaderIN3 = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            MyGridViewIN3.DataSource = dtReaderIN3
            MyGridViewIN3.DataBind()

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
And QYICase.Mode ='BIN29,BIN30,BIN31'
And ((TimeOut between '" & Session("x") & "' and '" & Session("y") & "') or TimeOut IS NULL) 
And TimeIn <='" & Session("y") & "'
order by TimeIn ASC"

            'And TimeIn <='" & Session("z2") & "'
            'And (TimeOut between '" & Session("x") & "' and '" & Session("y") & "' Or TimeOut IS NULL)
            'order by TimeIn ASC"


            Dim dtReader3 As SqlDataReader
            objCmd = New SqlCommand(strSQL3, objConn)
            dtReader3 = objCmd.ExecuteReader()

            '*** BindData to Repeater ***'
            MyGridView3.DataSource = dtReader3
            MyGridView3.DataBind()

            dtReader3.Close()
            dtReader3 = Nothing


            '*** RIST Low Yield Weekly Report ***'
            Session("COUNTWeek1") = ""
            Session("COUNTWeek2") = ""
            Session("COUNTWeek3") = ""
            Session("COUNTWeek4") = ""
            Session("COUNTWeek5") = ""
            Session("COUNTWeek6") = ""
            Session("COUNTWeek7") = ""

            strSQLCOUNTWeek = "SELECT convert(datetime,convert(varchar(10), TimeIn, 120) + ' 00:00:00') As WeekDate
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %') and DATEPART(ww,TimeIn) = DATEPART(ww,'" & Request.Form("txtDaily") & "')
GRoup By convert(datetime,convert(varchar(10), TimeIn, 120) + ' 00:00:00')"
            dtCOUNTWeek = New SqlDataAdapter(strSQLCOUNTWeek, objConn)
            dtCOUNTWeek.Fill(dtCOUNTWeekly)
            If dtCOUNTWeekly.Rows.Count > 0 Then

                For i = 1 To dtCOUNTWeekly.Rows.Count - 1
                    Session("COUNTWeek" & i) = dtCOUNTWeekly.Rows(i)("WeekDate")
                Next

                If Session("COUNTWeek1").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek1")).ToString("yyyy/MM/dd") & " 10:00"
                    Session("B") = Session("COUNTWeek1") & " 09:59:59"
                    Session("C") = Session("COUNTWeek1") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek1")).ToString("yyyy/MM/dd") & " 09:59:59"
                    Session("E") = Session("COUNTWeek1") & " 07:59:59"

                    strSQLWeek1 = "SELECT sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end)+sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end)-sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end)) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek1 = New SqlDataAdapter(strSQLWeek1, objConn)
                    dtWeek1.Fill(dtWeekly1)
                    If dtWeekly1.Rows.Count > 0 Then
                        lbldate1.Text = Session("COUNTWeek1")
                        lblWip1.Text = dtWeekly1.Rows(0)("SUMWIP")
                        lblIn1.Text = dtWeekly1.Rows(0)("SUMIN")
                        lblOut1.Text = dtWeekly1.Rows(0)("SUMOUT")
                        lblRemain1.Text = dtWeekly1.Rows(0)("SUMREMAIN")
                    End If

                End If

                If Session("COUNTWeek2").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek2")).ToString("yyyy/MM/dd") & " 10:00"
                    Session("B") = Session("COUNTWeek2") & " 09:59:59"
                    Session("C") = Session("COUNTWeek2") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek2")).ToString("yyyy/MM/dd") & " 09:59:59"
                    Session("E") = Session("COUNTWeek2") & " 07:59:59"

                    strSQLWeek2 = "SELECT sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end)+sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end)-sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end)) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek2 = New SqlDataAdapter(strSQLWeek2, objConn)
                    dtWeek2.Fill(dtWeekly2)
                    If dtWeekly2.Rows.Count > 0 Then
                        lbldate2.Text = Session("COUNTWeek2")
                        lblWip2.Text = dtWeekly2.Rows(0)("SUMWIP")
                        lblIn2.Text = dtWeekly2.Rows(0)("SUMIN")
                        lblOut2.Text = dtWeekly2.Rows(0)("SUMOUT")
                        lblRemain2.Text = dtWeekly2.Rows(0)("SUMREMAIN")
                    End If

                End If

                If Session("COUNTWeek3").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek3")).ToString("yyyy/MM/dd") & " 10:00"
                    Session("B") = Session("COUNTWeek3") & " 09:59:59"
                    Session("C") = Session("COUNTWeek3") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek3")).ToString("yyyy/MM/dd") & " 09:59:59"
                    Session("E") = Session("COUNTWeek3") & " 07:59:59"


                    strSQLWeek3 = "SELECT sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end)+sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end)-sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end)) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek3 = New SqlDataAdapter(strSQLWeek3, objConn)
                    dtWeek3.Fill(dtWeekly3)
                    If dtWeekly3.Rows.Count > 0 Then
                        lbldate3.Text = Session("COUNTWeek3")
                        lblWip3.Text = dtWeekly3.Rows(0)("SUMWIP")
                        lblIn3.Text = dtWeekly3.Rows(0)("SUMIN")
                        lblOut3.Text = dtWeekly3.Rows(0)("SUMOUT")
                        lblRemain3.Text = dtWeekly3.Rows(0)("SUMREMAIN")
                    End If

                End If

                If Session("COUNTWeek4").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek4")).ToString("yyyy/MM/dd") & " 10:00"
                    Session("B") = Session("COUNTWeek4") & " 09:59:59"
                    Session("C") = Session("COUNTWeek4") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek4")).ToString("yyyy/MM/dd") & " 09:59:59"
                    Session("E") = Session("COUNTWeek4") & " 07:59:59"

                    strSQLWeek4 = "SELECT sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end)+sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end)-sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end)) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek4 = New SqlDataAdapter(strSQLWeek4, objConn)
                    dtWeek4.Fill(dtWeekly4)
                    If dtWeekly4.Rows.Count > 0 Then
                        lbldate4.Text = Session("COUNTWeek4")
                        lblWip4.Text = dtWeekly4.Rows(0)("SUMWIP")
                        lblIn4.Text = dtWeekly4.Rows(0)("SUMIN")
                        lblOut4.Text = dtWeekly4.Rows(0)("SUMOUT")
                        lblRemain4.Text = dtWeekly4.Rows(0)("SUMREMAIN")
                    End If

                End If

                If Session("COUNTWeek5").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek5")).ToString("yyyy/MM/dd") & " 10:00"
                    Session("B") = Session("COUNTWeek5") & " 09:59:59"
                    Session("C") = Session("COUNTWeek5") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek5")).ToString("yyyy/MM/dd") & " 09:59:59"
                    Session("E") = Session("COUNTWeek5") & " 07:59:59"

                    strSQLWeek5 = "SELECT sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end)+sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end)-sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end)) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek5 = New SqlDataAdapter(strSQLWeek5, objConn)
                    dtWeek5.Fill(dtWeekly5)
                    If dtWeekly5.Rows.Count > 0 Then
                        lbldate5.Text = Session("COUNTWeek5")
                        lblWip5.Text = dtWeekly5.Rows(0)("SUMWIP")
                        lblIn5.Text = dtWeekly5.Rows(0)("SUMIN")
                        lblOut5.Text = dtWeekly5.Rows(0)("SUMOUT")
                        lblRemain5.Text = dtWeekly5.Rows(0)("SUMREMAIN")
                    End If
                End If

                If Session("COUNTWeek6").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek6")).ToString("yyyy/MM/dd") & " 10:00"
                    Session("B") = Session("COUNTWeek6") & " 09:59:59"
                    Session("C") = Session("COUNTWeek6") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek6")).ToString("yyyy/MM/dd") & " 09:59:59"
                    Session("E") = Session("COUNTWeek6") & " 07:59:59"

                    strSQLWeek6 = "SELECT sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end)+sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end)-sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end)) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek6 = New SqlDataAdapter(strSQLWeek6, objConn)
                    dtWeek6.Fill(dtWeekly6)
                    If dtWeekly6.Rows.Count > 0 Then
                        lbldate6.Text = Session("COUNTWeek6")
                        lblWip6.Text = dtWeekly6.Rows(0)("SUMWIP")
                        lblIn6.Text = dtWeekly6.Rows(0)("SUMIN")
                        lblOut6.Text = dtWeekly6.Rows(0)("SUMOUT")
                        lblRemain6.Text = dtWeekly6.Rows(0)("SUMREMAIN")
                    End If
                End If
                If Session("COUNTWeek7").ToString().Trim() <> "" Then
                    Session("A") = DateAdd(DateInterval.Day, -1, Session("COUNTWeek7")).ToString("yyyy/MM/dd") & " 10:00"
                    Session("B") = Session("COUNTWeek7") & " 09:59:59"
                    Session("C") = Session("COUNTWeek7") & " 08:00"
                    Session("D") = DateAdd(DateInterval.Day, +1, Session("COUNTWeek7")).ToString("yyyy/MM/dd") & " 09:59:59"
                    Session("E") = Session("COUNTWeek7") & " 07:59:59"

                    strSQLWeek7 = "SELECT sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end) SUMWIP,
sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end) SUMIN,
sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end) SUMOUT,
(sum(case when (TimeIn <= '" & Session("E") & "' and (TimeOut between '" & Session("A") & "' And '" & Session("B") & "' or TimeOut IS NULL)) then 1 else 0 end)+sum(case when (TimeIn Between '" & Session("C") & "' and '" & Session("B") & "' and ((TimeOut BetWeen '" & Session("C") & "' And '" & Session("B") & "') Or TimeOut IS NULL)) then 1 else 0 end)-sum(case when (TimeOut Between '" & Session("A") & "' and '" & Session("B") & "') then 1 else 0 end)) As SUMREMAIN
FROM [DBx].[QYI].[QYICase],[DBx].[QYI].[QYILowYield],[DBx].[dbo].[MyUser]
WHERE  QYICase.No= QYILowYield.No And QYICase.UserIDIn=MyUser.ID
And (QYICase.Mode ='LCL'  Or QYICase.Mode ='Yield < 80 %')"
                    dtWeek7 = New SqlDataAdapter(strSQLWeek7, objConn)
                    dtWeek7.Fill(dtWeekly7)
                    If dtWeekly7.Rows.Count > 0 Then
                        lbldate7.Text = Session("COUNTWeek7")
                        lblWip7.Text = dtWeekly7.Rows(0)("SUMWIP")
                        lblIn7.Text = dtWeekly7.Rows(0)("SUMIN")
                        lblOut7.Text = dtWeekly7.Rows(0)("SUMOUT")
                        lblRemain7.Text = dtWeekly7.Rows(0)("SUMREMAIN")
                    End If
                End If

            End If

        End If
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

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=DataDailyReport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages
            myGridView.AllowPaging = False
            MyGridView1.AllowPaging = False
            MyGridView3.AllowPaging = False

            '***RIST Daily Low Yield Report (BELOW 80%)

            myGridView.HeaderRow.BackColor = Color.White
            For Each cell As TableCell In myGridView.HeaderRow.Cells

                cell.BackColor = myGridView.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In myGridView.Rows
                row.BackColor = Color.White
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = myGridView.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = myGridView.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next

            divExport.RenderControl(hw)

            '***RIST Daily Low Yield Report (BELOW LCL & ABOVE 80%)
            MyGridView1.HeaderRow.BackColor = Color.White

            For Each cell As TableCell In MyGridView1.HeaderRow.Cells
                cell.BackColor = MyGridView1.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In MyGridView1.Rows
                row.BackColor = Color.White
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = MyGridView1.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = MyGridView1.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next

            'MyGridView1.RenderControl(hw)

            '***RIST Daily IC Burn Report.
            MyGridView3.HeaderRow.BackColor = Color.White

            For Each cell As TableCell In MyGridView3.HeaderRow.Cells
                cell.BackColor = MyGridView1.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In MyGridView3.Rows
                row.BackColor = Color.White
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = MyGridView3.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = MyGridView3.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next

            'MyGridView3.RenderControl(hw)

            'style to format numbers to string
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()
        End Using
    End Sub


End Class