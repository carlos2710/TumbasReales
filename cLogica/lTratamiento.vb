Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lTratamiento
    Dim odTratamiento As New dTratamiento
    Public Function ReporteTratamientoExcel(ByVal oeTratamiento As eTratamiento) As DataTable
        Try
            Return odTratamiento.ReporteTratamientoExcel(oeTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaTratamientos(ByVal oeTratamiento As eTratamiento) As DataTable
        Try
            Return odTratamiento.listaTratamientos(oeTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarTratamiento(ByVal oeTratamiento As eTratamiento) As DataTable
        Try
            Return odTratamiento.registrarTratamiento(oeTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarTratamiento2(ByVal oeTratamiento As eTratamiento) As DataTable
        Try
            Return odTratamiento.registrarTratamiento2(oeTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarTratamiento3(ByVal oeTratamiento As eTratamiento) As DataTable
        Try
            Return odTratamiento.registrarTratamiento3(oeTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarTratamiento4(ByVal oeTratamiento As eTratamiento) As DataTable
        Try
            Return odTratamiento.registrarTratamiento4(oeTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarTratamiento5(ByVal oeTratamiento As eTratamiento) As DataTable
        Try
            Return odTratamiento.registrarTratamiento5(oeTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarTratamiento6(ByVal oeTratamiento As eTratamiento) As DataTable
        Try
            Return odTratamiento.registrarTratamiento6(oeTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarTratamiento7(ByVal oeTratamiento As eTratamiento) As DataTable
        Try
            Return odTratamiento.registrarTratamiento7(oeTratamiento)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
