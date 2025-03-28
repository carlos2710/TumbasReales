Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Imports System.Data
Public Class dColeccion
    Dim SqlHelper As New SqlHelper
    Public Function ListarGrupoColeccion(ByVal gc As Integer) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset("grl_grupocolecciones", gc)

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

    Public Function ListarTiposInformacion(ByVal ti As Integer) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset("grl_tiposinformacion", ti)

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

    Public Function ListarColeccionDetalle(ByVal ti As Integer) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset("col_listadoColecciones", ti)

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
