Imports System.Data.SqlClient
Public Class _Default
    Inherits Page

    Dim objConn As SqlConnection
    Dim objCmd As SqlCommand
    Dim strConnString, strSQL, strSQLLCL, strSQLBIN, strSQLBIN19, strSQLLot, sqlSQLFQIFYI As String
    Dim ds As New DataSet()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        strConnString = "Server=172.16.0.102;Uid=System;PASSWORD=p@$$w0rd;database=DBx;Max Pool Size=400;Connect Timeout=600;"
        objConn = New SqlConnection(strConnString)
        objConn.Open()
        If Not IsPostBack Then
            BindData()
        End If
    End Sub

    Sub BindData()
        '*** Data FQI To FYI ****'
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Using con As New SqlConnection(strConnString)
            Using cmd As New SqlCommand("Select No,LotNo,Process,OldDeviceName,OldPackage,Mode FROM [DBx].[QYI].[QYICase] WHERE (StatusFlowFYI='FYI') and  (TimeIn >'2020-10-06 00:00:00.000' AND ReceiveDate IS NULL)")
                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        MyGridViewFYI.DataSource = dt
                        MyGridViewFYI.DataBind()
                    End Using
                End Using
            End Using
        End Using

        '*** Data LCL & Yield <80% ****'
        strSQLLCL = "Select LotNo,Process,OldDeviceName,OldPackage,Mode,UserIDIn as UserIn, CONVERT (varchar(20),TimeIn,113) As Time1st,CONVERT (varchar(20),TimeOut,113) As TimeOut,OSNG1 As OSNG,GotoProcess as Status
        FROM [DBx].[QYI].[QYICase] 
        WHERE (Mode = 'LCL' or Mode='Yield < 80 %' or Mode='ASI 100% Lot') and  (GotoProcess IS NULL or GotoProcess ='Retest FT Auto1' or GotoProcess ='Retest FT Auto2' or GotoProcess ='Retest FT Auto3' or GotoProcess ='Retest FT Auto4') and (GotoProcess2 IS NULL )"

        Dim dtReaderLCL As SqlDataReader
        objCmd = New SqlCommand(strSQLLCL, objConn)
        dtReaderLCL = objCmd.ExecuteReader()

        '*** BindData to GridView ***'
        MyGridViewLCL.DataSource = dtReaderLCL
        MyGridViewLCL.DataBind()

        dtReaderLCL.Close()
        dtReaderLCL = Nothing

        '*** Data Bin ****'
        strSQLBIN = "Select LotNo,Process,OldDeviceName,OldPackage,Mode,UserIDIn as UserIn, CONVERT (varchar(20),TimeIn,113) As Time1st,CONVERT (varchar(20),TimeOut,113) As TimeOut,OSNG1 As OSNG,GotoProcess as Status
        FROM [DBx].[QYI].[QYICase] 
        WHERE (Mode = 'BIN29,BIN30,BIN31' or Mode='BIN13,BIN14' or Mode='BIN28') and  (GotoProcess IS NULL) and (GotoProcess2 IS NULL )"

        Dim dtReaderBIN As SqlDataReader
        objCmd = New SqlCommand(strSQLBIN, objConn)
        dtReaderBIN = objCmd.ExecuteReader()

        '*** BindData to GridView ***'
        myGridViewBIN.DataSource = dtReaderBIN
        myGridViewBIN.DataBind()

        dtReaderBIN.Close()
        dtReaderBIN = Nothing

        '*** Data Bin19 ****'myGridViewBin19
        strSQLBIN19 = "Select LotNo,Process,OldDeviceName,OldPackage,Mode,UserIDIn as UserIn, CONVERT (varchar(20),TimeIn,113) As Time1st,CONVERT (varchar(20),TimeOut,113) As TimeOut,OSNG1 As OSNG,GotoProcess as Status
        FROM [DBx].[QYI].[QYICase] 
        WHERE (Mode = 'BIN19') and  (GotoProcess ='Retest Auto3 Bin19' or GotoProcess IS NULL) and (GotoProcess2 IS NULL )"

        Dim dtReaderBIN19 As SqlDataReader
        objCmd = New SqlCommand(strSQLBIN19, objConn)
        dtReaderBIN19 = objCmd.ExecuteReader()

        '*** BindData to GridView ***'
        myGridViewBin19.DataSource = dtReaderBIN19
        myGridViewBin19.DataBind()

        dtReaderBIN19.Close()
        dtReaderBIN19 = Nothing

        '*** Data Lot Eva ****'
        strSQLLot = "Select LotNo,Process,OldDeviceName,OldPackage,Mode,UserIDIn as UserIn, CONVERT (varchar(20),TimeIn,113) As Time1st,CONVERT (varchar(20),TimeOut,113) As TimeOut,OSNG1 As OSNG,GotoProcess as Status
        FROM [DBx].[QYI].[QYICase] 
        WHERE (Mode = 'Lot Eva New Device' or Mode='Lot Eva Test Equipment') and  (GotoProcess IS NULL) and (GotoProcess2 IS NULL )"

        Dim dtReaderLot As SqlDataReader
        objCmd = New SqlCommand(strSQLLot, objConn)
        dtReaderLot = objCmd.ExecuteReader()

        '*** BindData to GridView ***'
        myGridViewLot.DataSource = dtReaderLot
        myGridViewLot.DataBind()

        dtReaderLot.Close()
        dtReaderLot = Nothing
    End Sub

    Protected Sub btnReceive_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        Using con As New SqlConnection(strConnString)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE [DBx].[QYI].[QYICase] SET [ReceiveDate] = '" & Now() & "' WHERE No=@No"
                cmd.Connection = con
                con.Open()
                For Each row As GridViewRow In MyGridViewFYI.Rows
                    'Get the HobbyId from the DataKey property.
                    Dim No As Integer = Convert.ToInt32(MyGridViewFYI.DataKeys(row.RowIndex).Values(0))

                    'Get the checked value of the CheckBox.
                    Dim chk As CheckBox = DirectCast(row.FindControl("chkSelect"), CheckBox)
                    If chk.Checked = True Then
                        'Save to database
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@No", No)
                        cmd.ExecuteNonQuery()
                    End If

                Next
                con.Close()
                Response.Redirect(Request.Url.AbsoluteUri)
            End Using
        End Using

    End Sub
End Class