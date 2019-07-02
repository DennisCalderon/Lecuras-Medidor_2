Public Class Principal
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ActualizarMedidoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarMedidoresToolStripMenuItem.Click
        Dim form As New Padron_Clientes
        form.ShowDialog()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.Click
        Dim form As New Soporte
        form.ShowDialog()
    End Sub
End Class
