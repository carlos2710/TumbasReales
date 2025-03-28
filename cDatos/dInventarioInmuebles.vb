Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dInventarioInmuebles
    Dim SqlHelper As New SqlHelper
    Public Function ReporteInvInmueblesExcel(ByVal oeInventarioInmuebles As eInventarioInmuebles) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventarioInmuebles
                ds = SqlHelper.ExecuteDataset("rep_InvInmueblesExcel")
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
    Public Function listaInventarioInmuebles(ByVal oeInventarioInmuebles As eInventarioInmuebles) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventarioInmuebles
                ds = SqlHelper.ExecuteDataset("inm_listaInventarioInmuebles", .codigo_inm)
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
    Public Function registrarInmueble1(ByVal oeInventarioInmuebles As eInventarioInmuebles) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventarioInmuebles
                ds = SqlHelper.ExecuteDataset("inm_registrarInmueble", .codigo_inm, .nombresitio_inm, .caserio_inm, .departamento_inm, .provincia_inm, .distrito_inm, .utme_inm, .utmn_inm, .datum_inm, .perimetro_inm, .usuarioreg)
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
    Public Function registrarInmueble2(ByVal oeInventarioInmuebles As eInventarioInmuebles) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventarioInmuebles
                ds = SqlHelper.ExecuteDataset("inm_registrarInmueble2", .codigo_inm, .normalega_inm, .fecha_inm, .levplano_inm, .elaboroplano_inm, .fichatec_inm, .memoriades_inm, .cultur_inm, .tipositio_inm, .estado_inm, .usuarioreg)
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
    Public Function eliminarInmueble(ByVal oeInventarioInmuebles As eInventarioInmuebles) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventarioInmuebles
                ds = SqlHelper.ExecuteDataset("inm_eliminarInmueble", .codigo_inm, .usuarioreg)
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
