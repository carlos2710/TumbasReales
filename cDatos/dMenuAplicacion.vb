Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dMenuAplicacion
    Dim SqlHelper As New SqlHelper
    Public Function ListarColeccionDetalle() As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset("col_listadoColecciones")

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
    Private Function Cargar(ByVal o_fila As DataRow) As eMenuAplicacion
        Try
            Dim eMenuAplicacion = New eMenuAplicacion( _
                                    o_fila("codigo_Men") _
                                , o_fila("descripcion_Men").ToString _
                                , o_fila("enlace_Men").ToString _
                                , o_fila("codigo_Apl") _
                                , o_fila("codigoRaiz_Men") _
                                , o_fila("icono_Men").ToString _
                                , o_fila("iconosel_men").ToString _
                                , o_fila("expandible_men").ToString _
                                , o_fila("nivel_men").ToString _
                                , o_fila("orden_men") _
                                , o_fila("variable_men").ToString _
                                , String.Empty _
                                , o_fila("codigo_Tfu") _
                                , o_fila("_target") _
                                , o_fila("_link") _
                                , o_fila("accesoAlumnoInactivo") _
            )
            Return eMenuAplicacion
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Listar(ByVal oeMenuAplicacion As eMenuAplicacion) As List(Of eMenuAplicacion)
        Try
            Dim lsMenuAplicacion As New List(Of eMenuAplicacion)
            Dim ds As DataSet
            With oeMenuAplicacion
                ds = SqlHelper.ExecuteDataset("[dbo].[ConsultarAplicacionUsuario]" _
                        , .tipoOperacion _
                        , .param1 _
                        , .param2 _
                        , .param3)
            End With

            oeMenuAplicacion = Nothing
            If ds.Tables(0).Rows.Count > 0 Then
                For Each o_Fila As DataRow In ds.Tables(0).Rows
                    oeMenuAplicacion = Cargar(o_Fila)
                    lsMenuAplicacion.Add(oeMenuAplicacion)
                Next
            End If
            Return lsMenuAplicacion
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
