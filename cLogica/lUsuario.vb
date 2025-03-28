Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lUsuario
    Dim odUsuario As New dUsuario
    Public Function listarArchivosCompartidos(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.listarArchivosCompartidos(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizaContadorEnvioEmails(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.actualizaContadorEnvioEmails(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarDatosSocio(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.consultarDatosSocio(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarUsuarioFuncion(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.actualizarUsuarioFuncion(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarUsuarioFn(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.eliminarUsuarioFn(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function agregarUsuarioFuncion(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.agregarUsuarioFuncion(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarUsuarioFuncion() As DataTable
        Try
            Return odUsuario.ListarUsuarioFuncion()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizaFuncionMenu(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.actualizaFuncionMenu(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListaFunciones() As DataTable
        Try
            Return odUsuario.ListaFunciones()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarFuncionMenu(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.ListarFuncionMenu(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarMenu(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.actualizarMenu(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarMenu(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.eliminarMenu(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarCodigosRaiz(ByVal raiz As Integer) As DataTable
        Try
            Return odUsuario.ListarCodigosRaiz(raiz)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarMenu(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.registrarMenu(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listarMenus(ByVal oeUsuario As eUsuario) As DataTable
        Try
            Return odUsuario.listarMenus(oeUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
