Imports System.Data.SqlClient

Public Class connection

    Dim connect As New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")
    Public Function open() As SqlConnection
        Try
            connect.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return connect
    End Function

    Public Function close() As SqlConnection
        Try
            connect.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return connect
    End Function
End Class
