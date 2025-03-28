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

imports Microsoft.Reporting.WebForms

Partial Class RepCatalogoPDF
    Inherits System.Web.UI.Page
    Dim codigo_cat As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        If Not Session("dni") Is Nothing Then
            Dim fn As New lFunciones
            Dim oeCatologo As New eCatalogo
            Dim olCatologo As New lCatalogo

            If (Request.QueryString("CAT") <> "") Then
                codigo_cat = fn.DecrytedString64(Request.QueryString("CAT"))
            Else
                FormsAuthentication.RedirectToLoginPage()
            End If
        End If

    End Sub

    Private Sub GenerarPDF(ByVal newcodigo As String)

        Dim adapter As New dsTumbasReales1TableAdapters.cat_reportePDFTableAdapter
        Dim table As New dsTumbasReales1.cat_reportePDFDataTable
        adapter.Fill(table, newcodigo)


    End Sub

    Protected Sub btnGenerarRepCat_Click(sender As Object, e As EventArgs) Handles btnGenerarRepCat.Click
        GenerarPDF(codigo_cat)
    End Sub
End Class
