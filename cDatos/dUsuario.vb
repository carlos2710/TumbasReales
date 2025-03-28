Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Imports System.Data
Public Class dUsuario
    Dim SqlHelper As New SqlHelper
    Public Function listarArchivosCompartidos(ByVal oeUsuario As eUsuario) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeUsuario
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
    Public Function actualizaContadorEnvioEmails(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("soc_actualizaEnvioEmailSocio", .codigo_uap, .email)
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
    Public Function consultarDatosSocio(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("soc_CumpleaniosSocios", .codigo_uap)
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
    Public Function actualizarUsuarioFuncion(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("usu_actualizarUsuarioFuncion", .codigo_uap, .aPaterno, .aMaterno, .nombres, .docidentidad, .tsexo, .email, .email2, .codigo_Apl, .codigo_tfu, .param1)
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
    Public Function eliminarUsuarioFn(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("usu_eliminarUsuarioFn", .codigo_Men, .param1)
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
    Public Function agregarUsuarioFuncion(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("usu_agregarUsuarioFuncion", .aPaterno, .aMaterno, .nombres, .docidentidad, .tsexo, .email, .email2, .codigo_Apl, .codigo_tfu, .param1)
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
    Public Function ListarUsuarioFuncion() As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset("usu_listaUsuariosFuncion")
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
    Public Function actualizaFuncionMenu(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("usu_actualizarFuncionMenu", .codigoRaizMen, .descripcion_Men)
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
    Public Function ListaFunciones() As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset("usu_listaFunciones")
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
    Public Function ListarFuncionMenu(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("usu_listaFuncionMenu", .codigo_Men)
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
    Public Function actualizarMenu(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("usu_actualizarMenu", .codigo_Men, .descripcion_Men, .codigo_Apl, .codigoRaizMen, .nivel_men, .orden_men, .param1, .enlace)
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
    Public Function eliminarMenu(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("usu_eliminarMenu", .codigo_Men)
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
    Public Function ListarCodigosRaiz(ByVal raiz As Integer) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset("usu_listarMenus", raiz)
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
    Public Function registrarMenu(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("usu_registrarMenu", .descripcion_Men, .codigo_Apl, .codigoRaizMen, .nivel_men, .orden_men, .param1, .enlace)
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
    Public Function listarMenus(ByVal oeUsuario As eUsuario) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeUsuario
                ds = SqlHelper.ExecuteDataset("usu_listarMenus")
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

