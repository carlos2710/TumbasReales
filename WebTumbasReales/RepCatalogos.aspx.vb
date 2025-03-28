Option Explicit On
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Imports cEntidad
Imports cLogica
Imports System.Collections.Generic
Imports System.Net
Partial Class RepCatalogos
    Inherits System.Web.UI.Page
    Private oeInventario As eInventario
    Private olInventario As lInventario

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

        If Session("dni") Is Nothing Then
            FormsAuthentication.RedirectToLoginPage()
        End If

    End Sub


    Protected Sub btnExportarRep_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportarRep.ServerClick

        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment; filename=RepCatalogos.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = System.Text.Encoding.Default
        Response.Write(HTML())
        Response.End()

    End Sub

    Private Function HTML() As String
        Dim Page1 As New Page()
        Dim Form2 As New HtmlForm()
        Dim Grid As New GridView
        Dim oeCatalogo As New eCatalogo
        Dim olCatalogo As New lCatalogo
        Dim fn As New lFunciones

        oeCatalogo.unidad_cat = Me.param1.Value
        oeCatalogo.contexto_cat = Me.param2.Value
        oeCatalogo.material_cat = Me.param3.Value
        oeCatalogo.id_dgc = fn.DecrytedString64(Me.param4.Value)
        Grid.DataSource = olCatalogo.rep_CatalogosExcel(oeCatalogo)

        Grid.DataBind()
        Grid.EnableViewState = False
        Page1.EnableViewState = False
        Page1.Controls.Add(Form2)
        Page1.EnableEventValidation = False

        'Form2.Controls.Add(Me.LblTitulo)
        Form2.Controls.Add(Grid)

        Dim builder1 As New System.Text.StringBuilder()
        Dim writer1 As New System.IO.StringWriter(builder1)
        Dim writer2 As New HtmlTextWriter(writer1)

        Page1.DesignerInitialize()
        Page1.RenderControl(writer2)
        Page1.Dispose()
        Page1 = Nothing
        Return builder1.ToString()
    End Function

End Class
