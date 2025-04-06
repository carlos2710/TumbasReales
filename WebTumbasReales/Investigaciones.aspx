<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Investigaciones.aspx.vb" Inherits="Investigaciones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>	.: AVA - SIP&Aacute;N :.</title>

    <script type="text/javascript" src='assets/js/jquery.dataTables.min.js'></script>  
    <link rel='stylesheet' href='assets/css/jquery.dataTables.min.css'/>  
     
    <link rel='stylesheet' href='assets/css/validaform.css'/>     
    <script src="assets/js/funciones.js" type="text/javascript"></script> 
    
    <script src='assets/js/bootstrap-datepicker.js'></script>
    <script src='assets/js/funcionesDataTable.js?y=1'></script>

<script  type="text/javascript" >

    var aData = [];
    var bData = [];

    jQuery(document).ready(function () {

        var nombre_anio;
        var valor_anio;
        var lstAnio;

        var nombre_colec;
        var valor_colec;
        var lstColec;

        var nombre_sitio;
        var valor_sitio;
        var lstSitio;

        var nombre_anioAfec;
        var valor_anioAfec;
        var lstAnioAfect;

        var nombre_sitioAfec;
        var valor_sitioAfec;
        var lstSitioAfect;

        fnResetDataTableTramite('tbMuebles', 0, 'desc');
        fnResetDataTableTramite('tbInventario', 0, 'desc');
        fnResetDataTableTramite('tbAfectacionInm', 0, 'desc');
        
        //listaDepartamento();

        $('#DivMuebles').hide();
        $('#DivInmuebles').hide();

        $("#btnBienesMuebles").click(fnBienesMuebles);
        $("#btnBienesInmuebles").click(fnBienesInmuebles);
        
        $("#btnCargar").click(fnCargar);
        $("#btnCargarArq").click(fnCargarArq);
        $("#btnCargarExcav").click(fnCargarExcav);
        $("#btnCargarAfecDoc").click(fnCargarAfecDoc);
        
        $("#btnArqueo").click(fnArqueo);
        $("#btnInventario").click(fnInventario);
        $("#btnExcavaciones").click(fnExcavaciones);
        $("#btnAfecta").click(fnAfecta);

        $("#btnAfecDoc").click(fnAfecDoc);
        $("#btnAfecBD").click(fnAfecBD);
        
        $("#btnGuardarInvI1").click(fnGuardarInvI10);
        $("#btnGuardarInvI2").click(fnGuardarInvInv2);

        $('#btnInvInmebles').click(function () {
            limpiaInvInm();
            $("#invInm").val("0");
            $('.nav-tabs a[href="#tabIdentificacionII"]').tab('show')
            $('div#mdConfirmarInvInm').modal('show');
        });

        $('#btnAfectaInm').click(function () {
            limpiaInvInm();
            $("#afeInm").val("0");
            $('.nav-tabs a[href="#tabIdentificacionII"]').tab('show')
            $('div#mdConfirmarAfectInm').modal('show');
        });        

        $("#btnAgregarAI").click(fnAgregarAI);
        
        $("#btnDelReg").click(fnDelRegistro);
        $("#btnDelRegAI").click(fnDelRegistroAI);
        
        CargarMuebles();
        CargarInmuebles1();

        lstAnio = fnCargaLista("lstAnioInvestig");
        var jsonStringU = JSON.parse(lstAnio);

        $('#txtAnio').autocomplete({
            source: $.map(jsonStringU, function (item) {
                return item.nombre_anio;
            }),
            select: function (event, ui) {
                var selectecItem = jsonStringU.filter(function (value) {
                    return value.nombre_anio == ui.item.value;
                });
                nombre_anio = selectecItem[0].nombre_anio;
            },
            minLength: 3,
            delay: 100
        });

        $('#txtAnio').keyup(function () {
            var l = parseInt($(this).val().length);
            if (l == 0) {
                nombre_anio = "";
            }
        });
        
        lstColecciones();

        
        lstSitio = fnCargaLista("lstSitioArqInvestig");
        var jsonStringUS = JSON.parse(lstSitio);

        $('#txtSitio').autocomplete({
            source: $.map(jsonStringUS, function (item) {
                return item.nombre_sitio;
            }),
            select: function (event, ui) {
                var selectecItem = jsonStringUS.filter(function (value) {
                    return value.nombre_sitio == ui.item.value;
                });
                nombre_sitio = selectecItem[0].nombre_sitio;
            },
            minLength: 3,
            delay: 100
        });

        $('#txtSitio').keyup(function () {
            var l = parseInt($(this).val().length);
            if (l == 0) {
                nombre_sitio = "";
            }
        });

        lstAnioAfect = fnCargaLista("lstAnioAfectaDoc");
        var jsonStringUAD = JSON.parse(lstAnioAfect);

        $('#txtAnioAfecDoc').autocomplete({
            source: $.map(jsonStringUAD, function (item) {
                return item.nombre_anioAfec;
            }),
            select: function (event, ui) {
                var selectecItem = jsonStringUAD.filter(function (value) {
                    return value.nombre_anioAfec == ui.item.value;
                });
                nombre_anioAfec = selectecItem[0].nombre_anioAfec;
            },
            minLength: 3,
            delay: 100
        });

        $('#txtAnioAfecDoc').keyup(function () {
            var l = parseInt($(this).val().length);
            if (l == 0) {
                nombre_anioAfec = "";
            }
        });

        lstSitioAfect = fnCargaLista("lstSitioAfectaDoc");
        var jsonStringUSAD = JSON.parse(lstSitioAfect);

        $('#txtAnioAfecDoc').autocomplete({
            source: $.map(jsonStringUSAD, function (item) {
                return item.nombre_sitioAfec;
            }),
            select: function (event, ui) {
                var selectecItem = jsonStringUSAD.filter(function (value) {
                    return value.nombre_sitioAfec == ui.item.value;
                });
                nombre_sitioAfec = selectecItem[0].nombre_sitioAfec;
            },
            minLength: 3,
            delay: 100
        });

        $('#txtAnioAfecDoc').keyup(function () {
            var l = parseInt($(this).val().length);
            if (l == 0) {
                nombre_sitioAfec = "";
            }
        });

        listaDepartamento();
        listaProvincia();
        listaDistrito();

        $("#cboDepartamento").change(function () {
            console.log(this.value);
            if (this.value == "0") {
                //$("#dboProvincia option").remove();
                //$("#cboDistrito option").remove();
                $('#dboProvincia').val("0");
                $('#cboDistrito').val("0");
            }
            else {
                $.ajax({
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    url: "processmuseo.aspx",
                    data: { "param0": "lstProvincia", "param1": this.value },
                    dataType: "json",
                    success: function (data) {
                        //aData = data;
                        //console.log(data);
                        var i = 0;
                        var t = '<option value="">Seleccione Provincia</option>';
                        if (data.length > 0) {
                            for (var i = 0; i < data.length; i++) {
                                t += '<option value="' + data[i].valor + '">' + data[i].descripcion + '</option>';
                            }
                        }
                        $('#dboProvincia').html(t);
                    },
                    error: function (result) {
                        sOut = '';
                    }
                });
                $('#dboProvincia').val("0");
                $('#cboDistrito').val("0");
            }
        });

        $("#dboProvincia").change(function () {
            if (this.value == "0") {
                //$("#cboDistrito option").remove();
                $('#cboDistrito').val("0");
            }
            else {
                $.ajax({
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    url: "processmuseo.aspx",
                    data: { "param0": "lstDistrito", "param1": this.value },
                    dataType: "json",
                    success: function (data) {
                        //aData = data;
                        //console.log(data);
                        var i = 0;
                        var t = '';
                        if (data.length > 0) {
                            for (var i = 0; i < data.length; i++) {
                                t += '<option value="' + data[i].valor + '">' + data[i].descripcion + '</option>';
                            }
                        }
                        $('#cboDistrito').html(t);
                    },
                    error: function (result) {
                        sOut = '';
                    }
                });
            }
        });

        permisos();

    });

    function listaDepartamento() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("lstDepartamento");
        //var form = $('#frmCatalogo').serialize();
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            //data: form,
            data: { "param0": "lstDepartamento" },
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                var i = 0;
                var t = '';
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        t += '<option value="' + data[i].valor + '">' + data[i].descripcion + '</option>';
                        
                    }
                }
                $('#cboDepartamento').html(t);
            },
            error: function (result) {
                fnMensaje(data[0].alert, data[0].msje);
                //console.log(result);
            }
        });
    }

    function listaProvincia() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("lstProvincia");
        //var form = $('#frmCatalogo').serialize();
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            //data: form,
            data: { "param0": "lstProvincia", "param1": 0 },
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                var i = 0;
                var t = '';
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        t += '<option value="' + data[i].valor + '">' + data[i].descripcion + '</option>';
                    }
                }
                $('#dboProvincia').html(t);
            },
            error: function (result) {
                fnMensaje(data[0].alert, data[0].msje);
                //console.log(result);
            }
        });
    }

    function listaDistrito() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("lstDistrito");
        //var form = $('#frmCatalogo').serialize();
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            //data: form,
            data: { "param0": "lstDistrito", "param1": 0 },
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                var i = 0;
                var t = '';
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        t += '<option value="' + data[i].valor + '">' + data[i].descripcion + '</option>';
                    }
                }
                $('#cboDistrito').html(t);
            },
            error: function (result) {
                fnMensaje(data[0].alert, data[0].msje);
                //console.log(result);
            }
        });
    }

    function permisos() {
        if ($("#tfu").val() == "3" || $("#tfu").val() == "5") {
            $("#btnCargar").hide();
            $("#btnCargarArq").hide();
            $("#btnInvInmebles").hide();
            $("#btnGuardarInvI1").hide();
            $("#btnGuardarInvI2").hide();
            $("#btnCargarExcav").hide();
            $("#btnCargarAfecDoc").hide();
            $("#btnAfectaInm").hide();
            $("#btnDelRegAI").hide();
            $("#btnAgregarAI").hide();
        } else {
            $("#btnCargar").show();
            $("#btnCargarArq").show();
            $("#btnInvInmebles").show();
            $("#btnGuardarInvI1").show();
            $("#btnGuardarInvI2").show();
            $("#btnCargarExcav").show();
            $("#btnCargarAfecDoc").show();
            $("#btnAfectaInm").show();
            $("#btnDelRegAI").show();
            $("#btnAgregarAI").show();

        }
    }

    function fnGuardarInvI1() {
        //fnGuardarInvI10(0);
    }

    function fnDelRegistro() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("DelInvInmueble");
        var load = $("#txtUpload").val();
        console.log(load+"#");
        //$("input#param1").val(load);
        var form = $('#frmInvestigaciones').serialize();
        $.ajax({
            type: "POST",
            url: "processmuseo.aspx",
            data: form,
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listaInvInmuebles();
                $('.piluku-preloader').addClass('hidden');
            },
            error: function (result) {
                $('.piluku-preloader').addClass('hidden');
                f_Menu("frmInvestigaciones.aspx");
            }
        });
        //document.getElementById("param0").value = "";
        $("#param0").val("");
        $('div#mdDelRegistro').modal('hide');
    }

    function fnDelRegistroAI() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("DelAfectacionInmueble");
        var form = $('#frmInvestigaciones').serialize();
        $.ajax({
            type: "POST",
            url: "processmuseo.aspx",
            data: form,
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarAfectacionInmuebles();
                $('.piluku-preloader').addClass('hidden');
            },
            error: function (result) {
                $('.piluku-preloader').addClass('hidden');
                f_Menu("frmInvestigaciones.aspx");
            }
        });
        //document.getElementById("param0").value = "";
        $("#param0").val("");
        $('div#mdDelRegistroAI').modal('hide');
    }

    function fnAgregarAI() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        if ($("#txtInstancia").val() == "") {
            mensaje = "Ingrese Instancia"
            sw = 1;
        }
        if ($("#txtQuienInspAI").val() == "") {
            mensaje = "Ingrese Quién realizó inspección"
            sw = 1;
        }
        if ($("#cboRealizoInspAI").val() == "0") {
            mensaje = "Selección realizó inspección"
            sw = 1;
        }
        if ($("#txtTipoAfectAI").val() == "") {
            mensaje = "Ingrese tipo afectación"
            sw = 1;
        }
        if ($("#txtdenuncianteAI").val() == "") {
            mensaje = "Ingrese denunciado"
            sw = 1;
        }
        if ($("#txtSitioAI").val() == "") {
            mensaje = "Seleccione sitio"
            sw = 1;
        }
        if ($("#txtFechaAI").val() == "") {
            mensaje = "Seleccion Fecha"
            sw = 1;
        }
        if ($("#afeInm").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionAI"]').tab('show')
            } 
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gAfectacionInmueble");
            //var form = $('#frmCatalogo').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gAfectacionInmueble", "afeInm": $("#afeInm").val(), "txtFechaAI": $("#txtFechaAI").val(), "txtSitioAI": $("#txtSitioAI").val(), "txtdenuncianteAI": $("#txtdenuncianteAI").val(), "txtdenunciadoAI": $("#txtdenunciadoAI").val(), "txtTipoAfectAI": $("#txtTipoAfectAI").val(), "cboRealizoInspAI": $("#cboRealizoInspAI").val(), "txtQuienInspAI": $("#txtQuienInspAI").val(), "txtInstancia": $("#txtInstancia").val(), },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#afeInm').val(data[0].code);
                        listarAfectacionInmuebles();
                        //tablaCalalogosDGC()
                        $('.piluku-preloader').addClass('hidden');
                    } else {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('.piluku-preloader').addClass('hidden');
                    }
                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    console.log(result);
                }
            });
        }
        $("#param0").val("");
    }

    function listarAfectacionInmuebles() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "listarAfectacionInmueble", "afeInm": 0 },
            dataType: "json",
            async: false,
            success: function (data) {
                var tb = '';
                var i = 0;
                var mostrar = '';
                var contador = 0;
                var tipo_sexo = '';
                aData = data;
                if (aData.length > 0) {
                    for (i = 0; i < aData.length; i++) {
                        contador = contador + 1;
                        tb += '<tr>';
                        tb += '<td>';
                        tb += '<center><a href="#" class="btn btn-green btn-xs" onclick="fnEditarAI(\'' + aData[i].codigo_ain + '\')" ><i class="ion-edit"></i></a>';
                        tb += '<a href="#" class="btn btn-red btn-xs" onclick="fnBorrarAI(\'' + aData[i].codigo_ain + '\',\'' + aData[i].sitio_ain + '\')" ><i class="ion-android-cancel"></i></a></td>';
                        tb += '</center></td>';
                        tb += '<td style="text-align:center">' + aData[i].fecha_ain + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].sitio_ain + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].tipoafect_ain + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].instancia_ain + '</td>';
                        tb += '</tr>';
                    }
                } else {
                    tb = "";
                }
                fnDestroyDataTableDetalle('tbAfectacionInm');
                $('#pAfectacionInm').html(tb);
                fnResetDataTableTramite('tbAfectacionInm', 0, 'asc');
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function fnGuardarInvInv2() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        if ($("#txtEstado").val() == "") {
            mensaje = "Ingrese Estado"
            sw = 1;
        }
        if ($("#txtTipoSitio").val() == "") {
            mensaje = "Ingrese tipo Sitio"
            sw = 1;
        }
        if ($("#txtCultura").val() == "") {
            mensaje = "Ingrese Cultura"
            sw = 1;
        }
        if ($("#cboMemoria").val() == "0") {
            mensaje = "Seleccion Memoria"
            sw = 1;
        }
        if ($("#cboFichaTec").val() == "0") {
            mensaje = "Seleccione ficha ténica"
            sw = 1;
        }
        if ($("#txtElaborado").val() == "0") {
            mensaje = "Ingrese elaborado por"
            sw = 1;
        }
        if ($("#cboLevPlano").val() == "0") {
            mensaje = "Seleccione levantamiento de plano"
            sw = 1;
        }
        if ($("#txtFecha").val() == "") {
            mensaje = "Seleccion Fecha"
            sw = 1;
        }
        if ($("#invInm").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje );
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionII"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabOrigenII"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gInvInmbueble2");
            //var form = $('#frmCatalogo').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gInvInmbueble2", "invInm": $("#invInm").val(), "txtNorma": $("#txtNorma").val(), "txtFecha": $("#txtFecha").val(), "cboLevPlano": $("#cboLevPlano").val(), "txtElaborado": $("#txtElaborado").val(), "cboFichaTec": $("#cboFichaTec").val(), "cboMemoria": $("#cboMemoria").val(), "txtTipoSitio": $("#txtTipoSitio").val(), "txtCultura": $("#txtCultura").val(), "txtEstado": $("#txtEstado").val(), "txtEstado": $("#txtNombreSitioI").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#invInm').val(data[0].code);
                        listaInvInmuebles();
                        $('.piluku-preloader').addClass('hidden');
                    } else {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('.piluku-preloader').addClass('hidden');
                    }
                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    console.log(result);
                }
            });
        }
        $("#param0").val("");
    }

    function fnGuardarInvI10() {
        
        var sw = 0;
        var swTab = 1;
        var mensaje = "";

        if ($("#txtPerimetro").val() == "") {
            mensaje = "Ingrese Perimetro"
            sw = 1;
        }
        if ($("#txtDatum").val() == "") {
            mensaje = "Ingrese Datum"
            sw = 1;
        }
        if ($("#txtUTMn").val() == "") {
            mensaje = "Ingrese UTM N"
            sw = 1;
        }
        if ($("#txtUTMe").val() == "") {
            mensaje = "Ingrese UTM E"
            sw = 1;
        }
        if ($("#txtCaserio").val() == "") {
            mensaje = "Ingrese Caserio"
            sw = 1;
        }
        if ($("#txtNombreSitioI").val() == "") {
            mensaje = "Ingrese Nombre Sitio"
            sw = 1;
        }
        if ($("#invInm").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionII"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabIdentificacionII"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gInvInmbueble1");
            //var form = $('#frmCatalogo').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gInvInmbueble1", "invInm": $("#invInm").val(), "txtNombreSitioI": $("#txtNombreSitioI").val(), "txtCaserio": $("#txtCaserio").val(), "cboDepartamento": $("#cboDepartamento").val(), "dboProvincia": $("#dboProvincia").val(), "cboDistrito": $("#cboDistrito").val(), "txtUTMe": $("#txtUTMe").val(), "txtUTMn": $("#txtUTMn").val(), "txtDatum": $("#txtDatum").val(), "txtPerimetro": $("#txtPerimetro").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#invInm').val(data[0].code);
                        listaInvInmuebles();
                        $('.piluku-preloader').addClass('hidden');
                    } else {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('.piluku-preloader').addClass('hidden');
                    }
                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    console.log(result);
                }
            });
        }
        $("#param0").val("");
    }

    function limpiaInvInm() {
        $("#txtNroI").val("");
        $("#txtNombreSitioI").val("");
        $("#txtCaserio").val("");
        $("#cboDepartamento").val("0");
        $("#dboProvincia").val("0");
        $("#cboDistrito").val("0");
        $("#txtUTMe").val("");
        $("#txtUTMn").val("");
        $("#txtDatum").val("");
        $("#txtPerimetro").val("");
        $("#txtNorma").val("");
        $("#txtFecha").val("");
        $("#cboLevPlano").val("0");
        $("#txtElaborado").val("");
        $("#cboFichaTec").val("0");
        $("#cboMemoria").val("0");
        $("#txtTipoSitio").val("");
        $("#txtEstado").val("");
        $("#txtCultura").val("");
    }

    function fnArqueo() {
        CargarInmuebles1();
        $('#DivArqueo').show();
        $('#DivInventario').hide();
        $('#DivExcavaciones').hide();
        $('#DivAfecta').hide();

        $('#DivAfecDoc').hide();
        $('#DivAfecBD').hide();
    }
    
    function fnInventario() {
        listaInvInmuebles();
        $('#DivArqueo').hide();
        $('#DivExcavaciones').hide();
        $('#DivInventario').show();
        $('#DivAfecta').hide();

        $('#DivAfecDoc').hide();
        $('#DivAfecBD').hide();
    }

    function fnExcavaciones() {
        CargarInmuebles2();
        $('#DivArqueo').hide();
        $('#DivInventario').hide();
        $('#DivExcavaciones').show();
        $('#DivAfecta').hide();

        $('#DivAfecDoc').hide();
        $('#DivAfecBD').hide();
    }

    function fnAfecta() {
        $('#DivArqueo').hide();
        $('#DivInventario').hide();
        $('#DivExcavaciones').hide();
        $('#DivAfecta').show();

        $('#DivAfecDoc').hide();
        $('#DivAfecBD').hide();
    }

    function fnAfecDoc() {
        $('#DivAfecDoc').show();
        $('#DivAfecBD').hide();
        //Inicio JAZ
        CargarInmuebles3();
        //Fin JAZ
    }

    function fnAfecBD() {
        $('#DivAfecDoc').hide();
        $('#DivAfecBD').show();
        $('#afeInm').val("0");
        listarAfectacionInmuebles();
    }

    function fnEditarAI(c) {
        var x = fnBuscarAI(c);
        if (x >= 0) {
            $('#afeInm').val(aData[x].codigo_ain);
            $('#txtFechaAI').val(aData[x].fecha_ain);
            $('#txtSitioAI').val(aData[x].sitio_ain);
            $('#txtdenuncianteAI').val(aData[x].denunciante_ain);
            $('#txtdenunciadoAI').val(aData[x].denunciado_ain);
            $('#txtTipoAfectAI').val(aData[x].tipoafect_ain);

            if (aData[x].inspeccion_ain == "") {
                $('#cboRealizoInspAI').val(0);
            }
            else {
                $('#cboRealizoInspAI').val(aData[x].inspeccion_ain);
            }
            $('#txtQuienInspAI').val(aData[x].realizoinspec_ain);
            $('#txtInstancia').val(aData[x].instancia_ain);
           
        }
        $('div#mdConfirmarAfectInm').modal('show');
        return true;
    }

    function fnBuscarAI(c) {
        var i;
        var j = -1;
        var l;
        l = aData.length;
        for (i = 0; i < l; i++) {
            if (aData[i].codigo_ain == c) {
                j = i;
                return j;
            }
        }
    }


    function fnEditarII(c) {
        var x = fnBuscar(c);
        if (x >= 0) {
            $('#invInm').val(aData[x].codigo_inm);
            $('#txtNroI').val(aData[x].codigo_inm);
            $('#txtNombreSitioI').val(aData[x].nombresitio_inm);
            $('#txtCaserio').val(aData[x].caserio_inm);

            if (aData[x].departamento_inm == "") {
                $('#cboDepartamento').val(0);
            }
            else {
                $('#cboDepartamento').val(aData[x].departamento_inm);
            }
            if (aData[x].provincia_inm == "") {
                $('#dboProvincia').val(0);
            }
            else {
                $('#dboProvincia').val(aData[x].provincia_inm);
            }
            if (aData[x].distrito_inm == "") {
                $('#cboDistrito').val(0);
            }
            else {
                $('#cboDistrito').val(aData[x].distrito_inm);
            }

            $('#txtUTMe').val(aData[x].utme_inm);
            $('#txtUTMn').val(aData[x].utmn_inm);
            $('#txtDatum').val(aData[x].datum_inm);
            $('#txtPerimetro').val(aData[x].perimetro_inm);
            
            $('#txtNorma').val(aData[x].normalega_inm);
            $('#txtFecha').val(aData[x].fecha_inm);
            if (aData[x].levplano_inm == "") {
                $('#cboLevPlano').val(0);
            }
            else {
                $('#cboLevPlano').val(aData[x].levplano_inm);
            }
            $('#txtElaborado').val(aData[x].elaboroplano_inm);
            if (aData[x].fichatec_inm == "") {
                $('#cboFichaTec').val(0);
            }
            else {
                $('#cboFichaTec').val(aData[x].fichatec_inm);
            }            
            if (aData[x].memoriades_inm == "") {
                $('#cboMemoria').val(0);
            }
            else {
                $('#cboMemoria').val(aData[x].memoriades_inm);
            }
            $('#txtCultura').val(aData[x].cultur_inm);
            $('#txtTipoSitio').val(aData[x].tipositio_inm);
            $('#txtEstado').val(aData[x].estado_inm);
        }
        $('div#mdConfirmarInvInm').modal('show');
        return true;
    }

    function fnBuscar(c) {
        var i;
        var j = -1;
        var l;
        l = aData.length;
        for (i = 0; i < l; i++) {
            if (aData[i].codigo_inm == c) {
                j = i;
                return j;
            }
        }
    }


    function listaInvInmuebles() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "ListaInvInmbueble", "invInm": 0 },
            dataType: "json",
            async: false,
            success: function (data) {
                var tb = '';
                var i = 0;
                var mostrar = '';
                var contador = 0;
                var tipo_sexo = '';
                aData = data;
                if (aData.length > 0) {
                    for (i = 0; i < aData.length; i++) {
                        contador = contador + 1;
                        tb += '<tr>';
                        tb += '<td>';
                        tb += '<center><a href="#" class="btn btn-green btn-xs" onclick="fnEditarII(\'' + aData[i].codigo_inm + '\')" ><i class="ion-edit"></i></a>';
                        tb += '<a href="#" class="btn btn-red btn-xs" onclick="fnBorrarII(\'' + aData[i].codigo_inm + '\',\'' + aData[i].nombresitio_inm + '\')" ><i class="ion-android-cancel"></i></a></td>';
                        tb += '</center></td>';
                        tb += '<td style="text-align:center">' + aData[i].nombresitio_inm + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].distrito_inm + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].normalega_inm + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].cultur_inm + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].tipositio_inm + '</td>';
                        tb += '</tr>';
                    }
                } else {
                    tb = "";
                }
                fnDestroyDataTableDetalle('tbInventario');
                $('#pInventario').html(tb);
                fnResetDataTableTramite('tbInventario', 0, 'asc');
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function fnBorrarII(c, d) {
        $("#param1").val(c);
        $("#Dato").html("<label class='col-md-12 control-label'> Desea Confirmar la Eliminaci&oacute;n del Registro: " + d + "</label>");
        $('div#mdDelRegistro').modal('show');

        return true;
    }

    function fnBorrarAI(c, d) {
        $("#param1").val(c);
        $("#DatoAI").html("<label class='col-md-12 control-label'> Desea Confirmar la Eliminaci&oacute;n del Registro: " + d + "</label>");
        $('div#mdDelRegistroAI').modal('show');
        return true;
    }

    function CargarMuebles() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "ListarMuebles" },
            dataType: "json",
            async: false,
            success: function (data) {
                var tb = '';
                var i = 0;
                var mostrar = '';
                var contador = 0;
                var tipo_sexo = '';
                aData = data;
                if (aData.length > 0) {
                    for (i = 0; i < aData.length; i++) {
                        contador = contador + 1;
                        tb += '<tr>';
                        tb += '<td style="text-align:center">' + contador + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].anio_mue + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].coleccion_mue + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].tipoarchivo_mue + '</td>';
                        if (aData[i].archivo == "" || aData[i].archivo == "0") {
                            tb += '<td style="text-align:center"> Sin Archivo </td>';
                        } else {
                            tb += '<td style="text-align:center"> <a onclick="fnDownload(\'' + aData[i].archivo + '\')" target="_blank" style="font-weight:bold;color:blue;"> Descargar</a>';
                           
                        }
                        tb += '</tr>';
                    }
                } else {
                    tb = "";
                }
                fnDestroyDataTableDetalle('tbMuebles');
                $('#pMuebles').html(tb);
                fnResetDataTableTramite('tbMuebles', 0, 'asc');
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function CargarInmuebles1() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "ListarInmuebles1" },
            dataType: "json",
            async: false,
            success: function (data) {
                var tb = '';
                var i = 0;
                var mostrar = '';
                var contador = 0;
                var tipo_sexo = '';
                aData = data;
                if (aData.length > 0) {
                    for (i = 0; i < aData.length; i++) {
                        contador = contador + 1;
                        tb += '<tr>';
                        tb += '<td style="text-align:center">' + contador + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].sitio_arq + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].tipoarchivo_arq + '</td>';
                        if (aData[i].archivo == "" || aData[i].archivo == "0") {
                            tb += '<td style="text-align:center"> Sin Archivo </td>';
                        } else {
                            tb += '<td style="text-align:center"> <a onclick="fnDownload(\'' + aData[i].archivo + '\')" target="_blank" style="font-weight:bold;color:blue;"> Descargar</a>';

                        }
                        tb += '</tr>';
                    }
                } else {
                    tb = "";
                }
                fnDestroyDataTableDetalle('tbArque');
                $('#pArque').html(tb);
                fnResetDataTableTramite('tbArque', 0, 'asc');
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function CargarInmuebles2() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "ListarInmuebles2" },
            dataType: "json",
            async: false,
            success: function (data) {
                var tb = '';
                var i = 0;
                var mostrar = '';
                var contador = 0;
                var tipo_sexo = '';
                aData = data;
                if (aData.length > 0) {
                    for (i = 0; i < aData.length; i++) {
                        contador = contador + 1;
                        tb += '<tr>';
                        tb += '<td style="text-align:center">' + contador + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].anio_exc + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].proyecto_exc + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].tipoarchivo_exc + '</td>';
                        if (aData[i].archivo == "" || aData[i].archivo == "0") {
                            tb += '<td style="text-align:center"> Sin Archivo </td>';
                        } else {
                            tb += '<td style="text-align:center"> <a onclick="fnDownload(\'' + aData[i].archivo + '\')" target="_blank" style="font-weight:bold;color:blue;"> Descargar</a>';

                        }
                        tb += '</tr>';
                    }
                } else {
                    tb = "";
                }
                fnDestroyDataTableDetalle('tbExcava');
                $('#pExcava').html(tb);
                fnResetDataTableTramite('tbExcava', 0, 'asc');
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function CargarInmuebles3() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "ListarInmuebles3" },
            dataType: "json",
            async: false,
            success: function (data) {
                var tb = '';
                var i = 0;
                var mostrar = '';
                var contador = 0;
                var tipo_sexo = '';
                aData = data;
                if (aData.length > 0) {
                    for (i = 0; i < aData.length; i++) {
                        contador = contador + 1;
                        tb += '<tr>';
                        //Inicio JAZ
                        //tb += '<td style="text-align:center">' + contador + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].codigo_ado + '</td>';
                        //Fin JAZ
                        tb += '<td style="text-align:center">' + aData[i].anio_ado + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].sitio_ado + '</td>';
                        if (aData[i].archivo == "" || aData[i].archivo == "0") {
                            tb += '<td style="text-align:center"> Sin Archivo </td>';
                        } else {
                            tb += '<td style="text-align:center"> <a onclick="fnDownload(\'' + aData[i].archivo + '\')" target="_blank" style="font-weight:bold;color:blue;"> Descargar</a>';

                        }
                        tb += '</tr>';
                    }
                } else {
                    tb = "";
                }
                fnDestroyDataTableDetalle('tbAfecDoc');
                $('#pAfecDoc').html(tb);
                fnResetDataTableTramite('tbAfecDoc', 0, 'asc');
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function lstColecciones() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstColeccionInvestig" },
            dataType: "json",
            async: false,
            success: function (data) {
                var i = 0;
                var t = '';
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        t += '<option value="' + data[i].valor + '" ' + data[i].selected + '>' + data[i].descripcion + '</option>';
                    }
                }
                $('#cboColeccion').html(t);
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function fnCargaLista(param) {
        try {
            var arr;
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": param },
                async: false,
                cache: false,
                success: function (data) {
                    arr = data;
                },
                error: function (result) {
                    arr = null;
                }
            })
            return arr;
        }
        catch (err) {
            //alert(err.message);
            console.log('error');
        }
    }

    function fnBienesMuebles() {
        CargarMuebles();
        $('#DivMuebles').show();
        $('#DivInmuebles').hide();
    }

    function fnBienesInmuebles() {
        $('#DivInmuebles').show();
        $('#DivMuebles').hide();
        
        $('#DivArqueo').hide();
        $('#DivInventario').hide();
        $('#DivExcavaciones').hide();
        $('#DivAfecta').hide();
    }

    function fnDownload(id_ar) {
        var flag = false;
        var form = new FormData();
        form.append("param0", "Download2");
        form.append("IdArchivo", id_ar);
        form.append("area", 10);
        // alert();
        //            console.log(form);
        $.ajax({
            type: "POST",
            url: "processmuseo.aspx",
            data: form,
            dataType: "json",
            cache: false,
            contentType: false,
            processData: false,
            success: function (data) {
                flag = true;

                var file = 'data:application/octet-stream;base64,' + data[0].File;
                var link = document.createElement("a");
                link.download = data[0].Nombre;
                link.href = file;
                link.click();
            },
            error: function (result) {
                console.log(result);
                flag = false;
            }
        });
        return flag;
    }


    function fnMostrarImagen(id_ar, id) {
        var flag = false;
        var form = new FormData();
        form.append("param0", "Download2");
        form.append("IdArchivo", id_ar);
        form.append("area", 1);
        // alert();
        //            console.log(form);
        $.ajax({
            type: "POST",
            url: "processmuseo.aspx",
            data: form,
            dataType: "json",
            cache: false,
            contentType: false,
            processData: false,
            success: function (data) {
                flag = true;

                var file = 'data:application/octet-stream;base64,' + data[0].File;
                $('#' + id).attr('src', file);
            },
            error: function (result) {
                console.log(result);
                flag = false;
            }
        });
        return flag;
    }

    function fnCargar() {
        var sw = 0;
        var swTab = 0;
        var mensaje = "";
        var swvalida = 0;
        if ($("#txtAnio").val() == "") {
            mensaje = "Ingrese Año"
            sw = 1;
        }
        if ($("#cboColeccion").val() == "0") {
            mensaje = "Seleccione coleccion"
            sw = 1;
        }
        if ($("#cboTipoArchivo").val() == "0") {
            mensaje = "Seleccione tipo archivo"
            sw = 1;
        }
        if ($("#file").val() == "") {
            mensaje = "Seleccione archivo"
            sw = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gMuebles1");
            var form = $('#frmInvestigaciones').serialize();
            $.ajax({
                type: "POST",
                //contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        if ($("#file").val() != "") {
                            SubirArchivo(data[0].code, "MUEBLE");
                        }
                        fnMensaje(data[0].alert, data[0].msje);
                    } else {
                        fnMensaje("Error", "Error en el proceso");
                    }

                    $('.piluku-preloader').addClass('hidden');
                    limpiarMuebles();
                    CargarMuebles();
                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    //console.log(result);
                }
            });
        }
        $("#param0").val("");

    }

    function fnCargarArq() {
        var sw = 0;
        var swTab = 0;
        var mensaje = "";
        var swvalida = 0;
        if ($("#txtSitio").val() == "") {
            mensaje = "Ingrese Sitio"
            sw = 1;
        }
        if ($("#cbTipoArq").val() == "0") {
            mensaje = "Seleccione tipo "
            sw = 1;
        }
        if ($("#fileArq").val() == "") {
            mensaje = "Seleccione archivo"
            sw = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gInmuebles1");
            var form = $('#frmInvestigaciones').serialize();
            $.ajax({
                type: "POST",
                //contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        if ($("#fileArq").val() != "") {
                            SubirArchivo(data[0].code, "ARQUE");
                        }
                        fnMensaje(data[0].alert, data[0].msje);
                    } else {
                        fnMensaje("Error", "Error en el proceso");
                    }

                    $('.piluku-preloader').addClass('hidden');
                    limpiarInmuebles1();
                    CargarInmuebles1();
                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    //console.log(result);
                }
            });
        }
        $("#param0").val("");
    }

    
    function fnCargarExcav() {
        var sw = 0;
        var swTab = 0;
        var mensaje = "";
        var swvalida = 0;
        if ($("#AnioExca").val() == "") {
            mensaje = "Ingrese Año"
            sw = 1;
        }
        if ($("#ProyectoExca").val() == "") {
            mensaje = "Ingrese Proyecto"
            sw = 1;
        }
        if ($("#cbTipoExca").val() == "0") {
            mensaje = "Seleccione tipo "
            sw = 1;
        }
        if ($("#fileExcav").val() == "") {
            mensaje = "Seleccione archivo"
            sw = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gInmuebles2");
            var form = $('#frmInvestigaciones').serialize();
            $.ajax({
                type: "POST",
                //contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        if ($("#fileExcav").val() != "") {
                            SubirArchivo(data[0].code, "EXCAV");
                        }
                        fnMensaje(data[0].alert, data[0].msje);
                    } else {
                        fnMensaje("Error", "Error en el proceso");
                    }

                    $('.piluku-preloader').addClass('hidden');
                    limpiarInmuebles2();
                    CargarInmuebles2();
                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    //console.log(result);
                }
            });
        }
        $("#param0").val("");
    }

    
    function fnCargarAfecDoc() {
        var sw = 0;
        var swTab = 0;
        var mensaje = "";
        var swvalida = 0;
        if ($("#txtAnioAfecDoc").val() == "") {
            mensaje = "Ingrese Año"
            sw = 1;
        }
        if ($("#txtProyectoAfec").val() == "") {
            mensaje = "Ingrese Sitio"
            sw = 1;
        }
        //Inicio JAZ
        if ($("#file_AfecDoc").val() == "") {
            mensaje = "Seleccione un archivo"
            sw = 1;
        }
        //Fin JAZ
        if (sw == 1) {
            fnMensaje("error", mensaje);
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gInmuebles3");
            var form = $('#frmInvestigaciones').serialize();

            $.ajax({
                type: "POST",
                //contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        if ($("#file_AfecDoc").val() != "") {
                            SubirArchivo(data[0].code, "AFECT");
                        }
                        fnMensaje(data[0].alert, data[0].msje);
                    } else {
                        fnMensaje("Error", "Error en el proceso");
                    }

                    $('.piluku-preloader').addClass('hidden');
                    limpiarInmuebles3();
                    CargarInmuebles3();
                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    //console.log(result);
                }
            });
        }
        $("#param0").val("");
    }

    function SubirArchivo(cod, tipo) {

        var flag = false;
        try {
            var data = new FormData();
            data.append("param0", "SurbirArchivoMueble");
            data.append("codigo", cod);
            data.append("tipo", tipo);

            if (tipo == "MUEBLE") {
                var files = $("#file").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "ARQUE") {
                var files = $("#fileArq").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "EXCAV") {
                var files = $("#fileExcav").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "AFECT") {
                var files = $("#file_AfecDoc").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (files.length > 0) {
                $.ajax({
                    type: "POST",
                    url: "processmuseo.aspx",
                    data: data,
                    dataType: "json",
                    cache: false,
                    contentType: false,
                    processData: false,
                    async: false,
                    success: function (data) {
                        flag = true;
                        //console.log('ARCHIVO SUBIDO');
                    },
                    error: function (result) {
                        //console.log('falseee');
                        flag = false;
                    }
                });
            }
            return flag;

        }
        catch (err) {
            return false;
        }
    }

    function limpiarMuebles() {
        $("#param0").val("");
        $("#txtAnio").val("");
        $("#cboColeccion").val("0");
        $("#cboTipoArchivo").val("0");
        $("#file").val("");
    }

    function limpiarInmuebles1() {
        $("#param0").val("");
        $("#cbTipoArq").val("0");
        $("#fileArq").val("");
    }

    function limpiarInmuebles2() {
        $("#param0").val("");
        $("#AnioExca").val("");
        $("#ProyectoExca").val("");
        $("#cbTipoExca").val("0");
        $("#fileExcav").val("");
    }

    function limpiarInmuebles3() {
        $("#param0").val("");
        $("#txtAnioAfecDoc").val("");
        $("#txtProyectoAfec").val("");
        $("#file_AfecDoc").val("");
    }



        function soloNumeros(evt, input) {
            // Backspace = 8, Enter = 13, ‘0′ = 48, ‘9′ = 57, ‘.’ = 46, ‘-’ = 43
            var key = window.Event ? evt.which : evt.keyCode;
            var chark = String.fromCharCode(key);
            var tempValue = input.value + chark;
            if (key >= 48 && key <= 57) {
                if (filter(tempValue) === false) {
                    return false;
                } else {
                    return true;
                }
            } else {
                if (key == 8 || key == 13 || key == 0) {
                    return true;
                } else if (key == 46) {
                    if (filter(tempValue) === false) {
                        return false;
                    } else {
                        return true;
                    }
                } else {
                    return false;
                }
            }
        }
        function filter(__val__) {
            var preg = /^([0-9]+\.?[0-9]{0,2})$/;
            if (preg.test(__val__) === true) {
                return true;
            } else {
                return false;
            }

        }

</script>


</head>

<body  >

    <form id="frmInvestigaciones" name="frmInvestigaciones" runat="server">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="paramdgc" name="paramdgc" value="" runat="server" /> 
    <input type="hidden" id="eval" name="eval" value="" /> 
    <input type="hidden" id="invInm" name="invInm" value="" /> 
    <input type="hidden" id="afeInm" name="afeInm" value="" /> 
    <input type="hidden" id="tfu" name="tfu" value="" runat="server"/> 
            
        <div class="row">
    <div class="panel panel-piluku">

            <div class="panel-heading">
		        <h3 class="panel-title">
			        
                    <div class="col-md-6" align="left" >
                          <div id="titulo" runat="server"> INVESTIGACIONES</div>  
                    </div>
                    <div class="col-md-5" align="right">
                            <%--<button type="button" class="btn btn-white " id="btnExportarRep" runat="server" ><i class="ion-android-download"></i>&nbsp;Exportar Reporte</button>--%>	
                    </div>                       
                </h3>
	        </div>	  
	        <div class='table-responsive'>	        
                <div class='panel-body' >
                    <center>
                        <a href="#" id="btnBienesMuebles" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Bienes Muebles</a>
                        <a href="#" id="btnBienesInmuebles" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Bienes Inmuebles</a>
                    </center>
                        
                    <div class='table-responsive' id="DivMuebles">
                        <br />
                        <center>
                            <div class="row">
                            
                                <div class="form-group">
                                    <label class="col-sm-1 control-label" for="txtAnio">
                                        Año:</label>
                                    <div class="col-sm-1">
                                        <input type="text" id="txtAnio" name="txtAnio" class="form-control" />
                                    </div>
                                </div>  
                                <div class="form-group">
                                    <label class="col-sm-1 control-label" for="cboColeccion">
                                        Colección:</label>
                                    <div class="col-sm-3">
                                        <select class="form-control" id="cboColeccion" name="cboColeccion">
                                        </select>
                                    </div>
                                </div>  
                            </div>
                            <br />
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-1 control-label" for="txtAnio">
                                        Tipo:</label>
                                    <div class="col-sm-2">
                                        <select class="form-control" id="cboTipoArchivo" name="cboTipoArchivo">
                                            <option value="0">-- Seleccione -- </option>
                                            <option value="1">Informe y BD</option>
                                            <option value="2">Archivo Fotográfico</option>
                                        </select> 
                                    </div>
                                </div> 
                                <div class="form-group">
                                    <label class="col-sm-1 control-label" for="txtAnio">
                                        Archivo:</label>
                                    <div class="col-sm-2">
                                        <input type="file" id="txtUpload" name="txtUpload" class="form-control" />
                                        <button type="button" class="btn btn-green" id="btnCargar"><i class="ion-android-done"></i>&nbsp;Cargar</button>	
                                    </div>
                                </div>  
                            </div>               
                        </center>  

                        <table class='display dataTable cell-border' id='tbMuebles' style="width:95%;font-size:smaller;" >
                            <thead>
                            <tr>
                                    <th style="width:6%;text-align:center;"></th>
                                    <th style="width:15%;text-align:center;">Año</th>
                                    <th style="width:20%;text-align:center;">Colección</th>
                                    <th style="width:10%;text-align:center;">Tipo Archivo</th>
                                    <th style="width:10%;text-align:center;">Archivo</th>
                                </tr>
                                </thead>     
                                <tbody id ="pMuebles" runat ="server">
                                </tbody>                             
                                <tfoot>
                                <tr>
                                <th colspan="6"></th>
                                </tr>
                                </tfoot>
                        </table>
                    </div>    
                    <div class='table-responsive' id="DivInmuebles"> 
                        <br />
                        <center>
                            <a href="#" id="btnArqueo" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Sitio Arqueológicos</a>
                            <a href="#" id="btnInventario" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Inventario</a>
                            <a href="#" id="btnExcavaciones" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Excavaciones</a>
                            <a href="#" id="btnAfecta" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Afectaciones</a>
                        </center>
                        <div class='table-responsive' id="DivArqueo">
                             <br />
                            <center>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-1 control-label" for="txtSitio">
                                            Sitio:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtSitio" name="txtSitio" class="form-control" />
                                        </div>
                                    </div>  
                                    <div class="form-group">
                                        <label class="col-sm-1 control-label" for="txtAnio">
                                            Tipo:</label>
                                        <div class="col-sm-1">
                                                <select class="form-control" id="cbTipoArq" name="cbTipoArq">
                                                <option value="0">-- Seleccione -- </option>
                                                <option value="1">Documentación</option>
                                                <option value="2">Planos</option>
                                            </select> 
                                        </div>
                                    </div>   
                                    <div class="form-group">
                                        <div class="col-sm-1">
                                            <button type="button" class="btn btn-green" id="btnCargarArq" ><i class="ion-android-done"></i>&nbsp;Cargar</button>	
                                        </div>
                                    </div>  
                                </div>
                                <br />
                                <div class="row">
                                
                                    <div class="form-group">
                                        <label class="col-sm-1 control-label" for="fileArq">
                                            Archivo:</label>
                                        <div class="col-sm-2">
                                            <input type="file" id="fileArq" name="fileArq" />
                                        </div>
                                    </div>   
                                </div>               
                            </center>  
                             <br />
                             <table class='display dataTable cell-border' id='tbArque' style="width:950%;font-size:smaller;" >
                                <thead>
                                <tr>
                                        <th style="width:6%;text-align:center;"></th>
                                        <th style="width:15%;text-align:center;">Sitio</th>
                                        <th style="width:20%;text-align:center;">Tipo</th>
                                        <th style="width:10%;text-align:center;">Archivo</th>
                                    </tr>
                                    </thead>     
                                    <tbody id ="pArque" runat ="server">
                                    </tbody>                             
                                    <tfoot>
                                    <tr>
                                    <th colspan="4"></th>
                                    </tr>
                                    </tfoot>
                            </table>
                         </div>

                        <div class='table-responsive' id="DivInventario">
                             <br />
                             <table class='display dataTable cell-border' id='tbInventario' style="width:95%;font-size:smaller;" >
                                <thead>
                                <tr>
                                        <th style="width:6%;text-align:center;"></th>
                                        <th style="width:15%;text-align:center;">Nombre Sitio</th>
                                        <th style="width:20%;text-align:center;">Distrito</th>
                                        <th style="width:10%;text-align:center;">Norma Legal</th>
                                        <th style="width:10%;text-align:center;">Cultura</th>
                                        <th style="width:10%;text-align:center;">Tipo Sitio</th>

                                    </tr>
                                    </thead>     
                                    <tbody id ="pInventario" runat ="server">
                                    </tbody>                             
                                    <tfoot>
                                    <tr>
                                    <th colspan="6"></th>
                                    </tr>
                                    </tfoot>
                            </table>
                            <center>
                                <a href="#" id="btnInvInmebles" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Agregar Inventario Inmuebles</a>
                                <button type="button" class="btn btn-white " id="btnExportarRep" runat="server" ><i class="ion-android-download"></i>&nbsp;Exportar Reporte</button>	
                        
                            </center>
                         </div>

                        <div class='table-responsive' id="DivExcavaciones">
                             <br />
                            <center>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-1 control-label" for="AnioExca">
                                            Año:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="AnioExca" name="AnioExca" class="form-control" />
                                        </div>
                                    </div>  
                                    <div class="form-group">
                                        <label class="col-sm-1 control-label" for="ProyectoExca">
                                            Proyecto:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="ProyectoExca" name="ProyectoExca" class="form-control" />
                                        </div>
                                    </div>  
                                   
                                    <div class="form-group">
                                        <div class="col-sm-1">
                                            <button type="button" class="btn btn-green" id="btnCargarExcav" ><i class="ion-android-done"></i>&nbsp;Cargar</button>	
                                        </div>
                                    </div>  
                                </div>
                                <br />
                                <div class="row">
                                     <div class="form-group">
                                        <label class="col-sm-1 control-label" for="cbTipoExca">
                                            Tipo:</label>
                                        <div class="col-sm-1">
                                                <select class="form-control" id="cbTipoExca" name="cbTipoExca">
                                                <option value="0">-- Seleccione -- </option>
                                                <option value="1">Resoluciones</option>
                                                <option value="2">Actas</option>
                                                <option value="3">Informes Técnicos</option>
                                            </select> 
                                        </div>
                                    </div>   
                                    <div class="form-group">
                                        <label class="col-sm-1 control-label" for="fileExcav">
                                            Archivo:</label>
                                        <div class="col-sm-2">
                                            <input type="file" id="fileExcav" name="fileExcav" />
                                        </div>
                                    </div>   
                                </div>               
                            </center>  
                             <br />
                             <table class='display dataTable cell-border' id='tbExcava' style="width:950%;font-size:smaller;" >
                                <thead>
                                <tr>
                                        <th style="width:6%;text-align:center;"></th>
                                        <th style="width:15%;text-align:center;">Año</th>
                                        <th style="width:20%;text-align:center;">Proyecto</th>
                                        <th style="width:20%;text-align:center;">Tipo</th>
                                        <th style="width:10%;text-align:center;">Archivo</th>
                                    </tr>
                                    </thead>     
                                    <tbody id ="pExcava" runat ="server">
                                    </tbody>                             
                                    <tfoot>
                                    <tr>
                                    <th colspan="5"></th>
                                    </tr>
                                    </tfoot>
                            </table>
                         </div>

                        <div class='table-responsive' id="DivAfecta">
                             <br />
                            <center>
                                <a href="#" id="btnAfecDoc" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Documentación</a>
                                <a href="#" id="btnAfecBD" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Base de Datos</a>
                            </center>  
                            <div class='table-responsive' id="DivAfecDoc">
                            <br />
                            <center>
                                <div class="row">
                            
                                    <div class="form-group">
                                        <label class="col-sm-1 control-label" for="txtAnioAfecDoc">
                                            Año:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtAnioAfecDoc" name="txtAnioAfecDoc" class="form-control" />
                                        </div>
                                    </div>  
                                    <div class="form-group">
                                        <label class="col-sm-1 control-label" for="txtProyectoAfec">
                                            Sitio:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtProyectoAfec" name="txtProyectoAfec" class="form-control" />
                                        </div>
                                    </div>  
                                    <div class="form-group">
                                        <div class="col-sm-1">
                                            <button type="button" class="btn btn-green" id="btnCargarAfecDoc" ><i class="ion-android-done"></i>&nbsp;Cargar</button>	
                                        </div>
                                    </div>  
                                    </div>
                                    <br />
                                    <div class="row">  
                                        <div class="form-group">
                                            <label class="col-sm-1 control-label" for="file_AfecDoc">
                                                Archivo:</label>
                                            <div class="col-sm-2">
                                                <input type="file" id="file_AfecDoc" name="file_AfecDoc" />
                                            </div>
                                        </div>   
                                    </div>               
                                </center>  

                                <table class='display dataTable cell-border' id='tbAfecDoc' style="width:95%;font-size:smaller;" >
                                    <thead>
                                    <tr>
                                            <th style="width:6%;text-align:center;"></th>
                                            <th style="width:15%;text-align:center;">Año</th>
                                        <%--Inicio JAZ--%>
                                            <%--<th style="width:20%;text-align:center;">Proyecto</th>--%>
                                            <th style="width:20%;text-align:center;">Sitio</th>
                                        <%--Fin JAZ--%>
                                            <th style="width:10%;text-align:center;">Archivo</th>
                                        </tr>
                                        </thead>     
                                        <tbody id ="pAfecDoc" runat ="server">
                                        </tbody>                             
                                        <tfoot>
                                        <tr>
                                        <th colspan="4"></th>
                                        </tr>
                                        </tfoot>
                                </table>
                            </div>    
                            
                            <div class='table-responsive' id="DivAfecBD">
                            <br />
                                <table class='display dataTable cell-border' id='tbAfectacionInm' style="width:95%;font-size:smaller;" >
                                    <thead>
                                    <tr>
                                        <th style="width:6%;text-align:center;"></th>
                                        <th style="width:15%;text-align:center;">Fecha</th>
                                        <th style="width:20%;text-align:center;">Sitio</th>
                                        <th style="width:10%;text-align:center;">Tipo</th>
                                        <th style="width:10%;text-align:center;">Instancia</th>
                                    </tr>
                                    </thead>     
                                        <tbody id ="pAfectacionInm" runat ="server">
                                        </tbody>                             
                                    <tfoot>
                                    <tr>
                                        <th colspan="6"></th>
                                    </tr>
                                    </tfoot>
                                </table>
                                <center>
                                    <a href="#" id="btnAfectaInm" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Afectación Inmuebles</a>
                                    <button type="button" class="btn btn-white " id="btnExportarRepAI" runat="server" ><i class="ion-android-download"></i>&nbsp;Exportar Reporte</button>	
                        
                                </center>
                            </div>    

                         </div>


                    </div>               
                </div> 
     
            </div> 
        </div>
    </div>


<div class="modal fade " id="mdConfirmarAfectInm" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-jr">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Afectación Inmuebles</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="Li1" runat="server" ><a href="#tabIdentificacionAI" aria-controls="home" role="tab" data-toggle="tab" > Datos</a></li>
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">
	
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacionAI" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroAI">
                                            N° :</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="Text1" name="txtNroAI" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtFechaAI">
                                            Fecha:</label>
                                            <div class="col-sm-2" id="Div1">
                                                <div class="input-group date">
									                <input type="text" class="form-control" id="txtFechaAI" name="txtFechaAI" data-provide="datepicker"/>
									                <span class="input-group-addon bg">
										                <i class="ion ion-ios-calendar-outline"></i>
									                </span>
							                    </div>	
                                            </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSitioAI" >
                                            Sitio:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtSitioAI" name="txtSitioAI" class="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtdenuncianteAI">
                                            Denunciante:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtdenuncianteAI" name="txtdenuncianteAI" class="form-control"/>                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                     <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtdenunciadoAI">
                                            Denunciado:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtdenunciadoAI" name="txtdenunciadoAI" class="form-control"/>                                            
                                        </div>
                                    </div>
                                     <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTipoAfectAI">
                                            Tipo Afectación:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtTipoAfectAI" name="txtTipoAfectAI" class="form-control"/>                                                                                        
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboRealizoInspAI">
                                            Realizó Inspección:</label>
                                        <div class="col-sm-3">
                                            <select class="form-control" id="cboRealizoInspAI" name="cboRealizoInspAI">
                                                   <option value="0" selected>-- Seleccione -- </option>
                                                   <option value="1">SI</option>
                                                   <option value="2">NO</option>
                                               </select> 
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtQuienInspAI">
                                            Quién realizó Insp:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtQuienInspAI" name="txtQuienInspAI" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtInstancia">
                                            Instancia Denuncia:</label>
                                        <div class="col-sm-3">
                                             <select class="form-control" id="txtInstancia" name="txtInstancia">
                                                   <option value="0" selected>-- Seleccione -- </option>
                                                   <option value="1">DENUNCIA EN COMISARIA</option>
                                                   <option value="2">DENUNCIA EN FISCALÍA</option>
                                                     <option value="3">PROCESO JUDICIAL</option>
                                                     <option value="4">ARCHIVADO</option>
                                                     <option value="5">JUICIO GANADO</option>
                                                     <option value="6">JUICIO PERDIDO</option>
                                               </select>
                                        </div>
                                    </div>
                                </div>
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnAgregarAI" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
                                                
                    </div> 
                    
	            </div> 
            </div> 

        </div>
    </div>
</div>
</div>

<div class="modal fade " id="mdConfirmarInvInm" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-jr">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Inventario Inmuebles</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="Li11" runat="server" ><a href="#tabIdentificacionII" aria-controls="home" role="tab" data-toggle="tab" > Identificaci&oacute;n</a></li>
					    <li role="presentationlogin" id="Li10" runat="server" ><a href="#tabOrigenInvII" aria-controls="profile" role="tab" data-toggle="tab" > Datos Adicionales</a></li>
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">
	
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacionII" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroI">
                                            N° :</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNroI" name="txtNroI" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNombreSitioI">
                                            Nombre Sitio:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNombreSitioI" name="txtNombreSitioI" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCaserio" >
                                            Caserio:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCaserio" name="txtCaserio" class="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboDepartamento">
                                            Departamento:</label>
                                        <div class="col-sm-3">
                                            <select class="form-control" id="cboDepartamento" name="cboDepartamento"></select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                     <div class="form-group">
                                        <label class="col-sm-2 control-label" for="dboProvincia">
                                            Provincia:</label>
                                        <div class="col-sm-3">
                                            <select class="form-control" id="dboProvincia" name="dboProvincia"></select>
                                        </div>
                                    </div>
                                     <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboDistrito">
                                            Distrito:</label>
                                        <div class="col-sm-3">
                                            <select class="form-control" id="cboDistrito" name="cboDistrito"></select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUTMe">
                                            UTM E [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtUTMe" name="txtUTMe" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUTMn">
                                            UTM N [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtUTMn" name="txtUTMn" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDatum">
                                            DATUM:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDatum" name="txtDatum" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPerimetro">
                                            Perimetro [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtPerimetro" name="txtPerimetro" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarInvI1" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
                        <div role="tabpanel" class="tab-pane " id="tabOrigenInvII" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNorma">
                                            Norma Legal:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNorma" name="txtNorma" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtFecha">
                                            Fecha:</label>
                                         <div class="col-sm-2" id="Div17">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFecha" name="txtFecha" data-provide="datepicker"/>
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>	
                                    </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboLevPlano">
                                            Levant. Plano:</label>
                                        <div class="col-sm-3">
                                            <select class="form-control" id="cboLevPlano" name="cboLevPlano">
                                                <option value="0">-- Seleccione -- </option>
                                                   <option value="1">SI</option>
                                                   <option value="2">NO</option>
                                            </select>                  
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtElaborado">
                                            Elaboró Plano:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtElaborado" name="txtElaborado" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboFichaTec">
                                            Ficha Técnica:</label>
                                        <div class="col-sm-3">
                                                <select class="form-control" id="cboFichaTec" name="cboFichaTec">
                                                    <option value="0">-- Seleccione -- </option>
                                                   <option value="1">SI</option>
                                                   <option value="2">NO</option>
                                                </select>              
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboMemoria">
                                            Memoria descriptiva:</label>
                                        <div class="col-sm-3">
                                              <select class="form-control" id="cboMemoria" name="cboMemoria">
                                                  <option value="0">-- Seleccione -- </option>
                                                   <option value="1">SI</option>
                                                   <option value="2">NO</option>
                                              </select>              
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTipoSitio">
                                            Tipo Sitio:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtTipoSitio" name="txtTipoSitio" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtEstado">
                                           Estado conserv.:</label>
                                        <div class="col-sm-3">
                                             <input type="text" id="txtEstado" name="txtEstado" class="form-control" />         
                                        </div>
                                    </div>
                                </div>                              
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCultura">
                                            Cultura:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCultura" name="txtCultura" class="form-control" />
                                        </div>
                                    </div>                                    
                                </div>  
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarInvI2" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

                        </div>
                        
                    </div> 
                    
	            </div> 
            </div> 

        </div>
    </div>
</div>
</div>

<div class="modal fade" id="mdDelRegistro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header" style="background-color:#E33439;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Confirmar Operaci&oacute;n</h4>
		</div>
		<div class="modal-body">
            <div class="row">
	            <div class="col-md-12" id="Dato">
	                
	            </div>
            </div>
	            
		</div>		
		<div class="modal-footer">
		  <center>
		      <div class="btn-group">			      
		            <button type="button" class="btn btn-primary" id="btnDelReg" ><i class="ion-android-done"></i>&nbsp;SI</button>	
		            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="ion-android-cancel"></i>&nbsp;NO</button>		
		       </div>
		  </center>
		</div>
	</div>
</div>
</div>

<div class="modal fade" id="mdDelRegistroAI" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header" style="background-color:#E33439;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Confirmar Operaci&oacute;n</h4>
		</div>
		<div class="modal-body">
            <div class="row">
	            <div class="col-md-12" id="DatoAI">
	                
	            </div>
            </div>
	            
		</div>		
		<div class="modal-footer">
		  <center>
		      <div class="btn-group">			      
		            <button type="button" class="btn btn-primary" id="btnDelRegAI" ><i class="ion-android-done"></i>&nbsp;SI</button>	
		            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="ion-android-cancel"></i>&nbsp;NO</button>		
		       </div>
		  </center>
		</div>
	</div>
</div>
</div>

</form>

</body>
</html>

