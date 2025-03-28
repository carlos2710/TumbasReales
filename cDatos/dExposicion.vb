Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Imports System.Data
Public Class dExposicion
    Dim SqlHelper As New SqlHelper
    Public Function ReporteExposicionesAnio2(ByVal oeExposicion As eExposicion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeExposicion
                ds = SqlHelper.ExecuteDataset("exp_reporteExposicionesAnio2", .param1)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ReporteExposicionesAnio(ByVal oeExposicion As eExposicion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeExposicion
                ds = SqlHelper.ExecuteDataset("exp_reporteExposicionesAnio", .param1)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function listaCombosAniosExposiciones(ByVal oeExposicion As eExposicion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeExposicion
                ds = SqlHelper.ExecuteDataset("pub_listarCboAnioExposiciones")
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ReporteExposiciones(ByVal oeExposicion As eExposicion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeExposicion
                ds = SqlHelper.ExecuteDataset("cat_reporteExposiciones")
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function eliminarExposicion(ByVal oeExposicion As eExposicion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeExposicion
                ds = SqlHelper.ExecuteDataset("exp_eliminarExposicion", .param1)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function listarExposiciones(ByVal oeExposicion As eExposicion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeExposicion
                ds = SqlHelper.ExecuteDataset("exp_listarExposiciones", .param1)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function listaCombosPublicacion(ByVal oeExposicion As eExposicion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeExposicion
                ds = SqlHelper.ExecuteDataset("rep_cboPublicaciones", .TipoOperacion)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function actualizarExposiciones(ByVal oeExposicion As eExposicion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeExposicion
                ds = SqlHelper.ExecuteDataset("exp_actualizarExposicion1", .numero, .codregnac_exp, .codpropietario_exp, .codexcavacion_exp, .otroscodigos_exp, .usuariomod, .param1)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function actualizarExposiciones2(ByVal oeExposicion As eExposicion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeExposicion
                ds = SqlHelper.ExecuteDataset("exp_actualizarExposicion2", .denominacion_exp, .sitio_exp, .contexto_exp, .nombre_exp, .lugar_exp, .pais_exp, .inmueble_exp, .resolucacion_exp, .institucion_exp, .comisario_exp, .salida_exp, .retorno_exp, .nropiliza_exp, .monto_exp, .usuarioreg, .param1)

                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
