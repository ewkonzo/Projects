Imports System.Net
Imports System.Web
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class DbConn
    Dim DBConn As New SqlConnection
    Dim AccDB As New SqlConnection
    Public Accrec As SqlDataReader
    Public rec As SqlDataReader
    Public Enum dataExecTypes
        ExecTypeQuery = 0
        ExecTypeNonQuery = 1
    End Enum

    Public Function DBconnection() As System.Data.SqlClient.SqlConnection
        Try
            DBconnection = New Data.SqlClient.SqlConnection
            If DBconnection.State = Data.ConnectionState.Broken Or DBconnection.State = Data.ConnectionState.Closed Then
                DBconnection.ConnectionString = "Data Source=DITLPT-SWAMBUGU\MS2008SERVER;Initial Catalog=WEIGHCONSQL;MultipleActiveResultsets=True;User ID=sa;Password =pass"
                DBconnection.Open()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function ACCconnection() As SqlConnection
        Try
            ACCconnection = New SqlConnection
            If ACCconnection.State = Data.ConnectionState.Broken Or ACCconnection.State = Data.ConnectionState.Closed Then
                ACCconnection.ConnectionString = My.Settings.WEIGHCONConnectionString
                ACCconnection.Open()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function AccUpload(ByVal psql As String) As SqlCommand
        Try
            AccUpload = New SqlCommand(psql, ACCconnection)
            AccUpload.ExecuteNonQuery()
            ACCconnection.Dispose()
            ACCconnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function AccDownload(ByVal psql As String) As SqlCommand
        Try
            AccDownload = New SqlCommand(psql, ACCconnection)
            Accrec = AccDownload.ExecuteReader
            ACCconnection.Dispose()
            ACCconnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function CONNUpload(ByVal psql As String) As Data.SqlClient.SqlCommand
        Try
            CONNUpload = New Data.SqlClient.SqlCommand(psql, DBconnection)
            CONNUpload.ExecuteNonQuery()
            DBconnection.Dispose()
            DBconnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function CONNDownload(ByVal psql As String) As Data.SqlClient.SqlCommand
        Try
            CONNDownload = New Data.SqlClient.SqlCommand(psql, DBconnection)
            rec = CONNDownload.ExecuteReader
            DBconnection.Dispose()
            DBconnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
End Class
