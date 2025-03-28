Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lAfectacionInmueble
    Dim odAfectacionInmueble As New dAfectacionInmueble
    Public Function ReporteAfectaInmueblesExcel(ByVal oeAfectacionInmueble As eAfectacionInmueble) As DataTable
        Try
            Return odAfectacionInmueble.ReporteAfectaInmueblesExcel(oeAfectacionInmueble)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaInventarioInmuebles(ByVal oeAfectacionInmueble As eAfectacionInmueble) As DataTable
        Try
            Return odAfectacionInmueble.listaAfectacionInmuebles(oeAfectacionInmueble)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarAfectacionInmueble(ByVal oeAfectacionInmueble As eAfectacionInmueble) As DataTable
        Try
            Return odAfectacionInmueble.registrarAfectacionInmueble(oeAfectacionInmueble)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarAfectacionInmueble(ByVal oeAfectacionInmueble As eAfectacionInmueble) As DataTable
        Try
            Return odAfectacionInmueble.eliminarAfectacionInmueble(oeAfectacionInmueble)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
