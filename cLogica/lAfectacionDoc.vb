Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lAfectacionDoc
    Dim odAfectacionDoc As New dAfectacionDoc

    Public Function listarAnioAfectacionesDoc(ByVal oeAfectacionDoc As eAfectacionDoc) As DataTable
        Try
            Return odAfectacionDoc.listarAnioAfectacionesDoc(oeAfectacionDoc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listarSitioAfectacionesDoc(ByVal oeAfectacionDoc As eAfectacionDoc) As DataTable
        Try
            Return odAfectacionDoc.listarSitioAfectacionesDoc(oeAfectacionDoc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function invest_registrarAfectacionesDoc(ByVal oeAfectacionDoc As eAfectacionDoc) As DataTable
        Try
            Return odAfectacionDoc.invest_registrarAfectacionesDoc(oeAfectacionDoc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function invest_ListarAfectacionesDoc(ByVal oeAfectacionDoc As eAfectacionDoc) As DataTable
        Try
            Return odAfectacionDoc.invest_ListarAfectacionesDoc(oeAfectacionDoc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
