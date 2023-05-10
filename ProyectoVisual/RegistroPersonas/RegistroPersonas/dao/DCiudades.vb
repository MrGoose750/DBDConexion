Imports System.Data.SqlClient

Public Class DCiudades

    Dim strConn As String = My.Settings.StrConnection.ToString()

    Public Function MostrarRegistros() As DataSet
        Dim ds As New DataSet
        Try
            Dim conn As New SqlConnection(strConn)
            Dim tSql As String = "Select id as N'CODIGO', nombre as N'CIUDAD' from ciudad"
            Dim da As New SqlDataAdapter(tSql, conn)
            da.Fill(ds)
        Catch ex As Exception
            MsgBox("Ocurrio un error al obtener los registros" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return ds
    End Function
End Class
