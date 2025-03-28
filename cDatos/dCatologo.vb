Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dCatologo
    Dim SqlHelper As New SqlHelper
    Public Function listaDistrito(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("listarDistrito", .param1)
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
    Public Function listaProvincia(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("listarProvincia", .param1)
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
    Public Function listaDepartamentos(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("listarDepartamentos")
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
    Public Function reportCatPDF(ByVal oeCatologo As eCatalogo) As DataSet
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_reportePDF", .param1)
            End With

            If (ds.Tables.Count > 0) Then
                dt = ds.Tables(0)
            Else
                Return Nothing
            End If

            Return ds
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function eliminarColeccion(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("grl_eliminarColecciones", .codpropietario_cat, .usuarioreg)
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
    Public Function agregarColeccion(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("grl_colecciones", .param1, .codinvinc_cat, .param2, .param3)
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
    Public Function listaColeccionesxGrupo(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("grl_ListarcoleccionesMant", .param1)
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
    Public Function rep_CatalogosExcel(ByVal oeCatologo As eCatalogo) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("rep_CatalogosExcel", .id_dgc, .unidad_cat, .contexto_cat, .material_cat)
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
    Public Function RepCatalogos(ByVal oeCatologo As eCatalogo) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("rep_Catalogos", .id_dgc, .unidad_cat, .contexto_cat, .material_cat)
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
    Public Function listaCombosReportes(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("rep_cbsReportes", .TipoOperacion)
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
    Public Function SearchGeneral(ByVal oeCatologo As eCatalogo) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_searchGeneral", .nombreclasif_cat)
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
    Public Function ReporteCatalogoGC(ByVal oeCatologo As eCatalogo) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_reporteCatalogosGC", .param1)
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
    Public Function listarArchivosCompartidos(ByVal oeCatologo As eCatalogo) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeCatologo
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
    Public Function actualizarIdentificacionCodAdicionales(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_actualizarIdentificacion", .codpropietario_cat, .codregnac_cat, .codexcavacion_cat, .codreginc_cat, .codinvinc_cat, .otrocodigos_cat, .id_dgc, .usuarioreg, .param1, .param2)
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
    Public Function ListarCatalogosDGC(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_listarCatalogosDGC", .nrodocumento_cat)
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
    Public Function registrarIdentificacionCodAdicionales7(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_registroDatos", .codpropietario_cat, .fichacampoelab_cat, .fechafichacampo_cat, .fototomada_cat, .fechafoto, .tipo_cat, .nrodocumento_cat, .fechadocumento_cat, .otrasreferencias_cat, .fechareg, .id_dgc, .usuarioreg)
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
    Public Function registrarIdentificacionCodAdicionales5(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_registroUbicacionActual", .codpropietario_cat, .nombreinmueble_cat, .ubicacionespecif_cat, .situacion_cat, .pisovitrina_cat, .almacenanaquel_cat, .cajacontenedor_cat, .bolsa_cat, .id_dgc, .usuarioreg)
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

    Public Function registrarIdentificacionCodAdicionales4(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_registroDatosPropiedad", .codpropietario_cat, .tipopropietario_cat, .propietario_cat, .tipocustodio_cat, .nombrecustodio_cat, .adquisicion_cat, .referenciaadq_cat, .direccioninmueble_cat, .id_dgc, .usuarioreg)
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
    Public Function registrarIdentificacionCodAdicionales3(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_registroFisicaDimensiones", .codpropietario_cat, .material_cat, .tipo_cat, .denominacion_cat, .manufactura_cat, .decoracion_cat, .descripcion_cat, .colores_cat, .acabadosuperf_cat, .representaciones_cat, .motivodecorativo_cat, .alto_cat, .largo_cat, .ancho_cat, .espesor_cat, .diametromax_cat, .diametromin_cat, .diametrobase_cat, .peso_cat, .id_dgc, .usuarioreg)
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
    Public Function registrarIdentificacionCodAdicionales2(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_registroDatosorigen", .codpropietario_cat, .cultura_cat, .estilo_cat, .periodo_cat, .cronologia_cat, .areageografica_cat, .origenclasif_cat, .nombreclasif_cat, .region_cat, .valle_cat, .margen_cat, .provieneexcav_cat, .sector_cat, .unidad_cat, .capa_cat, .nivel_cat, .cuadricula_cat, .plano_cat, .contexto_cat, .ubicacioncontexto_cat, .alturaabs_cat, .otrosdatos_cat, .id_dgc, .usuarioreg)
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
    Public Function eliminarCatologo(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_eliminarRegistro", .codpropietario_cat, .usuarioreg)
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
    Public Function listaCombos(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
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

    Public Function registrarIdentificacionCodAdicionales(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("cat_registroIdentificacion", .codpropietario_cat, .codregnac_cat, .codexcavacion_cat, .codreginc_cat, .codinvinc_cat, .otrocodigos_cat, .id_dgc, .usuarioreg, .usuarioreg)
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
    Public Function listadoCatalogos(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
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
    Public Function PlanillaArqueologica(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("plantilla_arqueologicaTabla")
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

    Public Function PlanillaArqueologicaExcel(ByVal oeCatologo As eCatalogo) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeCatologo
                ds = SqlHelper.ExecuteDataset("plantilla_arqueologica")
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
