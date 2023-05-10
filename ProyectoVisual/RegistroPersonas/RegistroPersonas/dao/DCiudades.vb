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

    Public Function GuardarRegistro(ByVal ciudad As Ciudades) As Boolean
        Dim resultado As Boolean = False



        Try
            Dim conn As New SqlConnection(strConn)
            Dim cmd As New SqlCommand()
            Dim tsql = "insert into Ciudad(nombre) values(@nombre)"
            cmd.Parameters.AddWithValue("@nombre", ciudad.Nombre)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql
            cmd.Connection = conn
            cmd.Connection.Open()

            If (cmd.ExecuteNonQuery <> 0) Then
                resultado = True
            End If
            cmd.Connection.Close()

        Catch ex As Exception
            MsgBox("Error al intentar guardar el registro", MsgBoxStyle.Critical, "Ciudades")
        End Try

        Return resultado
    End Function

    Public Function EditarRegistro(ByVal ciudad As Ciudades)
        Dim flag = False

        Try
            Dim tsql = "UPDATE Ciudad SET nombre = @nombre, estado = @estado where id = @id"
            Dim conn As New SqlConnection(My.Settings.StrConnection)
            Dim cmd As New SqlCommand(tsql, conn)
            cmd.Parameters.AddWithValue("@nombre", ciudad.Nombre)
            cmd.Parameters.AddWithValue("@estado", ciudad.Estado)
            cmd.Parameters.AddWithValue("@id", ciudad.Id)
            cmd.Connection.Open()

            If (cmd.ExecuteNonQuery <> 0) Then
                flag = True
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try

        Return flag
    End Function
End Class
