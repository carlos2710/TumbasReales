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
Imports System.Diagnostics
Imports System.Xml
Imports System.Xml.Serialization
Imports cDatos
Partial Class processmuseo
    Inherits System.Web.UI.Page
    Private oeCatalogo As eCatalogo
    Private olCatalogo As lCatalogo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim JSONresult As String = ""

        If Me.Page.User.Identity.IsAuthenticated Then
            If Request("param0") = "gCatalogo1" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeCatologo.unidad_cat = Request("txtNroFicha").ToString()
                    oeCatologo.codregnac_cat = Request("txtCodRegNac").ToString()
                    oeCatologo.codpropietario_cat = Request("txtCodPropietario").ToString()
                    oeCatologo.codexcavacion_cat = Request("txtCodigoExcavacion").ToString()
                    oeCatologo.codreginc_cat = Request("txtRegINC").ToString()
                    oeCatologo.codinvinc_cat = Request("txtInvINVC").ToString()
                    oeCatologo.otrocodigos_cat = Request("txtOtrosCod").ToString()
                    oeCatologo.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeCatologo.usuarioreg = Session("dni")
                    oeCatologo.param1 = "1"
                    If (Request("cat").ToString() = "") Then
                        dt1 = olCatologo.registrarIdentificacionCodAdicionales(oeCatologo)
                    Else
                        oeCatologo.codpropietario_cat = fn.DecrytedString64(Request("cat").ToString())
                        dt1 = olCatologo.actualizarIdentificacionCodAdicionales(oeCatologo)
                    End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
            ElseIf Request("param0") = "regInventario" Then
                Try
                    Dim oeTbInventario As New etbInventario
                    Dim olTbInventario As New lTbInventario
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    'Inicio JAZ
                    oeTbInventario.cod_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    'Fin JAZ
                    oeTbInventario.Registro_nacional = Request("txtRegistroNac").ToString()
                    oeTbInventario.Codigo_propiet = Request("txtCodPropietario").ToString()
                    oeTbInventario.Otro_codigo = Request("txtOtrosCod").ToString()
                    oeTbInventario.Categoria = Request("txtCategoria").ToString()
                    oeTbInventario.Taxonomia = Request("txtTaxonomia").ToString()
                    oeTbInventario.Denominacion = Request("txtDenominacion").ToString()
                    oeTbInventario.Cultura = Request("txtCultura").ToString()
                    oeTbInventario.Periodo = Request("txtPeriodo").ToString()
                    oeTbInventario.Descripcion_identificacion = Request("txtDescripcion").ToString()
                    oeTbInventario.Tipo_material = Request("txtTipoMat").ToString()
                    oeTbInventario.Tecnicas = Request("txtTecnicas").ToString()
                    If String.IsNullOrEmpty(Request("txtAlto").ToString()) Then
                    Else
                        oeTbInventario.Alto = Double.Parse(Request("txtAlto"))
                    End If
                    If String.IsNullOrEmpty(Request("txtLargo").ToString()) Then
                    Else
                        oeTbInventario.Largo = Double.Parse(Request("txtLargo"))
                    End If
                    If String.IsNullOrEmpty(Request("txtAncho").ToString()) Then
                    Else
                        oeTbInventario.Ancho = Double.Parse(Request("txtAncho"))
                    End If
                    If String.IsNullOrEmpty(Request("txtDiamMax").ToString()) Then
                    Else
                        oeTbInventario.Diam_maximo = Double.Parse(Request("txtDiamMax"))
                    End If
                    If String.IsNullOrEmpty(Request("txtDiamMin").ToString()) Then
                    Else
                        oeTbInventario.Diam_min = Double.Parse(Request("txtDiamMin"))
                    End If
                    If String.IsNullOrEmpty(Request("txtPesoTecnico").ToString()) Then
                    Else
                        oeTbInventario.Peso = Double.Parse(Request("txtPesoTecnico"))
                    End If
                    oeTbInventario.Estado_integridad = Request("txtEstadoIntegridad").ToString()
                    If String.IsNullOrEmpty(Request("txtCantidadConservacion").ToString()) Then
                    Else
                        oeTbInventario.Cantidad = Integer.Parse(Request("txtCantidadConservacion"))
                    End If
                    oeTbInventario.Detalle_conservacion = Request("txtDetalleConservacion").ToString()
                    oeTbInventario.Procedencia = Request("txtProcedencia").ToString()
                    oeTbInventario.Region_origen = Request("txtRegion").ToString()
                    oeTbInventario.Sitio_origen = Request("txtSitio").ToString()
                    oeTbInventario.Sector_origen = Request("txtSectorOrigen").ToString()
                    oeTbInventario.Subsector_origen = Request("txtSubSectorOrigen").ToString()
                    oeTbInventario.Unidad_origen = Request("txtUnidadPozo").ToString()
                    oeTbInventario.Cuadrante_origen = Request("txtCuadrante").ToString()
                    oeTbInventario.Capa_origen = Request("txtCapaNivel").ToString()
                    oeTbInventario.Cuadricula_origen = Request("txtCuadriculaOrigen").ToString()
                    oeTbInventario.Contexto_origen = Request("txtContextoOrigen").ToString()
                    oeTbInventario.Coleccion_propiedad = Request("txtColeccion").ToString()
                    oeTbInventario.Adquisicion_propiedad = Request("txtModoAdquisicion").ToString()
                    oeTbInventario.Documento_propiedad = Request("txtDocumento").ToString()
                    If String.IsNullOrEmpty(Request("txtFechaPropiedad").ToString()) Then
                        oeTbInventario.Fecha_propiedad = "01/01/1999"
                    Else
                        oeTbInventario.Fecha_propiedad = Request("txtFechaPropiedad").ToString()
                    End If
                    oeTbInventario.Ubicacion = Request("txtUbicacion").ToString()
                    oeTbInventario.Area_ubicacion = Request("txtAreaSala").ToString()
                    oeTbInventario.Especifica_ubicacion = Request("txtUbicacionEspecifica").ToString()
                    oeTbInventario.Nivel_ubicacion = Request("txtNivelUbicacion").ToString()
                    oeTbInventario.Caja_ubicacion = Request("txtNroCajaUbicacion").ToString()
                    oeTbInventario.Bolsa_ubicacion = Request("txtNroBolsaUbicacion").ToString()
                    oeTbInventario.Excavado_adic = Request("txtExcavado").ToString()
                    oeTbInventario.Registrado_adic = Request("txtRegistrado").ToString()
                    If String.IsNullOrEmpty(Request("txtFechaAdicional").ToString()) Then
                        oeTbInventario.Fecha_adic = "01/01/1999"
                    Else
                        oeTbInventario.Fecha_adic = Request("txtFechaAdicional").ToString()
                    End If
                    oeTbInventario.Observacion_adic = Request("txtObservacionAdic").ToString()

                    dt1 = olTbInventario.RegistrarTbInventario(oeTbInventario)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)

                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
            ElseIf Request("param0") = "CargaMasivaInv" Then
                Try

                    Dim oeTbInventario As New etbInventario
                    Dim olTbInventario As New lTbInventario
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    oeTbInventario.cod_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeTbInventario.Registro_nacional = Request("txtRegistroNac").ToString()
                    oeTbInventario.Codigo_propiet = Request("txtCodPropietario").ToString()
                    oeTbInventario.Otro_codigo = Request("txtOtrosCod").ToString()
                    oeTbInventario.Categoria = Request("txtCategoria").ToString()
                    oeTbInventario.Taxonomia = Request("txtTaxonomia").ToString()
                    oeTbInventario.Denominacion = Request("txtDenominacion").ToString()
                    oeTbInventario.Cultura = Request("txtCultura").ToString()
                    oeTbInventario.Periodo = Request("txtPeriodo").ToString()
                    oeTbInventario.Descripcion_identificacion = Request("txtDescripcion").ToString()
                    oeTbInventario.Tipo_material = Request("txtTipoMat").ToString()
                    oeTbInventario.Tecnicas = Request("txtTecnicas").ToString()
                    If String.IsNullOrEmpty(Request("txtAlto")) Then
                    Else
                        oeTbInventario.Alto = Decimal.Parse(Request("txtAlto"))
                    End If
                    If String.IsNullOrEmpty(Request("txtLargo")) Then
                    Else
                        oeTbInventario.Largo = Decimal.Parse(Request("txtLargo"))
                    End If
                    If String.IsNullOrEmpty(Request("txtAncho")) Then
                    Else
                        oeTbInventario.Ancho = Decimal.Parse(Request("txtAncho"))
                    End If
                    If String.IsNullOrEmpty(Request("txtDiamMax")) Then
                    Else
                        oeTbInventario.Diam_maximo = Decimal.Parse(Request("txtDiamMax"))
                    End If
                    If String.IsNullOrEmpty(Request("txtDiamMin")) Then
                    Else
                        oeTbInventario.Diam_min = Decimal.Parse(Request("txtDiamMin"))
                    End If
                    If String.IsNullOrEmpty(Request("txtPesoTecnico")) Then
                    Else
                        oeTbInventario.Peso = Decimal.Parse(Request("txtPesoTecnico"))
                    End If
                    oeTbInventario.Estado_integridad = Request("txtEstadoIntegridad").ToString()
                    If String.IsNullOrEmpty(Request("txtCantidadConservacion")) Then
                    Else
                        oeTbInventario.Cantidad = Integer.Parse(Request("txtCantidadConservacion"))
                    End If
                    oeTbInventario.Detalle_conservacion = Request("txtDetalleConservacion").ToString()
                    oeTbInventario.Procedencia = Request("txtProcedencia").ToString()
                    oeTbInventario.Region_origen = Request("txtRegion").ToString()
                    oeTbInventario.Sitio_origen = Request("txtSitio").ToString()
                    oeTbInventario.Sector_origen = Request("txtSectorOrigen").ToString()
                    oeTbInventario.Subsector_origen = Request("txtSubSectorOrigen").ToString()
                    oeTbInventario.Unidad_origen = Request("txtUnidadPozo").ToString()
                    oeTbInventario.Cuadrante_origen = Request("txtCuadrante").ToString()
                    oeTbInventario.Capa_origen = Request("txtCapaNivel").ToString()
                    oeTbInventario.Cuadricula_origen = Request("txtCuadriculaOrigen").ToString()
                    oeTbInventario.Contexto_origen = Request("txtContextoOrigen").ToString()
                    oeTbInventario.Coleccion_propiedad = Request("txtColeccion").ToString()
                    oeTbInventario.Adquisicion_propiedad = Request("txtModoAdquisicion").ToString()
                    oeTbInventario.Documento_propiedad = Request("txtDocumento").ToString()
                    If String.IsNullOrEmpty(Request("txtFechaPropiedad")) Then
                        oeTbInventario.Fecha_propiedad = "01/01/01"
                    Else
                        oeTbInventario.Fecha_propiedad = Request("txtFechaPropiedad").ToString()
                    End If
                    oeTbInventario.Ubicacion = Request("txtUbicacion").ToString()
                    oeTbInventario.Area_ubicacion = Request("txtAreaSala").ToString()
                    oeTbInventario.Especifica_ubicacion = Request("txtUbicacionEspecifica").ToString()
                    oeTbInventario.Nivel_ubicacion = Request("txtNivelUbicacion").ToString()
                    oeTbInventario.Caja_ubicacion = Request("txtNroCajaUbicacion").ToString()
                    oeTbInventario.Bolsa_ubicacion = Request("txtNroBolsaUbicacion").ToString()
                    oeTbInventario.Excavado_adic = Request("txtExcavado").ToString()
                    oeTbInventario.Registrado_adic = Request("txtRegistrado").ToString()
                    If String.IsNullOrEmpty(Request("txtFechaAdicional")) Then
                        oeTbInventario.Fecha_adic = "01/01/01"
                    Else
                        oeTbInventario.Fecha_adic = Request("txtFechaAdicional").ToString()
                    End If
                    oeTbInventario.Observacion_adic = Request("txtObservacionAdic").ToString()

                    dt1 = olTbInventario.RegistrarTbInventario(oeTbInventario)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)

                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
                'INICIO JAZ
            ElseIf Request("param0") = "CargaMasivaEva" Then
                Try

                    Dim oeEvaluacion As New eEvaluacion
                    Dim olEvaluacion As New lEvaluacion
                    Dim fn As New lFunciones
                    Dim dt1, dt2, dt3, dt4, dt5 As New DataTable

                    oeEvaluacion.nroficha_con = Request("txtNroFichaE").ToString()
                    oeEvaluacion.codregnac_con = Request("txtCodRegNacE").ToString()
                    oeEvaluacion.codpropietario_con = Request("txtCodPropietarioE").ToString()
                    oeEvaluacion.codexcavacion_con = Request("txtCodigoExcavacionE").ToString()
                    oeEvaluacion.codrestauracion_con = Request("txtCodRestaurE").ToString()
                    oeEvaluacion.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeEvaluacion.usuarioreg = Session("dni")

                    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    oeEvaluacion.nroficha_con = dt1.Rows(0)("Code").ToString()
                    oeEvaluacion.sector_con = Request("txtSectorE").ToString()
                    oeEvaluacion.unidad_con = Request("txtUnidadE").ToString()
                    oeEvaluacion.capa_con = Request("txtCapaE").ToString()
                    oeEvaluacion.nivel_con = Request("txtNivelE").ToString()
                    oeEvaluacion.cuadricula_con = Request("txtCuadriculaE").ToString()
                    oeEvaluacion.param1 = Request("txtPlanoE").ToString()
                    oeEvaluacion.contexto_con = Request("txtContextoE").ToString()
                    oeEvaluacion.ubicontexto_con = Request("txtUbicContextoE").ToString()
                    oeEvaluacion.alturaobs_con = Request("txtAlturaObsE").ToString()
                    oeEvaluacion.otrosdatos_con = Request("txtOtrosDatosE").ToString()

                    dt2 = olEvaluacion.registrarEvaluacion2(oeEvaluacion)

                    oeEvaluacion.material_con = Request("txtMaterialE").ToString()
                    oeEvaluacion.denominacion_con = Request("txtDenominacionE").ToString()
                    oeEvaluacion.descripcion_con = Request("txtDescripcionE").ToString()
                    oeEvaluacion.alto_con = Integer.Parse(Request("txtAltoE").ToString())
                    oeEvaluacion.largo_con = Integer.Parse(Request("txtLargoE").ToString())
                    oeEvaluacion.ancho_con = Integer.Parse(Request("txtAnchoE").ToString())
                    oeEvaluacion.espesor_con = Integer.Parse(Request("txtEspesorE").ToString())
                    oeEvaluacion.diametromax_con = Integer.Parse(Request("txtDiamMaxE").ToString())
                    oeEvaluacion.diametromin_con = Integer.Parse(Request("txtDiamMinE").ToString())
                    oeEvaluacion.diametrobase_con = Integer.Parse(Request("txtDiamBaseE").ToString())
                    oeEvaluacion.peso_con = Integer.Parse(Request("txtPesoE").ToString())
                    oeEvaluacion.ubicinmueble_con = Request("txtUbicInmuebleE").ToString()
                    oeEvaluacion.nrocaja_con = Request("txtCajaE").ToString()
                    oeEvaluacion.nrobolsa_con = Request("txtBolsaE").ToString()
                    oeEvaluacion.integridadbien_con = Integer.Parse(Request("cboIntegridadE").ToString())
                    oeEvaluacion.conservacionbien_con = Integer.Parse(Request("cboConservacionE").ToString())
                    oeEvaluacion.detconservacion_con = Request("txtDetConservacionE").ToString()
                    oeEvaluacion.observaciones_con = Request("txtObservacionE").ToString()
                    oeEvaluacion.temperatura_con = Integer.Parse(Request("txtTemperaturaE").ToString())
                    oeEvaluacion.humedad_con = Request("txtHumedadE").ToString()
                    oeEvaluacion.manipulacion_con = Request("txtMinipulacionE").ToString()
                    oeEvaluacion.otros_con = Request("txtOtrosE").ToString()
                    oeEvaluacion.conservadorcargo_con = Request("txtConsCargoE").ToString()
                    oeEvaluacion.fecha_con = Request("txtFechaE").ToString()


                    dt3 = olEvaluacion.registrarEvaluacion3(oeEvaluacion)
                    dt4 = olEvaluacion.registrarEvaluacion4(oeEvaluacion)
                    dt5 = olEvaluacion.registrarEvaluacion5(oeEvaluacion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)

                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
            ElseIf Request("param0") = "CargaMasivaTra" Then
                Try

                    Dim oeTratamiento As New eTratamiento
                    Dim olTratamiento As New lTratamiento
                    Dim fn As New lFunciones
                    Dim dt1, dt2, dt3, dt4, dt5, dt6 As New DataTable

                    oeTratamiento.nroficha_tra = CInt(Val(Request("eval").ToString()))
                    oeTratamiento.codregnac_tra = Request("txtCodRegNacT").ToString()
                    oeTratamiento.codpropietario_tra = Request("txtCodPropietarioT").ToString()
                    oeTratamiento.codexcavacion_tra = Request("txtCodigoExcavacionT").ToString()
                    oeTratamiento.codrestauracion_tra = Request("txtCodRestaurT").ToString()
                    oeTratamiento.sector_tra = Request("txtSectorT").ToString()
                    oeTratamiento.unidad_tra = Request("txtUnidadT").ToString()
                    oeTratamiento.capa_tra = Request("txtCapaT").ToString()
                    oeTratamiento.nivel_tra = Request("txtNivelT").ToString()
                    oeTratamiento.cuadricula_tra = Request("txtCuadriculaT").ToString()
                    oeTratamiento.plano_tra = Request("txtPlanoT").ToString()
                    oeTratamiento.contexto_tra = Request("txtContextoT").ToString()
                    oeTratamiento.ubicontexto_tra = Request("txtUbicContextoT").ToString()
                    oeTratamiento.alturaobs_tra = Request("txtAlturaObsT").ToString()
                    oeTratamiento.otrosdatos_tra = Request("txtOtrosDatosT").ToString()
                    oeTratamiento.material_tra = Request("txtMaterialT").ToString()
                    oeTratamiento.denominacion_tra = Request("txtDenominacionT").ToString()
                    oeTratamiento.descripcion_tra = Request("txtDescripcionT").ToString()
                    oeTratamiento.largo_tra = CInt(Val(Request("txtLargoT").ToString()))
                    oeTratamiento.alto_tra = CInt(Val(Request("txtAltoT").ToString()))
                    oeTratamiento.ancho_tra = CInt(Val(Request("txtAnchoT").ToString()))
                    oeTratamiento.espesor_tra = CInt(Val(Request("txtEspesorT").ToString()))
                    oeTratamiento.diametromax_tra = CInt(Val(Request("txtDiamMaxT").ToString()))
                    oeTratamiento.diametromin_tra = CInt(Val(Request("txtDiamMinT").ToString()))
                    oeTratamiento.diametrobase_tra = CInt(Val(Request("txtDiamBaseT").ToString()))
                    oeTratamiento.pesoini_tra = CInt(Val(Request("txtPesoIniT").ToString()))
                    oeTratamiento.pesofin_tra = CInt(Val(Request("txtPesoFinT").ToString()))
                    oeTratamiento.ubicinmueble_tra = Request("txtUbicInmuebleT").ToString()
                    oeTratamiento.nrocaja_tra = Request("txtCajaT").ToString()
                    oeTratamiento.nrobolsa_tra = CInt(Val(Request("txtBolsaT").ToString()))
                    oeTratamiento.integridadbien_tra = CInt(Val(Request("cboIntegridadT").ToString()))
                    oeTratamiento.conservacionbien_tra = CInt(Val(Request("cboConservacionT").ToString()))
                    oeTratamiento.detconservacion_tra = Request("txtDetConservacionT").ToString()
                    oeTratamiento.intervenciones_tra = Request("txtIntervAntT").ToString()
                    If String.IsNullOrEmpty(Request("txtFechaIniT").ToString()) Then
                        oeTratamiento.fini_tra = "01/01/1999"
                    Else
                        oeTratamiento.fini_tra = Request("txtFechaIniT").ToString()
                    End If
                    If String.IsNullOrEmpty(Request("txtFechFinT").ToString()) Then
                        oeTratamiento.ffin_tra = "01/01/1999"
                    Else
                        oeTratamiento.ffin_tra = Request("txtFechFinT").ToString()
                    End If
                    oeTratamiento.dettratamiento_tra = Request("txtDetTratamientoT").ToString()
                    oeTratamiento.secadopost_tra = Request("txtSecadoT").ToString()
                    oeTratamiento.pegadopost_tra = Request("txtPegadoT2").ToString()
                    oeTratamiento.consolidacion_tra = Request("txtConsolidacionT").ToString()
                    oeTratamiento.reintegracion_tra = Request("txtReIntegracT").ToString()
                    oeTratamiento.otrospost_tra = Request("txtOtrosPostT").ToString()
                    If String.IsNullOrEmpty(Request("txtFechaIniProcT").ToString()) Then
                        oeTratamiento.finipost_tra = "01/01/1999"
                    Else
                        oeTratamiento.finipost_tra = Request("txtFechaIniProcT").ToString()
                    End If
                    If String.IsNullOrEmpty(Request("txtFechaFinProcT").ToString()) Then
                        oeTratamiento.ffinpost_tra = "01/01/1999"
                    Else
                        oeTratamiento.ffinpost_tra = Request("txtFechaFinProcT").ToString()
                    End If
                    oeTratamiento.temperatura_tra = CInt(Val(Request("txtTemperaturaT").ToString()))
                    oeTratamiento.humedad_tra = Request("txtHumedadT").ToString()
                    oeTratamiento.manipulacion_tra = Request("txtManipulacionT").ToString()
                    oeTratamiento.iluminacion_tra = Request("txtIluminacionT").ToString()
                    oeTratamiento.otrosrec_tra = Request("txtOtrosRecT").ToString()
                    oeTratamiento.materialrec_tra = Request("txtMaterialRecomendT").ToString()
                    oeTratamiento.observaciones_tra = Request("txtObservacionesT").ToString()
                    oeTratamiento.conservadorcargo_tra = Request("txtConservCargoT").ToString()
                    If String.IsNullOrEmpty(Request("txtFechaT").ToString()) Then
                        oeTratamiento.fecha_tra = "01/01/1999"
                    Else
                        oeTratamiento.fecha_tra = Request("txtFechaT").ToString()
                    End If
                    oeTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeTratamiento.usuarioreg = Session("dni")

                    dt1 = olTratamiento.registrarTratamiento(oeTratamiento)
                    dt2 = olTratamiento.registrarTratamiento2(oeTratamiento)
                    dt3 = olTratamiento.registrarTratamiento3(oeTratamiento)
                    dt4 = olTratamiento.registrarTratamiento4(oeTratamiento)
                    dt5 = olTratamiento.registrarTratamiento5(oeTratamiento)
                    'dt6 = olTratamiento.registrarTratamiento6(oeTratamiento)



                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)

                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
                'FIN JAZ
            ElseIf Request("param0") = "modInventario" Then
                Try
                    Dim oeTbInventario As New etbInventario
                    Dim olTbInventario As New lTbInventario
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    oeTbInventario.cod_inventario = Integer.Parse(Request("inv"))
                    oeTbInventario.Registro_nacional = Request("txtRegistroNac").ToString()
                    oeTbInventario.Codigo_propiet = Request("txtCodPropietario").ToString()
                    oeTbInventario.Otro_codigo = Request("txtOtrosCod").ToString()
                    oeTbInventario.Categoria = Request("txtCategoria").ToString()
                    oeTbInventario.Taxonomia = Request("txtTaxonomia").ToString()
                    oeTbInventario.Denominacion = Request("txtDenominacion").ToString()
                    oeTbInventario.Cultura = Request("txtCultura").ToString()
                    oeTbInventario.Periodo = Request("txtPeriodo").ToString()
                    oeTbInventario.Descripcion_identificacion = Request("txtDescripcion").ToString()
                    oeTbInventario.Tipo_material = Request("txtTipoMat").ToString()
                    oeTbInventario.Tecnicas = Request("txtTecnicas").ToString()
                    If String.IsNullOrEmpty(Request("txtAlto").ToString()) Then
                    Else
                        oeTbInventario.Alto = Double.Parse(Request("txtAlto"))
                    End If
                    If String.IsNullOrEmpty(Request("txtLargo").ToString()) Then
                    Else
                        oeTbInventario.Largo = Double.Parse(Request("txtLargo"))
                    End If
                    If String.IsNullOrEmpty(Request("txtAncho").ToString()) Then
                    Else
                        oeTbInventario.Ancho = Double.Parse(Request("txtAncho"))
                    End If
                    If String.IsNullOrEmpty(Request("txtDiamMax").ToString()) Then
                    Else
                        oeTbInventario.Diam_maximo = Double.Parse(Request("txtDiamMax"))
                    End If
                    If String.IsNullOrEmpty(Request("txtDiamMin").ToString()) Then
                    Else
                        oeTbInventario.Diam_min = Double.Parse(Request("txtDiamMin"))
                    End If
                    If String.IsNullOrEmpty(Request("txtPesoTecnico").ToString()) Then
                    Else
                        oeTbInventario.Peso = Double.Parse(Request("txtPesoTecnico"))
                    End If
                    oeTbInventario.Estado_integridad = Request("txtEstadoIntegridad").ToString()
                    If String.IsNullOrEmpty(Request("txtCantidadConservacion").ToString()) Then
                    Else
                        oeTbInventario.Cantidad = Integer.Parse(Request("txtCantidadConservacion"))
                    End If
                    oeTbInventario.Detalle_conservacion = Request("txtDetalleConservacion").ToString()
                    oeTbInventario.Procedencia = Request("txtProcedencia").ToString()
                    oeTbInventario.Region_origen = Request("txtRegion").ToString()
                    oeTbInventario.Sitio_origen = Request("txtSitio").ToString()
                    oeTbInventario.Sector_origen = Request("txtSectorOrigen").ToString()
                    oeTbInventario.Subsector_origen = Request("txtSubSectorOrigen").ToString()
                    oeTbInventario.Unidad_origen = Request("txtUnidadPozo").ToString()
                    oeTbInventario.Cuadrante_origen = Request("txtCuadrante").ToString()
                    oeTbInventario.Capa_origen = Request("txtCapaNivel").ToString()
                    oeTbInventario.Cuadricula_origen = Request("txtCuadriculaOrigen").ToString()
                    oeTbInventario.Contexto_origen = Request("txtContextoOrigen").ToString()
                    oeTbInventario.Coleccion_propiedad = Request("txtColeccion").ToString()
                    oeTbInventario.Adquisicion_propiedad = Request("txtModoAdquisicion").ToString()
                    oeTbInventario.Documento_propiedad = Request("txtDocumento").ToString()
                    If String.IsNullOrEmpty(Request("txtFechaPropiedad").ToString()) Then
                        oeTbInventario.Fecha_propiedad = "01/01/1999"
                    Else
                        oeTbInventario.Fecha_propiedad = Request("txtFechaPropiedad").ToString()
                    End If
                    oeTbInventario.Ubicacion = Request("txtUbicacion").ToString()
                    oeTbInventario.Area_ubicacion = Request("txtAreaSala").ToString()
                    oeTbInventario.Especifica_ubicacion = Request("txtUbicacionEspecifica").ToString()
                    oeTbInventario.Nivel_ubicacion = Request("txtNivelUbicacion").ToString()
                    oeTbInventario.Caja_ubicacion = Request("txtNroCajaUbicacion").ToString()
                    oeTbInventario.Bolsa_ubicacion = Request("txtNroBolsaUbicacion").ToString()
                    oeTbInventario.Excavado_adic = Request("txtExcavado").ToString()
                    oeTbInventario.Registrado_adic = Request("txtRegistrado").ToString()
                    If String.IsNullOrEmpty(Request("txtFechaAdicional").ToString()) Then
                        oeTbInventario.Fecha_adic = "01/01/1999"
                    Else
                        oeTbInventario.Fecha_adic = Request("txtFechaAdicional").ToString()
                    End If
                    oeTbInventario.Observacion_adic = Request("txtObservacionAdic").ToString()

                    dt1 = olTbInventario.ModificarTbInventario(oeTbInventario)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)

                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
            ElseIf Request("param0") = "gCatalogo3" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeCatologo.codpropietario_cat = fn.DecrytedString64(Request("cat").ToString())
                    oeCatologo.material_cat = Request("txtMaterial").ToString()
                    oeCatologo.tipo_cat = Request("txtTipo").ToString()
                    oeCatologo.denominacion_cat = Request("txtDenominacion").ToString()
                    oeCatologo.manufactura_cat = Request("txtManufactura").ToString()
                    oeCatologo.decoracion_cat = Request("txtDecoracion").ToString()
                    oeCatologo.descripcion_cat = Request("txtDescripcion").ToString()
                    oeCatologo.colores_cat = Request("txtColores").ToString()
                    oeCatologo.acabadosuperf_cat = Request("txtAcabado").ToString()
                    oeCatologo.representaciones_cat = Request("txtRepresentaciones").ToString()
                    oeCatologo.motivodecorativo_cat = Request("txtDecorativo").ToString()
                    oeCatologo.alto_cat = Request("txtAlto").ToString()
                    oeCatologo.largo_cat = Request("txtLargo").ToString()
                    oeCatologo.ancho_cat = Request("txtAncho").ToString()
                    oeCatologo.espesor_cat = Request("txtEspesor").ToString()
                    oeCatologo.diametromax_cat = Request("txtDiamMax").ToString()
                    oeCatologo.diametromin_cat = Request("txtDiamMin").ToString()
                    oeCatologo.diametrobase_cat = Request("txtDiamBase").ToString()
                    oeCatologo.peso_cat = Request("txtPeso").ToString()
                    oeCatologo.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeCatologo.usuarioreg = Session("dni")
                    dt1 = olCatologo.registrarIdentificacionCodAdicionales3(oeCatologo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gCatalogo2" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeCatologo.codpropietario_cat = fn.DecrytedString64(Request("cat").ToString())
                    oeCatologo.cultura_cat = Request("txtCultura").ToString()
                    oeCatologo.estilo_cat = Request("txtEstilo").ToString()
                    oeCatologo.periodo_cat = Request("cboPeriodo").ToString()
                    oeCatologo.cronologia_cat = Request("cboCronologia").ToString()
                    oeCatologo.areageografica_cat = Request("cboGeografica").ToString()
                    oeCatologo.origenclasif_cat = Request("cboClasificacion").ToString()
                    oeCatologo.nombreclasif_cat = Request("txtNombreClasif").ToString()
                    oeCatologo.region_cat = Request("txtRegion").ToString()
                    oeCatologo.valle_cat = Request("txtValle").ToString()
                    oeCatologo.margen_cat = Request("cboMargen").ToString()
                    oeCatologo.provieneexcav_cat = Request("cboExcavacion").ToString()
                    oeCatologo.sector_cat = Request("txtSector").ToString()
                    oeCatologo.unidad_cat = Request("txtUnidad").ToString()
                    oeCatologo.capa_cat = Request("txtCapa").ToString()
                    If (Request("txtNivel").ToString() = "") Then
                        oeCatologo.nivel_cat = 0
                    Else
                        oeCatologo.nivel_cat = Request("txtNivel").ToString()
                    End If

                    If (Request("txtCuadricula").ToString() = "") Then
                        oeCatologo.cuadricula_cat = 0
                    Else
                        oeCatologo.cuadricula_cat = Request("txtCuadricula").ToString()
                    End If

                    If (Request("txtPlano").ToString() = "") Then
                        oeCatologo.plano_cat = 0
                    Else
                        oeCatologo.plano_cat = Request("txtPlano").ToString()
                    End If

                    oeCatologo.contexto_cat = Request("txtContexto").ToString()
                    oeCatologo.ubicacioncontexto_cat = Request("txtUbicContexto").ToString()
                    oeCatologo.alturaabs_cat = Request("txtAlturaAbsoluta").ToString()
                    oeCatologo.otrosdatos_cat = Request("txtOtrosDatos").ToString()
                    oeCatologo.usuarioreg = Session("dni")
                    oeCatologo.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    dt1 = olCatologo.registrarIdentificacionCodAdicionales2(oeCatologo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gCatalogo4" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeCatologo.codpropietario_cat = fn.DecrytedString64(Request("cat").ToString())
                    oeCatologo.tipopropietario_cat = Request("cboTipoProp").ToString()
                    oeCatologo.propietario_cat = Request("txtNombreProp").ToString()
                    oeCatologo.tipocustodio_cat = Request("cbocustodio").ToString()
                    oeCatologo.nombrecustodio_cat = Request("txtNombreCustodio").ToString()
                    oeCatologo.adquisicion_cat = Request("cboAquisicion").ToString()
                    oeCatologo.referenciaadq_cat = Request("txtRefFormaAdq").ToString()
                    oeCatologo.direccioninmueble_cat = Request("txtDireccionI").ToString()
                    oeCatologo.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeCatologo.usuarioreg = Session("dni")
                    dt1 = olCatologo.registrarIdentificacionCodAdicionales4(oeCatologo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gCatalogo5" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeCatologo.codpropietario_cat = fn.DecrytedString64(Request("cat").ToString())
                    oeCatologo.nombreinmueble_cat = Request("txtNombreInmueble").ToString()
                    oeCatologo.ubicacionespecif_cat = Request("txtUbicacionInmueble").ToString()
                    oeCatologo.situacion_cat = Request("cboSituacion").ToString()
                    oeCatologo.pisovitrina_cat = Request("txtPisoVitrina").ToString()
                    oeCatologo.almacenanaquel_cat = Request("txtalmacenAnaquel").ToString()
                    oeCatologo.cajacontenedor_cat = Request("txtCajaContenedor").ToString()
                    oeCatologo.bolsa_cat = Request("txtBolsa").ToString()
                    oeCatologo.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeCatologo.usuarioreg = Session("dni")
                    dt1 = olCatologo.registrarIdentificacionCodAdicionales5(oeCatologo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gCatalogo6" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones

                    Dim codigo As String
                    codigo = Request("cat").ToString()

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "success")
                    dict.Add("msje", "Procesando archivos")
                    dict.Add("code", 1)
                    list.Add(dict)

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstEval" Then
                Try
                    Dim oeEvaluacion As New eEvaluacion
                    Dim olEvaluacion As New lEvaluacion
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeEvaluacion.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olEvaluacion.listarFiltroEvaluacion(oeEvaluacion)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("item_eval", dt1.Rows(i).Item("item").ToString())
                        dict.Add("nombre_eval", dt1.Rows(i).Item("value").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "gEvaluacion1" Then
                Try
                    Dim oeEvaluacion As New eEvaluacion
                    Dim olEvaluacion As New lEvaluacion
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeEvaluacion.nroficha_con = Request("txtNroFichaE").ToString()
                    oeEvaluacion.codregnac_con = Request("txtCodRegNacE").ToString()
                    oeEvaluacion.codpropietario_con = Request("txtCodPropietarioE").ToString()
                    oeEvaluacion.codexcavacion_con = Request("txtCodigoExcavacionE").ToString()
                    oeEvaluacion.codrestauracion_con = Request("txtCodRestaurE").ToString()
                    oeEvaluacion.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeEvaluacion.usuarioreg = Session("dni")

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gEvaluacion2" Then
                Try
                    Dim oeEvaluacion As New eEvaluacion
                    Dim olEvaluacion As New lEvaluacion
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    oeEvaluacion.sector_con = Request("txtSectorE").ToString()
                    oeEvaluacion.unidad_con = Request("txtUnidadE").ToString()
                    oeEvaluacion.capa_con = Request("txtCapaE").ToString()
                    oeEvaluacion.nivel_con = Request("txtNivelE").ToString()
                    oeEvaluacion.cuadricula_con = Request("txtCuadriculaE").ToString()
                    oeEvaluacion.param1 = Request("txtPlanoE").ToString()
                    oeEvaluacion.contexto_con = Request("txtContextoE").ToString()
                    oeEvaluacion.ubicontexto_con = Request("txtUbicContextoE").ToString()
                    oeEvaluacion.alturaobs_con = Request("txtAlturaObsE").ToString()
                    oeEvaluacion.otrosdatos_con = Request("txtOtrosDatosE").ToString()
                    oeEvaluacion.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeEvaluacion.usuarioreg = Session("dni")

                    oeEvaluacion.nroficha_con = Request("eval").ToString()
                    dt1 = olEvaluacion.registrarEvaluacion2(oeEvaluacion)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "gEvaluacion3" Then
                Try
                    Dim oeEvaluacion As New eEvaluacion
                    Dim olEvaluacion As New lEvaluacion
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    oeEvaluacion.material_con = Request("txtMaterialE").ToString()
                    oeEvaluacion.denominacion_con = Request("txtDenominacionE").ToString()
                    oeEvaluacion.descripcion_con = Request("txtDescripcionE").ToString()
                    oeEvaluacion.alto_con = Request("txtAltoE").ToString()
                    oeEvaluacion.largo_con = Request("txtLargoE").ToString()
                    oeEvaluacion.ancho_con = Request("txtAnchoE").ToString()
                    oeEvaluacion.espesor_con = Request("txtEspesorE").ToString()
                    oeEvaluacion.diametromax_con = Request("txtDiamMaxE").ToString()
                    oeEvaluacion.diametromin_con = Request("txtDiamMinE").ToString()
                    oeEvaluacion.diametrobase_con = Request("txtDiamBaseE").ToString()
                    oeEvaluacion.peso_con = Request("txtPesoE").ToString()
                    oeEvaluacion.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeEvaluacion.usuarioreg = Session("dni")

                    oeEvaluacion.nroficha_con = Request("eval").ToString()
                    dt1 = olEvaluacion.registrarEvaluacion3(oeEvaluacion)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gEvaluacion4" Then
                Try
                    Dim oeEvaluacion As New eEvaluacion
                    Dim olEvaluacion As New lEvaluacion
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    oeEvaluacion.ubicinmueble_con = Request("txtUbicInmuebleE").ToString()
                    oeEvaluacion.nrocaja_con = Request("txtCajaE").ToString()
                    oeEvaluacion.nrobolsa_con = Request("txtBolsaE").ToString()
                    oeEvaluacion.integridadbien_con = Request("cboIntegridadE").ToString()
                    oeEvaluacion.conservacionbien_con = Request("cboConservacionE").ToString()
                    oeEvaluacion.detconservacion_con = Request("txtDetConservacionE").ToString()
                    oeEvaluacion.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeEvaluacion.usuarioreg = Session("dni")

                    oeEvaluacion.nroficha_con = Request("eval").ToString()
                    dt1 = olEvaluacion.registrarEvaluacion4(oeEvaluacion)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gEvaluacion5" Then
                Try
                    Dim oeEvaluacion As New eEvaluacion
                    Dim olEvaluacion As New lEvaluacion
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    oeEvaluacion.observaciones_con = Request("txtObservacionE").ToString()
                    oeEvaluacion.temperatura_con = Request("txtTemperaturaE").ToString()
                    oeEvaluacion.humedad_con = Request("txtHumedadE").ToString()
                    oeEvaluacion.manipulacion_con = Request("txtMinipulacionE").ToString()
                    oeEvaluacion.otros_con = Request("txtOtrosE").ToString()
                    oeEvaluacion.conservadorcargo_con = Request("txtConsCargoE").ToString()
                    oeEvaluacion.fecha_con = Request("txtFechaE").ToString()
                    oeEvaluacion.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeEvaluacion.usuarioreg = Session("dni")

                    oeEvaluacion.nroficha_con = Request("eval").ToString()
                    dt1 = olEvaluacion.registrarEvaluacion5(oeEvaluacion)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "gTratamiento1" Then
                Try
                    Dim oeTratamiento As New eTratamiento
                    Dim olTratamiento As New lTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeTratamiento.nroficha_tra = Request("txtNroFichaT").ToString()
                    oeTratamiento.codregnac_tra = Request("txtCodRegNacT").ToString()
                    oeTratamiento.codpropietario_tra = Request("txtCodPropietarioT").ToString()
                    oeTratamiento.codexcavacion_tra = Request("txtCodigoExcavacionT").ToString()
                    oeTratamiento.codrestauracion_tra = Request("txtCodRestaurT").ToString()
                    oeTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeTratamiento.usuarioreg = Session("dni")

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olTratamiento.registrarTratamiento(oeTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gTratamiento2" Then
                Try
                    Dim oeTratamiento As New eTratamiento
                    Dim olTratamiento As New lTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeTratamiento.sector_tra = Request("txtSectorT").ToString()
                    oeTratamiento.unidad_tra = Request("txtUnidadT").ToString()
                    oeTratamiento.capa_tra = Request("txtCapaT").ToString()
                    oeTratamiento.nivel_tra = Request("txtNivelT").ToString()
                    oeTratamiento.cuadricula_tra = Request("txtCuadriculaT").ToString()
                    oeTratamiento.plano_tra = Request("txtPlanoT").ToString()
                    oeTratamiento.contexto_tra = Request("txtContextoT").ToString()
                    oeTratamiento.ubicontexto_tra = Request("txtUbicContextoT").ToString()
                    oeTratamiento.alturaobs_tra = Request("txtAlturaObsT").ToString()
                    oeTratamiento.otrosdatos_tra = Request("txtOtrosDatosT").ToString()
                    oeTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeTratamiento.usuarioreg = Session("dni")
                    oeTratamiento.nroficha_tra = Request("eval").ToString()


                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olTratamiento.registrarTratamiento2(oeTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gTratamiento3" Then
                Try
                    Dim oeTratamiento As New eTratamiento
                    Dim olTratamiento As New lTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeTratamiento.material_tra = Request("txtMaterialT").ToString()
                    oeTratamiento.denominacion_tra = Request("txtDenominacionT").ToString()
                    oeTratamiento.descripcion_tra = Request("txtDescripcionT").ToString()
                    oeTratamiento.alto_tra = Request("txtAltoT").ToString()
                    oeTratamiento.largo_tra = Request("txtLargoT").ToString()
                    oeTratamiento.ancho_tra = Request("txtAnchoT").ToString()
                    oeTratamiento.espesor_tra = Request("txtEspesorT").ToString()
                    oeTratamiento.diametromax_tra = Request("txtDiamMaxT").ToString()
                    oeTratamiento.diametromin_tra = Request("txtDiamMinT").ToString()
                    oeTratamiento.diametrobase_tra = Request("txtDiamBaseT").ToString()
                    oeTratamiento.pesoini_tra = Request("txtPesoIniT").ToString()
                    oeTratamiento.pesofin_tra = Request("txtPesoFinT").ToString()
                    oeTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeTratamiento.usuarioreg = Session("dni")
                    oeTratamiento.nroficha_tra = Request("eval").ToString()


                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olTratamiento.registrarTratamiento3(oeTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gTratamiento4" Then
                Try
                    Dim oeTratamiento As New eTratamiento
                    Dim olTratamiento As New lTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeTratamiento.ubicinmueble_tra = Request("txtUbicInmuebleT").ToString()
                    oeTratamiento.nrocaja_tra = Request("txtCajaT").ToString()
                    oeTratamiento.nrobolsa_tra = Request("txtBolsaT").ToString()
                    oeTratamiento.integridadbien_tra = Request("cboIntegridadT").ToString()
                    oeTratamiento.conservacionbien_tra = Request("cboConservacionT").ToString()
                    oeTratamiento.detconservacion_tra = Request("txtDetConservacionT").ToString()
                    oeTratamiento.intervenciones_tra = Request("txtIntervAntT").ToString()
                    oeTratamiento.fini_tra = Request("txtFechaIniT").ToString()
                    oeTratamiento.ffin_tra = Request("txtFechFinT").ToString()
                    oeTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeTratamiento.usuarioreg = Session("dni")
                    oeTratamiento.nroficha_tra = Request("eval").ToString()


                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olTratamiento.registrarTratamiento4(oeTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gTratamiento5" Then
                Try
                    Dim oeTratamiento As New eTratamiento
                    Dim olTratamiento As New lTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeTratamiento.dettratamiento_tra = Request("txtDetTratamientoT").ToString()
                    oeTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeTratamiento.usuarioreg = Session("dni")
                    oeTratamiento.nroficha_tra = Request("eval").ToString()


                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olTratamiento.registrarTratamiento5(oeTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gTratamiento6" Then
                Try
                    Dim oeTratamiento As New eTratamiento
                    Dim olTratamiento As New lTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeTratamiento.secadopost_tra = Request("txtSecadoT").ToString()
                    oeTratamiento.pegado_tra = Request("txtPegadoT").ToString()
                    oeTratamiento.consolidacion_tra = Request("txtConsolidacionT").ToString()
                    oeTratamiento.reintegracion_tra = Request("txtReIntegracT").ToString()
                    oeTratamiento.otrosdatos_tra = Request("txtOtrosPostT").ToString()
                    oeTratamiento.finitrat_tra = Request("txtFechaIniProcT").ToString()
                    oeTratamiento.ffintrat_tra = Request("txtFechaFinProcT").ToString()
                    oeTratamiento.temperatura_tra = Request("txtTemperaturaT").ToString()
                    oeTratamiento.humedad_tra = Request("txtHumedadT").ToString()
                    oeTratamiento.manipulacion_tra = Request("txtManipulacionT").ToString()
                    oeTratamiento.iluminacion_tra = Request("txtIluminacionT").ToString()
                    oeTratamiento.otrosrec_tra = Request("txtOtrosRecT").ToString()
                    oeTratamiento.materialrec_tra = Request("txtMaterialRecomendT").ToString()
                    oeTratamiento.observaciones_tra = Request("txtObservacionesT").ToString()
                    oeTratamiento.conservadorcargo_tra = Request("txtConservCargoT").ToString()
                    oeTratamiento.fecha_tra = Request("txtFechaT").ToString()
                    oeTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeTratamiento.usuarioreg = Session("dni")
                    oeTratamiento.nroficha_tra = Request("eval").ToString()


                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olTratamiento.registrarTratamiento6(oeTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gTratamiento77" Then
                Try
                    Dim oeTratamiento As New eTratamiento
                    Dim olTratamiento As New lTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeTratamiento.secadopost_tra = Request("txtSecadoT").ToString()
                    oeTratamiento.pegado_tra = Request("txtPegadoT").ToString()
                    oeTratamiento.consolidacion_tra = Request("txtConsolidacionT").ToString()
                    oeTratamiento.reintegracion_tra = Request("txtReIntegracT").ToString()
                    oeTratamiento.otrosdatos_tra = Request("txtOtrosPostT").ToString()
                    oeTratamiento.finitrat_tra = Request("txtFechaIniProcT").ToString()
                    oeTratamiento.ffintrat_tra = Request("txtFechaFinProcT").ToString()
                    oeTratamiento.temperatura_tra = Request("txtTemperaturaT").ToString()
                    oeTratamiento.humedad_tra = Request("txtHumedadT").ToString()
                    oeTratamiento.manipulacion_tra = Request("txtManipulacionT").ToString()
                    oeTratamiento.iluminacion_tra = Request("txtIluminacionT").ToString()
                    oeTratamiento.otrosrec_tra = Request("txtOtrosRecT").ToString()
                    oeTratamiento.materialrec_tra = Request("txtMaterialRecomendT").ToString()
                    oeTratamiento.observaciones_tra = Request("txtObservacionesT").ToString()
                    oeTratamiento.conservadorcargo_tra = Request("txtConservCargoT").ToString()
                    oeTratamiento.fecha_tra = Request("txtFechaT").ToString()
                    oeTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeTratamiento.usuarioreg = Session("dni")
                    oeTratamiento.nroficha_tra = Request("eval").ToString()


                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olTratamiento.registrarTratamiento6(oeTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gTratamientoPT1" Then
                Try
                    Dim oePostTratamiento As New ePostTratamiento
                    Dim olPostTratamiento As New lPostTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oePostTratamiento.nroficha_ptr = Request("txtNroFichaPT").ToString()
                    oePostTratamiento.codregnac_ptr = Request("txtCodRegNacPT").ToString()
                    oePostTratamiento.codpropietario_ptr = Request("txtCodPropietarioPT").ToString()
                    oePostTratamiento.codexcavacion_ptr = Request("txtCodigoExcavacionPT").ToString()
                    oePostTratamiento.codrestauracion_ptr = Request("txtCodRestaurPT").ToString()
                    oePostTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oePostTratamiento.usuarioreg = Session("dni")
                    oePostTratamiento.nroficha_ptr = Request("eval").ToString()

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olPostTratamiento.registrarPostTratamiento(oePostTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gTratamientoPT2" Then
                Try
                    Dim oePostTratamiento As New ePostTratamiento
                    Dim olPostTratamiento As New lPostTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    'oePostTratamiento.nroficha_ptr = Request("txtNroFichaPT").ToString()
                    oePostTratamiento.sector_ptr = Request("txtSectorPT").ToString()
                    oePostTratamiento.unidad_ptr = Request("txtUnidadPT").ToString()
                    oePostTratamiento.capa_ptr = Request("txtCapaPT").ToString()
                    oePostTratamiento.cuadricula_ptr = Request("txtCuadriculaPT").ToString()
                    oePostTratamiento.plano_ptr = Request("txtPlanoPT").ToString()
                    oePostTratamiento.contexto_ptr = Request("txtContextoPT").ToString()
                    oePostTratamiento.ubicontexto_ptr = Request("txtUbicContextoPT").ToString()
                    oePostTratamiento.alturaobs_ptr = Request("txtAlturaObsPT").ToString()
                    oePostTratamiento.otrosdatos_ptr = Request("txtOtrosDatosPT").ToString()
                    oePostTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oePostTratamiento.usuarioreg = Session("dni")
                    oePostTratamiento.nroficha_ptr = Request("eval").ToString()

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olPostTratamiento.registrarPostTratamiento2(oePostTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "gTratamientoPT3" Then
                Try
                    Dim oePostTratamiento As New ePostTratamiento
                    Dim olPostTratamiento As New lPostTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oePostTratamiento.material_ptr = Request("txtMaterialPT").ToString()
                    oePostTratamiento.denominacion_ptr = Request("txtDenominacionPT").ToString()
                    oePostTratamiento.descripcion_ptr = Request("txtDescripcionPT").ToString()
                    oePostTratamiento.alto_ptr = Request("txtAltoPT").ToString()
                    oePostTratamiento.largo_ptr = Request("txtLargoPT").ToString()
                    oePostTratamiento.ancho_ptr = Request("txtAnchoPT").ToString()
                    oePostTratamiento.espesor_ptr = Request("txtEspesorPT").ToString()
                    oePostTratamiento.diametromax_ptr = Request("txtDiamMaxPT").ToString()
                    oePostTratamiento.diametromin_ptr = Request("txtDiamMinPT").ToString()
                    oePostTratamiento.diametrobase_ptr = Request("txtDiamBasePT").ToString()
                    oePostTratamiento.peso_ptr = Request("txtPesoPT").ToString()
                    oePostTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oePostTratamiento.usuarioreg = Session("dni")
                    oePostTratamiento.nroficha_ptr = Request("eval").ToString()

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olPostTratamiento.registrarPostTratamiento3(oePostTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gTratamientoPT4" Then
                Try
                    Dim oePostTratamiento As New ePostTratamiento
                    Dim olPostTratamiento As New lPostTratamiento
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    oePostTratamiento.ubicinmueble_ptr = Request("txtUbicInmueblePT").ToString()
                    oePostTratamiento.nrocaja_ptr = Request("txtCajaPT").ToString()
                    oePostTratamiento.nrobolsa_ptr = Request("txtBolsaPT").ToString()
                    oePostTratamiento.problematica_ptr = Request("txtProblemPT").ToString()
                    oePostTratamiento.varicacion_ptr = Request("txtVariacPT").ToString()
                    oePostTratamiento.reacciones_ptr = Request("txtReaccionesPT").ToString()
                    oePostTratamiento.presentaafec_ptr = Request("txtPresAfectPT").ToString()
                    oePostTratamiento.tipoafec_ptr = Request("txtTipoAfecPT").ToString()
                    oePostTratamiento.causaafec_ptr = Request("txtCausaAfecPT").ToString()
                    oePostTratamiento.recomendaciones_ptr = Request("txtRecomenPT").ToString()
                    oePostTratamiento.conservadorcargo_ptr = Request("txtConseCargoPT").ToString()
                    oePostTratamiento.fecha_ptr = Request("txtFechaPT").ToString()
                    oePostTratamiento.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oePostTratamiento.usuarioreg = Session("dni")
                    oePostTratamiento.nroficha_ptr = Request("eval").ToString()

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olPostTratamiento.registrarPostTratamiento4(oePostTratamiento)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gAlmacen1" Then
                Try
                    Dim oeAlmacenes As New eAlmacenes
                    Dim olAlmacenes As New lAlmacenes
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeAlmacenes.nroficha_alm = Request("txtNroFichaA").ToString()
                    oeAlmacenes.ambmonitoreo_alm = Request("txtAmbMonitoreoA").ToString()
                    oeAlmacenes.area_alm = Request("txtAreaA").ToString()
                    oeAlmacenes.tipoestruct_alm = Request("txtTipoEstrA").ToString()
                    oeAlmacenes.ventanas_alm = Request("txtVentanasA").ToString()
                    oeAlmacenes.tipoluz_alm = Request("txtTipoLuzA").ToString()
                    oeAlmacenes.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeAlmacenes.usuarioreg = Session("dni")
                    oeAlmacenes.nroficha_alm = Request("eval").ToString()

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olAlmacenes.registrarAlmacenes(oeAlmacenes)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gAlmacen2" Then
                Try
                    Dim oeAlmacenes As New eAlmacenes
                    Dim olAlmacenes As New lAlmacenes
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeAlmacenes.tipoaa_alm = Request("txtTipoAireA").ToString()
                    oeAlmacenes.cantidadaa_alm = Request("txtCantAireA").ToString()
                    oeAlmacenes.tipoex_alm = Request("txtTipoExtA").ToString()
                    oeAlmacenes.cantidadex_alm = Request("txtCantExtA").ToString()
                    oeAlmacenes.cantthermo_alm = Request("txtCantThermA").ToString()
                    oeAlmacenes.cantestantes_alm = Request("txtCantEstA").ToString()
                    oeAlmacenes.nivelesestantes_alm = Request("txtNivelEstA").ToString()
                    oeAlmacenes.cajasplast_alm = Request("ttxCajaPlaA").ToString()
                    oeAlmacenes.cajascarton_alm = Request("txtCajaCartonA").ToString()
                    oeAlmacenes.cajasmadera_alm = Request("txtCajaMadA").ToString()
                    oeAlmacenes.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeAlmacenes.usuarioreg = Session("dni")
                    oeAlmacenes.nroficha_alm = Request("eval").ToString()

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olAlmacenes.registrarAlmacenes2(oeAlmacenes)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gAlmacen3" Then
                Try
                    Dim oeAlmacenes As New eAlmacenes
                    Dim olAlmacenes As New lAlmacenes
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeAlmacenes.coleccion_alm = Request("txtColeccionA").ToString()
                    oeAlmacenes.material_alm = Request("txtMaterialA").ToString()
                    oeAlmacenes.otros_alm = Request("txtOtrosA").ToString()
                    oeAlmacenes.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeAlmacenes.usuarioreg = Session("dni")
                    oeAlmacenes.nroficha_alm = Request("eval").ToString()

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olAlmacenes.registrarAlmacenes3(oeAlmacenes)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gAlmacen4" Then
                Try
                    Dim oeAlmacenes As New eAlmacenes
                    Dim olAlmacenes As New lAlmacenes
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeAlmacenes.fecha_alm = Request("txtFechaA").ToString()
                    oeAlmacenes.hringresoa_alm = Request("txtHraIngAA").ToString()
                    oeAlmacenes.hrsalidaa_alm = Request("txtHraSalAA").ToString()
                    oeAlmacenes.primeraTa_alm = Request("txtPriTaCA").ToString()
                    oeAlmacenes.segundaTa_alm = Request("txtSegTaCA").ToString()
                    oeAlmacenes.primeraHa_alm = Request("txtPriHa").ToString()
                    oeAlmacenes.segundaHa_alm = Request("txtSegundaHa").ToString()
                    oeAlmacenes.hringresop_alm = Request("txtHraIngPA").ToString()
                    oeAlmacenes.hrsalidap_alm = Request("txtHraSalPA").ToString()
                    oeAlmacenes.primeraTp_alm = Request("txtPriTpCA").ToString()
                    oeAlmacenes.segundaTp_alm = Request("txtSegTpCA").ToString()
                    oeAlmacenes.primeraHp_alm = Request("txtPrimeraHp").ToString()
                    oeAlmacenes.segundaHp_alm = Request("txtSegundaHp").ToString()
                    oeAlmacenes.observaciones_alm = Request("txtObsA").ToString()
                    'Inicio JAZ
                    oeAlmacenes.conservadorcargo_alm = Request("txtConservCargoA").ToString()
                    'Fin JAZ
                    oeAlmacenes.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeAlmacenes.usuarioreg = Session("dni")
                    oeAlmacenes.nroficha_alm = Request("eval").ToString()

                    'If (Request("eval").ToString() = "") Then
                    '    'oeEvaluacion.nroficha_con = 0
                    '    dt1 = olEvaluacion.registrarEvaluacion(oeEvaluacion)
                    'Else
                    dt1 = olAlmacenes.registrarAlmacenes4(oeAlmacenes)
                    'End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstAnioInvestig" Then
                Try
                    Dim oeInvestMuebles As New eInvestMuebles
                    Dim olinvestMuebles As New linvestMuebles
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    dt1 = olinvestMuebles.listaAnioInvest(oeInvestMuebles)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("nombre_anio", dt1.Rows(i).Item("anio_mue").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstColeccionInvestig" Then
                Try
                    Dim oeInvestMuebles As New eInvestMuebles
                    Dim olinvestMuebles As New linvestMuebles
                    Dim fn As New lFunciones
                    Dim dt As New DataTable

                    dt = olinvestMuebles.listaColeccionesInvest(oeInvestMuebles)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    Dim sele As String = "0"
                    For i As Integer = 0 To dt.Rows.Count
                        Dim dict As New Dictionary(Of String, Object)()
                        If (sele = "0") Then
                            dict.Add("valor", 0)
                            dict.Add("descripcion", "-- Seleccione --")
                            dict.Add("selected", "selected")
                            sele = "1"
                        Else
                            dict.Add("valor", dt.Rows(i - 1).Item("id_dgc").ToString())
                            dict.Add("descripcion", dt.Rows(i - 1).Item("descripcion_dgc").ToString())
                            dict.Add("selected", "")
                        End If
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "gMuebles1" Then
                Try
                    Dim oeInvestMuebles As New eInvestMuebles
                    Dim olinvestMuebles As New linvestMuebles
                    Dim OeArchivos As New eArchivoCompartido
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeInvestMuebles.anio_mue = Request("txtAnio").ToString()
                    oeInvestMuebles.coleccion_mue = Request("cboColeccion").ToString()
                    oeInvestMuebles.tipoarchivo_mue = Request("cboTipoArchivo").ToString()

                    oeInvestMuebles.usuarioreg = Session("dni")
                    OeArchivos.NombreArchivo = Request("param1").ToString()
                    dt1 = olinvestMuebles.registrarMuebles(oeInvestMuebles, OeArchivos)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "SurbirArchivoMueble" Then
                Try
                    Dim fn As New lFunciones
                    Dim post As HttpPostedFile = HttpContext.Current.Request.Files("ArchivoASubir")
                    Dim codigo As String = fn.DecrytedString64(Request("codigo").ToString())
                    Dim tipo As String = Request("tipo")
                    Dim NroRend As String = 0

                    Dim Fecha As String = Date.Now.ToString("dd/MM/yyyy")
                    Dim Usuario As String = Session("dni")
                    Dim Input(post.ContentLength) As Byte

                    If tipo = "MUEBLE" Then
                        NroRend = 10
                    End If
                    If tipo = "ARQUE" Then
                        NroRend = 11
                    End If
                    If tipo = "EXCAV" Then
                        NroRend = 12
                    End If
                    If tipo = "AFECT" Then
                        NroRend = 13
                    End If

                    Dim b As New BinaryReader(post.InputStream)
                    Dim binData As Byte() = b.ReadBytes(post.InputStream.Length)
                    Dim base64 = System.Convert.ToBase64String(binData)
                    Dim wsCloud As New ClsArchivosCompartidos
                    Dim list As New Dictionary(Of String, String)
                    '  Dim list As New List(Of Dictionary(Of String, String))()
                    list.Add("Fecha", Fecha)
                    list.Add("Extencion", System.IO.Path.GetExtension(post.FileName))
                    list.Add("Nombre", System.IO.Path.GetFileName(post.FileName))
                    list.Add("TransaccionId", codigo)
                    list.Add("TablaId", "1")
                    list.Add("NroOperacion", NroRend)
                    list.Add("Archivo", System.Convert.ToBase64String(binData, 0, binData.Length))
                    list.Add("Usuario", Usuario)
                    list.Add("Equipo", "")
                    list.Add("Ip", "")
                    list.Add("param8", Usuario)
                    Dim envelope As String = wsCloud.SoapEnvelope(list)
                    'Dim result As String = wsCloud.PeticionRequestSoap("http://localhost/SharedFilesService/SharedFiles.asmx", envelope, "http://usat.edu.pe/UploadFile", Usuario)
                    Dim result As String = wsCloud.PeticionRequestSoap("http://localhost/SharedFilesService/SharedFiles.asmx", envelope, "http://usat.edu.pe/UploadFile", Usuario)

                    Dim tb As New Data.DataTable
                    Dim oeAlumno As New eAlumno
                    Dim olAlumno As New lAlumno
                    Dim dt As New DataTable

                    oeAlumno.param1 = 1
                    oeAlumno.param2 = codigo
                    oeAlumno.param3 = NroRend

                    'dt = olAlumno.ActualizarArchivoCompartivo(oeAlumno)

                Catch ex As Exception
                    Dim Data1 As New Dictionary(Of String, Object)()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Data1.Add("rpta", "1 - LIST")
                    Data1.Add("msje", ex.Message)
                    list.Add(Data1)
                    JSONresult = serializer.Serialize(list)
                    Response.Write(JSONresult)
                End Try


            ElseIf Request("param0") = "ListarMuebles" Then
                Try
                    Dim oeInvestMuebles As New eInvestMuebles
                    Dim olinvestMuebles As New linvestMuebles
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    dt1 = olinvestMuebles.listarMuebles(oeInvestMuebles)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo_mue", dt1.Rows(i).Item("codigo_mue").ToString())
                        dict.Add("anio_mue", dt1.Rows(i).Item("anio_mue").ToString())
                        dict.Add("coleccion_mue", dt1.Rows(i).Item("coleccion_mue").ToString())
                        dict.Add("tipoarchivo_mue", dt1.Rows(i).Item("tipoarchivo_mue").ToString())
                        dict.Add("archivo", fn.EncrytedString64(dt1.Rows(i).Item("archivo").ToString()))

                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "lstSitioArqInvestig" Then
                Try
                    Dim oeSitioArqueI As New eSitioArqueI
                    Dim olSitioArqueI As New lSitioArqueI
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    dt1 = olSitioArqueI.listaSitioArq(oeSitioArqueI)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("nombre_sitio", dt1.Rows(i).Item("sitio_arq").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gInmuebles1" Then
                Try
                    Dim oeSitioArqueI As New eSitioArqueI
                    Dim olSitioArqueI As New lSitioArqueI
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeSitioArqueI.sitio_arq = Request("txtSitio").ToString()
                    oeSitioArqueI.tipoarchivo_arqe = Request("cbTipoArq").ToString()

                    oeSitioArqueI.usuarioreg = Session("dni")


                    dt1 = olSitioArqueI.registrarInmuebles1(oeSitioArqueI)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "ListarInmuebles1" Then
                Try
                    Dim oeSitioArqueI As New eSitioArqueI
                    Dim olSitioArqueI As New lSitioArqueI
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    dt1 = olSitioArqueI.listarInmuebles1(oeSitioArqueI)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo_arq", dt1.Rows(i).Item("codigo_arq").ToString())
                        dict.Add("sitio_arq", dt1.Rows(i).Item("sitio_arq").ToString())
                        dict.Add("tipoarchivo_arq", dt1.Rows(i).Item("tipoarchivo_arq").ToString())
                        dict.Add("archivo", fn.EncrytedString64(dt1.Rows(i).Item("archivo").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gInmuebles1" Then
                Try
                    Dim oeSitioArqueI As New eSitioArqueI
                    Dim olSitioArqueI As New lSitioArqueI
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeSitioArqueI.sitio_arq = Request("txtSitio").ToString()
                    oeSitioArqueI.tipoarchivo_arqe = Request("cbTipoArq").ToString()

                    oeSitioArqueI.usuarioreg = Session("dni")


                    dt1 = olSitioArqueI.registrarInmuebles1(oeSitioArqueI)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "ListarInmuebles1" Then
                Try
                    Dim oeSitioArqueI As New eSitioArqueI
                    Dim olSitioArqueI As New lSitioArqueI
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    dt1 = olSitioArqueI.listarInmuebles1(oeSitioArqueI)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo_arq", dt1.Rows(i).Item("codigo_arq").ToString())
                        dict.Add("sitio_arq", dt1.Rows(i).Item("sitio_arq").ToString())
                        dict.Add("tipoarchivo_arq", dt1.Rows(i).Item("tipoarchivo_arq").ToString())
                        dict.Add("archivo", fn.EncrytedString64(dt1.Rows(i).Item("archivo").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gInmuebles2" Then
                Try
                    Dim oeExcavacion As New eExcavacion
                    Dim olExcavacion As New lExcavacion
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeExcavacion.anio_exc = Request("AnioExca").ToString()
                    oeExcavacion.proyecto_exc = Request("ProyectoExca").ToString()
                    oeExcavacion.tipoarchivo_exc = Request("cbTipoExca").ToString()

                    oeExcavacion.usuarioreg = Session("dni")


                    dt1 = olExcavacion.registrarInmuebles2(oeExcavacion)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "ListarInmuebles2" Then
                Try
                    Dim oeExcavacion As New eExcavacion
                    Dim olExcavacion As New lExcavacion
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    dt1 = olExcavacion.listarInmuebles2(oeExcavacion)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo_exc", dt1.Rows(i).Item("codigo_exc").ToString())
                        dict.Add("anio_exc", dt1.Rows(i).Item("anio_exc").ToString())
                        dict.Add("proyecto_exc", dt1.Rows(i).Item("proyecto_exc").ToString())
                        dict.Add("tipoarchivo_exc", dt1.Rows(i).Item("tipoarchivo_exc").ToString())
                        dict.Add("archivo", fn.EncrytedString64(dt1.Rows(i).Item("archivo").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "lstAnioAfectaDoc" Then
                Try
                    Dim oeAfectacionDoc As New eAfectacionDoc
                    Dim olAfectacionDoc As New lAfectacionDoc
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    dt1 = olAfectacionDoc.listarAnioAfectacionesDoc(oeAfectacionDoc)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("nombre_anioAfec", dt1.Rows(i).Item("anio_ado").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstSitioAfectaDoc" Then
                Try
                    Dim oeAfectacionDoc As New eAfectacionDoc
                    Dim olAfectacionDoc As New lAfectacionDoc
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    dt1 = olAfectacionDoc.listarSitioAfectacionesDoc(oeAfectacionDoc)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("nombre_sitioAfec", dt1.Rows(i).Item("sitio_ado").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gInmuebles3" Then
                Try
                    Dim oeAfectacionDoc As New eAfectacionDoc
                    Dim olAfectacionDoc As New lAfectacionDoc
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeAfectacionDoc.anio_ado = Request("txtAnioAfecDoc").ToString()
                    oeAfectacionDoc.sitio_ado = Request("txtProyectoAfec").ToString()

                    oeAfectacionDoc.usuarioreg = Session("dni")


                    dt1 = olAfectacionDoc.invest_registrarAfectacionesDoc(oeAfectacionDoc)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "ListarInmuebles3" Then
                Try
                    Dim oeAfectacionDoc As New eAfectacionDoc
                    Dim olAfectacionDoc As New lAfectacionDoc
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    dt1 = olAfectacionDoc.invest_ListarAfectacionesDoc(oeAfectacionDoc)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo_ado", dt1.Rows(i).Item("codigo_ado").ToString())
                        dict.Add("anio_ado", dt1.Rows(i).Item("anio_ado").ToString())
                        dict.Add("sitio_ado", dt1.Rows(i).Item("sitio_ado").ToString())
                        dict.Add("archivo_ado", dt1.Rows(i).Item("archivo_ado").ToString())
                        dict.Add("archivo", fn.EncrytedString64(dt1.Rows(i).Item("archivo").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gInvInmbueble1" Then
                Try
                    Dim oeInventarioInmuebles As New eInventarioInmuebles
                    Dim olinventarioInmuebles As New linventarioInmuebles
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeInventarioInmuebles.codigo_inm = Request("invInm").ToString()
                    oeInventarioInmuebles.nombresitio_inm = Request("txtNombreSitioI").ToString()
                    oeInventarioInmuebles.caserio_inm = Request("txtCaserio").ToString()
                    oeInventarioInmuebles.departamento_inm = Request("cboDepartamento").ToString()
                    oeInventarioInmuebles.provincia_inm = Request("dboProvincia").ToString()
                    oeInventarioInmuebles.distrito_inm = Request("cboDistrito").ToString()
                    oeInventarioInmuebles.utme_inm = Request("txtUTMe").ToString()
                    oeInventarioInmuebles.utmn_inm = Request("txtUTMn").ToString()
                    oeInventarioInmuebles.datum_inm = Request("txtDatum").ToString()
                    oeInventarioInmuebles.perimetro_inm = Request("txtPerimetro").ToString()

                    oeInventarioInmuebles.usuarioreg = Session("dni")

                    dt1 = olinventarioInmuebles.registrarInmueble1(oeInventarioInmuebles)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gInvInmbueble2" Then
                Try
                    Dim oeInventarioInmuebles As New eInventarioInmuebles
                    Dim olinventarioInmuebles As New linventarioInmuebles
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeInventarioInmuebles.codigo_inm = Request("invInm").ToString()
                    oeInventarioInmuebles.normalega_inm = Request("txtNorma").ToString()
                    oeInventarioInmuebles.fecha_inm = Request("txtFecha").ToString()
                    oeInventarioInmuebles.levplano_inm = Request("cboLevPlano").ToString()
                    oeInventarioInmuebles.elaboroplano_inm = Request("txtElaborado").ToString()
                    oeInventarioInmuebles.fichatec_inm = Request("cboFichaTec").ToString()
                    oeInventarioInmuebles.memoriades_inm = Request("cboMemoria").ToString()
                    oeInventarioInmuebles.cultur_inm = Request("txtCultura").ToString()
                    oeInventarioInmuebles.tipositio_inm = Request("txtTipoSitio").ToString()
                    oeInventarioInmuebles.estado_inm = Request("txtEstado").ToString()

                    oeInventarioInmuebles.usuarioreg = Session("dni")

                    dt1 = olinventarioInmuebles.registrarInmueble2(oeInventarioInmuebles)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "ListaInvInmbueble" Then
                Try
                    Dim oeInventarioInmuebles As New eInventarioInmuebles
                    Dim olinventarioInmuebles As New linventarioInmuebles
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeInventarioInmuebles.codigo_inm = Request("invInm").ToString()

                    dt1 = olinventarioInmuebles.listaInventarioInmuebles(oeInventarioInmuebles)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo_inm", dt1.Rows(i).Item("codigo_inm").ToString())
                        dict.Add("nombresitio_inm", dt1.Rows(i).Item("nombresitio_inm").ToString())
                        dict.Add("caserio_inm", dt1.Rows(i).Item("caserio_inm").ToString())
                        dict.Add("departamento_inm", dt1.Rows(i).Item("departamento_inm").ToString())
                        dict.Add("provincia_inm", dt1.Rows(i).Item("provincia_inm").ToString())
                        dict.Add("distrito_inm", dt1.Rows(i).Item("distrito_inm").ToString())
                        dict.Add("utme_inm", dt1.Rows(i).Item("utme_inm").ToString())
                        dict.Add("utmn_inm", dt1.Rows(i).Item("utmn_inm").ToString())
                        dict.Add("datum_inm", dt1.Rows(i).Item("datum_inm").ToString())
                        dict.Add("perimetro_inm", dt1.Rows(i).Item("perimetro_inm").ToString())
                        dict.Add("normalega_inm", dt1.Rows(i).Item("normalega_inm").ToString())
                        dict.Add("fecha_inm", dt1.Rows(i).Item("fecha_inm").ToString())
                        dict.Add("levplano_inm", dt1.Rows(i).Item("levplano_inm").ToString())
                        dict.Add("elaboroplano_inm", dt1.Rows(i).Item("elaboroplano_inm").ToString())
                        dict.Add("fichatec_inm", dt1.Rows(i).Item("fichatec_inm").ToString())
                        dict.Add("memoriades_inm", dt1.Rows(i).Item("memoriades_inm").ToString())
                        dict.Add("cultur_inm", dt1.Rows(i).Item("cultur_inm").ToString())
                        dict.Add("tipositio_inm", dt1.Rows(i).Item("tipositio_inm").ToString())
                        dict.Add("estado_inm", dt1.Rows(i).Item("estado_inm").ToString())
                        dict.Add("activo", dt1.Rows(i).Item("activo").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "DelInvInmueble" Then
                Try
                    Dim oeInventarioInmuebles As New eInventarioInmuebles
                    Dim olinventarioInmuebles As New linventarioInmuebles
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    oeInventarioInmuebles.codigo_inm = Request("param1").ToString()
                    'oeInventarioInmuebles.codigo_inm = fn.DecrytedString64(Request("param1").ToString())

                    oeInventarioInmuebles.usuarioreg = Session("dni")

                    dt1 = olinventarioInmuebles.eliminarInmueble(oeInventarioInmuebles)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gAfectacionInmueble" Then
                Try
                    Dim oeAfectacionInmueble As New eAfectacionInmueble
                    Dim olAfectacionInmueble As New lAfectacionInmueble
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeAfectacionInmueble.codigo_ain = Request("afeInm").ToString()
                    oeAfectacionInmueble.fecha_ain = Request("txtFechaAI").ToString()
                    oeAfectacionInmueble.sitio_ain = Request("txtSitioAI").ToString()
                    oeAfectacionInmueble.denunciante_ain = Request("txtdenuncianteAI").ToString()
                    oeAfectacionInmueble.denunciado_ain = Request("txtdenunciadoAI").ToString()
                    oeAfectacionInmueble.tipoafect_ain = Request("txtTipoAfectAI").ToString()
                    oeAfectacionInmueble.inspeccion_ain = Request("cboRealizoInspAI").ToString()
                    oeAfectacionInmueble.realizoinspec_ain = Request("txtQuienInspAI").ToString()
                    oeAfectacionInmueble.instancia_ain = Request("txtInstancia").ToString()

                    oeAfectacionInmueble.usuarioreg = Session("dni")

                    dt1 = olAfectacionInmueble.registrarAfectacionInmueble(oeAfectacionInmueble)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "listarAfectacionInmueble" Then
                Try
                    Dim oeAfectacionInmueble As New eAfectacionInmueble
                    Dim olAfectacionInmueble As New lAfectacionInmueble
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeAfectacionInmueble.codigo_ain = Request("afeInm").ToString()

                    dt1 = olAfectacionInmueble.listaInventarioInmuebles(oeAfectacionInmueble)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo_ain", dt1.Rows(i).Item("codigo_ain").ToString())
                        dict.Add("fecha_ain", dt1.Rows(i).Item("fecha_ain").ToString())
                        dict.Add("sitio_ain", dt1.Rows(i).Item("sitio_ain").ToString())
                        dict.Add("denunciante_ain", dt1.Rows(i).Item("denunciante_ain").ToString())
                        dict.Add("denunciado_ain", dt1.Rows(i).Item("denunciado_ain").ToString())
                        dict.Add("tipoafect_ain", dt1.Rows(i).Item("tipoafect_ain").ToString())
                        dict.Add("inspeccion_ain", dt1.Rows(i).Item("inspeccion_ain").ToString())
                        dict.Add("realizoinspec_ain", dt1.Rows(i).Item("realizoinspec_ain").ToString())
                        dict.Add("instancia_ain", dt1.Rows(i).Item("instancia_ain").ToString())
                        dict.Add("activo", dt1.Rows(i).Item("activo").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "DelAfectacionInmueble" Then
                Try
                    Dim oeAfectacionInmueble As New eAfectacionInmueble
                    Dim olAfectacionInmueble As New lAfectacionInmueble
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeAfectacionInmueble.codigo_ain = Request("param1").ToString()
                    oeAfectacionInmueble.usuarioreg = Session("dni")

                    dt1 = olAfectacionInmueble.eliminarAfectacionInmueble(oeAfectacionInmueble)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "PlaniArqueo" Then
                Try
                    Dim oeCatalogo As New eCatalogo
                    Dim olCatalogo As New lCatalogo
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    dt1 = olCatalogo.PlanillaArqueologica(oeCatalogo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codpropietario_cat", dt1.Rows(i).Item("codpropietario_cat").ToString())
                        dict.Add("codreginc_cat", dt1.Rows(i).Item("codreginc_cat").ToString())
                        dict.Add("cultura_cat", dt1.Rows(i).Item("cultura_cat").ToString())
                        dict.Add("denominacion_cat", dt1.Rows(i).Item("denominacion_cat").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "SurbirArchivoNew" Then
                Try
                    Dim fn As New lFunciones
                    Dim post As HttpPostedFile = HttpContext.Current.Request.Files("ArchivoASubir")
                    Dim codigo As String = Request("codigo").ToString()
                    Dim tipo As String = Request("tipo")
                    Dim NroRend As String = 0

                    Dim Fecha As String = Date.Now.ToString("dd/MM/yyyy")
                    Dim Usuario As String = Session("dni")
                    Dim Input(post.ContentLength) As Byte

                    If tipo = "FRONTAL" Then
                        NroRend = 1
                    End If
                    If tipo = "LATERAL" Then
                        NroRend = 2
                    End If
                    If tipo = "OTRAS" Then
                        NroRend = 3
                    End If
                    If tipo = "DETALLE" Then
                        NroRend = 4
                    End If
                    If tipo = "DIBUJO" Then
                        NroRend = 5
                    End If
                    If tipo = "FRONTALE" Then
                        NroRend = 20
                    End If

                    Dim b As New BinaryReader(post.InputStream)
                    Dim binData As Byte() = b.ReadBytes(post.InputStream.Length)
                    Dim base64 = System.Convert.ToBase64String(binData)
                    Dim wsCloud As New ClsArchivosCompartidos
                    Dim list As New Dictionary(Of String, String)
                    '  Dim list As New List(Of Dictionary(Of String, String))()
                    list.Add("Fecha", Fecha)
                    list.Add("Extencion", System.IO.Path.GetExtension(post.FileName))
                    list.Add("Nombre", System.IO.Path.GetFileName(post.FileName))
                    list.Add("TransaccionId", codigo)
                    list.Add("TablaId", "1")
                    list.Add("NroOperacion", NroRend)
                    list.Add("Archivo", System.Convert.ToBase64String(binData, 0, binData.Length))
                    list.Add("Usuario", Usuario)
                    list.Add("Equipo", "")
                    list.Add("Ip", "")
                    list.Add("param8", Usuario)
                    Dim envelope As String = wsCloud.SoapEnvelope(list)
                    'Dim result As String = wsCloud.PeticionRequestSoap("http://localhost/SharedFilesService/SharedFiles.asmx", envelope, "http://usat.edu.pe/UploadFile", Usuario)
                    Dim result As String = wsCloud.PeticionRequestSoap("http://localhost/SharedFilesService/SharedFiles.asmx", envelope, "http://usat.edu.pe/UploadFile", Usuario)

                    Dim tb As New Data.DataTable
                    Dim oeAlumno As New eAlumno
                    Dim olAlumno As New lAlumno
                    Dim dt As New DataTable

                    oeAlumno.param1 = 1
                    oeAlumno.param2 = codigo
                    oeAlumno.param3 = NroRend

                    'dt = olAlumno.ActualizarArchivoCompartivo(oeAlumno)

                Catch ex As Exception
                    Dim Data1 As New Dictionary(Of String, Object)()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Data1.Add("rpta", "1 - LIST")
                    Data1.Add("msje", ex.Message)
                    list.Add(Data1)
                    JSONresult = serializer.Serialize(list)
                    Response.Write(JSONresult)
                End Try

            ElseIf Request("param0") = "Download2" Then
                Download2()
            ElseIf Request("param0") = "DownloadSinEnc" Then
                DownloadSinEnc()

            ElseIf Request("param0") = "gCatalogo7" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeCatologo.codpropietario_cat = fn.DecrytedString64(Request("cat").ToString())
                    oeCatologo.fichacampoelab_cat = Request("txtFichaCampo").ToString()
                    oeCatologo.fechafichacampo_cat = Request("txtFechaFichaC").ToString()
                    oeCatologo.fototomada_cat = Request("txtFotoTomada").ToString()
                    oeCatologo.fechafoto = Request("txtFechaTomaFoto").ToString()
                    oeCatologo.tipo_cat = Request("cboDocumentos").ToString()
                    oeCatologo.nrodocumento_cat = Request("txtNroDoc").ToString()
                    oeCatologo.fechadocumento_cat = Request("txtFechaDoc").ToString()
                    oeCatologo.otrasreferencias_cat = Request("txtOtrasReferencias").ToString()
                    oeCatologo.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeCatologo.usuarioreg = Session("dni")
                    dt1 = olCatologo.registrarIdentificacionCodAdicionales7(oeCatologo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstTbInventario" Then
                Try
                    Dim oeTbInventario As New etbInventario
                    Dim olTbInventario As New lTbInventario
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeTbInventario.cod_inventario = 0
                    dt1 = olTbInventario.ListarTbInventario(oeTbInventario)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    serializer.MaxJsonLength = Int32.MaxValue
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("cod_inventario", dt1.Rows(i).Item("cod_inventario").ToString())
                        dict.Add("registro_nacional", dt1.Rows(i).Item("registro_nacional").ToString())
                        dict.Add("codigo_propiet", dt1.Rows(i).Item("codigo_propiet").ToString())
                        dict.Add("otro_codigo", dt1.Rows(i).Item("otro_codigo").ToString())
                        dict.Add("categoria", dt1.Rows(i).Item("categoria").ToString())
                        dict.Add("taxonomia", dt1.Rows(i).Item("taxonomia").ToString())
                        dict.Add("denominacion", dt1.Rows(i).Item("denominacion").ToString())
                        dict.Add("cultura", dt1.Rows(i).Item("cultura").ToString())
                        dict.Add("periodo", dt1.Rows(i).Item("periodo").ToString())
                        dict.Add("descripcion_identificacion", dt1.Rows(i).Item("descripcion_identificacion").ToString())
                        dict.Add("tipo_material", dt1.Rows(i).Item("tipo_material").ToString())
                        dict.Add("tecnicas", dt1.Rows(i).Item("tecnicas").ToString())
                        dict.Add("alto", dt1.Rows(i).Item("alto").ToString())
                        dict.Add("largo", dt1.Rows(i).Item("largo").ToString())
                        dict.Add("ancho", dt1.Rows(i).Item("ancho").ToString())
                        dict.Add("diam_maximo", dt1.Rows(i).Item("diam_maximo").ToString())
                        dict.Add("diam_min", dt1.Rows(i).Item("diam_min").ToString())
                        dict.Add("peso", dt1.Rows(i).Item("peso").ToString())
                        dict.Add("estado_integridad", dt1.Rows(i).Item("estado_integridad").ToString())
                        dict.Add("cantidad", dt1.Rows(i).Item("cantidad").ToString())
                        dict.Add("detalle_conservacion", dt1.Rows(i).Item("detalle_conservacion").ToString())
                        dict.Add("procedencia", dt1.Rows(i).Item("procedencia").ToString())
                        dict.Add("region_origen", dt1.Rows(i).Item("region_origen").ToString())
                        dict.Add("sitio_origen", dt1.Rows(i).Item("sitio_origen").ToString())
                        dict.Add("sector_origen", dt1.Rows(i).Item("sector_origen").ToString())
                        dict.Add("subsector_origen", dt1.Rows(i).Item("subsector_origen").ToString())
                        dict.Add("unidad_origen", dt1.Rows(i).Item("unidad_origen").ToString())
                        dict.Add("cuadrante_origen", dt1.Rows(i).Item("cuadrante_origen").ToString())
                        dict.Add("capa_origen", dt1.Rows(i).Item("capa_origen").ToString())
                        dict.Add("cuadricula_origen", dt1.Rows(i).Item("cuadricula_origen").ToString())
                        dict.Add("contexto_origen", dt1.Rows(i).Item("contexto_origen").ToString())
                        dict.Add("coleccion_propiedad", dt1.Rows(i).Item("coleccion_propiedad").ToString())
                        dict.Add("adquisicion_propiedad", dt1.Rows(i).Item("adquisicion_propiedad").ToString())
                        dict.Add("documento_propiedad", dt1.Rows(i).Item("documento_propiedad").ToString())
                        dict.Add("fecha_propiedad", dt1.Rows(i).Item("fecha_propiedad").ToString())
                        dict.Add("ubicacion", dt1.Rows(i).Item("ubicacion").ToString())
                        dict.Add("area_ubicacion", dt1.Rows(i).Item("area_ubicacion").ToString())
                        dict.Add("especifica_ubicacion", dt1.Rows(i).Item("especifica_ubicacion").ToString())
                        dict.Add("nivel_ubicacion", dt1.Rows(i).Item("nivel_ubicacion").ToString())
                        dict.Add("caja_ubicacion", dt1.Rows(i).Item("caja_ubicacion").ToString())
                        dict.Add("bolsa_ubicacion", dt1.Rows(i).Item("bolsa_ubicacion").ToString())
                        dict.Add("excavado_adic", dt1.Rows(i).Item("excavado_adic").ToString())
                        dict.Add("registrado_adic", dt1.Rows(i).Item("registrado_adic").ToString())
                        dict.Add("fecha_adic", dt1.Rows(i).Item("fecha_adic").ToString())
                        dict.Add("observacion_adic", dt1.Rows(i).Item("observacion_adic").ToString())
                        list.Add(dict)
                    Next
                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
                'Inicio JAZ
            ElseIf Request("param0") = "lstTbInventarioCP" Then
                Try
                    Dim oeTbInventario As New etbInventario
                    Dim olTbInventario As New lTbInventario
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeTbInventario.Codigo_propiet = Request("param1").ToString()
                    oeTbInventario.cod_dgc = fn.DecrytedString64(Request("param2").ToString())
                    dt1 = olTbInventario.ListarTbInventarioCP(oeTbInventario)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    serializer.MaxJsonLength = Int32.MaxValue
                    If dt1 IsNot Nothing Then
                        For i As Integer = 0 To dt1.Rows.Count - 1
                            Dim dict As New Dictionary(Of String, Object)()
                            dict.Add("cod_inventario", dt1.Rows(i).Item("cod_inventario").ToString())
                            dict.Add("registro_nacional", dt1.Rows(i).Item("registro_nacional").ToString())
                            dict.Add("codigo_propiet", dt1.Rows(i).Item("codigo_propiet").ToString())
                            dict.Add("otro_codigo", dt1.Rows(i).Item("otro_codigo").ToString())
                            dict.Add("categoria", dt1.Rows(i).Item("categoria").ToString())
                            dict.Add("taxonomia", dt1.Rows(i).Item("taxonomia").ToString())
                            dict.Add("denominacion", dt1.Rows(i).Item("denominacion").ToString())
                            dict.Add("cultura", dt1.Rows(i).Item("cultura").ToString())
                            dict.Add("periodo", dt1.Rows(i).Item("periodo").ToString())
                            dict.Add("descripcion_identificacion", dt1.Rows(i).Item("descripcion_identificacion").ToString())
                            dict.Add("tipo_material", dt1.Rows(i).Item("tipo_material").ToString())
                            dict.Add("tecnicas", dt1.Rows(i).Item("tecnicas").ToString())
                            dict.Add("alto", dt1.Rows(i).Item("alto").ToString())
                            dict.Add("largo", dt1.Rows(i).Item("largo").ToString())
                            dict.Add("ancho", dt1.Rows(i).Item("ancho").ToString())
                            dict.Add("diam_maximo", dt1.Rows(i).Item("diam_maximo").ToString())
                            dict.Add("diam_min", dt1.Rows(i).Item("diam_min").ToString())
                            dict.Add("peso", dt1.Rows(i).Item("peso").ToString())
                            dict.Add("estado_integridad", dt1.Rows(i).Item("estado_integridad").ToString())
                            dict.Add("cantidad", dt1.Rows(i).Item("cantidad").ToString())
                            dict.Add("detalle_conservacion", dt1.Rows(i).Item("detalle_conservacion").ToString())
                            dict.Add("procedencia", dt1.Rows(i).Item("procedencia").ToString())
                            dict.Add("region_origen", dt1.Rows(i).Item("region_origen").ToString())
                            dict.Add("sitio_origen", dt1.Rows(i).Item("sitio_origen").ToString())
                            dict.Add("sector_origen", dt1.Rows(i).Item("sector_origen").ToString())
                            dict.Add("subsector_origen", dt1.Rows(i).Item("subsector_origen").ToString())
                            dict.Add("unidad_origen", dt1.Rows(i).Item("unidad_origen").ToString())
                            dict.Add("cuadrante_origen", dt1.Rows(i).Item("cuadrante_origen").ToString())
                            dict.Add("capa_origen", dt1.Rows(i).Item("capa_origen").ToString())
                            dict.Add("cuadricula_origen", dt1.Rows(i).Item("cuadricula_origen").ToString())
                            dict.Add("contexto_origen", dt1.Rows(i).Item("contexto_origen").ToString())
                            dict.Add("coleccion_propiedad", dt1.Rows(i).Item("coleccion_propiedad").ToString())
                            dict.Add("adquisicion_propiedad", dt1.Rows(i).Item("adquisicion_propiedad").ToString())
                            dict.Add("documento_propiedad", dt1.Rows(i).Item("documento_propiedad").ToString())
                            dict.Add("fecha_propiedad", dt1.Rows(i).Item("fecha_propiedad").ToString())
                            dict.Add("ubicacion", dt1.Rows(i).Item("ubicacion").ToString())
                            dict.Add("area_ubicacion", dt1.Rows(i).Item("area_ubicacion").ToString())
                            dict.Add("especifica_ubicacion", dt1.Rows(i).Item("especifica_ubicacion").ToString())
                            dict.Add("nivel_ubicacion", dt1.Rows(i).Item("nivel_ubicacion").ToString())
                            dict.Add("caja_ubicacion", dt1.Rows(i).Item("caja_ubicacion").ToString())
                            dict.Add("bolsa_ubicacion", dt1.Rows(i).Item("bolsa_ubicacion").ToString())
                            dict.Add("excavado_adic", dt1.Rows(i).Item("excavado_adic").ToString())
                            dict.Add("registrado_adic", dt1.Rows(i).Item("registrado_adic").ToString())
                            dict.Add("fecha_adic", dt1.Rows(i).Item("fecha_adic").ToString())
                            dict.Add("observacion_adic", dt1.Rows(i).Item("observacion_adic").ToString())
                            list.Add(dict)
                        Next
                        JSONresult = serializer.Serialize(list)
                    End If

                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstTbInventarioDGC" Then
                Try
                    Dim oeTbInventario As New etbInventario
                    Dim olTbInventario As New lTbInventario
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeTbInventario.cod_dgc = fn.DecrytedString64(Request("param1").ToString())
                    dt1 = olTbInventario.ListarTbInventarioDGC(oeTbInventario)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    serializer.MaxJsonLength = Int32.MaxValue
                    If dt1 IsNot Nothing Then
                        For i As Integer = 0 To dt1.Rows.Count - 1
                            Dim dict As New Dictionary(Of String, Object)()
                            dict.Add("cod_inventario", dt1.Rows(i).Item("cod_inventario").ToString())
                            dict.Add("registro_nacional", dt1.Rows(i).Item("registro_nacional").ToString())
                            dict.Add("codigo_propiet", dt1.Rows(i).Item("codigo_propiet").ToString())
                            dict.Add("otro_codigo", dt1.Rows(i).Item("otro_codigo").ToString())
                            dict.Add("categoria", dt1.Rows(i).Item("categoria").ToString())
                            dict.Add("taxonomia", dt1.Rows(i).Item("taxonomia").ToString())
                            dict.Add("denominacion", dt1.Rows(i).Item("denominacion").ToString())
                            dict.Add("cultura", dt1.Rows(i).Item("cultura").ToString())
                            dict.Add("periodo", dt1.Rows(i).Item("periodo").ToString())
                            dict.Add("descripcion_identificacion", dt1.Rows(i).Item("descripcion_identificacion").ToString())
                            dict.Add("tipo_material", dt1.Rows(i).Item("tipo_material").ToString())
                            dict.Add("tecnicas", dt1.Rows(i).Item("tecnicas").ToString())
                            dict.Add("alto", dt1.Rows(i).Item("alto").ToString())
                            dict.Add("largo", dt1.Rows(i).Item("largo").ToString())
                            dict.Add("ancho", dt1.Rows(i).Item("ancho").ToString())
                            dict.Add("diam_maximo", dt1.Rows(i).Item("diam_maximo").ToString())
                            dict.Add("diam_min", dt1.Rows(i).Item("diam_min").ToString())
                            dict.Add("peso", dt1.Rows(i).Item("peso").ToString())
                            dict.Add("estado_integridad", dt1.Rows(i).Item("estado_integridad").ToString())
                            dict.Add("cantidad", dt1.Rows(i).Item("cantidad").ToString())
                            dict.Add("detalle_conservacion", dt1.Rows(i).Item("detalle_conservacion").ToString())
                            dict.Add("procedencia", dt1.Rows(i).Item("procedencia").ToString())
                            dict.Add("region_origen", dt1.Rows(i).Item("region_origen").ToString())
                            dict.Add("sitio_origen", dt1.Rows(i).Item("sitio_origen").ToString())
                            dict.Add("sector_origen", dt1.Rows(i).Item("sector_origen").ToString())
                            dict.Add("subsector_origen", dt1.Rows(i).Item("subsector_origen").ToString())
                            dict.Add("unidad_origen", dt1.Rows(i).Item("unidad_origen").ToString())
                            dict.Add("cuadrante_origen", dt1.Rows(i).Item("cuadrante_origen").ToString())
                            dict.Add("capa_origen", dt1.Rows(i).Item("capa_origen").ToString())
                            dict.Add("cuadricula_origen", dt1.Rows(i).Item("cuadricula_origen").ToString())
                            dict.Add("contexto_origen", dt1.Rows(i).Item("contexto_origen").ToString())
                            dict.Add("coleccion_propiedad", dt1.Rows(i).Item("coleccion_propiedad").ToString())
                            dict.Add("adquisicion_propiedad", dt1.Rows(i).Item("adquisicion_propiedad").ToString())
                            dict.Add("documento_propiedad", dt1.Rows(i).Item("documento_propiedad").ToString())
                            dict.Add("fecha_propiedad", dt1.Rows(i).Item("fecha_propiedad").ToString())
                            dict.Add("ubicacion", dt1.Rows(i).Item("ubicacion").ToString())
                            dict.Add("area_ubicacion", dt1.Rows(i).Item("area_ubicacion").ToString())
                            dict.Add("especifica_ubicacion", dt1.Rows(i).Item("especifica_ubicacion").ToString())
                            dict.Add("nivel_ubicacion", dt1.Rows(i).Item("nivel_ubicacion").ToString())
                            dict.Add("caja_ubicacion", dt1.Rows(i).Item("caja_ubicacion").ToString())
                            dict.Add("bolsa_ubicacion", dt1.Rows(i).Item("bolsa_ubicacion").ToString())
                            dict.Add("excavado_adic", dt1.Rows(i).Item("excavado_adic").ToString())
                            dict.Add("registrado_adic", dt1.Rows(i).Item("registrado_adic").ToString())
                            dict.Add("fecha_adic", dt1.Rows(i).Item("fecha_adic").ToString())
                            dict.Add("observacion_adic", dt1.Rows(i).Item("observacion_adic").ToString())
                            list.Add(dict)
                        Next
                        JSONresult = serializer.Serialize(list)
                    End If

                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
                'Fin JAZ
            ElseIf Request("param0") = "regRutaArchivo" Then
                Try
                    Dim oeArchivo As New eArchivoCompartido
                    Dim olArchivo As New lArchivoCompartido

                    Dim dt1 As New DataTable

                    oeArchivo.NombreArchivo = Request("txtNombreArchivo").ToString()
                    oeArchivo.Fecha = DateTime.Today
                    oeArchivo.Extencion = Request("txtExtension").ToString()
                    oeArchivo.IdTabla = "1"
                    oeArchivo.IdTransaccion = Request("txtTransaccion").ToString()
                    oeArchivo.NroOperacion = "20"
                    oeArchivo.RutaArchivo = Request("txtRuta").ToString()
                    oeArchivo.FechaReg = DateTime.Now
                    oeArchivo.UsuarioReg = Session("dni")

                    dt1 = olArchivo.RegistrarArchivo(oeArchivo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
            ElseIf Request("param0") = "lstInventariosDGC" Then
                Try
                    Dim oeInventario As New eInventario
                    Dim olInventario As New lInventario
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeInventario.param1 = fn.DecrytedString64(Request("param1").ToString())

                    dt1 = olInventario.ListarInventariosDGC(oeInventario)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo", fn.EncrytedString64(dt1.Rows(i).Item("codpropietario_inv").ToString()))
                        dict.Add("codpropietario_inv", dt1.Rows(i).Item("codpropietario_inv").ToString())
                        dict.Add("id_inv", dt1.Rows(i).Item("id_inv").ToString())
                        dict.Add("nro_inv", dt1.Rows(i).Item("nro_inv").ToString())
                        dict.Add("proyecto_inv", dt1.Rows(i).Item("proyecto_inv").ToString())
                        dict.Add("temporada_inv", dt1.Rows(i).Item("temporada_inv").ToString())
                        dict.Add("sector_inv", RTrim(dt1.Rows(i).Item("sector_inv").ToString()))
                        dict.Add("subsector_inv", RTrim(dt1.Rows(i).Item("subsector_inv").ToString()))
                        dict.Add("unidad_inv", RTrim(dt1.Rows(i).Item("unidad_inv").ToString()))
                        dict.Add("capa_inv", RTrim(dt1.Rows(i).Item("capa_inv").ToString()))
                        dict.Add("nivel_inv", RTrim(dt1.Rows(i).Item("nivel_inv").ToString()))
                        dict.Add("cuadricula_inv", dt1.Rows(i).Item("cuadricula_inv").ToString())
                        dict.Add("contexto_inv", dt1.Rows(i).Item("contexto_inv").ToString())
                        dict.Add("plano_inv", dt1.Rows(i).Item("plano_inv").ToString())
                        dict.Add("tipomaterial_inv", dt1.Rows(i).Item("tipomaterial_inv").ToString())
                        dict.Add("descripcion_inv", dt1.Rows(i).Item("descripcion_inv").ToString())
                        dict.Add("cultura_inv", dt1.Rows(i).Item("cultura_inv").ToString())
                        dict.Add("dcultura_inv", dt1.Rows(i).Item("dcultura_inv").ToString())
                        dict.Add("estilo_inv", dt1.Rows(i).Item("estilo_inv").ToString())
                        dict.Add("otrosdatos_inv", dt1.Rows(i).Item("otrosdatos_inv").ToString())
                        dict.Add("nrocaja_inv", dt1.Rows(i).Item("nrocaja_inv").ToString())
                        dict.Add("nrobolsa_inv", dt1.Rows(i).Item("nrobolsa_inv").ToString())
                        dict.Add("codexcavacion_inv", dt1.Rows(i).Item("codexcavacion_inv").ToString())
                        dict.Add("ini_rotulacion_inv", dt1.Rows(i).Item("ini_rotulacion_inv").ToString())
                        dict.Add("fin_rotulacion_inv", dt1.Rows(i).Item("fin_rotulacion_inv").ToString())
                        dict.Add("cantidad_inv", dt1.Rows(i).Item("cantidad_inv").ToString())
                        dict.Add("peso_inv", dt1.Rows(i).Item("peso_inv").ToString())
                        dict.Add("fechaalmacen_inv", dt1.Rows(i).Item("fechaalmacen_inv").ToString())
                        dict.Add("registro_inv", dt1.Rows(i).Item("registro_inv").ToString())
                        dict.Add("almacen_inv", dt1.Rows(i).Item("almacen_inv").ToString())
                        dict.Add("estante_inv", dt1.Rows(i).Item("estante_inv").ToString())
                        dict.Add("observacion_inv", dt1.Rows(i).Item("observacion_inv").ToString())
                        dict.Add("fechareg", dt1.Rows(i).Item("fechareg").ToString())
                        dict.Add("usuarioreg", dt1.Rows(i).Item("usuarioreg").ToString())
                        dict.Add("activo_inv", dt1.Rows(i).Item("activo_inv").ToString())
                        dict.Add("id_dgc", dt1.Rows(i).Item("id_dgc").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstEvaluacionesDGC" Then
                Try
                    Dim oeEvaluacion As New eEvaluacion
                    Dim olEvaluacion As New lEvaluacion
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeEvaluacion.nroficha_con = Request("param1").ToString()
                    oeEvaluacion.id_dgc = fn.DecrytedString64(Request("param2").ToString())

                    dt1 = olEvaluacion.listaEvaluaciones(oeEvaluacion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo", fn.EncrytedString64(dt1.Rows(i).Item("nroficha_con").ToString()))
                        dict.Add("nroficha_con", dt1.Rows(i).Item("nroficha_con").ToString())
                        dict.Add("id_dgc", dt1.Rows(i).Item("id_dgc").ToString())
                        dict.Add("codregnac_con", dt1.Rows(i).Item("codregnac_con").ToString())
                        dict.Add("codpropietario_con", dt1.Rows(i).Item("codpropietario_con").ToString())
                        dict.Add("codexcavacion_con", dt1.Rows(i).Item("codexcavacion_con").ToString())
                        dict.Add("codrestauracion_con", dt1.Rows(i).Item("codrestauracion_con").ToString())
                        dict.Add("sector_con", dt1.Rows(i).Item("sector_con").ToString())
                        dict.Add("unidad_con", dt1.Rows(i).Item("unidad_con").ToString())
                        dict.Add("capa_con", dt1.Rows(i).Item("capa_con").ToString())
                        dict.Add("nivel_con", dt1.Rows(i).Item("nivel_con").ToString())
                        dict.Add("cuadricula_con", dt1.Rows(i).Item("cuadricula_con").ToString())
                        dict.Add("plano_con", dt1.Rows(i).Item("plano_con").ToString())
                        dict.Add("contexto_con", dt1.Rows(i).Item("contexto_con").ToString())
                        dict.Add("ubicontexto_con", dt1.Rows(i).Item("ubicontexto_con").ToString())
                        dict.Add("alturaobs_con", dt1.Rows(i).Item("alturaobs_con").ToString())
                        dict.Add("otrosdatos_con", dt1.Rows(i).Item("otrosdatos_con").ToString())
                        dict.Add("material_con", dt1.Rows(i).Item("material_con").ToString())
                        dict.Add("denominacion_con", dt1.Rows(i).Item("denominacion_con").ToString())
                        dict.Add("descripcion_con", dt1.Rows(i).Item("descripcion_con").ToString())
                        dict.Add("alto_con", dt1.Rows(i).Item("alto_con").ToString())
                        dict.Add("largo_con", dt1.Rows(i).Item("largo_con").ToString())
                        dict.Add("ancho_con", dt1.Rows(i).Item("ancho_con").ToString())
                        dict.Add("espesor_con", dt1.Rows(i).Item("espesor_con").ToString())
                        dict.Add("diametromax_con", dt1.Rows(i).Item("diametromax_con").ToString())
                        dict.Add("diametromin_con", dt1.Rows(i).Item("diametromin_con").ToString())
                        dict.Add("diametrobase_con", dt1.Rows(i).Item("diametrobase_con").ToString())
                        dict.Add("peso_con", dt1.Rows(i).Item("peso_con").ToString())
                        dict.Add("ubicinmueble_con", dt1.Rows(i).Item("ubicinmueble_con").ToString())
                        dict.Add("nrocaja_con", dt1.Rows(i).Item("nrocaja_con").ToString())
                        dict.Add("nrobolsa_con", dt1.Rows(i).Item("nrobolsa_con").ToString())
                        dict.Add("integridadbien_con", dt1.Rows(i).Item("integridadbien_con").ToString())
                        dict.Add("conservacionbien_con", dt1.Rows(i).Item("conservacionbien_con").ToString())
                        dict.Add("detconservacion_con", dt1.Rows(i).Item("detconservacion_con").ToString())
                        dict.Add("intervenciones_con", dt1.Rows(i).Item("intervenciones_con").ToString())
                        dict.Add("afectacion_con", dt1.Rows(i).Item("afectacion_con").ToString())
                        dict.Add("tratamiento_con", dt1.Rows(i).Item("tratamiento_con").ToString())
                        dict.Add("limpieza_con", dt1.Rows(i).Item("limpieza_con").ToString())
                        dict.Add("observaciones_con", dt1.Rows(i).Item("observaciones_con").ToString())
                        dict.Add("temperatura_con", dt1.Rows(i).Item("temperatura_con").ToString())
                        dict.Add("humedad_con", dt1.Rows(i).Item("humedad_con").ToString())
                        dict.Add("manipulacion_con", dt1.Rows(i).Item("manipulacion_con").ToString())
                        dict.Add("otros_con", dt1.Rows(i).Item("otros_con").ToString())
                        dict.Add("conservadorcargo_con", dt1.Rows(i).Item("conservadorcargo_con").ToString())
                        dict.Add("fecha_con", dt1.Rows(i).Item("fecha_con").ToString())
                        dict.Add("foto_con", dt1.Rows(i).Item("foto_con").ToString())
                        dict.Add("activo", dt1.Rows(i).Item("activo").ToString())
                        dict.Add("fechareg", dt1.Rows(i).Item("fechareg").ToString())
                        dict.Add("usuarioreg", dt1.Rows(i).Item("usuarioreg").ToString())
                        dict.Add("fechamod", dt1.Rows(i).Item("fechamod").ToString())
                        dict.Add("usuariomod", dt1.Rows(i).Item("usuariomod").ToString())
                        dict.Add("problematica_inv", dt1.Rows(i).Item("problematica_inv").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstEvaluaciones2" Then
                Try
                    Dim oeEvaluacion As New eEvaluacion
                    Dim olEvaluacion As New lEvaluacion
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeEvaluacion.codpropietario_con = Request("param1").ToString()
                    oeEvaluacion.id_dgc = fn.DecrytedString64(Request("param2").ToString())

                    dt1 = olEvaluacion.listaEvaluaciones2(oeEvaluacion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo", fn.EncrytedString64(dt1.Rows(i).Item("nroficha_con").ToString()))
                        dict.Add("nroficha_con", dt1.Rows(i).Item("nroficha_con").ToString())
                        dict.Add("id_dgc", dt1.Rows(i).Item("id_dgc").ToString())
                        dict.Add("codregnac_con", dt1.Rows(i).Item("codregnac_con").ToString())
                        dict.Add("codpropietario_con", dt1.Rows(i).Item("codpropietario_con").ToString())
                        dict.Add("codexcavacion_con", dt1.Rows(i).Item("codexcavacion_con").ToString())
                        dict.Add("codrestauracion_con", dt1.Rows(i).Item("codrestauracion_con").ToString())
                        dict.Add("sector_con", dt1.Rows(i).Item("sector_con").ToString())
                        dict.Add("unidad_con", dt1.Rows(i).Item("unidad_con").ToString())
                        dict.Add("capa_con", dt1.Rows(i).Item("capa_con").ToString())
                        dict.Add("nivel_con", dt1.Rows(i).Item("nivel_con").ToString())
                        dict.Add("cuadricula_con", dt1.Rows(i).Item("cuadricula_con").ToString())
                        dict.Add("plano_con", dt1.Rows(i).Item("plano_con").ToString())
                        dict.Add("contexto_con", dt1.Rows(i).Item("contexto_con").ToString())
                        dict.Add("ubicontexto_con", dt1.Rows(i).Item("ubicontexto_con").ToString())
                        dict.Add("alturaobs_con", dt1.Rows(i).Item("alturaobs_con").ToString())
                        dict.Add("otrosdatos_con", dt1.Rows(i).Item("otrosdatos_con").ToString())
                        dict.Add("material_con", dt1.Rows(i).Item("material_con").ToString())
                        dict.Add("denominacion_con", dt1.Rows(i).Item("denominacion_con").ToString())
                        dict.Add("descripcion_con", dt1.Rows(i).Item("descripcion_con").ToString())
                        dict.Add("alto_con", dt1.Rows(i).Item("alto_con").ToString())
                        dict.Add("largo_con", dt1.Rows(i).Item("largo_con").ToString())
                        dict.Add("ancho_con", dt1.Rows(i).Item("ancho_con").ToString())
                        dict.Add("espesor_con", dt1.Rows(i).Item("espesor_con").ToString())
                        dict.Add("diametromax_con", dt1.Rows(i).Item("diametromax_con").ToString())
                        dict.Add("diametromin_con", dt1.Rows(i).Item("diametromin_con").ToString())
                        dict.Add("diametrobase_con", dt1.Rows(i).Item("diametrobase_con").ToString())
                        dict.Add("peso_con", dt1.Rows(i).Item("peso_con").ToString())
                        dict.Add("ubicinmueble_con", dt1.Rows(i).Item("ubicinmueble_con").ToString())
                        dict.Add("nrocaja_con", dt1.Rows(i).Item("nrocaja_con").ToString())
                        dict.Add("nrobolsa_con", dt1.Rows(i).Item("nrobolsa_con").ToString())
                        dict.Add("integridadbien_con", dt1.Rows(i).Item("integridadbien_con").ToString())
                        dict.Add("conservacionbien_con", dt1.Rows(i).Item("conservacionbien_con").ToString())
                        dict.Add("detconservacion_con", dt1.Rows(i).Item("detconservacion_con").ToString())
                        dict.Add("intervenciones_con", dt1.Rows(i).Item("intervenciones_con").ToString())
                        dict.Add("afectacion_con", dt1.Rows(i).Item("afectacion_con").ToString())
                        dict.Add("tratamiento_con", dt1.Rows(i).Item("tratamiento_con").ToString())
                        dict.Add("limpieza_con", dt1.Rows(i).Item("limpieza_con").ToString())
                        dict.Add("observaciones_con", dt1.Rows(i).Item("observaciones_con").ToString())
                        dict.Add("temperatura_con", dt1.Rows(i).Item("temperatura_con").ToString())
                        dict.Add("humedad_con", dt1.Rows(i).Item("humedad_con").ToString())
                        dict.Add("manipulacion_con", dt1.Rows(i).Item("manipulacion_con").ToString())
                        dict.Add("otros_con", dt1.Rows(i).Item("otros_con").ToString())
                        dict.Add("conservadorcargo_con", dt1.Rows(i).Item("conservadorcargo_con").ToString())
                        dict.Add("fecha_con", dt1.Rows(i).Item("fecha_con").ToString())
                        dict.Add("foto_con", dt1.Rows(i).Item("foto_con").ToString())
                        dict.Add("activo", dt1.Rows(i).Item("activo").ToString())
                        dict.Add("fechareg", dt1.Rows(i).Item("fechareg").ToString())
                        dict.Add("usuarioreg", dt1.Rows(i).Item("usuarioreg").ToString())
                        dict.Add("fechamod", dt1.Rows(i).Item("fechamod").ToString())
                        dict.Add("usuariomod", dt1.Rows(i).Item("usuariomod").ToString())
                        dict.Add("problematica_inv", dt1.Rows(i).Item("problematica_inv").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
            ElseIf Request("param0") = "lstTratamientoDGC" Then
                Try
                    Dim oeTratamiento As New eTratamiento
                    Dim olTratamiento As New lTratamiento
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeTratamiento.nroficha_tra = Request("param1").ToString()
                    oeTratamiento.id_dgc = fn.DecrytedString64(Request("param2").ToString())

                    dt1 = olTratamiento.listaTratamientos(oeTratamiento)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo", fn.EncrytedString64(dt1.Rows(i).Item("nroficha_tra").ToString()))
                        dict.Add("nroficha_tra", dt1.Rows(i).Item("nroficha_tra").ToString())
                        dict.Add("id_dgc", dt1.Rows(i).Item("id_dgc").ToString())
                        dict.Add("codregnac_tra", dt1.Rows(i).Item("codregnac_tra").ToString())
                        dict.Add("codpropietario_tra", dt1.Rows(i).Item("codpropietario_tra").ToString())
                        dict.Add("codexcavacion_tra", dt1.Rows(i).Item("codexcavacion_tra").ToString())
                        dict.Add("codrestauracion_tra", dt1.Rows(i).Item("codrestauracion_tra").ToString())
                        dict.Add("sector_tra", dt1.Rows(i).Item("sector_tra").ToString())
                        dict.Add("unidad_tra", dt1.Rows(i).Item("unidad_tra").ToString())
                        dict.Add("capa_tra", dt1.Rows(i).Item("capa_tra").ToString())
                        dict.Add("nivel_tra", dt1.Rows(i).Item("nivel_tra").ToString())
                        dict.Add("cuadricula_tra", dt1.Rows(i).Item("cuadricula_tra").ToString())
                        dict.Add("plano_tra", dt1.Rows(i).Item("plano_tra").ToString())
                        dict.Add("contexto_tra", dt1.Rows(i).Item("contexto_tra").ToString())
                        dict.Add("ubicontexto_tra", dt1.Rows(i).Item("ubicontexto_tra").ToString())
                        dict.Add("alturaobs_tra", dt1.Rows(i).Item("alturaobs_tra").ToString())
                        dict.Add("otrosdatos_tra", dt1.Rows(i).Item("otrosdatos_tra").ToString())
                        dict.Add("material_tra", dt1.Rows(i).Item("material_tra").ToString())
                        dict.Add("denominacion_tra", dt1.Rows(i).Item("denominacion_tra").ToString())
                        dict.Add("descripcion_tra", dt1.Rows(i).Item("descripcion_tra").ToString())
                        dict.Add("alto_tra", dt1.Rows(i).Item("alto_tra").ToString())
                        dict.Add("largo_tra", dt1.Rows(i).Item("largo_tra").ToString())
                        dict.Add("ancho_tra", dt1.Rows(i).Item("ancho_tra").ToString())
                        dict.Add("espesor_tra", dt1.Rows(i).Item("espesor_tra").ToString())
                        dict.Add("diametromax_tra", dt1.Rows(i).Item("diametromax_tra").ToString())
                        dict.Add("diametromin_tra", dt1.Rows(i).Item("diametromin_tra").ToString())
                        dict.Add("diametrobase_tra", dt1.Rows(i).Item("diametrobase_tra").ToString())
                        dict.Add("pesoini_tra", dt1.Rows(i).Item("pesoini_tra").ToString())
                        dict.Add("pesofin_tra", dt1.Rows(i).Item("pesofin_tra").ToString())
                        dict.Add("ubicinmueble_tra", dt1.Rows(i).Item("ubicinmueble_tra").ToString())
                        dict.Add("nrocaja_tra", dt1.Rows(i).Item("nrocaja_tra").ToString())
                        dict.Add("nrobolsa_tra", dt1.Rows(i).Item("nrobolsa_tra").ToString())
                        dict.Add("integridadbien_tra", dt1.Rows(i).Item("integridadbien_tra").ToString())
                        dict.Add("conservacionbien_tra", dt1.Rows(i).Item("conservacionbien_tra").ToString())
                        dict.Add("detconservacion_tra", dt1.Rows(i).Item("detconservacion_tra").ToString())
                        dict.Add("intervenciones_tra", dt1.Rows(i).Item("intervenciones_tra").ToString())
                        dict.Add("retiroconsolidante_tra", dt1.Rows(i).Item("retiroconsolidante_tra").ToString())
                        dict.Add("limpiezasuperf_tra", dt1.Rows(i).Item("limpiezasuperf_tra").ToString())
                        dict.Add("despegado_tra", dt1.Rows(i).Item("despegado_tra").ToString())
                        dict.Add("pegado_tra", dt1.Rows(i).Item("pegado_tra").ToString())
                        dict.Add("refuerzo_tra", dt1.Rows(i).Item("refuerzo_tra").ToString())
                        dict.Add("otros_tra", dt1.Rows(i).Item("otros_tra").ToString())
                        dict.Add("fini_tra", dt1.Rows(i).Item("fini_tra").ToString())
                        dict.Add("ffin_tra", dt1.Rows(i).Item("ffin_tra").ToString())
                        dict.Add("mecanica_tra", dt1.Rows(i).Item("mecanica_tra").ToString())
                        dict.Add("quimica_tra", dt1.Rows(i).Item("quimica_tra").ToString())
                        dict.Add("finilim_tra", dt1.Rows(i).Item("finilim_tra").ToString())
                        dict.Add("ffinlim_tra", dt1.Rows(i).Item("ffinlim_tra").ToString())
                        dict.Add("intervenido_tra", dt1.Rows(i).Item("intervenido_tra").ToString())
                        dict.Add("dettratamiento_tra", dt1.Rows(i).Item("dettratamiento_tra").ToString())
                        dict.Add("inhibicion_tra", dt1.Rows(i).Item("inhibicion_tra").ToString())
                        dict.Add("estabilizacion_tra", dt1.Rows(i).Item("estabilizacion_tra").ToString())
                        dict.Add("desalacion_tra", dt1.Rows(i).Item("desalacion_tra").ToString())
                        dict.Add("neutralizacion_tra", dt1.Rows(i).Item("neutralizacion_tra").ToString())
                        dict.Add("otrostrat_tra", dt1.Rows(i).Item("otrostrat_tra").ToString())
                        dict.Add("finitrat_tra", dt1.Rows(i).Item("finitrat_tra").ToString())
                        dict.Add("ffintrat_tra", dt1.Rows(i).Item("ffintrat_tra").ToString())
                        dict.Add("secadopost_tra", dt1.Rows(i).Item("secadopost_tra").ToString())
                        dict.Add("pegadopost_tra", dt1.Rows(i).Item("pegadopost_tra").ToString())
                        dict.Add("consolidacion_tra", dt1.Rows(i).Item("consolidacion_tra").ToString())
                        dict.Add("reintegracion_tra", dt1.Rows(i).Item("reintegracion_tra").ToString())
                        dict.Add("otrospost_tra", dt1.Rows(i).Item("otrospost_tra").ToString())
                        dict.Add("finipost_tra", dt1.Rows(i).Item("finipost_tra").ToString())
                        dict.Add("ffinpost_tra", dt1.Rows(i).Item("ffinpost_tra").ToString())
                        dict.Add("temperatura_tra", dt1.Rows(i).Item("temperatura_tra").ToString())
                        dict.Add("humedad_tra", dt1.Rows(i).Item("humedad_tra").ToString())
                        dict.Add("manipulacion_tra", dt1.Rows(i).Item("manipulacion_tra").ToString())
                        dict.Add("iluminacion_tra", dt1.Rows(i).Item("iluminacion_tra").ToString())
                        dict.Add("otrosrec_tra", dt1.Rows(i).Item("otrosrec_tra").ToString())
                        dict.Add("materialrec_tra", dt1.Rows(i).Item("materialrec_tra").ToString())
                        dict.Add("observaciones_tra", dt1.Rows(i).Item("observaciones_tra").ToString())
                        dict.Add("conservadorcargo_tra", dt1.Rows(i).Item("conservadorcargo_tra").ToString())
                        dict.Add("fecha_tra", dt1.Rows(i).Item("fecha_tra").ToString())
                        dict.Add("fotoini_tra", dt1.Rows(i).Item("fotoini_tra").ToString())
                        dict.Add("fotofin_tra", dt1.Rows(i).Item("fotofin_tra").ToString())
                        dict.Add("detalle_tra", dt1.Rows(i).Item("detalle_tra").ToString())
                        dict.Add("foto1_tra", dt1.Rows(i).Item("foto1_tra").ToString())
                        dict.Add("foto2_tra", dt1.Rows(i).Item("foto2_tra").ToString())
                        dict.Add("activo", dt1.Rows(i).Item("activo").ToString())
                        dict.Add("fechareg", dt1.Rows(i).Item("fechareg").ToString())
                        dict.Add("usuarioreg", dt1.Rows(i).Item("usuarioreg").ToString())
                        dict.Add("fechamod", dt1.Rows(i).Item("fechamod").ToString())
                        dict.Add("usuariomod", dt1.Rows(i).Item("usuariomod").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "listaPostTratemientos" Then
                Try
                    Dim oePostTratamiento As New ePostTratamiento
                    Dim olPostTratamiento As New lPostTratamiento
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oePostTratamiento.nroficha_ptr = Request("param1").ToString()
                    oePostTratamiento.id_dgc = fn.DecrytedString64(Request("param2").ToString())

                    dt1 = olPostTratamiento.listaPostTratemientos(oePostTratamiento)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("nroficha_ptr", dt1.Rows(i).Item("nroficha_ptr").ToString())
                        dict.Add("id_dgc", dt1.Rows(i).Item("id_dgc").ToString())
                        dict.Add("codregnac_ptr", dt1.Rows(i).Item("codregnac_ptr").ToString())
                        dict.Add("codpropietario_ptr", dt1.Rows(i).Item("codpropietario_ptr").ToString())
                        dict.Add("codexcavacion_ptr", dt1.Rows(i).Item("codexcavacion_ptr").ToString())
                        dict.Add("codrestauracion_ptr", dt1.Rows(i).Item("codrestauracion_ptr").ToString())
                        dict.Add("sector_ptr", dt1.Rows(i).Item("sector_ptr").ToString())
                        dict.Add("unidad_ptr", dt1.Rows(i).Item("unidad_ptr").ToString())
                        dict.Add("capa_ptr", dt1.Rows(i).Item("capa_ptr").ToString())
                        dict.Add("nivel_ptr", dt1.Rows(i).Item("nivel_ptr").ToString())
                        dict.Add("cuadricula_ptr", dt1.Rows(i).Item("cuadricula_ptr").ToString())
                        dict.Add("plano_ptr", dt1.Rows(i).Item("plano_ptr").ToString())
                        dict.Add("contexto_ptr", dt1.Rows(i).Item("contexto_ptr").ToString())
                        dict.Add("ubicontexto_ptr", dt1.Rows(i).Item("ubicontexto_ptr").ToString())
                        dict.Add("alturaobs_ptr", dt1.Rows(i).Item("alturaobs_ptr").ToString())
                        dict.Add("otrosdatos_ptr", dt1.Rows(i).Item("otrosdatos_ptr").ToString())
                        dict.Add("material_ptr", dt1.Rows(i).Item("material_ptr").ToString())
                        dict.Add("denominacion_ptr", dt1.Rows(i).Item("denominacion_ptr").ToString())
                        dict.Add("descripcion_ptr", dt1.Rows(i).Item("descripcion_ptr").ToString())
                        dict.Add("alto_ptr", dt1.Rows(i).Item("alto_ptr").ToString())
                        dict.Add("largo_ptr", dt1.Rows(i).Item("largo_ptr").ToString())
                        dict.Add("ancho_ptr", dt1.Rows(i).Item("ancho_ptr").ToString())
                        dict.Add("espesor_ptr", dt1.Rows(i).Item("espesor_ptr").ToString())
                        dict.Add("diametromax_ptr", dt1.Rows(i).Item("diametromax_ptr").ToString())
                        dict.Add("diametromin_ptr", dt1.Rows(i).Item("diametromin_ptr").ToString())
                        dict.Add("diametrobase_ptr", dt1.Rows(i).Item("diametrobase_ptr").ToString())
                        dict.Add("peso_ptr", dt1.Rows(i).Item("peso_ptr").ToString())
                        dict.Add("ubicinmueble_ptr", dt1.Rows(i).Item("ubicinmueble_ptr").ToString())
                        dict.Add("nrocaja_ptr", dt1.Rows(i).Item("nrocaja_ptr").ToString())
                        dict.Add("nrobolsa_ptr", dt1.Rows(i).Item("nrobolsa_ptr").ToString())
                        dict.Add("problematica_ptr", dt1.Rows(i).Item("problematica_ptr").ToString())
                        dict.Add("varicacion_ptr", dt1.Rows(i).Item("varicacion_ptr").ToString())
                        dict.Add("reacciones_ptr", dt1.Rows(i).Item("reacciones_ptr").ToString())
                        dict.Add("presentaafec_ptr", dt1.Rows(i).Item("presentaafec_ptr").ToString())
                        dict.Add("tipoafec_ptr", dt1.Rows(i).Item("tipoafec_ptr").ToString())
                        dict.Add("causaafec_ptr", dt1.Rows(i).Item("causaafec_ptr").ToString())
                        dict.Add("recomendaciones_ptr", dt1.Rows(i).Item("recomendaciones_ptr").ToString())
                        dict.Add("conservadorcargo_ptr", dt1.Rows(i).Item("conservadorcargo_ptr").ToString())
                        dict.Add("fecha_ptr", dt1.Rows(i).Item("fecha_ptr").ToString())
                        dict.Add("foto_ptr", dt1.Rows(i).Item("foto_ptr").ToString())
                        dict.Add("activo", dt1.Rows(i).Item("activo").ToString())
                        dict.Add("fechareg", dt1.Rows(i).Item("fechareg").ToString())
                        dict.Add("usuarioreg", dt1.Rows(i).Item("usuarioreg").ToString())
                        dict.Add("fechamod", dt1.Rows(i).Item("fechamod").ToString())
                        dict.Add("usuariomod", dt1.Rows(i).Item("usuariomod").ToString())

                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "listaAlmacenes" Then
                Try
                    Dim oeAlmacenes As New eAlmacenes
                    Dim olAlmacenes As New lAlmacenes
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeAlmacenes.nroficha_alm = Request("param1").ToString()
                    oeAlmacenes.id_dgc = fn.DecrytedString64(Request("param2").ToString())

                    dt1 = olAlmacenes.listaAlmacenes(oeAlmacenes)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("nroficha_alm", dt1.Rows(i).Item("nroficha_alm").ToString())
                        dict.Add("id_dgc", dt1.Rows(i).Item("id_dgc").ToString())
                        dict.Add("ambmonitoreo_alm", dt1.Rows(i).Item("ambmonitoreo_alm").ToString())
                        dict.Add("area_alm", dt1.Rows(i).Item("area_alm").ToString())
                        dict.Add("tipoestruct_alm", dt1.Rows(i).Item("tipoestruct_alm").ToString())
                        dict.Add("ventanas_alm", dt1.Rows(i).Item("ventanas_alm").ToString())
                        dict.Add("tipoluz_alm", dt1.Rows(i).Item("tipoluz_alm").ToString())
                        dict.Add("tipoaa_alm", dt1.Rows(i).Item("tipoaa_alm").ToString())
                        dict.Add("cantidadaa_alm", dt1.Rows(i).Item("cantidadaa_alm").ToString())
                        dict.Add("tipoex_alm", dt1.Rows(i).Item("tipoex_alm").ToString())
                        dict.Add("cantidadex_alm", dt1.Rows(i).Item("cantidadex_alm").ToString())
                        dict.Add("cantthermo_alm", dt1.Rows(i).Item("cantthermo_alm").ToString())
                        dict.Add("deshumedecedor_alm", dt1.Rows(i).Item("deshumedecedor_alm").ToString())
                        dict.Add("cantestantes_alm", dt1.Rows(i).Item("cantestantes_alm").ToString())
                        dict.Add("nivelesestantes_alm", dt1.Rows(i).Item("nivelesestantes_alm").ToString())
                        dict.Add("cajasplast_alm", dt1.Rows(i).Item("cajasplast_alm").ToString())
                        dict.Add("cajascarton_alm", dt1.Rows(i).Item("cajascarton_alm").ToString())
                        dict.Add("cajasmadera_alm", dt1.Rows(i).Item("cajasmadera_alm").ToString())
                        dict.Add("coleccion_alm", dt1.Rows(i).Item("coleccion_alm").ToString())
                        dict.Add("material_alm", dt1.Rows(i).Item("material_alm").ToString())
                        dict.Add("otros_alm", dt1.Rows(i).Item("otros_alm").ToString())
                        dict.Add("fechamonit_alm", dt1.Rows(i).Item("fechamonit_alm").ToString())
                        dict.Add("hringresoa_alm", dt1.Rows(i).Item("hringresoa_alm").ToString())
                        dict.Add("hrsalidaa_alm", dt1.Rows(i).Item("hrsalidaa_alm").ToString())
                        dict.Add("primeraTa_alm", dt1.Rows(i).Item("primeraTa_alm").ToString())
                        dict.Add("segundaTa_alm", dt1.Rows(i).Item("segundaTa_alm").ToString())
                        dict.Add("primeraHa_alm", dt1.Rows(i).Item("primeraHa_alm").ToString())
                        dict.Add("segundaHa_alm", dt1.Rows(i).Item("segundaHa_alm").ToString())
                        dict.Add("hringresop_alm", dt1.Rows(i).Item("hringresop_alm").ToString())
                        dict.Add("hrsalidap_alm", dt1.Rows(i).Item("hrsalidap_alm").ToString())
                        dict.Add("primeraTp_alm", dt1.Rows(i).Item("primeraTp_alm").ToString())
                        dict.Add("segundaTp_alm", dt1.Rows(i).Item("segundaTp_alm").ToString())
                        dict.Add("primeraHp_alm", dt1.Rows(i).Item("primeraHp_alm").ToString())
                        dict.Add("segundaHp_alm", dt1.Rows(i).Item("segundaHp_alm").ToString())
                        dict.Add("observaciones_alm", dt1.Rows(i).Item("observaciones_alm").ToString())
                        dict.Add("conservadorcargo_alm", dt1.Rows(i).Item("conservadorcargo_alm").ToString())
                        dict.Add("fecha_alm", dt1.Rows(i).Item("fecha_alm").ToString())
                        dict.Add("activo", dt1.Rows(i).Item("activo").ToString())
                        dict.Add("fechareg", dt1.Rows(i).Item("fechareg").ToString())
                        dict.Add("usuarioreg", dt1.Rows(i).Item("usuarioreg").ToString())
                        dict.Add("fechamod", dt1.Rows(i).Item("fechamod").ToString())
                        dict.Add("usuariomod", dt1.Rows(i).Item("usuariomod").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "RepInventarios" Then
                Try
                    Dim oeInventario As New eInventario
                    Dim olInventario As New lInventario
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeInventario.unidad_inv = fn.DecrytedString64(Request("param1").ToString())
                    oeInventario.tipomaterial_inv = fn.DecrytedString64(Request("param2").ToString())
                    oeInventario.id_dgc = fn.DecrytedString64(Request("param3").ToString())
                    dt1 = olInventario.RepInventarios(oeInventario)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    If Not dt1 Is Nothing AndAlso dt1.Rows.Count > 0 Then
                        For i As Integer = 0 To dt1.Rows.Count - 1
                            Dim dict As New Dictionary(Of String, Object)()
                            dict.Add("codigo", fn.EncrytedString64(dt1.Rows(i).Item("codpropietario_inv").ToString()))
                            dict.Add("codpropietario_inv", dt1.Rows(i).Item("codpropietario_inv").ToString())
                            dict.Add("id_inv", dt1.Rows(i).Item("id_inv").ToString())
                            dict.Add("nro_inv", dt1.Rows(i).Item("nro_inv").ToString())
                            dict.Add("proyecto_inv", dt1.Rows(i).Item("proyecto_inv").ToString())
                            dict.Add("temporada_inv", dt1.Rows(i).Item("temporada_inv").ToString())
                            dict.Add("sector_inv", dt1.Rows(i).Item("sector_inv").ToString())
                            dict.Add("subsector_inv", dt1.Rows(i).Item("subsector_inv").ToString())
                            dict.Add("unidad_inv", dt1.Rows(i).Item("unidad_inv").ToString())
                            dict.Add("capa_inv", dt1.Rows(i).Item("capa_inv").ToString())
                            dict.Add("nivel_inv", dt1.Rows(i).Item("nivel_inv").ToString())
                            dict.Add("cuadricula_inv", dt1.Rows(i).Item("cuadricula_inv").ToString())
                            dict.Add("contexto_inv", dt1.Rows(i).Item("contexto_inv").ToString())
                            dict.Add("plano_inv", dt1.Rows(i).Item("plano_inv").ToString())
                            dict.Add("tipomaterial_inv", dt1.Rows(i).Item("tipomaterial_inv").ToString())
                            dict.Add("descripcion_inv", dt1.Rows(i).Item("descripcion_inv").ToString())
                            dict.Add("cultura_inv", dt1.Rows(i).Item("cultura_inv").ToString())
                            'dict.Add("dcultura_inv", dt1.Rows(i).Item("dcultura_inv").ToString())
                            dict.Add("estilo_inv", dt1.Rows(i).Item("estilo_inv").ToString())
                            dict.Add("otrosdatos_inv", dt1.Rows(i).Item("otrosdatos_inv").ToString())
                            dict.Add("nrocaja_inv", dt1.Rows(i).Item("nrocaja_inv").ToString())
                            dict.Add("nrobolsa_inv", dt1.Rows(i).Item("nrobolsa_inv").ToString())
                            dict.Add("codexcavacion_inv", dt1.Rows(i).Item("codexcavacion_inv").ToString())
                            dict.Add("ini_rotulacion_inv", dt1.Rows(i).Item("ini_rotulacion_inv").ToString())
                            dict.Add("fin_rotulacion_inv", dt1.Rows(i).Item("fin_rotulacion_inv").ToString())
                            dict.Add("cantidad_inv", dt1.Rows(i).Item("cantidad_inv").ToString())
                            dict.Add("peso_inv", dt1.Rows(i).Item("peso_inv").ToString())
                            dict.Add("fechaalmacen_inv", dt1.Rows(i).Item("fechaalmacen_inv").ToString())
                            dict.Add("registro_inv", dt1.Rows(i).Item("registro_inv").ToString())
                            dict.Add("almacen_inv", dt1.Rows(i).Item("almacen_inv").ToString())
                            dict.Add("estante_inv", dt1.Rows(i).Item("estante_inv").ToString())
                            dict.Add("observacion_inv", dt1.Rows(i).Item("observacion_inv").ToString())
                            dict.Add("fechareg", dt1.Rows(i).Item("fechareg").ToString())
                            dict.Add("usuarioreg", dt1.Rows(i).Item("usuarioreg").ToString())
                            dict.Add("activo_inv", dt1.Rows(i).Item("activo_inv").ToString())
                            dict.Add("id_dgc", dt1.Rows(i).Item("id_dgc").ToString())
                            list.Add(dict)
                        Next
                    End If
                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstCatalogosDGC" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeCatologo.nrodocumento_cat = fn.DecrytedString64(Request("param1").ToString())

                    dt1 = olCatologo.ListarCatalogosDGC(oeCatologo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("codigo", fn.EncrytedString64(dt1.Rows(i).Item("codpropietario_cat").ToString()))
                        dict.Add("propietario", dt1.Rows(i).Item("codpropietario_cat").ToString())
                        dict.Add("codregnac_cat", dt1.Rows(i).Item("codregnac_cat").ToString())
                        dict.Add("codexcavacion_cat", dt1.Rows(i).Item("codexcavacion_cat").ToString())
                        dict.Add("codreginc_cat", dt1.Rows(i).Item("codreginc_cat").ToString())
                        dict.Add("codinvinc_cat", dt1.Rows(i).Item("codinvinc_cat").ToString())
                        dict.Add("otrocodigos_cat", dt1.Rows(i).Item("otrocodigos_cat").ToString())
                        dict.Add("cultura_cat", dt1.Rows(i).Item("cultura_cat").ToString())
                        dict.Add("estilo_cat", dt1.Rows(i).Item("estilo_cat").ToString())
                        dict.Add("periodo_cat", dt1.Rows(i).Item("periodo_cat").ToString())
                        dict.Add("cronologia_cat", dt1.Rows(i).Item("cronologia_cat").ToString())
                        dict.Add("areageografica_cat", dt1.Rows(i).Item("areageografica_cat").ToString())
                        dict.Add("origenclasif_cat", dt1.Rows(i).Item("origenclasif_cat").ToString())
                        dict.Add("nombreclasif_cat", dt1.Rows(i).Item("nombreclasif_cat").ToString())
                        dict.Add("region_cat", dt1.Rows(i).Item("region_cat").ToString())
                        dict.Add("valle_cat", dt1.Rows(i).Item("valle_cat").ToString())
                        dict.Add("margen_cat", dt1.Rows(i).Item("margen_cat").ToString())
                        dict.Add("provieneexcav_cat", dt1.Rows(i).Item("provieneexcav_cat").ToString())
                        dict.Add("sector_cat", dt1.Rows(i).Item("sector_cat").ToString())
                        dict.Add("unidad_cat", dt1.Rows(i).Item("unidad_cat").ToString())
                        dict.Add("capa_cat", dt1.Rows(i).Item("capa_cat").ToString())
                        dict.Add("nivel_cat", dt1.Rows(i).Item("nivel_cat").ToString())
                        dict.Add("cuadricula_cat", dt1.Rows(i).Item("cuadricula_cat").ToString())
                        dict.Add("plano_cat", dt1.Rows(i).Item("plano_cat").ToString())
                        dict.Add("contexto_cat", dt1.Rows(i).Item("contexto_cat").ToString())
                        dict.Add("ubicacioncontexto_cat", dt1.Rows(i).Item("ubicacioncontexto_cat").ToString())
                        dict.Add("alturaabs_cat", dt1.Rows(i).Item("alturaabs_cat").ToString())
                        dict.Add("otrosdatos_cat", dt1.Rows(i).Item("otrosdatos_cat").ToString())
                        dict.Add("material_cat", dt1.Rows(i).Item("material_cat").ToString())
                        dict.Add("tipo_cat", dt1.Rows(i).Item("tipo_cat").ToString())
                        dict.Add("denominacion_cat", dt1.Rows(i).Item("denominacion_cat").ToString())
                        dict.Add("manufactura_cat", dt1.Rows(i).Item("manufactura_cat").ToString())
                        dict.Add("decoracion_cat", dt1.Rows(i).Item("decoracion_cat").ToString())
                        dict.Add("descripcion_cat", dt1.Rows(i).Item("descripcion_cat").ToString())
                        dict.Add("colores_cat", dt1.Rows(i).Item("colores_cat").ToString())
                        dict.Add("acabadosuperf_cat", dt1.Rows(i).Item("acabadosuperf_cat").ToString())
                        dict.Add("representaciones_cat", dt1.Rows(i).Item("representaciones_cat").ToString())
                        dict.Add("motivodecorativo_cat", dt1.Rows(i).Item("motivodecorativo_cat").ToString())
                        dict.Add("alto_cat", dt1.Rows(i).Item("alto_cat").ToString())
                        dict.Add("largo_cat", dt1.Rows(i).Item("largo_cat").ToString())
                        dict.Add("ancho_cat", dt1.Rows(i).Item("ancho_cat").ToString())
                        dict.Add("espesor_cat", dt1.Rows(i).Item("espesor_cat").ToString())
                        dict.Add("diametromax_cat", dt1.Rows(i).Item("diametromax_cat").ToString())
                        dict.Add("diametromin_cat", dt1.Rows(i).Item("diametromin_cat").ToString())
                        dict.Add("diametrobase_cat", dt1.Rows(i).Item("diametrobase_cat").ToString())
                        dict.Add("peso_cat", dt1.Rows(i).Item("peso_cat").ToString())
                        dict.Add("tipopropietario_cat", dt1.Rows(i).Item("tipopropietario_cat").ToString())
                        dict.Add("propietario_cat", dt1.Rows(i).Item("propietario_cat").ToString())
                        dict.Add("tipocustodio_cat", dt1.Rows(i).Item("tipocustodio_cat").ToString())
                        dict.Add("nombrecustodio_cat", dt1.Rows(i).Item("nombrecustodio_cat").ToString())
                        dict.Add("adquisicion_cat", dt1.Rows(i).Item("adquisicion_cat").ToString())
                        dict.Add("referenciaadq_cat", dt1.Rows(i).Item("referenciaadq_cat").ToString())
                        dict.Add("direccioninmueble_cat", dt1.Rows(i).Item("direccioninmueble_cat").ToString())
                        dict.Add("nombreinmueble_cat", dt1.Rows(i).Item("nombreinmueble_cat").ToString())
                        dict.Add("ubicacionespecif_cat", dt1.Rows(i).Item("ubicacionespecif_cat").ToString())
                        dict.Add("situacion_cat", dt1.Rows(i).Item("situacion_cat").ToString())
                        dict.Add("pisovitrina_cat", dt1.Rows(i).Item("pisovitrina_cat").ToString())
                        dict.Add("almacenanaquel_cat", dt1.Rows(i).Item("almacenanaquel_cat").ToString())
                        dict.Add("cajacontenedor_cat", dt1.Rows(i).Item("cajacontenedor_cat").ToString())
                        dict.Add("bolsa_cat", dt1.Rows(i).Item("bolsa_cat").ToString())
                        dict.Add("frontal", fn.EncrytedString64(dt1.Rows(i).Item("frontal").ToString()))
                        dict.Add("lateral", fn.EncrytedString64(dt1.Rows(i).Item("lateral").ToString()))
                        dict.Add("otras", fn.EncrytedString64(dt1.Rows(i).Item("otras").ToString()))
                        dict.Add("detalle", fn.EncrytedString64(dt1.Rows(i).Item("detalle").ToString()))
                        dict.Add("dibujo", fn.EncrytedString64(dt1.Rows(i).Item("dibujo").ToString()))
                        dict.Add("fichacampoelab_cat", dt1.Rows(i).Item("fichacampoelab_cat").ToString())
                        dict.Add("fechafichacampo_cat", dt1.Rows(i).Item("fechafichacampo_cat").ToString())
                        dict.Add("fototomada_cat", dt1.Rows(i).Item("fototomada_cat").ToString())
                        dict.Add("fechafoto", dt1.Rows(i).Item("fechafoto").ToString())
                        dict.Add("tipodoc_cat", dt1.Rows(i).Item("tipodoc_cat").ToString())
                        dict.Add("nrodocumento_cat", dt1.Rows(i).Item("nrodocumento_cat").ToString())
                        dict.Add("fechadocumento_cat", dt1.Rows(i).Item("fechadocumento_cat").ToString())
                        dict.Add("otrasreferencias_cat", dt1.Rows(i).Item("otrasreferencias_cat").ToString())
                        dict.Add("fechareg", dt1.Rows(i).Item("fechareg").ToString())
                        dict.Add("usuarioreg", dt1.Rows(i).Item("usuarioreg").ToString())
                        dict.Add("fechamod", dt1.Rows(i).Item("fechamod").ToString())
                        dict.Add("usuariomod", dt1.Rows(i).Item("usuariomod").ToString())
                        dict.Add("activo_cat", dt1.Rows(i).Item("activo_cat").ToString())
                        dict.Add("id_dgc", dt1.Rows(i).Item("id_dgc").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "RepCatologos" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt1 As New DataTable
                    Dim fn As New lFunciones
                    oeCatologo.unidad_cat = Request("param1").ToString()
                    oeCatologo.contexto_cat = Request("param2").ToString()
                    oeCatologo.material_cat = Request("param3").ToString()
                    oeCatologo.id_dgc = fn.DecrytedString64(Request("param4").ToString())
                    dt1 = olCatologo.RepCatalogos(oeCatologo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    If Not dt1 Is Nothing AndAlso dt1.Rows.Count > 0 Then
                        For i As Integer = 0 To dt1.Rows.Count - 1
                            Dim dict As New Dictionary(Of String, Object)()
                            dict.Add("codigo", fn.EncrytedString64(dt1.Rows(i).Item("Cod_Propietario").ToString()))
                            dict.Add("Cod_Propietario", dt1.Rows(i).Item("Cod_Propietario").ToString())
                            dict.Add("Cod_RegistroNacional", dt1.Rows(i).Item("Cod_RegistroNacional").ToString())
                            dict.Add("Cod_Excavacion", dt1.Rows(i).Item("Cod_Excavacion").ToString())
                            dict.Add("Cod_RegistroINC", dt1.Rows(i).Item("Cod_RegistroINC").ToString())
                            'dict.Add("codinvinc_cat", dt1.Rows(i).Item("codinvinc_cat").ToString())
                            dict.Add("Cod_Otros", dt1.Rows(i).Item("Cod_Otros").ToString())
                            dict.Add("Cultura", dt1.Rows(i).Item("Cultura").ToString())
                            dict.Add("Estilo", dt1.Rows(i).Item("Estilo").ToString())
                            dict.Add("Periodo", dt1.Rows(i).Item("Periodo").ToString())
                            dict.Add("Cronologia", dt1.Rows(i).Item("Cronologia").ToString())
                            dict.Add("Area_Geografica", dt1.Rows(i).Item("Area_Geografica").ToString())
                            dict.Add("Origen_Clasif", dt1.Rows(i).Item("Origen_Clasif").ToString())
                            dict.Add("Nombre_Clasif", dt1.Rows(i).Item("Nombre_Clasif").ToString())
                            dict.Add("Region", dt1.Rows(i).Item("Region").ToString())
                            dict.Add("Valle", dt1.Rows(i).Item("Valle").ToString())
                            dict.Add("Margen", dt1.Rows(i).Item("Margen").ToString())
                            dict.Add("Proviene_Excav", dt1.Rows(i).Item("Proviene_Excav").ToString())
                            dict.Add("Sector", dt1.Rows(i).Item("Sector").ToString())
                            dict.Add("Unidad", dt1.Rows(i).Item("Unidad").ToString())
                            dict.Add("Capa", dt1.Rows(i).Item("Capa").ToString())
                            dict.Add("Nivel", dt1.Rows(i).Item("Nivel").ToString())
                            dict.Add("Cuadricula", dt1.Rows(i).Item("Cuadricula").ToString())
                            dict.Add("Plano", dt1.Rows(i).Item("Plano").ToString())
                            dict.Add("Contexto", dt1.Rows(i).Item("Contexto").ToString())
                            dict.Add("Ubicacion_Contexto", dt1.Rows(i).Item("Ubicacion_Contexto").ToString())
                            dict.Add("Altura_Abs", dt1.Rows(i).Item("Altura_Abs").ToString())
                            dict.Add("Otros_Datos", dt1.Rows(i).Item("Otros_Datos").ToString())
                            dict.Add("Material", dt1.Rows(i).Item("Material").ToString())
                            dict.Add("Tipo", dt1.Rows(i).Item("Tipo").ToString())
                            dict.Add("Denominacion", dt1.Rows(i).Item("Denominacion").ToString())
                            dict.Add("Manufactura", dt1.Rows(i).Item("Manufactura").ToString())
                            dict.Add("Decoracion", dt1.Rows(i).Item("Decoracion").ToString())
                            dict.Add("Descripcion", dt1.Rows(i).Item("Descripcion").ToString())
                            dict.Add("Colores", dt1.Rows(i).Item("Colores").ToString())
                            dict.Add("Acabado_Superf", dt1.Rows(i).Item("Acabado_Superf").ToString())
                            dict.Add("Representaciones", dt1.Rows(i).Item("Representaciones").ToString())
                            dict.Add("Motivo_Decorativo", dt1.Rows(i).Item("Motivo_Decorativo").ToString())
                            dict.Add("alto", dt1.Rows(i).Item("alto").ToString())
                            dict.Add("Largo", dt1.Rows(i).Item("Largo").ToString())
                            dict.Add("Ancho", dt1.Rows(i).Item("Ancho").ToString())
                            dict.Add("Espesor", dt1.Rows(i).Item("Espesor").ToString())
                            dict.Add("Diametro_Max", dt1.Rows(i).Item("Diametro_Max").ToString())
                            dict.Add("Diametro_Min", dt1.Rows(i).Item("Diametro_Min").ToString())
                            dict.Add("Diametro_Base", dt1.Rows(i).Item("Diametro_Base").ToString())
                            dict.Add("Peso", dt1.Rows(i).Item("Peso").ToString())
                            dict.Add("Tipo_Propietario", dt1.Rows(i).Item("Tipo_Propietario").ToString())
                            dict.Add("Propietario", dt1.Rows(i).Item("Propietario").ToString())
                            dict.Add("Tipo_Custodio", dt1.Rows(i).Item("Tipo_Custodio").ToString())
                            dict.Add("Nombre_Custodio", dt1.Rows(i).Item("Nombre_Custodio").ToString())
                            dict.Add("Adquisicion", dt1.Rows(i).Item("Adquisicion").ToString())
                            dict.Add("Referencia_Adq", dt1.Rows(i).Item("Referencia_Adq").ToString())
                            dict.Add("Direccion_Inmueble", dt1.Rows(i).Item("Direccion_Inmueble").ToString())
                            dict.Add("Nombre_Inmueble", dt1.Rows(i).Item("Nombre_Inmueble").ToString())
                            dict.Add("Ubicación_Especifica", dt1.Rows(i).Item("Ubicación_Especifica").ToString())
                            dict.Add("Situacion", dt1.Rows(i).Item("Situacion").ToString())
                            dict.Add("Piso_vitrina", dt1.Rows(i).Item("Piso_vitrina").ToString())
                            dict.Add("Almacen_Anaquel", dt1.Rows(i).Item("Almacen_Anaquel").ToString())
                            dict.Add("Caja_Contenedor", dt1.Rows(i).Item("Caja_Contenedor").ToString())
                            dict.Add("Bolsa", dt1.Rows(i).Item("Bolsa").ToString())
                            dict.Add("Vista_Frontal", fn.EncrytedString64(dt1.Rows(i).Item("Vista_Frontal").ToString()))
                            dict.Add("Vista_Lateral", fn.EncrytedString64(dt1.Rows(i).Item("Vista_Lateral").ToString()))
                            dict.Add("Otras_Vistas", fn.EncrytedString64(dt1.Rows(i).Item("Otras_Vistas").ToString()))
                            dict.Add("Detalle", fn.EncrytedString64(dt1.Rows(i).Item("Detalle").ToString()))
                            dict.Add("Dibujo", fn.EncrytedString64(dt1.Rows(i).Item("Dibujo").ToString()))
                            dict.Add("Ficha_Campo", dt1.Rows(i).Item("Ficha_Campo").ToString())
                            dict.Add("Fecha_FichaCampo", dt1.Rows(i).Item("Fecha_FichaCampo").ToString())
                            dict.Add("Foto_tomada", dt1.Rows(i).Item("Foto_tomada").ToString())
                            dict.Add("Fecha_foto", dt1.Rows(i).Item("Fecha_foto").ToString())
                            dict.Add("Tipo_Doc", dt1.Rows(i).Item("Tipo_Doc").ToString())
                            dict.Add("Nro_Doc", dt1.Rows(i).Item("Nro_Doc").ToString())
                            dict.Add("Fecha_Doc", dt1.Rows(i).Item("Fecha_Doc").ToString())
                            dict.Add("Otras_Referencias", dt1.Rows(i).Item("Otras_Referencias").ToString())
                            dict.Add("Fecha_Reg", dt1.Rows(i).Item("Fecha_Reg").ToString())
                            list.Add(dict)
                        Next
                    End If

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "DelUsuFn" Then
                Try
                    Dim oeUsuario As New eUsuario
                    Dim olUsuario As New lUsuario
                    Dim dt As New DataTable
                    Dim fn As New lFunciones

                    oeUsuario.codigo_Men = fn.DecrytedString64(Request("param1").ToString)
                    oeUsuario.param1 = "JSeclen"
                    'oeUsuario.param1 = session("")
                    dt = olUsuario.eliminarUsuarioFn(oeUsuario)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        dict.Add("alert", dt.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt.Rows(i).Item("Msje").ToString())
                        dict.Add("Code", dt.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lst" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt As New DataTable
                    oeCatologo.TipoOperacion = Request("param1").ToString()

                    dt = olCatologo.listaCombos(oeCatologo)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    Dim sele As String = "0"
                    For i As Integer = 0 To dt.Rows.Count
                        Dim dict As New Dictionary(Of String, Object)()
                        If (sele = "0") Then
                            dict.Add("valor", 0)
                            dict.Add("descripcion", "-- Seleccione --")
                            dict.Add("selected", "selected")
                            sele = "1"
                        Else
                            dict.Add("valor", dt.Rows(i - 1).Item("valor").ToString())
                            dict.Add("descripcion", dt.Rows(i - 1).Item("descripcion").ToString())
                            dict.Add("selected", "")
                        End If
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "CboPublicaciones" Then
                Try
                    Dim oePublicacion As New ePublicacion
                    Dim olPublicaciones As New lPublicaciones
                    Dim dt As New DataTable
                    oePublicacion.TipoOperacion = Request("param1").ToString()

                    dt = olPublicaciones.listaCombosPublicacion(oePublicacion)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    Dim sele As String = "0"
                    For i As Integer = 0 To dt.Rows.Count
                        Dim dict As New Dictionary(Of String, Object)()
                        If (sele = "0") Then
                            dict.Add("valor", 0)
                            dict.Add("descripcion", "-- Seleccione --")
                            dict.Add("selected", "selected")
                            sele = "1"
                        Else
                            dict.Add("valor", dt.Rows(i - 1).Item("valor").ToString())
                            dict.Add("descripcion", dt.Rows(i - 1).Item("descripcion").ToString())
                            dict.Add("selected", "")
                        End If
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gPublicacion1" Then
                Try
                    Dim oePublicacion As New ePublicacion
                    Dim olPublicaciones As New lPublicaciones
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oePublicacion.numero = Request("txtnro").ToString()
                    oePublicacion.denominacion_pub = Request("txtDenominacion").ToString()
                    oePublicacion.codpropietario_pub = Request("txtCodPropietario").ToString()
                    oePublicacion.codexcavacion_pub = Request("txtCodigoExcavacion").ToString()
                    oePublicacion.sitio_pub = Request("txtSitio").ToString()
                    oePublicacion.contexto_pub = Request("txtContexto").ToString()
                    oePublicacion.usuariomod = Session("dni")

                    If (Request("pub").ToString() = "") Then
                        oePublicacion.param1 = 0
                    Else
                        oePublicacion.param1 = fn.DecrytedString64(Request("pub").ToString())

                    End If
                    dt1 = olPublicaciones.actualizarPublicaciones(oePublicacion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gPublicacion2" Then
                Try
                    Dim oePublicacion As New ePublicacion
                    Dim olPublicaciones As New lPublicaciones
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oePublicacion.presentabio_pub = Request("cbPresentaBio").ToString()
                    oePublicacion.tipobio_pub = Request("cbTipoBio").ToString()
                    oePublicacion.autores_pub = Request("txtAutor").ToString()
                    oePublicacion.titulo_pub = Request("txtTitulo").ToString()
                    If Request("txtAnioPub").ToString() = "" Then
                        oePublicacion.anio_pub = 0
                    Else
                        oePublicacion.anio_pub = Request("txtAnioPub").ToString()
                    End If
                    oePublicacion.titulolibro_pub = Request("txtTituloLibro").ToString()
                    If Request("txtEdicion").ToString() = "" Then
                        oePublicacion.edicion_pub = 0
                    Else
                        oePublicacion.edicion_pub = Request("txtEdicion").ToString()
                    End If
                    If Request("txtPaginas").ToString() = "" Then
                        oePublicacion.paginas_pub = 0
                    Else
                        oePublicacion.paginas_pub = Request("txtPaginas").ToString()
                    End If
                    If Request("txtNroFigura").ToString() = "" Then
                        oePublicacion.nrofigura_pub = 0
                    Else
                        oePublicacion.nrofigura_pub = Request("txtNroFigura").ToString()
                    End If
                    If Request("txtVolumen").ToString() = "" Then
                        oePublicacion.volumen_pub = 0
                    Else
                        oePublicacion.volumen_pub = Request("txtVolumen").ToString()
                    End If
                    oePublicacion.seccion = Request("txtSeccion").ToString()
                    oePublicacion.fechaconsulta_pub = Request("txtFechaConsulta").ToString()
                    oePublicacion.param2 = Request("txtDirElect").ToString()
                    oePublicacion.usuarioreg = Session("dni")
                    oePublicacion.param1 = fn.DecrytedString64(Request("pub").ToString())

                    dt1 = olPublicaciones.actualizarPublicaciones2(oePublicacion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "DelPublicacion" Then
                Try
                    Dim oePublicacion As New ePublicacion
                    Dim olPublicaciones As New lPublicaciones
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oePublicacion.param1 = fn.DecrytedString64(Request("param1").ToString())

                    dt1 = olPublicaciones.eliminarPublicacion(oePublicacion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstPublicaciones" Then
                Try
                    Dim oePublicacion As New ePublicacion
                    Dim olPublicaciones As New lPublicaciones
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oePublicacion.param1 = Request("param1").ToString()

                    dt1 = olPublicaciones.listarPublicaciones(oePublicacion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    If Not dt1 Is Nothing AndAlso (dt1.Rows.Count > 0) Then
                        For i As Integer = 0 To dt1.Rows.Count - 1
                            Dim dict As New Dictionary(Of String, Object)()
                            dict.Add("numero", dt1.Rows(i).Item("numero").ToString())
                            dict.Add("denominacion", dt1.Rows(i).Item("denominacion_pub").ToString())
                            dict.Add("numeroe", fn.EncrytedString64(dt1.Rows(i).Item("numero").ToString()))
                            dict.Add("codpropietario", dt1.Rows(i).Item("codpropietario_pub").ToString())
                            dict.Add("codexcavacion", dt1.Rows(i).Item("codexcavacion_pub").ToString())
                            dict.Add("sitio", dt1.Rows(i).Item("sitio_pub").ToString())
                            dict.Add("contexto", dt1.Rows(i).Item("contexto_pub").ToString())
                            dict.Add("presentabio", dt1.Rows(i).Item("presentabio_pub").ToString())
                            dict.Add("tipobio", dt1.Rows(i).Item("tipobio_pub").ToString())
                            dict.Add("autores", dt1.Rows(i).Item("autores_pub").ToString())
                            dict.Add("titulo", dt1.Rows(i).Item("titulo_pub").ToString())
                            dict.Add("anio", dt1.Rows(i).Item("anio_pub").ToString())
                            dict.Add("titulolibro", dt1.Rows(i).Item("titulolibro_pub").ToString())
                            dict.Add("edicion", dt1.Rows(i).Item("edicion_pub").ToString())
                            dict.Add("paginas", dt1.Rows(i).Item("paginas_pub").ToString())
                            dict.Add("nrofigura", dt1.Rows(i).Item("nrofigura_pub").ToString())
                            dict.Add("volumen", dt1.Rows(i).Item("volumen_pub").ToString())
                            dict.Add("seccion", dt1.Rows(i).Item("seccion").ToString())
                            dict.Add("fechaconsulta", dt1.Rows(i).Item("fechaconsulta_pub").ToString())
                            dict.Add("direccionelect", dt1.Rows(i).Item("direccionelect_pub").ToString())
                            list.Add(dict)
                        Next
                    End If
                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "lstExposiciones" Then
                Try
                    Dim oeExposicion As New eExposicion
                    Dim olExposicion As New lExposiciones
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeExposicion.param1 = Request("param1").ToString()

                    dt1 = olExposicion.listarExposiciones(oeExposicion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    If Not dt1 Is Nothing AndAlso (dt1.Rows.Count > 0) Then
                        For i As Integer = 0 To dt1.Rows.Count - 1
                            Dim dict As New Dictionary(Of String, Object)()
                            dict.Add("numero", fn.EncrytedString64(dt1.Rows(i).Item("numero").ToString()))
                            dict.Add("numeroe", dt1.Rows(i).Item("numero").ToString())
                            dict.Add("codregnac", dt1.Rows(i).Item("codregnac_exp").ToString())
                            dict.Add("codpropietario", dt1.Rows(i).Item("codpropietario_exp").ToString())
                            dict.Add("codexcavacion", dt1.Rows(i).Item("codexcavacion_exp").ToString())
                            dict.Add("otroscodigos", dt1.Rows(i).Item("otroscodigos_exp").ToString())
                            dict.Add("denominacion", dt1.Rows(i).Item("denominacion_exp").ToString())
                            dict.Add("sitio", dt1.Rows(i).Item("sitio_exp").ToString())
                            dict.Add("contexto", dt1.Rows(i).Item("contexto_exp").ToString())
                            dict.Add("nombre", dt1.Rows(i).Item("nombre_exp").ToString())
                            dict.Add("lugar", dt1.Rows(i).Item("lugar_exp").ToString())
                            dict.Add("pais", dt1.Rows(i).Item("pais_exp").ToString())
                            dict.Add("inmueble", dt1.Rows(i).Item("inmueble_exp").ToString())
                            dict.Add("resolucacion", dt1.Rows(i).Item("resolucacion_exp").ToString())
                            dict.Add("institucion", dt1.Rows(i).Item("institucion_exp").ToString())
                            dict.Add("comisario", dt1.Rows(i).Item("comisario_exp").ToString())
                            dict.Add("nropiliza", dt1.Rows(i).Item("nropiliza_exp").ToString())
                            dict.Add("monto_exp", dt1.Rows(i).Item("monto_exp").ToString())
                            dict.Add("salida", dt1.Rows(i).Item("salida_exp").ToString())
                            dict.Add("retorno", dt1.Rows(i).Item("retorno_exp").ToString())
                            dict.Add("activo", dt1.Rows(i).Item("activo_exp").ToString())
                            list.Add(dict)
                        Next
                    End If
                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "gExposicion1" Then
                Try
                    Dim oeExposicion As New eExposicion
                    Dim olExposiciones As New lExposiciones
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeExposicion.numero = Request("txtnro").ToString()
                    oeExposicion.codregnac_exp = Request("txtRegNac").ToString()
                    oeExposicion.codpropietario_exp = Request("txtCodPropietario").ToString()
                    oeExposicion.codexcavacion_exp = Request("txtCodigoExcavacion").ToString()
                    oeExposicion.otroscodigos_exp = Request("txtOtrosCod").ToString()
                    oeExposicion.usuariomod = Session("dni")

                    If (Request("exp").ToString() = "") Then
                        oeExposicion.param1 = 0
                    Else
                        oeExposicion.param1 = fn.DecrytedString64(Request("exp").ToString())

                    End If
                    dt1 = olExposiciones.actualizarExposiciones(oeExposicion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gExposicion2" Then
                Try
                    Dim oeExposicion As New eExposicion
                    Dim olExposiciones As New lExposiciones
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeExposicion.denominacion_exp = Request("txtDenominacion").ToString()
                    oeExposicion.sitio_exp = Request("txtSitio").ToString()
                    oeExposicion.contexto_exp = Request("txtContexto").ToString()
                    oeExposicion.nombre_exp = Request("txtNombreExp").ToString()
                    oeExposicion.lugar_exp = Request("txtLugar").ToString()
                    oeExposicion.pais_exp = Request("txtPais").ToString()
                    oeExposicion.inmueble_exp = Request("txtInmueble").ToString()
                    oeExposicion.resolucacion_exp = Request("txtResolucion").ToString()
                    oeExposicion.institucion_exp = Request("txtInstitucion").ToString()
                    oeExposicion.comisario_exp = Request("txtComisario").ToString()
                    oeExposicion.salida_exp = Request("txtSalida").ToString()
                    oeExposicion.retorno_exp = Request("txtRetorno").ToString()
                    oeExposicion.nropiliza_exp = Request("txtPoliza").ToString()
                    oeExposicion.monto_exp = Request("txtMonto").ToString()
                    oeExposicion.usuarioreg = Session("dni")
                    oeExposicion.param1 = fn.DecrytedString64(Request("exp").ToString())

                    dt1 = olExposiciones.actualizarExposiciones2(oeExposicion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try


            ElseIf Request("param0") = "DelExposicion" Then
                Try
                    Dim oeExposicion As New eExposicion
                    Dim olExposiciones As New lExposiciones
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable
                    oeExposicion.param1 = fn.DecrytedString64(Request("param1").ToString())

                    dt1 = olExposiciones.eliminarExposicion(oeExposicion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "cboAnioPublicaciones" Then
                Try
                    Dim oePublicacion As New ePublicacion
                    Dim olPublicaciones As New lPublicaciones
                    Dim dt As New DataTable
                    Dim fn As New lFunciones

                    dt = olPublicaciones.listaCombosAnioPublicaciones(oePublicacion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    Dim sele As String = "0"
                    For i As Integer = 0 To dt.Rows.Count
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        If (sele = "0") Then
                            dict.Add("valor", 0)
                            dict.Add("descripcion", "-- Seleccione --")
                            dict.Add("selected", "selected")
                            sele = "1"
                        Else
                            dict.Add("valor", fn.EncrytedString64(dt.Rows(i - 1).Item("valor").ToString()))
                            dict.Add("descripcion", dt.Rows(i - 1).Item("descripcion").ToString())
                            dict.Add("selected", "")
                        End If
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "RepPublicaciones" Then
                Try
                    Dim oePublicacion As New ePublicacion
                    Dim olPublicaciones As New lPublicaciones
                    Dim dt As New DataTable
                    Dim fn As New lFunciones

                    oePublicacion.anio_pub = fn.DecrytedString64(Request("param1").ToString())
                    dt = olPublicaciones.ReportePublicacionesAnio(oePublicacion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    Dim sele As String = "0"
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("numero", dt.Rows(i).Item("numero").ToString())
                        dict.Add("denominacion_pub", dt.Rows(i).Item("denominacion_pub").ToString())
                        dict.Add("codpropietario_pub", dt.Rows(i).Item("codpropietario_pub").ToString())
                        dict.Add("sitio_pub", dt.Rows(i).Item("sitio_pub").ToString())
                        dict.Add("codexcavacion_pub", dt.Rows(i).Item("codexcavacion_pub").ToString())
                        dict.Add("contexto_pub", dt.Rows(i).Item("contexto_pub").ToString())
                        dict.Add("presentabio_pub", dt.Rows(i).Item("presentabio_pub").ToString())
                        dict.Add("tipobio_pub", dt.Rows(i).Item("tipobio_pub").ToString())
                        dict.Add("autores_pub", dt.Rows(i).Item("autores_pub").ToString())
                        dict.Add("titulo_pub", dt.Rows(i).Item("titulo_pub").ToString())
                        dict.Add("anio_pub", dt.Rows(i).Item("anio_pub").ToString())
                        dict.Add("titulolibro_pub", dt.Rows(i).Item("titulolibro_pub").ToString())
                        dict.Add("edicion_pub", dt.Rows(i).Item("edicion_pub").ToString())
                        dict.Add("paginas_pub", dt.Rows(i).Item("paginas_pub").ToString())
                        dict.Add("nrofigura_pub", dt.Rows(i).Item("nrofigura_pub").ToString())
                        dict.Add("volumen_pub", dt.Rows(i).Item("volumen_pub").ToString())
                        dict.Add("seccion", dt.Rows(i).Item("seccion").ToString())
                        dict.Add("fechaconsulta_pub", dt.Rows(i).Item("fechaconsulta_pub").ToString())
                        dict.Add("direccionelect_pub", dt.Rows(i).Item("direccionelect_pub").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "cboAnioExposiciones" Then
                Try
                    Dim oeExposicion As New eExposicion
                    Dim olExposiciones As New lExposiciones
                    Dim dt As New DataTable
                    Dim fn As New lFunciones

                    dt = olExposiciones.listaCombosAniosExposiciones(oeExposicion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    Dim sele As String = "0"
                    For i As Integer = 0 To dt.Rows.Count
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        If (sele = "0") Then
                            dict.Add("valor", 0)
                            dict.Add("descripcion", "-- Seleccione --")
                            dict.Add("selected", "selected")
                            sele = "1"
                        Else
                            dict.Add("valor", fn.EncrytedString64(dt.Rows(i - 1).Item("valor").ToString()))
                            dict.Add("descripcion", dt.Rows(i - 1).Item("descripcion").ToString())
                            dict.Add("selected", "")
                        End If
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "ReporteExposicionesAnio" Then
                Try
                    Dim oeExposicion As New eExposicion
                    Dim olExposiciones As New lExposiciones
                    Dim dt As New DataTable
                    Dim fn As New lFunciones

                    oeExposicion.param1 = fn.DecrytedString64(Request("param1").ToString())
                    dt = olExposiciones.ReporteExposicionesAnio(oeExposicion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    Dim sele As String = "0"
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("numero", dt.Rows(i).Item("numero").ToString())
                        dict.Add("codregnac_exp", dt.Rows(i).Item("codregnac_exp").ToString())
                        dict.Add("codpropietario_exp", dt.Rows(i).Item("codpropietario_exp").ToString())
                        dict.Add("codexcavacion_exp", dt.Rows(i).Item("codexcavacion_exp").ToString())
                        dict.Add("otroscodigos_exp", dt.Rows(i).Item("otroscodigos_exp").ToString())
                        dict.Add("denominacion", dt.Rows(i).Item("denominacion_exp").ToString())
                        dict.Add("sitio_exp", dt.Rows(i).Item("sitio_exp").ToString())
                        dict.Add("contexto", dt.Rows(i).Item("contexto_exp").ToString())
                        dict.Add("nombre_exp", dt.Rows(i).Item("nombre_exp").ToString())
                        dict.Add("lugar_exp", dt.Rows(i).Item("lugar_exp").ToString())
                        dict.Add("pais", dt.Rows(i).Item("pais_exp").ToString())
                        dict.Add("inmueble_exp", dt.Rows(i).Item("inmueble_exp").ToString())
                        dict.Add("resolucacion_exp", dt.Rows(i).Item("resolucacion_exp").ToString())
                        dict.Add("institucion_exp", dt.Rows(i).Item("institucion_exp").ToString())
                        dict.Add("comisario_exp", dt.Rows(i).Item("comisario_exp").ToString())
                        dict.Add("nropiliza_exp", dt.Rows(i).Item("nropiliza_exp").ToString())
                        dict.Add("monto_exp", dt.Rows(i).Item("monto_exp").ToString())
                        dict.Add("salida", dt.Rows(i).Item("salida_exp").ToString())
                        dict.Add("retorno_exp", dt.Rows(i).Item("retorno_exp").ToString())
                        dict.Add("activo_exp", dt.Rows(i).Item("activo_exp").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "cboReportes" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt As New DataTable
                    Dim fn As New lFunciones
                    oeCatologo.TipoOperacion = Request("param1").ToString()

                    dt = olCatologo.listaCombosReportes(oeCatologo)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    Dim sele As String = "0"
                    For i As Integer = 0 To dt.Rows.Count
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        If (sele = "0") Then
                            dict.Add("valor", 0)
                            dict.Add("descripcion", "-- Seleccione --")
                            dict.Add("selected", "selected")
                            sele = "1"
                        Else
                            dict.Add("valor", fn.EncrytedString64(dt.Rows(i - 1).Item("valor").ToString()))
                            dict.Add("descripcion", dt.Rows(i - 1).Item("descripcion").ToString())
                            dict.Add("selected", "")
                        End If
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gColeccion" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt As New DataTable
                    Dim fn As New lFunciones
                    oeCatologo.codinvinc_cat = fn.DecrytedString64(Request("cboGrupoCole").ToString())
                    oeCatologo.param2 = Request("txtColeccion").ToString()
                    oeCatologo.param3 = Session("dni")
                    If (Request("param1").ToString() = "0") Then
                        oeCatologo.param1 = 0
                    Else
                        oeCatologo.param1 = fn.DecrytedString64(Request("param1").ToString())
                    End If
                    dt = olCatologo.agregarColeccion(oeCatologo)


                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        dict.Add("alert", dt.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "DelColeccion" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim fn As New lFunciones
                    Dim dt As New DataTable
                    oeCatologo.codpropietario_cat = fn.DecrytedString64(Request("param1").ToString())
                    oeCatologo.usuarioreg = Session("dni")
                    dt = olCatologo.eliminarColeccion(oeCatologo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstColeccionesXGrupo" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt As New DataTable
                    Dim fn As New lFunciones
                    oeCatologo.param1 = fn.DecrytedString64(Request("param1").ToString())

                    dt = olCatologo.listaColeccionesxGrupo(oeCatologo)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        dict.Add("gco", fn.EncrytedString64(dt.Rows(i).Item("id_gco").ToString()))
                        dict.Add("dgco", dt.Rows(i).Item("descripcion_gco").ToString())
                        dict.Add("dgc", fn.EncrytedString64(dt.Rows(i).Item("id_dgc").ToString()))
                        dict.Add("ddgc", dt.Rows(i).Item("descripcion_dgc").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "DelCatalogo" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim fn As New lFunciones
                    Dim dt As New DataTable
                    oeCatologo.codpropietario_cat = fn.DecrytedString64(Request("param1").ToString())
                    oeCatologo.usuarioreg = Session("dni")
                    dt = olCatologo.eliminarCatologo(oeCatologo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "DelInventario" Then
                Try
                    Dim oeInventario As New eInventario
                    Dim olInventario As New lInventario
                    Dim fn As New lFunciones
                    Dim dt As New DataTable
                    oeInventario.codpropietario_inv = Request("param1").ToString()
                    oeInventario.usuarioreg = Session("dni")
                    dt = olInventario.eliminarInventario(oeInventario)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

                'Inicio JAZ
            ElseIf Request("param0") = "DelEvaluacion" Then
                Try
                    Dim oeEvaluacion As New eEvaluacion
                    Dim olEvaluacion As New lEvaluacion
                    Dim fn As New lFunciones
                    Dim dt As New DataTable

                    oeEvaluacion.nroficha_con = fn.DecrytedString64(Request("param1").ToString())
                    oeEvaluacion.id_dgc = fn.DecrytedString64(Request("param2").ToString())
                    oeEvaluacion.usuarioreg = Session("dni")
                    dt = olEvaluacion.eliminarEliminacion(oeEvaluacion)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
                '    Fin JAZ

            ElseIf Request("param0") = "gInventario1" Then
                Try
                    Dim oeInventario As New eInventario
                    Dim olInventario As New lInventario
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    oeInventario.codpropietario_inv = Request("txtCodPropietario").ToString()
                    oeInventario.codexcavacion_inv = Request("txtCodigoExcavacion").ToString()
                    oeInventario.nro_inv = Request("txtNroInv").ToString()
                    oeInventario.proyecto_inv = Request("txtProyecto").ToString()
                    oeInventario.temporada_inv = Request("txtTemporada").ToString()
                    oeInventario.sector_inv = Request("txtSector").ToString()
                    oeInventario.subsector_inv = Request("txtSubSector").ToString()
                    oeInventario.unidad_inv = Request("txtUnidad").ToString()
                    oeInventario.capa_inv = Request("txtCapa").ToString()
                    oeInventario.nivel_inv = Request("txtNivel").ToString()
                    If (Request("txtCuadricula").ToString() = "") Then
                        oeInventario.cuadricula_inv = 0
                    Else
                        oeInventario.cuadricula_inv = Request("txtCuadricula")
                    End If
                    oeInventario.contexto_inv = Request("txtContexto").ToString()
                    If (Request("txtPlano").ToString() = "") Then
                        oeInventario.plano_inv = 0
                    Else
                        oeInventario.plano_inv = Request("txtPlano").ToString()
                    End If
                    oeInventario.tipomaterial_inv = Request("cboTipoMat").ToString()
                    oeInventario.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeInventario.usuarioreg = Session("dni")

                    If (Request("inv").ToString() = "") Then
                        dt1 = olInventario.registrarIdentificacionCodAdicionales(oeInventario)
                    Else
                        oeInventario.codpropietario_inv = fn.DecrytedString64(Request("inv").ToString())
                        dt1 = olInventario.actualizarIdentificacionCodAdicionales(oeInventario)
                    End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", fn.EncrytedString64(dt1.Rows(i).Item("Code").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gInventario2" Then
                Try
                    Dim oeInventario As New eInventario
                    Dim olInventario As New lInventario
                    Dim fn As New lFunciones
                    Dim dt1 As New DataTable

                    oeInventario.codpropietario_inv = fn.DecrytedString64(Request("inv").ToString())
                    oeInventario.observacion_inv = Request("txtObservacion").ToString()
                    oeInventario.estante_inv = Request("txtEstante").ToString()
                    oeInventario.almacen_inv = Request("txtAlmacen").ToString()
                    oeInventario.fechareg = Request("txtFechaReg").ToString()
                    oeInventario.fechaalmacen_inv = Request("txtFechaAlmacen").ToString()
                    oeInventario.peso_inv = Request("txtPeso").ToString()
                    oeInventario.cantidad_inv = Request("txtCantidad").ToString()
                    oeInventario.fin_rotulacion_inv = Request("txtFinRotu").ToString()
                    oeInventario.ini_rotulacion_inv = Request("txtIniRotu").ToString()
                    oeInventario.nrobolsa_inv = Request("txtNroBolsa").ToString()
                    oeInventario.nrocaja_inv = Request("txtNroCaja").ToString()
                    oeInventario.otrosdatos_inv = Request("txtOtrosDatos").ToString()
                    oeInventario.estilo_inv = Request("txtEstilo").ToString()
                    oeInventario.cultura_inv = Request("txtCultura").ToString()
                    oeInventario.descripcion_inv = Request("txtDescripcion").ToString()
                    oeInventario.id_dgc = fn.DecrytedString64(Request("paramdgc").ToString())
                    oeInventario.usuarioreg = Session("dni")

                    dt1 = olInventario.registrarIdentificacionCodAdicionales2(oeInventario)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                        dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstCatalogos" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt As New DataTable
                    oeCatologo.TipoOperacion = ""
                    dt = olCatologo.listadoCatalogos(oeCatologo)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        dict.Add("id", dt.Rows(i).Item("codpropietario_cat").ToString())
                        dict.Add("codregnac", dt.Rows(i).Item("codregnac_cat").ToString())
                        dict.Add("codexcavacion", dt.Rows(i).Item("codexcavacion_cat").ToString())
                        dict.Add("codreginc", dt.Rows(i).Item("codreginc_cat").ToString())
                        dict.Add("codinvinc", dt.Rows(i).Item("codinvinc_cat").ToString())
                        dict.Add("otrocodigos", dt.Rows(i).Item("otrocodigos_cat").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "CambioClave" Then
                Try
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim dict As New Dictionary(Of String, Object)()
                    Dim objE As New eAlumno
                    Dim objL As New lAlumno
                    Dim blnResultado As String = ""
                    ' MsgBox("ok")
                    If (Request("param3").ToString = Request("param4").ToString) Then
                        objE.codigo_Alu = Session("DNI")
                        objE.password_Alu = Request("param2").ToString
                        objE.nuevaClave = Request("param3").ToString
                        objE.confirmaClave = Request("param4").ToString

                        blnResultado = objL.CambioDeClave(objE)

                        dict.Add("alert", "success")
                        dict.Add("msje", blnResultado)
                        dict.Add("Code", "0")
                        list.Add(dict)
                    Else
                        dict.Add("alert", "error")
                        dict.Add("msje", "Los campos no coinciden")
                        dict.Add("Code", "1")
                        list.Add(dict)
                    End If
                    objE = Nothing
                    objL = Nothing

                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    JSONresult = serializer.Serialize(list)

                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstUsuarioFuncion" Then
                Try
                    Dim oeUsuario As New eUsuario
                    Dim olUsuario As New lUsuario
                    Dim dt As New DataTable
                    Dim fn As New lFunciones
                    dt = olUsuario.ListarUsuarioFuncion()

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        dict.Add("codigo", fn.EncrytedString64(dt.Rows(i).Item("codigo_per").ToString()))
                        dict.Add("colaborador", dt.Rows(i).Item("colaborador").ToString())
                        dict.Add("apellidoPat_per", dt.Rows(i).Item("apellidoPat_per").ToString())
                        dict.Add("apellidoMat_per", dt.Rows(i).Item("apellidoMat_per").ToString())
                        dict.Add("nombres_per", dt.Rows(i).Item("nombres_per").ToString())
                        dict.Add("sexo_per", dt.Rows(i).Item("sexo_per").ToString())
                        dict.Add("tipoDocIdent_per", dt.Rows(i).Item("tipoDocIdent_per").ToString())
                        dict.Add("nroDocIdent_per", dt.Rows(i).Item("nroDocIdent_per").ToString())
                        dict.Add("eMail_per", dt.Rows(i).Item("eMail_per").ToString())
                        dict.Add("email2_per", dt.Rows(i).Item("email2_per").ToString())
                        dict.Add("codigo_Apl", dt.Rows(i).Item("codigo_Apl").ToString())
                        dict.Add("funcion", dt.Rows(i).Item("funcion").ToString())
                        dict.Add("codigotfu", fn.EncrytedString64(dt.Rows(i).Item("codigo_Tfu").ToString()))
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "gUsuarioFuncion" Then
                Try
                    Dim oeUsuario As New eUsuario
                    Dim olUsuario As New lUsuario
                    Dim fn As New lFunciones

                    Dim dt As New DataTable
                    oeUsuario.aPaterno = Request("txtPaterno").ToString
                    oeUsuario.aMaterno = Request("txtMaterno").ToString
                    oeUsuario.nombres = Request("txtNombres").ToString
                    oeUsuario.docidentidad = Request("txtDNI").ToString
                    oeUsuario.tsexo = Request("hdTSexo").ToString
                    oeUsuario.email = Request("txtEmail").ToString
                    oeUsuario.email2 = Request("txtEmail2").ToString
                    oeUsuario.codigo_Apl = 1
                    oeUsuario.codigo_tfu = fn.DecrytedString64(Request("cboFunciones2").ToString)
                    oeUsuario.param1 = Session("dni")
                    'oeUsuario.param1 = session("Usuario")
                    Dim tipo As String
                    tipo = Request("hdTipo").ToString
                    If tipo = "G" Then
                        dt = olUsuario.agregarUsuarioFuncion(oeUsuario)
                    Else
                        oeUsuario.codigo_uap = fn.DecrytedString64(Request("param1").ToString)
                        dt = olUsuario.actualizarUsuarioFuncion(oeUsuario)
                    End If

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        dict.Add("alert", dt.Rows(i).Item("Status").ToString())
                        dict.Add("msje", dt.Rows(i).Item("Msje").ToString())
                        dict.Add("Code", dt.Rows(i).Item("Code").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

            ElseIf Request("param0") = "lstfuncionMenu" Then
                Try
                    Dim oeUsuario As New eUsuario
                    Dim olUsuario As New lUsuario
                    Dim dt As New DataTable
                    Dim fn As New lFunciones

                    oeUsuario.codigo_Men = fn.DecrytedString64(Request("param1").ToString)
                    dt = olUsuario.ListarFuncionMenu(oeUsuario)

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        dict.Add("seleccion", dt.Rows(i).Item("seleccion").ToString())
                        dict.Add("codigo", fn.EncrytedString64(dt.Rows(i).Item("codigo").ToString()))
                        dict.Add("draiz", dt.Rows(i).Item("draiz").ToString())
                        dict.Add("descripcion", dt.Rows(i).Item("descripcion").ToString())
                        dict.Add("raiz", dt.Rows(i).Item("raiz").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
            ElseIf Request("param0") = "lstDepartamento" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt As New DataTable
                    Dim fn As New lFunciones


                    dt = olCatologo.listaDepartamentos(oeCatologo)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("valor", dt.Rows(i).Item("item").ToString())
                        dict.Add("descripcion", dt.Rows(i).Item("descripcion").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
            ElseIf Request("param0") = "lstProvincia" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt As New DataTable
                    Dim fn As New lFunciones

                    oeCatologo.param1 = Request("param1").ToString
                    dt = olCatologo.listaProvincia(oeCatologo)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("valor", dt.Rows(i).Item("item").ToString())
                        dict.Add("descripcion", dt.Rows(i).Item("descripcion").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
            ElseIf Request("param0") = "lstDistrito" Then
                Try
                    Dim oeCatologo As New eCatalogo
                    Dim olCatologo As New lCatalogo
                    Dim dt As New DataTable
                    Dim fn As New lFunciones

                    oeCatologo.param1 = Request("param1").ToString()
                    dt = olCatologo.listaDistrito(oeCatologo)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("valor", dt.Rows(i).Item("item").ToString())
                        dict.Add("descripcion", dt.Rows(i).Item("descripcion").ToString())
                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try
            ElseIf Request("param0") = "lstFunciones" Then
                Try
                    Dim oeUsuario As New eUsuario
                    Dim olUsuario As New lUsuario
                    Dim dt As New DataTable
                    Dim fn As New lFunciones

                    dt = olUsuario.ListaFunciones()

                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim dict As New Dictionary(Of String, Object)()
                        dict.Add("reset", False)
                        dict.Add("codigo", fn.EncrytedString64(dt.Rows(i).Item("codigo_Tfu").ToString()))
                        dict.Add("descripcion", dt.Rows(i).Item("descripcion_Tfu").ToString())
                        dict.Add("abreviatura", dt.Rows(i).Item("abreviatura_Tfu").ToString())
                        If i = 0 Then
                            dict.Add("selected", "selected")
                        Else
                            dict.Add("selected", "")
                        End If

                        list.Add(dict)
                    Next

                    JSONresult = serializer.Serialize(list)
                Catch ex As Exception
                    'Response.Write(ex.Message)
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim dict As New Dictionary(Of String, Object)()
                    dict.Add("alert", "error")
                    dict.Add("msje", ex.Message.ToString)
                    list.Add(dict)
                    JSONresult = serializer.Serialize(list)
                End Try

                'ElseIf Request("param0") = "gCatalogo2" Then
                '    Try
                '        Dim oeCatologo As New eCatalogo
                '        Dim olCatologo As New lCatalogo
                '        Dim dt1 As New DataTable
                '        oeCatologo.unidad_cat = Request("txtNroFicha").ToString()
                '        oeCatologo.codregnac_cat = Request("txtCodRegNac").ToString()
                '        oeCatologo.codpropietario_cat = Request("txtCodPropietario").ToString()
                '        oeCatologo.codexcavacion_cat = Request("txtCodigoExcavacion").ToString()
                '        oeCatologo.codreginc_cat = Request("txtRegINC").ToString()
                '        oeCatologo.codinvinc_cat = Request("txtInvINVC").ToString()
                '        oeCatologo.otrocodigos_cat = Request("txtOtrosCod").ToString()

                '        oeCatologo.usuarioreg = "Jr"

                '        dt1 = olCatologo.registrarIdentificacionCodAdicionales(oeCatologo)

                '        Dim list As New List(Of Dictionary(Of String, Object))()
                '        Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                '        For i As Integer = 0 To dt1.Rows.Count - 1
                '            Dim dict As New Dictionary(Of String, Object)()
                '            dict.Add("alert", dt1.Rows(i).Item("Status").ToString())
                '            dict.Add("msje", dt1.Rows(i).Item("Msje").ToString())
                '            dict.Add("code", dt1.Rows(i).Item("Code").ToString())
                '            list.Add(dict)
                '        Next

                '        JSONresult = serializer.Serialize(list)
                '    Catch ex As Exception
                '        'Response.Write(ex.Message)
                '        Dim list As New List(Of Dictionary(Of String, Object))()
                '        Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                '        Dim dict As New Dictionary(Of String, Object)()
                '        dict.Add("alert", "error")
                '        dict.Add("msje", ex.Message.ToString)
                '        list.Add(dict)
                '        JSONresult = serializer.Serialize(list)
                '    End Try
            End If
            Response.Write(JSONresult)
        Else
            If Request("param0") = "RCla" Then
                Try

                    Dim dt As New Data.DataTable
                    Dim list As New List(Of Dictionary(Of String, Object))()
                    Dim dict As New Dictionary(Of String, Object)()
                    Dim objE As New eAlumno
                    Dim objL As New lAlumno
                    Dim Email As String = ""
                    Dim nemail As Integer = 0

                    objE.nroDocIdent_Alu = Request("param2")
                    dt = objL.RecuperarClave_persona(objE)

                    If Not dt Is Nothing AndAlso (dt.Rows.Count > 0) Then
                        If dt.Rows(0).Item("email2_per").ToString <> "" Then
                            Email = dt.Rows(0).Item("eMail_per").ToString & ";" & dt.Rows(0).Item("email2_per").ToString
                            nemail = 2
                        Else
                            Email = dt.Rows(0).Item("eMail_per").ToString
                            nemail = 1
                        End If

                        If Email Is Nothing Or Email = "" Then
                            dict.Add("email", "")
                            dict.Add("aviso", "No tiene correo registrado para enviar su contrase&ntilde;a")
                            dict.Add("respuesta", "ERROR")
                        Else

                            Dim saludo As String = ""
                            Dim blnResultado As Boolean = False
                            Dim Asunto, mensaje, origen, destino As String
                            Dim ObjMail As New clsMailNet


                            If dt.Rows(0).Item("sexo").ToString = "M" Then
                                saludo = "estimado Sr"
                            Else
                                saludo = "estimada Srta"
                            End If

                            mensaje = ""
                            Asunto = "TUMBAS REALES - Recuperar Contraseña"
                            'Asunto = "Confirmación de Referencia Laboral"
                            mensaje = mensaje + "<html><head><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />"
                            mensaje = mensaje + "<title>TUMBAS REALES</title>"
                            mensaje = mensaje + "<style type='text/css'>.usat { font-family:Calibri;color:#F1132A;font-size:25px;font-weight: bold;} "
                            mensaje = mensaje + ".bolsa{color:#F1132A;font-family:Calibri;font-size: 13px;font-weight: 500;}</style></head>"
                            mensaje = mensaje + "<body>"
                            mensaje = mensaje + "<div style='text-align:center;width:100%'>"
                            mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td style='text-align:center;'>"
                            mensaje = mensaje + "<div style='width:100%;margin:0 auto;text-align:center;background:#000000'><img src='http://www.museotumbasreales.com/images/logo.png' width='200' height='80' ></div>"
                            mensaje = mensaje + "</td></tr></table>"
                            mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr>"
                            mensaje = mensaje + "<td style = 'background:none;border-bottom:1px solid #000000;height:1px;width:50%;margin:0px 0px 0px 0px' > &nbsp;</td></tr></table><br />"
                            mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td>"

                            mensaje = mensaje + "<div style='margin-top:10px;text-align:center;color:gray;font-family:Calibri '>Hola " + " " + dt.Rows(0).Item("socio").ToString + ".<br>Tu contraseña para poder acceder a la web Tumbas Reales <br/>es: <b>" + dt.Rows(0).Item("password_per").ToString + "</b><br/><br/>Si por alguna razón no solicitaste el envío de esta<br />información, te recomendamos cambiar tu contraseña para<br/>mayor seguridad.</div>"
                            mensaje = mensaje + "</td></tr></table>"
                            mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'>"
                            mensaje = mensaje + "<tr><td style='background:none;border-bottom:1px solid #000000;height:1px;width:50%;margin:0px 0px 0px 0px' > &nbsp;</td></tr></table><br />"
                            mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td>"
                            mensaje = mensaje + "<div style='margin:0 auto;text-align:center;color:gray;font-family:Calibri'>¡Muchas gracias por confiar en nosotros!</div>"
                            mensaje = mensaje + "<div style='margin:0 auto;text-align:center;color:gray;font-family:Calibri'><b>El equipo de comunicaciones</b></div><br /></td></tr></table>"
                            mensaje = mensaje + "<table border='0' width='70%' cellpadding='0' cellspacing='0'><tr><td style='text-align:center;'>"
                            mensaje = mensaje + "<div style='font-size:11px;color:gray;font-family:Calibri'><div>Av. Juan Pablo Vizcardo y Guzmán N° 895 Lambayeque - Lambayeque <br/>"
                            mensaje = mensaje + "<a href='junior.seclenleon@gmail.com' style='color:gray;text-decoration:none;font-family:Calibri' target='_blank'> <b>junior.seclenleon@gmail.com</b></a></div> "
                            mensaje = mensaje + "<div style='font-family:Calibri' >© Copyright 2018 - TUMBAS REALES - Todos los derechos reservados</div>"
                            mensaje = mensaje + "</td></tr></table></div></body></html>"

                            destino = Trim(Email)
                            'destino = "jalvaz@outlook.com"
                            blnResultado = ObjMail.fnEnviarMailVarios("servicios@tumbasreales.com.pe", "Servicios TUMBAS REALES", destino, Asunto, mensaje, True, "TumbasReales", "junior.seclenleon@gmail.com")
                            If (blnResultado = True) Then
                                dict.Add("email", emailpass(dt.Rows(0).Item("eMail_per").ToString))
                                dict.Add("email2", emailpass(dt.Rows(0).Item("eMail2_per").ToString))
                                dict.Add("aviso", "Correo enviado correctamente")
                                dict.Add("respuesta", "OK")
                            Else
                                dict.Add("email", "")
                                dict.Add("aviso", "Error al enviar correo con contrase&ntilde;a")
                                dict.Add("respuesta", "ERROR")
                            End If
                            dict.Add("numEmail", nemail)
                        End If

                    Else

                        dict.Add("email", "")
                        dict.Add("aviso", "No existe Nro Documento de Identidad en el sistema")
                        dict.Add("respuesta", "ERROR")
                        dict.Add("numEmail", nemail)
                    End If

                    list.Add(dict)


                    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
                    JSONresult = serializer.Serialize(list)
                    Response.Write(JSONresult)
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            Else
                Response.Redirect("~/Default.aspx")
                Exit Sub
            End If
        End If
    End Sub

    Function emailpass(ByVal email As String) As String
        Try
            Dim str1 As String = extraerCad(email, "@", 0)
            Dim str2 As String = extraerCad(email, "@", 1)
            Dim str3 As String = extraerCad(str2, ".", 0)
            Dim str4 As String = extraerCad(str2, ".", 1)
            Dim str5 As String = extraerCad(str2, ".", 2)
            Dim emailF As String = ""
            ' Response.Write(email & "<br>")
            If str5 <> "" Then
                emailF = fnReplacePass(str1.ToString, 2, 2, "*") & "@" & fnReplacePass(str3.ToString, 1, 0, "*") & "." & str4.ToString & "." & str5.ToString
            Else
                emailF = fnReplacePass(str1.ToString, 2, 2, "*") & "@" & fnReplacePass(str3.ToString, 1, 0, "*") & "." & str4.ToString

            End If

            'Response.Write(emailF & "<br>")
            Return emailF
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Function extraerCad(ByVal CAD As String, ByVal LIM As String, ByVal INDICE As Integer) As String
        Try
            Dim TestArray() As String = Split(CAD, LIM)
            Return TestArray(INDICE)

        Catch ex As Exception
            Return ""
        End Try

    End Function

    Function fnReplacePass(ByVal CAD As String, ByVal L As Integer, ByVal R As Integer, Optional ByVal REPLACE As String = "*") As String
        Try
            Dim strlen As Integer = CAD.Length
            Dim textoL As String = Left(CAD, L)
            Dim textoR As String = Right(CAD, R)
            Dim concat As String = ""
            Dim textoF As String = ""
            Dim N As Integer = strlen - L - R

            For i As Integer = 0 To N - 1
                concat = concat & REPLACE
            Next
            textoF = textoL & concat & textoR

            Return textoF
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Function encode(ByVal str As String) As String
        Return (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(str)))
    End Function

    Function decode(ByVal str As String) As String
        Return System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(str))
    End Function


    Sub Download2()
        Dim fn As New lFunciones
        Try
            'Dim usuario_session_ As String() = Session("perlogin").ToString.Split(New Char() {"\"c})
            Dim usuario_session As String = Session("dni")
            Dim area As String = Request("area")
            Dim IdArchivo As String = fn.DecrytedString64(Request("IdArchivo"))

            Dim wsCloud As New ClsArchivosCompartidos
            Dim list As New Dictionary(Of String, String)

            Dim oeCatalogo As New eCatalogo
            Dim olCatalogo As New lCatalogo
            Dim dt As New Data.DataTable

            oeCatalogo.param1 = 2
            oeCatalogo.param2 = area
            oeCatalogo.param3 = IdArchivo
            dt = olCatalogo.listarArchivosCompartidos(oeCatalogo)

            Dim resultData As New List(Of Dictionary(Of String, Object))()
            ' Response.Write(IdArchivo)
            list.Add("IdArchivo", IdArchivo)
            list.Add("Usuario", usuario_session)
            Dim envelope As String = wsCloud.SoapEnvelopeDescarga(list)
            Dim result As String = wsCloud.PeticionRequestSoap("http://localhost/SharedFilesService/SharedFiles.asmx", envelope, "http://usat.edu.pe/DownloadFile", usuario_session)
            'Dim result As String = wsCloud.PeticionRequestSoap("http://localhost/SharedFilesService/SharedFiles.asmx", envelope, "http://usat.edu.pe/DownloadFile", usuario_session)
            Dim imagen As String = ResultFile(result)
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim Data As New Dictionary(Of String, Object)()
                Data.Add("File", imagen)
                Data.Add("Nombre", dt.Rows(i).Item("NombreArchivo"))
                Data.Add("Extencion", dt.Rows(i).Item("Extencion"))
                resultData.Add(Data)
            Next
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim JSONresult As String = ""
            'serializer.MaxJsonLength = Int32.MaxValue
            JSONresult = serializer.Serialize(resultData)
            Response.Write(JSONresult)

        Catch ex As Exception
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim JSONresult As String = ""
            Dim Data As New Dictionary(Of String, Object)()
            Data.Add("msje", ex.Message)
            JSONresult = serializer.Serialize(Data)
            Response.Write(JSONresult)
        End Try

    End Sub
    Sub DownloadSinEnc()
        Dim fn As New lFunciones
        Try
            'Dim usuario_session_ As String() = Session("perlogin").ToString.Split(New Char() {"\"c})
            Dim usuario_session As String = Session("dni")
            Dim area As String = Request("area")
            Dim IdArchivo As String = Request("IdArchivo")

            Dim wsCloud As New ClsArchivosCompartidos
            Dim list As New Dictionary(Of String, String)

            Dim oeCatalogo As New eCatalogo
            Dim olCatalogo As New lCatalogo
            Dim dt As New Data.DataTable

            oeCatalogo.param1 = 2
            oeCatalogo.param2 = area
            oeCatalogo.param3 = IdArchivo
            dt = olCatalogo.listarArchivosCompartidos(oeCatalogo)

            Dim resultData As New List(Of Dictionary(Of String, Object))()
            ' Response.Write(IdArchivo)
            list.Add("IdArchivo", IdArchivo)
            list.Add("Usuario", usuario_session)
            Dim envelope As String = wsCloud.SoapEnvelopeDescarga(list)
            Dim result As String = wsCloud.PeticionRequestSoap("http://localhost/SharedFilesService/SharedFiles.asmx", envelope, "http://usat.edu.pe/DownloadFile", usuario_session)
            'Dim result As String = wsCloud.PeticionRequestSoap("http://localhost/SharedFilesService/SharedFiles.asmx", envelope, "http://usat.edu.pe/DownloadFile", usuario_session)
            Dim imagen As String = ResultFile(result)
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim Data As New Dictionary(Of String, Object)()
                Data.Add("File", imagen)
                Data.Add("Nombre", dt.Rows(i).Item("NombreArchivo"))
                Data.Add("Extencion", dt.Rows(i).Item("Extencion"))
                resultData.Add(Data)
            Next
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim JSONresult As String = ""
            serializer.MaxJsonLength = Integer.MaxValue
            JSONresult = serializer.Serialize(resultData)
            Response.Write(JSONresult)

        Catch ex As Exception
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim JSONresult As String = ""
            Dim Data As New Dictionary(Of String, Object)()
            Data.Add("msje", ex.Message)
            JSONresult = serializer.Serialize(Data)
            Response.Write(JSONresult)
        End Try

    End Sub
    Function ResultFile(ByVal cadXml As String) As String
        Dim nsMgr As XmlNamespaceManager
        Dim xml As XmlDocument = New XmlDocument()
        xml.LoadXml(cadXml)
        nsMgr = New XmlNamespaceManager(xml.NameTable)
        nsMgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")
        Dim res As XmlNode = xml.DocumentElement.SelectSingleNode("/soap:Envelope/soap:Body", nsMgr)
        '  Dim mNombre = xml.ReadElementString("nombre")
        Return res.InnerText
        '   Response.Write("dd" + res.InnerText)
    End Function

    Private Function GeneraToken() As String
        Dim rnd As New Random
        Dim ubicacion As Integer
        Dim strNumeros As String = "0123456789"
        Dim strLetraMin As String = "abcdefghijklmnopqrstuvwxyz"
        Dim strLetraMay As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim Token As String = ""
        Dim strCadena As String = ""
        strCadena = strLetraMin & strNumeros & strLetraMay
        While Token.Length < 10
            ubicacion = rnd.Next(0, strCadena.Length)
            If (ubicacion = 62) Then
                Token = Token & strCadena.Substring(ubicacion - 1, 1)
            End If
            If (ubicacion < 62) Then
                Token = Token & strCadena.Substring(ubicacion, 1)
            End If
        End While
        Return Token
    End Function

End Class
