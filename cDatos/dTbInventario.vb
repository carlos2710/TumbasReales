Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient

Public Class dTbInventario
    Dim SqlHelper As New SqlHelper
    Public Function RegistroTbInventario(ByVal oeTbInventario As etbInventario) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeTbInventario
                ds = SqlHelper.ExecuteDataset("inv_registrotbInventario", .Registro_nacional, .Codigo_propiet, .Otro_codigo, .Categoria, .Taxonomia, .Denominacion, .Cultura,
                                               .Periodo, .Descripcion_identificacion, .Tipo_material, .Tecnicas, .Alto, .Largo, .Ancho, .Diam_maximo, .Diam_min, .Peso, .Estado_integridad,
                                                .Cantidad, .Detalle_conservacion, .Procedencia, .Region_origen, .Sitio_origen, .Sector_origen, .Subsector_origen, .Unidad_origen, .Cuadrante_origen,
                                                .Capa_origen, .Cuadricula_origen, .Contexto_origen, .Coleccion_propiedad, .Adquisicion_propiedad, .Documento_propiedad, .Fecha_propiedad,
                                                .Ubicacion, .Area_ubicacion, .Especifica_ubicacion, .Nivel_ubicacion, .Caja_ubicacion, .Bolsa_ubicacion, .Excavado_adic, .Registrado_adic, .Fecha_adic, .Observacion_adic, .cod_dgc) 'JAZ
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

    Public Function ModificarTbInventario(ByVal oeTbInventario As etbInventario) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeTbInventario
                ds = SqlHelper.ExecuteDataset("inv_modificartbInventario", .cod_inventario, .Registro_nacional, .Codigo_propiet, .Otro_codigo, .Categoria, .Taxonomia, .Denominacion, .Cultura,
                                               .Periodo, .Descripcion_identificacion, .Tipo_material, .Tecnicas, .Alto, .Largo, .Ancho, .Diam_maximo, .Diam_min, .Peso, .Estado_integridad,
                                                .Cantidad, .Detalle_conservacion, .Procedencia, .Region_origen, .Sitio_origen, .Sector_origen, .Subsector_origen, .Unidad_origen, .Cuadrante_origen,
                                                .Capa_origen, .Cuadricula_origen, .Contexto_origen, .Coleccion_propiedad, .Adquisicion_propiedad, .Documento_propiedad, .Fecha_propiedad,
                                                .Ubicacion, .Area_ubicacion, .Especifica_ubicacion, .Nivel_ubicacion, .Caja_ubicacion, .Bolsa_ubicacion, .Excavado_adic, .Registrado_adic,
                                                .Fecha_adic, .Observacion_adic)
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

    Public Function ListarTbInventario(ByVal oeTbInventario As etbInventario) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable

        Try
            With oeTbInventario
                ds = SqlHelper.ExecuteDataset("inv_listarTbInventario", .cod_inventario)

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
    'Inicio JAZ
    Public Function ListarTbInventarioCP(ByVal oeTbInventario As etbInventario) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable

        Try
            With oeTbInventario
                ds = SqlHelper.ExecuteDataset("inv_listarTbInventarioCP", .Codigo_propiet, .cod_dgc)
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

    Public Function ListarTbInventarioDGC(ByVal oeTbInventario As etbInventario) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable

        Try
            With oeTbInventario
                ds = SqlHelper.ExecuteDataset("inv_listarTbInventarioDGC", .cod_dgc)
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
    'Fin JAZ
End Class
