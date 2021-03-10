Imports System.Data.SqlClient
Imports OJT_InOut_System.ServiceLibrary

Public Class DetailOut2
    Inherits System.Web.UI.Page
    Dim objConn, objConnPro, objConnIS As SqlConnection
    Dim objCmd, objCmdPro, objCmdIS As SqlCommand
    Dim strSQLEmp, strSQLLot, strSQLTranLot, strSQLQYI, strSQLUpcase, strSQLLY, strSQLIC As String
    Dim dtAdapterEmp, dtAdapterLot, dtTranLot, dtAdapterQYI, dtAdapterLY, dtAdapterIC As SqlDataAdapter
    Dim dtEmp, dtLot, dtLotID, dtQYI, dtLY, dtIC As New DataTable

    Public C_iLibgrarySevice As ServiceiLibraryClient
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        C_iLibgrarySevice = New ServiceiLibraryClient()
        Dim strConnString As String
        strConnString = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=DBx;Max Pool Size=400;Connect Timeout=600;"
        objConn = New SqlConnection(strConnString)
        objConn.Open()

        Dim strConnStringPro As String
        strConnStringPro = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=APCSProDB;Max Pool Size=400;Connect Timeout=600;"
        objConnPro = New SqlConnection(strConnStringPro)
        objConnPro.Open()

        txtLotno.Text = Session("Lot")
        txtEmpNo.Text = Session("Emp")
        txtOSNG1.Text = Session("NG1")
        RadioButton1.Checked = True
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click

        If RadioButton3.Checked = True And txtOSNG2.Text <> "" Then
            Session("TotolNG") = txtOSNG1.Text + txtOSNG2.Text
            If Session("TotalNG") > 4 Then
                Session("NG") = Session("TotolNG")
                Response.Redirect("OSNG_Over2.aspx")
            Else
                'Check Lot ใน QYI 
                strSQLQYI = "Select Top(1) * FROM [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "'  order By TimeIn DESC"
                dtAdapterQYI = New SqlDataAdapter(strSQLQYI, objConn)
                dtAdapterQYI.Fill(dtQYI)
                If dtQYI.Rows.Count > 0 Then
                    If dtQYI.Rows(0)("UserIDIn2").ToString.Trim() <> "" And dtQYI.Rows(0)("UserIDOut2").ToString.Trim() = "" Then
                        Session("QYINo") = dtQYI.Rows(0)("No")
                        Session("GOto") = "AUTO(4)"
                        'Update ข้อมูลลงใน QYICase
                        strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & txtEmpNo.Text & "' " &
                        " ,TimeOut2 = '" & Now() & "',GotoProcess2 = '" & Session("GOto") & "',OSNG2='" & txtOSNG2.Text & "' Where No ='" & Session("QYINo") & "'"
                        objCmd = New SqlCommand(strSQLUpcase, objConn)
                        objCmd.ExecuteNonQuery()

                        C_iLibgrarySevice.EndLotNoCheckLicenser(txtLotno.Text, "TE-QYI-01", txtEmpNo.Text, 0, 0)

                        'ไปหน้าIS
                        If Session("Menu") = "FQI" Then
                            Response.Redirect("http://beerserver/FQI_REC/MainForm.aspx")
                        ElseIf Session("Menu") = "FYI" Then
                            Response.Redirect("http://beerserver/LSI/FYI/mainmenu.aspx")
                        End If
                    Else
                        Session("QYINo") = dtQYI.Rows(0)("No")
                        Session("GOto") = "AUTO(4)"
                        'Update ข้อมูลลงใน QYICase
                        strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & txtEmpNo.Text & "' " &
                        " ,TimeOut2 = '" & Now() & "',GotoProcess2 = '" & Session("GOto") & "',OSNG2='" & txtOSNG2.Text & "' Where No ='" & Session("QYINo") & "'"
                        objCmd = New SqlCommand(strSQLUpcase, objConn)
                        objCmd.ExecuteNonQuery()

                        C_iLibgrarySevice.EndLotNoCheckLicenser(txtLotno.Text, "TE-QYI-01", txtEmpNo.Text, 0, 0)

                        'ไปหน้าIS
                        If Session("Menu") = "FQI" Then
                            Response.Redirect("http://beerserver/FQI_REC/MainForm.aspx")
                        ElseIf Session("Menu") = "FYI" Then
                            Response.Redirect("http://beerserver/LSI/FYI/mainmenu.aspx")
                        End If
                    End If

                Else
                    MsgBox("No Data")
                End If
            End If
        ElseIf RadioButton4.Checked = True Then
            'OS All Pass
            C_iLibgrarySevice.EndLotNoCheckLicenser(txtLotno.Text, "TE-QYI-01", txtEmpNo.Text, 0, 0)
            'Check Lot ใน QYI 
            strSQLQYI = "Select Top(1) * FROM [DBx].[QYI].[QYICase] Where LotNo ='" & txtLotno.Text & "'  order By TimeIn DESC"
            dtAdapterQYI = New SqlDataAdapter(strSQLQYI, objConn)
            dtAdapterQYI.Fill(dtQYI)
            If dtQYI.Rows.Count > 0 Then
                If dtQYI.Rows(0)("UserIDIn2").ToString.Trim() <> "" And dtQYI.Rows(0)("UserIDOut2").ToString.Trim() = "" Then
                    Session("QYINo") = dtQYI.Rows(0)("No")
                    Session("GOto") = "AUTO(4)"
                    'Update ข้อมูลลงใน QYICase
                    strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut2 = '" & txtEmpNo.Text & "' " &
                        " ,TimeOut2 = '" & Now() & "',GotoProcess2 = '" & Session("GOto") & "',OSNG2='0' Where No ='" & Session("QYINo") & "'"
                    objCmd = New SqlCommand(strSQLUpcase, objConn)
                    objCmd.ExecuteNonQuery()

                    'ไปหน้าIS
                    If Session("Menu") = "FQI" Then
                        Response.Redirect("http://beerserver/FQI_REC/MainForm.aspx")
                    ElseIf Session("Menu") = "FYI" Then
                        Response.Redirect("http://beerserver/LSI/FYI/mainmenu.aspx")
                    End If
                Else
                    Session("QYINo") = dtQYI.Rows(0)("No")
                    Session("GOto") = "AUTO(4)"
                    'Update ข้อมูลลงใน QYICase
                    strSQLUpcase = "UPDATE [DBx].[QYI].[QYICase] SET UserIDOut3 = '" & txtEmpNo.Text & "' " &
                        " ,TimeOut3 = '" & Now() & "',GotoProcess3 = '" & Session("GOto") & "',OSNG3='0' Where No ='" & Session("QYINo") & "'"
                    objCmd = New SqlCommand(strSQLUpcase, objConn)
                    objCmd.ExecuteNonQuery()

                    'ไปหน้าIS
                    If Session("Menu") = "FQI" Then
                        Response.Redirect("http://beerserver/FQI_REC/MainForm.aspx")
                    ElseIf Session("Menu") = "FYI" Then
                        Response.Redirect("http://beerserver/LSI/FYI/mainmenu.aspx")
                    End If
                End If
            Else
                MsgBox("No Data")
            End If
        ElseIf RadioButton3.Checked = True And txtOSNG2.Text = "" Then
            MsgBox("Input OS NG ")
        ElseIf RadioButton3.Checked = False And RadioButton4.Checked = False Then
            MsgBox("Select Manual OS Test 2st")
        End If
    End Sub
End Class