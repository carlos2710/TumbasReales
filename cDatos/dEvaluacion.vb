Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dEvaluacion
    Dim SqlHelper As New SqlHelper
    Public Function ReporteEvaluacionesExcel(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeEvaluacion
                ds = SqlHelper.ExecuteDataset("rep_EvaluacionesExcel", .id_dgc)
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
    Public Function eliminarEliminacion(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeEvaluacion
                'Inicio JAZ
                'ds = SqlHelper.ExecuteDataset("con_eliminarRegistro", .codpropietario_con, .usuarioreg)
                ds = SqlHelper.ExecuteDataset("con_eliminarRegistro", .nroficha_con, .id_dgc, .usuarioreg)
                'Fin JAZ
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
    Public Function listarFiltroEvaluacion(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeEvaluacion
                ds = SqlHelper.ExecuteDataset("con_listaFiltroEvaluaciones", .id_dgc)
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
    Public Function listaEvaluaciones(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeEvaluacion
                ds = SqlHelper.ExecuteDataset("con_listaEvaluaciones", .nroficha_con, .id_dgc)
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
    Public Function listaEvaluaciones2(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeEvaluacion
                ds = SqlHelper.ExecuteDataset("con_listaEvaluaciones2", .codpropietario_con, .id_dgc)
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
    Public Function registrarEvaluacion(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeEvaluacion
                ds = SqlHelper.ExecuteDataset("con_insertarEvaluacion", .nroficha_con, .id_dgc, .codregnac_con, .codpropietario_con, .codexcavacion_con, .codrestauracion_con, .usuarioreg)
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
    Public Function registrarEvaluacion2(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeEvaluacion
                ds = SqlHelper.ExecuteDataset("con_insertarEvaluacion2", .nroficha_con, .id_dgc, .sector_con, .unidad_con, .capa_con, .nivel_con, .cuadricula_con, .param1, .contexto_con, .ubicontexto_con, .alturaobs_con, .otrosdatos_con, .usuarioreg)
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
    Public Function registrarEvaluacion3(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeEvaluacion
                ds = SqlHelper.ExecuteDataset("con_insertarEvaluacion3", .nroficha_con, .id_dgc, .material_con, .denominacion_con, .descripcion_con, .alto_con, .largo_con, .ancho_con, .espesor_con, .diametromax_con, .diametromin_con, .diametrobase_con, .peso_con, .usuarioreg)
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
    Public Function registrarEvaluacion4(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeEvaluacion
                ds = SqlHelper.ExecuteDataset("con_insertarEvaluacion4", .nroficha_con, .id_dgc, .ubicinmueble_con, .nrocaja_con, .nrobolsa_con, .integridadbien_con, .conservacionbien_con, .detconservacion_con, .usuarioreg)
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
    Public Function registrarEvaluacion5(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeEvaluacion
                ds = SqlHelper.ExecuteDataset("con_insertarEvaluacion5", .nroficha_con, .id_dgc, .observaciones_con, .temperatura_con, .humedad_con, .manipulacion_con, .otros_con, .conservadorcargo_con, .fecha_con, .usuarioreg)
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
