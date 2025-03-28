Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lPublicaciones
    Dim odPublicacion As New dPublicacion
    Public Function ReportePublicaciones2(ByVal oePublicacion As ePublicacion) As DataTable
        Try
            Return odPublicacion.ReportePublicaciones2(oePublicacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ReportePublicacionesAnio(ByVal oePublicacion As ePublicacion) As DataTable
        Try
            Return odPublicacion.ReportePublicacionesAnio(oePublicacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaCombosAnioPublicaciones(ByVal oePublicacion As ePublicacion) As DataTable
        Try
            Return odPublicacion.listaCombosAnioPublicaciones(oePublicacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ReportePublicaciones(ByVal oePublicacion As ePublicacion) As DataTable
        Try
            Return odPublicacion.ReportePublicaciones(oePublicacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarPublicaciones2(ByVal oePublicacion As ePublicacion) As DataTable
        Try
            Return odPublicacion.actualizarPublicaciones2(oePublicacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarPublicacion(ByVal oePublicacion As ePublicacion) As DataTable
        Try
            Return odPublicacion.eliminarPublicacion(oePublicacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listarPublicaciones(ByVal oePublicacion As ePublicacion) As DataTable
        Try
            Return odPublicacion.listarPublicaciones(oePublicacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listaCombosPublicacion(ByVal oePublicacion As ePublicacion) As DataTable
        Try
            Return odPublicacion.listaCombosPublicacion(oePublicacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function actualizarPublicaciones(ByVal oePublicacion As ePublicacion) As DataTable
        Try
            Return odPublicacion.actualizarPublicaciones(oePublicacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
