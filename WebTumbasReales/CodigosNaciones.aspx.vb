Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Imports cEntidad
Imports cLogica
Imports System.Collections.Generic
Imports System.Net
Partial Class CodigosNaciones
    Inherits System.Web.UI.Page
    Private oeCatalogo As eCatalogo
    Private olCatalogo As lCatalogo

    Private oeColeccion As eColeccion
    Private olColeccion As lColeccion
    Dim crear As Boolean = False

    Private dt As DataTable
    Private dtCol As DataTable
    Private dtTI As DataTable
    Private oeAlumno As eAlumno
    Private olAlumno As lAlumno

    Dim tipo As Integer
    Dim per As Integer
    Dim per_s As String
    Dim tipo_s As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If
        If Not Session("dni") Is Nothing Then
            Dim fn As New lFunciones

            If (Request.QueryString("PER") <> "") Then
                per = fn.DecrytedString64(Request.QueryString("PER"))
                per_s = Request.QueryString("PER")
                If (Request.QueryString("TI") <> "") Then
                    tipo_s = Request.QueryString("TI")
                    tipo = fn.DecrytedString64(Request.QueryString("TI"))

                End If
            End If

        Else
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub

    Protected Sub btnExportarRep_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportarRep.ServerClick

        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment; filename=RepPlanillaArqueologica.xls")
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

        Grid.DataSource = olCatalogo.PlanillaArqueologicaExcel(oeCatalogo)

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
