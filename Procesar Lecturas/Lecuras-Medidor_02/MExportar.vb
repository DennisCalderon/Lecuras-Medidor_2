﻿Imports System.IO
Module MExportar
    Public Sub ExportToExcel(ByVal DGV As DataGridView, ByVal FlNm As String)
        Dim fs As New StreamWriter(FlNm, False)
        With fs
            .WriteLine("<?xml version=""1.0""?> ")
            .WriteLine("<?mso-application progid=""Excel.Sheet""?>  ")
            .WriteLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""  ")
            .WriteLine(" xmlns:o=""urn:schemas-microsoft-com:office:office""")
            .WriteLine(" xmlns:x=""urn:schemas-microsoft-com:office:excel"" ")
            .WriteLine(" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""")
            .WriteLine(" xmlns:html=""http://www.w3.org/TR/REC-html40""> ")
            .WriteLine(" <DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office""> ")
            .WriteLine("  <Version>16.00</Version>")
            .WriteLine(" </DocumentProperties>  ")
            .WriteLine(" <OfficeDocumentSettings xmlns=""urn:schemas-microsoft-com:office:office"">  ")
            .WriteLine("  <AllowPNG/>   ")
            .WriteLine(" </OfficeDocumentSettings>")
            .WriteLine(" <ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel""> ")
            .WriteLine("  <WindowHeight>9630</WindowHeight>")
            .WriteLine("  <WindowWidth>24000</WindowWidth> ")
            .WriteLine("  <WindowTopX>0</WindowTopX>  ")
            .WriteLine("  <WindowTopY>0</WindowTopY>  ")
            .WriteLine("  <ProtectStructure>False</ProtectStructure>")
            .WriteLine("  <ProtectWindows>False</ProtectWindows>")
            .WriteLine(" </ExcelWorkbook>")
            .WriteLine(" <Styles> ")
            .WriteLine("  <Style ss:ID=""Default"" ss:Name=""Normal"">   ")
            .WriteLine("   <Alignment ss:Vertical=""Bottom""/>")
            .WriteLine("   <Borders/>   ")
            .WriteLine("   <Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000""/>  ")
            .WriteLine("   <Interior/>  ")
            .WriteLine("   <NumberFormat/>   ")
            .WriteLine("   <Protection/>")
            .WriteLine("  </Style>")
            .WriteLine("  <Style ss:ID=""s62""> ")
            .WriteLine("   <NumberFormat ss:Format=""0""/> ")
            .WriteLine("  </Style>")
            .WriteLine("  <Style ss:ID=""s63""> ")
            .WriteLine("   <NumberFormat ss:Format=""0.0000""/>")
            .WriteLine("  </Style>")
            .WriteLine("  <Style ss:ID=""s64""> ")
            .WriteLine("   <Alignment ss:Vertical=""Bottom""/>")
            .WriteLine("   <Borders/>   ")
            .WriteLine("   <Font ss:FontName=""Calibri""/> ")
            .WriteLine("   <Interior/>  ")
            .WriteLine("   <NumberFormat/>   ")
            .WriteLine("   <Protection/>")
            .WriteLine("  </Style>")
            .WriteLine("  <Style ss:ID=""s68""> ")
            .WriteLine("   <Alignment ss:Vertical=""Bottom""/>")
            .WriteLine("   <Borders>")
            .WriteLine("		<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("		<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("		<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("		<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("   </Borders>   ")
            .WriteLine("   <Font ss:FontName=""Calibri""/> ")
            .WriteLine("   <Interior/>  ")
            .WriteLine("   <NumberFormat/>   ")
            .WriteLine("   <Protection/>")
            .WriteLine("  </Style>")
            .WriteLine("  <Style ss:ID=""s69""> ")
            .WriteLine("   <Alignment ss:Vertical=""Bottom""/>")
            .WriteLine("   <Borders>")
            .WriteLine("		<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("		<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("		<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("		<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("   </Borders>   ")
            .WriteLine("   <Font ss:FontName=""Calibri""/> ")
            .WriteLine("   <Interior/>  ")
            .WriteLine("   <NumberFormat ss:Format=""0""/> ")
            .WriteLine("   <Protection/>")
            .WriteLine("  </Style>")
            .WriteLine("  <Style ss:ID=""s70""> ")
            .WriteLine("   <Alignment ss:Vertical=""Bottom""/>")
            .WriteLine("   <Borders>")
            .WriteLine("		<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("		<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("		<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("		<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("   </Borders>   ")
            .WriteLine("   <Font ss:FontName=""Calibri""/> ")
            .WriteLine("   <Interior/>  ")
            .WriteLine("   <NumberFormat ss:Format=""0.0000""/>")
            .WriteLine("   <Protection/>")
            .WriteLine("  </Style>")
            .WriteLine("  <Style ss:ID=""s71""> ")
            .WriteLine("   <Alignment ss:Vertical=""Bottom""/>")
            .WriteLine("   <Borders/>   ")
            .WriteLine("   <Font ss:FontName=""Calibri""/> ")
            .WriteLine("   <Interior/>  ")
            .WriteLine("   <NumberFormat ss:Format=""0.0000;[Red]0.0000""/> ")
            .WriteLine("   <Protection/>")
            .WriteLine("  </Style>")
            .WriteLine("  <Style ss:ID=""s78""> ")
            .WriteLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>")
            .WriteLine("   <Borders>")
            .WriteLine("		<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("		<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("		<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("   </Borders>   ")
            .WriteLine("   <Font ss:FontName=""Calibri"" ss:Size=""11"" ss:Bold=""1""/>")
            .WriteLine("   <Interior ss:Color=""#FFFF00"" ss:Pattern=""Solid""/>  ")
            .WriteLine("   <NumberFormat/>   ")
            .WriteLine("   <Protection/>")
            .WriteLine("  </Style>")
            .WriteLine("  <Style ss:ID=""s79""> ")
            .WriteLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>")
            .WriteLine("   <Borders>")
            .WriteLine("		<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("		<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("		<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("   </Borders>   ")
            .WriteLine("   <Font ss:FontName=""Calibri"" ss:Size=""11"" ss:Bold=""1""/>")
            .WriteLine("   <Interior ss:Color=""#FFFF00"" ss:Pattern=""Solid""/>  ")
            .WriteLine("   <NumberFormat ss:Format=""0""/> ")
            .WriteLine("   <Protection/>")
            .WriteLine("  </Style>")
            .WriteLine("  <Style ss:ID=""s80""> ")
            .WriteLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>")
            .WriteLine("   <Borders>")
            .WriteLine("		<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("		<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("		<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("   </Borders>   ")
            .WriteLine("   <Font ss:FontName=""Calibri"" ss:Size=""11"" ss:Bold=""1""/>")
            .WriteLine("   <Interior ss:Color=""#FFFF00"" ss:Pattern=""Solid""/>  ")
            .WriteLine("   <NumberFormat ss:Format=""0.0000""/>")
            .WriteLine("   <Protection/>")
            .WriteLine("  </Style>")
            .WriteLine(" </Styles>")

            If DGV.Name = "Hoja" Then
                .WriteLine(" <Worksheet ss:Name=""Hoja1"">") ' nombre de la hoja
                .WriteLine("  <Table ss:ExpandedColumnCount=""7"" x:FullColumns=""1""") 'ss:ExpandedRowCount=""2881""
                .WriteLine("   x:FullRows=""1"" ss:DefaultColumnWidth=""60"" ss:DefaultRowHeight=""15""> ")
                .WriteLine("   <Column ss:Width=""39.75""/>")                       '   "Mes"
                .WriteLine("   <Column ss:Width=""93""/>  ")                        '   "Código de Empresa"
                .WriteLine("   <Column ss:Width=""84""/>  ")                        '   "Código de Suministro"
                .WriteLine("   <Column ss:Width=""99.75""/>")                       '  "Código de Barra de Compra"
                .WriteLine("   <Column ss:StyleID=""s62"" ss:Width=""84""/>  ")     '   "Fecha / Hora"
                .WriteLine("   <Column ss:StyleID=""s63"" ss:Width=""90""/>  ")     '   "EA"
            End If
            'AUTO SET HEADER
            .WriteLine("   <Row ss:AutoFitHeight=""0"" ss:Height=""40.5"" ss:StyleID=""s64"">   ")
            .WriteLine("		<Cell ss:StyleID=""s78""><Data ss:Type=""String"">Mes</Data></Cell> ")
            .WriteLine("		<Cell ss:StyleID=""s78""><Data ss:Type=""String"">Código de Empresa</Data></Cell> ")
            .WriteLine("		<Cell ss:StyleID=""s78""><Data ss:Type=""String"">Código de Suministro</Data></Cell>   ")
            .WriteLine("		<Cell ss:StyleID=""s78""><Data ss:Type=""String"">Código de Barra de Compra</Data></Cell> ")
            .WriteLine("		<Cell ss:StyleID=""s79""><Data ss:Type=""String"">Fecha / Hora</Data></Cell>")
            .WriteLine("		<Cell ss:StyleID=""s80""><Data ss:Type=""String"">EA</Data></Cell>  ")
            .WriteLine("   </Row> ")

            For intRow As Integer = 0 To DGV.RowCount - 1
                Application.DoEvents()
                .WriteLine("   <Row ss:AutoFitHeight=""0"" ss:Height=""12.75"" ss:StyleID=""s64"" ss:utoFitHeight=""0"">  ")

                .WriteLine("		<Cell ss:StyleID=""s68""><Data ss:Type=""Number"">{0}</Data></Cell>", DGV.Item(0, intRow).Value.ToString)
                .WriteLine("		<Cell ss:StyleID=""s68""><Data ss:Type=""String"">{0}</Data></Cell>", DGV.Item(1, intRow).Value.ToString)
                .WriteLine("		<Cell ss:StyleID=""s68""><Data ss:Type=""Number"">{0}</Data></Cell>", DGV.Item(2, intRow).Value.ToString)
                .WriteLine("		<Cell ss:StyleID=""s68""><Data ss:Type=""String"">{0}</Data></Cell>", DGV.Item(3, intRow).Value.ToString)
                .WriteLine("		<Cell ss:StyleID=""s69""><Data ss:Type=""Number"">{0}</Data></Cell>", DGV.Item(4, intRow).Value.ToString)
                .WriteLine("		<Cell ss:StyleID=""s70""><Data ss:Type=""Number"">{0}</Data></Cell>", DGV.Item(5, intRow).Value.ToString)

                .WriteLine("   </Row>")
            Next
            .WriteLine("  </Table>")
            .WriteLine("  <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">   ")
            .WriteLine("   <Unsynced/>  ")
            .WriteLine("   <Print>")
            .WriteLine("<ValidPrinterInfo/> ")
            .WriteLine("<PaperSizeIndex>9</PaperSizeIndex>")
            .WriteLine("<HorizontalResolution>300</HorizontalResolution>")
            .WriteLine("<VerticalResolution>300</VerticalResolution> ")
            .WriteLine("   </Print>")
            .WriteLine("   <Selected/>  ")
            .WriteLine("   <Panes>")
            .WriteLine("<Pane>")
            .WriteLine("<Number>3</Number> ")
            .WriteLine("<RangeSelection>R1C1:R1C6</RangeSelection>  ")
            .WriteLine("</Pane>")
            .WriteLine("   </Panes>")
            .WriteLine("   <ProtectObjects>False</ProtectObjects>   ")
            .WriteLine("   <ProtectScenarios>False</ProtectScenarios>")
            .WriteLine("  </WorksheetOptions>")
            .WriteLine(" </Worksheet>   ")
            .WriteLine("</Workbook>")
            .Close()
        End With
        fs.Close()
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
    Public Sub ExportToExcelMasivo(ByVal FlNm As String)
        Dim fs As New StreamWriter(FlNm, False)
        With fs
            .WriteLine("<?xml version=""1.0""?> ")
            .WriteLine("<?mso-application progid=""Excel.Sheet""?> ")
            .WriteLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""   ")
            .WriteLine(" xmlns:o=""urn:schemas-microsoft-com:office:office""")
            .WriteLine(" xmlns:x=""urn:schemas-microsoft-com:office:excel"" ")
            .WriteLine(" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""   ")
            .WriteLine(" xmlns:html=""http://www.w3.org/TR/REC-html40"">")
            .WriteLine(" <DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office""> ")
            .WriteLine("  <Author>Dennis Severino Calderón Mamani</Author>  ")
            .WriteLine("  <LastAuthor>Dennis Severino Calderón Mamani</LastAuthor>   ")
            .WriteLine("  <Created>2019-07-02T18:40:47Z</Created>  ")
            .WriteLine("  <Version>16.00</Version>  ")
            .WriteLine(" </DocumentProperties>  ")
            .WriteLine(" <OfficeDocumentSettings xmlns=""urn:schemas-microsoft-com:office:office""> ")
            .WriteLine("  <AllowPNG/>")
            .WriteLine(" </OfficeDocumentSettings>  ")
            .WriteLine(" <ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel"">  ")
            .WriteLine("  <WindowHeight>9630</WindowHeight>  ")
            .WriteLine("  <WindowWidth>24000</WindowWidth>   ")
            .WriteLine("  <WindowTopX>0</WindowTopX>")
            .WriteLine("  <WindowTopY>0</WindowTopY>")
            .WriteLine("  <ProtectStructure>False</ProtectStructure> ")
            .WriteLine("  <ProtectWindows>False</ProtectWindows>   ")
            .WriteLine(" </ExcelWorkbook>  ")
            .WriteLine(" <Styles>")
            .WriteLine("  <Style ss:ID=""Default"" ss:Name=""Normal"">  ")
            .WriteLine("   <Alignment ss:Vertical=""Bottom""/> ")
            .WriteLine("   <Borders/>")
            .WriteLine("   <Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000""/>  ")
            .WriteLine("   <Interior/> ")
            .WriteLine("   <NumberFormat/> ")
            .WriteLine("   <Protection/>   ")
            .WriteLine("  </Style>   ")
            .WriteLine("  <Style ss:ID=""s65""> ")
            .WriteLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>")
            .WriteLine("   <Borders> ")
            .WriteLine("      <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("      <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("      <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("   </Borders>")
            .WriteLine("   <Font ss:FontName=""Calibri"" ss:Size=""11"" ss:Bold=""1""/>")
            .WriteLine("   <Interior ss:Color=""#FFFF00"" ss:Pattern=""Solid""/> ")
            .WriteLine("   <NumberFormat/> ")
            .WriteLine("   <Protection/>   ")
            .WriteLine("  </Style>   ")
            .WriteLine("  <Style ss:ID=""s66""> ")
            .WriteLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>")
            .WriteLine("   <Borders> ")
            .WriteLine("      <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("      <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("      <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("   </Borders>")
            .WriteLine("   <Font ss:FontName=""Calibri"" ss:Size=""11"" ss:Bold=""1""/>")
            .WriteLine("   <Interior ss:Color=""#FFFF00"" ss:Pattern=""Solid""/> ")
            .WriteLine("   <NumberFormat ss:Format=""0""/>   ")
            .WriteLine("   <Protection/>   ")
            .WriteLine("  </Style>   ")
            .WriteLine("  <Style ss:ID=""s67""> ")
            .WriteLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>")
            .WriteLine("   <Borders> ")
            .WriteLine("      <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("      <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("      <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("   </Borders>")
            .WriteLine("   <Font ss:FontName=""Calibri"" ss:Size=""11"" ss:Bold=""1""/>")
            .WriteLine("   <Interior ss:Color=""#FFFF00"" ss:Pattern=""Solid""/> ")
            .WriteLine("   <NumberFormat ss:Format=""0.0000""/>")
            .WriteLine("   <Protection/>   ")
            .WriteLine("  </Style>   ")
            .WriteLine("  <Style ss:ID=""s68""> ")
            .WriteLine("   <Alignment ss:Vertical=""Bottom""/> ")
            .WriteLine("   <Borders> ")
            .WriteLine("      <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("      <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("      <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("      <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("   </Borders>")
            .WriteLine("   <Font ss:FontName=""Calibri""/>   ")
            .WriteLine("   <Interior/> ")
            .WriteLine("   <NumberFormat/> ")
            .WriteLine("   <Protection/>   ")
            .WriteLine("  </Style>   ")
            .WriteLine("  <Style ss:ID=""s69""> ")
            .WriteLine("   <Alignment ss:Vertical=""Bottom""/> ")
            .WriteLine("   <Borders> ")
            .WriteLine("      <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("      <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("      <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("      <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("   </Borders>")
            .WriteLine("   <Font ss:FontName=""Calibri""/>   ")
            .WriteLine("   <Interior/> ")
            .WriteLine("   <NumberFormat ss:Format=""0""/>   ")
            .WriteLine("   <Protection/>   ")
            .WriteLine("  </Style>   ")
            .WriteLine("  <Style ss:ID=""s70""> ")
            .WriteLine("   <Alignment ss:Vertical=""Bottom""/> ")
            .WriteLine("   <Borders> ")
            .WriteLine("      <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("      <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("      <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>  ")
            .WriteLine("      <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/> ")
            .WriteLine("   </Borders>")
            .WriteLine("   <Font ss:FontName=""Calibri""/>   ")
            .WriteLine("   <Interior/> ")
            .WriteLine("   <NumberFormat ss:Format=""0.0000""/>")
            .WriteLine("   <Protection/>   ")
            .WriteLine("  </Style>   ")
            .WriteLine(" </Styles>   ")
        End With
        fs.Close()
    End Sub
    Public Sub AddExcelHeader(ByVal NameSector As String, ByVal FlNm As String)
        Dim fs As New StreamWriter(FlNm, True)
        With fs
            .WriteLine("  <Worksheet ss:Name=""{0}"">", NameSector)
            .WriteLine("  <Table ss:ExpandedColumnCount=""6"" x:FullColumns=""1""  ") 'ss:ExpandedRowCount=""4"" 
            .WriteLine("   x:FullRows=""1"" ss:DefaultColumnWidth=""60"" ss:DefaultRowHeight=""15"">")
            .WriteLine("   <Column ss:Width=""60.75""/>  ")
            .WriteLine("   <Column ss:Index=""3"" ss:Width=""60.75""/>  ")
            .WriteLine("   <Column ss:Index=""5"" ss:AutoFitWidth=""0"" ss:Width=""68.25""/> ")
            .WriteLine("   <Column ss:Width=""60.75""/>  ")

            .WriteLine("   <Row ss:AutoFitHeight=""0"" ss:Height=""45"">")

            .WriteLine("      <Cell ss:StyleID=""s65""><Data ss:Type=""String"">Mes</Data></Cell> ")
            .WriteLine("      <Cell ss:StyleID=""s65""><Data ss:Type=""String"">Código de Empresa</Data></Cell>")
            .WriteLine("      <Cell ss:StyleID=""s65""><Data ss:Type=""String"">Código de Suministro</Data></Cell>   ")
            .WriteLine("      <Cell ss:StyleID=""s65""><Data ss:Type=""String"">Código de Barra de Compra</Data></Cell>")
            .WriteLine("      <Cell ss:StyleID=""s66""><Data ss:Type=""String"">Fecha / Hora</Data></Cell> ")
            .WriteLine("      <Cell ss:StyleID=""s67""><Data ss:Type=""String"">EA</Data></Cell>  ")

            .WriteLine("   </Row>")

        End With
        fs.Close()
    End Sub
    Public Sub AddExcelBody(ByVal DGV As DataGridView, ByVal FlNm As String)
        Dim fs As New StreamWriter(FlNm, True)
        With fs
            For intRow As Integer = 0 To DGV.RowCount - 1
                Application.DoEvents()
                .WriteLine("   <Row ss:AutoFitHeight=""0"">  ")

                .WriteLine("      <Cell ss:StyleID=""s68""><Data ss:Type=""Number"">{0}</Data></Cell>", DGV.Item(0, intRow).Value.ToString)
                .WriteLine("      <Cell ss:StyleID=""s68""><Data ss:Type=""String"">{0}</Data></Cell>", DGV.Item(1, intRow).Value.ToString)
                .WriteLine("      <Cell ss:StyleID=""s68""><Data ss:Type=""Number"">{0}</Data></Cell>", DGV.Item(2, intRow).Value.ToString)
                .WriteLine("      <Cell ss:StyleID=""s68""><Data ss:Type=""String"">{0}</Data></Cell>", DGV.Item(3, intRow).Value.ToString)
                .WriteLine("      <Cell ss:StyleID=""s69""><Data ss:Type=""Number"">{0}</Data></Cell>", DGV.Item(4, intRow).Value.ToString)
                .WriteLine("      <Cell ss:StyleID=""s70""><Data ss:Type=""Number"">{0}</Data></Cell>", DGV.Item(5, intRow).Value.ToString)

                .WriteLine("   </Row>")
            Next
            .Close()
        End With
    End Sub
    Public Sub AddExcelFooter(ByVal FlNm As String)
        Dim fs As New StreamWriter(FlNm, True)
        With fs
            .WriteLine("  </Table>   ")
            .WriteLine("  <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">")
            .WriteLine("   <PageSetup> ")
            .WriteLine("<Header x:Margin=""0.3""/>")
            .WriteLine("<Footer x:Margin=""0.3""/>")
            .WriteLine("<PageMargins x:Bottom=""0.75"" x:Left=""0.7"" x:Right=""0.7"" x:Top=""0.75""/>   ")
            .WriteLine("   </PageSetup>")
            .WriteLine("   <Unsynced/> ")
            .WriteLine("   <Selected/> ")
            .WriteLine("   <Panes>   ")
            .WriteLine("<Pane>   ")
            .WriteLine(" <Number>3</Number> ")
            .WriteLine(" <ActiveRow>7</ActiveRow> ")
            .WriteLine(" <ActiveCol>5</ActiveCol> ")
            .WriteLine("</Pane>  ")
            .WriteLine("   </Panes>  ")
            .WriteLine("   <ProtectObjects>False</ProtectObjects>  ")
            .WriteLine("   <ProtectScenarios>False</ProtectScenarios>")
            .WriteLine("  </WorksheetOptions>")
            .WriteLine(" </Worksheet>")
            .Close()
        End With
    End Sub
    Public Sub ExportPadron(ByVal lista As List(Of String), ByVal dgvpadron As DataGridView)
        Dim FilePadron As String = "Exportados\" & "Padron" & "--" & Now.Year & "-" & Now.Month & "-" & Now.Day & "--" & Now.Hour & "-" & Now.Minute & "-" & Now.Second & ".xls"
        If File.Exists(FilePadron) Then File.Delete(FilePadron)

        MBaseDatos.ExportPadron(lista, dgvpadron)

        Dim fw As New StreamWriter(FilePadron, False)
        With fw
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

            .WriteLine("    <Worksheet ss:Name=""Hoja1"">") 'SET NAMA SHEET
                .WriteLine("        <Table>")
                .WriteLine("            <Column ss:Width=""100""/>") '"Número de Padrón Actual"
                .WriteLine("            <Column ss:Width=""100""/>") '"NombrePadron"
                .WriteLine("            <Column ss:Width=""100""/>") '"Item"
                .WriteLine("            <Column ss:Width=""100""/>") '"Codigo Ruta de Suministro"
                .WriteLine("            <Column ss:Width=""100""/>") '"Codigo de Suministro"
                .WriteLine("            <Column ss:Width=""100""/>") '"Nombre de Suministro"
                .WriteLine("            <Column ss:Width=""100""/>") '"Direccion del Predio"
                .WriteLine("            <Column ss:Width=""100""/>") '"Nombre del Sector"
                .WriteLine("            <Column ss:Width=""100""/>") '"Tension"
                .WriteLine("            <Column ss:Width=""100""/>") '"Tarifa"
                .WriteLine("            <Column ss:Width=""100""/>") '"Sistema Electrico"
                .WriteLine("            <Column ss:Width=""100""/>") '"Actividad Economica"
                .WriteLine("            <Column ss:Width=""100""/>") '"Factor de Tension"
                .WriteLine("            <Column ss:Width=""100""/>") '"Factor de Corriente"
                .WriteLine("            <Column ss:Width=""100""/>") '"Factor de Transformacion EA"
                .WriteLine("            <Column ss:Width=""100""/>") '"Marca del Medidor"
                .WriteLine("            <Column ss:Width=""100""/>") '"Modelo"
            .WriteLine("            <Column ss:Width=""100""/>") '"Serie"
            'AUTO SET HEADER
            .WriteLine("            <Row ss:StyleID=""ksg"">")

            For i As Integer = 0 To dgvpadron.Columns.Count - 1 'SET HEADER
                Application.DoEvents()
                .WriteLine("            <Cell ss:StyleID=""hdr"">")
                .WriteLine("                <Data ss:Type=""String"">{0}</Data>", dgvpadron.Columns.Item(i).HeaderText)
                .WriteLine("            </Cell>")
            Next
            .WriteLine("            </Row>")

            For intRow As Integer = 0 To dgvpadron.RowCount - 2
                Application.DoEvents()
                .WriteLine("        <Row ss:StyleID=""ksg"" ss:utoFitHeight =""0"">")
                For intCol As Integer = 0 To dgvpadron.Columns.Count - 1
                    Application.DoEvents()
                    .WriteLine("        <Cell ss:StyleID=""isi"">")
                    .WriteLine("            <Data ss:Type=""String"">{0}</Data>", dgvpadron.Item(intCol, intRow).Value.ToString)
                    .WriteLine("        </Cell>")
                Next
                .WriteLine("        </Row>")
            Next
            .WriteLine("        </Table>")
            .WriteLine("    </Worksheet>")
            .WriteLine("</Workbook>")
            .Close()
        End With
        Process.Start(FilePadron)
    End Sub
End Module
