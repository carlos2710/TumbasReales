﻿Imports System.Web.Security
Imports System.Data
Imports cLogica
Imports System.Data.DataTable
Imports System.Collections.Generic
Imports System.Data.DataRow
Imports System.Data.DataColumn
Imports cEntidad
Imports System.IO
Imports System.Web.HttpRequest
Imports System.Globalization

Partial Class procesar
    Inherits System.Web.UI.Page

    'Public Shared Function DataToJSON(ByVal type As Integer, _
    '                                  ByVal ParamArray parameterValues() As Object) As Object
    '    Dim fn As New lFunciones
    '    'Dim list As New List(Of Dictionary(Of String, Object))()

    '    Try

    '        Select Case type
    '            Case 0  'Cambio de Clave
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                Dim objE As New eAlumno
    '                Dim objL As New lAlumno
    '                Dim blnResultado As String = ""
    '                Dim nro As String
    '                ' MsgBox("ok")
    '                If (parameterValues(2) = parameterValues(3)) Then
    '                    objE.codigo_Alu = fn.DecrytedString64(parameterValues(0).ToString)
    '                    objE.password_Alu = parameterValues(1)
    '                    objE.nuevaClave = parameterValues(2)
    '                    objE.confirmaClave = parameterValues(3)
    '                    nro = fn.DecrytedString64(parameterValues(4).ToString)
    '                    If fn.DecrytedString64(parameterValues(4).ToString) = "1" Then
    '                        blnResultado = objL.CambioDeClaveEgresado(objE)
    '                    Else
    '                        blnResultado = objL.CambioDeClave(objE)
    '                    End If
    '                    dict.Add("Resultado", blnResultado)
    '                    dict.Add("aviso", "OK")
    '                    list.Add(dict)
    '                Else
    '                    dict.Add("Resultado", "ERROR")
    '                    dict.Add("aviso", "Los campos no coinciden")
    '                    list.Add(dict)
    '                End If
    '                objE = Nothing
    '                objL = Nothing

    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                Return serializer.Serialize(list)
    '            Case 1  'Recuperar contraseña

    '                Dim dt As New Data.DataTable
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                Dim objE As New eAlumno
    '                Dim objL As New lAlumno
    '                Dim Email As String

    '                Try
    '                    objE.codigoUniver_Alu = parameterValues(0)
    '                    dt = objL.RecuperarClave(objE)

    '                    'Cecilia gastelo 13/03/2018 
    '                    If (dt.Rows.Count > 0) Then
    '                        Email = dt.Rows(0).Item("UserPrincipalName").ToString 'Cambió eMail_Alu por el Correo-USAT

    '                        If Email Is Nothing OrElse Email = "" Then
    '                            Email = dt.Rows(0).Item("eMail_Alu").ToString 'Cambió email2_Alu por correo Personal-1
    '                        End If

    '                        If Email Is Nothing Or Email = "" Then
    '                            dict.Add("email", "")
    '                            dict.Add("aviso", "No tiene correo registrado para enviar su contrase&ntilde;a")
    '                            dict.Add("respuesta", "ERROR")
    '                        Else
    '		'fin 13/03/2018 

    '                            Dim blnResultado As Boolean = False
    '                            Dim Asunto, mensaje, origen, destino As String
    '                            Dim ObjMail As New clsMailNet
    '                            Asunto = "Recuperar Contraseña Campus Virtual USAT"
    '                            mensaje = "<html><head><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' /><title>Mail Recuperar Contraseña</title><style type='text/css'>"
    '                            mensaje = mensaje + ".Estilo1 {font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 12px;}</style></head><body><table width='100%' border='0'>"
    '                            mensaje = mensaje + "<tr><td colspan='3' bgcolor='#006699'>&nbsp;</td></tr><tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td><span class='Estilo1'>Estimado Alumno <strong></strong></span></td>"
    '                            mensaje = mensaje + "<td>&nbsp;</td><td>&nbsp;</td></tr><tr><td><span class='Estilo1'>Ha solicitado el envio de su contraseña a su correo electrónico, la misma que es <b>" & dt.Rows(0).Item("password_alu").ToString
    '                            mensaje = mensaje + "</b><br>Si por alguna razón usted no solicitó el envío de esta información, le recomendamos ingrese al Campus Virtual USAT y cambie su contraseña para mayor seguridad."
    '                            mensaje = mensaje + "</span></td><td>&nbsp;</td><td>&nbsp;</td></tr></table></body></hmtl>"
    '                            origen = "serviciosti@usat.edu.pe"
    '                            'destino = Trim(Email)
    '                            destino = "freddy.seclen@usat.edu.pe"
    '                            blnResultado = ObjMail.EnviarMail("serviciosti@usat.edu.pe", "Servicios TI", destino, Asunto, mensaje, True, "Servicios TI", destino)
    '                            If (blnResultado = True) Then
    '                                dict.Add("email", Email)
    '                                dict.Add("aviso", "Correo enviado correctamente")
    '                                dict.Add("respuesta", "OK")
    '                            Else
    '                                dict.Add("email", "")
    '                                dict.Add("aviso", "Error al enviar correo con contrase&ntilde;a")
    '                                dict.Add("respuesta", "ERROR")
    '                            End If

    '                        End If
    '                    End If
    '                Catch ex As Exception
    '                    dict.Add("email", "")
    '                    dict.Add("aviso", ex.Message)
    '                    dict.Add("respuesta", "ERROR")
    '                Finally
    '                    list.Add(dict)
    '                End Try

    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                Return serializer.Serialize(list)


    '            Case 3  'Cambio de Grupo
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                Dim dtCruce As New Data.DataTable
    '                Dim dtOper As New Data.DataTable
    '                Dim codigo_cup_ant, codigo_dma, CodAlu As Integer
    '                Dim mensajes(1) As String
    '                Dim olCambio As New lCambioGrupo
    '                Dim oDetalle As New eDetalleMatricula
    '                Dim oCurso As New eCursoProgramado
    '                Try
    '                    CodAlu = parameterValues(0)
    '                    codigo_cup_ant = parameterValues(2)
    '                    codigo_dma = parameterValues(1)

    '                    oDetalle.codigo_dma = codigo_dma
    '                    oCurso.codigo_cup = parameterValues(3)
    '                    oCurso.codigo_cup_ant = codigo_cup_ant
    '                    dtCruce = olCambio.ValidaCruceCambioGrupo(oDetalle, oCurso)


    '                    If (dtCruce.Rows.Count > 0) Then 'Existe cruce
    '                        dict.Add("Aviso", "Existe cruce de horario")
    '                        dict.Add("Resultado", "ERROR")
    '                    Else
    '                        '                '### Graba el cambio de grupo, internamente está la bitacora ###
    '                        Dim oDetalleCG As New eDetalleMatricula
    '                        Dim oCursoCG As New eCursoProgramado

    '                        oDetalleCG.codigo_cup = parameterValues(3)
    '                        oDetalleCG.equipo_dma = parameterValues(4)
    '                        oDetalleCG.operador_dma = CodAlu
    '                        oDetalleCG.codigo_dma = codigo_dma
    '                        oCursoCG.codigo_cup_ant = codigo_cup_ant
    '                        oDetalleCG.codigo_mar = parameterValues(5)
    '                        oDetalleCG.codigoUniverAlu = parameterValues(6)

    '                        If parameterValues(7).ToString = "OTROS" Then
    '                            oDetalleCG.observacion_dma = parameterValues(8).ToString

    '                        End If

    '                        If CInt(parameterValues(5)) = 0 Or (parameterValues(7).ToString = "OTROS" And parameterValues(8).ToString = "") Then
    '                            dict.Add("Aviso", "Ingrese motivo de Cambio de Grupo")
    '                            dict.Add("Resultado", "ERROR")
    '                        Else

    '                            ' dtOper = olCambio.ValidaOperador(oDetalleCG, oCursoCG)

    '                            ' If CInt(dtOper.Rows(0).Item("existe")) > 0 Then
    '                            mensajes(0) = olCambio.CambiarDeGrupo(oDetalleCG, oCursoCG)
    '                            Select Case (Left(mensajes(0), 1))
    '                                Case "1", "3", "4" ' 1: ocurrio error, 3: no hay vacantes    
    '                                    dict.Add("Resultado", "C")
    '                                    dict.Add("Aviso", Mid(mensajes(0), 2, mensajes(0).Length))
    '                                Case "2" ' 2: registrado correctamente
    '                                    dict.Add("Resultado", "OK")
    '                                    dict.Add("Aviso", Mid(mensajes(0), 2, mensajes(0).Length))
    '                            End Select


    '                            'dict.Add("mensaje", mensajes(0))
    '                            'dict.Add("mensaje2", Left(mensajes(0), 1))
    '                            'dict.Add("mensaje3", Mid(mensajes(0), 2, mensajes(0).Length))

    '                            '    dict.Add("Resultado", "OK")
    '                            '    Else
    '                            '    dict.Add("Aviso", "No puedes cambiarte de grupo en este curso, ha sido matriculado por Asesor/Cordinador")
    '                            '    dict.Add("Resultado", "ERROR")
    '                            'End If





    '                        End If






    '                    End If
    '                Catch ex As Exception
    '                    dict.Add("Resultado", "ERROR")
    '                    dict.Add("Aviso", ex.Message)
    '                Finally
    '                    list.Add(dict)
    '                End Try

    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                Return serializer.Serialize(list)
    '            Case Else
    '                Return Nothing
    '        End Select

    '        Return Nothing
    '    Catch ex As Exception
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        Dim dict As New Dictionary(Of String, Object)()
    '        dict.Add("respuesta", ex.Message)
    '        list.Add(dict)
    '        Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '        Return serializer.Serialize(list)
    '    End Try



    'End Function

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Dim JSONresult As String

    '    If Not Me.Page.User.Identity.IsAuthenticated Then
    '        If Request("param0") = "rcE" Then       'Recuperar contraseña
    '            JSONresult = DataToJSON(Request("param1"), Request("param2"))
    '        ElseIf Request("param0") = "rcEg" Then
    '            Try

    '                Dim dt As New Data.DataTable
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                Dim objE As New eAlumno
    '                Dim objL As New lAlumno
    '                Dim Email As String = ""
    '                Dim nemail As Integer = 0

    '                objE.nroDocIdent_Alu = Request("param2")
    '                dt = objL.RecuperarClave_egresado(objE)
    '                'Response.Write(dt.Rows.Count)


    '                If Not dt Is Nothing AndAlso (dt.Rows.Count > 0) Then
    '                    If dt.Rows(0).Item("emailAlternativo_Pso").ToString <> "" Then
    '                        Email = dt.Rows(0).Item("emailPrincipal_Pso").ToString & ";" & dt.Rows(0).Item("emailAlternativo_Pso").ToString
    '                        nemail = 2
    '                    Else
    '                        Email = dt.Rows(0).Item("emailPrincipal_Pso").ToString
    '                        nemail = 1
    '                    End If

    '                    'Email = dt.Rows(0).Item("emailPrincipal_Pso").ToString & ";" & dt.Rows(0).Item("emailAlternativo_Pso").ToString

    '                    'If Email Is Nothing OrElse Email = "" Then
    '                    '    Email = dt.Rows(0).Item("emailAlternativo_Pso").ToString
    '                    'End If



    '                    If Email Is Nothing Or Email = "" Then
    '                        dict.Add("email", "")
    '                        dict.Add("aviso", "No tiene correo registrado para enviar su contrase&ntilde;a")
    '                        dict.Add("respuesta", "ERROR")
    '                    Else

    '                        Dim saludo As String = ""
    '                        Dim blnResultado As Boolean = False
    '                        Dim Asunto, mensaje, origen, destino As String
    '                        Dim ObjMail As New clsMailNet


    '                        If dt.Rows(0).Item("sexo").ToString = "M" Then
    '                            saludo = "estimado Sr"
    '                        Else
    '                            saludo = "estimada Srta"
    '                        End If

    '                        mensaje = ""
    '                        Asunto = "Recuperar Contraseña AlumniUSAT"
    '                        'Asunto = "Confirmación de Referencia Laboral"
    '                        mensaje = mensaje + "<html><head><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />"
    '                        mensaje = mensaje + "<title>Confirmac&íacute;on de Referencia Laboral</title>"
    '                        mensaje = mensaje + "<style type='text/css'>.usat { font-family:Calibri;color:#F1132A;font-size:25px;font-weight: bold;} "
    '                        mensaje = mensaje + ".bolsa{color:#F1132A;font-family:Calibri;font-size: 13px;font-weight: 500;}</style></head>"
    '                        mensaje = mensaje + "<body>"
    '                        mensaje = mensaje + "<div style='text-align:center;width:100%'>"
    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td style='text-align:center;'>"
    '                        mensaje = mensaje + "<div style='width:70%;margin:0 auto;text-align:center;'><img src='http://intranet.usat.edu.pe/campusestudiante/assets/images/logousat.png' width='100' height='100' ></div>"
    '                        mensaje = mensaje + "<div style='width:70%;margin:0 auto;text-align:center;'><div class='usat'>ALUMNI USAT</div> <div class='bolsa'></div> </div></td></tr></table>"

    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr>"
    '                        mensaje = mensaje + "<td style = 'background:none;border-bottom:1px solid #F1132A;height:1px;width:50%;margin:0px 0px 0px 0px' > &nbsp;</td></tr></table><br />"
    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td>"

    '                        mensaje = mensaje + "<div style='margin-top:10px;text-align:center;color:gray;font-family:Calibri '>Hola " + " " + dt.Rows(0).Item("egresado").ToString + ".<br>Tu contraseña para poder acceder al Campus Alumni USAT <br/>es: <b>" + dt.Rows(0).Item("password_Alu").ToString + "</b><br/><br/>Si por alguna razón no solicitaste el envío de esta<br />información, te recomendamos cambiar tu contraseña para<br/>mayor seguridad.</div>"
    '                        mensaje = mensaje + "</td></tr></table>"
    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'>"
    '                        mensaje = mensaje + "<tr><td style='background:none;border-bottom:1px solid #F1132A;height:1px;width:50%;margin:0px 0px 0px 0px' > &nbsp;</td></tr></table><br />"
    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td>"
    '                        mensaje = mensaje + "<div style='margin:0 auto;text-align:center;color:gray;font-family:Calibri'>¡Muchas gracias por confiar en nosotros!</div>"
    '                        mensaje = mensaje + "<div style='margin:0 auto;text-align:center;color:gray;font-family:Calibri'><b>El equipo de ALUMNI USAT</b></div><br /></td></tr></table>"
    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td style='text-align:center;'>"
    '                        mensaje = mensaje + "<div style='font-size:11px;color:gray;font-family:Calibri'><div>Av. San Josemaría Escrivá de Balaguer Nº 855 Chiclayo - Perú<br/>"
    '                        mensaje = mensaje + "<a href='alumni@usat.edu.pe' style='color:gray;text-decoration:none;font-family:Calibri' target='_blank'> <b>alumni@usat.edu.pe</b></a></div> "
    '                        mensaje = mensaje + "<div style='font-family:Calibri' >© Copyright 2017: USAT - Todos los derechos reservados</div>"
    '                        mensaje = mensaje + "</td></tr></table></div></body></html>"
    '                        origen = "alumni@usat.edu.pe"
    '                        'destino = Trim(Email)
    '                        destino = "freddy.seclen@usat.edu.pe"
    '                        blnResultado = ObjMail.fnEnviarMailVarios("alumni@usat.edu.pe", "Alumni USAT", destino, Asunto, mensaje, True, "AlumniUSAT", "alumni@usat.edu.pe")
    '                        If (blnResultado = True) Then
    '                            dict.Add("email", emailpass(dt.Rows(0).Item("emailPrincipal_Pso").ToString))
    '                            dict.Add("email2", emailpass(dt.Rows(0).Item("emailAlternativo_Pso").ToString))
    '                            dict.Add("aviso", "Correo enviado correctamente")
    '                            dict.Add("respuesta", "OK")
    '                        Else
    '                            dict.Add("email", "")
    '                            dict.Add("aviso", "Error al enviar correo con contrase&ntilde;a")
    '                            dict.Add("respuesta", "ERROR")
    '                        End If
    '                        dict.Add("numEmail", nemail)
    '                    End If

    '                Else

    '                    dict.Add("email", "")
    '                    dict.Add("aviso", "No existe Nro Documento de Identidad en el sistema")
    '                    dict.Add("respuesta", "ERROR")
    '                    dict.Add("numEmail", nemail)
    '                End If

    '                'list.Add(dict)


    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                JSONresult = serializer.Serialize(dict)
    '                Response.Write(JSONresult)
    '            Catch ex As Exception
    '                Response.Write(ex.Message)
    '            End Try

    '        Else
    '            Response.Write(Nothing)

    '        End If
    '    Else
    '        '***************** Cambio de Clave *****************


    '        If Request("param0") = "rcEg" Then
    '            Try

    '                Dim dt As New Data.DataTable
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                Dim objE As New eAlumno
    '                Dim objL As New lAlumno
    '                Dim Email As String = ""


    '                objE.nroDocIdent_Alu = Request("param2")
    '                dt = objL.RecuperarClave_egresado(objE)
    '                'Response.Write(dt.Rows.Count)


    '                If Not dt Is Nothing AndAlso (dt.Rows.Count > 0) Then
    '                    Email = dt.Rows(0).Item("emailPrincipal_Pso").ToString & ";" & dt.Rows(0).Item("emailAlternativo_Pso").ToString




    '                    If Email Is Nothing Or Email = "" Then
    '                        dict.Add("email", "")
    '                        dict.Add("aviso", "No tiene correo registrado para enviar su contrase&ntilde;a")
    '                        dict.Add("respuesta", "ERROR")
    '                    Else

    '                        Dim saludo As String = ""
    '                        Dim blnResultado As Boolean = False
    '                        Dim Asunto, mensaje, origen, destino As String
    '                        Dim ObjMail As New clsMailNet


    '                        If dt.Rows(0).Item("sexo").ToString = "M" Then
    '                            saludo = "estimado Sr"
    '                        Else
    '                            saludo = "estimada Srta"
    '                        End If

    '                        mensaje = ""
    '                        Asunto = "Recuperar Contraseña AlumniUSAT"
    '                        'Asunto = "Confirmación de Referencia Laboral"
    '                        mensaje = mensaje + "<html><head><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />"
    '                        mensaje = mensaje + "<title>Recuperar Contraseña AlumniUSAT</title>"
    '                        mensaje = mensaje + "<style type='text/css'>.usat { font-family:Calibri;color:#F1132A;font-size:25px;font-weight: bold;} "
    '                        mensaje = mensaje + ".bolsa{color:#F1132A;font-family:Calibri;font-size: 13px;font-weight: 500;}</style></head>"
    '                        mensaje = mensaje + "<body>"
    '                        mensaje = mensaje + "<div style='text-align:center;width:100%'>"
    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td style='text-align:center;'>"
    '                        mensaje = mensaje + "<div style='width:70%;margin:0 auto;text-align:center;'><img src='http://intranet.usat.edu.pe/campusestudiante/assets/images/logousat.png' width='100' height='100' ></div>"
    '                        mensaje = mensaje + "<div style='width:70%;margin:0 auto;text-align:center;'><div class='usat'>ALUMNI USAT</div> <div class='bolsa'></div> </div></td></tr></table>"

    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr>"
    '                        mensaje = mensaje + "<td style = 'background:none;border-bottom:1px solid #F1132A;height:1px;width:50%;margin:0px 0px 0px 0px' > &nbsp;</td></tr></table><br />"
    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td>"

    '                        mensaje = mensaje + "<div style='margin-top:10px;text-align:center;color:gray;font-family:Calibri '>Hola " + " " + dt.Rows(0).Item("egresado").ToString + ".<br>Tu contraseña para poder acceder al Campus Alumni USAT <br/>es: <b>" + dt.Rows(0).Item("password_Alu").ToString + "</b><br/><br/>Si por alguna razón no solicitaste el envío de esta<br />información, te recomendamos cambiar tu contraseña para<br/>mayor seguridad.</div>"
    '                        mensaje = mensaje + "</td></tr></table>"
    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'>"
    '                        mensaje = mensaje + "<tr><td style='background:none;border-bottom:1px solid #F1132A;height:1px;width:50%;margin:0px 0px 0px 0px' > &nbsp;</td></tr></table><br />"
    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td>"
    '                        mensaje = mensaje + "<div style='margin:0 auto;text-align:center;color:gray;font-family:Calibri'>¡Muchas gracias por confiar en nosotros!</div>"
    '                        mensaje = mensaje + "<div style='margin:0 auto;text-align:center;color:gray;font-family:Calibri'><b>El equipo de ALUMNI USAT</b></div><br /></td></tr></table>"
    '                        mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td style='text-align:center;'>"
    '                        mensaje = mensaje + "<div style='font-size:11px;color:gray;font-family:Calibri'><div>Av. San Josemaría Escrivá de Balaguer Nº 855 Chiclayo - Perú<br/>"
    '                        mensaje = mensaje + "<a href='alumni@usat.edu.pe' style='color:gray;text-decoration:none;font-family:Calibri' target='_blank'> <b>alumni@usat.edu.pe</b></a></div> "
    '                        mensaje = mensaje + "<div style='font-family:Calibri' >© Copyright 2017: USAT - Todos los derechos reservados</div>"
    '                        mensaje = mensaje + "</td></tr></table></div></body></html>"
    '                        origen = "alumni@usat.edu.pe"
    '                        destino = Trim(Email)
    '                        blnResultado = ObjMail.fnEnviarMailVarios("alumni@usat.edu.pe", "Alumni USAT", destino, Asunto, mensaje, True, "AlumniUSAT", "alumni@usat.edu.pe")
    '                        If (blnResultado = True) Then
    '                            dict.Add("email", emailpass(dt.Rows(0).Item("emailPrincipal_Pso").ToString))
    '                            dict.Add("email2", emailpass(dt.Rows(0).Item("emailAlternativo_Pso").ToString))
    '                            dict.Add("aviso", "Correo enviado correctamente")
    '                            dict.Add("respuesta", "OK")
    '                        Else
    '                            dict.Add("email", "")
    '                            dict.Add("aviso", "Error al enviar correo con contrase&ntilde;a")
    '                            dict.Add("respuesta", "ERROR")
    '                        End If

    '                    End If

    '                Else

    '                    dict.Add("email", "")
    '                    dict.Add("aviso", "No existe Nro Documento de Identidad en el sistema")
    '                    dict.Add("respuesta", "ERROR")
    '                End If

    '                'list.Add(dict)


    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                JSONresult = serializer.Serialize(dict)
    '                ' Response.Write(JSONresult)
    '            Catch ex As Exception
    '                Response.Write(ex.Message)
    '            End Try

    '        ElseIf Request("param0") = "regMat" Then
    '            Session.Add("MatMensaje", "")
    '            Dim olMat As New lMatricula
    '            Dim oeMat As New eMatricula
    '            Dim f As New lFunciones
    '            Dim values As ArrayList = f.ParamsValues(Request.Params, "param1")
    '            Dim resultado As String = ""
    '            Dim resultadoaArr() As String
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim dict As New Dictionary(Of String, Object)()
    '            Dim cup As String = ""
    '            Dim cur As String = ""
    '            Dim vcs As String = ""
    '            Dim strcm As String = ""

    '            Dim codmat As Integer = 0

    '            Dim dt As New DataTable




    '            With oeMat
    '                .tipooperacion = "E"
    '                .codigo_Alu = Session("codigo_Alu")
    '                .codigo_Pes = Session("codigo_Pes")
    '                .codigo_Cac = Session("Codigo_Cac")
    '                .estadoMat = "N"
    '                .observacion_Mat = "Matrícula Web"



    '                For index As Integer = 0 To values.Count - 1

    '                    If values(index).ToString().Contains("cup") Then

    '                        cup = cup & Request(values(index).ToString()) & ","

    '                    End If

    '                    If values(index).ToString().Contains("ccur") Then

    '                        cur = cur & Request(values(index).ToString()) & ","

    '                    End If

    '                    If values(index).ToString().Contains("vcs") Then

    '                        vcs = vcs & Request(values(index).ToString()) & ","

    '                    End If

    '                    If values(index).ToString().Contains("rem") Then

    '                        codmat = CInt(Request(values(index).ToString()))

    '                    End If


    '                    If values(index).ToString().Contains("cm") Then

    '                        strcm = strcm & Request(values(index).ToString()) & ","

    '                    End If


    '                Next


    '                Dim cupUlt As String = ""
    '                Dim vcsUlt As String = ""



    '                If CInt(Session("codigo_mat")) > 0 AndAlso ((Request("T").ToString = "OTROS" And Request("O").ToString.Trim = "") Or CInt(Request("M")) = 0) Then

    '                    dict.Add("R", "NO")
    '                    dict.Add("UP", False)
    '                    dict.Add("Mensaje", "Falta ingresar Motivo de Agregado")

    '                Else
    '                    Dim cursosValidos As String = ""
    '                    'validar cursos si existen en sesion: problema de sesiones en mismo navegador con 2 sesiones abiertas
    '                    cursosValidos = ExistenCursos(cur)

    '                    If Not cursosValidos.ToString().Contains("0,") Then

    '                        ActivarCursos(cur)
    '                        If ValidaMatricula(cur) Then

    '                            cupUlt = seleccionarcup(cup, strcm)
    '                            vcsUlt = seleccionarveces(vcs, strcm)

    '                            '.arrCP = cup
    '                            .arrCP = cupUlt
    '                            ' .arrVD = vcs
    '                            .arrVD = vcsUlt

    '                            If codmat = 0 Then
    '                                .tipomatricula_Dma = "N"
    '                            Else
    '                                .tipomatricula_Dma = "A"
    '                            End If

    '                            .estado_Dma = "P"
    '                            .tipoactualizacion = "MAT"
    '                            .usuario_Bit = Session("codigoUniver_Alu")
    '                            .esquipo_Bit = Session("ip")
    '                            .observacion_mar = ""

    '                            If CInt(Request("M")) > 0 Then
    '                                .codigo_mar = Request("M")
    '                                .observacion_mar = Request("O").ToString.Trim '  "Vía Campus estudiante"
    '                            End If

    '                            If Session("tipo_Cac").ToString = "E" Then
    '                                .nroPartes_Deu = 2
    '                            Else
    '                                .nroPartes_Deu = 5
    '                            End If
    '                            .tipoCondicion = Session("condicionciclo_anterior")
    '                            .motivocondicion = ""
    '                            .mensaje = ""

    '                            dt = olMat.validarCruceHorario(oeMat)

    '                            If dt Is Nothing Then
    '                                resultado = olMat.guardarMatricula(oeMat)
    '                                resultadoaArr = Split(resultado, "|")
    '                                If resultadoaArr.Length = 1 Then
    '                                    dict.Add("Mensaje", resultadoaArr(0).ToString.Trim)
    '                                Else
    '                                    If resultadoaArr(1).ToString.Substring(0, 9) = "Se regist" Then
    '                                        dict.Add("R", "OK")
    '                                        If Session("carta") = "S" Then
    '                                            dict.Add("URLCARTA", "ImprimirCarta.aspx")
    '                                        Else
    '                                            dict.Add("URLCARTA", "")
    '                                        End If



    '                                    Else
    '                                        dict.Add("R", "CANCEL")

    '                                        dict.Add("URLCARTA", "")
    '                                    End If
    '                                    dict.Add("UP", False)
    '                                    dict.Add("Mensaje", resultadoaArr(1).ToString.Trim)
    '                                End If

    '                            Else
    '                                dict.Add("R", "C")
    '                            End If


    '                        Else
    '                            '  MsgBox("no pasa")
    '                            DesactivarCursos(cur)
    '                            dict.Add("R", "CANCEL")
    '                            dict.Add("UP", False)
    '                            dict.Add("Mensaje", Session("MatMensaje").ToString)

    '                        End If

    '                    Else
    '                        dict.Add("R", "CANCEL")
    '                        dict.Add("UP", True)
    '                        dict.Add("Mensaje", "No existen cursos, vuelve actualizar la lista de cursos para matricularte")
    '                    End If

    '                End If

    '                dt = Nothing
    '                olMat = Nothing
    '                oeMat = Nothing
    '                list.Add(dict)
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'Response.write(serializer.Serialize(list))
    '                ' MsgBox(serializer.Serialize(list))
    '                JSONresult = serializer.Serialize(list)
    '            End With
    '        ElseIf Request("param0") = "regMatgo" Then
    '            Session.Add("MatMensaje", "")
    '            Dim olMat As New lMatricula
    '            Dim oeMat As New eMatricula
    '            Dim f As New lFunciones
    '            Dim values As ArrayList = f.ParamsValues(Request.Params, "param1")
    '            Dim resultado As String = ""
    '            Dim resultadoaArr() As String
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim dict As New Dictionary(Of String, Object)()
    '            Dim cup As String = ""
    '            Dim cur As String = ""
    '            Dim vcs As String = ""
    '            Dim strcm As String = ""

    '            Dim codmat As Integer = 0

    '            Dim dt As New DataTable




    '            With oeMat
    '                .tipooperacion = "E"
    '                .codigo_Alu = Session("codigo_Alu")
    '                .codigo_Pes = Session("codigo_Pes")
    '                .codigo_Cac = Session("Codigo_Cac")
    '                .estadoMat = "N"
    '                .observacion_Mat = "Matrícula Web"



    '                For index As Integer = 0 To values.Count - 1

    '                    If values(index).ToString().Contains("cup") Then

    '                        cup = cup & Request(values(index).ToString()) & ","

    '                    End If

    '                    If values(index).ToString().Contains("ccur") Then

    '                        cur = cur & Request(values(index).ToString()) & ","

    '                    End If

    '                    If values(index).ToString().Contains("vcs") Then

    '                        vcs = vcs & Request(values(index).ToString()) & ","

    '                    End If

    '                    If values(index).ToString().Contains("rem") Then

    '                        codmat = CInt(Request(values(index).ToString()))

    '                    End If


    '                    If values(index).ToString().Contains("cm") Then

    '                        strcm = strcm & Request(values(index).ToString()) & ","

    '                    End If


    '                Next


    '                Dim cupUlt As String = ""
    '                Dim vcsUlt As String = ""



    '                If CInt(Session("codigo_mat")) > 0 AndAlso ((Request("T").ToString = "OTROS" And Request("O").ToString.Trim = "") Or CInt(Request("M")) = 0) Then

    '                    dict.Add("R", "NO")
    '                    dict.Add("UP", False)
    '                    dict.Add("Mensaje", "Falta ingresar Motivo de Agregado")

    '                Else
    '                    Dim cursosValidos As String = ""
    '                    'validar cursos si existen en sesion: problema de sesiones en mismo navegador con 2 sesiones abiertas
    '                    cursosValidos = ExistenCursos(cur)

    '                    If Not cursosValidos.ToString().Contains("0,") Then

    '                        ActivarCursos(cur)
    '                        If ValidaMatricula(cur) Then

    '                            cupUlt = seleccionarcup(cup, strcm)
    '                            vcsUlt = seleccionarveces(vcs, strcm)

    '                            '.arrCP = cup
    '                            .arrCP = cupUlt
    '                            ' .arrVD = vcs
    '                            .arrVD = vcsUlt

    '                            If codmat = 0 Then
    '                                .tipomatricula_Dma = "N"
    '                            Else
    '                                .tipomatricula_Dma = "A"
    '                            End If

    '                            .estado_Dma = "P"
    '                            .tipoactualizacion = "MAT"
    '                            .usuario_Bit = Session("codigoUniver_Alu")
    '                            .esquipo_Bit = Session("ip")
    '                            .observacion_mar = ""

    '                            If CInt(Request("M")) > 0 Then
    '                                .codigo_mar = Request("M")
    '                                .observacion_mar = Request("O").ToString.Trim '  "Vía Campus estudiante"
    '                            End If

    '                            If Session("tipo_Cac").ToString = "E" Then
    '                                .nroPartes_Deu = 2
    '                            Else
    '                                .nroPartes_Deu = 5
    '                            End If
    '                            .tipoCondicion = Session("condicionciclo_anterior")
    '                            .motivocondicion = ""
    '                            .mensaje = ""

    '                            ' dt = olMat.validarCruceHorario(oeMat)

    '                            'If dt Is Nothing Then
    '                            If Session("CruceSessionGO") Then
    '                                resultado = olMat.guardarMatricula(oeMat)
    '                                resultadoaArr = Split(resultado, "|")
    '                                If resultadoaArr.Length = 1 Then
    '                                    dict.Add("Mensaje", resultadoaArr(0).ToString.Trim)
    '                                Else
    '                                    If resultadoaArr(1).ToString.Substring(0, 9) = "Se regist" Then
    '                                        dict.Add("R", "OK")
    '                                    Else
    '                                        dict.Add("R", "CANCEL")
    '                                    End If
    '                                    dict.Add("UP", False)
    '                                    dict.Add("Mensaje", resultadoaArr(1).ToString.Trim)

    '                                End If

    '                            Else
    '                                dict.Add("R", "C")
    '                                dict.Add("CruceSessionGO", Session("CruceSessionGO"))
    '                            End If


    '                        Else
    '                            '  MsgBox("no pasa")
    '                            DesactivarCursos(cur)
    '                            dict.Add("R", "CANCEL")
    '                            dict.Add("UP", False)
    '                            dict.Add("Mensaje", Session("MatMensaje").ToString)

    '                        End If

    '                    Else
    '                        dict.Add("R", "CANCEL")
    '                        dict.Add("UP", True)
    '                        dict.Add("Mensaje", "No existen cursos, vuelve actualizar la lista de cursos para matricularte")
    '                    End If

    '                End If

    '                dt = Nothing
    '                olMat = Nothing
    '                oeMat = Nothing
    '                list.Add(dict)
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'Response.write(serializer.Serialize(list))
    '                ' MsgBox(serializer.Serialize(list))
    '                JSONresult = serializer.Serialize(list)
    '            End With

    '        ElseIf Request("param0") = "fSr" Then
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim dict As New Dictionary(Of String, Object)()


    '            'Dim dia As String = "LU"  'entrada
    '            Dim numeroDia As Integer = 1 ' entrada
    '            Dim fechaActual As Date = Session("fechaServidor")
    '            Dim nombreDia As String = Request("param2")
    '            Dim numeroDiaActual As Integer = Weekday(fechaActual)
    '            Dim fechaCalendario As Date
    '            Dim fechaCalendario2 As String
    '            Dim dias As Double
    '            numeroDiaActual = numeroDiaActual - 1

    '            If numeroDiaActual = 0 Then numeroDiaActual = 7

    '            Select Case nombreDia
    '                Case "LU"
    '                    numeroDia = 1
    '                Case "MA"
    '                    numeroDia = 2
    '                Case "MI"
    '                    numeroDia = 3
    '                Case "JU"
    '                    numeroDia = 4
    '                Case "VI"
    '                    numeroDia = 5
    '                Case "SA"
    '                    numeroDia = 6
    '                Case Else
    '                    numeroDia = 7
    '            End Select

    '            If numeroDia = numeroDiaActual Then
    '                fechaCalendario = fechaActual

    '            ElseIf numeroDia < numeroDiaActual Then

    '                dias = (numeroDiaActual - numeroDia) * -1
    '                fechaCalendario = fechaActual.AddDays(dias)
    '            Else
    '                dias = numeroDia - numeroDiaActual
    '                fechaCalendario = fechaActual.AddDays(dias)

    '            End If

    '            fechaCalendario2 = fechaCalendario.Year.ToString & "-" & fechaCalendario.Month.ToString("00") & "-" & fechaCalendario.Day.ToString("00")


    '            ' dict.Add("date", fechaActual)
    '            '  dict.Add("numeroDiaActual", numeroDiaActual)
    '            dict.Add("fec", fechaCalendario2)
    '            list.Add(dict)
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            JSONresult = serializer.Serialize(list)

    '        ElseIf Request("param0") = "chses" Then
    '            Dim i As Integer = 0
    '            Dim j As Integer = 0
    '            Dim oeMat As New eMatricula
    '            Dim olMat As New lMatricula
    '            Dim dt As New DataTable
    '            oeMat.codigo_Alu = Session("codigo_Alu")
    '            oeMat.codigo_Cac = Session("codigo_Cac")
    '            oeMat.codigo_Pes = Session("codigo_Pes")
    '            oeMat.codigo_cup = Request("param2")
    '            oeMat.arrCP = Request("param3")
    '            dt = olMat.cruceHorarioSession(oeMat)

    '            'Dim dict As New Dictionary(Of String, Object)()
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

    '            'list = dtCursos
    '            Dim sum As Integer = 0
    '            Session("CruceSessionGO") = True  ' pasa a matricular


    '            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then


    '                'For j = 0 To dt.Rows.Count - 1
    '                '    sum = sum + dt.Rows(i).Item("cant")
    '                'Next


    '                Session("CruceSessionGO") = False   ' no pasa a matricular
    '                For i = 0 To dt.Rows.Count - 1
    '                    Dim dict As New Dictionary(Of String, Object)()
    '                    dict.Add("cursoA", dt.Rows(i).Item("cursoA").ToString())
    '                    dict.Add("grupoA", dt.Rows(i).Item("grupoA").ToString())
    '                    dict.Add("sesionA", dt.Rows(i).Item("sesionA").ToString())
    '                    dict.Add("horasA", dt.Rows(i).Item("HorasA").ToString())
    '                    dict.Add("cursoB", dt.Rows(i).Item("cursoB").ToString())
    '                    dict.Add("grupoB", dt.Rows(i).Item("grupoB").ToString())
    '                    dict.Add("sesionB", dt.Rows(i).Item("sesionB").ToString())
    '                    dict.Add("horasB", dt.Rows(i).Item("HorasB").ToString())
    '                    list.Add(dict)
    '                Next


    '            End If


    '            JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "cgE" Then
    '            JSONresult = DataToJSON(Request("param1"), Session("codigo_Alu"), Request("param2"), Request("param3"), Request("param4"), Request.ServerVariables("REMOTE_ADDR"), Request("param6"), Session("codigoUniver_Alu"), Request("param7"), Request("param8"))
    '        ElseIf Request("param0") = "rcE" Then
    '            JSONresult = DataToJSON(Request("param1"), Request("param2"))
    '        ElseIf Request("param0") = "fUpReqCur" Then
    '            Dim olMat As New lMatricula
    '            Dim oeMat As New eMatricula

    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim dict As New Dictionary(Of String, Object)()


    '            Dim dt As New DataTable




    '            With oeMat
    '                .codigo_Alu = Session("codigo_Alu")
    '                .codigo_Pes = Session("codigo_Pes")
    '                .codigo_Cac = Session("Codigo_Cac")
    '                dt = olMat.actualizarRequisitosCurso(oeMat)


    '                If dt Is Nothing Then

    '                    dict.Add("resultado", "OK")
    '                    dict.Add("msj", "Se ha actualizado la lista de cursos")
    '                Else
    '                    dict.Add("resultado", "ERROR")
    '                    dict.Add("msj", "Se ha actualizado la lista de cursos")
    '                End If

    '            End With
    '            dt = Nothing
    '            olMat = Nothing
    '            oeMat = Nothing
    '            list.Add(dict)
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            'Response.write(serializer.Serialize(list))
    '            ' MsgBox(serializer.Serialize(list))
    '            JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "lsCM" Then
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            list = Session("lstCursosDisponiblesJson")
    '            JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "lsCNFM" Then
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            list = Session("lstConfMatJson")
    '            JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "lsCMINV" Then  ' lista de cursos invitados PROFESIONALIZACION
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            list = Session("lstCMINV")
    '            Session.Remove("lstCMINV")
    '            JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "lstCRECU" Then  ' lista de cursos invitados PROFESIONALIZACION
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            list = Session("lstCRECU")
    '            'Session.Remove("lstCRECU")
    '            JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "lstCEXAM" Then  ' lista de cursos invitados PROFESIONALIZACION
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            list = Session("lstCEXAM")
    '            Session.Remove("lstCEXAM")
    '            JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "lstEXANOD" Then  ' lista de cursos invitados PROFESIONALIZACION
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            list = Session("lstEXANOD")
    '            Session.Remove("lstEXANOD")
    '            JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "retMat" Then

    '            Dim ol As New lMatricula
    '            Dim oe As New eMatricula
    '            Dim dt1 As New DataTable
    '            Dim dt2 As New DataTable

    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim dict As New Dictionary(Of String, Object)()
    '            Session.Add("RetMensaje", "")

    '            If Session("tipo_Cac").ToString = "N" Then
    '                If Session("cicloIng_Alu").ToString.Trim <> (Year(Date.Now).ToString() & "-II") Then

    '                    If (Request("t") = "OTROS" And Request("m").ToString.Trim = "") Or CInt(Request("r")) = 0 Then

    '                        dict.Add("R", "NO")
    '                        dict.Add("Mensaje", "Falta ingresar Motivo de Retiro")

    '                    Else
    '                        If ValidaRetiro(Request("param1")) Then
    '                            oe.codigo_dma = CInt(Request("param1"))
    '                            oe.codigo_Alu = Session("codigo_Alu")
    '                            oe.codigo_Cac = Session("codigo_cac")
    '                            dt1 = ol.VerificaFechaAgregadoRetiro(oe)
    '                            If Not dt1 Is Nothing Then
    '                                If dt1.Rows(0).Item("mensaje").ToString = "OK" Then
    '                                    oe.tipooperacion = "E"
    '                                    oe.codigo_dma = CInt(Request("param1"))
    '                                    oe.codigoUniver = Session("codigoUniver_Alu")
    '                                    oe.codigo_mar = CInt(Request("r")) '27
    '                                    oe.observacion_Mat = Request("m").ToString ' "Vía Campus estudiante"
    '                                    'oe.observacion_mar = Request("m").ToString
    '                                    dt2 = ol.RetirarCursoMatricula(oe)



    '                                    If Not dt2 Is Nothing Then
    '                                        If dt2.Rows(0).Item("mensaje").ToString().Contains("Se ha registrado correctamente") Then
    '                                            dict.Add("R", "OK")
    '                                            dict.Add("Mensaje", "Se ha registrado correctamente")
    '                                        Else
    '                                            dict.Add("R", "NO")
    '                                            If dt2.Rows(0).Item("mensaje").ToString().Contains("history.back(-1)|") Then

    '                                                Dim TestArray() As String
    '                                                TestArray = Split(dt2.Rows(0).Item("mensaje").ToString(), "|")


    '                                                dict.Add("Mensaje", TestArray(1))
    '                                            ElseIf dt2.Rows(0).Item("mensaje").ToString().Contains("RET_ERROR|") Then

    '                                                Dim TestArray() As String
    '                                                TestArray = Split(dt2.Rows(0).Item("mensaje").ToString(), "|")


    '                                                dict.Add("Mensaje", TestArray(1))
    '                                            Else
    '                                                dict.Add("Mensaje", "Se ha producido un error en el retiro del curso")
    '                                            End If

    '                                        End If
    '                                    End If
    '                                Else

    '                                    dict.Add("R", "NO")
    '                                    dict.Add("Mensaje", dt1.Rows(0).Item("mensaje").ToString)

    '                                End If



    '                            End If

    '                        Else

    '                            dict.Add("R", "NO")
    '                            dict.Add("Mensaje", Session("RetMensaje").ToString)

    '                        End If
    '                    End If
    '                Else
    '                    dict.Add("R", "NO")
    '                    dict.Add("Mensaje", "Lo sentimos, el proceso de retiros no se encuentra habilitado para estudiantes ingresantes " & Session("cicloIng_Alu").ToString.Trim)

    '                    dt1 = Nothing
    '                    dt2 = Nothing
    '                    ol = Nothing
    '                    oe = Nothing
    '                End If

    '            End If




    '            list.Add(dict)

    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            'Response.write(serializer.Serialize(list))
    '            ' MsgBox(serializer.Serialize(list))
    '            JSONresult = serializer.Serialize(list)

    '        ElseIf Request("param0") = "retMatGO" Then

    '            Dim ol As New lMatricula
    '            Dim oe As New eMatricula
    '            Dim dt1 As New DataTable
    '            Dim dt2 As New DataTable

    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim dict As New Dictionary(Of String, Object)()
    '            Session.Add("RetMensaje", "")

    '            If Session("tipo_Cac").ToString = "N" Then
    '                If Session("cicloIng_Alu").ToString.Trim <> Session("descripcion_Cac").ToString.Trim Then

    '                    If (Request("t") = "OTROS" And Request("m").ToString.Trim = "") Or CInt(Request("r")) = 0 Then

    '                        dict.Add("R", "NO")
    '                        dict.Add("Mensaje", "Falta ingresar Motivo de Retiro")

    '                    Else
    '                        If ValidaRetiro(Request("param1")) Then
    '                            oe.codigo_dma = CInt(Request("param1"))
    '                            oe.codigo_Alu = Session("codigo_Alu")
    '                            oe.codigo_Cac = Session("codigo_cac")
    '                            dt1 = ol.VerificaFechaAgregadoRetiro(oe)
    '                            If Not dt1 Is Nothing Then
    '                                If dt1.Rows(0).Item("mensaje").ToString = "OK" Then
    '                                    oe.tipooperacion = "E"
    '                                    oe.codigo_dma = CInt(Request("param1"))
    '                                    oe.codigoUniver = Session("codigoUniver_Alu")
    '                                    oe.codigo_mar = CInt(Request("r")) '27
    '                                    oe.observacion_Mat = Request("m").ToString ' "Vía Campus estudiante"
    '                                    'oe.observacion_mar = Request("m").ToString
    '                                    dt2 = ol.RetirarCursoMatricula(oe)



    '                                    If Not dt2 Is Nothing Then
    '                                        If dt2.Rows(0).Item("mensaje").ToString().Contains("Se ha registrado correctamente") Then
    '                                            dict.Add("R", "OK")
    '                                            dict.Add("Mensaje", "Se ha registrado correctamente")
    '                                        Else
    '                                            dict.Add("R", "NO")
    '                                            If dt2.Rows(0).Item("mensaje").ToString().Contains("history.back(-1)|") Then

    '                                                Dim TestArray() As String
    '                                                TestArray = Split(dt2.Rows(0).Item("mensaje").ToString(), "|")


    '                                                dict.Add("Mensaje", TestArray(1))
    '                                            ElseIf dt2.Rows(0).Item("mensaje").ToString().Contains("RET_ERROR|") Then

    '                                                Dim TestArray() As String
    '                                                TestArray = Split(dt2.Rows(0).Item("mensaje").ToString(), "|")


    '                                                dict.Add("Mensaje", TestArray(1))
    '                                            Else
    '                                                dict.Add("Mensaje", "Se ha producido un error en el retiro del curso")
    '                                            End If

    '                                        End If
    '                                    End If
    '                                Else

    '                                    dict.Add("R", "NO")
    '                                    dict.Add("Mensaje", dt1.Rows(0).Item("mensaje").ToString)

    '                                End If



    '                            End If

    '                        Else

    '                            dict.Add("R", "NO")
    '                            dict.Add("Mensaje", Session("RetMensaje").ToString)

    '                        End If
    '                    End If
    '                Else
    '                    dict.Add("R", "NO")
    '                    dict.Add("Mensaje", "Lo sentimos, el proceso de retiros no se encuentra habilitado para estudiantes ingresantes " & Session("cicloIng_Alu").ToString.Trim)

    '                    dt1 = Nothing
    '                    dt2 = Nothing
    '                    ol = Nothing
    '                    oe = Nothing
    '                End If

    '            End If




    '            list.Add(dict)

    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            'Response.write(serializer.Serialize(list))
    '            ' MsgBox(serializer.Serialize(list))
    '            JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "regNivMat" Then
    '            Dim olMat As New lMatricula
    '            Dim oeMat As New eMatricula
    '            Dim f As New lFunciones
    '            Dim values As ArrayList = f.ParamsValues(Request.Params, "param1")
    '            Dim resultado As New DataTable

    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim dict As New Dictionary(Of String, Object)()
    '            Dim cup As String = ""
    '            Dim dma As Integer = 0
    '            Dim monto As Decimal = 0
    '            Dim curso As String = ""
    '            Dim dt As New DataTable
    '            Dim Email As String
    '            Dim Asunto, mensaje, origen, destino As String
    '            Dim ObjMail As New clsMailNet
    '            Dim blnResultado As Boolean

    '            With oeMat
    '                .tipooperacion = "E"
    '                .codigo_Alu = Session("codigo_Alu")



    '                For index As Integer = 0 To values.Count - 1

    '                    If values(index).ToString().Contains("cup") Then

    '                        cup = Request(values(index).ToString())

    '                    End If

    '                    If values(index).ToString().Contains("cdma") Then

    '                        dma = Request(values(index).ToString())

    '                    End If

    '                    If values(index).ToString().Contains("costo") Then

    '                        monto = Request(values(index).ToString())

    '                    End If
    '                    If values(index).ToString().Contains("curso") Then

    '                        curso = Request(values(index).ToString())

    '                    End If
    '                Next

    '                .codigo_cup = CInt(cup)
    '                .codigo_dma = dma
    '                .monto = monto



    '            End With


    '            If Request("param2") = "1" Then

    '                dt = olMat.EjecutaProcesoNivelacion(oeMat)


    '                If Not dt Is Nothing Then



    '                    'If dt.Rows(0).Item("codigo_deu") > 0 Then

    '                    '    For i As Integer = 0 To dt.Rows.Count - 1
    '                    '        '========================
    '                    '        If dt.Rows(i).Item("emailCoordinar") <> "" Then
    '                    '            Email = dt.Rows(i).Item("emailCoordinar").ToString
    '                    '            Asunto = "Recuperar Contraseña Campus Virtual USAT"
    '                    '            mensaje = "</br><font face='Courier'>" & "Estimado(a): <b>" & dt.Rows(i).Item("NombreCoordinador").ToString.ToUpper & "</b>"
    '                    '            mensaje = mensaje + "</br></br><P><ALIGN='justify'> Se le comunica que, el alumno <b>" & dt.Rows(i).Item("alumno").ToString.ToUpper & "</b> del Programa <b>" & dt.Rows(i).Item("ProgramaProfesionalizacion").ToString.ToUpper & "</b> ha confirmado su matricula para el curso <b>" & curso.ToString.ToUpper & "</b> </P>"

    '                    '            mensaje = mensaje + "</br> Atte.<br><br>Campus Virtual - USAT.</font>"

    '                    '            origen = "desarrollosistemas@usat.edu.pe"
    '                    '            destino = Trim(Email)



    '                    '            blnResultado = ObjMail.EnviarMail("campusvirtual@usat.edu.pe", "Desarrollo de Sistemas", destino, Asunto, mensaje, True, "Desarrollo de Sistemas", destino)
    '                    '            If (blnResultado = True) Then
    '                    '                dict.Add("email", Email)
    '                    '                dict.Add("aviso", "Correo enviado correctamente")
    '                    '                ' dict.Add("respuesta", "OK")
    '                    '            Else
    '                    '                dict.Add("email", "")
    '                    '                dict.Add("aviso", "Error al enviar correo")
    '                    '                'dict.Add("respuesta", "ERROR")
    '                    '            End If
    '                    '        End If
    '                    '    Next
    '                    'End If


    '                    dict.Add("R", "OK")
    '                    dict.Add("Mensaje", "ha confirmado su matricula para el curso " & curso.ToString.ToUpper)

    '                Else
    '                    dict.Add("R", "CANCEL")
    '                    dict.Add("Mensaje", "Ocurrio un problema al confirmar la matricula, favor de volver intentar")
    '                End If


    '            Else
    '                dt = olMat.RechazaProcesoNivelacion(oeMat)


    '                If Not dt Is Nothing Then
    '                    dict.Add("R", "OK")
    '                    dict.Add("Mensaje", "ha rechazado su matricula para el curso")


    '                Else
    '                    dict.Add("R", "CANCEL")
    '                    dict.Add("Mensaje", "Ocurrio un problema al rechazar la matricula, favor de volver intentar")
    '                End If



    '            End If




    '            dt = Nothing
    '            olMat = Nothing
    '            oeMat = Nothing
    '            list.Add(dict)
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            'Response.write(serializer.Serialize(list))
    '            ' MsgBox(serializer.Serialize(list))

    '            JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "regCurRec" Then
    '            Dim olMat As New lMatricula
    '            Dim oeMat As New eMatricula

    '            Dim resultado As New DataTable

    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim dict As New Dictionary(Of String, Object)()
    '            Dim cup As String = ""
    '            Dim dma As Integer = 0
    '            Dim monto As Decimal = 0
    '            Dim curso As String = ""
    '            Dim dt As New DataTable

    '            Dim ObjMail As New clsMailNet
    '            Dim ip As String = Request.ServerVariables("REMOTE_ADDR").ToString()
    '            Dim host As String = System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName

    '            Dim hdpc As String = ip & " | " & host


    '            With oeMat
    '                .tipooperacion = "E"
    '                .codigo_Alu = Session("codigo_Alu")
    '                .codigo_Cac = Session("Codigo_Cac")
    '                .codigo_dma = Request("param3")
    '                .hdpc = hdpc
    '            End With


    '            If fnValidaCursoInvitadoUltimo(Request("param3")) Then

    '                If Request("param2") = "1" Then
    '                    If Session("codigo_test") = 2 Then
    '                        dt = olMat.ConfirmaExamenRecuperacion(oeMat)

    '                    Else
    '                        dt = olMat.ConfirmaExamenRecuperacionOtros(oeMat)

    '                    End If


    '                    If Not dt Is Nothing Then

    '                        If dt.Rows(0).Item("deuda") > 0 Then
    '                            dict.Add("R", "OK")
    '                            dict.Add("Mensaje", "ha confirmado examen de recuperacion para el curso " & curso.ToString.ToUpper)


    '                        Else

    '                            If dt.Rows(0).Item("deuda") = -1 Then
    '                                dict.Add("R", "CANCEL")
    '                                dict.Add("Mensaje", "Existe cruce de horario de examen de recuperación")

    '                            Else
    '                                dict.Add("R", "CANCEL")
    '                                dict.Add("Mensaje", "Ocurrio un problema al confirmar la matricula, favor de volver intentar")
    '                            End If


    '                        End If

    '                    Else
    '                        dict.Add("R", "CANCEL")
    '                        dict.Add("Mensaje", "Ocurrio un problema al confirmar la matricula, favor de volver intentar")
    '                    End If


    '                Else
    '                    dt = olMat.RechazaExamenRecuperacion(oeMat)


    '                    If Not dt Is Nothing Then

    '                        If dt.Rows(0).Item("codigo_dma") > 0 Then
    '                            dict.Add("R", "OK")
    '                            dict.Add("Mensaje", "ha rechazado examen de recuperacion para el curso" & curso.ToString.ToUpper)
    '                        Else

    '                            dict.Add("R", "CANCEL")
    '                            dict.Add("Mensaje", "Ocurrio un problema al rechazar la matricula, favor de volver intentar")

    '                        End If



    '                    Else
    '                        dict.Add("R", "CANCEL")
    '                        dict.Add("Mensaje", "Ocurrio un problema al rechazar la matricula, favor de volver intentar")
    '                    End If



    '                End If


    '            Else
    '                dict.Add("R", "CANCEL")
    '                dict.Add("Mensaje", "No es posible realizar solicitud ")
    '            End If


    '            dt = Nothing
    '            olMat = Nothing
    '            oeMat = Nothing
    '            list.Add(dict)
    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            'Response.write(serializer.Serialize(list))
    '            ' MsgBox(serializer.Serialize(list))

    '            JSONresult = serializer.Serialize(list)
    '            ElseIf Request("param0") = "solBec" Then
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                Dim dt As New Data.DataTable
    '                Dim oeAlumno As New eAlumno
    '                Dim olAlumno As New lAlumno
    '                oeAlumno.codigo_Alu = CInt(Session("codigo_alu"))
    '                dt = olAlumno.Beca_RegistrarSolicitud(oeAlumno)

    '                If Not dt Is Nothing Then
    '                    dict.Add("R", "OK")
    '                    dict.Add("ESTADO", dt.Rows(0).Item("estado_bso").ToString)
    '                    Select Case dt.Rows(0).Item("estado_bso").ToString
    '                        Case "enviado"
    '                            dict.Add("NOTI", "information")
    '                            dict.Add("MENSAJE", "La solicitud ha sido enviada. Al finalizar el proceso de recepción de solicitudes, se informará el resultado por este medio.")

    '                        Case "rechazado"
    '                            dict.Add("NOTI", "error")
    '                            dict.Add("MENSAJE", "Lo sentimos, en esta ocasión no has alcanzado ninguna de nuestras Becas. Te animamos a seguir esforzándote para una siguiente oportunidad.")

    '                        Case "aceptado"
    '                            dict.Add("NOTI", "success")
    '                            dict.Add("MENSAJE", "La USAT reconoce tus resultados académicos y te otorga este BENEFICIO por : <b>" & dt.Rows(0).Item("descripcion_bec").ToString & "</b>, esperando que continúes obteniendo éxitos.")

    '                    End Select

    '                Else
    '                    dict.Add("R", "C")
    '                    dict.Add("NOTI", "error")
    '                    dict.Add("MENSAJE", "Se produjo un erro al realizar esta operaci&oacute;n")
    '                End If
    '                list.Add(dict)
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'Response.write(serializer.Serialize(list))
    '                ' MsgBox(serializer.Serialize(list))

    '                JSONresult = serializer.Serialize(list)



    '            ElseIf Request("param0") = "lsMar" Then
    '                Dim i As Integer = 0
    '                Dim dt As New DataTable
    '                Dim oeMotivo As New eMotivoAgregadoRetiro
    '                Dim olMotivo As New lMotivoAgregadoRetiro
    '                oeMotivo.tipo_mar = Request("param2")
    '                oeMotivo.codigo_mar = 0

    '                dt = olMotivo.BuscaMotivoAyR(oeMotivo)

    '                'Dim dict As New Dictionary(Of String, Object)()
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'list = dtCursos



    '                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

    '                    For i = 0 To dt.Rows.Count - 1
    '                        Dim dict As New Dictionary(Of String, Object)()

    '                        dict.Add("c", dt.Rows(i).Item("codigo_mar"))
    '                        dict.Add("desc", dt.Rows(i).Item("descripcion_mar"))




    '                        list.Add(dict)


    '                    Next

    '                End If

    '                JSONresult = serializer.Serialize(list)


    '            ElseIf Request("param0") = "lsHis" Then
    '                Dim i As Integer = 0
    '                Dim dtCursos As New DataTable
    '                Dim dtProm As New DataTable
    '                Dim oeHistorialAcademico As New eHistorialAcademico
    '                Dim olHistorialAcademico As New lHistorialAcademico
    '                oeHistorialAcademico.tipo_Hac = 19

    '                '#001 - INICIO - JR
    '                Dim tipoAlumni As String
    '                tipoAlumni = Trim(Session("egresado_Alu"))

    '                If tipoAlumni = "1" Then
    '                    oeHistorialAcademico.codigo_cpf = 0
    '                    oeHistorialAcademico.codigoAlu_Hac = Request("param2")
    '                Else
    '                    oeHistorialAcademico.codigo_cpf = Request("param2")
    '                    oeHistorialAcademico.codigoAlu_Hac = Session("codigo_Alu")
    '                End If
    '                '#001 - FIN - JR

    '                oeHistorialAcademico.codigoCac_Hac = 0
    '                dtCursos = olHistorialAcademico.ConsultarNotasPorCpf(oeHistorialAcademico)

    '                'Dim dict As New Dictionary(Of String, Object)()
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'list = dtCursos

    '                Dim cac As String = ""
    '                Dim sumcred As Integer = 0
    '                Dim sumcredxnf As Decimal = 0.0
    '                Dim promciclo As Decimal = 0.0

    '                If Not dtCursos Is Nothing AndAlso dtCursos.Rows.Count > 0 Then
    '                    olHistorialAcademico = New lHistorialAcademico
    '                    cac = dtCursos.Rows(i).Item("descripcion_Cac")

    '                    For i = 0 To dtCursos.Rows.Count - 1
    '                        Dim dict As New Dictionary(Of String, Object)()
    '                        If cac <> dtCursos.Rows(i).Item("descripcion_Cac") Then
    '                            Dim dict2 As New Dictionary(Of String, Object)()
    '                            If sumcred = 0 Then
    '                                promciclo = 0
    '                            Else
    '                                oeHistorialAcademico = New eHistorialAcademico
    '                                oeHistorialAcademico.codigoAlu_Hac = Session("codigo_Alu")
    '                                oeHistorialAcademico.codigoCac_Hac = dtCursos.Rows(i - 1).Item("Codigo_cac")
    '                                dtProm = olHistorialAcademico.ConsultarPPSCVE(oeHistorialAcademico)
    '                                promciclo = CDec(dtProm.Rows(0).Item("Promedio"))
    '                                ' promciclo = sumcredxnf / sumcred
    '                            End If


    '                            dict2.Add("swprom", True)
    '                            dict2.Add("prom", promciclo)
    '                            dict2.Add("sumcred", sumcred)
    '                            cac = dtCursos.Rows(i).Item("descripcion_Cac")
    '                            list.Add(dict2)

    '                            sumcred = 0
    '                            sumcredxnf = 0

    '                        End If





    '                        dict.Add("swprom", False)
    '                        dict.Add("prom", "0")
    '                        dict.Add("sumcred", 0)
    '                        dict.Add("dma", dtCursos.Rows(i).Item("codigo_dma"))
    '                        dict.Add("desc_cac", dtCursos.Rows(i).Item("descripcion_Cac"))
    '                        dict.Add("tcurdma", dtCursos.Rows(i).Item("tipoCurso_Dma"))
    '                        dict.Add("iden", dtCursos.Rows(i).Item("identificador_Cur"))
    '                        dict.Add("curso", dtCursos.Rows(i).Item("nombre_Cur"))
    '                        dict.Add("ciclo", dtCursos.Rows(i).Item("Ciclo_Cur"))
    '                        dict.Add("cred", dtCursos.Rows(i).Item("creditoCur_Dma"))
    '                        dict.Add("nota", dtCursos.Rows(i).Item("notaFinal_Dma"))
    '                        dict.Add("condicion", dtCursos.Rows(i).Item("condicion_Dma"))
    '                        dict.Add("notacred", dtCursos.Rows(i).Item("NotaCredito"))
    '                        dict.Add("notamin", dtCursos.Rows(i).Item("notaMinima_Cac"))
    '                        dict.Add("codciclo", dtCursos.Rows(i).Item("Codigo_cac"))
    '                        dict.Add("estdma", dtCursos.Rows(i).Item("estado_dma"))
    '                        dict.Add("asidma", dtCursos.Rows(i).Item("asistencias_Dma"))
    '                        dict.Add("inasidma", dtCursos.Rows(i).Item("inasistencias_Dma"))
    '                        dict.Add("vcsdma", dtCursos.Rows(i).Item("vecesCurso_Dma"))
    '                        dict.Add("escuela", dtCursos.Rows(i).Item("escuela"))
    '                    dict.Add("grupo", dtCursos.Rows(i).Item("grupohor_cup"))


    '                    If dtCursos.Rows(i).Item("grupohor_cup").ToString.Contains("CNVTR") Then
    '                        dict.Add("cnvtr", True)
    '                    Else
    '                        dict.Add("cnvtr", False)
    '                    End If

    '                        dict.Add("tipo", dtCursos.Rows(i).Item("tipomatricula_dma"))
    '                        If dtCursos.Rows(i).Item("condicion_Dma") = "A" Then
    '                            dict.Add("color", "blue")

    '                        ElseIf dtCursos.Rows(i).Item("condicion_Dma") = "D" Then
    '                            dict.Add("color", "red")


    '                        ElseIf dtCursos.Rows(i).Item("condicion_Dma") = "P" Then
    '                            dict.Add("color", "green")
    '                        End If



    '                        sumcredxnf = sumcredxnf + (dtCursos.Rows(i).Item("notaFinal_Dma") * dtCursos.Rows(i).Item("creditoCur_Dma"))
    '                        If dtCursos.Rows(i).Item("tipomatricula_dma").ToString() <> "R" Then
    '                            sumcred = sumcred + dtCursos.Rows(i).Item("creditoCur_Dma")
    '                        End If


    '                        list.Add(dict)



    '                        If dtCursos.Rows.Count = (i + 1) Then
    '                            oeHistorialAcademico = New eHistorialAcademico
    '                            oeHistorialAcademico.codigoAlu_Hac = Session("codigo_Alu")
    '                            oeHistorialAcademico.codigoCac_Hac = dtCursos.Rows(i).Item("Codigo_cac")
    '                            dtProm = olHistorialAcademico.ConsultarPPSCVE(oeHistorialAcademico)
    '                            promciclo = CDec(dtProm.Rows(0).Item("Promedio"))
    '                            ' promciclo = sumcredxnf / sumcred


    '                            Dim dict2 As New Dictionary(Of String, Object)()
    '                            'promciclo = sumcredxnf / sumcred
    '                            'If dict.Remove("swprom") Then
    '                            dict2.Add("swprom", True)
    '                            'End If
    '                            ' If dict.Remove("prom") Then
    '                            dict2.Add("prom", promciclo)
    '                            'End If
    '                            ' If dict.Remove("sumcred") Then
    '                            dict2.Add("sumcred", sumcred)
    '                            'End If

    '                            list.Add(dict2)
    '                        End If


    '                    Next

    '                End If

    '                JSONresult = serializer.Serialize(list)

    '            ElseIf Request("param0") = "bblv" Then
    '                Dim oeBibliotecaVirtual As New eBibliotecaVirtual
    '                Dim olBibliotecaVirtual As New lBibliotecaVirtual

    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()


    '                oeBibliotecaVirtual.codigobiv = Request("param2")
    '                oeBibliotecaVirtual.codigoalu = Session("codigo_Alu")
    '                olBibliotecaVirtual.RegistarVisita(oeBibliotecaVirtual)
    '                oeBibliotecaVirtual = Nothing
    '                olBibliotecaVirtual = Nothing

    '                dict.Add("r", "OK")
    '                dict.Add("msj", "Ok")


    '                list.Add(dict)
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'Response.write(serializer.Serialize(list))
    '                ' MsgBox(serializer.Serialize(list))
    '                JSONresult = serializer.Serialize(list)
    '            ElseIf Request("param0") = "CnfS" Then
    '                Dim swcpf As Boolean = True
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                dict.Add("codigoUniversitario", Session("codigoUniver_Alu"))
    '                dict.Add("foto", Session("rutaFoto"))

    '                If Session("codigo_Cpf") = "24" Or Session("codigo_Cpf") = "31" Or Session("precioCreditoNew_Alu") = 0 Then
    '                    swcpf = False
    '                Else
    '                    swcpf = True
    '                End If

    '                If Session("codigo_test") = "2" Then
    '                    If swcpf Then
    '                        dict.Add("pen", True)
    '                    Else
    '                        dict.Add("pen", False)
    '                    End If

    '                Else
    '                    dict.Add("pen", False)
    '                End If
    '                dict.Add("x", Session("precioCreditoNew_Alu"))
    '                list.Add(dict)
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'Response.write(serializer.Serialize(list))
    '                ' MsgBox(serializer.Serialize(list))
    '                JSONresult = serializer.Serialize(list)

    '            ElseIf Request("param0") = "CnfSE" Then

    '                Dim dict As New Dictionary(Of String, Object)()
    '                dict.Add("swEe", CBool(Session("obligar").ToString))
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                JSONresult = serializer.Serialize(dict)

    '            ElseIf Request("param0") = "lstDAl" Then

    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                Dim dt As New DataTable
    '                Dim dtProm As New DataTable
    '                Dim oeAlumno As New eAlumno
    '                Dim olAlumno As New lAlumno
    '                oeAlumno.tipoOperacion = "RG"
    '                oeAlumno.codigo_Alu = Session("codigo_Alu")
    '                dt = olAlumno.consultarAlumno(oeAlumno)




    '                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

    '                    If dt.Rows(0).Item("confirmaDatos") = 0 Then

    '                        dict.Add("mod", True)
    '                        dict.Add("email1", dt.Rows(0).Item("eMail_Alu").ToString)
    '                        dict.Add("email2", dt.Rows(0).Item("email2_Alu").ToString)
    '                        dict.Add("fijo", dt.Rows(0).Item("telefonoCasa_Dal").ToString)
    '                        dict.Add("movil", dt.Rows(0).Item("telefonoMovil_Dal").ToString)
    '                        dict.Add("direccion", dt.Rows(0).Item("direccion_Dal").ToString)

    '                    Else
    '                        If (CInt(dt.Rows(0).Item("modificardatos")) > 0 And (CInt(dt.Rows(0).Item("modificardatos")) Mod 6) = 0) Then
    '                            dict.Add("mod", True)
    '                            dict.Add("email1", dt.Rows(0).Item("eMail_Alu").ToString)
    '                            dict.Add("email2", dt.Rows(0).Item("email2_Alu").ToString)
    '                            dict.Add("fijo", dt.Rows(0).Item("telefonoCasa_Dal").ToString)
    '                            dict.Add("movil", dt.Rows(0).Item("telefonoMovil_Dal").ToString)
    '                            dict.Add("direccion", dt.Rows(0).Item("direccion_Dal").ToString)
    '                        Else
    '                            dict.Add("mod", False)
    '                        End If

    '                    End If

    '                End If

    '                list.Add(dict)
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'Response.write(serializer.Serialize(list))
    '                ' MsgBox(serializer.Serialize(list))
    '                JSONresult = serializer.Serialize(list)
    '            ElseIf Request("param0") = "gTlf" Then
    '                Dim f As New lFunciones
    '                Dim values As ArrayList = f.ParamsValues(Request.Params, "param2")
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                Dim dt As New DataTable
    '                Dim dtProm As New DataTable
    '                Dim oeAlumno As New eAlumno
    '                Dim olAlumno As New lAlumno


    '                With oeAlumno
    '                    .codigo_Alu = Session("codigo_Alu")
    '                    .email_Alu = ""
    '                    .email_Alu2 = ""
    '                    .direccion = ""
    '                    .telefonocasa = ""
    '                    .telefonomovil = Request("param1")

    '                End With
    '                dt = olAlumno.ModificaDatosAlumnoV2(oeAlumno)

    '                If Not dt Is Nothing AndAlso dt.Rows(0).Item("rpta").ToString = "OK" Then
    '                    dict.Add("r", True)
    '                    dict.Add("msje", "Se ha modificado sus datos correctamente")
    '                    dict.Add("alert", "success")

    '                Else
    '                    dict.Add("r", False)
    '                    dict.Add("alert", "warning")
    '                    dict.Add("msje", "Ha ocurrido un problema al modificar sus datos. Consulte a desarrollo serviciosti@usat.edu.pe")
    '                End If



    '                'list.Add(dict)

    '                oeAlumno = Nothing
    '                olAlumno = Nothing
    '                dt = Nothing

    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'Response.write(serializer.Serialize(list))
    '                'MsgBox(serializer.Serialize(list))
    '                JSONresult = serializer.Serialize(dict)

    '            ElseIf Request("param0") = "modDAl" Then  ' modificar datos del alumno
    '                Dim f As New lFunciones
    '                Dim values As ArrayList = f.ParamsValues(Request.Params, "param2")
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                Dim dt As New DataTable
    '                Dim dtProm As New DataTable
    '                Dim oeAlumno As New eAlumno
    '                Dim olAlumno As New lAlumno

    '                If CBool(Request(values(5))) Then
    '                    With oeAlumno
    '                        .codigo_Alu = Session("codigo_Alu")
    '                        .email_Alu = Request(values(0).ToString)
    '                        .email_Alu2 = Request(values(1).ToString)
    '                        .direccion = Request(values(4).ToString)
    '                        .telefonocasa = Request(values(2).ToString)
    '                        .telefonomovil = Request(values(3).ToString)
    '                        If CBool(Request(values(5))) Then
    '                            .confirmaDatos = 1
    '                        Else
    '                            .confirmaDatos = 0
    '                        End If

    '                    End With
    '                    dt = olAlumno.ModificaDatosAlumno(oeAlumno)

    '                    If Not dt Is Nothing AndAlso dt.Rows(0).Item("rpta").ToString = "OK" Then
    '                        dict.Add("r", True)
    '                        dict.Add("msje", "Se ha modificado sus datos correctamente")
    '                        dict.Add("alert", "success")

    '                    Else
    '                        dict.Add("r", False)
    '                        dict.Add("alert", "warning")
    '                        dict.Add("msje", "Ha ocurrido un problema al modificar sus datos. Consulte a desarrollo serviciosti@usat.edu.pe")
    '                    End If

    '                Else
    '                    dict.Add("r", False)
    '                    dict.Add("msje", "No ha aceptado los t&eacute;rminos y condiciones")
    '                    dict.Add("alert", "warning")
    '                End If

    '                list.Add(dict)

    '                oeAlumno = Nothing
    '                olAlumno = Nothing
    '                dt = Nothing

    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'Response.write(serializer.Serialize(list))
    '                ' MsgBox(serializer.Serialize(list))
    '                JSONresult = serializer.Serialize(list)

    '            ElseIf Request("param0") = "SPns" Then
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim dict As New Dictionary(Of String, Object)()
    '                Dim oeDeuda As New eDeuda
    '                Dim olDeuda As New lDeuda
    '                Dim dtDeuda As New DataTable

    '                oeDeuda.alumno.codigo_Alu = Session("codigo_Alu")
    '                oeDeuda.cuotas = Request("param2")
    '                oeDeuda.tipo = "2"
    '                dtDeuda = olDeuda.ConsultaSimuladorPensiones(oeDeuda)
    '                'Response.Write(dtDeuda.Rows(0).Item("pagoMensualAnterior"))
    '                If Not dtDeuda Is Nothing AndAlso dtDeuda.Rows.Count > 0 Then
    '                    dict.Add("pagoAnterior", dtDeuda.Rows(0).Item("pagoMensualAnterior"))
    '                    dict.Add("pagoActual", dtDeuda.Rows(0).Item("pagoMensual"))
    '                    dict.Add("difxmen", Math.Abs(CDec(dtDeuda.Rows(0).Item("pagoMensual")) - CDec(dtDeuda.Rows(0).Item("pagoMensualAnterior"))))
    '                    dict.Add("difxcred", Format("#####.##", Math.Abs((CDec(dtDeuda.Rows(0).Item("pagoMensual")) - CDec(dtDeuda.Rows(0).Item("pagoMensualAnterior")))) / Request("param2")))
    '                End If

    '                list.Add(dict)
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'Response.write(serializer.Serialize(list))
    '                ' MsgBox(serializer.Serialize(list))
    '                JSONresult = serializer.Serialize(list)

    '            ElseIf Request("param0") = "lsDAL" Then
    '                Dim i As Integer = 0
    '                Dim oeAlumno As New eAlumno
    '                Dim olAlumno As New lAlumno
    '                Dim dt As New DataTable
    '                oeAlumno.codigo_Alu = Session("codigo_Alu")
    '                oeAlumno.tipoOperacion = "RG"
    '                dt = olAlumno.consultarAlumno(oeAlumno)

    '                'Dim dict As New Dictionary(Of String, Object)()
    '                Dim list As New List(Of Dictionary(Of String, Object))()
    '                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '                'list = dtCursos



    '                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then


    '                    Dim dict As New Dictionary(Of String, Object)()

    '                    dict.Add("nombresAlu", dt.Rows(0).Item("ApellidosNombres").ToString.ToUpper)
    '                    dict.Add("escuelaAlu", dt.Rows(0).Item("EscuelaProfesional").ToString.ToUpper)
    '                    dict.Add("codigoUniver", dt.Rows(0).Item("codigoUniver_Alu").ToString.ToUpper)
    '                    dict.Add("fechaNacimiento", CDate(dt.Rows(0).Item("fechaNacimiento_Alu")).ToShortDateString)
    '                    dict.Add("cicloIngreso", dt.Rows(0).Item("SemIngreso").ToString)
    '                    dict.Add("planEstudio", StrConv(dt.Rows(0).Item("PlanEstudio").ToString.ToLower, VbStrConv.ProperCase))
    '                    dict.Add("nroDocIdent", dt.Rows(0).Item("nroDocIdent_Alu").ToString)
    '                    dict.Add("emailAlu", dt.Rows(0).Item("eMail_Alu").ToString)
    '                    dict.Add("email2Alu", dt.Rows(0).Item("email2_Alu").ToString)
    '                    dict.Add("direccionAlu", StrConv(dt.Rows(0).Item("direccion_Dal").ToString.ToLower, VbStrConv.ProperCase))
    '                    dict.Add("telefonoAlu", dt.Rows(0).Item("telefonoCasa_Dal").ToString)
    '                    dict.Add("movilAlu", dt.Rows(0).Item("telefonoMovil_Dal").ToString)
    '                    dict.Add("centrotrabajoAlu", StrConv(dt.Rows(0).Item("centroTrabajo_Dal").ToString.ToLower, VbStrConv.ProperCase))
    '                    dict.Add("religionAlu", StrConv(dt.Rows(0).Item("religion_Dal").ToString.ToLower, VbStrConv.ProperCase))
    '                    dict.Add("ultimosacramentoAlu", StrConv(dt.Rows(0).Item("ultimoSacramento_Dal").ToString.ToLower, VbStrConv.ProperCase))
    '                    dict.Add("tipocolegioAlu", StrConv(dt.Rows(0).Item("tipoColegio_Dal").ToString.ToLower, VbStrConv.ProperCase))

    '                    dict.Add("institucionAlu", StrConv(dt.Rows(0).Item("nombre_Col").ToString.ToLower & " (" & dt.Rows(0).Item("nombreDis_Col").ToString.ToLower & " / " & dt.Rows(0).Item("nombrePro_Col").ToString.ToLower & " / " & dt.Rows(0).Item("nombreDep_Col").ToString.ToLower & " )", VbStrConv.ProperCase))

    '                    dict.Add("anioegresoAlu", dt.Rows(0).Item("añoEgresoSec_Dal").ToString)
    '                    dict.Add("contactoAlu", StrConv(dt.Rows(0).Item("PersonaFam_Dal").ToString.ToLower, VbStrConv.ProperCase))
    '                    dict.Add("direccioncontactoAlu", StrConv(dt.Rows(0).Item("direccionFam_Dal").ToString.ToLower & " " & dt.Rows(0).Item("urbanizacionFam_Dal").ToString.ToLower & " (" & dt.Rows(0).Item("nombreDisFam_Dal").ToString.ToLower & " / " & dt.Rows(0).Item("nombreProFam_Dal").ToString.ToLower & " / " & dt.Rows(0).Item("nombreDepFam_Dal").ToString.ToLower & ")", VbStrConv.ProperCase))
    '                    dict.Add("telefonocontactoAlu", dt.Rows(0).Item("telefonoFam_Dal").ToString)






    '                    list.Add(dict)




    '                End If

    '                JSONresult = serializer.Serialize(list)
    '        ElseIf Request("param0") = "gCC" Then   ' graba carta de compromiso

    '            Dim dict As New Dictionary(Of String, Object)()

    '            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '            Try
    '                Dim oeMat As New eMatricula
    '                Dim olMat As New lMatricula
    '                Dim dtMat As New DataTable
    '                oeMat.codigo_Alu = Session("codigo_Alu")
    '                oeMat.codigo_Cac = Session("Codigo_Cac")
    '                oeMat.codigo_sco = 246
    '                dtMat = olMat.RegistrarBitacoraCartaCompromiso(oeMat)

    '                If dtMat IsNot Nothing AndAlso dtMat.Rows.Count > 0 Then
    '                    If dtMat.Rows(0).Item("cod") > 0 Then
    '                        dict.Add("cc", dtMat.Rows(0).Item("cod"))
    '                        dict.Add("r", True)
    '                        dict.Add("alert", "success")
    '                        dict.Add("msj", "Carta registrada con exito")


    '                        Dim Email As String = ""
    '                        Email = Session("email")
    '                        'Email = "esaavedra@usat.edu.pe"


    '                        If Email IsNot Nothing Or Email <> "" Then
    '                            Dim blnResultado As Boolean = False
    '                            Dim Asunto, mensaje, origen, destino As String
    '                            Dim ObjMail As New clsMailNet
    '                            Asunto = "Constancia de Carta de Compromiso - Campus Estudiante"
    '                            mensaje = "<html><head><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' /><title>Constancia de Carta de Compromiso - Campus Estudiante</title><style type='text/css'>"
    '                            mensaje = mensaje + ".Estilo1 {font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 12px;}</style></head><body><table width='100%' border='0'>"
    '                            mensaje = mensaje + "<tr><td colspan='3'>&nbsp;</td></tr><tr><td><span class='Estilo1'>Estimado(a) <b>" & Session("nombreCompleto").ToString & "</b></span></td></tr>"
    '                            mensaje = mensaje + "<td>&nbsp;</td><td>&nbsp;</td></tr><tr><td><br><span class='Estilo1'>El día de Hoy " + CDate(Date.Today).ToString("dddd").ToString + " " + CStr(CDate(Date.Today).ToString("dd/MM/yyyy")) + " a las " + Date.Now.ToString("hh:mm tt").ToString + " horas. Ud ha aceptado el siguiente compromiso: "


    '                            mensaje = mensaje + "<br><br>""Mediante la presente, me obligo desde este momento libre y voluntariamente  a aprobar cada asignatura en la que me inscriba durante los meses de  enero y febrero de 2018, las mismas que he desaprobado en ciclos anteriores, caso contrario acepto la medida de separación definitiva y automática de la Universidad establecida en el  artículo 47° del Reglamento de Estudios de Pregrado y el artículo 102 de la Ley Universitaria 30220."""

    '                            mensaje = mensaje + "<br><br>Una vez iniciada las clases debe presentar esta carta impresa y firmada a la Dirección de Escuela.  La Fecha límite de presentación es hasta el 15 de enero 2018, caso contrario quedará anulada su inscripción."

    '                            mensaje = mensaje + "</span></td><td>&nbsp;</td><td>&nbsp;</td></tr></table></body></hmtl>"
    '                            origen = "serviciosti@usat.edu.pe"
    '                            destino = Trim(Email)
    '                            blnResultado = ObjMail.EnviarMail("serviciosti@usat.edu.pe", "Servicios TI", destino, Asunto, mensaje, True, "Servicios TI", destino)
    '                            dict.Add("mail", Email)
    '                            If (blnResultado) Then
    '                                dict.Add("envio", True)
    '                            Else
    '                                dict.Add("envio", False)
    '                            End If

    '                        End If


    '                    Else
    '                        dict.Add("cc", 0)
    '                        dict.Add("r", False)
    '                        dict.Add("msj", "Surgieron problemas al registrar carta de compromiso")
    '                    End If
    '                End If
    '            Catch ex As Exception
    '                dict.Add("cc", 0)
    '                dict.Add("r", False)
    '                dict.Add("alert", "error")
    '                dict.Add("msj", ex.Message)
    '            End Try




    '            JSONresult = serializer.Serialize(dict)


    '            Else
    '                If (Request("param5") <> "") Then
    '                    JSONresult = DataToJSON(Request("param0"), Request("param1"), Request("param2"), Request("param3"), Request("param4"), Request("param5"))
    '                Else
    '                    JSONresult = DataToJSON(Request("param0"), Request("param1"), Request("param2"), Request("param3"), Request("param4"))
    '                End If
    '            End If
    '            Response.Write(JSONresult)
    '    End If
    'End Sub

    'Private Function seleccionarcup(ByVal cup As String, ByVal codmat As String) As String
    '    Try
    '        Dim TestArray() As String
    '        TestArray = Split(codmat.ToString(), ",")
    '        Dim TestArrayCup() As String
    '        TestArrayCup = Split(cup.ToString(), ",")

    '        Dim j As Integer = 0
    '        Dim strcup As String = ""

    '        For i As Integer = 0 To TestArray.Length - 2
    '            If CInt(TestArray(i)) = 0 Then

    '                strcup = strcup & TestArrayCup(i).ToString & ","

    '            End If
    '        Next

    '        Return strcup
    '    Catch ex As Exception
    '        Return ""
    '    End Try
    'End Function
    'Private Function ValidaRetiro(ByVal detmat As String) As Boolean
    '    Try
    '        Dim sw As Boolean = True
    '        Dim rpta As String = ""
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim codigo_cur As Integer = CInt(fnBuscarDataDetMat(detmat, "ccur"))


    '        If fnValidaRetiroComplementario(codigo_cur) Then
    '            If fnValidaRetiroCreditos(codigo_cur) Then
    '                If fnValidaRetiroSuperiordp(codigo_cur) Then

    '                    If fnValidaRetiroSuperior(codigo_cur) Then

    '                        sw = True
    '                    Else
    '                        rpta = "Primero debes retirarte de cursos de ciclos superiores"
    '                        sw = False
    '                    End If
    '                Else
    '                    rpta = "No puedes retirarte de cursos desaprobados"
    '                    sw = False
    '                End If

    '            Else
    '                rpta = "No puedes retirarte de este curso. Cr&eacute;ditos mínimos para llevar en ciclo regular: 12"

    '                sw = False
    '            End If

    '        Else
    '            rpta = "No puedes retirarte de cursos complementarios"
    '            sw = False
    '        End If




    '        Session.Add("RetMensaje", rpta)
    '        Return sw
    '    Catch ex As Exception

    '    End Try
    'End Function
    'Private Function fnValidaRetiroCreditos(ByVal codigo_cur As Integer) As Boolean
    '    Try
    '        Dim sw As Boolean = True
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim creditos As Integer = CInt(fnBuscarData(codigo_cur, "cred"))
    '        Dim cicSel As Integer = CInt(fnBuscarData(codigo_cur, "cic"))
    '        Dim acumcred As Integer = 0
    '        For i As Integer = 0 To list.Count - 1
    '            If CInt(list(i).Item("cup_Mat")) > 0 Then

    '                acumcred = acumcred + CInt(list(i).Item("vCred"))

    '            End If
    '        Next

    '        If (acumcred - creditos) < 12 Then
    '            sw = False
    '        End If


    '        Return sw
    '    Catch ex As Exception
    '        Return False
    '        Response.Write(ex.Message)
    '    End Try
    'End Function
    'Private Function fnValidaRetiroSuperior(ByVal codigo_cur As Integer) As Boolean
    '    Try
    '        Dim sw As Boolean = True
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        'Dim cupmat As Integer = CInt(fnBuscarData(codigo_cur, "cupm"))
    '        Dim cicSel As Integer = CInt(fnBuscarData(codigo_cur, "cic"))
    '        For i As Integer = 0 To list.Count - 1
    '            If CInt(list(i).Item("vCic")) > cicSel And CInt(list(i).Item("cup_Mat")) > 0 Then

    '                sw = False
    '                Exit For

    '            End If
    '        Next

    '        Return sw
    '    Catch ex As Exception
    '        Return False
    '        Response.Write(ex.Message)
    '    End Try
    'End Function
    'Private Function fnValidaRetiroSuperiordp(ByVal codigo_cur As Integer) As Boolean
    '    Try
    '        Dim sw As Boolean = True
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim veces As Integer = CInt(fnBuscarData(codigo_cur, "vec"))

    '        If veces > 0 Then

    '            sw = False


    '        End If
    '        Return sw
    '    Catch ex As Exception
    '        Return False
    '        Response.Write(ex.Message)
    '    End Try
    'End Function
    'Private Function fnValidaRetiroComplementario(ByVal codigo_cur As Integer) As Boolean
    '    Try
    '        Dim sw As Boolean = True
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim vtc As String = fnBuscarData(codigo_cur, "tc")

    '        If vtc = "I" Or vtc = "C" Then

    '            sw = False


    '        End If
    '        Return sw
    '    Catch ex As Exception
    '        Return False
    '        Response.Write(ex.Message)
    '    End Try
    'End Function
    'Private Function seleccionarveces(ByVal vcs As String, ByVal codmat As String) As String
    '    Try



    '        Dim TestArray() As String
    '        TestArray = Split(codmat.ToString(), ",")
    '        Dim TestArrayVeces() As String
    '        TestArrayVeces = Split(vcs.ToString(), ",")

    '        Dim j As Integer = 0
    '        Dim strveces As String = ""

    '        For i As Integer = 0 To TestArray.Length - 2
    '            If CInt(TestArray(i)) = 0 Then
    '                strveces = strveces & TestArrayVeces(i).ToString & ","
    '            End If
    '        Next

    '        Return strveces
    '    Catch ex As Exception
    '        Return ""
    '    End Try
    'End Function
    'Private Sub ActivarCursos(ByVal cadCursos As String)
    '    Dim list As New List(Of Dictionary(Of String, Object))()
    '    list = Session("lstCursosDisponiblesJson")
    '    Dim TestArray() As String
    '    TestArray = Split(cadCursos.ToString(), ",")
    '    Dim sumCreditos As Integer = 0





    '    For i As Integer = 0 To TestArray.Length - 2
    '        For j As Integer = 0 To list.Count - 1
    '            If CInt(TestArray(i)) = CInt(list(j).Item("codigo_cur").ToString) Then

    '                list(j).Item("chk") = True
    '                sumCreditos = sumCreditos + CInt(list(j).Item("credCurso").ToString)
    '                Exit For
    '            End If

    '        Next


    '    Next
    '    Session("credSelec") = sumCreditos
    '    Session("lstCursosDisponiblesJson") = list
    'End Sub
    'Private Sub DesactivarCursos(ByVal cadCursos As String)
    '    Dim list As New List(Of Dictionary(Of String, Object))()
    '    list = Session("lstCursosDisponiblesJson")
    '    Dim TestArray() As String
    '    TestArray = Split(cadCursos.ToString(), ",")

    '    For i As Integer = 0 To TestArray.Length - 2
    '        For j As Integer = 0 To list.Count - 1
    '            If CInt(TestArray(i)) = CInt(list(j).Item("codigo_cur").ToString) Then

    '                list(j).Item("chk") = False
    '                Exit For
    '            End If


    '        Next


    '    Next
    '    Session("lstCursosDisponiblesJson") = list


    'End Sub
    'Private Function ExistenCursos(ByVal cadCursos As String) As String
    '    Try
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim TestArray() As String
    '        TestArray = Split(cadCursos.ToString(), ",")

    '        Dim _cad As String = ""
    '        Dim sw As Boolean = False



    '        For i As Integer = 0 To TestArray.Length - 2
    '            For j As Integer = 0 To list.Count - 1
    '                If CInt(TestArray(i)) = CInt(list(j).Item("codigo_cur").ToString) Then
    '                    sw = True
    '                    Exit For
    '                End If
    '            Next

    '            If sw Then
    '                _cad = _cad & "1,"
    '            Else
    '                _cad = _cad & "0,"

    '            End If
    '            sw = False
    '        Next

    '        Return _cad
    '    Catch ex As Exception
    '        Return ""
    '    End Try


    'End Function
    'Private Function ValidaMatricula(ByVal cadCursos As String) As Boolean
    '    Try
    '        Dim sw As Boolean = False
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Session("cElf") = False
    '        Dim TestArray() As String
    '        TestArray = Split(cadCursos.ToString(), ",")
    '        Session.Add("lstCurMat", TestArray)
    '        Dim rpta As String = ""
    '        For i As Integer = 0 To TestArray.Length - 2

    '            'If Session("credSelec") < 15 Then

    '            '    rpta = "No puedes Matricularte, los cr&eacute;ditos mínimos para llevar en ciclo regular: 15"
    '            '    sw = False
    '            'Else

    '            If Session("credSelec") > Session("credMaxMat") Then
    '                rpta = "No puede llevar mas de " & Session("credSelec") & "  cr&eacute;ditos'"
    '                sw = False
    '            Else
    '                Session("cElf") = True
    '                If fnValidaSeleccionElectivo(CInt(TestArray(i))) Then
    '                    If fnValidaSeleccionInferiorDesaprobado(CInt(TestArray(i))) Then
    '                        If fnValidaSeleccionComplementario(CInt(TestArray(i))) Then

    '                            If fnValidaSeleccionIdioma(CInt(TestArray(i))) Then

    '                                If fnValidaSeleccionInferior(CInt(TestArray(i))) Then
    '                                    sw = True
    '                                Else
    '                                    rpta = "Debes cursos de ciclos inferiores"
    '                                    sw = False
    '                                End If
    '                            Else

    '                                rpta = "Debes curso complementario (Idioma)"
    '                                sw = False
    '                            End If



    '                        Else
    '                            rpta = "Debes seleccionar un curso complementario (c&oacute;mputo)"""
    '                            sw = False
    '                        End If


    '                    Else
    '                        rpta = "No puede seleccionar este curso, primero seleccione cursos desaprobados"
    '                        sw = False
    '                    End If

    '                Else
    '                    rpta = "Debes cursos electivos"
    '                    Session("cElf") = False
    '                    sw = False
    '                End If

    '            End If

    '            'End If

    '            If sw = False Then

    '                Exit For

    '            End If

    '        Next
    '        Session.Add("MatMensaje", rpta)
    '        Session.Remove("lstCurMat")
    '        Return sw
    '    Catch ex As Exception

    '    End Try
    'End Function
    'Private Function fnValidaSeleccionInferiorDesaprobado(ByVal codigo_cur As Integer) As Boolean
    '    Try
    '        Dim sw As Boolean = True
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim cicSel As Integer = CInt(fnBuscarData(codigo_cur, "cic"))
    '        For i As Integer = 0 To list.Count - 1
    '            If CInt(list(i).Item("vCic")) < cicSel And CInt(list(i).Item("stt")) = 1 And list(i).Item("chk") = False And CInt(list(i).Item("vvec").ToString) > 0 Then
    '                If Session("cElf") = False Then
    '                    sw = False
    '                    Exit For
    '                End If
    '            End If
    '        Next
    '        Return sw
    '    Catch ex As Exception
    '        Return False
    '        Response.Write(ex.Message)
    '    End Try
    'End Function
    'Private Function fnValidaSeleccionInferior(ByVal codigo_cur As Integer) As Boolean
    '    Try
    '        Dim sw As Boolean = True
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim cicSel As Integer = CInt(fnBuscarData(codigo_cur, "cic"))
    '        For i As Integer = 0 To list.Count - 1
    '            If list(i).Item("electivo_cur").ToString = "False" And CInt(list(i).Item("vCic")) < cicSel And CInt(list(i).Item("stt")) = 1 And list(i).Item("vtc").ToString <> "I" And list(i).Item("chk") = False Then

    '                If list(i).Item("vtc").ToString <> "C" Then
    '                    sw = False
    '                    Exit For
    '                End If
    '            End If
    '        Next
    '        Return sw
    '    Catch ex As Exception
    '        Return False
    '        Response.Write(ex.Message)
    '    End Try
    'End Function
    'Private Function fnValidaSeleccionComplementario(ByVal codigo_cur As Integer) As Boolean
    '    Try

    '        Dim sw As Boolean = True
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim cicSel As Integer = CInt(fnBuscarData(codigo_cur, "cic"))
    '        For i As Integer = 0 To list.Count - 1
    '            'If list(i).Item("electivo_cur").ToString = "False" And CInt(list(i).Item("vCic")) < cicSel And CInt(list(i).Item("stt")) = 1 Then
    '            If CInt(list(i).Item("vCic")) < cicSel And CInt(list(i).Item("stt")) = 1 Then

    '                'If list(i).Item("chk") = False And (list(i).Item("vtc").ToString = "I" Or list(i).Item("vtc").ToString = "C") Then
    '                If list(i).Item("chk") = False And list(i).Item("vtc").ToString = "C" Then

    '                    If fnValidaCC(list(i).Item("vtc").ToString) Then
    '                        sw = False
    '                        Exit For
    '                    End If

    '                End If


    '            End If

    '        Next

    '        Return sw

    '    Catch ex As Exception
    '        Return False
    '        Response.Write(ex.Message)
    '    End Try

    'End Function
    'Private Function fnValidaCC(ByVal tc As String) As Boolean
    '    Try
    '        Dim sw As Boolean = True
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")

    '        Dim I As Integer = 0
    '        Dim C As Integer = 0

    '        If tc = "I" Then
    '            For j As Integer = 0 To list.Count - 1
    '                If list(j).Item("vtc").ToString = "I" Then
    '                    I = I + 1

    '                End If
    '            Next

    '            If I >= 1 Then
    '                sw = False
    '            Else
    '                sw = True
    '            End If

    '        ElseIf tc = "C" Then
    '            For j As Integer = 0 To list.Count - 1
    '                If list(j).Item("vtc").ToString = "C" Then
    '                    C = C + 1
    '                End If
    '            Next
    '            If C = 1 Then
    '                sw = False
    '            Else
    '                sw = True
    '            End If
    '        Else
    '            sw = True

    '        End If

    '        Return sw
    '    Catch ex As Exception
    '        Return False
    '    End Try

    'End Function
    'Private Function fnValidaSeleccionElectivo(ByVal codigo_cur As Integer) As Boolean
    '    Try
    '        Dim nel As Integer = fnElectivoSel()
    '        Dim total As Integer = CInt(Session("elecAprob")) + nel

    '        If total >= CInt(Session("elecPes")) Then
    '            Session("rElec") = True
    '        Else
    '            Session("rElec") = False
    '        End If

    '        Dim sw As Boolean = True

    '        If Session("rElec") Then
    '            sw = True
    '        Else
    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            list = Session("lstCursosDisponiblesJson")
    '            Dim cicSel As Integer = CInt(fnBuscarData(codigo_cur, "cic"))
    '            For i As Integer = 0 To list.Count - 1
    '                If CInt(list(i).Item("vnel")) > CInt(list(i).Item("velap")) And CInt(list(i).Item("vCic")) < cicSel And CInt(list(i).Item("stt")) = 1 Then

    '                    ' if (fnValidaSeleccionElectivoCicloChk(aData[i].vCic)) 
    '                    If fnValidaSeleccionElectivoCicloChk(CInt(list(i).Item("vCic"))) Then
    '                        sw = False
    '                        Exit For
    '                    End If
    '                End If
    '                'if (aData[i].electivo_cur == 'True' && parseInt(aData[i].vnel) > parseInt(aData[i].velap) && parseInt(aData[i].vCic) < parseInt(cicSel) && parseInt(aData[i].stt)==1) { // && sThisVal == "0" && ) {
    '            Next
    '        End If
    '        Return sw

    '    Catch ex As Exception
    '        Return False
    '        Response.Write(ex.Message)
    '    End Try

    'End Function

    'Private Function fnElectivoSel() As Integer

    '    Dim s As Integer = 0
    '    Dim list As New List(Of Dictionary(Of String, Object))()
    '    list = Session("lstCursosDisponiblesJson")

    '    For i As Integer = 0 To List.Count - 1
    '        'If list(i).Item("electivo_cur") = "True" And CInt(list(i).Item("vnel")) >= CInt(list(i).Item("velap")) Then
    '        If list(i).Item("electivo_cur") = "True" Then
    '            If list(i).Item("chk") = True Then
    '                If fnElectivoMat(list(i).Item("codigo_cur")) Then
    '                    s = s + 1
    '                End If

    '            End If
    '        End If
    '    Next
    '    Return s
    'End Function

    'Private Function fnElectivoMat(ByVal cur As Integer) As Integer
    '    Dim sw As Boolean = False
    '    '  Dim list As New List(Of Dictionary(Of String, Object))()
    '    Dim TestArrayCur() As String
    '    TestArrayCur = Session("lstCurMat")
    '    For i As Integer = 0 To TestArrayCur.Length - 2
    '        If TestArrayCur(i) = cur Then
    '            sw = True
    '            Exit For
    '        End If
    '    Next
    '    Return sw

    'End Function

    'Private Function fnValidaSeleccionElectivoCicloChk(ByVal ciclo As Integer) As Boolean
    '    Dim sw As Boolean = True
    '    Dim list As New List(Of Dictionary(Of String, Object))()
    '    list = Session("lstCursosDisponiblesJson")
    '    Dim Elec As Integer = 0
    '    Dim sElec As Integer = 0
    '    For i As Integer = 0 To list.Count - 1
    '        If list(i).Item("electivo_cur") = "True" And CInt(list(i).Item("vCic")) = ciclo Then
    '            Elec = CInt(list(i).Item("vnel")) - CInt(list(i).Item("velap"))
    '            If list(i).Item("chk") = True Then
    '                sElec = sElec + 1
    '            End If

    '            If sElec = Elec Then
    '                sw = False
    '                Exit For
    '            End If

    '            'If list(i).Item("chk") = True Then
    '            '    sw = False
    '            '    Exit For
    '            'End If


    '        End If
    '        'if (aData[i].electivo_cur == 'True' && parseInt(aData[i].vnel) > parseInt(aData[i].velap) && parseInt(aData[i].vCic) < parseInt(cicSel) && parseInt(aData[i].stt)==1) { // && sThisVal == "0" && ) {
    '    Next

    '    Return sw

    'End Function

    'Private Function fnValidaSeleccionIdioma(ByVal codigo_cur As Integer) As Boolean
    '    Try
    '        Dim sw As Boolean = True
    '        'If Session("rIdi") Then
    '        '    sw = True
    '        'Else
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim cicSel As Integer = CInt(fnBuscarData(codigo_cur, "cic"))
    '        For i As Integer = 0 To list.Count - 1

    '            ' If list(i).Item("vtc").ToString = "I" And CInt(list(i).Item("vnidi")) > CInt(list(i).Item("vidiap")) And CInt(list(i).Item("vCic")) < cicSel And CInt(list(i).Item("stt")) = 1 Then
    '            If list(i).Item("vtc").ToString = "I" And CInt(list(i).Item("vCic")) < cicSel And CInt(list(i).Item("stt")) = 1 And list(i).Item("sIdi") = True Then
    '                ' if (fnValidaSeleccionElectivoCicloChk(aData[i].vCic)) 
    '                If fnValidaSeleccionIdiomaCicloChk(CInt(list(i).Item("vCic"))) Then
    '                    sw = False
    '                    Exit For
    '                End If
    '            End If
    '            'if (aData[i].electivo_cur == 'True' && parseInt(aData[i].vnel) > parseInt(aData[i].velap) && parseInt(aData[i].vCic) < parseInt(cicSel) && parseInt(aData[i].stt)==1) { // && sThisVal == "0" && ) {
    '        Next

    '        'End If
    '        Return sw

    '    Catch ex As Exception
    '        Return False
    '        Response.Write(ex.Message)
    '    End Try


    'End Function

    'Private Function fnValidaSeleccionIdiomaCicloChk(ByVal ciclo As Integer) As Boolean
    '    Dim sw As Boolean = True
    '    Dim list As New List(Of Dictionary(Of String, Object))()
    '    list = Session("lstCursosDisponiblesJson")

    '    For i As Integer = 0 To list.Count - 1
    '        If list(i).Item("vtc") = "I" And CInt(list(i).Item("vCic")) = ciclo Then
    '            If list(i).Item("chk") = True Then


    '                ' if (fnValidaSeleccionElectivoCicloChk(aData[i].vCic)) 

    '                sw = False
    '                Exit For

    '            End If


    '        End If
    '        'if (aData[i].electivo_cur == 'True' && parseInt(aData[i].vnel) > parseInt(aData[i].velap) && parseInt(aData[i].vCic) < parseInt(cicSel) && parseInt(aData[i].stt)==1) { // && sThisVal == "0" && ) {
    '    Next

    '    Return sw

    'End Function
    'Private Function fnBuscarData(ByVal buscar As Integer, ByVal campo As String) As String
    '    Try
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim r As String = ""

    '        For i As Integer = 0 To list.Count - 1
    '            If list(i).Item("codigo_cur") = buscar Then

    '                Select Case campo
    '                    Case "cupm"
    '                        r = list(i).Item("cup_Mat").ToString

    '                    Case "cic"
    '                        r = list(i).Item("vCic").ToString

    '                    Case "cred"
    '                        r = list(i).Item("vCred").ToString

    '                    Case "nel"
    '                        r = list(i).Item("vnel").ToString

    '                    Case "elap"
    '                        r = list(i).Item("velap").ToString

    '                    Case "elec"
    '                        r = list(i).Item("electivo_cur").ToString

    '                    Case "selC"
    '                        r = list(i).Item("selCurso").ToString

    '                    Case "vec"
    '                        r = list(i).Item("vvec").ToString

    '                    Case "tc"
    '                        r = list(i).Item("vtc").ToString

    '                    Case "nomC"
    '                        r = list(i).Item("nombre_Cur").ToString

    '                    Case "pc"
    '                        r = list(i).Item("vpc").ToString
    '                    Case "sIdi"
    '                        r = list(i).Item("sIdi")
    '                    Case Else
    '                        r = ""
    '                End Select
    '                Exit For
    '            Else

    '                r = ""
    '            End If
    '            r = ""

    '        Next

    '        Return r

    '    Catch ex As Exception
    '        Return ""
    '        Response.Write(ex.Message)
    '    End Try

    'End Function
    'Private Function fnBuscarDataDetMat(ByVal buscar As Integer, ByVal campo As String) As String
    '    Try
    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCursosDisponiblesJson")
    '        Dim r As String = ""

    '        For i As Integer = 0 To list.Count - 1
    '            If list(i).Item("cod_Dmat") = buscar Then

    '                Select Case campo
    '                    Case "ccur"
    '                        r = list(i).Item("codigo_cur").ToString

    '                    Case "cupm"
    '                        r = list(i).Item("cup_Mat").ToString

    '                    Case "cic"
    '                        r = list(i).Item("vCic").ToString

    '                    Case "cred"
    '                        r = list(i).Item("vCred").ToString

    '                    Case "nel"
    '                        r = list(i).Item("vnel").ToString

    '                    Case "elap"
    '                        r = list(i).Item("velap").ToString

    '                    Case "elec"
    '                        r = list(i).Item("electivo_cur").ToString

    '                    Case "selC"
    '                        r = list(i).Item("selCurso").ToString

    '                    Case "vec"
    '                        r = list(i).Item("vvec").ToString

    '                    Case "tc"
    '                        r = list(i).Item("vtc").ToString

    '                    Case "nomC"
    '                        r = list(i).Item("nombre_Cur").ToString

    '                    Case "pc"
    '                        r = list(i).Item("vpc").ToString

    '                    Case Else
    '                        r = ""
    '                End Select
    '                Exit For
    '            Else

    '                r = ""
    '            End If
    '            r = ""

    '        Next

    '        Return r

    '    Catch ex As Exception
    '        Return ""
    '        Response.Write(ex.Message)
    '    End Try

    'End Function
    'Function emailpass(ByVal email As String) As String
    '    Try


    '        Dim str1 As String = extraerCad(email, "@", 0)
    '        Dim str2 As String = extraerCad(email, "@", 1)
    '        Dim str3 As String = extraerCad(str2, ".", 0)
    '        Dim str4 As String = extraerCad(str2, ".", 1)
    '        Dim str5 As String = extraerCad(str2, ".", 2)
    '        Dim emailF As String = ""
    '        ' Response.Write(email & "<br>")
    '        If str5 <> "" Then
    '            emailF = fnReplacePass(str1.ToString, 2, 2, "*") & "@" & fnReplacePass(str3.ToString, 1, 0, "*") & "." & str4.ToString & "." & str5.ToString
    '        Else
    '            emailF = fnReplacePass(str1.ToString, 2, 2, "*") & "@" & fnReplacePass(str3.ToString, 1, 0, "*") & "." & str4.ToString

    '        End If

    '        'Response.Write(emailF & "<br>")
    '        Return emailF
    '    Catch ex As Exception
    '        Return ""
    '    End Try

    'End Function

    'Function fnReplacePass(ByVal CAD As String, ByVal L As Integer, ByVal R As Integer, Optional ByVal REPLACE As String = "*") As String
    '    Try


    '        Dim strlen As Integer = CAD.Length
    '        Dim textoL As String = Left(CAD, L)
    '        Dim textoR As String = Right(CAD, R)
    '        Dim concat As String = ""
    '        Dim textoF As String = ""
    '        Dim N As Integer = strlen - L - R

    '        For i As Integer = 0 To N - 1
    '            concat = concat & REPLACE
    '        Next
    '        'Response.Write(textoL & "<br>")
    '        'Response.Write(textoR & "<br>")
    '        textoF = textoL & concat & textoR

    '        Return textoF
    '    Catch ex As Exception
    '        Return ""
    '    End Try
    'End Function
    'Function extraerCad(ByVal CAD As String, ByVal LIM As String, ByVal INDICE As Integer) As String
    '    Try


    '        Dim TestArray() As String = Split(CAD, LIM)
    '        Return TestArray(INDICE)

    '    Catch ex As Exception
    '        Return ""
    '    End Try

    'End Function

    'Private Function fnValidaCursoInvitado(ByVal codigo_dma As String) As Boolean
    '    Dim swtime As Boolean = False
    '    Try

    '        Dim list As New List(Of Dictionary(Of String, Object))()
    '        list = Session("lstCRECU")
    '        For i As Integer = 0 To list.Count - 1
    '            If list(i).Item("cdma") = codigo_dma Then
    '                swtime = list(i).Item("time")
    '                Exit For
    '            End If
    '        Next

    '        Return swtime
    '    Catch ex As Exception
    '        Return swtime
    '    End Try


    'End Function
    'Private Function fnValidaCursoInvitadoUltimo(ByVal codigo_dma As String) As Boolean
    '    Dim swtime As Boolean = False

    '    Try
    '        If Session("codigo_test") = 2 Then
    '            Dim i As Integer = 0

    '            Dim list As New List(Of Dictionary(Of String, Object))()
    '            Dim dt As New DataTable
    '            Dim oeCursoProgramado As New eCursoProgramado
    '            Dim olCursoProgramado As New lCursoProgramado
    '            oeCursoProgramado.codigo_Alu = Session("Codigo_Alu")
    '            oeCursoProgramado.codigo_cac = Session("Codigo_Cac")


    '            dt = olCursoProgramado.ConsultarCursosRecuperacion(oeCursoProgramado)



    '            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '                For i = 0 To dt.Rows.Count - 1
    '                    If dt.Rows(i).Item("codigo_Dma").ToString = codigo_dma Then
    '                        If (dt.Rows(i).Item("minutosdif") >= 15) Then
    '                            swtime = True
    '                            Exit For
    '                        Else
    '                            swtime = False
    '                        End If
    '                    End If

    '                Next
    '            Else
    '                swtime = False
    '            End If


    '            dt = Nothing

    '        Else
    '            swtime = True
    '        End If

    '        Return swtime
    '    Catch ex As Exception
    '        Return swtime
    '    End Try


    'End Function

    ''Private Function fnValidaCursoInvitadoUltimo(ByVal codigo_dma As String) As Boolean
    ''    Dim swtime As Boolean = False

    ''    Try
    ''        Dim i As Integer = 0

    ''        Dim list As New List(Of Dictionary(Of String, Object))()
    ''        Dim dt As New DataTable
    ''        Dim oeCursoProgramado As New eCursoProgramado
    ''        Dim olCursoProgramado As New lCursoProgramado
    ''        oeCursoProgramado.codigo_Alu = Session("Codigo_Alu")
    ''        oeCursoProgramado.codigo_cac = Session("Codigo_Cac")

    ''        If Session("codigo_test") = 2 Then
    ''            dt = olCursoProgramado.ConsultarCursosRecuperacion(oeCursoProgramado)
    ''        Else
    ''            dt = olCursoProgramado.ConsultarCursosRecuperacionOtros(oeCursoProgramado)
    ''        End If

    ''        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    ''            For i = 0 To dt.Rows.Count - 1
    ''                If dt.Rows(i).Item("codigo_Dma").ToString = codigo_dma Then
    ''                    If (dt.Rows(i).Item("minutosdif") >= 15) Then
    ''                        swtime = True
    ''                        Exit For
    ''                    Else
    ''                        swtime = False
    ''                    End If
    ''                End If

    ''            Next
    ''        Else
    ''            swtime = False
    ''        End If


    ''        dt = Nothing

    ''        Return swtime
    ''    Catch ex As Exception
    ''        Return swtime
    ''    End Try


    ''End Function

End Class

