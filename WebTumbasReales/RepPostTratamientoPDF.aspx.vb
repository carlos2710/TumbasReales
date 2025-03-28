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

Partial Class RepPostTratamientoPDF
    Inherits System.Web.UI.Page
    Dim codigo_ptr As String
    Dim codigo_dgc As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        If Not Session("dni") Is Nothing Then
            Dim fn As New lFunciones
            Dim oeCatologo As New eCatalogo
            Dim olCatologo As New lCatalogo

            If (Request.QueryString("PTR") <> "") Then
                codigo_ptr = fn.DecrytedString64(Request.QueryString("PTR"))
                codigo_dgc = fn.DecrytedString64(Request.QueryString("DGC"))

            Else
                FormsAuthentication.RedirectToLoginPage()
            End If

        Else
            FormsAuthentication.RedirectToLoginPage()
        End If

    End Sub

    Private Sub GenerarPDF(ByVal newcodigo As String, ByVal newdgc As Integer)

        Dim adapter As New dsPostTratamientoTableAdapters.posttrat_reportePDFTableAdapter
        Dim table As New dsPostTratamiento.posttrat_reportePDFDataTable
        adapter.Fill(table, newcodigo, newdgc)

    End Sub

    Protected Sub btnGenerarRepCat_Click(sender As Object, e As EventArgs) Handles btnGenerarRepCat.Click
        GenerarPDF(codigo_ptr, codigo_dgc)
    End Sub
End Class
