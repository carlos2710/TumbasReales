Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dinvestMuebles
    Dim SqlHelper As New SqlHelper
    Public Function listaAnioInvest(ByVal oeInvestMuebles As eInvestMuebles) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInvestMuebles
                ds = SqlHelper.ExecuteDataset("inves_listarAnios")
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

    Public Function listaColeccionesInvest(ByVal oeInvestMuebles As eInvestMuebles) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInvestMuebles
                ds = SqlHelper.ExecuteDataset("invest_listadoColecciones")
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

    Public Function registrarMuebles(ByVal oeInvestMuebles As eInvestMuebles, ByVal oeArchivos As eArchivoCompartido) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim odArchivos As New dArchivoCompartido


        Try
            With oeInvestMuebles
                ds = SqlHelper.ExecuteDataset("invest_registrarmuebles", .anio_mue, .coleccion_mue, .tipoarchivo_mue, .usuarioreg)
            End With

            If (ds.Tables.Count > 0) Then
                dt = ds.Tables(0)
                oeArchivos.IdTransaccion = 1
                Dim dt2 = odArchivos.registrarArchivoComp(oeArchivos)

            Else
                Return Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function listarMuebles(ByVal oeInvestMuebles As eInvestMuebles) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeInvestMuebles
                ds = SqlHelper.ExecuteDataset("invest_ListarMuebles")
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
