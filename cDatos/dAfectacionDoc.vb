Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dAfectacionDoc
    Dim SqlHelper As New SqlHelper
    Public Function listarAnioAfectacionesDoc(ByVal oeAfectacionDoc As eAfectacionDoc) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAfectacionDoc
                ds = SqlHelper.ExecuteDataset("inves_listarAnioAfectacionesDoc")
            End With

            If (ds.Tables.Count > 0) Then
                dt = ds.Tables(0)
            Else
                Return Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function listarSitioAfectacionesDoc(ByVal oeAfectacionDoc As eAfectacionDoc) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAfectacionDoc
                ds = SqlHelper.ExecuteDataset("inves_listarSitioAfectacionesDoc")
            End With

            If (ds.Tables.Count > 0) Then
                dt = ds.Tables(0)
            Else
                Return Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function invest_registrarAfectacionesDoc(ByVal oeAfectacionDoc As eAfectacionDoc) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAfectacionDoc
                ds = SqlHelper.ExecuteDataset("invest_registrarAfectacionesDoc", .anio_ado, .sitio_ado, .usuarioreg)
            End With

            If (ds.Tables.Count > 0) Then
                dt = ds.Tables(0)
            Else
                Return Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function invest_ListarAfectacionesDoc(ByVal oeAfectacionDoc As eAfectacionDoc) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAfectacionDoc
                ds = SqlHelper.ExecuteDataset("invest_ListarAfectacionesDoc")
            End With

            If (ds.Tables.Count > 0) Then
                dt = ds.Tables(0)
            Else
                Return Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
