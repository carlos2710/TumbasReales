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

Partial Class Main
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

            '#001 FIN - JR
        'If Not Session("codigo_Alu") Is Nothing Then
        If Not Session("dni") Is Nothing Then

            oeMenuAplicacion = New eMenuAplicacion
            olMenuAplicacion = New lMenuAplicacion
            lsMenuAplicacion = New List(Of eMenuAplicacion)
            oeMenuAplicacion.tipoOperacion = "0"
            oeMenuAplicacion.param1 = 1
            oeMenuAplicacion.param2 = 0
            oeMenuAplicacion.param3 = 5
            'lsMenuAplicacion = olMenuAplicacion.Listar(oeMenuAplicacion)
            'Session.Add("lstMenu", lsMenuAplicacion)
            crear = True

            'llena colección dinamicamente
            ColeccionDetalle()

            If Not Session("lstMenu") Is Nothing AndAlso crear Then
                lsMenuAplicacion = Session("lstMenu")
                crear = True
            End If
            If crear Then

                'crearMenu(lsMenuAplicacion)
            End If


            oeMenuAplicacion = Nothing
            olMenuAplicacion = Nothing
            lsMenuAplicacion = Nothing
        Else
            FormsAuthentication.RedirectToLoginPage()
        End If
        '#001 - JR


    End Sub

    Sub descargar()
        Try
            'Dim documento As New Document(PageSize.A4, 85, 85, 67, 50)
            Dim documento As New Document(PageSize.A4, 0, 0, 0, 0)
            Dim ms As New MemoryStream
            Dim writer As PdfWriter
            writer = PdfWriter.GetInstance(documento, ms)

            Dim textohtml As String = ""

            'textohtml = textohtml.Replace("jr/" & Session("photoEgre"), Server.MapPath("~") & "jr/" & Session("photoEgre"))
            textohtml &= "<table style=""border: 1px solid black;width:100%"" border=""1"">"
            textohtml &= "<tr>"
            textohtml &= "<td rowspan=""2"" style=""width:20%"">a"
            'textohtml &= "<img  src='" + Server.MapPath("~") & +"/assets/images/logo.jpg' alt='Ministerio de Cultura del Perú' height='50px' widht='200px'>"
            textohtml &= "</td>"
            textohtml &= "<td colspan=""2"" style=""width:60%;font-weight:bold;font-size:8px;text-align:center"" >UNIDAD EJECUTORA 005 - NAYLAMP LAMBAYEQUE</td>"
            textohtml &= "<td rowspan=""2"" style=""width:20%"">a"
            'textohtml &= "<img  src='" + Server.MapPath("~") & +"/assets/images/museo-tumbas-reales3.jpg' alt='Ministerio de Cultura del Perú' height=" '50px' widht='200px'>"
            textohtml &= "</td>"
            textohtml &= "</tr>"
            textohtml &= "<tr>"
            textohtml &= "<td style=""font-weight:bold;font-size:8px;text-align:center"">MUSEO TUMBAS REALES DE SIPAN</td>"
            textohtml &= "</tr>"
            textohtml &= "<tr>"
            textohtml &= "<td style=""font-weight:bold;font-size:8px;text-align:center"" >CATALOGO DE BIENES ARQUEOLOGICOS MUEBLES</td>"
            textohtml &= "</tr>"
            textohtml &= "</table>"

            textohtml = ""
            textohtml &= "<table style=""width:100%"" border=""1"">"
            textohtml &= "<tr>"
            textohtml &= "<td  rowspan=""3"">a</td>"
            textohtml &= "<td >b</td>"
            textohtml &= "<td  rowspan=""3"">c</td>"
            textohtml &= "</tr>"
            textohtml &= "<tr>"
            textohtml &= "<td >d</td>"
            textohtml &= "</tr>"
            textohtml &= "<tr>"
            textohtml &= "<td >d</td>"
            textohtml &= "</tr>"
            textohtml &= "</table>"

            'Response.Write(textohtml)
            '------------------------------------------------------------------------------        
            'PDF
            '------------------------------------------------------------------------------                   
            Dim se As New StringReader(textohtml)
            Dim obj As New HTMLWorker(documento)

            Dim rootPath As String = Server.MapPath("~")
            Dim customfont As BaseFont

            Dim style As New StyleSheet

            documento.Open()
            obj.Parse(se)

            documento.Close()
            Response.Clear()
            Dim reg As RegularExpressions.Regex
            Dim textoOriginal As String = Session("dni")
            Dim textoNormalizado As String = textoOriginal.Normalize(NormalizationForm.FormD)
            reg = New RegularExpressions.Regex("[^a-zA-Z0-9 ]")
            Dim nombreEgresadoSinAcentos As String = reg.Replace(textoNormalizado, "")
            Response.AddHeader("content-disposition", "attachment; filename=pdf" & "a" & ".pdf")
            Response.ContentType = "application/pdf"
            Response.Buffer = True
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length)
            Response.OutputStream.Flush()
            Response.End()
        Catch ex As Exception
            Response.Write(ex.Message & " - " & ex.StackTrace)
        End Try

    End Sub

    Private Sub ColeccionDetalle()
        dtCol = New DataTable
        olColeccion = New lColeccion
        Dim i As Integer = 1
        Dim contador As Integer = 1
        Dim formato As String = ""
        'dtCol = olColeccion.ListarColeccionDetalle()

        'If dtCol.Rows.Count > 0 Then
        '    For i = 1 To dtCol.Rows.Count
        '        If (contador = dtCol.Rows(i - 1).Item("id_gco").ToString) Then
        '            If contador <> 1 Then
        '                formato += "</div>"
        '                formato += "</div>"
        '            End If
        '            contador = contador + 1
        '            formato += "<div class='panel-body col-md-3'>"
        '            formato += "  <div class='panel panel-piluku' >"
        '            formato += "    <div class='panel-heading' style='background-color:White; color:black'>"
        '            formato += "    <h3 class='panel-title'>"
        '            formato += "        <b style='color:red'>" + dtCol.Rows(i - 1).Item("descripcion_gco").ToString + "</b>"
        '            formato += "    </h3>"
        '            formato += "    </div>"
        '            formato += "        <div>"
        '            formato += "<a href='#' onclick='f_Menu(""information.aspx"")'> <i class='ion-android-create' > </i> " + dtCol.Rows(i - 1).Item("descripcion_dgc").ToString + "</a>"
        '            formato += "        </div>"
        '        Else
        '            formato += "<div>"
        '            formato += "<a href='#' onclick='f_Menu(""information.aspx"")'> <i class='ion-android-create' > </i> " + dtCol.Rows(i - 1).Item("descripcion_dgc").ToString + "</a>"
        '            formato += "</div>"
        '        End If
        '    Next
        '    formato += "</div>"
        '    formato += "</div>"
        '    'Me.colecciones.InnerHtml = formato
        'End If

        Dim fn As New lFunciones
        Dim izq As String = ""
        Dim der As String = ""
        Dim medio As String = ""
        dtCol = olColeccion.ListarTiposInformacion(0)

        If dtCol.Rows.Count > 0 Then
            For i = 1 To dtCol.Rows.Count
                If i <= 3 Then
                    izq += "<div  style='height:50px; border-style: double; border-width: 4px;margin-bottom:15px; color:#1E5127;' > "
                    izq += " <div style='display: flex;justify-content: center;align-items: center;'>"
                    izq += " <img class='avatar-sipan' src='assets/images/sipan1.jpg' alt='' height='20px' widht='20px'><a href='#' onclick='f_Menu(""" + dtCol.Rows(i - 1).Item("enlace").ToString + "?PER=" + Session("codigo_per") + "&TI=" + fn.EncrytedString64(dtCol.Rows(i - 1).Item("id").ToString) + """)'>  " + dtCol.Rows(i - 1).Item("descripcion").ToString + "</a>"
                    izq += "  </div>"
                    izq += "</div>"
                Else
                    If i <= 6 Then
                        der += "<div style='height:50px; border-style: double; border-width: 4px;margin-bottom:15px; color:#1E5127;'  >"
                        der += "  <div style='display: flex;justify-content: center;align-items: center;'>"
                        der += "  <img class='avatar-sipan' src='assets/images/sipan1.jpg' alt='' height='20px' widht='20px'>  <a href='#' onclick='f_Menu(""" + dtCol.Rows(i - 1).Item("enlace").ToString + "?PER=" + Session("codigo_per") + "&TI=" + fn.EncrytedString64(dtCol.Rows(i - 1).Item("id").ToString) + """)'>  " + dtCol.Rows(i - 1).Item("descripcion").ToString + "</a>"
                        der += "  </div>"
                        der += "</div>"
                    Else
                        medio += "<div style='height:50px; border-style: double; border-width: 4px;margin-bottom:15px; color:#1E5127;'  >"
                        medio += "  <div style='display: flex;justify-content: center;align-items: center;'>"
                        medio += "  <img class='avatar-sipan' src='assets/images/sipan1.jpg' alt='' height='20px' widht='20px'>  <a href='#' onclick='f_Menu(""" + dtCol.Rows(i - 1).Item("enlace").ToString + "?PER=" + Session("codigo_per") + "&TI=" + fn.EncrytedString64(dtCol.Rows(i - 1).Item("id").ToString) + """)'>  " + dtCol.Rows(i - 1).Item("descripcion").ToString + "</a>"
                        medio += "  </div>"
                        medio += "</div>"
                    End If
                End If
            Next

            Me.izquierda.InnerHtml = izq
            Me.derecha.InnerHtml = der
            Me.medio.InnerHtml = medio

        End If

    End Sub
    Private Sub crearMenu(ByVal lista As List(Of eMenuAplicacion))
        Try

            Dim strMenu As New StringBuilder

            strMenu.Append("<ul class='list-unstyled menu-parent' id='mainMenu'>")

            'strMenu.Append("<li><a href='#' class='waves-effect waves-light' ><i class='icon ti-home'></i><span class='text '>Dashboard</span></a></li>")


            If lista.Count > 0 Then

                For Each Fila As eMenuAplicacion In lista

                    If NoTienePadre(Fila) Then
                        If TieneHijos(lista, Fila) Then
                            strMenu.Append("<li class='submenu'>")
                            strMenu.Append("<a class='waves-effect waves-light' href='#" & Fila.codigo_Men & "'>")
                            strMenu.Append(" <i class='icon " & Fila.icono_Men & "'></i>")
                            strMenu.Append("<span class='text'> " & Fila.descripcion_Men & "</span>")
                            strMenu.Append("<i class='chevron ti-angle-right'></i></a>")
                            strMenu.Append(LlenarMenu(lista, Fila))
                            strMenu.Append("</li>")
                        Else
                            strMenu.Append("<li>")

                            If Fila.target = "" Then
                                strMenu.Append("<a href='#'  onclick=f_Menu('" & Fila.enlace_men & "')>")
                            Else
                                strMenu.Append("<a href='" & Fila.link & "' target='" & Fila.target & "' )>")
                            End If


                            strMenu.Append("<i class='icon " & Fila.icono_Men & "'></i>")
                            strMenu.Append("<span class='text'> " & Fila.descripcion_Men & "</span>")
                            strMenu.Append("</a>")
                            strMenu.Append("</li>")
                        End If

                    End If
                    ' strMenu.Append("</li>")
                Next

                strMenu.Append("</li>")
                strMenu.Append("</ul>")

                'divLeftbar.InnerHtml = strMenu.ToString

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub crearMenuInactivo(ByVal lista As List(Of eMenuAplicacion))
        Try

            Dim strMenu As New StringBuilder

            strMenu.Append("<ul class='list-unstyled menu-parent' id='mainMenu'>")

            'strMenu.Append("<li><a href='#' class='waves-effect waves-light' ><i class='icon ti-home'></i><span class='text '>Dashboard</span></a></li>")


            If lista.Count > 0 Then

                For Each Fila As eMenuAplicacion In lista
                    If Fila.accesoAlumnoInactivo Then
                        If NoTienePadre(Fila) Then
                            If TieneHijos(lista, Fila) Then
                                strMenu.Append("<li class='submenu'>")
                                strMenu.Append("<a class='waves-effect waves-light' href='#" & Fila.codigo_Men & "'>")
                                strMenu.Append(" <i class='icon " & Fila.icono_Men & "'></i>")
                                strMenu.Append("<span class='text'> " & Fila.descripcion_Men & "</span>")
                                strMenu.Append("<i class='chevron ti-angle-right'></i></a>")
                                strMenu.Append(LlenarMenuInactivo(lista, Fila))
                                strMenu.Append("</li>")
                            Else
                                strMenu.Append("<li>")

                                If Fila.target = "" Then
                                    strMenu.Append("<a href='#'  onclick=f_Menu('" & Fila.enlace_men & "')>")
                                Else
                                    strMenu.Append("<a href='" & Fila.link & "' target='" & Fila.target & "' )>")
                                End If


                                strMenu.Append("<i class='icon " & Fila.icono_Men & "'></i>")
                                strMenu.Append("<span class='text'> " & Fila.descripcion_Men & "</span>")
                                strMenu.Append("</a>")
                                strMenu.Append("</li>")
                            End If

                        End If
                    End If
                Next

                strMenu.Append("</li>")
                strMenu.Append("</ul>")

                'divLeftbar.InnerHtml = strMenu.ToString

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Function LlenarMenu(ByVal lista As List(Of eMenuAplicacion), ByVal oe As eMenuAplicacion) As String
        Try
            Dim cadMenu As String = ""
            '0: padre
            '1: padre con hijos y tiene padre
            '2: hijo
            'es padre



            If TienePadreHijos(lista, oe) Then


            End If

            If TieneHijos(lista, oe) Then

                cadMenu = cadMenu & "<ul class='list-unstyled' id='" & oe.codigo_Men & "'>"

                cadMenu = cadMenu & ListaHijos(lista, oe)

                cadMenu = cadMenu & "</ul>"



            End If



            Return cadMenu

        Catch ex As Exception
            Throw
        End Try

    End Function
    Private Function LlenarMenuInactivo(ByVal lista As List(Of eMenuAplicacion), ByVal oe As eMenuAplicacion) As String
        Try
            Dim cadMenu As String = ""
            '0: padre
            '1: padre con hijos y tiene padre
            '2: hijo
            'es padre




            If TieneHijos(lista, oe) Then

                If oe.accesoAlumnoInactivo Then
                    cadMenu = cadMenu & "<ul class='list-unstyled' id='" & oe.codigo_Men & "'>"

                    cadMenu = cadMenu & ListaHijosInactivos(lista, oe)

                    cadMenu = cadMenu & "</ul>"

                End If

            End If



            Return cadMenu

        Catch ex As Exception
            Throw
        End Try

    End Function
    Private Function ListaHijos(ByVal lista As List(Of eMenuAplicacion), ByVal oe As eMenuAplicacion) As String
        Try
            Dim cad As String = ""
            For Each Fila As eMenuAplicacion In lista

                If Fila.codigoRaiz_Men = oe.codigo_Men Then
                    If Not TieneHijos(lista, Fila) Then
                        'cad = cad & "<li><a href='main.aspx?modulo=" & Fila.enlace_men.Replace(".aspx", "") & "'>" & Fila.descripcion_Men & "</a></li>"

                        If Fila.target = "" Then
                            cad = cad & "<li><a href='#' onclick=f_Menu('" & Fila.enlace_men & "')>" & Fila.descripcion_Men & "</a></li>"
                        Else
                            cad = cad & "<li><a href='" & Fila.link & "' target='" & Fila.target & "'>" & Fila.descripcion_Men & "</a></li>"
                        End If


                    Else
                        LlenarMenu(lista, Fila)

                    End If

                End If

            Next
            Return cad
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function ListaHijosInactivos(ByVal lista As List(Of eMenuAplicacion), ByVal oe As eMenuAplicacion) As String
        Try
            Dim cad As String = ""
            For Each Fila As eMenuAplicacion In lista

                If Fila.codigoRaiz_Men = oe.codigo_Men Then
                    If Not TieneHijos(lista, Fila) Then
                        'cad = cad & "<li><a href='main.aspx?modulo=" & Fila.enlace_men.Replace(".aspx", "") & "'>" & Fila.descripcion_Men & "</a></li>"
                        If Fila.accesoAlumnoInactivo Then
                            If Fila.target = "" Then
                                cad = cad & "<li><a href='#' onclick=f_Menu('" & Fila.enlace_men & "')>" & Fila.descripcion_Men & "</a></li>"
                            Else
                                cad = cad & "<li><a href='" & Fila.link & "' target='" & Fila.target & "'>" & Fila.descripcion_Men & "</a></li>"
                            End If
                        End If

                    Else
                        LlenarMenuInactivo(lista, Fila)

                    End If

                End If

            Next
            Return cad
        Catch ex As Exception
            Throw
        End Try
    End Function
    Private Function ListaPadreHijos(ByVal lista As List(Of eMenuAplicacion), ByVal oe As eMenuAplicacion) As String
        Try
            Dim cad As String = ""
            For Each Fila As eMenuAplicacion In lista

                If Fila.codigoRaiz_Men = oe.codigo_Men Then
                    If TienePadreHijos(lista, Fila) Then
                        'cad = cad & "<li><a href='main.aspx?modulo=" & Fila.enlace_men.Replace(".aspx", "") & "'>" & Fila.descripcion_Men & "</a></li>"
                        cad = cad & "<li><a href='#' onclick=f_Menu('" & Fila.enlace_men & "')>" & Fila.descripcion_Men & "</a></li>"
                    End If
                End If
            Next
            Return cad
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function NoTienePadre(ByVal oe As eMenuAplicacion) As Boolean
        Try
            If oe.codigoRaiz_Men = 0 Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function TieneHijos(ByVal lista As List(Of eMenuAplicacion), ByVal oe As eMenuAplicacion) As Boolean
        Try
            For Each Fila As eMenuAplicacion In lista

                If Fila.codigoRaiz_Men = oe.codigo_Men Then
                    Return True
                End If

            Next
            Return False
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function TienePadreHijos(ByVal lista As List(Of eMenuAplicacion), ByVal oe As eMenuAplicacion) As Boolean
        Try
            Dim p As Integer = 0
            Dim h As Integer = 0

            For Each Fila As eMenuAplicacion In lista

                If Fila.codigo_Men = oe.codigoRaiz_Men Then
                    p = 1
                End If
                If Fila.codigoRaiz_Men = oe.codigo_Men Then
                    h = 1
                End If
            Next
            If p = 1 And h = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

   

    Protected Sub LoginStatus1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.Load


    End Sub
End Class
