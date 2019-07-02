Imports System.Data.SQLite
Module MBaseDatos
    Const cadena_conexion As String = "Data Source=electrosur.s3db;Version=3"
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
End Module
