Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lSitioArqueI
    Dim odSitioArqueI As New dSitioArqueI

    Public Function listaSitioArq(ByVal oeSitioArqueI As eSitioArqueI) As DataTable
        Try
            Return odSitioArqueI.listaSitioArq(oeSitioArqueI)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function registrarInmuebles1(ByVal oeSitioArqueI As eSitioArqueI) As DataTable
        Try
            Return odSitioArqueI.registrarInmuebles1(oeSitioArqueI)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listarInmuebles1(ByVal oeSitioArqueI As eSitioArqueI) As DataTable
        Try
            Return odSitioArqueI.listarInmuebles1(oeSitioArqueI)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
