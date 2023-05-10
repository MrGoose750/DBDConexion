Public Class FrmCiudad

    Private Sub FrmCiudad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarRegistros()
    End Sub

    Sub LlenarRegistros()
        Dim dCiudad As New DCiudades
        DgvRegistros.DataSource = dCiudad.MostrarRegistros.Tables(0)
        DgvRegistros.Refresh()
        GbRegistro.Text = "Registros almacenados: " & DgvRegistros.Rows.Count
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim ciudad As New Ciudades()
            ciudad.Nombre = TxtNombre.Text.Trim
            Dim dCiudad As New DCiudades

            If (dCiudad.GuardarRegistro(ciudad)) Then
                MsgBox("Registro guardado satisfactoriamente", MsgBoxStyle.Information, "Ciudad")
            Else
                MsgBox("No se pudo guardar el registro", MsgBoxStyle.Information, "Ciudades")
            End If
            LlenarRegistros()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Try
            Dim ciudad As New Ciudades(CInt(TxtId.Text), TxtNombre.Text, True)
            Dim dao As New DCiudades

            If (dao.EditarRegistro(ciudad)) Then
                MsgBox("Registro editado")
            Else
                MsgBox("Error")
            End If
            LlenarRegistros()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvRegistros_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRegistros.CellDoubleClick
        Dim fila As Integer = DgvRegistros.CurrentRow.Index
        TxtId.Text = DgvRegistros.Rows(fila).Cells(0).Value
        TxtNombre.Text = DgvRegistros.Rows(fila).Cells(1).Value
    End Sub
End Class