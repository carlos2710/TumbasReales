Option Explicit On
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Imports cEntidad
Imports cLogica
Imports System.Collections.Generic
Imports System.Net

Partial Class Usuarios
    Inherits System.Web.UI.Page
    Private oeCatalogo As eCatalogo
    Private olCatalogo As lCatalogo

    Private dt As DataTable
    Private dtCol As DataTable
    Private oeAlumno As eAlumno
    Private olAlumno As lAlumno
    Private dtTI As DataTable
    Private dtGC As DataTable

    Private oeColeccion As eColeccion
    Private olColeccion As lColeccion

    Dim tipo As Integer
    Dim per As Integer
    Dim gc As Integer
    Dim tipo_s As String
    Dim per_s As String
    Dim gc_s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Session("dni") Is Nothing Then
                FormsAuthentication.RedirectToLoginPage()
            Else
                Me.tfu.Value = Session("codigo_Tfu")
            End If
        End If
    End Sub
End Class
