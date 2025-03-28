Imports cDatos
Imports cEntidad
Imports System.Data
Public Class linvestMuebles
    Dim odinvestMuebles As New dinvestMuebles

    Public Function listaAnioInvest(ByVal oeInvestMuebles As eInvestMuebles) As DataTable
        Try
            Return odinvestMuebles.listaAnioInvest(oeInvestMuebles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listaColeccionesInvest(ByVal oeInvestMuebles As eInvestMuebles) As DataTable
        Try
            Return odinvestMuebles.listaColeccionesInvest(oeInvestMuebles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function registrarMuebles(ByVal oeInvestMuebles As eInvestMuebles, ByVal oeArchivos As eArchivoCompartido) As DataTable
        Try
            Return odinvestMuebles.registrarMuebles(oeInvestMuebles, oeArchivos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listarMuebles(ByVal oeInvestMuebles As eInvestMuebles) As DataTable
        Try
            Return odinvestMuebles.listarMuebles(oeInvestMuebles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
