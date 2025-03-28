Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Imports cEntidad
Imports cLogica
Imports System.Collections.Generic
Imports System.Net

Imports iTextSharp.text
Imports iTextSharp.text.Image
Imports iTextSharp.text.html
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml
Imports iTextSharp.text.html.simpleparser
Imports System.IO
Imports System.util
Imports System.Text.RegularExpressions
Imports System.Globalization

Imports Microsoft.Reporting.WebForms
Partial Class RepTratamientoPDF
    Inherits System.Web.UI.Page
    Dim codigo_trat As String
    Dim codigo_dgc As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        If Not Session("dni") Is Nothing Then
            Dim fn As New lFunciones
            Dim oeCatologo As New eCatalogo
            Dim olCatologo As New lCatalogo

            If (Request.QueryString("TRA") <> "") Then
                codigo_trat = fn.DecrytedString64(Request.QueryString("TRA"))
                codigo_dgc = fn.DecrytedString64(Request.QueryString("DGC"))


            Else
                FormsAuthentication.RedirectToLoginPage()
            End If

        Else
            FormsAuthentication.RedirectToLoginPage()
        End If

    End Sub

    Private Sub GenerarPDF(ByVal newcodigo As String, ByVal newdgc As Integer)

        Dim adapter As New dsTratamientoxsdTableAdapters.tratam_reportePDFTableAdapter
        Dim table As New dsTratamientoxsd.tratam_reportePDFDataTable
        adapter.Fill(table, newcodigo, newdgc)


    End Sub

    Protected Sub btnGenerarRepCat_Click(sender As Object, e As EventArgs) Handles btnGenerarRepCat.Click
        GenerarPDF(codigo_trat, codigo_dgc)
    End Sub
End Class
