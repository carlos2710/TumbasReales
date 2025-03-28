Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lArchivoCompartido
    Dim odArchivoCompartido As dArchivoCompartido
    Public Function RegistrarArchivo(ByVal oeArchivo As eArchivoCompartido) As DataTable
        Try
            Return odArchivoCompartido.registrarArchivoComp(oeArchivo)
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
