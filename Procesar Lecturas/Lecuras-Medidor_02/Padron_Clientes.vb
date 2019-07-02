
Imports System
Imports System.Data
Imports System.IO
Imports Excel


Public Class Padron_Clientes
    Dim result As DataSet 'para llenar el dataGridView con los datos del padrón
    Private Sub Padron_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnProcesar.Enabled = False
        btnExportar.Enabled = False
        cboSector.Items.Add("Tacna")
        cboSector.Items.Add("Moquegua")
        cboSector.Items.Add("Ilo")
        cboSector.Items.Add("Libres")
        cboSector.Items.Add("Todos")
        cboSector.SelectedIndex = 0
    End Sub

    Private Sub btnCargarExcel_Click(sender As Object, e As EventArgs) Handles btnCargarExcel.Click
        dgvmedidor.DataMember = ""
        dgvmedidor.DataSource = ""

        btnMostrarPadron.Enabled = False
        cboSector.Enabled = False

        Using ofd As New OpenFileDialog()
            ofd.Filter = "Excel 2007-2016|*.xlsx"
            ofd.ValidateNames = True

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim fs As FileStream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read)
                    Dim reader As IExcelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs) 'Read excel 2007

                    reader.IsFirstRowAsColumnNames = True
                    result = reader.AsDataSet()
                    For Each dt As DataTable In result.Tables
                        cboExcel.Items.Add(dt.TableName)
                    Next
                    reader.Close()
                    cboExcel.SelectedIndex = 0
                Catch ex As Exception
                    MessageBox.Show("Problema detectado, por favor verifique que existe el archivo; si lo esta usando cierrelo y vuelva a intentar", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End Using

    End Sub

    Private Sub cboExcel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExcel.SelectedIndexChanged
        'Fill data from excel into DataGridView based on sheet selection
        dgvmedidor.DataSource = result.Tables(cboExcel.SelectedIndex)

        If (cboExcel.Text <> "") Then
            btnProcesar.Enabled = True
        Else
            btnProcesar.Enabled = False
        End If
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        btnMostrarPadron.Enabled = False
        cboSector.Enabled = False
        btnCargarExcel.Enabled = False
        cboExcel.Enabled = False
        btnProcesar.Enabled = False
        btnExportar.Enabled = False

        Dim NumImport As Integer
        'MessageBox.Show(cboExcel.SelectedItem, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        MBaseDatos.ConsultaNumImport(cboExcel.SelectedItem, NumImport) ' obtener el último ID del lote de medidores en la DB

        MessageBox.Show(NumImport, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = dgvmedidor.Rows.Count + 15

        Dim item As Integer = 1
        With dgvmedidor
            If .Rows.Count > 0 Then
                btnCargarExcel.Enabled = False
                btnProcesar.Enabled = False
                dgvmedidor.Enabled = False
                'ConsultaNumImport(NumImport)
                For i As Integer = 0 To .Rows.Count - 1
                    Application.DoEvents()
                    'MsgBox(NumImport)
                    'MsgBox(dgvmedidor.Rows(i).Cells(0).Value.ToString())
                    If String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString()) = False Then
                        'MsgBox(.Rows(i).Cells(1).Value.ToString(), MsgBoxStyle.Information, "Proceso de Cargar Terminado")
                        MBaseDatos.GuardarPadron(NumImport, cboExcel.SelectedItem, item, .Rows(i).Cells(1).Value.ToString(), .Rows(i).Cells(2).Value.ToString(), .Rows(i).Cells(3).Value.ToString(), .Rows(i).Cells(4).Value.ToString(), .Rows(i).Cells(5).Value.ToString(), .Rows(i).Cells(6).Value.ToString(), .Rows(i).Cells(7).Value.ToString(), .Rows(i).Cells(8).Value.ToString(), .Rows(i).Cells(9).Value.ToString(), .Rows(i).Cells(10).Value.ToString(), .Rows(i).Cells(11).Value.ToString(), .Rows(i).Cells(12).Value.ToString(), .Rows(i).Cells(13).Value.ToString(), .Rows(i).Cells(14).Value.ToString(), .Rows(i).Cells(15).Value.ToString())
                    End If
                    ProgressBar1.Value = i + 1
                    item = item + 1
                Next
            End If
        End With
        MsgBox("Padrón Actualizado", MsgBoxStyle.Information, "Proceso de Cargar Terminado")
        ProgressBar1.Value = 0
        Me.Close()

    End Sub
End Class