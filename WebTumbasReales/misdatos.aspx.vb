Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security
Imports CEntidad
Imports CLogica
Imports System.Collections.Generic
Partial Class misdatos
    Inherits System.Web.UI.Page

    Private dt As DataTable

    Private codigoFoto As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        If Not Session("dni") Is Nothing Then
            Me.txtNombre.Value = Session("apellidoPat") & " " & Session("apellidoMat") & ", " & Session("nombres")
            Me.txtEmail.Value = Session("email")
            Me.txtEmail2.Value = Session("email2")
            Me.DNI.InnerHtml = Session("dni")
            If Session("sexo") = "M" Then
                Me.SEXO.InnerHtml = "Hombre"
            Else
                Me.SEXO.InnerHtml = "Mujer"
            End If
        Else
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub
End Class
