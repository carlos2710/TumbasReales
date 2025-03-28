Option Explicit On
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Imports cEntidad
Imports cLogica
Imports System.Collections.Generic
Imports System.Net
Partial Class informationCon
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

    Private oeEvaluacion As eEvaluacion
    Private olEvaluacion As lEvaluacion

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

            If (Request.QueryString("PER") <> "") Then
                per = fn.DecrytedString64(Request.QueryString("PER"))
                per_s = Request.QueryString("PER")
                If (Request.QueryString("TI") <> "") Then
                    tipo = fn.DecrytedString64(Request.QueryString("TI"))
                    tipo_s = Request.QueryString("TI")
                    If (Request.QueryString("GC") <> "") Then
                        gc = fn.DecrytedString64(Request.QueryString("GC"))
                        gc_s = Request.QueryString("GC")
                        Me.paramdgc.Value = Request.QueryString("GC")
                        Me.tfu.Value = Session("codigo_Tfu")
                        Listar()
                    End If
                End If
            End If
        Else
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub

    Private Sub Listar()
        oeEvaluacion = New eEvaluacion
        olEvaluacion = New lEvaluacion
        dt = New DataTable
        Dim strBody As New StringBuilder
        Dim strBody1 As New StringBuilder

        Dim fn As New lFunciones

        olColeccion = New lColeccion

        dtTI = New DataTable
        dtGC = New DataTable

        oeEvaluacion.nroficha_con = 0
        oeEvaluacion.id_dgc = gc
        dt = olEvaluacion.listaEvaluaciones(oeEvaluacion)
        dtTI = olColeccion.ListarTiposInformacion(tipo)
        dtGC = olColeccion.ListarGrupoColeccion(gc)

        Dim tipoinfo As String
        Dim coleccion As String
        If dtTI.Rows.Count > 0 Then
            For i = 0 To dtTI.Rows.Count - 1
                tipoinfo = dtTI.Rows(0).Item("descripcion").ToString
            Next
        End If

        If dtGC.Rows.Count > 0 Then
            For i = 0 To dtGC.Rows.Count - 1
                coleccion = dtGC.Rows(0).Item("descripcion_gco").ToString & " - " & dtGC.Rows(0).Item("descripcion_dgc").ToString
            Next
        End If

        Me.titulo.InnerHtml = tipoinfo & " - " & coleccion
        Me.titulo.InnerHtml = Me.titulo.InnerHtml & " &nbsp;&nbsp; <a href='#' onclick='f_Menu(""Conservacion.aspx?PER=" & per_s & "&TI=" & tipo_s & """)'><i class='ion-reply-all btn btn-white'></i></a>" '& " &nbsp;&nbsp; <button type='button' class='btn btn-green' id='btnExportarRep' runat='server' ><i class='ion-android-done'></i>&nbsp;Exportar Reporte</button>"


        'If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
        '    With dt.Rows(0)
        '        If (dt IsNot Nothing) Then
        '            For i As Integer = 0 To dt.Rows.Count - 1
        '                strBody.Append("<tr id='" & dt.Rows(i).Item("codpropietario_cat") & "' >")
        '                strBody.Append("<td><a href='#' class='btn btn-orange btn-xs' onclick='fnEditar(""" & fn.EncrytedString64(dt.Rows(i).Item("nroficha_con")) & """)' ><i class='ion-edit'></i></a>")
        '                strBody.Append("<a href='#' class='btn btn-red btn-xs' onclick='fnBorrarG(""" & fn.EncrytedString64(dt.Rows(i).Item("nroficha_con")) & """,""" & fn.EncrytedString64(dt.Rows(i).Item("codpropietario")) & """)' ><i class='ion-android-cancel'></i></a></td>")
        '                strBody.Append("<td>" & dt.Rows(i).Item("codpropietario") & "</td>")
        '                strBody.Append("<td>" & dt.Rows(i).Item("denominacion") & "</td>")
        '                strBody.Append("<td>" & dt.Rows(i).Item("codexcavacion") & "</td>")
        '                strBody.Append("<td>" & dt.Rows(i).Item("material").ToString.ToUpper & "</td>")
        '                strBody.Append("<td>" & dt.Rows(i).Item("material").ToString.ToUpper & "</td>")
        '                strBody.Append("</tr>")
        '            Next
        '        End If

        '        Me.pEvaluacion.InnerHtml = strBody.ToString
        '    End With
        'End If

    End Sub

    Protected Sub btnExportarRep_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportarRep.ServerClick
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment; filename=RepConservaciones.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = System.Text.Encoding.Default
        Response.Write(HTML())
        Response.End()
    End Sub

    Protected Sub bbtnExportarRepT_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportarRepT.ServerClick
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment; filename=RepTratamientos.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = System.Text.Encoding.Default
        Response.Write(HTMLT())
        Response.End()
    End Sub

    Protected Sub btnExportarRepPT_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportarRepPT.ServerClick
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment; filename=RepPostTratamientos.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = System.Text.Encoding.Default
        Response.Write(HTMLPt())
        Response.End()
    End Sub

    Protected Sub btnExportarRepA_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportarRepA.ServerClick
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment; filename=RepAlamcenes.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = System.Text.Encoding.Default
        Response.Write(HTMLA())
        Response.End()
    End Sub

    Private Function HTML() As String
        Dim Page1 As New Page()
        Dim Form2 As New HtmlForm()
        Dim Grid As New GridView
        Dim oeEvaluacion As New eEvaluacion
        Dim olEvaluacion As New lEvaluacion

        oeEvaluacion.id_dgc = gc
        Grid.DataSource = olEvaluacion.ReporteEvaluacionesExcel(oeEvaluacion)

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

    Private Function HTMLT() As String
        Dim Page1 As New Page()
        Dim Form2 As New HtmlForm()
        Dim Grid As New GridView
        Dim oeTratamiento As New eTratamiento
        Dim olTratamiento As New lTratamiento

        oeTratamiento.id_dgc = gc
        Grid.DataSource = olTratamiento.ReporteTratamientoExcel(oeTratamiento)

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

    Private Function HTMLPt() As String
        Dim Page1 As New Page()
        Dim Form2 As New HtmlForm()
        Dim Grid As New GridView
        Dim oePostTratamiento As New ePostTratamiento
        Dim olPostTratamiento As New lPostTratamiento

        oePostTratamiento.id_dgc = gc
        Grid.DataSource = olPostTratamiento.ReportePostTratamientoExcel(oePostTratamiento)

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


    Private Function HTMLA() As String
        Dim Page1 As New Page()
        Dim Form2 As New HtmlForm()
        Dim Grid As New GridView
        Dim oeAlmacenes As New eAlmacenes
        Dim olAlmacenes As New lAlmacenes

        oeAlmacenes.id_dgc = gc
        Grid.DataSource = olAlmacenes.ReporteAlmacenesExcel(oeAlmacenes)

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
