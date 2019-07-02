Imports System.IO
Public Class Principal
    Dim ruta_general As String 'almacena la ruta de la carpeta donde se encuentran los archivos de lecturas
    Dim exportar As Integer = 1 'determina si la exportación en de forma Unitaria o Masiva
    Dim conteoTotal As Integer = 1 'determina el incremente en la Barra de Progreso
    Sub checkedPadron(ByVal X As Boolean)
        chkTacna.Enabled = X
        chkMoquegua.Enabled = X
        chkIlo.Enabled = X
        chkLibres.Enabled = X
    End Sub
    Sub checkedMedidor(ByVal X As Boolean)
        chkS1440.Enabled = X
        chkA1800.Enabled = X
        chkMHTAB.Enabled = X
    End Sub
    Sub leerTiposMedidores(ByRef tipos_archivo As String)
        If chkS1440.Checked = True Then tipos_archivo = "S-1440|*.LP"
        If chkA1800.Checked = True Then tipos_archivo = "A-1800|*.prn"
        If chkMHTAB.Checked = True Then tipos_archivo = "MH-TAB|*.tab"
        If chkS1440.Checked = True And chkA1800.Checked = True Then tipos_archivo = "S-1440 y A-1800|*.LP;*.prn" '"S-1440|*.LP" & "|A-1800|*.prn"
        If chkS1440.Checked = True And chkMHTAB.Checked = True Then tipos_archivo = "S-1440 y MH-TAB|*.LP;*.tab" '"S-1440|*.LP" & "|MH-TAB|*.tab"
        If chkA1800.Checked = True And chkMHTAB.Checked = True Then tipos_archivo = "A-1800 y MH-TAB|*.prn;*.tab" ' "A-1800|*.prn" & "|MH-TAB|*.tab"
        If chkS1440.Checked = True And chkA1800.Checked = True And chkMHTAB.Checked = True Then tipos_archivo = "S-1440 y A-1800 y MH-TAB|*.LP;*.prn;*.tab" '"S-1440|*.LP" & "|A-1800|*.prn" & "|MH-TAB|*.tab"
    End Sub
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False
        lbArchivos.Enabled = False
        dgvcontenido.Enabled = False
        checkedPadron(False)

        btnBuscar.Select()
        dgvcontenido.AllowUserToAddRows = False ' denegar la acción de registros al usuario
    End Sub

    Private Sub ActualizarMedidoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarMedidoresToolStripMenuItem.Click
        Dim form As New Padron_Clientes
        form.ShowDialog()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.Click
        Dim form As New Soporte
        form.ShowDialog()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'buscar la ruta de los archivos
        Dim tipos_archivo As String = "Ejecutables|*.exe" ' por si el usuario no elije ningún checked se le colocara esto por defecto

        leerTiposMedidores(tipos_archivo)
        'MsgBox(tipos_archivo)

        OpenFileDialog1.Title = "Buscando la ubicación de los Archivos"
        OpenFileDialog1.FileName = "Archivos"

        OpenFileDialog1.Filter = tipos_archivo
        'OpenFileDialog1.Filter = "S-1440|*.LP" + "|A-1800|*.prn" + "|MH-TAB|*.tab"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim ruta As String '= "C:\Users\sing_\source\repos\Electrosur\Recursos"
            ruta = OpenFileDialog1.FileName
            'txtruta.Text = OpenFileDialog1.FileName

            lbArchivos.Items.Clear()
            'MsgBox(tipos_archivo.Remove(0, 7))
            ruta = ruta.Substring(0, (ruta.LastIndexOf("\") + 1))
            ruta_general = ruta ' colocando la RUTA en la variable Global "RUTA"
            Dim folder As New DirectoryInfo(ruta)
            Dim cant_archivos As Integer = 0

            'llenar el ListBox con las lecturas
            If tipos_archivo.Contains("*.LP") = True Then
                'MsgBox(tipos_archivo)
                For Each file As FileInfo In folder.GetFiles("*.LP")
                    lbArchivos.Items.Add(file.Name)
                    cant_archivos = cant_archivos + 1
                Next
            End If
            If tipos_archivo.Contains("*.prn") = True Then
                For Each file As FileInfo In folder.GetFiles("*.prn")
                    lbArchivos.Items.Add(file.Name)
                    cant_archivos = cant_archivos + 1
                Next
            End If
            If tipos_archivo.Contains("*.tab") = True Then
                For Each file As FileInfo In folder.GetFiles("*.tab")
                    lbArchivos.Items.Add(file.Name)
                    cant_archivos = cant_archivos + 1
                Next
            End If

            lblarchivos.Text = cant_archivos

            btnBuscar.Enabled = False
            btnExportMasivo.Enabled = True
            lbArchivos.Enabled = True
            btnNuevo.Enabled = True
            checkedMedidor(False)
            checkedPadron(True)
            btnNuevo.Select()
        Else
            MsgBox("No seleccionaste nada", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub lbArchivos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbArchivos.SelectedIndexChanged
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False
        dgvcontenido.Enabled = False

        dgvcontenido.Rows.Clear()

        Dim ruta As String = ruta_general.Substring(0, (ruta_general.LastIndexOf("\") + 1))
        ruta = ruta & lbArchivos.SelectedItem
        'txtruta.Text = ruta
        'MsgBox(ruta, MsgBoxStyle.Information, "leyendo")
        Dim conteo As Integer
        Dim filasT As Integer ' este solo se usara para el conteo total de registros
        obtenertotal(ruta, conteo, filasT)

        'diferenciar entre la exportación unitaria y la masiva
        If (exportar = 1) Then
            dgvcontenido.Rows.Clear()
        End If

        Dim tipo_medidor As String
        tipo_medidor = ruta.Substring(ruta.LastIndexOf(".") + 1, 2)
        'MsgBox(tipo_medidor)
        Select Case tipo_medidor
            Case "LP" : lecturaArchivo(dgvcontenido, ruta, " ", 2, 0)
            Case "pr" : lecturaArchivo(dgvcontenido, ruta, " ", 1, 0)
            Case "ta" : lecturaArchivo(dgvcontenido, ruta, vbTab, 1, 0)
        End Select
        eliminarPrimeralineaDGV(dgvcontenido)
        btnNuevo.Enabled = True
        btnExportUnit.Enabled = True
        btnExportMasivo.Enabled = True
        lbArchivos.Enabled = True
        dgvcontenido.Enabled = True
    End Sub
    Sub obtenertotal(ByVal ruta As String, ByRef conteo As String, ByRef filasT As Integer)
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""
        Dim fila As Integer = 0

        Dim id_medidor As String = "" ''Número de identificación=06677067
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                fila += 1
            End If
        Loop Until sLine Is Nothing

        filasT = fila

        Dim tipo_medidor As String
        tipo_medidor = ruta.Substring(ruta.LastIndexOf(".") + 1, 2)
        'MsgBox(tipo_medidor)

        Select Case tipo_medidor
            Case "LP" : conteo = fila - 3
            Case "pr" : conteo = fila - 1
            Case "ta" : conteo = fila - 2
        End Select

        If exportar = 1 Then
            lblregistros.Text = conteo
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = fila
        End If

        objReader.Close()
    End Sub
    Sub eliminarPrimeralineaDGV(ByVal DGV As DataGridView)
        If (DGV.Item(4, 0).Value.ToString().Substring(8, 4) = "0000") Then
            DGV.Rows.RemoveAt(0)
        End If
    End Sub
    Sub lecturaArchivo(ByVal tabla As DataGridView, ByVal ruta As String, ByVal caracter As String, ByVal numfila As Integer, ByRef medidor As String)
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""
        Dim fila As Integer = 0
        Dim fila2 As Integer = 0
        Dim primero As Integer = 1 'verificar la primera línea de lecturas en el archivo de texto
        Dim codsuministro As String = ""
        Dim FTEA As String = ""

        tabla.AllowUserToAddRows = False

        Dim id_medidor As String = "" ''Número de identificación=06677067	Factor U=1	Factor I=1
        Do
            sLine = objReader.ReadLine()

            If Not sLine Is Nothing Then

                If fila = 0 Then
                    If exportar = 2 Then
                        id_medidor = medidor
                    Else
                        id_medidor = CInt(Val(lbArchivos.SelectedItem))
                    End If
                    'consulta a la DB
                    MBaseDatos.ConsultaCodSumFT(CStr(id_medidor), codsuministro, FTEA)
                    fila += 1
                Else
                    If fila2 >= numfila Then
                        'MsgBox(sLine, MsgBoxStyle.Information, "leyendo")imero = primero + 1
                        agregarFilaCaso(tabla, sLine, caracter, id_medidor, codsuministro, FTEA, ruta)
                    End If
                    'txtruta.Text = sLine
                    'MsgBox(sLine, MsgBoxStyle.Information, "leyendo")
                    fila2 += 1
                End If
            End If
            If exportar = 1 Then
                ProgressBar1.Value = fila2
            End If
            If exportar = 2 Then
                conteoTotal = conteoTotal + 1
                ProgressBar1.Value = conteoTotal
            End If
        Loop Until sLine Is Nothing

        'MsgBox(fila2, MsgBoxStyle.Information, "leyendo")
        objReader.Close()
        If exportar = 1 Then
            ProgressBar1.Value = 0
        End If
    End Sub

    Sub agregarFilaCaso(ByVal tabla As DataGridView, ByVal linea As String, ByVal caracter As String, ByVal id_medidor As Integer, ByVal codsuministro As String, ByVal FTEA As String, ByVal ruta As String)
        Dim arreglo() As String = linea.Split(caracter)
        Dim cod_empresa As String = "ELS"
        Dim cod_barra As String = "B0229"
        Dim fech_hora As String = ""
        Dim hora As Integer = 0
        Dim fech As Date
        Dim mes As String = ""
        Dim Potencia As String

        'Dim codsuministro As String = ""
        'Dim FTEA As String = ""
        Dim EA As String
        Dim Potencia1 As Double
        Dim EA1 As Double

        Dim tipo_medidor As String
        tipo_medidor = ruta.Substring(ruta.LastIndexOf(".") + 1, 2)
        'MsgBox(tipo_medidor)
        Select Case tipo_medidor
            Case "pr"
                'MsgBox(arreglo(12))
                'MsgBox(arreglo(13))
                'MsgBox(arreglo(14))
                'MsgBox(arreglo(15))
                'MsgBox(arreglo(16))
                fech = CStr(arreglo(13).Substring(1, 8))
                fech_hora = CStr(fech.Year) & (If(fech.Month < 10, 0 & fech.Month, fech.Month)) & CStr(If(fech.Day < 10, 0 & fech.Day, fech.Day)) &
                            (Replace(arreglo(14).Substring(1, 5), ":", ""))
                mes = fech.Month
                Potencia = arreglo(16)
                Potencia = Potencia.Replace(";", "")
                'MsgBox(CDbl(Potencia))
                'MsgBox(FTEA)
                'MsgBox(Val(FTEA))
                'MsgBox(Val(Potencia) * Val(FTEA))
                EA = (CDbl(Potencia) * CDbl(FTEA)) / 4
                EA = Format(Convert.ToDouble(EA), "###0.0000")
        'MsgBox(EA)
            Case "LP"
                'MsgBox(arreglo(1)) ' hora    / 12:00:00
                'MsgBox(arreglo(2)) 'am - fm  / a.m.;
                'MsgBox(arreglo(4))
                If arreglo(1) = "12:00:00" And arreglo(2) = "a.m.;" Then arreglo(1) = "00:00:00"
                If arreglo(1) = "12:15:00" And arreglo(2) = "a.m.;" Then arreglo(1) = "00:15:00"
                If arreglo(1) = "12:30:00" And arreglo(2) = "a.m.;" Then arreglo(1) = "00:30:00"
                If arreglo(1) = "12:45:00" And arreglo(2) = "a.m.;" Then arreglo(1) = "00:45:00"

                If arreglo(2) = "p.m.;" Then
                    'MsgBox(arreglo(1).Substring(0, 1))
                    If Val(arreglo(1).Substring(0, 2)) >= 1 And Val(arreglo(1).Substring(0, 2)) <= 11 Then
                        hora = arreglo(1).Substring(0, 2)
                        hora = hora + 12
                        arreglo(1) = hora & arreglo(1).Remove(0, 2)
                        'MsgBox(arreglo(1))
                    End If
                End If

                fech = CStr(arreglo(0))
                fech_hora = CStr(fech.Year) & (If(fech.Month < 10, 0 & fech.Month, fech.Month)) & CStr(If(fech.Day < 10, 0 & fech.Day, fech.Day)) & (Replace(arreglo(1).Substring(0, 5), ":", ""))
                mes = fech.Month
                Potencia = arreglo(4)
                Potencia = Potencia.Replace(";", "")
                'MsgBox(CDbl(Potencia))
                'MsgBox(FTEA)
                'MsgBox(Val(FTEA))
                'MsgBox(Val(Potencia) * Val(FTEA))
                EA = (CDbl(Potencia) * CDbl(FTEA)) / 4
                'MsgBox(EA)
                EA = Format(Convert.ToDouble(EA), "###0.0000")
            Case "ta"
                'MsgBox(arreglo(1)) ' hora y am - fm / 04:45 a.m.
                'MsgBox(arreglo(2))
                If arreglo(1) = "12:00 a.m." Then arreglo(1) = "00:00 a.m."
                If arreglo(1) = "12:15 a.m." Then arreglo(1) = "00:15 a.m."
                If arreglo(1) = "12:30 a.m." Then arreglo(1) = "00:30 a.m."
                If arreglo(1) = "12:45 a.m." Then arreglo(1) = "00:45 a.m."

                If arreglo(1).Contains("p.m.") Then
                    'MsgBox(arreglo(1).Substring(0, 1))
                    If Val(arreglo(1).Substring(0, 2)) >= 1 And Val(arreglo(1).Substring(0, 2)) <= 11 Then
                        hora = arreglo(1).Substring(0, 2)
                        hora = hora + 12
                        arreglo(1) = hora & arreglo(1).Remove(0, 2)
                        'MsgBox(arreglo(1))
                    End If
                End If

                fech = CStr(arreglo(0))
                fech_hora = CStr(fech.Year) & (If(fech.Month < 10, 0 & fech.Month, fech.Month)) & CStr(If(fech.Day < 10, 0 & fech.Day, fech.Day)) &
                    (Replace(arreglo(1).Substring(0, 5), ":", ""))
                mes = fech.Month
                Potencia = arreglo(3)
                Potencia = Potencia.Replace(";", "")
                'MsgBox(CDbl(Potencia))
                'MsgBox(FTEA)
                'MsgBox(Val(FTEA))
                'MsgBox(Val(Potencia) * Val(FTEA))
                EA = (CDbl(Potencia) * CDbl(FTEA)) / 4
                EA = Format(Convert.ToDouble(EA), "###0.0000")
        End Select
        EA = Replace(EA, ",", ".")
        tabla.Rows.Add(mes, cod_empresa, IIf(codsuministro = "", "No Existe", codsuministro), cod_barra, fech_hora, EA)
    End Sub

    Private Sub btnExportUnit_Click(sender As Object, e As EventArgs) Handles btnExportUnit.Click

    End Sub
End Class
