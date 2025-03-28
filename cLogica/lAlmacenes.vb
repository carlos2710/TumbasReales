Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lAlmacenes
    Dim odAlmacenes As New dAlmacenes
    Public Function ReporteAlmacenesExcel(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Try
            Return odAlmacenes.ReporteAlmacenesExcel(oeAlmacenes)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaAlmacenes(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Try
            Return odAlmacenes.listaAlmacenes(oeAlmacenes)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarAlmacenes(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Try
            Return odAlmacenes.registrarAlmacenes(oeAlmacenes)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarAlmacenes2(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Try
            Return odAlmacenes.registrarAlmacenes2(oeAlmacenes)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarAlmacenes3(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Try
            Return odAlmacenes.registrarAlmacenes3(oeAlmacenes)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarAlmacenes4(ByVal oeAlmacenes As eAlmacenes) As DataTable
        Try
            Return odAlmacenes.registrarAlmacenes4(oeAlmacenes)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
