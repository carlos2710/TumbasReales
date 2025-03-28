<%@ Page Language="VB" AutoEventWireup="false" CodeFile="informationInv.aspx.vb" Inherits="informationInv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//ES" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
    var Carga = [];
    document.querySelector('#fileArchivo').addEventListener('change', leerArchivo2, false);

    function leerArchivo2(evt) {
        let file = evt.target.files[0];
        let nombre = file.name.substr(-4);
        if (nombre != '.csv') {
            alert("Formato de archivo no es correcto, solo es permitido archivos .csv");
            document.getElementById("fileArchivo").value = "";
        } else {
            let reader = new FileReader();
            reader.onload = (e) => {
                let carg = e.target.result.split("\r\n");
                for (let i = 3; i < carg.length - 1; i++) {
                    console.log(carg);
                    Carga.push(carg[i]);
                }
            }
            //reader.readAsText(file, 'ISO-8859-4');    JAZ
            reader.readAsText(file, 'ISO-8859-1');
        }
        
    }
    
    jQuery(document).ready(function () {
        fnResetDataTableTramite('tbInventario', 0, 'desc');
        fnLstCombos("TIM", "cboTipoMat");

        listarInventariosDGC($("#paramdgc").val());
        tablaInventariosDGC();

        $('#btnAgregarInventario').click(function () {
            limpia();
            $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            $('div#mdConfirmarInventario').modal('show');
        });

        $('#btnCargaMasiva').click(function () {
            limpia();
            $('div#mdCargamasiva').modal('show');
        });

        $("#btnGuardarCat2").click(fnGuardarParte2);
        $("#btnSiguiente1").click(fnValidarIdentificacion);
        $("#btnSiguiente2").click(fnValidarTecnicos);
        $("#btnSiguiente3").click(fnValidarConservacion);
        $("#btnSiguiente4").click(fnValidarOrigen);
        $("#btnSiguiente5").click(fnValidarPropiedad);
        $("#btnSiguiente6").click(fnValidarUbicacion);
        $("#btnGuardar").click(fnValidarAdicional);
        $("#btnGuardarC").click(fnCargaMasiva);
        $("#btnDelReg").click(fnDelRegistro);
        $("#btnBuscar").click(fnBuscarCodigo);
        

    });
    function fnCargaMasiva() {
        for (let i = 0; i < Carga.length ; i++) {
            fnCargar(i);
        }
        $('#mdCargamasiva').modal('hide');
    }
    function fnCargar(i) {
        var Fila = Carga[i].split(";");
        $('#txtRegistroNac').val(Fila[1]);
        $('#txtCodPropietario').val(Fila[2]);
        $('#txtOtrosCod').val(Fila[3]);
        $('#txtCategoria').val(Fila[4]);
        $('#txtTaxonomia').val(Fila[5]);
        $('#txtDenominacion').val(Fila[6]);
        $('#txtCultura').val(Fila[7]);
        $('#txtPeriodo').val(Fila[8]);
        $('#txtDescripcion').val(Fila[9]);
        $('#txtTipoMat').val(Fila[10]);
        $('#txtTecnicas').val(Fila[11]);
        $('#txtAlto').val(Fila[12]);
        $('#txtLargo').val(Fila[13]);
        $('#txtAncho').val(Fila[14]);
        $('#txtDiamMax').val(Fila[15]);
        $('#txtDiamMin').val(Fila[16]);
        $('#txtPesoTecnico').val(Fila[17]);
        $('#txtEstadoIntegridad').val(Fila[18]);
        $('#txtCantidadConservacion').val(Fila[19]);
        $('#txtDetalleConservacion').val(Fila[20]);
        $('#txtProcedencia').val(Fila[21]);
        $('#txtRegion').val(Fila[22]);
        $('#txtSitio').val(Fila[23]);
        $('#txtSectorOrigen').val(Fila[24]);
        $('#txtSubSectorOrigen').val(Fila[25]);
        $('#txtUnidadPozo').val(Fila[26]);
        $('#txtCuadrante').val(Fila[27]);
        $('#txtCapaNivel').val(Fila[28]);
        $('#txtCuadriculaOrigen').val(Fila[29]);
        $('#txtContextoOrigen').val(Fila[30]);
        $('#txtColeccion').val(Fila[31]);
        $('#txtModoAdquisicion').val(Fila[32]);
        $('#txtDocumento').val(Fila[33]);
        $('#txtFechaPropiedad').val(Fila[34]);
        $('#txtUbicacion').val(Fila[35]);
        $('#txtAreaSala').val(Fila[36]);
        $('#txtUbicacionEspecifica').val(Fila[37]);
        $('#txtNivelUbicacion').val(Fila[38]);
        $('#txtNroCajaUbicacion').val(Fila[39]);
        $('#txtNroBolsaUbicacion').val(Fila[40]);
        $('#txtExcavado').val(Fila[41]);
        $('#txtRegistrado').val(Fila[42]);
        $('#txtFechaAdicional').val(Fila[43]);
        $('#txtObservacionAdic').val(Fila[44]);
        $('.piluku-preloader').removeClass('hidden');
              
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: {
                "param0": "CargaMasivaInv",
                "txtRegistroNac": $('#txtRegistroNac').val(),
                "txtCodPropietario": $('#txtCodPropietario').val(),
                "txtOtrosCod": $('#txtOtrosCod').val(),
                "txtCategoria": $('#txtCategoria').val(),
                "txtTaxonomia": $('#txtTaxonomia').val(),
                "txtDenominacion": $('#txtDenominacion').val(),
                "txtCultura": $('#txtCultura').val(),
                "txtPeriodo": $('#txtPeriodo').val(),
                "txtDescripcion": $('#txtDescripcion').val(),
                "txtTipoMat": $('#txtTipoMat').val(),
                "txtTecnicas": $('#txtTecnicas').val(),
                "txtAlto": $('#txtAlto').val(),
                "txtLargo": $('#txtLargo').val(),
                "txtAncho": $('#txtAncho').val(),
                "txtDiamMax": $('#txtDiamMax').val(),
                "txtDiamMin": $('#txtDiamMin').val(),
                "txtPesoTecnico": $('#txtPesoTecnico').val(),
                "txtEstadoIntegridad": $('#txtEstadoIntegridad').val(),
                "txtCantidadConservacion": $('#txtCantidadConservacion').val(),
                "txtDetalleConservacion": $('#txtDetalleConservacion').val(),
                "txtProcedencia": $('#txtProcedencia').val(),
                "txtRegion": $('#txtRegion').val(),
                "txtSitio": $('#txtSitio').val(),
                "txtSectorOrigen": $('#txtSectorOrigen').val(),
                "txtSubSectorOrigen": $('#txtSubSectorOrigen').val(),
                "txtUnidadPozo": $('#txtUnidadPozo').val(),
                "txtCuadrante": $('#txtCuadrante').val(),
                "txtCapaNivel": $('#txtCapaNivel').val(),
                "txtCuadriculaOrigen": $('#txtCuadriculaOrigen').val(),
                "txtContextoOrigen": $('#txtContextoOrigen').val(),
                "txtColeccion": $('#txtColeccion').val(),
                "txtModoAdquisicion": $('#txtModoAdquisicion').val(),
                "txtDocumento": $('#txtDocumento').val(),
                "txtFechaPropiedad": $('#txtFechaPropiedad').val(),
                "txtUbicacion": $('#txtUbicacion').val(),
                "txtAreaSala": $('#txtAreaSala').val(),
                "txtUbicacionEspecifica": $('#txtUbicacionEspecifica').val(),
                "txtNivelUbicacion": $('#txtNivelUbicacion').val(),
                "txtNroCajaUbicacion": $('#txtNroCajaUbicacion').val(),
                "txtNroBolsaUbicacion": $('#txtNroBolsaUbicacion').val(),
                "txtExcavado": $('#txtExcavado').val(),
                "txtRegistrado": $('#txtRegistrado').val(),
                "txtFechaAdicional": $('#txtFechaAdicional').val(),
                "txtObservacionAdic": $('#txtObservacionAdic').val()
            },
            dataType: "json",
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarInventariosDGC($("#paramdgc").val());
                tablaInventariosDGC();
                $('.piluku-preloader').addClass('hidden');
                $('div#mdConfirmarInventario').modal('hide');
            },
            error: function (result) {
                fnMensaje(data[0].alert, data[0].msje);
                console.log(result);
            }
        });

        
    }
    function limpia() {
        $('#inv').val("");
        $('#txtRegistroNac').val("");
        $('#txtCodPropietario').val("");
        $('#txtOtrosCod').val("");
        $('#txtCategoria').val("");
        $('#txtTaxonomia').val("");
        $('#txtDenominacion').val("");
        $('#txtCultura').val("");
        $('#txtPeriodo').val("");
        $('#txtDescripcion').val("");
        $('#txtTipoMat').val("");
        $('#txtTecnicas').val("");
        $('#txtAlto').val("");
        $('#txtLargo').val("");
        $('#txtAncho').val("");
        $('#txtDiamMax').val("");
        $('#txtDiamMin').val("");
        $('#txtPesoTecnico').val("");
        $('#txtEstadoIntegridad').val("");
        $('#txtCantidadConservacion').val("");
        $('#txtDetalleConservacion').val("");
        $('#txtProcedencia').val("");
        $('#txtRegion').val("");
        $('#txtSitio').val("");
        $('#txtSectorOrigen').val("");
        $('#txtSubSectorOrigen').val("");
        $('#txtUnidadPozo').val("");
        $('#txtCuadrante').val("");
        $('#txtCapaNivel').val("");
        $('#txtCuadriculaOrigen').val("");
        $('#txtContextoOrigen').val("");
        $('#txtColeccion').val("");
        $('#txtModoAdquisicion').val("");
        $('#txtDocumento').val("");
        $('#txtFechaPropiedad').val("");
        $('#txtUbicacion').val("");
        $('#txtAreaSala').val("");
        $('#txtUbicacionEspecifica').val("");
        $('#txtNivelUbicacion').val("");
        $('#txtNroCajaUbicacion').val("");
        $('#txtNroBolsaUbicacion').val("");
        $('#txtExcavado').val("");
        $('#txtRegistrado').val("");
        $('#txtFechaAdicional').val("");
        $('#txtObservacionAdic').val("");

    }
    function fnBorrarG(c, d) {
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
            if (aData[i].cod_inventario == c) {
                j = i;
                return j;
            }
        }
    }
    function fnEditar(c) {
        $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
        var x = fnBuscar(c);
        if (x >= 0) {
            $('#inv').val(aData[x].cod_inventario);
            var val1 = aData[x].registro_nacional
            $('#txtRegistroNac').val(val1.trim());
            var val1 = aData[x].codigo_propiet
            $('#txtCodPropietario').val(val1.trim());
            var val1 = aData[x].otro_codigo
            $('#txtOtrosCod').val(val1.trim());
            var val1 = aData[x].categoria
            $('#txtCategoria').val(val1.trim());
            var val1 = aData[x].taxonomia
            $('#txtTaxonomia').val(val1.trim());
            var val1 = aData[x].denominacion
            $('#txtDenominacion').val(val1.trim());
            var val1 = aData[x].cultura
            $('#txtCultura').val(val1.trim());
            var val1 = aData[x].periodo
            $('#txtPeriodo').val(val1.trim());
            var val1 = aData[x].descripcion_identificacion
            $('#txtDescripcion').val(val1.trim()); 
            var val1 = aData[x].tipo_material
            $('#txtTipoMat').val(val1.trim());
            var val1 = aData[x].tecnicas
            $('#txtTecnicas').val(val1.trim());
            $('#txtAlto').val(aData[x].alto);            
            $('#txtLargo').val(aData[x].largo);
            $('#txtAncho').val(aData[x].ancho);         
            $('#txtDiamMax').val(aData[x].diam_maximo);
            $('#txtDiamMin').val(aData[x].diam_min);
            $('#txtPesoTecnico').val(aData[x].peso);
            var val1 = aData[x].estado_integridad;
            $('#txtEstadoIntegridad').val(val1.trim());
            var val1 = aData[x].cantidad;
            $('#txtCantidadConservacion').val(val1.trim());
            var val1 = aData[x].detalle_conservacion;
            $('#txtDetalleConservacion').val(val1.trim());
            var val1 = aData[x].procedencia;
            $('#txtProcedencia').val(val1.trim());
            var val1 = aData[x].region_origen;
            $('#txtRegion').val(val1.trim());
            var val1 = aData[x].sitio_origen;
            $('#txtSitio').val(val1.trim());
            var val1 = aData[x].sector_origen;
            $('#txtSectorOrigen').val(val1.trim());
            var val1 = aData[x].subsector_origen;
            $('#txtSubSectorOrigen').val(val1.trim());
            var val1 = aData[x].unidad_origen;
            $('#txtUnidadPozo').val(val1.trim());
            var val1 = aData[x].cuadrante_origen;
            $('#txtCuadrante').val(val1.trim());
            var val1 = aData[x].capa_origen;
            $('#txtCapaNivel').val(val1.trim());
            var val1 = aData[x].cuadricula_origen;
            $('#txtCuadriculaOrigen').val(val1.trim());
            var val1 = aData[x].contexto_origen;
            $('#txtContextoOrigen').val(val1.trim());
            var val1 = aData[x].coleccion_propiedad;
            $('#txtColeccion').val(val1.trim());
            var val1 = aData[x].adquisicion_propiedad;
            $('#txtModoAdquisicion').val(val1.trim());
            var val1 = aData[x].documento_propiedad;
            $('#txtDocumento').val(val1.trim());
            //if (aData[x].fecha_propiedad != '1/01/1999 00:00:00') { JAZ
            if (aData[x].fecha_propiedad != '01/01/2001 0:00:00') {
                $('#txtFechaPropiedad').val(aData[x].fecha_propiedad);
            } else {
                $('#txtFechaPropiedad').val('');
            }
            var val1 = aData[x].ubicacion;
            $('#txtUbicacion').val(val1.trim());
            var val1 = aData[x].area_ubicacion;
            $('#txtAreaSala').val(val1.trim());
            var val1 = aData[x].especifica_ubicacion;
            $('#txtUbicacionEspecifica').val(val1.trim());
            var val1 = aData[x].nivel_ubicacion;
            $('#txtNivelUbicacion').val(val1.trim());
            var val1 = aData[x].caja_ubicacion;
            $('#txtNroCajaUbicacion').val(val1.trim());
            var val1 = aData[x].bolsa_ubicacion;
            $('#txtNroBolsaUbicacion').val(val1.trim());
            var val1 = aData[x].excavado_adic;
            $('#txtExcavado').val(val1.trim());
            var val1 = aData[x].registrado_adic;
            $('#txtRegistrado').val(val1.trim());
            //if (aData[x].fecha_adic != '1/01/1999 00:00:00') {    JAZ
            if (aData[x].fecha_adic != '01/01/2001 0:00:00') {
                $('#txtFechaAdicional').val(aData[x].fecha_adic);
            } else {
                $('#txtFechaAdicional').val('');
            }            
            var val1 = aData[x].observacion_adic;
            $('#txtObservacionAdic').val(val1.trim());

        }
        $('div#mdConfirmarInventario').modal('show');
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
        $("input#param0").val("DelInventario");
        var form = $('#frmInventario').serialize();
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "DelInventario", "param1": $("#param1").val() },
            dataType: "json",
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarInventariosDGC($("#paramdgc").val());
                tablaInventariosDGC();
                $('.piluku-preloader').addClass('hidden');
            },
            error: function (result) {
                $('.piluku-preloader').addClass('hidden');
                f_Menu("informationInv.aspx");
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
            data: { "param0": "lst", "param1": param1 },
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
                $('#' + combo).html(t);
            },
            error: function (result) {
                console.log('error');
            }
        });
        $("#param0").val("");
    }
    function listarInventariosDGC(val) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            //Inicio JAZ
            //data: { "param0": "lstTbInventario", "param1": val },
            data: { "param0": "lstTbInventarioDGC", "param1": val },
            //Fin JAZ
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
    function tablaInventariosDGC() {
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
                tb += '<center><a href="#" class="btn btn-green btn-xs" onclick="fnEditar(\'' + aData[i].cod_inventario + '\')" ><i class="ion-edit"></i></a>';
                tb += '<a href="#" class="btn btn-red btn-xs" onclick="fnBorrarG(\'' + aData[i].cod_inventario + '\',\'' + aData[i].codigo_propiet + '\')" ><i class="ion-android-cancel"></i></a></td>';
                tb += '</center></td>';
                tb += '<td style="text-align:center">' + aData[i].codigo_propiet + '</td>';
                tb += '<td style="text-align:center">' + aData[i].contexto_origen + '</td>';
                tb += '<td style="text-align:center">' + aData[i].cultura + '</td>';
                tb += '<td style="text-align:center">' + aData[i].tipo_material + '</td>';
                tb += '<td style="text-align:center">' + aData[i].bolsa_ubicacion + '</td>';
                tb += '<td style="text-align:center">' + aData[i].caja_ubicacion + '</td>';
                tb += '</tr>';
            }
        } else {
            tb = "";
        }
        fnDestroyDataTableDetalle('tbInventario');
        $('#pInventario').html(tb);
        fnResetDataTableTramite('tbInventario', 0, 'asc');
    }
    function fnGuardarParte2() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //if ($("#txtObservacion").val() == 0) {
        //    mensaje = "Ingrese Observación "
        //    sw = 1;
        //}
        if ($("#txtEstante").val() == "") {
            mensaje = "Ingrese Estante";
            sw = 1;
        }else{
            if ($("#txtEstante").val() > 6000) {
                mensaje = "Estante debe ser menor a 6000";
                $("#txtEstante").select();
                sw = 1;
            }
        }
        if ($("#txtAlmacen").val() == "") {
            mensaje = "Ingrese Almacen "
            sw = 1;
        }else{
            if ($("#txtAlmacen").val() > 6000) {
                mensaje = "Almacen debe ser menor a 6000";
                $("#txtAlmacen").select();
                sw = 1;
            }
        }
        if ($("#txtFechaReg").val() == "") {
            mensaje = "Seleccione Fecha de Registro";
            sw = 1;
        }
        if ($("#txtFechaAlmacen").val() == "") {
            mensaje = "Seleccione Fecha de Almacen";
            sw = 1;
        }
        if ($("#txtPeso").val() == "") {
            mensaje = "Ingrese Peso"
            sw = 1;
        }else{
            if ($("#txtPeso").val() > 6000) {
                mensaje = "Peso debe ser menor a 6000";
                $("#txtPeso").select();
                sw = 1;
            }
        }
        if ($("#txtCantidad").val() == "") {
            mensaje = "Ingrese Cantidad"
            sw = 1;
        }else{
            if ($("#txtCantidad").val() > 6000) {
                mensaje = "Cantidad debe ser menor a 6000";
                $("#txtCantidad").select();
                sw = 1;
            }
        }
        if ($("#txtFinRotu").val() == "") {
            mensaje = "Ingrese Fin de Rotulación";
            sw = 1;
        }
        //if ($("#txtIniRotu").val() == "") {
        //    mensaje = "Ingrese Inicio de Rotulación"
        //    sw = 1;
        //}
        if ($("#txtNroBolsa").val() == "") {
            mensaje = "Ingrese Nro de Bolsa";
            sw = 1;
        }
        //if ($("#txtNroCaja").val() == "") {
        //    mensaje = "Ingrese Nro Caja"
        //    sw = 1;
        //}
        //if ($("#txtOtrosDatos").val() == "") {
        //    mensaje = "Ingrese Otro Datos"
        //    sw = 1;
        //}
        if ($("#txtEstilo").val() == "") {
            mensaje = "Ingrese Estilo";
            sw = 1;
        }
        if ($("#txtCultrura").val() == "") {
            mensaje = "Ingrese Cultura";
            sw = 1;
        }
        if ($("#txtDescripcion").val() == "") {
            mensaje = "Ingrese Descripción";
            sw = 1;
        }
        if ($("#inv").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN";
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabOrigen"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gInventario2");
            var form = $('#frmInventario').serialize();
            $.ajax({
                type: "GET",
                //contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {
                    fnMensaje(data[0].alert, data[0].msje);
                    $('#inv').val(data[0].code);
                    listarInventariosDGC($("#paramdgc").val());
                    tablaInventariosDGC()
                    $('.piluku-preloader').addClass('hidden');
                    $('div#mdConfirmarInventario').modal('hide');
                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    console.log(result);
                }
            });
        }
        $("#param0").val("");
    }
    function fnValidarIdentificacion() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        if ($("#txtCodPropietario").val() == "") {
            mensaje = "Ingrese Código del Museo";
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabTecnicos"]').tab('show')
            }
            return false;
        } else {
            $('.nav-tabs a[href="#tabTecnicos"]').tab('show')
        }
    }
    function fnValidarTecnicos() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        

        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabTecnicos"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabConservacion"]').tab('show')
            }
            return false;
        } else {
            $('.nav-tabs a[href="#tabConservacion"]').tab('show')
        }
    }
    function fnValidarConservacion() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabConservacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabOrigen"]').tab('show')
            }
            return false;
        } else {
            $('.nav-tabs a[href="#tabOrigen"]').tab('show')
        }
    }
    function fnValidarOrigen() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        

        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabOrigen"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabPropiedad"]').tab('show')
            }
            return false;
        } else {
            $('.nav-tabs a[href="#tabPropiedad"]').tab('show')
        }
    }
    function fnValidarPropiedad() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabPropiedad"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabUbicacion"]').tab('show')
            }
            return false;
        } else {
            $('.nav-tabs a[href="#tabUbicacion"]').tab('show')
        }
    }
    function fnValidarUbicacion() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabUbicacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabAdicional"]').tab('show')
            }
            return false;
        } else {
            $('.nav-tabs a[href="#tabAdicional"]').tab('show')
        }
    }
    function fnValidarAdicional() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabAdicional"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabAdicional"]').tab('show')
            }
            return false;
        } else {
            if ($("#inv").val() == '') {
                $('.piluku-preloader').removeClass('hidden');                
                $.ajax({
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    url: "processmuseo.aspx",
                    data: {
                        "param0": "regInventario",
                        "txtRegistroNac": $('#txtRegistroNac').val(),
                        "txtCodPropietario": $('#txtCodPropietario').val(),
                        "txtOtrosCod": $('#txtOtrosCod').val(),
                        "txtCategoria": $('#txtCategoria').val(),
                        "txtTaxonomia": $('#txtTaxonomia').val(),
                        "txtDenominacion": $('#txtDenominacion').val(),
                        "txtCultura": $('#txtCultura').val(),
                        "txtPeriodo": $('#txtPeriodo').val(),
                        "txtDescripcion": $('#txtDescripcion').val(),
                        "txtTipoMat": $('#txtTipoMat').val(),
                        "txtTecnicas": $('#txtTecnicas').val(),
                        "txtAlto": $('#txtAlto').val(),
                        "txtLargo": $('#txtLargo').val(),
                        "txtAncho": $('#txtAncho').val(),
                        "txtDiamMax": $('#txtDiamMax').val(),
                        "txtDiamMin": $('#txtDiamMin').val(),
                        "txtPesoTecnico": $('#txtPesoTecnico').val(),
                        "txtEstadoIntegridad": $('#txtEstadoIntegridad').val(),
                        "txtCantidadConservacion": $('#txtCantidadConservacion').val(),
                        "txtDetalleConservacion": $('#txtDetalleConservacion').val(),
                        "txtProcedencia": $('#txtProcedencia').val(),
                        "txtRegion": $('#txtRegion').val(),
                        "txtSitio": $('#txtSitio').val(),
                        "txtSectorOrigen": $('#txtSectorOrigen').val(),
                        "txtSubSectorOrigen": $('#txtSubSectorOrigen').val(),
                        "txtUnidadPozo": $('#txtUnidadPozo').val(),
                        "txtCuadrante": $('#txtCuadrante').val(),
                        "txtCapaNivel": $('#txtCapaNivel').val(),
                        "txtCuadriculaOrigen": $('#txtCuadriculaOrigen').val(),
                        "txtContextoOrigen": $('#txtContextoOrigen').val(),
                        "txtColeccion": $('#txtColeccion').val(),
                        "txtModoAdquisicion": $('#txtModoAdquisicion').val(),
                        "txtDocumento": $('#txtDocumento').val(),
                        "txtFechaPropiedad": $('#txtFechaPropiedad').val(),
                        "txtUbicacion": $('#txtUbicacion').val(),
                        "txtAreaSala": $('#txtAreaSala').val(),
                        "txtUbicacionEspecifica": $('#txtUbicacionEspecifica').val(),
                        "txtNivelUbicacion": $('#txtNivelUbicacion').val(),
                        "txtNroCajaUbicacion": $('#txtNroCajaUbicacion').val(),
                        "txtNroBolsaUbicacion": $('#txtNroBolsaUbicacion').val(),
                        "txtExcavado": $('#txtExcavado').val(),
                        "txtRegistrado": $('#txtRegistrado').val(),
                        "txtFechaAdicional": $('#txtFechaAdicional').val(),
                        "txtObservacionAdic": $('#txtObservacionAdic').val()
                    },
                    dataType: "json",
                    success: function (data) {
                        fnMensaje(data[0].alert, data[0].msje);
                        listarInventariosDGC($("#paramdgc").val());
                        tablaInventariosDGC();
                        $('.piluku-preloader').addClass('hidden');
                        $('div#mdConfirmarInventario').modal('hide');
                    },
                    error: function (result) {
                        fnMensaje(data[0].alert, data[0].msje);
                        console.log(result);
                    }
                });
            } else {
                $('.piluku-preloader').removeClass('hidden');
                $('.piluku-preloader').removeClass('hidden');
                $.ajax({
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    url: "processmuseo.aspx",
                    data: {
                        "param0": "modInventario",
                        "inv": $("#inv").val(),
                        "txtRegistroNac": $('#txtRegistroNac').val(),
                        "txtCodPropietario": $('#txtCodPropietario').val(),
                        "txtOtrosCod": $('#txtOtrosCod').val(),
                        "txtCategoria": $('#txtCategoria').val(),
                        "txtTaxonomia": $('#txtTaxonomia').val(),
                        "txtDenominacion": $('#txtDenominacion').val(),
                        "txtCultura": $('#txtCultura').val(),
                        "txtPeriodo": $('#txtPeriodo').val(),
                        "txtDescripcion": $('#txtDescripcion').val(),
                        "txtTipoMat": $('#txtTipoMat').val(),
                        "txtTecnicas": $('#txtTecnicas').val(),
                        "txtAlto": $('#txtAlto').val(),
                        "txtLargo": $('#txtLargo').val(),
                        "txtAncho": $('#txtAncho').val(),
                        "txtDiamMax": $('#txtDiamMax').val(),
                        "txtDiamMin": $('#txtDiamMin').val(),
                        "txtPesoTecnico": $('#txtPesoTecnico').val(),
                        "txtEstadoIntegridad": $('#txtEstadoIntegridad').val(),
                        "txtCantidadConservacion": $('#txtCantidadConservacion').val(),
                        "txtDetalleConservacion": $('#txtDetalleConservacion').val(),
                        "txtProcedencia": $('#txtProcedencia').val(),
                        "txtRegion": $('#txtRegion').val(),
                        "txtSitio": $('#txtSitio').val(),
                        "txtSectorOrigen": $('#txtSectorOrigen').val(),
                        "txtSubSectorOrigen": $('#txtSubSectorOrigen').val(),
                        "txtUnidadPozo": $('#txtUnidadPozo').val(),
                        "txtCuadrante": $('#txtCuadrante').val(),
                        "txtCapaNivel": $('#txtCapaNivel').val(),
                        "txtCuadriculaOrigen": $('#txtCuadriculaOrigen').val(),
                        "txtContextoOrigen": $('#txtContextoOrigen').val(),
                        "txtColeccion": $('#txtColeccion').val(),
                        "txtModoAdquisicion": $('#txtModoAdquisicion').val(),
                        "txtDocumento": $('#txtDocumento').val(),
                        "txtFechaPropiedad": $('#txtFechaPropiedad').val(),
                        "txtUbicacion": $('#txtUbicacion').val(),
                        "txtAreaSala": $('#txtAreaSala').val(),
                        "txtUbicacionEspecifica": $('#txtUbicacionEspecifica').val(),
                        "txtNivelUbicacion": $('#txtNivelUbicacion').val(),
                        "txtNroCajaUbicacion": $('#txtNroCajaUbicacion').val(),
                        "txtNroBolsaUbicacion": $('#txtNroBolsaUbicacion').val(),
                        "txtExcavado": $('#txtExcavado').val(),
                        "txtRegistrado": $('#txtRegistrado').val(),
                        "txtFechaAdicional": $('#txtFechaAdicional').val(),
                        "txtObservacionAdic": $('#txtObservacionAdic').val()
                    },
                    dataType: "json",
                    success: function (data) {
                        fnMensaje(data[0].alert, data[0].msje);
                        listarInventariosDGC($("#paramdgc").val());
                        tablaInventariosDGC();
                        $('.piluku-preloader').addClass('hidden');
                        $('div#mdConfirmarInventario').modal('hide');
                    },
                    error: function (result) {
                        fnMensaje(data[0].alert, data[0].msje);
                        console.log(result);
                    }
                })
            }
            
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
    function fnBuscarCodigo() {
        if ($("#txtCodPropietario").val() == "") {
            var mensj = "Para buscar necesita llenar Código del Museo"
        } else {
            $.ajax({             
            //type: "POST",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstEvaluaciones2", "param1": $('#txtCodPropietario').val(), "param2": $('#paramdgc').val() },
            //data: form,
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {  
                if (data.length > 0) {
                    $('#txtOtrosCod').val(data[0].codexcavacion_con);
                    $('#txtDescripcion').val(data[0].descripcion_con);
                    $('#txtTipoMat').val(data[0].material_con);
                    $('#txtAlto').val(data[0].alto_con);
                    $('#txtLargo').val(data[0].largo_con);
                    $('#txtAncho').val(data[0].ancho_con);
                    $('#txtDiamMax').val(data[0].diametromax_con);
                    $('#txtDiamMin').val(data[0].diametromin_con);
                    $('#txtPesoTecnico').val(data[0].peso_con);
                    var integri = aData[0].integridadbien_con;
                    var inte = "";
                    if (integri == "1") {
                        inte = "Completo";
                    }
                    if (integri == "2") {
                        inte = "Incompleto";
                    }
                    if (integri == "3") {
                        inte = "Completo Fragmentado";
                    }
                    if (integri == "4") {
                        inte = "Completo Reintegrado";
                    }
                    if (integri == "5") {
                        inte = "Incompleto Reintegrado";
                    }
                    if (integri == "6") {
                        inte = "Incompleto Fragmentado";
                    }
                    $('#txtEstadoIntegridad').val(inte);
                    $('#txtDetalleConservacion').val(data[0].detconservacion_con);
                    $('#txtSectorOrigen').val(data[0].sector_con);
                    $('#txtUnidadPozo').val(data[0].unidad_con);
                    $('#txtCapaNivel').val(data[0].capa_con);
                    $('#txtCuadriculaOrigen').val(data[0].cuadricula_con);
                    $('#txtContextoOrigen').val(data[0].contexto_con);
                    $('#txtNroCajaUbicacion').val(data[0].nrocaja_con);
                    $('#txtNroBolsaUbicacion').val(data[0].nrobolsa_con);
                    $('#txtObservacionAdic').val(data[0].observaciones_con);
                } else {
                    //fnMensaje("error", "No hay información con ese Código de Museo"); 
                    fnMensaje("error", "No hay información con ese Código de Propietario en Modulo de Conservación");
                }
            },
            error: function (result) {
                console.log(result);
                $('.piluku-preloader').addClass('hidden');
            }
        });
        }
    }

</script>

<meta http-equiv= "Content-Type" content="text/html; charset=UTF-8" />
</head>

<body  >

    <form id="frmInventario" name="frmInventario" runat="server">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="paramdgc" name="paramdgc" value="" runat="server" /> 
    <input type="hidden" id="inv" name="inv" value="" /> 

    <div class="panel panel-piluku">
        <div class="panel-heading">
		    <h3 class="panel-title">
                <div class="col-md-6" align="left" >
                      <div id="titulo" runat="server"> </div>  
                </div>
                <div class="col-md-5" align="right">
                        <a href="#" id="btnCargaMasiva" class="btn btn-white" style="width:30%" ><i class="ion-android-done"></i>&nbsp;Carga Masiva</a>  
                        <button type="button" class="btn btn-white " id="btnExportarRep" runat="server" ><i class="ion-android-download"></i>&nbsp;Exportar Reporte</button>
                </div>
		    </h3>
	    </div>	  
	    <div class='table-responsive'>	        
        <div class='panel-body' >
            <div class='table-responsive'>
                <table class='display dataTable cell-border' id='tbInventario' style="width:95%;font-size:smaller">
                    <thead>
                    <tr>
                            <th style="width:6%;text-align:center;"></th>
                            <%--<th style="width:8%;text-align:center;">Codido de Museo</th>--%>
                            <th style="width:8%;text-align:center;">Código Propietario</th>
                            <th style="width:25%;text-align:center;">Contexto</th>
                            <th style="width:25%;text-align:center;">Cultura</th>
                            <th style="width:25%;text-align:center;">Tipo Material</th>
                            <th style="width:8%;text-align:center;">Bolsa</th>
                            <th style="width:8%;text-align:center;">Caja</th>
                        </tr>
                        </thead>     
                        <tbody id ="pInventario" runat ="server">
                        </tbody>                             
                        <tfoot>
                        <tr>
                        <th colspan="7"></th>
                        </tr>
                        </tfoot>
                        </table>
        </div>    
            
                      
    </div> 
            <center>                        
                <a href="#" id="btnAgregarInventario" class="btn btn-primary btn-lg" style="width:30%" ><i class="ion-android-done"></i>&nbsp;Agregar Inventario</a>                
            </center>
                <br />  
                                
    </div> 


    </div>

<div class="">

</div>

<div class="modal fade " id="mdConfirmarInventario" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-jr">
    <div class="modal-content">
        <div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Inventario</h4>
		</div>
        <div class="modal-body">
            <div class="panel-body">
                <div role="tabpanel">
                    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="Li3" runat="server" ><a href="#tabIdentificacion" aria-controls="home" role="tab" data-toggle="tab" > Datos de Identificación</a></li>
					    <li role="presentationlogin" id="Li4" runat="server" ><a href="#tabTecnicos" aria-controls="profile" role="tab" data-toggle="tab" > Datos Técnicos</a></li>
                        <li role="presentationlogin" id="Li5" runat="server" ><a href="#tabConservacion" aria-controls="profile" role="tab" data-toggle="tab" > Conservacion</a></li>
                        <li role="presentationlogin" id="Li6" runat="server" ><a href="#tabOrigen" aria-controls="profile" role="tab" data-toggle="tab" > Datos de Origen</a></li>
                        <li role="presentationlogin" id="Li7" runat="server" ><a href="#tabPropiedad" aria-controls="profile" role="tab" data-toggle="tab" > Datos de Propiedad</a></li>
                        <li role="presentationlogin" id="Li8" runat="server" ><a href="#tabUbicacion" aria-controls="profile" role="tab" data-toggle="tab" > Datos de Ubicación</a></li>
                        <li role="presentationlogin" id="Li9" runat="server" ><a href="#tabAdicional" aria-controls="profile" role="tab" data-toggle="tab" > Adicional</a></li>
				    </ul>
    				<br />
                    <div class="tab-content piluku-tab-content">
	
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacion" runat="server" >
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtRegistroNac">
                                            Registro Nacional</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtRegistroNac" name="txtRegistroNac" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodPropietario">
                                            Código de Propietario:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodPropietario" name="txtCodPropietario" class="form-control" />
                                        </div>
                                        <div class="col-sm-1">
                                            <button type="button" class="btn btn-primary" id="btnBuscar" ><i class="glyphicon glyphicon-search"></i>&nbsp;Buscar</button>
                                        </div>
                                    </div>
                                </div> 
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrosCod">
                                            Otros códigos</label>           
                                        <div class="col-sm-3">
                                            <input type="text" id="txtOtrosCod" name="txtOtrosCod" class="form-control"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCategoria">
                                            Categoria:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCategoria" name="txtCategoria" class="form-control"  />
                                        </div>
                                    </div>
                                </div>                                
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTaxonomia">
                                            Tipo/Taxonomía</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtTaxonomia" name="txtTaxonomia" class="form-control"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDenominacion">
                                            Denominacion:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDenominacion" name="txtDenominacion" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCultura">
                                            Cultura/Estilo/Autor/Febricante:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCultura" name="txtCultura" class="form-control"  />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPeriodo">
                                            Periodo/Época/Año:</label>
                                        <%--<div class="col-sm-1"> #JAZ--%>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtPeriodo" name="txtPeriodo" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDescripcion">
                                            Descripcion:</label>
                                        <div class="col-sm-8">
                                            <input type="text" id="txtDescripcion" name="txtDescripcion" class="form-control"  />
                                        </div>
                                    </div>
                                </div>  
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			
                                        <button type="button" class="btn btn-primary" id="btnSiguiente1" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>
				        </div>
                        <div role="tabpanel" class="tab-pane " id="tabTecnicos" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTipoMat">
                                            Material:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtTipoMat" name="txtTipoMat" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTecnicas">
                                            Tecnicas:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtTecnicas" name="txtTecnicas" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAlto">
                                            Alto:</label>
                                        <div class="col-sm-3">
                                                <input type="text" id="txtAlto" name="txtAlto" class="form-control" onKeyPress="return soloNumeros(event,this)"/>          
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtLargo">
                                            Largo:</label>
                                        <div class="col-sm-3">
                                               <input type="text" id="txtLargo" name="txtLargo" class="form-control" onKeyPress="return soloNumeros(event,this)"/> 
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAncho">
                                            Ancho:</label>
                                        <div class="col-sm-3">
                                                <input type="text" id="txtAncho" name="txtAncho" class="form-control" onKeyPress="return soloNumeros(event,this)"/>             
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMax">
                                            Diam. Max.:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtDiamMax" name="txtDiamMax" class="form-control" onKeyPress="return soloNumeros(event,this)"/>              
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMin">
                                            Diam. Min.:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDiamMin" name="txtDiamMin" class="form-control" onKeyPress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPesoTecnico">
                                            Peso:</label>
                                        <div class="col-sm-3">
                                             <input type="text" id="txtPesoTecnico" name="txtPesoTecnico" class="form-control" onKeyPress="return soloNumeros(event,this)"/>         
                                        </div>
                                    </div>
                                </div> 
                                <div class="modal-footer">
		                          <center>
		                              <div class="btn-group">			      
                                            <button type="button" class="btn btn-primary" id="btnSiguiente2" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                               </div>
		                          </center>
		                        </div>
                        </div>
                        <div role="tabpanel" class="tab-pane " id="tabConservacion" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtEstadoIntegridad">
                                            Estado de Integridad:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtEstadoIntegridad" name="txtEstadoIntegridad" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCantidadConservacion">
                                            Cantidad:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCantidadConservacion" name="txtCantidadConservacion" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDetalleConservacion">
                                            Detalle de Conservacion:</label>
                                        <div class="col-sm-6">
                                                <input type="text" id="txtDetalleConservacion" name="txtDetalleConservacion" class="form-control" />          
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
		                          <center>
		                              <div class="btn-group">			      
                                            <button type="button" class="btn btn-primary" id="btnSiguiente3" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                               </div>
		                          </center>
		                        </div>
                        </div>
                        <div role="tabpanel" class="tab-pane " id="tabOrigen" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtProcedencia">
                                            Procedencia/Manufactura:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtProcedencia" name="txtProcedencia" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtRegion">
                                            Region/Área geográfica:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtRegion" name="txtRegion" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSitio">
                                            Sitio:</label>
                                        <div class="col-sm-3">
                                                <input type="text" id="txtSitio" name="txtSitio" class="form-control" />          
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSectorOrigen">
                                            Sector:</label>
                                        <div class="col-sm-3">
                                               <input type="text" id="txtSectorOrigen" name="txtSectorOrigen" class="form-control" /> 
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSubSectorOrigen">
                                            Sub Sector:</label>
                                        <div class="col-sm-3">
                                                <input type="text" id="txtSubSectorOrigen" name="txtSubSectorOrigen" class="form-control" />             
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUnidadPozo">
                                            Unidad/Pozo:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtUnidadPozo" name="txtUnidadPozo" class="form-control" />              
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCuadrante">
                                            Cuadrante:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCuadrante" name="txtCuadrante" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCapaNivel">
                                            Capa/Nivel:</label>
                                        <div class="col-sm-3">
                                             <input type="text" id="txtCapaNivel" name="txtCapaNivel" class="form-control" />         
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCuadriculaOrigen">
                                            Cuadrícula:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCuadriculaOrigen" name="txtCuadriculaOrigen" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtContextoOrigen">
                                            Contexto:</label>
                                        <div class="col-sm-3">
                                             <input type="text" id="txtContextoOrigen" name="txtContextoOrigen" class="form-control" />         
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
		                          <center>
		                              <div class="btn-group">			      
                                            <button type="button" class="btn btn-primary" id="btnSiguiente4" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                               </div>
		                          </center>
		                        </div>
                        </div>
                        <div role="tabpanel" class="tab-pane " id="tabPropiedad" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtColeccion">
                                            Coleccion/Proyecto:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtColeccion" name="txtColeccion" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtModoAdquisicion">
                                            Modo de Adquisición:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtModoAdquisicion" name="txtModoAdquisicion" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDocumento">
                                            Documento:</label>
                                        <div class="col-sm-3">
                                                <input type="text" id="txtDocumento" name="txtDocumento" class="form-control" />          
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtFechaPropiedad">
                                            Fecha:</label>
                                        <div class="col-sm-2">
                                            <div class="input-group date">
                                                <input type="text" id="txtFechaPropiedad" name="txtFechaPropiedad" class="form-control" data-provide="datepicker"/> 
                                                <span class="input-group-addon bg">
										            <i class="ion ion-ios-calendar-outline"></i>
									            </span>
                                            </div>
                                               
                                        </div>
                                    </div>
                                </div>   
                            <div class="modal-footer">
		                          <center>
		                              <div class="btn-group">			      
                                            <button type="button" class="btn btn-primary" id="btnSiguiente5" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                               </div>
		                          </center>
		                        </div>
                        </div>
                        <div role="tabpanel" class="tab-pane " id="tabUbicacion" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUbicacion">
                                            Ubicación:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtUbicacion" name="txtUbicacion" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAreaSala">
                                            Área/Sala:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAreaSala" name="txtAreaSala" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUbicacionEspecifica">
                                            Ubic. Específica:</label>
                                        <div class="col-sm-3">
                                                <input type="text" id="txtUbicacionEspecifica" name="txtUbicacionEspecifica" class="form-control" />          
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNivelUbicacion">
                                            Nivel:</label>
                                        <div class="col-sm-3">
                                               <input type="text" id="txtNivelUbicacion" name="txtNivelUbicacion" class="form-control" /> 
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroCajaUbicacion">
                                            Nro Caja:</label>
                                        <div class="col-sm-3">
                                                <input type="text" id="txtNroCajaUbicacion" name="txtNroCajaUbicacion" class="form-control" />             
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroBolsaUbicacion">
                                            Nro Bolsa:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtNroBolsaUbicacion" name="txtNroBolsaUbicacion" class="form-control" />              
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
		                          <center>
		                              <div class="btn-group">			      
                                            <button type="button" class="btn btn-primary" id="btnSiguiente6" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                               </div>
		                          </center>
		                        </div>
                        </div>
                        <div role="tabpanel" class="tab-pane " id="tabAdicional" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtExcavado">
                                            Excavado por:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtExcavado" name="txtExcavado" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtRegistrado">
                                            Registrado por:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtRegistrado" name="txtRegistrado" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtFechaAdicional">
                                            Fecha:</label>
                                         <div class="col-sm-2" >
                                            <div class="input-group date">
									            <input type="text" class="form-control" id="txtFechaAdicional" name="txtFechaAdicional" data-provide="datepicker"/>
									            <span class="input-group-addon bg">
										            <i class="ion ion-ios-calendar-outline"></i>
									            </span>
							                </div>	
                                        </div>
                                    </div>                                    
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2" for="txtObservacionAdic">
                                            Observación:</label>
                                        <div class="col-sm-8">
                                            <input type="text" id="txtObservacionAdic" name="txtObservacionAdic" class="form-control" />
                                        </div>
                                    </div>

                                </div>
               
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardar" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
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

<div class="modal fade" id="mdCargamasiva" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
    <div class="modal-dialog">
	    <div class="modal-content">
		    <div class="modal-header" style="background-color:#E33439;" >
			    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			    <h4 class="modal-title"  style="color:White">Carga Masiva de Inventarios</h4>
		    </div>
		    <div class="modal-body">
                <div class="panel-body">
                    <div role="tabpanel" class="tab-pane " id="Div1" runat="server" >
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label" for="txtArchivo">
                                        Archivo de Carga:</label>
                                    <div class="col-sm-8">
                                        <input type="file" id="fileArchivo" name="fileArchivo" class="form-control" accept=".csv"/>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
		                        <center>
		                            <div class="btn-group">			      
                                        <button type="button" class="btn btn-primary" id="btnGuardarC" ><i class="ion-android-done"></i>&nbsp;Cargar</button>	
		                            </div>
		                        </center>
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
