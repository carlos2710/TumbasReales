Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dAfectacionInmueble
    Dim SqlHelper As New SqlHelper
    Public Function ReporteAfectaInmueblesExcel(ByVal oeAfectacionInmueble As eAfectacionInmueble) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAfectacionInmueble
                ds = SqlHelper.ExecuteDataset("rep_AfectaInmueblesExcel")
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
    Public Function listaAfectacionInmuebles(ByVal oeAfectacionInmueble As eAfectacionInmueble) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAfectacionInmueble
                ds = SqlHelper.ExecuteDataset("inm_listaAfectacionInmuebles", .codigo_ain)
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
    Public Function registrarAfectacionInmueble(ByVal oeAfectacionInmueble As eAfectacionInmueble) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAfectacionInmueble
                ds = SqlHelper.ExecuteDataset("inm_registrarAfectacionInmuebles", .codigo_ain, .fecha_ain, .sitio_ain, .denunciante_ain, .denunciado_ain, .tipoafect_ain, .inspeccion_ain, .realizoinspec_ain, .instancia_ain, .usuarioreg)
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
    Public Function eliminarAfectacionInmueble(ByVal oeAfectacionInmueble As eAfectacionInmueble) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAfectacionInmueble
                ds = SqlHelper.ExecuteDataset("inm_eliminarAfectacionInmuebles", .codigo_ain, .usuarioreg)
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
