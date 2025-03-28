Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lExposiciones
    Dim odExposicion As New dExposicion
    Public Function ReporteExposicionesAnio2(ByVal oeExposicion As eExposicion) As DataTable
        Try
            Return odExposicion.ReporteExposicionesAnio2(oeExposicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ReporteExposicionesAnio(ByVal oeExposicion As eExposicion) As DataTable
        Try
            Return odExposicion.ReporteExposicionesAnio(oeExposicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaCombosAniosExposiciones(ByVal oeExposicion As eExposicion) As DataTable
        Try
            Return odExposicion.listaCombosAniosExposiciones(oeExposicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ReporteExposiciones(ByVal oeExposicion As eExposicion) As DataTable
        Try
            Return odExposicion.ReporteExposiciones(oeExposicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarExposiciones2(ByVal oeExposicion As eExposicion) As DataTable
        Try
            Return odExposicion.actualizarExposiciones2(oeExposicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarExposicion(ByVal oeExposicion As eExposicion) As DataTable
        Try
            Return odExposicion.eliminarExposicion(oeExposicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listarExposiciones(ByVal oeExposicion As eExposicion) As DataTable
        Try
            Return odExposicion.listarExposiciones(oeExposicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listaCombosPublicacion(ByVal oeExposicion As eExposicion) As DataTable
        Try
            Return odExposicion.listaCombosPublicacion(oeExposicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function actualizarExposiciones(ByVal oeExposicion As eExposicion) As DataTable
        Try
            Return odExposicion.actualizarExposiciones(oeExposicion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
