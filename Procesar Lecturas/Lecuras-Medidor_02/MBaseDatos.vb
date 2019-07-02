Imports System.Data.SQLite
Module MBaseDatos
    Const cadena_conexion As String = "Data Source=electrosur.db;Version=3"
    Public Sub ConsultaNumImport(ByVal NombreSector As String, ByRef NumImport As String)
        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            objCommand.CommandText = "select  Max(NumImport) from Padroncliente where NombrePadron=""" & NombreSector & """ "
            objReader = objCommand.ExecuteReader()

            If objReader.Read() Then
                NumImport = objReader.Item("Max(NumImport)").ToString
                NumImport = Val(NumImport) + 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            objCommand.Dispose()
            objReader.Close()
            objCon.Close()
        End Try
    End Sub
    Public Sub GuardarPadron(ByVal NumImport As Integer, ByVal NombrePadron As String, ByVal Item As Integer, ByVal CodigoRutaSuministro As String, ByVal CodigoSuministro As String, ByVal NombreSuministro As String, ByVal DireccionPredio As String, ByVal NombreSector As String, ByVal Tension As String, ByVal Tarifa As String, ByVal SistemaElectrico As String, ByVal ActividadEconomica As String, ByVal FactorTension As String, ByVal FactorCorriente As String, ByVal FactorTransformacionEA As String, ByVal MarcaDelMedidor As String, ByVal Modelo As String, ByVal Serie As String)

        Dim objCon1 As SQLiteConnection
        Dim objCommand1 As SQLiteCommand

        Try
            objCon1 = New SQLiteConnection(cadena_conexion) '& "New=true;")
            objCon1.Open()
            'MsgBox("Abierta DB")
            objCommand1 = objCon1.CreateCommand()
            objCommand1.CommandText = "insert into Padroncliente ('NumImport', 'NombrePadron', 'Item', 'CodigoRutaSuministro', 'CodigoSuministro', 'NombreSuministro', 'DireccionPredio', 'NombreSector', 'ValorTension', 'Tarifa', 'SistemaElectrico', 'ActividadEconomica', 'FactorTension', 'FactorCorriente', 'FactorTransformacionEA', 'NombreMarca', 'NombreModelo', 'Serie') values (""" & NumImport & """,""" & NombrePadron & """,""" & Item & """,""" & CodigoRutaSuministro & """,""" & CodigoSuministro & """,""" & NombreSuministro.Replace(Chr(34), "") & """,""" & DireccionPredio.Replace(Chr(34), "") & """,""" & NombreSector & """,""" & Tension & """,""" & Tarifa & """,""" & SistemaElectrico & """,""" & ActividadEconomica & """,""" & FactorTension & """,""" & FactorCorriente & """,""" & FactorTransformacionEA & """,""" & MarcaDelMedidor & """,""" & Modelo & """,""" & Serie & """);"

            'MsgBox(objCommand1.CommandText)
            objCommand1.ExecuteNonQuery()
            'MsgBox("ex DB")
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox(objCommand1.CommandText)
        Finally
            objCommand1.Dispose()
            objCon1.Close()
        End Try
    End Sub
    Public Sub MostrarPadron(ByVal NombrePadron As String, ByRef dgvmedidor As DataGridView)
        Dim sql As String = ""

        If NombrePadron = "TODOS" Then
            sql = "SELECT * FROM Padroncliente WHERE NumImport in (select  Max(NumImport) from Padroncliente)"
        Else
            sql = "SELECT * FROM Padroncliente WHERE NumImport in (select  Max(NumImport) from Padroncliente where NombrePadron=""" & NombrePadron & """)"
        End If
        MsgBox(sql)
        Using con As New SQLiteConnection(cadena_conexion)

            Dim command As New SQLiteCommand(sql, con)
            Dim da As New SQLiteDataAdapter
            da.SelectCommand = command
            Dim dt As New DataTable
            da.Fill(dt)
            dgvmedidor.DataSource = dt

            With dgvmedidor
                .Columns(0).HeaderText = "Número de Padrón Actual"
                .Columns(2).HeaderText = "Nombre de Padrón"
                .Columns(3).HeaderText = "Item"
                .Columns(3).HeaderText = "Codigo Ruta de Suministro"
                .Columns(4).HeaderText = "Codigo de Suministro"
                .Columns(5).HeaderText = "Nombre de Suministro"
                .Columns(6).HeaderText = "Direccion del Predio"
                .Columns(7).HeaderText = "Nombre del Sector"
                .Columns(8).HeaderText = "Valor de Tension"
                .Columns(9).HeaderText = "Tarifa"
                .Columns(10).HeaderText = "Sistema Electrico"
                .Columns(11).HeaderText = "Actividad Economica"
                .Columns(12).HeaderText = "Factor de Tension"
                .Columns(13).HeaderText = "Factor de Corriente"
                .Columns(14).HeaderText = "Factor de Transformacion EA"
                .Columns(15).HeaderText = "Marca del Medidor"
                .Columns(16).HeaderText = "Nombre del Modelo"
                .Columns(17).HeaderText = "Serie"
            End With
        End Using
    End Sub
    Public Sub ConsultaCodSumFT(ByVal serie As String, ByRef codsuministro As String, ByRef FTEA As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            'objCommand.CommandText = "select CodigoSuministro, FactorTransformacionEA from Clientes where serie=" & serie & " and NumImport in (select  Max(NumImport) from Clientes)"
            objCommand.CommandText = "select CodigoSuministro, FactorTransformacionEA from Padroncliente where serie=""" & serie & """ "
            objReader = objCommand.ExecuteReader()

            'MsgBox((objReader.Read()), MsgBoxStyle.Information, "leyendo")
            If objReader.Read() Then
                codsuministro = objReader.Item("CodigoSuministro").ToString
                FTEA = objReader.Item("FactorTransformacionEA").ToString
                'MsgBox(CStr(FTEA), MsgBoxStyle.Information, "leyendo")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            'If Not IsNothing(objCon) Then
            objCommand.Dispose()
            objReader.Close()
            objCon.Close()
            'End If
        End Try
    End Sub
    Public Sub ConsultaSector(ByVal serie As String, ByRef NombreSector As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            'MsgBox("primero", MsgBoxStyle.Information, "leyendo")
            objCommand.CommandText = "select NombreSector from Padroncliente where serie=""" & serie & """ "
            'MsgBox(objCommand.CommandText, MsgBoxStyle.Information, "leyendo")
            objReader = objCommand.ExecuteReader()

            'MsgBox((objReader.Read()), MsgBoxStyle.Information, "leyendo")
            If objReader.Read() Then
                NombreSector = objReader.Item("NombreSector").ToString
                'MsgBox(CStr(FTEA), MsgBoxStyle.Information, "leyendo")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            objCommand.Dispose()
            objReader.Close()
            objCon.Close()
        End Try
    End Sub
End Module
