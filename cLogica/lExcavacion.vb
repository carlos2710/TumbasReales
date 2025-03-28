Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lExcavacion
    Dim odExcavacion As New dExcavacion

    Public Function listaAnioExcavacion(ByVal oeExcavacion As eExcavacion) As DataTable
        Try
            Return odExcavacion.listaAnioExcavacion(oeExcavacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listaProyectoExcavacion(ByVal oeExcavacion As eExcavacion) As DataTable
        Try
            Return odExcavacion.listaProyectoExcavacion(oeExcavacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function registrarInmuebles2(ByVal oeExcavacion As eExcavacion) As DataTable
        Try
            Return odExcavacion.registrarInmuebles2(oeExcavacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listarInmuebles2(ByVal oeExcavacion As eExcavacion) As DataTable
        Try
            Return odExcavacion.listarInmuebles2(oeExcavacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
