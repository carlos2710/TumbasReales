Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Imports cEntidad
Imports cLogica
Imports System.Collections.Generic
Imports System.Net

Partial Class Mantenimientos
    Inherits System.Web.UI.Page
    Private oeMenuAplicacion As eMenuAplicacion
    Private olMenuAplicacion As lMenuAplicacion
    Private lsMenuAplicacion As List(Of eMenuAplicacion)

    Private oeColeccion As eColeccion
    Private olColeccion As lColeccion
    Dim crear As Boolean = False

    Private dt As DataTable
    Private dtCol As DataTable
    Private oeAlumno As eAlumno
    Private olAlumno As lAlumno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        If Session("dni") Is Nothing Then
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub

    

End Class
