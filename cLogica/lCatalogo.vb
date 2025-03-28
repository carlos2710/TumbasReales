Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lCatalogo
    Dim odCatalogo As New dCatologo
    Public Function listaDistrito(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.listaDistrito(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaProvincia(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.listaProvincia(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaDepartamentos(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.listaDepartamentos(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function reportCatPDF(ByVal oeCatologo As eCatalogo) As DataSet
        Try
            Return odCatalogo.reportCatPDF(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarColeccion(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.eliminarColeccion(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function agregarColeccion(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.agregarColeccion(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function rep_CatalogosExcel(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.rep_CatalogosExcel(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaColeccionesxGrupo(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.listaColeccionesxGrupo(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function RepCatalogos(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.RepCatalogos(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaCombosReportes(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.listaCombosReportes(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function SearchGeneral(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.SearchGeneral(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ReporteCatalogoGC(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.ReporteCatalogoGC(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listarArchivosCompartidos(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.listarArchivosCompartidos(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarIdentificacionCodAdicionales(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.actualizarIdentificacionCodAdicionales(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarCatalogosDGC(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.ListarCatalogosDGC(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarIdentificacionCodAdicionales7(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.registrarIdentificacionCodAdicionales7(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarIdentificacionCodAdicionales5(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.registrarIdentificacionCodAdicionales5(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarIdentificacionCodAdicionales4(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.registrarIdentificacionCodAdicionales4(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarIdentificacionCodAdicionales3(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.registrarIdentificacionCodAdicionales3(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarIdentificacionCodAdicionales2(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.registrarIdentificacionCodAdicionales2(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarCatologo(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.eliminarCatologo(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaCombos(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.listaCombos(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarIdentificacionCodAdicionales(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.registrarIdentificacionCodAdicionales(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoCatalogos(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.listadoCatalogos(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PlanillaArqueologica(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.PlanillaArqueologica(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PlanillaArqueologicaExcel(ByVal oeCatologo As eCatalogo) As DataTable
        Try
            Return odCatalogo.PlanillaArqueologicaExcel(oeCatologo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
