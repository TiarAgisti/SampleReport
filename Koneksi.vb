Imports System.Data
Imports System.Data.SqlClient
Public Class Koneksi
    Protected Function ConnectionStr() As String
        Dim str As String = "Server=WS020104\SQLEXPRESS;Database=Ocean;User Id=sa;Password=12345;"
        Return str
    End Function

    Function sqlConnection() As SqlConnection
        Dim myConnection As SqlConnection = New SqlConnection(ConnectionStr)
        If myConnection.State = ConnectionState.Closed Then
            myConnection.Open()
        End If
        Return myConnection
    End Function


End Class
