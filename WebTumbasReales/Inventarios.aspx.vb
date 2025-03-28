Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Imports cEntidad
Imports cLogica
Imports System.Collections.Generic
Imports System.Net
Partial Class Inventarios
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
                    ColeccionDetalle()
                End If
            End If
        Else
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub
    Private Sub ColeccionDetalle()
        dtCol = New DataTable
        olColeccion = New lColeccion

        Dim fn As New lFunciones
        dtTI = New DataTable
        Dim i As Integer = 1
        Dim contador As Integer = 1
        Dim formato As String = ""
        dtCol = olColeccion.ListarColeccionDetalle(tipo)
        dtTI = olColeccion.ListarTiposInformacion(tipo)

        If dtTI.Rows.Count > 0 Then
            For i = 0 To dtTI.Rows.Count - 1
                Me.titulo_TI.InnerHtml = dtTI.Rows(0).Item("descripcion").ToString '& " &nbsp;&nbsp; <a href='#' onclick='f_Menu(""Main.aspx"")'><i class='ion-reply-all btn btn-white'></i></a>"
            Next
        End If



        If dtCol.Rows.Count > 0 Then
            For i = 1 To dtCol.Rows.Count
                If (contador = dtCol.Rows(i - 1).Item("id_gco").ToString) Then
                    If contador <> 1 Then
                        formato += "</div>"
                        formato += "</div>"
                    End If
                    contador = contador + 1
                    formato += "<div class='panel-body col-md-3'>"
                    formato += "  <div class='panel panel-piluku-col' >"
                    formato += "    <div class='panel-heading' style='background-color:#2A2929; color:black;align:center'>"
                    formato += "    <h3 class='panel-title' style='text-align:center'>"
                    formato += "        <b style='color:#fff'>" + dtCol.Rows(i - 1).Item("descripcion_gco").ToString + "</b>"
                    formato += "    </h3>"
                    formato += "    </div>"
                    formato += "        <div class='colecciones'>"
                    formato += "<img class='avatar-sipan' src='assets/images/sipan1.jpg' alt='' height='20px' widht='20px'><a href='#' onclick='f_Menu(""informationInv.aspx" + "?PER=" + Session("codigo_per") + "&TI=" + tipo_s + "&GC=" + fn.EncrytedString64(dtCol.Rows(i - 1).Item("id_dgc").ToString) + """)'>  " + dtCol.Rows(i - 1).Item("descripcion_dgc").ToString + "</a>"
                    formato += "        </div>"
                Else
                    formato += "<div class='colecciones'>"
                    formato += "<img class='avatar-sipan' src='assets/images/sipan1.jpg' alt='' height='20px' widht='20px'><a href='#' onclick='f_Menu(""informationInv.aspx" + "?PER=" + Session("codigo_per") + "&TI=" + tipo_s + "&GC=" + fn.EncrytedString64(dtCol.Rows(i - 1).Item("id_dgc").ToString) + """)'>  " + dtCol.Rows(i - 1).Item("descripcion_dgc").ToString + "</a>"
                    formato += "</div>"
                End If
            Next
            formato += "</div>"
            formato += "</div>"
            Me.colecciones.InnerHtml = formato
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

                'Me.pDatosGradoEgresado.InnerHtml = strBody.ToString
            End With
        End If

    End Sub

End Class
