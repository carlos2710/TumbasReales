Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lColeccion
    Dim odColeccion As New dColeccion
    Public Function ListarGrupoColeccion(ByVal gc As Integer) As DataTable
        Try
            Return odColeccion.ListarGrupoColeccion(gc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarTiposInformacion(ByVal ti As Integer) As DataTable
        Try
            Return odColeccion.ListarTiposInformacion(ti)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarColeccionDetalle(ByVal ti As Integer) As DataTable
        Try
            Return odColeccion.ListarColeccionDetalle(ti)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
