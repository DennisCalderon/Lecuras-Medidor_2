Imports System.IO
Module MExportar
    Public Sub ExportToExcel(ByVal DGV As DataGridView, ByVal FlNm As String, ByVal exportar As Integer)
        Dim fs As New StreamWriter(FlNm, False)
        With fs
            .WriteLine("<?xml version=""1.0""?>")
            .WriteLine("<?mso-application progid=""Excel.Sheet""?>")
            .WriteLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"">")
            .WriteLine("    <Styles>")
            .WriteLine("        <Style ss:ID=""hdr"">")
            .WriteLine("            <Alignment ss:Horizontal=""Center""/>")
            .WriteLine("            <Borders>")
            .WriteLine("                <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("                <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("                <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("            </Borders>")
            .WriteLine("            <Font ss:FontName=""Calibri"" ss:Size=""11"" ss:Bold=""1""/>") 'SET FONT
            .WriteLine("        </Style>")
            .WriteLine("        <Style ss:ID=""ksg"">")
            .WriteLine("            <Alignment ss:Vertical=""Bottom""/>")
            .WriteLine("            <Borders/>")
            .WriteLine("            <Font ss:FontName=""Calibri""/>") 'SET FONT
            .WriteLine("        </Style>")
            .WriteLine("        <Style ss:ID=""isi"">")
            .WriteLine("            <Borders>")
            .WriteLine("                <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("                <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("                <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("                <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("            </Borders>")
            .WriteLine("            <Font ss:FontName=""Calibri"" ss:Size=""10""/>") 'SET FONT
            .WriteLine("        </Style>")
            .WriteLine("    </Styles>")

            If exportar = 1 Then
                If DGV.Name = "Hoja" Then
                    .WriteLine("    <Worksheet ss:Name=""Hoja1"">") 'SET NAMA SHEET
                    .WriteLine("        <Table>")
                    .WriteLine("            <Column ss:Width=""40""/>") '   "Mes"
                    .WriteLine("            <Column ss:Width=""93""/>") '   "Código de Empresa"
                    .WriteLine("            <Column ss:Width=""84""/>") '   "Código de Suministro"
                    .WriteLine("            <Column ss:Width=""100""/>") '  "Código de Barra de Compra"
                    .WriteLine("            <Column ss:Width=""84""/>") '   "Fecha / Hora"
                    .WriteLine("            <Column ss:Width=""90""/>") '   "EA"
                End If
                'AUTO SET HEADER
                .WriteLine("            <Row ss:StyleID=""ksg"">")
                For i As Integer = 0 To DGV.Columns.Count - 1 'SET HEADER
                    Application.DoEvents()
                    .WriteLine("            <Cell ss:StyleID=""hdr"">")
                    .WriteLine("                <Data ss:Type=""String"">{0}</Data>", DGV.Columns.Item(i).HeaderText)
                    .WriteLine("            </Cell>")
                Next
                .WriteLine("            </Row>")

                For intRow As Integer = 0 To DGV.RowCount - 1
                    Application.DoEvents()
                    '.WriteLine("        <Row ss:StyleID=""ksg"" ss:utoFitHeight =""0"">")
                    'For intCol As Integer = 0 To DGV.Columns.Count - 1
                    '    Application.DoEvents()
                    '    .WriteLine("        <Cell ss:StyleID=""isi"">")
                    '    .WriteLine("            <Data ss:Type=""String"">{0}</Data>", DGV.Item(intCol, intRow).Value.ToString)
                    '    .WriteLine("        </Cell>")
                    'Next
                    .WriteLine("        <Row ss:StyleID=""ksg"" ss:utoFitHeight =""0"">")

                    .WriteLine("        <Cell ss:StyleID=""isi"">")
                    .WriteLine("            <Data ss:Type=""Number"">{0}</Data>", DGV.Item(0, intRow).Value.ToString)
                    .WriteLine("        </Cell>")
                    .WriteLine("        <Cell ss:StyleID=""isi"">")
                    .WriteLine("            <Data ss:Type=""String"">{0}</Data>", DGV.Item(1, intRow).Value.ToString)
                    .WriteLine("        </Cell>")
                    .WriteLine("        <Cell ss:StyleID=""isi"">")
                    .WriteLine("            <Data ss:Type=""Number"">{0}</Data>", DGV.Item(2, intRow).Value.ToString)
                    .WriteLine("        </Cell>")
                    .WriteLine("        <Cell ss:StyleID=""isi"">")
                    .WriteLine("            <Data ss:Type=""String"">{0}</Data>", DGV.Item(3, intRow).Value.ToString)
                    .WriteLine("        </Cell>")
                    .WriteLine("        <Cell ss:StyleID=""isi"">")
                    .WriteLine("            <Data ss:Type=""Number"">{0}</Data>", DGV.Item(4, intRow).Value.ToString)
                    .WriteLine("        </Cell>")
                    .WriteLine("        <Cell ss:StyleID=""isi"">")
                    .WriteLine("            <Data ss:Type=""Number"">{0}</Data>", DGV.Item(5, intRow).Value.ToString)
                    .WriteLine("        </Cell>")

                    .WriteLine("        </Row>")
                Next
                .WriteLine("        </Table>")
                .WriteLine("    </Worksheet>")

                .WriteLine("</Workbook>")
            End If
            .Close()
        End With
    End Sub
    Public Sub IntegridadLecturas(ByVal id_medidorserie As String, ByVal dgv As DataGridView, ByVal NombreSector As String, ByVal Report As String)
        Dim id_serie As Integer
        Dim anio As String
        Dim mes As String
        Dim cant_dias As Integer
        Dim cant_lecturas As Integer
        id_serie = CInt(Val(id_medidorserie))

        Dim ListaParaComparar As New List(Of String)
        Dim ListaCompleta As New List(Of String)

        anio = dgv.Item(4, 1).Value.ToString().Substring(0, 4) 'obtenemo el formato 201807010015 -- 2018-07-01-00-15
        mes = dgv.Item(4, 1).Value.ToString().Substring(4, 2)

        cant_dias = System.DateTime.DaysInMonth(anio, mes) 'Obtiene la cantidad de días indicandole el Año y el Mes
        cant_lecturas = (cant_dias * 4) 'cantidad de lecturas por mes

        For intdias As Integer = 1 To cant_dias
            For inthoras As Integer = 0 To 23
                ListaCompleta.Add(anio & mes & IIf(intdias < 10, "0" & intdias, intdias) & IIf(inthoras < 10, "0" & inthoras, inthoras) & "00")
                ListaCompleta.Add(anio & mes & IIf(intdias < 10, "0" & intdias, intdias) & IIf(inthoras < 10, "0" & inthoras, inthoras) & "15")
                ListaCompleta.Add(anio & mes & IIf(intdias < 10, "0" & intdias, intdias) & IIf(inthoras < 10, "0" & inthoras, inthoras) & "30")
                ListaCompleta.Add(anio & mes & IIf(intdias < 10, "0" & intdias, intdias) & IIf(inthoras < 10, "0" & inthoras, inthoras) & "45")
            Next
        Next
        ListaCompleta.Add(anio & IIf((Val(mes) + 1) < 10, "0" & Val(mes) + 1, Val(mes) + 1) & "010000")
        If ListaCompleta.Item(0).Contains("0000") Then
            ListaCompleta.RemoveAt(0)
        End If

        For intRow As Integer = 0 To dgv.RowCount - 1
            ListaParaComparar.Add(dgv.Item(4, intRow).Value.ToString())
        Next

        Dim ListadeDiferencias As List(Of String) = ListaCompleta.Except(ListaParaComparar).ToList()

        If NombreSector = "" Then
            MBaseDatos.ConsultaSector(id_serie, NombreSector)
            If NombreSector = "" Then NombreSector = "No Tiene"
        End If

        If ListadeDiferencias.Count > 0 Then
            Dim texto As New StreamWriter(Report, True)
            With texto
                .WriteLine("Nombre del Archivo : {0}", id_medidorserie)
                .WriteLine("Nombre del Sector : {0}", NombreSector)
                .WriteLine("Lecturas Faltantes:")
                For ii = 0 To ListadeDiferencias.Count - 1
                    Dim fechaReg As String
                    Dim horaReg As String
                    Dim imprimerReg As String
                    fechaReg = ListadeDiferencias.Item(ii).Substring(0, 4) & "-" & ListadeDiferencias.Item(ii).Substring(4, 2) & "-" & ListadeDiferencias.Item(ii).Substring(6, 2)
                    horaReg = ListadeDiferencias.Item(ii).Substring(8, 2) & ":" & ListadeDiferencias.Item(ii).Substring(10, 2)
                    imprimerReg = "Fecha :" & fechaReg & " y Hora: " & horaReg
                    .WriteLine("                   {0}", imprimerReg)
                Next ii
                .WriteLine("")
                .WriteLine("")
                .Close()
            End With
        End If


        'Module1.integridadLecturas = ListadeDiferencias
        '
        'Dim formDB As New IntegridadLecturas
        'formDB.ShowDialog()

        ListaParaComparar.Clear()
        ListaCompleta.Clear()
    End Sub
    Public Sub AddExcelHeader(ByVal DGV As DataGridView, ByVal NameSector As String, ByVal FlNm As String)
        Dim fs As New StreamWriter(FlNm, True)
        With fs
            If DGV.Name = "Hoja" Then
                .WriteLine("    <Worksheet ss:Name=""" & NameSector & """>") 'SET NAMA SHEET
                .WriteLine("        <Table>")
                .WriteLine("            <Column ss:Width=""40""/>") '   "Mes"
                .WriteLine("            <Column ss:Width=""93""/>") '   "Código de Empresa"
                .WriteLine("            <Column ss:Width=""84""/>") '   "Código de Suministro"
                .WriteLine("            <Column ss:Width=""100""/>") '  "Código de Barra de Compra"
                .WriteLine("            <Column ss:Width=""84""/>") '   "Fecha / Hora"
                .WriteLine("            <Column ss:Width=""90""/>") '   "EA"
            End If
            'AUTO SET HEADER
            .WriteLine("            <Row ss:StyleID=""ksg"">")
            For i As Integer = 0 To DGV.Columns.Count - 1 'SET HEADER
                Application.DoEvents()
                .WriteLine("            <Cell ss:StyleID=""hdr"">")
                .WriteLine("                <Data ss:Type=""String"">{0}</Data>", DGV.Columns.Item(i).HeaderText)
                .WriteLine("            </Cell>")
            Next
            .WriteLine("            </Row>")

        End With
        fs.Close()
    End Sub
    Public Sub AddExcelBody(ByVal DGV As DataGridView, ByVal FlNm As String)
        Dim fs As New StreamWriter(FlNm, True)
        With fs
            For intRow As Integer = 0 To DGV.RowCount - 1
                Application.DoEvents()
                .WriteLine("        <Row ss:StyleID=""ksg"" ss:utoFitHeight =""0"">")

                .WriteLine("        <Cell ss:StyleID=""isi"">")
                .WriteLine("            <Data ss:Type=""Number"">{0}</Data>", DGV.Item(0, intRow).Value.ToString)
                .WriteLine("        </Cell>")
                .WriteLine("        <Cell ss:StyleID=""isi"">")
                .WriteLine("            <Data ss:Type=""String"">{0}</Data>", DGV.Item(1, intRow).Value.ToString)
                .WriteLine("        </Cell>")
                .WriteLine("        <Cell ss:StyleID=""isi"">")
                .WriteLine("            <Data ss:Type=""Number"">{0}</Data>", DGV.Item(2, intRow).Value.ToString)
                .WriteLine("        </Cell>")
                .WriteLine("        <Cell ss:StyleID=""isi"">")
                .WriteLine("            <Data ss:Type=""String"">{0}</Data>", DGV.Item(3, intRow).Value.ToString)
                .WriteLine("        </Cell>")
                .WriteLine("        <Cell ss:StyleID=""isi"">")
                .WriteLine("            <Data ss:Type=""Number"">{0}</Data>", DGV.Item(4, intRow).Value.ToString)
                .WriteLine("        </Cell>")
                .WriteLine("        <Cell ss:StyleID=""isi"">")
                .WriteLine("            <Data ss:Type=""Number"">{0}</Data>", DGV.Item(5, intRow).Value.ToString)
                .WriteLine("        </Cell>")

                .WriteLine("        </Row>")
                'For intCol As Integer = 0 To DGV.Columns.Count - 1
                '    Application.DoEvents()
                '    .WriteLine("        <Cell ss:StyleID=""isi"">")
                '    .WriteLine("            <Data ss:Type=""String"">{0}</Data>", DGV.Item(intCol, intRow).Value.ToString)
                '    .WriteLine("        </Cell>")
                'Next
                '.WriteLine("        </Row>")
            Next
            .Close()
        End With
    End Sub
End Module
