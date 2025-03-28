Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Imports cEntidad
Imports cLogica
Imports System.Collections.Generic
Imports System.Net

Partial Class GrupoColecciones
    Inherits System.Web.UI.Page
    Private oeCatalogo As eCatalogo
    Private olCatalogo As lCatalogo

    Private dt As DataTable
    Private dtCol As DataTable
    Private oeAlumno As eAlumno
    Private olAlumno As lAlumno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Session("dni") Is Nothing Then
                FormsAuthentication.RedirectToLoginPage()
            Else
                Listar()
            End If

        End If
    End Sub

    Private Sub Listar()
        oeCatalogo = New eCatalogo
        olCatalogo = New lCatalogo
        dt = New DataTable
        Dim strBody As New StringBuilder
        Dim strBody1 As New StringBuilder
        oeCatalogo.TipoOperacion = ""
        dt = olCatalogo.listadoCatalogos(oeCatalogo)

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            With dt.Rows(0)
                If (dt IsNot Nothing) Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        strBody.Append("<tr id='" & dt.Rows(i).Item("codpropietario_cat") & "' >")
                        strBody.Append("<td><a href='#' class='btn btn-orange btn-xs' onclick='fnEditar(""" & dt.Rows(i).Item("codpropietario_cat") & """)' ><i class='ion-edit'></i></a>")
                        strBody.Append("<a href='#' class='btn btn-red btn-xs' onclick='fnBorrarG(""" & dt.Rows(i).Item("codpropietario_cat") & """)' ><i class='ion-android-cancel'></i></a></td>")
                        strBody.Append("<td>" & dt.Rows(i).Item("codregnac_cat") & "</td>")
                        strBody.Append("<td>" & dt.Rows(i).Item("codexcavacion_cat") & "</td>")
                        strBody.Append("<td>" & dt.Rows(i).Item("codreginc_cat") & "</td>")
                        strBody.Append("<td>" & dt.Rows(i).Item("codinvinc_cat").ToString.ToUpper & "</td>")
                        strBody.Append("<td>" & dt.Rows(i).Item("otrocodigos_cat").ToString.ToUpper & "</td>")
                        strBody.Append("</tr>")
                    Next
                End If

                Me.pDatosGradoEgresado.InnerHtml = strBody.ToString
            End With
        End If

    End Sub
End Class

