Imports cDatos
Imports cEntidad
Public Class lMenuAplicacion
    Dim odMenuAplicacion As New dMenuAplicacion
    Public Function Listar(ByVal oeMenuAplicacion As eMenuAplicacion) As List(Of eMenuAplicacion)
        Try
            Return odMenuAplicacion.Listar(oeMenuAplicacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarColeccionDetalle() As DataTable
        Try
            Return odMenuAplicacion.ListarColeccionDetalle()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
