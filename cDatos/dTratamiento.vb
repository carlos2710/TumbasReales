Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dTratamiento
    Dim SqlHelper As New SqlHelper
    Public Function ReporteTratamientoExcel(ByVal oeTratamiento As eTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeTratamiento
                ds = SqlHelper.ExecuteDataset("rep_TratamientosExcel", .id_dgc)
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
    Public Function listaTratamientos(ByVal oeTratamiento As eTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeTratamiento
                ds = SqlHelper.ExecuteDataset("con_listaTratemientos", .nroficha_tra, .id_dgc)
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
    Public Function registrarTratamiento(ByVal oeTratamiento As eTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarTratamiento", .nroficha_tra, .id_dgc, .codregnac_tra, .codpropietario_tra, .codexcavacion_tra, .codrestauracion_tra, .usuarioreg)
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
    Public Function registrarTratamiento2(ByVal oeTratamiento As eTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarTratamiento2", .nroficha_tra, .id_dgc, .sector_tra, .unidad_tra, .capa_tra, .nivel_tra, .cuadricula_tra, .plano_tra, .contexto_tra, .ubicontexto_tra, .alturaobs_tra, .otrosdatos_tra, .usuarioreg)
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
    Public Function registrarTratamiento3(ByVal oeTratamiento As eTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarTratamiento3", .nroficha_tra, .id_dgc, .material_tra, .denominacion_tra, .descripcion_tra, .alto_tra, .largo_tra, .ancho_tra, .espesor_tra, .diametromax_tra, .diametromin_tra, .diametrobase_tra, .pesoini_tra, .pesofin_tra, .usuarioreg)
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
    Public Function registrarTratamiento4(ByVal oeTratamiento As eTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarTratamiento4", .nroficha_tra, .id_dgc, .ubicinmueble_tra, .nrocaja_tra, .nrobolsa_tra, .integridadbien_tra, .conservacionbien_tra, .detconservacion_tra, .intervenciones_tra, .fini_tra, .ffin_tra, .usuarioreg)
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
    Public Function registrarTratamiento5(ByVal oeTratamiento As eTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarTratamiento5", .nroficha_tra, .id_dgc, .dettratamiento_tra, .usuarioreg)
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
    Public Function registrarTratamiento6(ByVal oeTratamiento As eTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarTratamiento6", .nroficha_tra, .id_dgc, .secadopost_tra, .pegado_tra, .consolidacion_tra, .reintegracion_tra, .otrosrec_tra, .finitrat_tra, .ffintrat_tra, .temperatura_tra, .humedad_tra, .manipulacion_tra, .iluminacion_tra, .otrosrec_tra, .materialrec_tra, .observaciones_tra, .conservadorcargo_tra, .fecha_tra, .usuarioreg)
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
    Public Function registrarTratamiento7(ByVal oeTratamiento As eTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarTratamiento7", .nroficha_tra, .id_dgc, .fotoini_tra, .fotofin_tra, .detalle_tra, .usuarioreg)
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
