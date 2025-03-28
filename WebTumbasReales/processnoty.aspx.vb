Imports System.Web.Security
Imports System.Data
Imports cLogica
Imports System.Data.DataTable
Imports System.Collections.Generic
Imports System.Data.DataRow
Imports System.Data.DataColumn
Imports cEntidad

Imports System.IO
Imports System.Web.HttpRequest

Partial Class processnoty
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim JSONresult As String = ""
       
        If Me.Page.User.Identity.IsAuthenticated Then

            ' Response.Write("1")
            If Request("param0") = "lstNotyy" Then

                Dim i As Integer = 0
                Dim dtNoty As New DataTable
                Dim oeNoty As New eNotificacion
                Dim olNoty As New lNotificacion
                oeNoty.tipo = "1"
                oeNoty.codigo_alu = Session("codigo_Alu")
                dtNoty = olNoty.NotificacionCampusEstudiante(oeNoty)
                'Dim dict As New Dictionary(Of String, Object)()
                Dim list As New List(Of Dictionary(Of String, Object))()
                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                'list = dtCursos



                For i = 0 To dtNoty.Rows.Count - 1
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("codna", dtNoty.Rows(i).Item("codigo_notificacionAlu"))
                    'dict.Add("codna", dtNoty.Rows(i).Item("codigo_notificacionAlu"))
                    dict.Add("codn", dtNoty.Rows(i).Item("codigo_noti"))
                    dict.Add("alu", dtNoty.Rows(i).Item("codigo_alu"))
                    dict.Add("r", dtNoty.Rows(i).Item("leido"))
                    dict.Add("codp", dtNoty.Rows(i).Item("envio_codigo_per"))
                    dict.Add("fecha", CDate(dtNoty.Rows(i).Item("fecenvio")).ToString("dd/MM/yyyy hh:mm:ss tt"))
                    dict.Add("texto", dtNoty.Rows(i).Item("titulo"))
                    dict.Add("msj", dtNoty.Rows(i).Item("mensaje"))
                    dict.Add("ctg", dtNoty.Rows(i).Item("codigo_Tga"))

                    If dtNoty.Rows(i).Item("codigo_Tga") = 1 Then
                        dict.Add("hexagon", "hexagon danger")
                        dict.Add("icon", "ion-ios-home")

                    ElseIf dtNoty.Rows(i).Item("codigo_Tga") = 2 Then
                        dict.Add("hexagon", "hexagon warning")
                        dict.Add("icon", "ion-university")

                    ElseIf dtNoty.Rows(i).Item("codigo_Tga") = 3 Then
                        dict.Add("hexagon", "hexagon success")
                        dict.Add("icon", "ion-ios-book")
                    End If

                    list.Add(dict)

                Next


                JSONresult = serializer.Serialize(list)

            ElseIf Request("param0") = "lstDetNoty" Then
                Dim dtNoty As New DataTable
                Dim oeNoty As New eNotificacion
                Dim olNoty As New lNotificacion
                Dim dtNoty2 As New DataTable


                oeNoty.tipo = "2"

                oeNoty.codigo_notificacionAlu = CInt(Request("param2"))
                oeNoty.codigo_alu = Session("codigo_Alu")
                dtNoty = olNoty.NotificacionCampusEstudiante(oeNoty)
                'Dim dict As New Dictionary(Of String, Object)()
                Dim list As New List(Of Dictionary(Of String, Object))()
                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                'list = dtCursos


                If dtNoty.Rows.Count > 0 Then
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("codna", dtNoty.Rows(0).Item("codigo_notificacionAlu"))
                    dict.Add("desc", dtNoty.Rows(0).Item("descripcion"))
                    dict.Add("codn", dtNoty.Rows(0).Item("codigo_noti"))
                    dict.Add("alu", dtNoty.Rows(0).Item("codigo_alu"))
                    dict.Add("r", dtNoty.Rows(0).Item("leido"))
                    dict.Add("codp", dtNoty.Rows(0).Item("envio_codigo_per"))
                    dict.Add("fecha", CDate(dtNoty.Rows(0).Item("fecenvio")).ToString("dd/MM/yyyy hh:mm:ss tt"))
                    dict.Add("texto", dtNoty.Rows(0).Item("titulo"))
                    dict.Add("ctg", dtNoty.Rows(0).Item("codigo_Tga"))
                    dict.Add("imgFile", dtNoty.Rows(0).Item("imgadjunto").ToString())
                    dict.Add("imgFileUrl", "http://serverdev/campusvirtual/personal/GrupoAviso/upload/img/" & dtNoty.Rows(0).Item("imgnombre1").ToString & "-" & dtNoty.Rows(0).Item("imgadjunto").ToString)
                    dict.Add("imgDesc", dtNoty.Rows(0).Item("imgdescripcion").ToString())
                    dict.Add("file", dtNoty.Rows(0).Item("fileadjunto").ToString())
                    dict.Add("fileUrl", "http://serverdev/campusvirtual/personal/GrupoAviso/upload/file/" & dtNoty.Rows(0).Item("filenombre1").ToString & "-" & dtNoty.Rows(0).Item("fileadjunto").ToString)
                    dict.Add("fileDesc", dtNoty.Rows(0).Item("filedescripcion").ToString())


                    If dtNoty.Rows(0).Item("leido") = "0" Then
                        dtNoty2 = New DataTable
                        oeNoty = New eNotificacion
                        olNoty = New lNotificacion
                        oeNoty.codigo_notificacionAlu = dtNoty.Rows(0).Item("codigo_notificacionAlu")
                        dtNoty2 = olNoty.NotificacionLeido(oeNoty)
                        If dtNoty2 Is Nothing Then
                            dict.Add("msg", "r")
                        Else
                            dict.Add("msg", "")
                        End If

                    Else
                        dict.Add("msg", "")
                    End If
                    list.Add(dict)

                End If
                dtNoty = Nothing
                oeNoty = Nothing
                olNoty = Nothing
                dtNoty2 = Nothing

                JSONresult = serializer.Serialize(list)

            ElseIf Request("param0") = "infoAluDeuda" Then
                'If (Session("estadodeuda_alu") = 1) Then
                Dim oeAlumno As New eAlumno
                Dim olAlumno As New lAlumno
                Dim dt As New DataTable
                oeAlumno.codigoUniver_Alu = Session("codigoUniver_Alu")
                oeAlumno.param1 = "P"
                dt = olAlumno.infoDeudaAlumno(oeAlumno)

                Dim list As New List(Of Dictionary(Of String, Object))()
                Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                'dict.Add("r", AlumnoDeudaPersonalizado())
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("d_fecha", dt.Rows(i).Item("FECHA").ToString())
                    dict.Add("d_servicio", dt.Rows(i).Item("SERVICIO").ToString())
                    dict.Add("d_cargo", dt.Rows(i).Item("CARGO").ToString())
                    dict.Add("d_pagos", dt.Rows(i).Item("PAGOS").ToString())
                    dict.Add("d_saldos", dt.Rows(i).Item("SALDO").ToString())
                    dict.Add("d_documento", dt.Rows(i).Item("DOCUMENTO").ToString())
                    dict.Add("c_respons", dt.Rows(i).Item("CODIGO_RESP").ToString())
                    dict.Add("d_respons", dt.Rows(i).Item("RESPONSABLE").ToString())
                    dict.Add("d_estadodeu", dt.Rows(i).Item("estado_Deu").ToString())
                    dict.Add("d_observaciondeu", dt.Rows(i).Item("OBSERVACION").ToString())
                    dict.Add("d_tipo", dt.Rows(i).Item("Tipo").ToString())
                    dict.Add("d_moraSco", dt.Rows(i).Item("generaMora_Sco").ToString())
                    dict.Add("d_venceSco", dt.Rows(i).Item("fechaVencimiento_Sco").ToString())
                    dict.Add("c_codigodeu", dt.Rows(i).Item("codigo_Deu").ToString())
                    dict.Add("c_codigosco", dt.Rows(i).Item("codigo_Sco").ToString())
                    dict.Add("d_estado", dt.Rows(i).Item("Est").ToString())
                    dict.Add("d_esProgEspSco", dt.Rows(i).Item("esProgramaEspecial_Sco").ToString())
                    dict.Add("d_intereseSco", dt.Rows(i).Item("generainteres_Sco").ToString())
                    dict.Add("d_moradeu", dt.Rows(i).Item("MORA_DEU").ToString())
                    dict.Add("c_codigopod", dt.Rows(i).Item("codigo_pod").ToString())
                    list.Add(dict)
                Next
                JSONresult = serializer.Serialize(list)
                'End If
            End If
            '#002 FIN - JR
            Response.Write(JSONresult)
        End If

    End Sub

End Class
