Imports System.Data.SqlClient
Public Class DetailIssueNo
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

        Lottxt1.Text = Session("LotAll")

        'ถ้าเป็นวันเดียวกับที่คีย์ข้อมูลจะ ใช้ Issue No เดิม
        If Session("CheckIssueDateold") = Date.Today Then
            Dim myDate As Date = Date.Now
            Dim myYear As Int32 = myDate.Year
            Session("InsertYear") = "RIST" & "-" & myYear
            Session("InsertIssueNo") = Session("CheckIssueNoold")
            Label1.Text = "Issue No. " & Session("CheckIssueNoold")
        Else
            'ถ้าไม่ใช่วันเดียวกับที่คีย์ข้อมูลจะ ใช้ Issue No ใหม่
            Dim nextissueno As String
            Dim cheakyear As String
            Dim countnext As Integer
            Dim countnext2 As String
            Dim myDate As Date = Date.Now
            Dim myYear As Int32 = myDate.Year
            Session("InsertYear") = "RIST" & "-" & myYear
            Session("InsertIssueNo") = "RIST" & "-" & myYear & "-" & "0001"
            Label1.Text = "Issue No. " & Session("InsertIssueNo")

            strSQLCheck = "
                SELECT      TOP (1) IssueNo
                FROM        [DBx].[QYI].QYILowYield
                WHERE       (IssueNo <> 'TEMPORARY')
                ORDER       BY IssueNo DESC"
            dtAdapterCheck = New SqlDataAdapter(strSQLCheck, objConn)
            dtAdapterCheck.Fill(dtCheck)
            If dtCheck.Rows.Count > 0 Then
                nextissueno = dtCheck.Rows(0)("IssueNo")
                cheakyear = nextissueno
                cheakyear = Mid(cheakyear, 6, 4)
                'เช็คปี ถ้าปีเดียวกันจะเป็น Issue No ต่อไป
                If myYear = cheakyear Then
                    nextissueno = Mid(nextissueno, 11, 5)
                    countnext = nextissueno.Trim()
                    countnext = countnext + 1

                    countnext2 = String.Format("{0,4:D4}", countnext)
                    Session("InsertIssueNo") = "RIST" & "-" & myYear & "-" & countnext2
                    Label1.Text = "Issue No. " & Session("InsertIssueNo")

                Else
                    'ถ้าไม่ใช่ปีเดียวกันจะเป็น Issue No ขึ้นปีใหม่
                    Session("InsertIssueNo") = "RIST" & "-" & myYear & "-" & "0001"
                    Label1.Text = "Issue No. " & Session("InsertIssueNo")
                End If
            End If
        End If
    End Sub

    'ปุ่ม NewIssueNo 
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nextissueno As String
        Dim cheakyear As String
        Dim countnext As Integer
        Dim countnext2 As String
        Dim myDate As Date = Date.Now
        Dim myYear As Int32 = myDate.Year
        Session("InsertYear") = "RIST" & "-" & myYear
        Label1.Text = "RIST" & "-" & myYear & "-" & "0001"
        Session("InsertIssueNo") = Label1.Text
        'กรณีที่เกิด เคสใหม่ในคนเดียวกันจะทำการ Issue No ใหม่
        Using connObj As New SqlClient.SqlConnection("Server=172.16.0.102;Database=DBx;User=QYIUser;")
            Using cmdObj As New SqlClient.SqlCommand("
                SELECT      TOP (1) IssueNo
                FROM        QYILowYield
                WHERE       (IssueNo <> 'TEMPORARY')
                ORDER       BY IssueNo DESC", connObj)
                connObj.Open()
                Using readerObj As SqlClient.SqlDataReader = cmdObj.ExecuteReader
                    While readerObj.Read
                        nextissueno = readerObj("IssueNo").ToString
                        cheakyear = nextissueno
                        cheakyear = Mid(cheakyear, 6, 4)

                        If myYear = cheakyear Then
                            nextissueno = Mid(nextissueno, 11, 5)
                            countnext = nextissueno.Trim()
                            countnext = countnext + 1

                            countnext2 = String.Format("{0,4:D4}", countnext)
                            Session("InsertIssueNo") = "RIST" & "-" & myYear & "-" & countnext2
                            Label1.Text = "Issue No. " & Session("InsertIssueNo")
                        Else
                            Session("InsertIssueNo") = "RIST" & "-" & myYear & "-" & "0001"
                            Label1.Text = "Issue No. " & Session("InsertIssueNo")
                            TextBox1.Text = Label1.Text
                        End If
                    End While
                End Using
                connObj.Close()
            End Using
        End Using
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Enabled = True
        Session("InsertIssueNo") = TextBox1.Text
    End Sub

    Protected Sub InputButton_Click(sender As Object, e As EventArgs) Handles InputButton.Click
        Dim strSQLCheckNo1, strSQLCheckNo2, strSQLCheckNo3, strSQLCheckNo4, strSQLCheckNo5, strSQLCheckNo6, strSQLCheckNo7, strSQLCheckNo8, strSQLCheckNo9, strSQLCheckNo10, strSQLCheckNo11, strSQLCheckNo12, strSQLCheckNo13, strSQLCheckNo14, strSQLCheckNo15, strSQLCheckNo16, strSQLCheckIssue As String
        Dim dtAdapterCheckNo1, dtAdapterCheckNo2, dtAdapterCheckNo3, dtAdapterCheckNo4, dtAdapterCheckNo5, dtAdapterCheckNo6, dtAdapterCheckNo7, dtAdapterCheckNo8, dtAdapterCheckNo9, dtAdapterCheckNo10, dtAdapterCheckNo11, dtAdapterCheckNo12, dtAdapterCheckNo13, dtAdapterCheckNo14, dtAdapterCheckNo15, dtAdapterCheckNo16, dtAdapterCheckIssue As SqlDataAdapter
        Dim dtCheckNo1, dtCheckNo2, dtCheckNo3, dtCheckNo4, dtCheckNo5, dtCheckNo6, dtCheckNo7, dtCheckNo8, dtCheckNo9, dtCheckNo10, dtCheckNo11, dtCheckNo12, dtCheckNo13, dtCheckNo14, dtCheckNo15, dtCheckNo16, dtCheckIssue As New DataTable
        Dim strSQLUpdate As String
        Dim myDate As Date = Date.Now
        Dim myYear As Int32 = myDate.Year
        Session("InsertYear") = "RIST" & "-" & myYear


        If TextBox1.Text <> "" Then
            strSQLCheckIssue = "
                        SELECT      IssueNo
                        FROM        [DBx].[QYI].[QYILowYield]
                        WHERE       IssueNo LIKE '%" & TextBox1.Text & "%'"
            dtAdapterCheckIssue = New SqlDataAdapter(strSQLCheckIssue, objConn)
            dtAdapterCheckIssue.Fill(dtCheckIssue)
            If dtCheckIssue.Rows.Count > 0 Then
                Session("MSGError") = "No"
                Page.RegisterClientScriptBlock("OnLoad", "<script>alert('Issuue No นี้มีถูกใช้ไปแล้ว กรุณากรอก Issue No ใหม่')</script>")
            Else
                Session("MSGError") = "Pass"
                Session("InsertIssueNo") = TextBox1.Text
            End If
        Else
            Session("InsertIssueNo") = Mid(Label1.Text, 11, 14)
            Session("MSGError") = "Pass"
        End If

        Dim thisDay As Date = Date.Now
        Session("InsertIssueDate") = thisDay

        Dim kb As Date
        kb = Date.Now.AddDays(180)
        Session("InsertKanban") = kb

        If DropDownList1.Text = "New Mode" Then
            Session("InsertMode") = "New Mode"
        Else
            Session("InsertMode") = "Same Mode"
            Session("SameModeNo") = txtModel1.Text

        End If

        Session("InsertNgtNo") = NgtNoT.Text
        Session("InsertNgtNo2") = txtNGTestNo2.Text
        Session("InsertNgtNo3") = txtNGTestNo3.Text
        Session("InsertNgtNo4") = txtNGTestNo4.Text
        Session("InsertNgtNo5") = txtNGTestNo5.Text
        Session("InsertNgtNo6") = txtNGTestNo6.Text

        Session("InsertNgtDate") = NgtDateT.Text
        Session("InsertNgtDate2") = txtNGData2.Text
        Session("InsertNgtDate3") = txtNGData3.Text
        Session("InsertNgtDate4") = txtNGData4.Text
        Session("InsertNgtDate5") = txtNGData5.Text
        Session("InsertNgtDate6") = txtNGData6.Text


        If Session("MSGError") = "No" Then

        ElseIf Session("MSGError") = "Pass" Then

            'LotNo 1 - LotNo5 (เฉพาะLotNo แรก)
            If Lottxt1.Text <> "" Then

                strSQLCheckNo1 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt1.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo1 = New SqlDataAdapter(strSQLCheckNo1, objConn)
                dtAdapterCheckNo1.Fill(dtCheckNo1)
                If dtCheckNo1.Rows.Count > 0 Then
                    Session("No1") = dtCheckNo1.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "',NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "',NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No1") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt2.Text <> "" Then
                strSQLCheckNo2 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt2.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo2 = New SqlDataAdapter(strSQLCheckNo2, objConn)
                dtAdapterCheckNo2.Fill(dtCheckNo2)
                If dtCheckNo2.Rows.Count > 0 Then
                    Session("No2") = dtCheckNo2.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No2") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt3.Text <> "" Then
                strSQLCheckNo3 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt3.Text & "'  and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo3 = New SqlDataAdapter(strSQLCheckNo3, objConn)
                dtAdapterCheckNo3.Fill(dtCheckNo3)
                If dtCheckNo3.Rows.Count > 0 Then
                    Session("No3") = dtCheckNo3.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No3") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt4.Text <> "" Then
                strSQLCheckNo4 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt4.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo4 = New SqlDataAdapter(strSQLCheckNo4, objConn)
                dtAdapterCheckNo4.Fill(dtCheckNo4)
                If dtCheckNo4.Rows.Count > 0 Then
                    Session("No4") = dtCheckNo4.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No4") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt5.Text <> "" Then
                strSQLCheckNo5 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt5.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo5 = New SqlDataAdapter(strSQLCheckNo5, objConn)
                dtAdapterCheckNo5.Fill(dtCheckNo5)
                If dtCheckNo5.Rows.Count > 0 Then
                    Session("No5") = dtCheckNo5.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No5") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt6.Text <> "" Then
                strSQLCheckNo6 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt6.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo6 = New SqlDataAdapter(strSQLCheckNo6, objConn)
                dtAdapterCheckNo6.Fill(dtCheckNo6)
                If dtCheckNo6.Rows.Count > 0 Then
                    Session("No6") = dtCheckNo6.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No6") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt7.Text <> "" Then
                strSQLCheckNo7 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt7.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo7 = New SqlDataAdapter(strSQLCheckNo7, objConn)
                dtAdapterCheckNo7.Fill(dtCheckNo7)
                If dtCheckNo7.Rows.Count > 0 Then
                    Session("No7") = dtCheckNo7.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No7") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt8.Text <> "" Then
                strSQLCheckNo8 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt8.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo8 = New SqlDataAdapter(strSQLCheckNo8, objConn)
                dtAdapterCheckNo8.Fill(dtCheckNo8)
                If dtCheckNo8.Rows.Count > 0 Then
                    Session("No8") = dtCheckNo8.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No8") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt9.Text <> "" Then
                strSQLCheckNo9 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt9.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo9 = New SqlDataAdapter(strSQLCheckNo9, objConn)
                dtAdapterCheckNo9.Fill(dtCheckNo9)
                If dtCheckNo9.Rows.Count > 0 Then
                    Session("No9") = dtCheckNo9.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No9") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt10.Text <> "" Then
                strSQLCheckNo10 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt10.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo10 = New SqlDataAdapter(strSQLCheckNo10, objConn)
                dtAdapterCheckNo10.Fill(dtCheckNo10)
                If dtCheckNo10.Rows.Count > 0 Then
                    Session("No10") = dtCheckNo10.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No10") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt11.Text <> "" Then
                strSQLCheckNo11 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt11.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo11 = New SqlDataAdapter(strSQLCheckNo11, objConn)
                dtAdapterCheckNo11.Fill(dtCheckNo11)
                If dtCheckNo11.Rows.Count > 0 Then
                    Session("No11") = dtCheckNo11.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No11") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt12.Text <> "" Then
                strSQLCheckNo12 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt12.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo12 = New SqlDataAdapter(strSQLCheckNo12, objConn)
                dtAdapterCheckNo12.Fill(dtCheckNo12)
                If dtCheckNo12.Rows.Count > 0 Then
                    Session("No12") = dtCheckNo12.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No12") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt13.Text <> "" Then
                strSQLCheckNo13 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt13.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo13 = New SqlDataAdapter(strSQLCheckNo13, objConn)
                dtAdapterCheckNo13.Fill(dtCheckNo13)
                If dtCheckNo13.Rows.Count > 0 Then
                    Session("No13") = dtCheckNo13.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No13") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt14.Text <> "" Then
                strSQLCheckNo14 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt14.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo14 = New SqlDataAdapter(strSQLCheckNo14, objConn)
                dtAdapterCheckNo14.Fill(dtCheckNo14)
                If dtCheckNo14.Rows.Count > 0 Then
                    Session("No14") = dtCheckNo12.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No14") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt15.Text <> "" Then
                strSQLCheckNo15 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt15.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo15 = New SqlDataAdapter(strSQLCheckNo15, objConn)
                dtAdapterCheckNo15.Fill(dtCheckNo15)
                If dtCheckNo15.Rows.Count > 0 Then
                    Session("No15") = dtCheckNo15.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No15") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            If Lottxt16.Text <> "" Then
                strSQLCheckNo16 = "
                        SELECT      TOP (1) No
                        FROM        [DBx].[QYI].[QYICase]
                        WHERE       LotNo= '" & Lottxt16.Text & "' and QYICase.Mode IS Not NULL  order By TimeIn DESC"
                dtAdapterCheckNo16 = New SqlDataAdapter(strSQLCheckNo16, objConn)
                dtAdapterCheckNo16.Fill(dtCheckNo16)
                If dtCheckNo16.Rows.Count > 0 Then
                    Session("No16") = dtCheckNo16.Rows(0)("No")
                End If

                strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set IssueNo = '" & Session("InsertIssueNo") & "',IssueDate ='" & Now() & "',Mode='" & Session("InsertMode") & "',SameModeIssue = '" & Session("SameModeNo") & "'
        ,NGTestNo='" & Session("InsertNgtNo") & "',NGTestNo2='" & Session("InsertNgtNo2") & "',NGTestNo3='" & Session("InsertNgtNo3") & "',NGTestNo4='" & Session("InsertNgtNo4") & "',NGTestNo5='" & Session("InsertNgtNo5") & "',NGTestNo6='" & Session("InsertNgtNo6") & "'
        ,NGTestData='" & Session("InsertNgtDate") & "',NGTestData2='" & Session("InsertNgtDate2") & "',NGTestData3='" & Session("InsertNgtDate3") & "',NGTestData4='" & Session("InsertNgtDate4") & "',NGTestData5='" & Session("InsertNgtDate5") & "',NGTestData6='" & Session("InsertNgtDate6") & "' Where No ='" & Session("No16") & "'"
                objCmd = New SqlCommand(strSQLUpdate, objConn)
                objCmd.ExecuteNonQuery()
            End If

            My.Computer.FileSystem.CreateDirectory("\\172.16.0.115/NewCenterPoint/QYI/" & Session("InsertYear") & "\" & Session("InsertIssueNo") & "(" & Session("Device") & ")")
            Response.Redirect("UploadFileIssueNo.aspx")
        End If
    End Sub

End Class