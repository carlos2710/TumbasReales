Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lEvaluacion
    Dim odEvaluacion As New dEvaluacion

    Public Function ReporteEvaluacionesExcel(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Try
            Return odEvaluacion.ReporteEvaluacionesExcel(oeEvaluacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarEliminacion(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Try
            Return odEvaluacion.eliminarEliminacion(oeEvaluacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listarFiltroEvaluacion(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Try
            Return odEvaluacion.listarFiltroEvaluacion(oeEvaluacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaEvaluaciones(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Try
            Return odEvaluacion.listaEvaluaciones(oeEvaluacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaEvaluaciones2(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Try
            Return odEvaluacion.listaEvaluaciones2(oeEvaluacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarEvaluacion(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Try
            Return odEvaluacion.registrarEvaluacion(oeEvaluacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarEvaluacion2(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Try
            Return odEvaluacion.registrarEvaluacion2(oeEvaluacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarEvaluacion3(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Try
            Return odEvaluacion.registrarEvaluacion3(oeEvaluacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarEvaluacion4(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Try
            Return odEvaluacion.registrarEvaluacion4(oeEvaluacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarEvaluacion5(ByVal oeEvaluacion As eEvaluacion) As DataTable
        Try
            Return odEvaluacion.registrarEvaluacion5(oeEvaluacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
