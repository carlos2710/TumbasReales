Imports cDatos
Imports cEntidad
Imports System.Data
Public Class linventarioInmuebles
    Dim odInventarioInmuebles As New dInventarioInmuebles
    Public Function ReporteInvInmueblesExcel(ByVal oeInventarioInmuebles As eInventarioInmuebles) As DataTable
        Try
            Return odInventarioInmuebles.ReporteInvInmueblesExcel(oeInventarioInmuebles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaInventarioInmuebles(ByVal oeInventarioInmuebles As eInventarioInmuebles) As DataTable
        Try
            Return odInventarioInmuebles.listaInventarioInmuebles(oeInventarioInmuebles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarInmueble1(ByVal oeInventarioInmuebles As eInventarioInmuebles) As DataTable
        Try
            Return odInventarioInmuebles.registrarInmueble1(oeInventarioInmuebles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarInmueble2(ByVal oeInventarioInmuebles As eInventarioInmuebles) As DataTable
        Try
            Return odInventarioInmuebles.registrarInmueble2(oeInventarioInmuebles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminarInmueble(ByVal oeInventarioInmuebles As eInventarioInmuebles) As DataTable
        Try
            Return odInventarioInmuebles.eliminarInmueble(oeInventarioInmuebles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
