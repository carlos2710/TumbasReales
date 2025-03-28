<%@ Page Language="VB" AutoEventWireup="false" CodeFile="information.aspx.vb" Inherits="information" %>

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

    var aData=[];

    jQuery(document).ready(function () {
        fnResetDataTableTramite('tbCatalogo', 0, 'desc');
        fnLstCombos("PER", "cboPeriodo");
        fnLstCombos("CRO", "cboCronologia");
        fnLstCombos("GEO", "cboGeografica");
        fnLstCombos("CLA", "cboClasificacion");
        fnLstCombos("CUS", "cbocustodio");
        fnLstCombos("ADQ", "cboAquisicion");
        fnLstCombos("DOC", "cboDocumentos");

        listarCatalogosDGC($("#paramdgc").val());
        tablaCalalogosDGC();

        $('#btnAgregarCatalogo').click(function () {
            limpia();
            $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            $('div#mdConfirmarCatalogo').modal('show');
        });

        $("#btnGuardarCat1").click(fnGuardarParte1);
        $("#btnGuardarCat2").click(fnGuardarParte2);
        $("#btnGuardarCat3").click(fnGuardarParte3);
        $("#btnGuardarCat4").click(fnGuardarParte4);
        $("#btnGuardarCat5").click(fnGuardarParte5);
        $("#btnGuardarCat6").click(fnGuardarParte6);
        $("#btnGuardarCat7").click(fnGuardarParte7);

        $("#btnDelReg").click(fnDelRegistro);

        permisos();

    });

    function permisos() {
        if ($("#tfu").val() == "3" || $("#tfu").val() == "5") {
            $("#btnAgregarCatalogo").hide();
            $("#btnGuardarCat1").hide();
            $("#btnGuardarCat2").hide();
            $("#btnGuardarCat3").hide();
            $("#btnGuardarCat4").hide();
            $("#btnGuardarCat5").hide();
            $("#btnGuardarCat6").hide();
            $("#btnGuardarCat7").hide();
            $("#btnDelReg").hide();
        } else {
            $("#btnAgregarCatalogo").show();
            $("#btnGuardarCat1").show();
            $("#btnGuardarCat2").show();
            $("#btnGuardarCat3").show();
            $("#btnGuardarCat4").show();
            $("#btnGuardarCat5").show();
            $("#btnGuardarCat6").show();
            $("#btnGuardarCat7").show();
            $("#btnDelReg").show();
        }
    }

    function fnLstCatalogos() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstCatalogos" },
            dataType: "json",
            async: false,
            success: function (data) {
                aData = data;
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function limpia() {
        $('#cat').val("");
        $('#txtNroFicha').val("");
        $('#txtCodRegNac').val("");
        $('#txtCodPropietario').val("");
        $('#txtCodigoExcavacion').val("");
        $('#txtRegINC').val("");
        $('#txtInvINVC').val("");
        $('#txtOtrosCod').val("");


        $('#cat').val("");
        $('#txtCodRegNac').val("");
        $('#txtCodPropietario').val("");
        $('#txtCodigoExcavacion').val("");
        $('#txtRegINC').val("");
        $('#txtInvINVC').val("");
        $('#txtOtrosCod').val("");

        $('#txtCultura').val("");
        $('#txtEstilo').val("");
        $('#cboPeriodo').val("0");
        $('#cboCronologia').val("0");
        $('#cboGeografica').val("0");
        $('#cboClasificacion').val("0");
        $('#txtNombreClasif').val("");
        $('#txtRegion').val("");
        $('#txtValle').val("");
        $('#cboMargen').val("0");
        $('#cboExcavacion').val("0");
        $('#txtSector').val("");
        $('#txtUnidad').val("");
        $('#txtCapa').val("");
        $('#txtNivel').val("");
        $('#txtCuadricula').val("");
        $('#txtPlano').val("");
        $('#txtContexto').val("");
        $('#txtUbicContexto').val("");
        $('#txtAlturaAbsoluta').val("");
        $('#txtOtrosDatos').val("");

        $('#txtMaterial').val("");
        $('#txtTipo').val("");
        $('#txtDenominacion').val("");
        $('#txtManufactura').val("");
        $('#txtDecoracion').val("");
        $('#txtDescripcion').val("");
        $('#txtColores').val("");
        $('#txtAcabado').val("");
        $('#txtRepresentaciones').val("");
        $('#txtDecorativo').val("");
        $('#txtAlto').val("");
        $('#txtLargo').val("");
        $('#txtAncho').val("");
        $('#txtEspesor').val("");
        $('#txtDiamMax').val("");
        $('#txtDiamMin').val("");
        $('#txtDiamBase').val("");
        $('#txtPeso').val("");

        $('#cboTipoProp').val("0");
        $('#txtNombreProp').val("");
        $('#cbocustodio').val("0");
        $('#txtNombreCustodio').val("");
        $('#cboAquisicion').val("0");
        $('#txtRefFormaAdq').val("");
        $('#txtDireccionI').val("");

        $('#txtNombreInmueble').val("");
        $('#txtUbicacionInmueble').val("");
        $('#cboSituacion').val("0");
        $('#txtPisoVitrina').val("");
        $('#txtalmacenAnaquel').val("");
        $('#txtCajaContenedor').val("");
        $('#txtBolsa').val("");
        $('#file_frontal').val("");
        $("#divFrontal").html("");
        $('#file_lateral').val("");
        $("#divLateral").html("");
        $('#file_otras').val("");
        $("#divOtras").html("");
        $('#file_Detalle').val("");
        $("#divDetalle").html("");
        $('#file_dibujo').val("");
        $("#divDibujo").html("");

        $('#txtFichaCampo').val("");
        $('#txtFechaFichaC').val("");
        $('#txtFotoTomada').val("");
        $('#txtFechaTomaFoto').val("");
        $('#cboDocumentos').val("0");
        $('#txtNroDoc').val("");
        $('#txtFechaDoc').val("");
        $('#txtOtrasReferencias').val("");

    }

    function fnBorrarG(c,d) {
        $("#param1").val(c);
        $("#Dato").html("<label class='col-md-12 control-label'> Desea Confirmar la Eliminaci&oacute;n del Registro: " + d + "</label>");
        $('div#mdDelRegistro').modal('show');
        return true;
    }

    function fnBuscar(c) {
        var i;
        var j = -1;
        var l;
        l = aData.length;
        for (i = 0; i < l; i++) {
            if (aData[i].codigo == c) {
                j = i;
                return j;
            }
        }
    }

    function fnEditar(c) {
        var x = fnBuscar(c);
        if (x >= 0) {
            $('#cat').val(aData[x].codigo);
            $('#txtNroFicha').val(aData[x].nroficha);
            $('#txtCodRegNac').val(aData[x].codregnac_cat);
            $('#txtCodPropietario').val(aData[x].propietario);
            $('#txtCodigoExcavacion').val(aData[x].codexcavacion_cat);
            $('#txtRegINC').val(aData[x].codreginc_cat);
            $('#txtInvINVC').val(aData[x].codinvinc_cat);
            $('#txtOtrosCod').val(aData[x].otrocodigos_cat);

            $('#txtCultura').val(aData[x].cultura_cat);
            $('#txtEstilo').val(aData[x].estilo_cat);

            if (aData[x].periodo_cat == "") {
                $('#cboPeriodo').val(0);
            }
            else {
                $('#cboPeriodo').val(aData[x].periodo_cat);
            }
            if (aData[x].cronologia_cat == "") {
                $('#cboCronologia').val(0);
            }
            else {
                $('#cboCronologia').val(aData[x].cronologia_cat);
            }
            if (aData[x].areageografica_cat == "") {
                $('#cboGeografica').val(0);
            }
            else {
                $('#cboGeografica').val(aData[x].areageografica_cat);
            }
            if (aData[x].origenclasif_cat == "") {
                $('#cboClasificacion').val(0);
            }
            else {
                $('#cboClasificacion').val(aData[x].origenclasif_cat);
            }
            $('#txtNombreClasif').val(aData[x].nombreclasif_cat);
            $('#txtRegion').val(aData[x].region_cat);
            $('#txtValle').val(aData[x].valle_cat);
            if (aData[x].margen_cat == "") {
                $('#cboMargen').val(0);
            }
            else {
                $('#cboMargen').val(aData[x].margen_cat);
            }
            if (aData[x].provieneexcav_cat == "") {
                $('#cboExcavacion').val(0);
            }
            else {
                $('#cboExcavacion').val(aData[x].provieneexcav_cat);
            }
            $('#txtSector').val(aData[x].sector_cat);
            $('#txtUnidad').val(aData[x].unidad_cat);
            $('#txtCapa').val(aData[x].capa_cat);
            $('#txtNivel').val(aData[x].nivel_cat);
            $('#txtCuadricula').val(aData[x].cuadricula_cat);
            $('#txtPlano').val(aData[x].plano_cat);
            $('#txtContexto').val(aData[x].contexto_cat);
            $('#txtUbicContexto').val(aData[x].ubicacioncontexto_cat);
            $('#txtAlturaAbsoluta').val(aData[x].alturaabs_cat);
            $('#txtOtrosDatos').val(aData[x].otrosdatos_cat);

            $('#txtMaterial').val(aData[x].material_cat);
            $('#txtTipo').val(aData[x].tipo_cat);
            $('#txtDenominacion').val(aData[x].denominacion_cat);
            $('#txtManufactura').val(aData[x].manufactura_cat);
            $('#txtDecoracion').val(aData[x].decoracion_cat);
            $('#txtDescripcion').val(aData[x].descripcion_cat);
            $('#txtColores').val(aData[x].colores_cat);
            $('#txtAcabado').val(aData[x].acabadosuperf_cat);
            $('#txtRepresentaciones').val(aData[x].representaciones_cat);
            $('#txtDecorativo').val(aData[x].motivodecorativo_cat);
            $('#txtAlto').val(aData[x].alto_cat);
            $('#txtLargo').val(aData[x].largo_cat);
            $('#txtAncho').val(aData[x].ancho_cat);
            $('#txtEspesor').val(aData[x].espesor_cat);
            $('#txtDiamMax').val(aData[x].diametromax_cat);
            $('#txtDiamMin').val(aData[x].diametromin_cat);
            $('#txtDiamBase').val(aData[x].diametrobase_cat);
            $('#txtPeso').val(aData[x].peso_cat);

            if (aData[x].tipopropietario_cat == "") {
                $('#cboTipoProp').val(0);
            }
            else {
                $('#cboTipoProp').val(aData[x].tipopropietario_cat);
            }
            $('#txtNombreProp').val(aData[x].propietario_cat);
            if (aData[x].tipocustodio_cat == "") {
                $('#cbocustodio').val(0);
            }
            else {
                $('#cbocustodio').val(aData[x].tipocustodio_cat);
            }
            $('#txtNombreCustodio').val(aData[x].nombrecustodio_cat);
            if (aData[x].adquisicion_cat == "") {
                $('#cboAquisicion').val(0);
            }
            else {
                $('#cboAquisicion').val(aData[x].adquisicion_cat);
            }
            $('#txtRefFormaAdq').val(aData[x].referenciaadq_cat);
            $('#txtDireccionI').val(aData[x].direccioninmueble_cat);

            $('#txtNombreInmueble').val(aData[x].nombreinmueble_cat);
            $('#txtUbicacionInmueble').val(aData[x].ubicacionespecif_cat);
            if (aData[x].situacion_cat == "") {
                $('#cboSituacion').val(0);
            }
            else {
                $('#cboSituacion').val(aData[x].situacion_cat);
            }
            $('#txtPisoVitrina').val(aData[x].pisovitrina_cat);
            $('#txtalmacenAnaquel').val(aData[x].almacenanaquel_cat);
            $('#txtCajaContenedor').val(aData[x].cajacontenedor_cat);
            $('#txtBolsa').val(aData[x].bolsa_cat);

            if (aData[x].frontal != "") {
                $("#divFrontal").html("<a onclick='fnDownload(\"" + aData[x].frontal + "\")' target='_blank' style='font-weight:bold;color:blue'>Descargar</a>")
            } else {
                $("#divFrontal").html("");
            }
            if (aData[x].lateral != "") {
                $("#divLateral").html("<a onclick='fnDownload(\"" + aData[x].lateral + "\")' target='_blank' style='font-weight:bold;color:blue'>Descargar</a>")
            } else {
                $("#divLateral").html("");
            }
            if (aData[x].otras != "") {
                $("#divOtras").html("<a onclick='fnDownload(\"" + aData[x].otras + "\")' target='_blank' style='font-weight:bold;color:blue'>Descargar</a>")
            } else {
                $("#divOtras").html("");
            }
            if (aData[x].detalle != "") {
                $("#divDetalle").html("<a onclick='fnDownload(\"" + aData[x].detalle + "\")' target='_blank' style='font-weight:bold;color:blue'>Descargar</a>")
            } else {
                $("#divDetalle").html("");
            }
            if (aData[x].dibujo != "") {
                $("#divDibujo").html("<a onclick='fnDownload(\"" + aData[x].dibujo + "\")' target='_blank' style='font-weight:bold;color:blue'>Descargar</a>")
            } else {
                $("#divDibujo").html("");
            }

            $('#txtFichaCampo').val(aData[x].fichacampoelab_cat);
            $('#txtFechaFichaC').val(aData[x].fechafichacampo_cat.slice(0, 10));
            $('#txtFotoTomada').val(aData[x].fototomada_cat);
            $('#txtFechaTomaFoto').val(aData[x].fechafoto.slice(0, 10));
            if (aData[x].tipodoc_cat == "") {
                $('#cboDocumentos').val(0);
            }
            else {
                $('#cboDocumentos').val(aData[x].tipodoc_cat);
            }
            $('#txtNroDoc').val(aData[x].nrodocumento_cat);
            $('#txtFechaDoc').val(aData[x].fechadocumento_cat.slice(0, 10));
            $('#txtOtrasReferencias').val(aData[x].otrasreferencias_cat);
        }
        $('div#mdConfirmarCatalogo').modal('show');
        return true;
    }

    function fnDownload(id_ar) {
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

    function fnDelRegistro() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("DelCatalogo");
        var form = $('#frmCatalogo').serialize();
        $.ajax({
            type: "POST",
            url: "processmuseo.aspx",
            data: form,
            dataType: "json",
            //cache: false,
            //async: false,
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarCatalogosDGC($("#paramdgc").val());
                tablaCalalogosDGC();
                $('.piluku-preloader').addClass('hidden');
            },
            error: function (result) {
                $('.piluku-preloader').addClass('hidden');
                f_Menu("information.aspx");
            }
        });
        //document.getElementById("param0").value = "";
        $("#param0").val("");
        $('div#mdDelRegistro').modal('hide');
    }

    function fnLstCombos(param1, combo) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lst", "param1":param1 },
            dataType: "json",
            async: false,
            success: function (data) {
                var i = 0;
                var t;
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        t += '<option value="' + data[i].valor + '"' + data[i].selected + '>' + data[i].descripcion + '</option>';
                    }
                }
                $('#' + combo).html(t);
            },
            error: function (result) {
                console.log('error');
            }
        });
        $("#param0").val("");
    }

    function fnGuardarParte1() {
        var sw = 0;
        var mensaje = "";
        if ($("#txtRegINC").val() == "") {
            mensaje = "Codigo de Registro INC"
            sw = 1;
        } else {
            if ($("#txtRegINC").val() > 6000) {
                mensaje = "Codigo Reg Anterior INC debe ser menor a 6000";
                $("#txtRegINC").select();
                sw = 1;
            }
        }
        
        if ($("#txtNroFicha").val() == "") {
            mensaje = "Ingrese Nro Ficha"
            sw = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gCatalogo1");
            //var form = $('#frmCatalogo').serialize();
            $.ajax({
                //type: "POST",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "gCatalogo1", "txtNroFicha": $("#txtNroFicha").val(), "txtCodRegNac": $("#txtCodRegNac").val(), "txtCodPropietario": $("#txtCodPropietario").val(), "txtCodigoExcavacion": $("#txtCodigoExcavacion").val(), "txtRegINC": $("#txtRegINC").val(), "txtInvINVC": $("#txtInvINVC").val(), "txtOtrosCod": $("#txtOtrosCod").val(), "paramdgc": $("#paramdgc").val(), "cat": $("#cat").val() },
                //data: form,
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#cat').val(data[0].code);
                        listarCatalogosDGC($("#paramdgc").val());
                        tablaCalalogosDGC()
                        $('.piluku-preloader').addClass('hidden');
                    } else {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('.piluku-preloader').addClass('hidden');
                    }
                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    //console.log(result);
                    $('.piluku-preloader').addClass('hidden');
                }
            });
        }
        $("#param0").val("");
    }

    function listarCatalogosDGC(val) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstCatalogosDGC", "param1": val },
            dataType: "json",
            async: false,
            success: function (data) {
                aData = data;
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function tablaCalalogosDGC()
    {
        var tb = '';
        var i = 0;
        var mostrar = '';
        var contador = 0;
        var tipo_sexo = '';
        if (aData.length > 0) {
            for (i = 0; i < aData.length; i++) {
                contador = contador + 1;
                tb += '<tr>';
                tb += '<td>';
                tb += '<center><a href="#" class="btn btn-green btn-xs" onclick="fnEditar(\'' + aData[i].codigo + '\')" ><i class="ion-edit"></i></a>';
                tb += '<a href="#" class="btn btn-red btn-xs" onclick="fnBorrarG(\'' + aData[i].codigo + '\',\'' + aData[i].propietario + '\')" ><i class="ion-android-cancel"></i></a></td>';
                tb += '</center></td>';
                //tb += '<td style="text-align:center">' + "<a href=" + item.id + ">" + item.id + "</a>" + '<a href="RepCatalogoPDF.aspx?CAT=' + aData[i].propietario  + '" target="popup" onClick="window.open(this.href, this.target); return false;">' + aData[i].propietario + '</a></td>';

                tb += '<td style="text-align:center">' + '<a href=RepCatalogoPDF.aspx?CAT=' + aData[i].codigo + ' target="popup" onClick="window.open(this.href, this.target,"width=1000,height=700"); return false;" style="color:blue">' + aData[i].propietario + "</a>" + '</td>';
                //tb += '<td style="text-align:center">' + aData[i].propietario + '</td>';
                tb += '<td style="text-align:center">' + aData[i].denominacion_cat + '</td>';
                tb += '<td style="text-align:center">' + aData[i].codexcavacion_cat + '</td>';
                tb += '<td style="text-align:center">' + aData[i].material_cat + '</td>';
                if (aData[i].frontal == "") {
                    tb += '<td style="text-align:center"> <img id="' + (i + 1) + '" name="' + (i + 1) + '" style="width:50px;height:50px;" src="assets/images/no-image.png" /> </td>';
                } else {
                    tb += '<td style="text-align:center"> <img id="' + (i + 1) + '" name="' + (i + 1) + '" style="width:50px;height:50px;" src="" /> </td>';
                    fnMostrarImagen(aData[i].frontal, i + 1);
                }
                tb += '</tr>';
            }
        } else {
            tb = "";
        }
        fnDestroyDataTableDetalle('tbCatalogo');
        $('#pCatalogo').html(tb);
        fnResetDataTableTramite('tbCatalogo', 0, 'asc');
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

    function fnGuardarParte2() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());

        //if ($("#txtPlano").val() > 6000) {
        //    mensaje = "Plano debe ser menor a 6000";
        //    $("#txtPlano").select();
        //    sw = 1;
        //}
        if ($("#txtCuadricula").val() > 999999) {
            mensaje = "Cuadricula debe ser menor a 999999";
            $("#txtCuadricula").select();
            sw = 1;
        }
        //if ($("#txtNivel").val() > 6000) {
        //    mensaje = "Nivel debe ser menor a 6000";
        //    $("#txtNivel").select();
        //    sw = 1;
        //}
        if ($("#cboExcavacion").val() == "0") {
            mensaje = "Seleccione Excavación"
            sw = 1;
        }
        if ($("#cboMargen").val() == "0") {
            mensaje = "Seleccione Margen"
            sw = 1;
        }
        if ($("#txtValle").val() == "") {
            mensaje = "Ingrese Valle"
            sw = 1;
        }
        if ($("#txtRegion").val() == "") {
            mensaje = "Seleccione Región"
            sw = 1;
        }
        if ($("#txtNombreClasif").val() == "") {
            mensaje = "Ingrese Nombre Clasificación"
            sw = 1;
        }
        if ($("#cboGeografica").val() == "0") {
            mensaje = "Seleccione Área Geográfica"
            sw = 1;
        }
        if ($("#cboCronologia").val() == "0") {
            mensaje = "Seleccione Cronologia"
            sw = 1;
        }
        if ($("#cboPeriodo").val() == "0") {
            mensaje = "Seleccione Periodo"
            sw = 1;
        }
        if ($("#txtEstilo").val() == "") {
            mensaje = "Ingrese Estilo"
            sw = 1;
        }
        if ($("#txtCultura").val() == "") {
            mensaje = "Ingrese Culturas"
            sw = 1;
        }
        if ($("#cat").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje );
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabOrigen"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gCatalogo2");
            //var form = $('#frmCatalogo').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: {"param0": "gCatalogo2", "cat": $("#cat").val(), "txtCultura": $("#txtCultura").val(), "txtEstilo": $("#txtEstilo").val(), "cboPeriodo": $("#cboPeriodo").val(), "cboCronologia": $("#cboCronologia").val(), "cboGeografica": $("#cboGeografica").val(), "cboClasificacion": $("#cboClasificacion").val(), "txtNombreClasif": $("#txtNombreClasif").val(), "txtRegion": $("#txtRegion").val(), "txtValle": $("#txtValle").val(), "cboMargen": $("#cboMargen").val(), "cboExcavacion": $("#cboExcavacion").val(), "txtSector": $("#txtSector").val(), "txtUnidad": $("#txtUnidad").val(), "txtCapa": $("#txtCapa").val(), "txtNivel": $("#txtNivel").val(), "txtCuadricula": $("#txtCuadricula").val(), "txtPlano": $("#txtPlano").val(), "txtContexto": $("#txtContexto").val(), "txtUbicContexto": $("#txtUbicContexto").val(), "txtAlturaAbsoluta": $("#txtAlturaAbsoluta").val(), "txtOtrosDatos": $("#txtOtrosDatos").val(), "paramdgc": $("#paramdgc").val()},
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#cat').val(data[0].code);
                        listarCatalogosDGC($("#paramdgc").val());
                        tablaCalalogosDGC()
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

    function fnGuardarParte3() {
        var sw = 0;
        var swTab = 0;
        var mensaje = "";
        if ($("#txtPeso").val() == "") {
            mensaje = "Ingrese Peso"
            sw = 1;
        }
        if ($("#txtDiamBase").val() == "") {
            mensaje = "Ingrese Diametro Base"
            sw = 1;
        }
        if ($("#txtDiamMin").val() == "") {
            mensaje = "Diametro Minimo"
            sw = 1;
        }
        if ($("#txtDiamMax").val() == "") {
            mensaje = "Diametro Maximo"
            sw = 1;
        }
        if ($("#txtEspesor").val() == "") {
            mensaje = "Ingreso Espesor"
            sw = 1;
        }
        if ($("#txtAncho").val() == "") {
            mensaje = "Ingrese Ancho"
            sw = 1;
        }
        if ($("#txtLargo").val() == "") {
            mensaje = "Ingrese Largo"
            sw = 1;
        }
        if ($("#txtAlto").val() == "") {
            mensaje = "Ingrese Alto"
            sw = 1;
        }      
        if ($("#txtDecorativo").val() == "") {
            mensaje = "Ingrese Motivo Decorativo"
            sw = 1;
        }
        if ($("#txtRepresentaciones").val() == "") {
            mensaje = "Ingrese Representaciones"
            sw = 1;
        }
        if ($("#txtAcabado").val() == "") {
            mensaje = "Ingrese Acabado"
            sw = 1;
        }
        if ($("#txtDescripcion").val() == "") {
            mensaje = "Ingrese Descripción"
            sw = 1;
        }        
        if ($("#txtManufactura").val() == "") {
            mensaje = "Ingrese Manufactura"
            sw = 1;
        }
        if ($("#txtDenominacion").val() == "") {
            mensaje = "Ingrese Denominación"
            sw = 1;
        }
        if ($("#txtTipo").val() == "") {
            mensaje = "Ingrese Tipo"
            sw = 1;
        }
        if ($("#txtMaterial").val() == "") {
            mensaje = "Ingrese Material"
            sw = 1;
        }
        if ($("#cat").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 1) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gCatalogo3");
            var form = $('#frmCatalogo').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "gCatalogo3", "cat": $("#cat").val(), "txtMaterial": $("#txtMaterial").val(), "txtTipo": $("#txtTipo").val(), "txtDenominacion": $("#txtDenominacion").val(), "txtManufactura": $("#txtManufactura").val(), "txtDecoracion": $("#txtDecoracion").val(), "txtDescripcion": $("#txtDescripcion").val(), "txtColores": $("#txtColores").val(), "txtAcabado": $("#txtAcabado").val(), "txtRepresentaciones": $("#txtRepresentaciones").val(), "txtDecorativo": $("#txtDecorativo").val(), "txtAlto": $("#txtAlto").val(), "txtLargo": $("#txtLargo").val(), "txtAncho": $("#txtAncho").val(), "txtEspesor": $("#txtEspesor").val(), "txtDiamMax": $("#txtDiamMax").val(), "txtDiamMin": $("#txtDiamMin").val(), "txtDiamBase": $("#txtDiamBase").val(), "txtPeso": $("#txtPeso").val(), "paramdgc": $("#paramdgc").val()},
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#cat').val(data[0].code);
                        listarCatalogosDGC($("#paramdgc").val());
                        tablaCalalogosDGC()
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

    function fnGuardarParte4() {
        var sw = 0;
        var swTab = 0;
        var mensaje = "";
        if ($("#txtDireccionI").val() == "") {
            mensaje = "Ingrese Direccion Inmueble"
            sw = 1;
        }
        if ($("#txtRefFormaAdq").val() == "") {
            mensaje = "Ingrese Referencia Adquisición"
            sw = 1;
        }
        if ($("#cboAquisicion").val() == "0") {
            mensaje = "Seleccione forma de Adquisición"
            sw = 1;
        }
        if ($("#txtNombreCustodio").val() == "") {
            mensaje = "Ingrese Nombre de Custodio"
            sw = 1;
        }
        if ($("#cbocustodio").val() == "0") {
            mensaje = "Selecciones Tipo de custodio"
            sw = 1;
        }
        if ($("#txtNombreProp").val() == "") {
            mensaje = "Ingrese nombre de Propietario"
            sw = 1;
        }
        if ($("#cboTipoProp").val() == "0") {
            mensaje = "Seleccione tipo de propietario"
            sw = 1;
        }
        if ($("#cat").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 1) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gCatalogo4");
            //var form = $('#frmCatalogo').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "gCatalogo4", "cat": $("#cat").val(), "cboTipoProp": $("#cboTipoProp").val(), "txtNombreProp": $("#txtNombreProp").val(), "cbocustodio": $("#cbocustodio").val(), "txtNombreCustodio": $("#txtNombreCustodio").val(), "cboAquisicion": $("#cboAquisicion").val(), "txtRefFormaAdq": $("#txtRefFormaAdq").val(), "txtDireccionI": $("#txtDireccionI").val(), "paramdgc": $("#paramdgc").val()},
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#cat').val(data[0].code);
                        listarCatalogosDGC($("#paramdgc").val());
                        tablaCalalogosDGC()
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

    function fnGuardarParte5() {
        var sw = 0;
        var swTab = 0;
        var mensaje = "";
        if ($("#txtBolsa").val() == "") {
            mensaje = "Ingrese bolsa"
            sw = 1;
        }
        if ($("#txtCajaContenedor").val() == "") {
            mensaje = "Ingrese nro caja contenedor"
            sw = 1;
        }
        if ($("#txtalmacenAnaquel").val() == "") {
            mensaje = "Ingrese almacén/anaquel"
            sw = 1;
        }
        if ($("#txtPisoVitrina").val() == "") {
            mensaje = "Ingrese piso y vitrina"
            sw = 1;
        }
        if ($("#cboSituacion").val() == "0") {
            mensaje = "Seleccione de situación"
            sw = 1;
        }
        if ($("#txtUbicacionInmueble").val() == "") {
            mensaje = "Ingrese ubicación de inmueble"
            sw = 1;
        }
        if ($("#txtNombreInmueble").val() == "") {
            mensaje = "Ingrese nombre de inmueble"
            sw = 1;
        }
        if ($("#cat").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 1) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gCatalogo5");
            var form = $('#frmCatalogo').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "gCatalogo5", "cat": $("#cat").val(), "txtNombreInmueble": $("#txtNombreInmueble").val(), "txtUbicacionInmueble": $("#txtUbicacionInmueble").val(), "cboSituacion": $("#cboSituacion").val(), "txtPisoVitrina": $("#txtPisoVitrina").val(), "txtalmacenAnaquel": $("#txtalmacenAnaquel").val(), "txtCajaContenedor": $("#txtCajaContenedor").val(), "txtBolsa": $("#txtBolsa").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#cat').val(data[0].code);
                        listarCatalogosDGC($("#paramdgc").val());
                        tablaCalalogosDGC()
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

    function fnGuardarParte6() {
        var sw = 0;
        var swTab = 0;
        var mensaje = "";
        var swvalida = 0;
        if ($("#file_dibujo").val() == "") {
            mensaje = "Seleccione imagen de dibujo"
            sw = 1;
        }
        if ($("#file_Detalle").val() == "") {
            mensaje = "Seleccione imagen de detalle"
            sw = 1;
        }
        if ($("#file_otras").val() == "") {
            mensaje = "Seleccione otra imagen"
            sw = 1;
        }
        if ($("#file_lateral").val() == "") {
            mensaje = "Seleccione imagen de lateral"
            sw = 1;
        }
        if ($("#file_frontal").val() == "") {
            mensaje = "Seleccione imagen frontal"
            sw = 1;
        }
        if ($("#cat").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab = 1) {
                $('.nav-tabs a[href="#tabImagenes"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gCatalogo6");
            var form = $('#frmCatalogo').serialize();
            $.ajax({
                type: "POST",
                //contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    //fnMensaje(data[0].alert, data[0].msje);
                    if ($("#file_frontal").val() != "") {
                        SubirArchivo($("#cat").val(), "FRONTAL");
                        swvalida = 1;
                    }
                    if ($("#file_lateral").val() != "") {
                        SubirArchivo($("#cat").val(), "LATERAL");
                        swvalida = 1;
                    }
                    if ($("#file_otras").val() != "") {
                        SubirArchivo($("#cat").val(), "OTRAS");
                        swvalida = 1;
                    }
                    if ($("#file_Detalle").val() != "") {
                        SubirArchivo($("#cat").val(), "DETALLE");
                        swvalida = 1;
                    }
                    if ($("#file_dibujo").val() != "") {
                        SubirArchivo($("#cat").val(), "DIBUJO");
                        swvalida = 1;
                    }
                    if (swvalida == 0) {
                        fnMensaje("error", "No se ha elegido ninguna imagen para subir");
                    } else {
                        listarCatalogosDGC($("#paramdgc").val());
                        tablaCalalogosDGC()
                        fnMensaje("success", "Archivo(s) subido(s) con éxito");
                    }                    
                    $('.piluku-preloader').addClass('hidden');
                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    console.log(result);
                }
            });
        }
        $("#param0").val("");
    }

    function SubirArchivo(cod, tipo) {

        var flag = false;
        try {
            var data = new FormData();
            data.append("param0", "SurbirArchivoNew");
            data.append("codigo", cod);
            data.append("tipo", tipo);

            if (tipo == "FRONTAL") {
                var files = $("#file_frontal").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "LATERAL") {
                var files = $("#file_lateral").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "OTRAS") {
                var files = $("#file_otras").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "DETALLE") {
                var files = $("#file_Detalle").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "DIBUJO") {
                var files = $("#file_dibujo").get(0).files;
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

    function fnGuardarParte7() {
        var sw = 0;
        var swTab = 0;
        var mensaje = "";
        if ($("#txtOtrasReferencias").val() == "") {
            mensaje = "Ingrese otras referencias"
            sw = 1;
        }
        if ($("#txtFechaReg").val() == "") {
            mensaje = "Ingrese otras referencias"
            sw = 1;
        }
        if ($("#txtUsuReg").val() == "") {
            mensaje = "Ingrese otras referencias"
            sw = 1;
        }
        if ($("#txtFechaDoc").val() == "") {
            mensaje = "Seleccione fecha de documento"
            sw = 1;
        }
        if ($("#txtNroDoc").val() == "") {
            mensaje = "Ingrese número de documento"
            sw = 1;
        }
        if ($("#cboDocumentos").val() == "0") {
            mensaje = "Seleccione tipo de documento"
            sw = 1;
        }
        if ($("#txtFechaTomaFoto").val() == "") {
            mensaje = "Seleccione fecha de toma de fotografía"
            sw = 1;
        }
        if ($("#txtFotoTomada").val() == "") {
            mensaje = "Ingrese foto tomada por"
            sw = 1;
        }
        if ($("#txtFechaFichaC").val() == "") {
            mensaje = "Seleccione fecha de ficha campo"
            sw = 1;
        }
        if ($("#txtFichaCampo").val() == "") {
            mensaje = "Ingrese ficha de campo elaborada"
            sw = 1;
        }
        if ($("#cat").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 1) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gCatalogo7");
            var form = $('#frmCatalogo').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "gCatalogo7", "cat": $("#cat").val(), "txtFichaCampo": $("#txtFichaCampo").val(), "txtFechaFichaC": $("#txtFechaFichaC").val(), "txtFotoTomada": $("#txtFotoTomada").val(), "txtFechaTomaFoto": $("#txtFechaTomaFoto").val(), "cboDocumentos": $("#cboDocumentos").val(), "txtNroDoc": $("#txtNroDoc").val(), "txtFechaDoc": $("#txtFechaDoc").val(), "txtOtrasReferencias": $("#txtOtrasReferencias").val(), "paramdgc": $("#paramdgc").val(), "txtUsuReg": $("#txtUsuReg").val(), "txtFechaReg": $("#txtFechaReg").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#cat').val(data[0].code);
                        listarCatalogosDGC($("#paramdgc").val());
                        tablaCalalogosDGC()
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

    <form id="frmCatalogo" name="frmCatalogo" runat="server">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="paramdgc" name="paramdgc" value="" runat="server" /> 
    <input type="hidden" id="cat" name="cat" value="" /> 
    <input type="hidden" id="tfu" name="tfu" value="" runat="server"/> 
        <div class="row">
    <div class="panel panel-piluku">

            <div class="panel-heading">
		        <h3 class="panel-title">
			        
                    <div class="col-md-6" align="left" >
                          <div id="titulo" runat="server"> </div>  
                    </div>
                    <div class="col-md-5" align="right">
                            <button type="button" class="btn btn-white " id="btnExportarRep" runat="server" ><i class="ion-android-download"></i>&nbsp;Exportar Reporte</button>	

                            <%--<a href="RepCatalogoPDF.aspx?CAT=MQA=" target="popup" onClick="window.open(this.href, this.target, 'width=1000,height=700'); return false;">Ver en PDF </a>--%>
                    </div>

                       
                </h3>
	        </div>	  
	        <div class='table-responsive'>	        
                <div class='panel-body' >
                    <div class='table-responsive'>
                        <table class='display dataTable cell-border' id='tbCatalogo' style="width:95%;font-size:smaller">
                            <thead>
                            <tr>
                                    <th style="width:6%;text-align:center;"></th>
                                    <th style="width:15%;text-align:center;">Código Propietario</th>
                                    <th style="width:20%;text-align:center;">Denominación</th>
                                    <th style="width:10%;text-align:center;">Código excavación</th>
                                    <th style="width:10%;text-align:center;">Materia Prima</th>
                                    <th style="width:15%;text-align:center;">Foto</th>
                                </tr>
                                </thead>     
                                <tbody id ="pCatalogo" runat ="server">
                                </tbody>                             
                                <tfoot>
                                <tr>
                                <th colspan="6"></th>
                                </tr>
                                </tfoot>
                        </table>
                    </div>              
                </div> 
                <center>                        
                    <a href="#" id="btnAgregarCatalogo" class="btn btn-primary btn-lg" style="width:30%" ><i class="ion-android-done"></i>&nbsp;Agregar Catálogo</a>                
                </center>
     
            </div> 
        </div>
    </div>


<div class="modal fade " id="mdConfirmarCatalogo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-jr">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Catálogo</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="Li1" runat="server" ><a href="#tabIdentificacion" aria-controls="home" role="tab" data-toggle="tab" > Identificaci&oacute;n</a></li>
					    <li role="presentationlogin" id="Li2" runat="server" ><a href="#tabOrigen" aria-controls="profile" role="tab" data-toggle="tab" > Datos Origen</a></li>
                        <li role="presentationlogin" id="Li3" runat="server" ><a href="#tabFisicaDimensaiones" aria-controls="profile" role="tab" data-toggle="tab" > Descripci&oacute;n F&iacute;sica</a></li>
                        <li role="presentationlogin" id="Li4" runat="server" ><a href="#tabPropiedades" aria-controls="profile" role="tab" data-toggle="tab" > Datos Propiertario</a></li>
                        <li role="presentationlogin" id="Li5" runat="server" ><a href="#tabUbicacionActual" aria-controls="profile" role="tab" data-toggle="tab" > Datos Ubicaci&oacute;n</a></li>
                        <li role="presentationlogin" id="Li6" runat="server" ><a href="#tabImagenes" aria-controls="profile" role="tab" data-toggle="tab" > Im&aacute;genes</a></li>
                        <li role="presentationlogin" id="Li7" runat="server" ><a href="#tabDatosReg" aria-controls="profile" role="tab" data-toggle="tab" > Datos Registro</a></li>
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">
	
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacion" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroFicha">
                                            N° Ficha:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNroFicha" name="txtNroFicha" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodRegNac">
                                            Cod. Reg. Nacional:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodRegNac" name="txtCodRegNac" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodPropietario" >
                                            Cod. Propietario:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodPropietario" name="txtCodPropietario" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodigoExcavacion">
                                            Cod. Excavaci&oacute;n:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodigoExcavacion" name="txtCodigoExcavacion" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtRegINC">
                                            Cod. Reg Anterio INC [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtRegINC" name="txtRegINC" class="form-control" onKeyPress="return soloNumeros(event,this)" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtInvINVC">
                                            Cod.Inventario INC:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtInvINVC" name="txtInvINVC" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrosCod">
                                            Otros Codigo:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtOtrosCod" name="txtOtrosCod" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarCat1" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
                        <div role="tabpanel" class="tab-pane " id="tabOrigen" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCultura">
                                            Culturas:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCultura" name="txtCultura" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtEstilo">
                                            Estilo:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtEstilo" name="txtEstilo" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cbPeriodo">
                                            Periodo:</label>
                                        <div class="col-sm-3">
                                            <select class="form-control" id="cboPeriodo" name="cboPeriodo"></select>                  
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cbCronologia">
                                            Cronolog&iacute;a:</label>
                                        <div class="col-sm-3">
                                               <select class="form-control" id="cboCronologia" name="cboCronologia"></select>                
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cbAreaGeo">
                                            &Aacute;rea Geogr&aacute;fica:</label>
                                        <div class="col-sm-3">
                                                <select class="form-control" id="cboGeografica" name="cboGeografica"></select>              
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboClasificacion">
                                            Clasif. Origen:</label>
                                        <div class="col-sm-3">
                                              <select class="form-control" id="cboClasificacion" name="cboClasificacion"></select>              
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNombreClasif">
                                            Nombre Clasif.:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNombreClasif" name="txtNombreClasif" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtRegion">
                                            Regi&oacute;n</label>
                                        <div class="col-sm-3">
                                              <%--<select class="form-control" id="cboRegion" name="cboRegion"></select>--%>    
                                             <input type="text" id="txtRegion" name="txtRegion" class="form-control" />         
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtValle">
                                            Valle:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtValle" name="txtValle" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtMargen">
                                            Margen:</label>
                                        <div class="col-sm-3">
                                               <select class="form-control" id="cboMargen" name="cboMargen">
                                                   <option value="0">-- Seleccione -- </option>
                                                   <option value="1">Izquierda</option>
                                                   <option value="2">Derecha</option>
                                               </select>              
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtProvExcav">
                                            Proviene de Excavación:</label>
                                        <div class="col-sm-3">
                                                <select class="form-control" id="cboExcavacion" name="cboExcavacion">
                                                   <option value="0">-- Seleccione -- </option>
                                                   <option value="1">Si</option>
                                                   <option value="2">No</option>
                                               </select>             
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSector">
                                            Sector:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtSector" name="txtSector" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUnidad">
                                            Unidad:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtUnidad" name="txtUnidad" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCapa">
                                            Capa:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCapa" name="txtCapa" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNivel">
                                            Nivel:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNivel" name="txtNivel" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCuadricula">
                                            Cuadr&iacute;cula [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCuadricula" name="txtCuadricula" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPlano">
                                            Plano:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtPlano" name="txtPlano" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtContexto">
                                            Contexto:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtContexto" name="txtContexto" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUbicContexto">
                                            Ubicación en contexto:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtUbicContexto" name="txtUbicContexto" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAlturaAbsoluta">
                                            Altura Absoluta:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAlturaAbsoluta" name="txtAlturaAbsoluta" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrosDatos">
                                            Otros Datos:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtOtrosDatos" name="txtOtrosDatos" class="form-control" />
                                        </div>
                                    </div>
                                </div>
               
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarCat2" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

                        </div>
                        <div role="tabpanel" class="tab-pane" id="tabFisicaDimensaiones" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtMaterial">
                                            Material:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtMaterial" name="txtMaterial" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTipo">
                                            Tipo:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtTipo" name="txtTipo" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDenominacion">
                                            Denomicación:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDenominacion" name="txtDenominacion" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtManufactura">
                                            Manufactura:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtManufactura" name="txtManufactura" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDecoracion">
                                            Decoración:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDecoracion" name="txtDecoracion" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDescripcion">
                                            Descripción:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDescripcion" name="txtDescripcion" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtColores">
                                            Colores:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtColores" name="txtColores" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAcabado">
                                            Acabado Superficial:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAcabado" name="txtAcabado" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtRepresentaciones">
                                            Representaciones:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtRepresentaciones" name="txtRepresentaciones" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDecorativo">
                                            Motivo Deco.:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDecorativo" name="txtDecorativo" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" >
                                            Alto [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtAlto" name="txtAlto" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" >
                                            Largo [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtLargo" name="txtLargo" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" >
                                            Ancho [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtAncho" name="txtAncho" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" >
                                            Espesor [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtEspesor" name="txtEspesor" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMax">
                                            Diámetro Máx. [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamMax" name="txtDiamMax" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMin">
                                            Diámetro Min. [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamMin" name="txtDiamMin" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamBase">
                                            Diámetro Base [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamBase" name="txtDiamBase" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPeso">
                                            Peso [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtPeso" name="txtPeso" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>

                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarCat3" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabPropiedades" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTipoProp">
                                            Tipo Propietario:</label>
                                        <div class="col-sm-2">
                                            <select class="form-control" id="cboTipoProp" name="cboTipoProp">
                                                   <option value="0">-- Seleccione -- </option>
                                                   <option value="1">Persona Natural</option>
                                                   <option value="2">Persona Jurídica</option>
                                               </select> 
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNombreProp">
                                            Nombre Propietario:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtNombreProp" name="txtNombreProp" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodPropietario">
                                            Cod. Propietario:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtCodPropietario" name="txtCodPropietario" class="form-control" />
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cbocustodio">
                                            Tipo Custodio:</label>
                                        <div class="col-sm-2">
                                            <select class="form-control" id="cbocustodio" name="cbocustodio"></select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNombreCustodio">
                                            nombre Custodio:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtNombreCustodio" name="txtNombreCustodio" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboAquisicion">
                                            Forma Adquisición:</label>
                                        <div class="col-sm-2">            
                                            <select class="form-control" id="cboAquisicion" name="cboAquisicion"></select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtRefFormaAdq">
                                            Referencia Forma Adq.:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtRefFormaAdq" name="txtRefFormaAdq" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDireccionI">
                                            Dirección Inmueble:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtDireccionI" name="txtDireccionI" class="form-control" />
                                        </div>
                                    </div>
                                </div>

                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarCat4" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabUbicacionActual" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNombreInmueble">
                                            Nombre Inmueble:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtNombreInmueble" name="txtNombreInmueble" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUbicacionInmueble">
                                            Ubic. en el Inmueble:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtUbicacionInmueble" name="txtUbicacionInmueble" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboSituacion">
                                            Situación:</label>
                                        <div class="col-sm-2">
                                            <select class="form-control" id="cboSituacion" name="cboSituacion">
                                                   <option value="0" selected>-- Seleccione -- </option>
                                                   <option value="1">Habido</option>
                                                   <option value="2">No Habido</option>
                                               </select> 
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPisoVitrina">
                                            Piso/Vitrina:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtPisoVitrina" name="txtPisoVitrina" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtalmacenAnaquel">
                                            Almacén/Anaquel:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtalmacenAnaquel" name="txtalmacenAnaquel" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCajaContenedor">
                                            N° Caja o Contenedor [1-9]:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtCajaContenedor" name="txtCajaContenedor" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtBolsa">
                                            N° Bolsa:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtBolsa" name="txtBolsa" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                               
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarCat5" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabImagenes" runat="server" >
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">
                                        Vista Frontal: </label>
                                    <div class="col-sm-4">
                                        <input type="file" id="file_frontal" name="file_frontal" />
                                        <div id="divFrontal">
                                        </div>
                                    </div>
                                </div>
                            </div>  
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">
                                        Vista Lateral: </label>
                                    <div class="col-sm-4">
                                        <input type="file" id="file_lateral" name="file_lateral" />
                                        <div id="divLateral">
                                        </div>
                                    </div>
                                </div>
                            </div>  
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">
                                        Otras vistas: </label>
                                    <div class="col-sm-4">
                                        <input type="file" id="file_otras" name="file_otras" />
                                        <div id="divOtras">
                                        </div>
                                    </div>
                                </div>
                            </div>  
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">
                                        Detalle: </label>
                                    <div class="col-sm-4">
                                        <input type="file" id="file_Detalle" name="file_Detalle" />
                                        <div id="divDetalle">
                                        </div>
                                    </div>
                                </div>
                            </div>  
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">
                                        Dibujo: </label>
                                    <div class="col-sm-4">
                                        <input type="file" id="file_dibujo" name="file_dibujo" />
                                        <div id="divDibujo">
                                        </div>
                                    </div>
                                </div>
                            </div>  
                            
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarCat6" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

                        </div>
                        <div role="tabpanel" class="tab-pane" id="tabDatosReg" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtFichaCampo">
                                            Ficha Campo Elab. por:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtFichaCampo" name="txtFichaCampo" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha Ficha Campo:</label>
                                    <div class="col-sm-2" id="Div17">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaFichaC" name="txtFechaFichaC" data-provide="datepicker"/>
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>	
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtFotoTomada">
                                            Foto Tomada por:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtFotoTomada" name="txtFotoTomada" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha Toma Fotografía:</label>
                                    <div class="col-sm-2" id="Div19">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaTomaFoto" name="txtFechaTomaFoto" data-provide="datepicker"/>
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboDocumentos">
                                            Tipo Documento:</label>
                                        <div class="col-sm-2">
                                            <select class="form-control" id="cboDocumentos" name="cboDocumentos"></select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroDoc">
                                            Nro Documento [1-9]:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtNroDoc" name="txtNroDoc" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha Documento:</label>
                                    <div class="col-sm-2" id="Div21">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaDoc" name="txtFechaDoc" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                    </div>
                                </div>
                               
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUsuReg">
                                            Registrador:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtUsuReg" name="txtUsuReg" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrasReferencias">
                                            Fecha de Registro:</label>
                                        <div class="col-sm-2">
                                            <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaReg" name="txtFechaReg" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrasReferencias">
                                            Otras Referencias:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtOtrasReferencias" name="txtOtrasReferencias" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarCat7" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
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

    
    

</form>

</body>
</html>
