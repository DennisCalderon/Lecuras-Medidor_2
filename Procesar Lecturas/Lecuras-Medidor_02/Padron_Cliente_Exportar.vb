Public Class Padron_Cliente_Exportar
    Private Sub btnCancela_Click(sender As Object, e As EventArgs) Handles btnCancela.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        dgvpadron.Rows.Clear()
        Dim lista As New List(Of String)
        If chkTacna.Checked = True Then
            lista.Add("TACNA")
        End If
        If chkMoquegua.Checked = True Then
            lista.Add("MOQUEGUA")
        End If
        If chkIlo.Checked = True Then
            lista.Add("ILO")
        End If
        If chkLibres.Checked = True Then
            lista.Add("LIBRES")
        End If
        MExportar.ExportPadron(lista, dgvpadron)
    End Sub
End Class