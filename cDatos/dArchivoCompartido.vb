Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dArchivoCompartido
    Dim SqlHelper As New SqlHelper
    Public Function registrarArchivoComp(ByVal oeArchivoComp As eArchivoCompartido) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeArchivoComp
                ds = SqlHelper.ExecuteDataset("USP_ARCHIVOSCOMPATIDOS", "1", .IdArchivosCompartidos, .NombreArchivo, .Fecha, .Extencion, .IdTabla, .IdTransaccion, .NroOperacion, .Descripcion, .RutaArchivo, .UsuarioReg, .IpReg)
            End With

            If (ds.Tables.Count > 0) Then
                dt = ds.Tables(0)
            Else
                Return Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
