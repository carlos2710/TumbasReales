Imports cDatos
Imports cEntidad
Imports System.Data

Public Class lTbInventario
    Dim odTbInventario As New dTbInventario

    Public Function RegistrarTbInventario(ByVal oeTbInventario As etbInventario) As DataTable
        Try
            Return odTbInventario.RegistroTbInventario(oeTbInventario)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ModificarTbInventario(ByVal oeTbInventario As etbInventario) As DataTable
        Try
            Return odTbInventario.ModificarTbInventario(oeTbInventario)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ListarTbInventario(ByVal oeTbInventario As etbInventario) As DataTable
        Try
            Return odTbInventario.ListarTbInventario(oeTbInventario)
        Catch ex As Exception
            Throw
        End Try
    End Function
    'Inicio JAZ
    Public Function ListarTbInventarioCP(ByVal oeTbInventario As etbInventario) As DataTable
        Try
            Return odTbInventario.ListarTbInventarioCP(oeTbInventario)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ListarTbInventarioDGC(ByVal oeTbInventario As etbInventario) As DataTable
        Try
            Return odTbInventario.ListarTbInventarioDGC(oeTbInventario)
        Catch ex As Exception
            Throw
        End Try
    End Function
    'Fin JAZ
End Class
