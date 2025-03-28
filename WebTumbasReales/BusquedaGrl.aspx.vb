Option Explicit On
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Imports cEntidad
Imports cLogica
Imports System.Collections.Generic
Imports System.Net
Partial Class BusquedaGrl
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
        End If
        If Not Session("dni") Is Nothing Then
            Dim fn As New lFunciones
            oeCatalogo = New eCatalogo
            olCatalogo = New lCatalogo
            dt = New DataTable
            Dim strBody As New StringBuilder
            Dim strBody1 As New StringBuilder

            If (Request.QueryString("SEA") <> "") Then
                oeCatalogo.nombreclasif_cat = Request.QueryString("SEA")
                dt = olCatalogo.SearchGeneral(oeCatalogo)

                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    With dt.Rows(0)
                        If (dt IsNot Nothing) Then
                            For i As Integer = 0 To dt.Rows.Count - 1
                                strBody.Append("<tr>")
                                strBody.Append("<td style='text-align:center'>" & dt.Rows(i).Item("informacion") & "</td>")
                                strBody.Append("<td style='text-align:center'>" & dt.Rows(i).Item("descripcion") & "</td>")
                                strBody.Append("<td style='text-align:center'>" & dt.Rows(i).Item("cultura") & "</td>")
                                strBody.Append("<td style='text-align:center'>" & dt.Rows(i).Item("material") & "</td>")
                                strBody.Append("<td style='text-align:center'>" & dt.Rows(i).Item("tipo") & "</td>")
                                strBody.Append("</tr>")
                            Next
                        End If

                        Me.pSearchGrl.InnerHtml = strBody.ToString
                    End With
                End If
            End If
        Else
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub

End Class
