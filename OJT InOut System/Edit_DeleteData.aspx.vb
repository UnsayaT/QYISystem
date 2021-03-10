Imports System.Data.SqlClient
Imports System.IO

Public Class Edit_DeleteData
    Inherits System.Web.UI.Page

    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand
    Dim strConnString, strSQL, strSQLIssueNo1, strSQLIssueNo2, strSQLIssueNo3, strSQLUpdate As String
    Dim dtReader As SqlDataReader
    Dim dtAdapterIssueNo1, dtAdapterIssueNo2, dtAdapterIssueNo3 As SqlDataAdapter
    Dim dtIssueNo1, dtIssueNo2, dtIssueNo3 As New DataTable
    Dim i As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strConnString = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=DBx;Max Pool Size=400;Connect Timeout=600;"
        objConn = New SqlConnection(strConnString)
        objConn.Open()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.txtIssueNo.Text <> "" Then
            strSQLIssueNo1 = "SELECT QYICase.*,QYILowYield.*,SUBSTRING(IssueNo, 1, 9) AS IssYear,TransactionData.Device,TransactionData.Package,TransactionData.LotNo As Lot  FROM [DBx].[QYI].[QYICase] INNER JOIN [DBx].[QYI].[QYILowYield] ON [DBx].[QYI].[QYICase] .No = [DBx].[QYI].[QYILowYield].No INNER JOIN 
dbo.TransactionData ON QYICase.LotNo = dbo.TransactionData.LotNo WHERE IssueNo LIKE '%" & Me.txtIssueNo.Text & "%'"
            dtAdapterIssueNo1 = New SqlDataAdapter(strSQLIssueNo1, objConn)
            dtAdapterIssueNo1.Fill(dtIssueNo1)
            If dtIssueNo1.Rows.Count > 0 Then
                Session("Mode") = "LowYield"
                Session("InsertYear") = dtIssueNo1.Rows(i)("IssYear")

                If IsDBNull(dtIssueNo1.Rows(i)("No")) Then
                    Session("No") = "-"
                Else
                    Session("No") = dtIssueNo1.Rows(i)("No")
                End If

                If IsDBNull(dtIssueNo1.Rows(i)("IssueNo")) Then
                    lblIssuNo.Text = "-"
                Else
                    lblIssuNo.Text = dtIssueNo1.Rows(i)("IssueNo")
                End If

                If IsDBNull(dtIssueNo1.Rows(i)("Lot")) Then
                    lblLotNo.Text = "-"
                Else
                    lblLotNo.Text = dtIssueNo1.Rows(i)("Lot")
                End If

                If IsDBNull(dtIssueNo1.Rows(i)("Device")) Then
                    lblDevice.Text = "-"
                Else
                    lblDevice.Text = dtIssueNo1.Rows(i)("Device")
                End If

                If IsDBNull(dtIssueNo1.Rows(i)("Package")) Then
                    lblPackage.Text = "-"
                Else
                    lblPackage.Text = dtIssueNo1.Rows(i)("Package")
                End If

                If IsDBNull(dtIssueNo1.Rows(i)("Process")) Then
                    lblProcess.Text = "-"
                Else
                    lblProcess.Text = dtIssueNo1.Rows(i)("Process")
                End If

                If IsDBNull(dtIssueNo1.Rows(i)("TestFlow")) Then
                    lblFlow.Text = "-"
                Else
                    lblFlow.Text = dtIssueNo1.Rows(i)("TestFlow")
                End If

                If IsDBNull(dtIssueNo1.Rows(i)("NGTestNo")) Then
                    txtNG.Text = ""
                Else
                    txtNG.Text = dtIssueNo1.Rows(i)("NGTestNo")
                End If

                If IsDBNull(dtIssueNo1.Rows(i)("NGTestData")) Then
                    txtNG.Text = ""
                Else
                    txtDataNG.Text = dtIssueNo1.Rows(i)("NGTestData")
                End If

            End If

        ElseIf Me.txtABNo.Text <> "" Then
            strSQLIssueNo2 = "SELECT QYICase.*,QYIICBurn.*,SUBSTRING(AbNo, 1, 9) AS AbnoYear,TransactionData.Device,TransactionData.Package,TransactionData.LotNo As Lot  FROM [DBx].[QYI].[QYICase] INNER JOIN [DBx].[QYI].[QYIICBurn] ON [DBx].[QYI].[QYICase] .No = [DBx].[QYI].[QYIICBurn].No INNER JOIN 
dbo.TransactionData ON QYICase.LotNo = dbo.TransactionData.LotNo WHERE Abno LIKE '%" & Me.txtABNo.Text & "%'"
            dtAdapterIssueNo2 = New SqlDataAdapter(strSQLIssueNo2, objConn)
            dtAdapterIssueNo2.Fill(dtIssueNo2)
            If dtIssueNo2.Rows.Count > 0 Then
                Session("Mode") = "ICBurn"
                Session("InsertYear") = dtIssueNo2.Rows(i)("AbnoYear")

                If IsDBNull(dtIssueNo2.Rows(i)("No")) Then
                    Session("No") = "-"
                Else
                    Session("No") = dtIssueNo2.Rows(i)("No")
                End If

                If IsDBNull(dtIssueNo2.Rows(i)("AbNo")) Then
                    lblIssuNo.Text = "-"
                Else
                    lblIssuNo.Text = dtIssueNo2.Rows(i)("AbNo")
                End If

                If IsDBNull(dtIssueNo2.Rows(i)("Lot")) Then
                    lblLotNo.Text = "-"
                Else
                    lblLotNo.Text = dtIssueNo2.Rows(i)("Lot")
                End If

                If IsDBNull(dtIssueNo2.Rows(i)("Device")) Then
                    lblDevice.Text = "-"
                Else
                    lblDevice.Text = dtIssueNo2.Rows(i)("Device")
                End If

                If IsDBNull(dtIssueNo2.Rows(i)("Package")) Then
                    lblPackage.Text = "-"
                Else
                    lblPackage.Text = dtIssueNo2.Rows(i)("Package")
                End If

                If IsDBNull(dtIssueNo2.Rows(i)("Process")) Then
                    lblProcess.Text = "-"
                Else
                    lblProcess.Text = dtIssueNo2.Rows(i)("Process")
                End If

                If IsDBNull(dtIssueNo2.Rows(i)("TestFlow")) Then
                    lblFlow.Text = "-"
                Else
                    lblFlow.Text = dtIssueNo2.Rows(i)("TestFlow")
                End If

                If IsDBNull(dtIssueNo2.Rows(i)("OSCheck")) Then
                    OSCheckValue.Text = ""
                Else
                    OSCheckValue.Text = dtIssueNo2.Rows(i)("OSCheck")
                End If

                If IsDBNull(dtIssueNo2.Rows(i)("LotStatus")) Then
                    LotstatusValue.Text = ""
                Else
                    LotstatusValue.Text = dtIssueNo2.Rows(i)("LotStatus")
                End If
            End If
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Session("Mode") = "LowYield" Then
            strSQLUpdate = "Update [DBx].[QYI].[QYILowYield] Set " &
            "Mode = '" & Me.Mode.SelectedValue & "' " &
            ",NGTestNo='" & Me.txtNG.Text & "' " &
            ",NGTestData='" & Me.txtDataNG.Text & "' " &
            "WHERE No ='" & Session("No") & "'"
            objCmd = New SqlCommand(strSQLUpdate, objConn)
            objCmd.ExecuteNonQuery()
        ElseIf Session("Mode") = "ICBurn" Then
            strSQLUpdate = "Update [DBx].[QYI].[QYIICBurn] Set " &
                "OSCheck = '" & Me.OSCheckValue.Text & "' " &
                ",LotStatus='" & Me.LotstatusValue.Text & "' " &
                "WHERE No ='" & Session("No") & "' "
            objCmd = New SqlCommand(strSQLUpdate, objConn)
            objCmd.ExecuteNonQuery()
        End If

        Page.RegisterClientScriptBlock("OnLoad", "<script>alert('Edit ข้อมูลสำเร็จ')</script>")

        'Response.Redirect("Default.aspx")
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Session("Status") = "CL"

        strSQL = "DELETE FROM [DBx].[QYI].[QYICase] WHERE No = '" & Session("No") & "' "
        objCmd = New SqlCommand
        With objCmd
            .Connection = objConn
            .CommandText = strSQL
            .CommandType = CommandType.Text
        End With
        objCmd.ExecuteNonQuery()

        objCmd = Nothing
        objCmd = Nothing
        objConn.Close()
        objConn = Nothing

        If Session("Mode") = "ICBurn" Then
            strSQL = "DELETE FROM [DBx].[QYI].[QYIICBurn] WHERE No ='" & Session("No") & "' "
            objCmd = New SqlCommand
            With objCmd
                .Connection = objConn
                .CommandText = strSQL
                .CommandType = CommandType.Text
            End With
            objCmd.ExecuteNonQuery()

            objCmd = Nothing
            objConn.Close()
            objConn = Nothing
            Dim DirInfo As New DirectoryInfo("\\172.16.0.115\NewCenterPoint\QYI\" & Session("InsertYear") & "\" & lblIssuNo.Text & "(" & lblDevice.Text & ")")
            '*** Delete Folder ***'
            If DirInfo.Exists Then
                DirInfo.Delete(True)
            End If

        ElseIf Session("Mode") = "LowYield" Then
            strSQL = "DELETE FROM [DBx].[QYI].[QYILowYield] WHERE No ='" & Session("No") & "' "
            objCmd = New SqlCommand
            With objCmd
                .Connection = objConn
                .CommandText = strSQL
                .CommandType = CommandType.Text
            End With
            objCmd.ExecuteNonQuery()

            objCmd = Nothing
            objConn.Close()
            objConn = Nothing

            Dim DirInfo As New DirectoryInfo("\\172.16.0.115\NewCenterPoint\QYI\" & Session("InsertYear") & "\" & lblIssuNo.Text & "(" & lblDevice.Text & ")")
            '*** Delete Folder ***'
            If DirInfo.Exists Then
                DirInfo.Delete(True)
            End If
        End If

        Page.RegisterClientScriptBlock("OnLoad", "<script>alert('Delete ข้อมูลสำเร็จ')</script>")
        'Response.Redirect("Default.aspx")
    End Sub

End Class