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

End Class