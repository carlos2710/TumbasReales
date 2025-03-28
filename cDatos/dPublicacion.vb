Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Imports System.Data
Public Class dPublicacion
    Dim SqlHelper As New SqlHelper
    Public Function ReportePublicaciones2(ByVal oePublicacion As ePublicacion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oePublicacion
                ds = SqlHelper.ExecuteDataset("pub_reportePublicacionesAnio2", .anio_pub)
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
    Public Function ReportePublicacionesAnio(ByVal oePublicacion As ePublicacion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oePublicacion
                ds = SqlHelper.ExecuteDataset("pub_reportePublicacionesAnio", .anio_pub)
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
    Public Function listaCombosAnioPublicaciones(ByVal oePublicacion As ePublicacion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oePublicacion
                ds = SqlHelper.ExecuteDataset("pub_listarCboAnioPublicaciones")
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
    Public Function ReportePublicaciones(ByVal oePublicacion As ePublicacion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oePublicacion
                ds = SqlHelper.ExecuteDataset("cat_reportePublicaciones")
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
    Public Function eliminarPublicacion(ByVal oePublicacion As ePublicacion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oePublicacion
                ds = SqlHelper.ExecuteDataset("pub_eliminarPublicacion", .param1)
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
    Public Function listarPublicaciones(ByVal oePublicacion As ePublicacion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oePublicacion
                ds = SqlHelper.ExecuteDataset("pub_listaPublicaciones", .param1)
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

    Public Function listaCombosPublicacion(ByVal oePublicacion As ePublicacion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oePublicacion
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

    Public Function actualizarPublicaciones(ByVal oePublicacion As ePublicacion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oePublicacion
                ds = SqlHelper.ExecuteDataset("pub_actualizarInformacion1", .numero, .denominacion_pub, .codpropietario_pub, .codexcavacion_pub, .sitio_pub, .contexto_pub, .usuariomod, .param1)
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

    Public Function actualizarPublicaciones2(ByVal oePublicacion As ePublicacion) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oePublicacion
                ds = SqlHelper.ExecuteDataset("pub_actualizarInformacion2", .presentabio_pub, .tipobio_pub, .autores_pub, .titulo_pub, .anio_pub, .titulolibro_pub, .edicion_pub, .paginas_pub, .nrofigura_pub, .volumen_pub, .seccion, .fechaconsulta_pub, .param2, .usuarioreg, .param1)
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
