Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dExcavacion
    Dim SqlHelper As New SqlHelper
    Public Function listaAnioExcavacion(ByVal oeExcavacion As eExcavacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeExcavacion
                ds = SqlHelper.ExecuteDataset("inves_listarAnioExcavaciones")
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
    Public Function listaProyectoExcavacion(ByVal oeExcavacion As eExcavacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeExcavacion
                ds = SqlHelper.ExecuteDataset("inves_listarProyectoExcavaciones")
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
    Public Function registrarInmuebles2(ByVal oeExcavacion As eExcavacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeExcavacion
                ds = SqlHelper.ExecuteDataset("invest_registrarExcavaciones", .anio_exc, .proyecto_exc, .tipoarchivo_exc, .usuarioreg)
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

    Public Function listarInmuebles2(ByVal oeExcavacion As eExcavacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeExcavacion
                ds = SqlHelper.ExecuteDataset("invest_ListarExcavaciones")
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
