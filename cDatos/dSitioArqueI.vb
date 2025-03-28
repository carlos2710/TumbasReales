Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Public Class dSitioArqueI

    Dim SqlHelper As New SqlHelper
    Public Function listaSitioArq(ByVal oeSitioArqueI As eSitioArqueI) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeSitioArqueI
                ds = SqlHelper.ExecuteDataset("inves_listarSitioArque")
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

    Public Function registrarInmuebles1(ByVal oeSitioArqueI As eSitioArqueI) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeSitioArqueI
                ds = SqlHelper.ExecuteDataset("invest_registrarSitioArque", .sitio_arq, .tipoarchivo_arqe, .usuarioreg)
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

    Public Function listarInmuebles1(ByVal oeSitioArqueI As eSitioArqueI) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeSitioArqueI
                ds = SqlHelper.ExecuteDataset("invest_ListarSitioArque")
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
