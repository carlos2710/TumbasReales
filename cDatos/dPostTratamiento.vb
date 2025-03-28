Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dPostTratamiento
    Dim SqlHelper As New SqlHelper
    Public Function ReportePostTratamientoExcel(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oePostTratamiento
                ds = SqlHelper.ExecuteDataset("rep_PostTratamientoExcel", .id_dgc)
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
    Public Function listaPostTratemientos(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oePostTratamiento
                ds = SqlHelper.ExecuteDataset("con_listaPostTratemientos", .nroficha_ptr, .id_dgc)
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
    Public Function registrarPostTratamiento(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oePostTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarPostTratamiento", .nroficha_ptr, .id_dgc, .codregnac_ptr, .codpropietario_ptr, .codexcavacion_ptr, .codrestauracion_ptr, .usuarioreg)
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
    Public Function registrarPostTratamiento2(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oePostTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarPostTratamiento2", .nroficha_ptr, .id_dgc, .sector_ptr, .unidad_ptr, .capa_ptr, .nivel_ptr, .cuadricula_ptr, .plano_ptr, .contexto_ptr, .ubicontexto_ptr, .alturaobs_ptr, .otrosdatos_ptr, .usuarioreg)
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
    Public Function registrarPostTratamiento3(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oePostTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarPostTratamiento3", .nroficha_ptr, .id_dgc, .material_ptr, .denominacion_ptr, .descripcion_ptr, .alto_ptr, .largo_ptr, .ancho_ptr, .espesor_ptr, .diametromax_ptr, .diametromin_ptr, .diametrobase_ptr, .peso_ptr, .usuarioreg)
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
    Public Function registrarPostTratamiento4(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oePostTratamiento
                ds = SqlHelper.ExecuteDataset("con_insertarPostTratamiento4", .nroficha_ptr, .id_dgc, .ubicinmueble_ptr, .nrocaja_ptr, .nrobolsa_ptr, .problematica_ptr, .varicacion_ptr, .reacciones_ptr, .presentaafec_ptr, .tipoafec_ptr, .causaafec_ptr, .recomendaciones_ptr, .conservadorcargo_ptr, .fecha_ptr, .usuarioreg)
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
