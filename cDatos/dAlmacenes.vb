Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dAlmacenes
    Dim SqlHelper As New SqlHelper
    Public Function ReporteAlmacenesExcel(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlmacenes
                ds = SqlHelper.ExecuteDataset("rep_AlmacenesExcel", .id_dgc)
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
    Public Function listaAlmacenes(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlmacenes
                ds = SqlHelper.ExecuteDataset("con_listaAlmacenes", .nroficha_alm, .id_dgc)
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
    Public Function registrarAlmacenes(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlmacenes
                ds = SqlHelper.ExecuteDataset("con_insertarAlmacenes", .nroficha_alm, .id_dgc, .ambmonitoreo_alm, .area_alm, .tipoestruct_alm, .ventanas_alm, .tipoluz_alm, .usuarioreg)
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
    Public Function registrarAlmacenes2(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlmacenes
                ds = SqlHelper.ExecuteDataset("con_insertarAlmacenes2", .nroficha_alm, .id_dgc, .tipoaa_alm, .cantidadaa_alm, .tipoex_alm, .cantidadex_alm, .cantthermo_alm, .deshumedecedor_alm, .cantestantes_alm, .nivelesestantes_alm, .cajasplast_alm, .cajascarton_alm, .cajasmadera_alm, .usuarioreg)
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
    Public Function registrarAlmacenes3(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlmacenes
                ds = SqlHelper.ExecuteDataset("con_insertarAlmacenes3", .nroficha_alm, .id_dgc, .coleccion_alm, .material_alm, .otros_alm, .conservadorcargo_alm, .usuarioreg)
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
    Public Function registrarAlmacenes4(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlmacenes
                ds = SqlHelper.ExecuteDataset("con_insertarAlmacenes4", .nroficha_alm, .id_dgc, .fecha_alm, .hringresoa_alm, .hrsalidaa_alm, .primeraTa_alm, .segundaTa_alm, .primeraHa_alm, .segundaHa_alm, .hringresop_alm, .hrsalidap_alm, .primeraTp_alm, .segundaTp_alm, .primeraHp_alm, .segundaHp_alm, .observaciones_alm, .usuarioreg)
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
