Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dInventario
    Dim SqlHelper As New SqlHelper
    Public Function RepInventariosExcel(ByVal oeInventario As eInventario) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("rep_InventariosExcel", .id_dgc, .unidad_inv, .tipomaterial_inv)
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
    Public Function RepInventarios(ByVal oeInventario As eInventario) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("rep_Inventarios", .id_dgc, .unidad_inv, .tipomaterial_inv)
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
    Public Function ReporteInventariosGC(ByVal oeInventario As eInventario) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("inv_reporteInventariosGC", .param1)
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
    Public Function listarArchivosCompartidos(ByVal oeInventario As eInventario) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("USP_LISTARARCHIVOSCOMPARTIDOS", .param1, .param2, .param3)
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
    Public Function actualizarIdentificacionCodAdicionales(ByVal oeInventario As eInventario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("inv_actualizaInventario", .codpropietario_inv, .codexcavacion_inv, .nro_inv, .proyecto_inv, .temporada_inv, .sector_inv, .subsector_inv, .unidad_inv, .capa_inv, .nivel_inv, .cuadricula_inv, .contexto_inv, .plano_inv, .tipomaterial_inv, .id_dgc, .usuarioreg, .param2)
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
    Public Function ListarInventariosDGC(ByVal oeInventario As eInventario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("inv_listarInventarioDGC", .param1)
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

    Public Function registrarIdentificacionCodAdicionales2(ByVal oeInventario As eInventario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("inv_actualizaInventario2", .codpropietario_inv, .descripcion_inv, .cultura_inv, .estilo_inv, .otrosdatos_inv, .nrocaja_inv, .nrobolsa_inv, .ini_rotulacion_inv, .fin_rotulacion_inv, .cantidad_inv, .peso_inv, .fechaalmacen_inv, .fechareg, .registro_inv, .almacen_inv, .estante_inv, .observacion_inv, .id_dgc, .usuarioreg)
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
    Public Function eliminarInventario(ByVal oeInventario As eInventario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("inv_eliminarRegistro", .codpropietario_inv, .usuarioreg)
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
    Public Function listaCombos(ByVal oeInventario As eInventario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("cat_listaCombos", .TipoOperacion)
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

    Public Function registrarIdentificacionCodAdicionales(ByVal oeInventario As eInventario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("inv_registroInventario", .codpropietario_inv, .codexcavacion_inv, .nro_inv, .proyecto_inv, .temporada_inv, .sector_inv, .subsector_inv, .unidad_inv, .capa_inv, .nivel_inv, .cuadricula_inv, .contexto_inv, .plano_inv, .tipomaterial_inv, .id_dgc, .usuarioreg)
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
    Public Function listadoCatalogos(ByVal oeInventario As eInventario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInventario
                ds = SqlHelper.ExecuteDataset("cat_listadoCatalogos", .TipoOperacion, "", "", "")
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
