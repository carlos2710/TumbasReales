Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lInventario
    Dim odInventario As New dInventario
    Public Function RepInventariosExcel(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.RepInventariosExcel(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function RepInventarios(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.RepInventarios(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ReporteInventariosGC(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.ReporteInventariosGC(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listarArchivosCompartidos(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.listarArchivosCompartidos(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarIdentificacionCodAdicionales(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.actualizarIdentificacionCodAdicionales(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarInventariosDGC(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.ListarInventariosDGC(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarIdentificacionCodAdicionales2(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.registrarIdentificacionCodAdicionales2(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarInventario(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.eliminarInventario(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaCombos(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.listaCombos(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarIdentificacionCodAdicionales(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.registrarIdentificacionCodAdicionales(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoCatalogos(ByVal oeInventario As eInventario) As DataTable
        Try
            Return odInventario.listadoCatalogos(oeInventario)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
