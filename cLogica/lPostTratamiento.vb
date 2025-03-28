Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lPostTratamiento
    Dim odPostTratamiento As New dPostTratamiento
    Public Function ReportePostTratamientoExcel(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Try
            Return odPostTratamiento.ReportePostTratamientoExcel(oePostTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaPostTratemientos(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Try
            Return odPostTratamiento.listaPostTratemientos(oePostTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarPostTratamiento(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Try
            Return odPostTratamiento.registrarPostTratamiento(oePostTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarPostTratamiento2(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Try
            Return odPostTratamiento.registrarPostTratamiento2(oePostTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarPostTratamiento3(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Try
            Return odPostTratamiento.registrarPostTratamiento3(oePostTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarPostTratamiento4(ByVal oePostTratamiento As ePostTratamiento) As DataTable
        Try
            Return odPostTratamiento.registrarPostTratamiento4(oePostTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
