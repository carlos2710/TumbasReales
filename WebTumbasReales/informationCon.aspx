<%@ Page Language="VB" AutoEventWireup="false" CodeFile="informationCon.aspx.vb" Inherits="informationCon" %>

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

<style type="text/css">
    .tags-input-wrapper{
        background: transparent;
        padding: 10px;
        border-radius: 4px;
        max-width: 400px;
        border: 1px solid #ccc
    }
    .tags-input-wrapper input{
        border: none;
        background: transparent;
        outline: none;
        width: 140px;
        margin-left: 8px;
    }
    .tags-input-wrapper .tag{
        display: inline-block;
        background-color: #DADADA;
        color: black;
        border-radius: 40px;
        padding: 0px 3px 0px 7px;
        margin-right: 5px;
        margin-bottom:5px;
    }
    .tags-input-wrapper .tag a {
        margin: 0 7px 3px;
        display: inline-block;
        cursor: pointer;
    }
</style>
<script  type="text/javascript" >

    var aData = [];
    var bData = [];
    //JAZ
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
                for (let i = 1; i < carg.length - 1; i++) {
                    Carga.push(carg[i]);
                }
            }
            //reader.readAsText(file, 'ISO-8859-4');    JAZ
            reader.readAsText(file, 'ISO-8859-1');
        }

    }
    //JAZ
    jQuery(document).ready(function () {

        var nombre_eval;
        var lstEval;

        fnResetDataTableTramite('tbEvaluacion', 0, 'desc');
        //fnLstCombos("PER", "cboPeriodo");
        //fnLstCombos("CRO", "cboCronologia");
        //fnLstCombos("GEO", "cboGeografica");
        //fnLstCombos("CLA", "cboClasificacion");
        //fnLstCombos("CUS", "cbocustodio");
        //fnLstCombos("ADQ", "cboAquisicion");
        //fnLstCombos("DOC", "cboDocumentos");

        listarEvaluacionesDGC($("#paramdgc").val());
        tablaEvaluacionesDGC();

        $('#btnAddEvaluacion').click(function () {
            limpiarEval();
            $('.nav-tabs a[href="#tabIdentificacionE"]').tab('show')
            $('div#mdConfirmarEvaluacion').modal('show');
        });
        $('#btnAddTratamiento').click(function () {
            limpiarTra();
            $('.nav-tabs a[href="#tabIdentificacionT"]').tab('show')
            $('div#mdConfirmarTratamiento').modal('show');
        });
        $('#btnAddPostTrata').click(function () {
            limpiarPT();
            $('.nav-tabs a[href="#tabIdentificacionPT"]').tab('show')
            $('div#mdConfirmarPostTratamiento').modal('show');
        });
        $('#btnAddAlmacenes').click(function () {
            limpiarA();
            $('.nav-tabs a[href="#tabIdentificacionA"]').tab('show')
            $('div#mdConfirmarAlmacenes').modal('show');
        });

        $("#btnGuardarEval1").click(fnGuardarEval1);
        $("#btnGuardarEval2").click(fnGuardarEval2);
        $("#btnGuardarEval3").click(fnGuardarEval3);
        $("#btnGuardarEval4").click(fnGuardarEval4);
        $("#btnGuardarEval5").click(fnGuardarEval5);

        $("#btnGuardarTrata1").click(fnGuardarTrat1);
        $("#btnGuardarTrata2").click(fnGuardarTrat2);
        $("#btnGuardarTrata3").click(fnGuardarTrat3);
        $("#btnGuardarTrata4").click(fnGuardarTrat4);
        $("#btnGuardarTrata5").click(fnGuardarTrat5);
        $("#btnGuardarTrata6").click(fnGuardarTrat6);
        $("#btnGuardarTrata7").click(fnGuardarTrat7);

        $("#btnGuardarPostTrat1").click(fnGuardarPostT1);
        $("#btnGuardarPostTrat2").click(fnGuardarPostT2);
        $("#btnGuardarPostTrat3").click(fnGuardarPostT3);
        $("#btnGuardarPostTrat4").click(fnGuardarPostT4);

        $("#btnGuardarAlmac1").click(fnGuardarAlmac1);
        $("#btnGuardarAlmac2").click(fnGuardarAlmac2);
        $("#btnGuardarAlmac3").click(fnGuardarAlmac3);
        $("#btnGuardarAlmac4").click(fnGuardarAlmac4);
        //Inicio JAZ
        $("#btnBuscarI").click(fnBuscarI);  
        //Fin JAZ
        $("#btnBuscarT").click(fnBuscarT);
        $("#btnBuscarPT").click(fnBuscarPT);
        $("#btnBuscarA").click(fnBuscarA);        
        
        $("#btnDelReg").click(fnDelRegistro);
        //inicio JAZ
        $('#btnCargaMasiva').click(function () {
            if ($('#cboEtapa').value = 1) {
                limpiarEval();
            }
            else if ($('#cboEtapa').value = 2) {
                limpiarTra();
            }
            else if ($('#cboEtapa').value = 3) {
                limpiarPT();
            }
            else if ($('#cboEtapa').value = 4) {
                limpiarA();
            } 
            $('div#mdCargamasiva').modal('show');
        });
        $("#btnGuardarC").click(fnCargaMasiva);
        //fin JAZ

        permisos();

    });
    //inicio JAZ
    function fnCargaMasiva() {
        for (let i = 0; i < Carga.length; i++) {
            if ($('#cboEtapa').val() == '1') {
                fnCargarEva(i);
            }
            else if ($('#cboEtapa').val() == 2) {
                fnCargarTra(i);
            }
            else if ($('#cboEtapa').val() == 3) {
                fnCargarPost(i);
            }
            else if ($('#cboEtapa').val() == 4) {
                fnCargarAlm(i);
            }
        }
        $('#mdCargamasiva').modal('hide');
    }

    function fnCargarEva(i) {
        var Fila = Carga[i].split(";");
        $('#txtNroFichaE').val(Fila[0]);
        $('#txtCodRegNacE').val(Fila[1]);
        $('#txtCodPropietarioE').val(Fila[2]);
        $('#txtCodigoExcavacionE').val(Fila[3]);
        $('#txtCodRestaurE').val(Fila[4]);
        $('#txtSectorE').val(Fila[5]);
        $('#txtUnidadE').val(Fila[6]);
        $('#txtCapaE').val(Fila[7]);
        $('#txtNivelE').val(Fila[8]);
        $('#txtCuadriculaE').val(Fila[9]);
        $('#txtPlanoE').val(Fila[10]);
        $('#txtContextoE').val(Fila[11]);
        $('#txtUbicContextoE').val(Fila[12]);
        $('#txtAlturaObsE').val(Fila[13]);
        $('#txtOtrosDatosE').val(Fila[14]);
        $('#txtMaterialE').val(Fila[15]);
        $('#txtDenominacionE').val(Fila[16]);
        $('#txtDescripcionE').val(Fila[17]);
        $('#txtAltoE').val(Fila[18]);
        $('#txtLargoE').val(Fila[19]);
        $('#txtAnchoE').val(Fila[20]);
        $('#txtEspesorE').val(Fila[21]);
        $('#txtDiamMaxE').val(Fila[22]);
        $('#txtDiamMinE').val(Fila[23]);
        $('#txtDiamBaseE').val(Fila[24]);
        $('#txtPesoE').val(Fila[25]);
        $('#txtUbicInmuebleE').val(Fila[26]);
        $('#txtCajaE').val(Fila[27]);
        $('#txtBolsaE').val(Fila[28]);
        //$('#cboIntegridadE').val(Fila[29]);
        $('#cboIntegridadE').val(Fila[30]);
        $('#cboConservacionE').val(Fila[31]);
        $('#txtDetConservacionE').val(Fila[32]);
        $('#txtIntervencionE').val(Fila[33]);
        $('#txtAfectacionE').val(Fila[34]);
        $('#txtTratamiento').val(Fila[35]);
        $('#txtLimpieza').val(Fila[36]);
        $('#txtObservacionE').val(Fila[37]);
        $('#txtTemperaturaE').val(Fila[38]);
        $('#txtHumedad').val(Fila[39]);
        $('#txtMinipulacionE').val(Fila[40]);
        $('#txtOtrosE').val(Fila[41]);
        $('#txtConsCargoE').val(Fila[42]);
        $('#txtFechaE').val(Fila[43]);
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: {
                "param0": "CargaMasivaEva",
                "txtNroFichaE": $('#txtNroFichaE').val(),
                "txtCodRegNacE": $('#txtCodRegNacE').val(),
                "txtCodPropietarioE":$('#txtCodPropietarioE').val(),
                "txtCodigoExcavacionE":$('#txtCodigoExcavacionE').val(),
                "txtCodRestaurE": $('#txtCodRestaurE').val(),
                "paramdgc": $("#paramdgc").val(),
                "txtSectorE":$('#txtSectorE').val(),
                "txtUnidadE":$('#txtUnidadE').val(),
                "txtCapaE":$('#txtCapaE').val(),
                "txtNivelE":$('#txtNivelE').val(),
                "txtCuadriculaE":$('#txtCuadriculaE').val(),
                "txtPlanoE":$('#txtPlanoE').val(),
                "txtContextoE":$('#txtContextoE').val(),
                "txtUbicContextoE":$('#txtUbicContextoE').val(),
                "txtAlturaObsE":$('#txtAlturaObsE').val(),
                "txtOtrosDatosE":$('#txtOtrosDatosE').val(),
                "txtMaterialE":$('#txtMaterialE').val(),
                "txtDenominacionE":$('#txtDenominacionE').val(),
                "txtDescripcionE":$('#txtDescripcionE').val(),
                "txtAltoE":$('#txtAltoE').val(),
                "txtLargoE":$('#txtLargoE').val(),
                "txtAnchoE":$('#txtAnchoE').val(),
                "txtEspesorE":$('#txtEspesorE').val(),
                "txtDiamMaxE":$('#txtDiamMaxE').val(),
                "txtDiamMinE":$('#txtDiamMinE').val(),
                "txtDiamBaseE":$('#txtDiamBaseE').val(),
                "txtPesoE":$('#txtPesoE').val(),
                "txtUbicInmuebleE":$('#txtUbicInmuebleE').val(),
                "txtCajaE":$('#txtCajaE').val(),
                "txtBolsaE":$('#txtBolsaE').val(),
                "cboIntegridadE":$('#cboIntegridadE').val(),
                "cboConservacionE":$('#cboConservacionE').val(),
                "txtDetConservacionE":$('#txtDetConservacionE').val(),
                "txtIntervencionE":$('#txtIntervencionE').val(),
                "txtAfectacionE":$('#txtAfectacionE').val(),
                "txtTratamiento":$('#txtTratamiento').val(),
                "txtLimpieza":$('#txtLimpieza').val(),
                "txtObservacionE":$('#txtObservacionE').val(),
                "txtTemperaturaE":$('#txtTemperaturaE').val(),
                "txtHumedad":$('#txtHumedad').val(),
                "txtMinipulacionE":$('#txtMinipulacionE').val(),
                "txtOtrosE":$('#txtOtrosE').val(),
                "txtConsCargoE":$('#txtConsCargoE').val(),
                "txtFechaE":$('#txtFechaE').val()
            },
            dataType: "json",
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarEvaluacionesDGC($("#paramdgc").val());
                tablaEvaluacionesDGC()
                $('.piluku-preloader').addClass('hidden');
            },
            error: function (result) {
                fnMensaje(data[0].alert, data[0].msje);
            }
        });


    }

    function fnCargarTra(i) {
        var Fila = Carga[i].split(";");
        $('#eval').val(Fila[0]);
        $('#txtCodRegNacT').val(Fila[1]);
        $('#txtCodPropietarioT').val(Fila[2]);
        $('#txtCodigoExcavacionT').val(Fila[3]);
        $('#txtCodRestaurT').val(Fila[4]);
        $('#txtSectorT').val(Fila[5]);
        $('#txtUnidadT').val(Fila[6]);
        $('#txtCapaT').val(Fila[7]);
        $('#txtNivelT').val(Fila[8]);
        $('#txtCuadriculaT').val(Fila[9]);
        $('#txtPlanoT').val(Fila[10]);
        $('#txtContextoT').val(Fila[11]);
        $('#txtUbicContextoT').val(Fila[12]);
        $('#txtAlturaObsT').val(Fila[13]);
        $('#txtOtrosDatosT').val(Fila[14]);
        $('#txtMaterialT').val(Fila[15]);
        $('#txtDenominacionT').val(Fila[16]);
        $('#txtDescripcionT').val(Fila[17]);
        $('#txtLargoT').val(Fila[18]);
        $('#txtAltoT').val(Fila[19]);
        $('#txtAnchoT').val(Fila[20]);
        $('#txtEspesorT').val(Fila[21]);
        $('#txtDiamMaxT').val(Fila[22]);
        $('#txtDiamMinT').val(Fila[23]);
        $('#txtDiamBaseT').val(Fila[24]);
        $('#txtPesoIniT').val(Fila[25]);
        $('#txtPesoFinT').val(Fila[26]);
        $('#txtUbicInmuebleT').val(Fila[27]);
        $('#txtCajaT').val(Fila[28]);
        $('#txtBolsaT').val(Fila[29]);
        $('#cboIntegridadT').val(Fila[30]);
        $('#cboConservacionT').val(Fila[31]);
        $('#txtDetConservacionT').val(Fila[32]);
        $('#txtIntervAntT').val(Fila[33]);
        $('#txtFechaIniT').val(Fila[34]);
        $('#txtFechFinT').val(Fila[35]);
        $('#txtDetTratamientoT').val(Fila[36]);
        $('#txtSecadoT').val(Fila[37]);
        $('#txtPegadoT2').val(Fila[38]);
        $('#txtConsolidacionT').val(Fila[39]);
        $('#txtReIntegracT').val(Fila[40]);
        $('#txtOtrosPostT').val(Fila[41]);
        $('#txtFechaIniProcT').val(Fila[42]);
        $('#txtFechaFinProcT').val(Fila[43]);
        $('#txtTemperaturaT').val(Fila[44]);
        $('#txtHumedadT').val(Fila[45]);
        $('#txtManipulacionT').val(Fila[46]);
        $('#txtIluminacionT').val(Fila[47]);
        $('#txtOtrosRecT').val(Fila[48]);
        $('#txtMaterialRecomendT').val(Fila[49]);
        $('#txtObservacionesT').val(Fila[50]);
        $('#txtConservCargoT').val(Fila[51]);
        $('#txtFechaT').val(Fila[52]);
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: {
                "param0": "CargaMasivaTra",
                "eval": $('#eval').val(),
                "paramdgc": $("#paramdgc").val(),
                "txtCodRegNacT": $('#txtCodRegNacT').val(),
                "txtCodPropietarioT": $('#txtCodPropietarioT').val(),
                "txtCodigoExcavacionT": $('#txtCodigoExcavacionT').val(),
                "txtCodRestaurT": $('#txtCodRestaurT').val(),
                "txtSectorT": $('#txtSectorT').val(),
                "txtUnidadT": $('#txtUnidadT').val(),
                "txtCapaT": $('#txtCapaT').val(),
                "txtNivelT": $('#txtNivelT').val(),
                "txtCuadriculaT": $('#txtCuadriculaT').val(),
                "txtPlanoT": $('#txtPlanoT').val(),
                "txtContextoT": $('#txtContextoT').val(),
                "txtUbicContextoT": $('#txtUbicContextoT').val(),
                "txtAlturaObsT": $('#txtAlturaObsT').val(),
                "txtOtrosDatosT": $('#txtOtrosDatosT').val(),
                "txtMaterialT": $('#txtMaterialT').val(),
                "txtDenominacionT": $('#txtDenominacionT').val(),
                "txtDescripcionT": $('#txtDescripcionT').val(),
                "txtLargoT": $('#txtLargoT').val(),
                "txtAltoT": $('#txtAltoT').val(),
                "txtAnchoT": $('#txtAnchoT').val(),
                "txtEspesorT": $('#txtEspesorT').val(),
                "txtDiamMaxT": $('#txtDiamMaxT').val(),
                "txtDiamMinT": $('#txtDiamMinT').val(),
                "txtDiamBaseT": $('#txtDiamBaseT').val(),
                "txtPesoIniT": $('#txtPesoIniT').val(),
                "txtPesoFinT": $('#txtPesoFinT').val(),
                "txtUbicInmuebleT": $('#txtUbicInmuebleT').val(),
                "txtCajaT": $('#txtCajaT').val(),
                "txtBolsaT": $('#txtBolsaT').val(),
                "cboIntegridadT": $('#cboIntegridadT').val(),
                "cboConservacionT": $('#cboConservacionT').val(),
                "txtDetConservacionT": $('#txtDetConservacionT').val(),
                "txtIntervAntT": $('#txtIntervAntT').val(),
                "txtFechaIniT": $('#txtFechaIniT').val(),
                "txtFechFinT": $('#txtFechFinT').val(),
                "txtDetTratamientoT": $('#txtDetTratamientoT').val(),
                "txtSecadoT": $('#txtSecadoT').val(),
                "txtPegadoT2": $('#txtPegadoT2').val(),
                "txtConsolidacionT": $('#txtConsolidacionT').val(),
                "txtReIntegracT": $('#txtReIntegracT').val(),
                "txtOtrosPostT": $('#txtOtrosPostT').val(),
                "txtFechaIniProcT": $('#txtFechaIniProcT').val(),
                "txtFechaFinProcT": $('#txtFechaFinProcT').val(),
                "txtTemperaturaT": $('#txtTemperaturaT').val(),
                "txtHumedadT": $('#txtHumedadT').val(),
                "txtManipulacionT": $('#txtManipulacionT').val(),
                "txtIluminacionT": $('#txtIluminacionT').val(),
                "txtOtrosRecT": $('#txtOtrosRecT').val(),
                "txtMaterialRecomendT": $('#txtMaterialRecomendT').val(),
                "txtObservacionesT": $('#txtObservacionesT').val(),
                "txtConservCargoT": $('#txtConservCargoT').val(),
                "txtFechaT": $('#txtFechaT').val()
            },
            dataType: "json",
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarEvaluacionesDGC($("#paramdgc").val());
                tablaEvaluacionesDGC()
                $('.piluku-preloader').addClass('hidden');
            },
            error: function (result) {
                fnMensaje(data[0].alert, data[0].msje);
            }
        });
    }

    function fnCargarPost(i) {
        var Fila = Carga[i].split(";");
        $('#eval').val(Fila[0]);
        $('#txtCodRegNacPT').val(Fila[1]);
        $('#txtCodPropietarioPT').val(Fila[2]);
        $('#txtCodigoExcavacionPT').val(Fila[3]);
        $('#txtCodRestaurPT').val(Fila[4]);
        $('#txtSectorPT').val(Fila[5]);
        $('#txtUnidadPT').val(Fila[6]);
        $('#txtCapaPT').val(Fila[7]);
        $('#txtNivelPT').val(Fila[8]);
        $('#txtCuadriculaPT').val(Fila[9]);
        $('#txtPlanoPT').val(Fila[10]);
        $('#txtContextoPT').val(Fila[11]);
        $('#txtUbicContextoPT').val(Fila[12]);
        $('#txtAlturaObsPT').val(Fila[13]);
        $('#txtOtrosDatosPT').val(Fila[14]);
        $('#txtMaterialPT').val(Fila[15]);
        $('#txtDenominacionPT').val(Fila[16]);
        $('#txtDescripcionPT').val(Fila[17]);
        $('#txtAltoPT').val(Fila[18]);
        $('#txtLargoPT').val(Fila[19]);
        $('#txtAnchoPT').val(Fila[20]);
        $('#txtEspesorPT').val(Fila[21]);
        $('#txtDiamMaxPT').val(Fila[22]);
        $('#txtDiamMinPT').val(Fila[23]);
        $('#txtDiamBasePT').val(Fila[24]);
        $('#txtPesoPT').val(Fila[25]);
        $('#txtUbicInmueblePT').val(Fila[26]);
        $('#txtCajaPT').val(Fila[27]);
        $('#txtBolsaPT').val(Fila[28]);
        $('#txtProblemPT').val(Fila[29]);
        $('#txtVariacPT').val(Fila[30]);
        $('#txtReaccionesPT').val(Fila[31]);
        $('#txtPresAfectPT').val(Fila[32]);
        $('#txtTipoAfecPT').val(Fila[33]);
        $('#txtCausaAfecPT').val(Fila[34]);
        $('#txtRecomenPT').val(Fila[35]);
        $('#txtConseCargoPT').val(Fila[36]);
        $('#txtFechaPT').val(Fila[37]);
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: {
                "param0": "CargaMasivaPost",
                "paramdgc": $("#paramdgc").val(),
                "txtNroFichaPT": $("#eval").val(),
                "txtCodRegNacPT": $("#txtCodRegNacPT").val(),
                "txtCodPropietarioPT": $("#txtCodPropietarioPT").val(),
                "txtCodigoExcavacionPT": $("#txtCodigoExcavacionPT").val(),
                "txtCodRestaurPT": $("#txtCodRestaurPT").val(),
                "txtSectorPT": $("#txtSectorPT").val(),
                "txtUnidadPT": $("#txtUnidadPT").val(),
                "txtCapaPT": $("#txtCapaPT").val(),
                "txtNivelPT": $("#txtNivelPT").val(),
                "txtCuadriculaPT": $("#txtCuadriculaPT").val(),
                "txtPlanoPT": $("#txtPlanoPT").val(),
                "txtContextoPT": $("#txtContextoPT").val(),
                "txtUbicContextoPT": $("#txtUbicContextoPT").val(),
                "txtAlturaObsPT": $("#txtAlturaObsPT").val(),
                "txtOtrosDatosPT": $("#txtOtrosDatosPT").val(),
                "txtMaterialPT": $("#txtMaterialPT").val(),
                "txtDenominacionPT": $("#txtDenominacionPT").val(),
                "txtDescripcionPT": $("#txtDescripcionPT").val(),
                "txtAltoPT": $("#txtAltoPT").val(),
                "txtLargoPT": $("#txtLargoPT").val(),
                "txtAnchoPT": $("#txtAnchoPT").val(),
                "txtEspesorPT": $("#txtEspesorPT").val(),
                "txtDiamMaxPT": $("#txtDiamMaxPT").val(),
                "txtDiamMinPT": $("#txtDiamMinPT").val(),
                "txtDiamBasePT": $("#txtDiamBasePT").val(),
                "txtPesoPT": $("#txtPesoPT").val(),
                "txtUbicInmueblePT": $("#txtUbicInmueblePT").val(),
                "txtCajaPT": $("#txtCajaPT").val(),
                "txtBolsaPT": $("#txtBolsaPT").val(),
                "txtProblemPT": $("#txtProblemPT").val(),
                "txtVariacPT": $("#txtVariacPT").val(),
                "txtReaccionesPT": $("#txtReaccionesPT").val(),
                "txtPresAfectPT": $("#txtPresAfectPT").val(),
                "txtTipoAfecPT": $("#txtTipoAfecPT").val(),
                "txtCausaAfecPT": $("#txtCausaAfecPT").val(),
                "txtRecomenPT": $("#txtRecomenPT").val(),
                "txtConseCargoPT": $("#txtConseCargoPT").val(),
                "txtFechaPT": $("#txtFechaPT").val()
            },
            dataType: "json",
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarEvaluacionesDGC($("#paramdgc").val());
                tablaEvaluacionesDGC()
                $('.piluku-preloader').addClass('hidden');
            },
            error: function (result) {
                fnMensaje(data[0].alert, data[0].msje);
            }
        });
    }

    function fnCargarAlm(i) {
        var Fila = Carga[i].split(";");
        $('#eval').val(Fila[0]);
        $('#txtAmbMonitoreoA').val(Fila[1]);
        $('#txtAreaA').val(Fila[2]);
        $('#txtTipoEstrA').val(Fila[3]);
        $('#txtVentanasA').val(Fila[4]);
        $('#txtTipoLuzA').val(Fila[5]);
        $('#txtTipoAireA').val(Fila[6]);
        $('#txtCantAireA').val(Fila[7]);
        $('#txtTipoExtA').val(Fila[8]);
        $('#txtCantExtA').val(Fila[9]);
        $('#txtCantThermA').val(Fila[10]);
        $('#txtCantEstA').val(Fila[11]);
        $('#txtNivelEstA').val(Fila[12]);
        $('#ttxCajaPlaA').val(Fila[13]);
        $('#txtCajaCartonA').val(Fila[14]);
        $('#txtCajaMadA').val(Fila[15]);
        $('#txtColeccionA').val(Fila[16]);
        $('#txtMaterialA').val(Fila[17]);
        $('#txtOtrosA').val(Fila[18]);
        $('#txtConservCargoA').val(Fila[19]);
        $('#txtFechaA').val(Fila[20]);
        $('#txtHraIngAA').val(Fila[21]);
        $('#txtHraSalAA').val(Fila[22]);
        $('#txtPriTaCA').val(Fila[23]);
        $('#txtSegTaCA').val(Fila[24]);
        $('#txtHraIngPA').val(Fila[27]);
        $('#txtHraSalPA').val(Fila[28]);
        $('#txtPriTpCA').val(Fila[29]);
        $('#txtSegTpCA').val(Fila[30]);
        $('#txtPriHa').val(Fila[31]);
        $('#txtSegundaHa').val(Fila[32]);
        $('#txtObsA').val(Fila[33]);
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: {
                "param0": "CargaMasivaAlm",
                "paramdgc": $("#paramdgc").val(),
                "eval": $("#eval").val(),
                "txtAmbMonitoreoA": $("#txtAmbMonitoreoA").val(),
                "txtAreaA": $("#txtAreaA").val(),
                "txtTipoEstrA": $("#txtTipoEstrA").val(),
                "txtVentanasA": $("#txtVentanasA").val(),
                "txtTipoLuzA": $("#txtTipoLuzA").val(),
                "txtTipoAireA": $("#txtTipoAireA").val(),
                "txtCantAireA": $("#txtCantAireA").val(),
                "txtTipoExtA": $("#txtTipoExtA").val(),
                "txtCantExtA": $("#txtCantExtA").val(),
                "txtCantThermA": $("#txtCantThermA").val(),
                "txtCantEstA": $("#txtCantEstA").val(),
                "txtNivelEstA": $("#txtNivelEstA").val(),
                "ttxCajaPlaA": $("#ttxCajaPlaA").val(),
                "txtCajaCartonA": $("#txtCajaCartonA").val(),
                "txtCajaMadA": $("#txtCajaMadA").val(),
                "txtColeccionA": $("#txtColeccionA").val(),
                "txtMaterialA": $("#txtMaterialA").val(),
                "txtOtrosA": $("#txtOtrosA").val(),
                "txtConservCargoA": $("#txtConservCargoA").val(),
                "txtFechaA": $("#txtFechaA").val(),
                "txtHraIngAA": $("#txtHraIngAA").val(),
                "txtHraSalAA": $("#txtHraSalAA").val(),
                "txtPriTaCA": $("#txtPriTaCA").val(),
                "txtSegTaCA": $("#txtSegTaCA").val(),
                "txtHraIngPA": $("#txtHraIngPA").val(),
                "txtHraSalPA": $("#txtHraSalPA").val(),
                "txtPriTpCA": $("#txtPriTpCA").val(),
                "txtSegTpCA": $("#txtSegTpCA").val(),
                "txtPrimeraHA": $("#txtPriHa").val(),
                "txtSegundaHa": $("#txtSegundaHa").val(),
                "txtObsA": $("#txtObsA").val()
            },
            dataType: "json",
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarEvaluacionesDGC($("#paramdgc").val());
                tablaEvaluacionesDGC()
                $('.piluku-preloader').addClass('hidden');
            },
            error: function (result) {
                fnMensaje(data[0].alert, data[0].msje);
            }
        });
    }

    //Fin JAZ

    function permisos() {
        if ($("#tfu").val() == "3" ) {
            $("#btnGuardarEval1").hide();
            $("#btnGuardarEval2").hide();
            $("#btnGuardarEval3").hide();
            $("#btnGuardarEval4").hide();
            $("#btnGuardarEval5").hide();
            $("#btnGuardarTrata1").hide();
            $("#btnGuardarTrata2").hide();
            $("#btnGuardarTrata3").hide();
            $("#btnGuardarTrata4").hide();
            $("#btnGuardarTrata5").hide();
            $("#btnGuardarTrata6").hide();
            $("#btnGuardarTrata7").hide();
            $("#btnGuardarPostTrat1").hide();
            $("#btnGuardarPostTrat2").hide();
            $("#btnGuardarPostTrat3").hide();
            $("#btnGuardarPostTrat4").hide();
            $("#btnGuardarAlmac1").hide();
            $("#btnGuardarAlmac2").hide();
            $("#btnGuardarAlmac3").hide();
            $("#btnGuardarAlmac4").hide();
            $("#btnDelReg").hide();
        } else {
            $("#btnGuardarEval1").show();
            $("#btnGuardarEval2").show();
            $("#btnGuardarEval3").show();
            $("#btnGuardarEval4").show();
            $("#btnGuardarEval5").show();
            $("#btnGuardarTrata1").show();
            $("#btnGuardarTrata2").show();
            $("#btnGuardarTrata3").show();
            $("#btnGuardarTrata4").show();
            $("#btnGuardarTrata5").show();
            $("#btnGuardarTrata6").show();
            $("#btnGuardarTrata7").show();
            $("#btnGuardarPostTrat1").show();
            $("#btnGuardarPostTrat2").show();
            $("#btnGuardarPostTrat3").show();
            $("#btnGuardarPostTrat4").show();
            $("#btnGuardarAlmac1").show();
            $("#btnGuardarAlmac2").show();
            $("#btnGuardarAlmac3").show();
            $("#btnGuardarAlmac4").show();
            $("#btnDelReg").show();
        }
    }

    //Inicio JAZ
    function fnBuscarI() {
        if ($('#txtCodPropietarioE').val() == "") {
            fnMensaje("error", "Ingrese Codigo de propietario");
        }
        else {           
            $.ajax({
                //type: "POST",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "lstTbInventarioCP", "param1": $('#txtCodPropietarioE').val(), "param2": $('#paramdgc').val() },
                //data: form,
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {

                    if (data.length > 0) {
                        fnMensaje("success", "Datos encontrados");
                        $('#txtCodRegNacE').val(data[0].registro_nacional);
                        $('#txtCodPropietarioE').val(data[0].codigo_propiet);
                        $('#txtCodigoExcavacionE').val(data[0].otro_codigo);
                        $('#txtSectorE').val(data[0].sector_origen);
                        $('#txtUnidadE').val(data[0].unidad_origen);
                        $('#txtCapaE').val(data[0].capa_origen);
                        $('#txtCuadriculaE').val(data[0].cuadricula_origen);
                        $('#txtMaterialE').val(data[0].tipo_material);
                        $('#txtContextoE').val(data[0].contexto_origen);                        
                        $('#txtDenominacionE').val(data[0].denominacion);
                        $('#txtDescripcionE').val(data[0].descripcion_identificacion);
                        $('#txtAltoE').val(data[0].alto);
                        $('#txtLargoE').val(data[0].largo);
                        $('#txtAnchoE').val(data[0].ancho);
                        $('#txtDiamMaxE').val(data[0].diam_maximo);
                        $('#txtDiamMinE').val(data[0].diam_min);
                        $('#txtPesoE').val(data[0].peso);
                        $('#txtUbicInmuebleE').val(data[0].especifica_ubicacion);
                        $('#txtCajaE').val(data[0].caja_ubicacion);
                        $('#txtBolsaE').val(data[0].bolsa_ubicacion);
                        $('#txtDetConservacionE').val(data[0].detalle_conservacion);
                        $('#txtObservacionE').val(data[0].observacion_adic);
                    } else {

                        fnMensaje("error", "No hay información con ese Codigo de propietario");
                    }
                },
                error: function (result) {
                    console.log(result);
                    $('.piluku-preloader').addClass('hidden');
                }
            });
        }
    }
    //Fin JAZ

    function fnBuscarT() {
        limpiarTra();
        if ($('#txtNroFichaT').val() == "") {
            fnMensaje("error", "Ingrese Nro de Ficha");
        }
        else {
            var cont = tagInput2.arr.length;
            console.log(cont);
            if (cont > 0) {
                $(".tags-input-wrapper").children("span").remove();
                document.getElementById("txtIntervAntT").value = "";
                tagInput2.arr.length = 0;
            }
            var cont2 = tagInput3.arr.length;
            console.log(cont2);
            if (cont2 > 0) {
                $(".tags-input-wrapper").children("span").remove();
                document.getElementById("txtDetTratamientoT").value = "";
                tagInput3.arr.length = 0;
            }
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                //type: "POST",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "lstEvaluacionesDGC", "param1": $('#txtNroFichaT').val(), "param2": $('#paramdgc').val() },
                //data: form,
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {
                   
                    if (data.length > 0) {

                        fnMensaje("success", "Datos encontrados");
                        $('#eval').val(data[0].nroficha_tra);
                        //$("#div_fileIniT").html("<a onclick='fnDownloadSinEnc(\"" + data[0].fotoini_tra + "\")' target='_blank' style='font-weight:bold;color:blue'>Descargar</a>")
                        //Cambiar URL
                        $("#RepPDFT").html('<a href=ReporteConservacionPDF.aspx?CON=' + aData[0].nroficha_con + ' target = "popup" onClick="window.open(this.href, this.target,"width=1000, height=700"); return false;" style = "color:blue" > Ver PDF </a>');
                        $('#txtCodRegNacT').val(data[0].codregnac_con);
                        $('#txtCodPropietarioT').val(data[0].codpropietario_con);
                        $('#txtCodigoExcavacionT').val(data[0].codexcavacion_con);
                        $('#txtCodRestaurT').val(data[0].codrestauracion_con);
                        $('#txtSectorT').val(data[0].sector_con);
                        $('#txtUnidadT').val(data[0].unidad_con);
                        $('#txtCapaT').val(data[0].capa_con);
                        $('#txtNivelT').val(data[0].nivel_con);
                        $('#txtCuadriculaT').val(data[0].cuadricula_con);
                        $('#txtPlanoT').val(data[0].plano_con);
                        $('#txtContextoT').val(data[0].contexto_con);
                        $('#txtUbicContextoT').val(data[0].ubicontexto_con);
                        $('#txtAlturaObsT').val(data[0].alturaobs_con);
                        $('#txtOtrosDatosT').val(data[0].otrosdatos_con);
                        $('#txtMaterialT').val(data[0].material_con);
                        $('#txtDenominacionT').val(data[0].denominacion_con);
                        $('#txtDescripcionT').val(data[0].descripcion_con);
                        $('#txtAltoT').val(data[0].alto_con);
                        $('#txtLargoT').val(data[0].largo_con);
                        $('#txtAnchoT').val(data[0].ancho_con);
                        $('#txtEspesorT').val(data[0].espesor_con);
                        $('#txtDiamMaxT').val(data[0].diametromax_con);
                        $('#txtDiamMinT').val(data[0].diametromin_con);
                        $('#txtDiamBaseT').val(data[0].diametrobase_con);
                        $('#txtPesoIniT').val(data[0].peso_con);
                        $('#txtUbicInmuebleT').val(data[0].ubicinmueble_con);
                        $('#txtCajaT').val(data[0].nrocaja_con);
                        $('#txtBolsaT').val(data[0].nrobolsa_con);
                        $('#cboIntegridadT').val(data[0].integridadbien_con);
                        $('#cboConservacionT').val(data[0].conservacionbien_con);
                        $('#txtDetConservacionT').val(data[0].detconservacion_con);

                    } else {

                        fnMensaje("error", "No hay información con ese Nro de Ficha");
                    }
                },
                error: function (result) {
                    console.log(result);
                    $('.piluku-preloader').addClass('hidden');
                }
            });
            $.ajax({
                //type: "POST",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "lstTratamientoDGC", "param1": $('#txtNroFichaT').val(), "param2": $('#paramdgc').val() },
                //data: form,
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {

                    if (data.length > 0) {
                        $('#txtUbicInmuebleT').val(data[0].ubicinmueble_tra);
                        $('#txtCajaT').val(data[0].nrocaja_tra);
                        $('#txtBolsaT').val(data[0].nrobolsa_tra);
                        $('#cboIntegridadT').val(data[0].integridadbien_tra);
                        $('#cboConservacionT').val(data[0].conservacionbien_tra);
                        $('#txtDetConservacionT').val(data[0].detconservacion_tra);
                        $('#txtIntervAntT').val(data[0].intervenciones_tra);
                        $('#txtFechaIniT').val(data[0].fini_tra);
                        $('#txtFechFinT').val(data[0].ffin_tra);
                        
                        const Listado = data[0].intervenciones_tra.split(",");
                        tagInput2.addData(Listado);
                        const Listado2 = data[0].dettratamiento_tra.split(",");
                        tagInput3.addData(Listado2);
                    } else {

                        fnMensaje("error", "No hay información con ese Nro de Ficha");
                    }
                },
                error: function (result) {
                    console.log(result);
                    $('.piluku-preloader').addClass('hidden');
                }
            });

        }
       
    }

    function fnBuscarPT() {
        limpiarPT();
        if ($('#txtNroFichaPT').val() == "") {
            fnMensaje("error", "Ingrese Nro de Ficha");
        }
        else {

            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                //type: "POST",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "lstEvaluacionesDGC", "param1": $('#txtNroFichaPT').val(), "param2": $('#paramdgc').val() },
                //data: form,
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {
                    if (data.length > 0) {
                        fnMensaje("success", "Datos encontrados");
                        $("#RepPDFPT").html('<a href=ReporteConservacionPDF.aspx?CON=' + aData[0].nroficha_con + ' target = "popup" onClick="window.open(this.href, this.target,"width=1000, height=700"); return false;" style = "color:blue" > Ver PDF </a>');
                        $('#txtCodRegNacPT').val(data[0].codregnac_con);
                        $('#txtCodPropietarioPT').val(data[0].codpropietario_con);
                        $('#txtCodigoExcavacionPT').val(data[0].codexcavacion_con);
                        $('#txtCodRestaurPT').val(data[0].codrestauracion_con);
                        $('#txtSectorPT').val(data[0].sector_con);
                        $('#txtUnidadPT').val(data[0].unidad_con);
                        $('#txtCapaPT').val(data[0].capa_con);
                        $('#txtNivelPT').val(data[0].nivel_con);
                        $('#txtCuadriculaPT').val(data[0].cuadricula_con);
                        $('#txtPlanoPT').val(data[0].plano_con);
                        $('#txtContextoPT').val(data[0].contexto_con);
                        $('#txtUbicContextoPT').val(data[0].ubicontexto_con);
                        $('#txtAlturaObsPT').val(data[0].alturaobs_con);
                        $('#txtOtrosDatosPT').val(data[0].otrosdatos_con);
                        $('#txtMaterialPT').val(data[0].material_con);
                        $('#txtDenominacionPT').val(data[0].denominacion_con);
                        $('#txtDescripcionPT').val(data[0].descripcion_con);
                        $('#txtAltoPT').val(data[0].alto_con);
                        $('#txtLargoPT').val(data[0].largo_con);
                        $('#txtAnchoPT').val(data[0].ancho_con);
                        $('#txtEspesorPT').val(data[0].espesor_con);
                        $('#txtDiamMaxPT').val(data[0].diametromax_con);
                        $('#txtDiamMinPT').val(data[0].diametromin_con);
                        $('#txtDiamBasePT').val(data[0].diametrobase_con);
                        $('#txtPesoPT').val(data[0].peso_con);
                        $('#txtUbicInmueblePT').val(data[0].ubicinmueble_con);
                        $('#txtCajaPT').val(data[0].nrocaja_con);
                        $('#txtBolsaPT').val(data[0].nrobolsa_con);
                    } else {
                        fnMensaje("error", "No hay información con ese Nro de Ficha");
                    }
                },
                error: function (result) {
                    console.log(result);
                    $('.piluku-preloader').addClass('hidden');
                }
            });
            $.ajax({
                //type: "POST",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "listaPostTratemientos", "param1": $('#txtNroFichaPT').val(), "param2": $('#paramdgc').val() },
                //data: form,
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {
                    if (data.length > 0) {
                        $('#txtUbicInmueblePT').val(data[0].ubicinmueble_ptr);
                        $('#txtCajaPT').val(data[0].nrocaja_ptr);
                        $('#txtBolsaPT').val(data[0].nrobolsa_ptr);
                        $('#txtProblemPT').val(data[0].problematica_ptr);
                        $('#txtVariacPT').val(data[0].varicacion_ptr);
                        $('#txtReaccionesPT').val(data[0].reacciones_ptr);
                        $('#txtPresAfectPT').val(data[0].presentaafec_ptr);
                        $('#txtTipoAfecPT').val(data[0].tipoafec_ptr);
                        $('#txtCausaAfecPT').val(data[0].causaafec_ptr);
                        $('#txtRecomenPT').val(data[0].recomendaciones_ptr);
                        $('#txtConseCargoPT').val(data[0].conservadorcargo_ptr);
                        $('#txtFechaPT').val(data[0].fecha_ptr);
                    } else {
                        fnMensaje("error", "No hay información con ese Nro de Ficha");
                    }
                },
                error: function (result) {
                    console.log(result);
                    $('.piluku-preloader').addClass('hidden');
                }
            });
        }
    }

    function fnBuscarA() {
        limpiarA();
        if ($('#txtNroFichaA').val() == "") {
            fnMensaje("error", "Ingrese Nro de Ficha");
        }
        else {

            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                //type: "POST",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "listaAlmacenes", "param1": $('#txtNroFichaA').val(), "param2": $('#paramdgc').val() },
                //data: form,
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {
                    if (data.length > 0) {
                        fnMensaje("success", "Datos encontrados");
                        $('#eval').val(data[0].nroficha_alm);
                        $('#txtNroFichaA').val(data[0].nroficha_alm);
                        $('#txtAmbMonitoreoA').val(data[0].ambmonitoreo_alm);
                        $('#txtAreaA').val(data[0].area_alm);
                        $('#txtTipoEstrA').val(data[0].tipoestruct_alm);
                        $('#txtVentanasA').val(data[0].ventanas_alm);
                        $('#txtTipoLuzA').val(data[0].tipoluz_alm);
                        $('#txtTipoAireA').val(data[0].tipoaa_alm);
                        $('#txtCantAireA').val(data[0].cantidadaa_alm);
                        $('#txtTipoExtA').val(data[0].tipoex_alm);
                        $('#txtCantExtA').val(data[0].cantidadex_alm);
                        $('#txtCantThermA').val(data[0].cantthermo_alm);
                        $('#txtCantEstA').val(data[0].cantestantes_alm);
                        $('#txtNivelEstA').val(data[0].nivelesestantes_alm);
                        $('#ttxCajaPlaA').val(data[0].cajasplast_alm);
                        $('#txtCajaCartonA').val(data[0].cajascarton_alm);
                        $('#txtCajaMadA').val(data[0].cajasmadera_alm);
                        $('#txtColeccionA').val(data[0].coleccion_alm);
                        $('#txtMaterialA').val(data[0].material_alm);
                        $('#txtOtrosA').val(data[0].otros_alm);
                        $('#txtConservCargoA').val(data[0].conservadorcargo_alm);
                        $('#txtFechaA').val(data[0].fechamonit_alm);
                        $('#txtHraIngAA').val(data[0].hringresoa_alm);
                        $('#txtHraSalAA').val(data[0].hrsalidaa_alm);
                        $('#txtPriTaCA').val(data[0].primeraTa_alm);
                        $('#txtSegTaCA').val(data[0].segundaTa_alm);
                        $('#txtHraIngPA').val(data[0].primeraHa_alm);
                        $('#txtHraSalPA').val(data[0].segundaHa_alm);
                        $('#txtPriTpCA').val(data[0].primeraTp_alm);
                        $('#txtSegTpCA').val(data[0].segundaTp_alm);
                        $('#txtPrimeraHA').val(data[0].primeraHp_alm);
                        $('#txtSegundaHA').val(data[0].segundaHp_alm);
                        $('#txtObsA').val(data[0].observaciones_alm);

                    } else {
                        fnMensaje("error", "No hay información con ese Nro de Ficha");
                    }
                },
                error: function (result) {
                    console.log(result);
                    $('.piluku-preloader').addClass('hidden');
                }
            });
        }
    }

    function limpiarEval() {
        $('#eval').val("");
        $('#txtNroFichaE').val("");
        $('#txtCodRegNacE').val("");
        $('#txtCodPropietarioE').val("");
        $('#txtCodigoExcavacionE').val("");
        $('#txtCodRestaurE').val("");
        $('#txtSectorE').val("");
        $('#txtUnidadE').val("");
        $('#txtCapaE').val("");
        $('#txtNivelE').val("");
        $('#txtCuadriculaE').val("");
        $('#txtPlanoE').val("");
        $('#txtContextoE').val("");
        $('#txtUbicContextoE').val("");
        $('#txtAlturaObsE').val("");
        $('#txtOtrosDatosE').val("");
        $('#txtMaterialE').val("");
        $('#txtDenominacionE').val("");
        $('#txtDescripcionE').val("");
        $('#txtAltoE').val("");
        $('#txtLargoE').val("");
        $('#txtAnchoE').val("");
        $('#txtEspesorE').val("");
        $('#txtDiamMaxE').val("");
        $('#txtDiamMinE').val("");
        $('#txtDiamBaseE').val("");
        $('#txtPesoE').val("");
        $('#txtUbicInmuebleE').val("");
        $('#txtCajaE').val("");
        $('#txtBolsaE').val("");
        $('#cboIntegridadE').val(0);
        $('#cboConservacionE').val(0);
        $('#txtDetConservacionE').val("");
        $('#txtIntervencionE').val("");
        $('#txtAfectacionE').val("");
        $('#txtTratamiento').val("");
        $('#txtLimpieza').val("");
        $('#txtObservacionE').val("");
        $('#txtTemperaturaE').val("");
        $('#txtHumedad').val("");
        $('#txtMinipulacionE').val("");
        $('#txtOtrosE').val("");
        $('#txtConsCargoE').val("");
        $('#txtFechaE').val("");
    }

    function limpiarTra() {
        $('#eval').val("");
        $('#RepPDFT').html("");
        $('#txtCodRegNacT').val("");
        $('#txtCodPropietarioT').val("");
        $('#txtCodigoExcavacionT').val("");
        $('#txtCodRestaurT').val("");
        $('#txtSectorT').val("");
        $('#txtUnidadT').val("");
        $('#txtCapaT').val("");
        $('#txtNivelT').val("");
        $('#txtCuadriculaT').val("");
        $('#txtPlanoT').val("");
        $('#txtContextoT').val("");
        $('#txtUbicContextoT').val("");
        $('#txtAlturaObsT').val("");
        $('#txtOtrosDatosT').val("");
        $('#txtMaterialT').val("");
        $('#txtDenominacionT').val("");
        $('#txtDescripcionT').val("");
        $('#txtLargoT').val("");
        $('#txtAltoT').val("");
        $('#txtAnchoT').val("");
        $('#txtEspesorT').val("");
        $('#txtDiamMaxT').val("");
        $('#txtDiamMinT').val("");
        $('#txtDiamBaseT').val("");
        $('#txtPesoIniT').val("");
        $('#txtPesoFinT').val("");
        $('#txtUbicInmuebleT').val("");
        $('#txtCajaT').val("");
        $('#txtBolsaT').val("");
        $('#cboIntegridadT').val(0);
        $('#cboConservacionT').val(0);
        $('#txtDetConservacionT').val("");
        $('#txtIntervencionT').val("");
        $('#txtIntervAntT').val("");
        $('#txtFechaIniT').val("");
        $('#txtFechFinT').val("");
        $('#txtMecanicaT').val("");
        $('#txtQuimicaT').val("");
        $('#txtFechaIniLimT').val("");
        $('#txtFechFinLimT').val("");
        $('#txtIntervenitoT').val(0);
        $('#txtDetTratamientoT').val("");
        $('#txtInhibicionT').val("");
        $('#txtEstabilizacionT').val("");
        $('#txtDesalacionT').val("");
        $('#txtNeutralizacT').val("");
        $('#txtOtrosTratT').val("");
        $('#txtFiniTratT').val("");
        $('#txtFfinTratT').val("");
        $('#txtSecadoT').val("");
        $('#txtPegadoT2').val("");
        $('#txtConsolidacionT').val("");
        $('#txtReIntegracT').val("");
        $('#txtOtrosPostT').val("");
        $('#txtFechaIniProcT').val("");
        $('#txtFechaFinProcT').val("");
        $('#txtTemperaturaT').val("");
        $('#txtHumedadT').val("");
        $('#txtManipulacionT').val("");
        $('#txtIluminacionT').val("");
        $('#txtOtrosRecT').val("");
        $('#txtMaterialRecomendT').val("");
        $('#txtObservacionesT').val("");
        $('#txtConservCargoT').val("");
        $('#txtFechaT').val("");
        $('#txtFotoIniT').val("");
        $('#txtFotoFinT').val("");
        $('#txtDetalleT').val("");

    }

    function limpiarPT() {
        $('#eval').val("");
        $('#RepPDFPT').html("");
        $('#txtCodRegNacPT').val("");
        $('#txtCodPropietarioPT').val("");
        $('#txtCodigoExcavacionPT').val("");
        $('#txtCodRestaurPT').val("");
        $('#txtSectorPT').val("");
        $('#txtUnidadPT').val("");
        $('#txtCapaPT').val("");
        $('#txtNivelPT').val("");
        $('#txtCuadriculaPT').val("");
        $('#txtPlanoPT').val("");
        $('#txtContextoPT').val("");
        $('#txtUbicContextoPT').val("");
        $('#txtAlturaObsPT').val("");
        $('#txtOtrosDatosPT').val("");
        $('#txtMaterialPT').val("");
        $('#txtDenominacionPT').val("");
        $('#txtDescripcionPT').val("");
        $('#txtAltoPT').val("");
        $('#txtLargoPT').val("");
        $('#txtAnchoPT').val("");
        $('#txtEspesorPT').val("");
        $('#txtDiamMaxPT').val("");
        $('#txtDiamMinPT').val("");
        $('#txtDiamBasePT').val("");
        $('#txtPesoPT').val("");
        $('#txtUbicInmueblePT').val("");
        $('#txtCajaPT').val("");
        $('#txtBolsaPT').val("");
        $('#txtProblemPT').val("");
        $('#txtVariacPT').val("");
        $('#txtReaccionesPT').val("");
        $('#txtPresAfectPT').val(0);
        $('#txtTipoAfecPT').val("");
        $('#txtCausaAfecPT').val("");
        $('#txtRecomenPT').val("");
        $('#txtConseCargoPT').val("");
        $('#txtFechaPT').val("");

    }

    function limpiarA() {
        $('#eval').val("");
        $('#txtAmbMonitoreoA').val("");
        $('#txtAreaA').val("");
        $('#txtTipoEstrA').val("");
        $('#txtVentanasA').val("");
        $('#txtTipoLuzA').val("");
        $('#txtTipoAireA').val("");
        $('#txtCantAireA').val("");
        $('#txtTipoExtA').val("");
        $('#txtCantExtA').val("");
        $('#txtCantThermA').val("");
        $('#txtCantEstA').val("");
        $('#txtNivelEstA').val("");
        $('#ttxCajaPlaA').val("");
        $('#txtCajaCartonA').val("");
        $('#txtCajaMadA').val("");
        $('#txtColeccionA').val("");
        $('#txtMaterialA').val("");
        $('#txtOtrosA').val("");
        $('#txtConservCargoA').val("");
        $('#txtFechaA').val("");
        $('#txtHraIngAA').val("");
        $('#txtHraSalAA').val("");
        $('#txtPriTaCA').val("");
        $('#txtSegTaCA').val("");
        $('#txtHraIngPA').val("");
        $('#txtHraSalPA').val("");
        $('#txtPriTpCA').val("");
        $('#txtSegTpCA').val("");
        $('#txtPrimeraHA').val("");
        $('#txtSegundaHA').val("");
        $('#txtObsA').val("");

    }

    function fnCargaLista(param) {
        try {
            var arr;
            //alert(param);
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": param, "param1": $('#paramdgc').val() },
                async: false,
                cache: false,
                success: function (data) {
                    //console.log(data);
                   
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

    function AsignarEval()
    {
        //$('#eval').val($('#txtNroFichaT').val());
        //alert($('#eval').val());
    }
    function AsignarEvalPT() {
        //$('#eval').val($('#txtNroFichaPT').val());
        //alert($('#eval').val());
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

    function limpiaEval() {
        $('#eval').val("");
        $('#txtCodRegNac').val("");
        $('#txtCodPropietario').val("");
        $('#txtCodigoExcavacion').val("");
        $('#txtCodRestaur').val("");
        $('#txtInvINVC').val("");
        $('#txtOtrosCod').val("");


        $('#cat').val("");
        $('#txtCodRegNac').val("");
        $('#txtCodPropietario').val("");
        $('#txtCodigoExcavacion').val("");
        $('#txtCodRestaur').val("");
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
            if (aData[i].codigo == c) {
                j = i;
                return j;
            }
        }
    }

    function fnEditar(c) {
        //alert(c);
        var x = fnBuscar(c);
        if (x >= 0) {
            var cont = tagInput.arr.length;
            console.log(cont);
            if (cont > 0) {
                $(".tags-input-wrapper").children("span").remove();
                document.getElementById("txtDetConservacionE").value = "";
                tagInput.arr.length = 0;
            }
            $('#eval').val(aData[x].nroficha_con);
            $('#txtNroFichaE').val(aData[x].nroficha_con);
            $('#txtCodRegNacE').val(aData[x].codregnac_con);
            $('#txtCodPropietarioE').val(aData[x].codpropietario_con);
            $('#txtCodigoExcavacionE').val(aData[x].codexcavacion_con);
            $('#txtCodRestaurE').val(aData[x].codrestauracion_con);
            $('#txtSectorE').val(aData[x].sector_con);
            $('#txtUnidadE').val(aData[x].unidad_con);

            $('#txtCapaE').val(aData[x].capa_con);
            $('#txtNivelE').val(aData[x].nivel_con);
            $('#txtCuadriculaE').val(aData[x].cuadricula_con);
            $('#txtPlanoE').val(aData[x].plano_con);
            $('#txtContextoE').val(aData[x].contexto_con);
            $('#txtUbicContextoE').val(aData[x].ubicontexto_con);
            $('#txtAlturaObsE').val(aData[x].alturaobs_con);
            $('#txtOtrosDatosE').val(aData[x].otrosdatos_con);
            $('#txtMaterialE').val(aData[x].material_con);
            $('#txtDenominacionE').val(aData[x].denominacion_con);
            $('#txtDescripcionE').val(aData[x].descripcion_con);
            $('#txtAltoE').val(aData[x].alto_con);
            $('#txtLargoE').val(aData[x].largo_con);
            $('#txtAnchoE').val(aData[x].ancho_con);
            $('#txtEspesorE').val(aData[x].espesor_con);
            $('#txtDiamMaxE').val(aData[x].diametromax_con);
            $('#txtDiamMinE').val(aData[x].diametromin_con);
            $('#txtDiamBaseE').val(aData[x].diametrobase_con);
            $('#txtPesoE').val(aData[x].peso_con);
            $('#txtUbicInmuebleE').val(aData[x].ubicinmueble_con);
            $('#txtCajaE').val(aData[x].nrocaja_con);
            $('#txtBolsaE').val(aData[x].nrobolsa_con);

            if (aData[x].integridadbien_con == "") {
                $('#cboIntegridadE').val(0);
            }
            else {
                $('#cboIntegridadE').val(aData[x].integridadbien_con);
            }
            if (aData[x].conservacionbien_con == "") {
                $('#cboConservacionE').val(0);
            }
            else {
                $('#cboConservacionE').val(aData[x].conservacionbien_con);
            }
           
            $('#txtDetConservacionE').val(aData[x].detconservacion_con);
            //Carga de Tags
            const Listado = aData[x].detconservacion_con.split(",");
            tagInput.addData(Listado);
            //Fin Carga de Tags
            
            $('#txtIntervencionE').val(aData[x].intervenciones_con);
            $('#txtAfectacionE').val(aData[x].afectacion_con);
            $('#txtTratamiento').val(aData[x].tratamiento_con);
            $('#txtLimpieza').val(aData[x].limpieza_con);


            $('#txtObservacionE').val(aData[x].observaciones_con);
            $('#txtTemperaturaE').val(aData[x].temperatura_con);
            $('#txtHumedad').val(aData[x].humedad_con);
            $('#txtMinipulacionE').val(aData[x].manipulacion_con);
            $('#txtOtrosE').val(aData[x].otros_con);
            $('#txtConsCargoE').val(aData[x].conservadorcargo_con);
            $('#txtFechaE').val(aData[x].fecha_con);

            if (aData[x].foto_con != "") {
                $("#divFrontalE").html("<a onclick='fnDownload(\"" + aData[x].foto_con + "\")' target='_blank' style='font-weight:bold;color:blue'>Descargar</a>")
            } else {
                $("#divFrontalE").html("");
            }

        }
        $('div#mdConfirmarEvaluacion').modal('show');
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


    function fnDownloadSinEnc(id_ar) {
        var flag = false;
        var form = new FormData();
        form.append("param0", "DownloadSinEnc");
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
        $("input#param0").val("DelConservacion");
        var form = $('#frmEvaluacion').serialize();
        $.ajax({
            //Inicio JAZ
            //type: "POST",
            //url: "processmuseo.aspx",
            //data: form,
            //dataType: "json",
            //cache: false,
            //async: false,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "DelEvaluacion", "param1": $("#param1").val(), "param2": $('#paramdgc').val() },
            dataType: "json",
            //Fin JAZ
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarEvaluacionesDGC($("#paramdgc").val());
                tablaEvaluacionesDGC();
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
            data: { "param0": "lst", "param1": param1 },
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

    function listarEvaluacionesDGC(val) {
 
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstEvaluacionesDGC", "param1": 0, "param2": val },
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

    function tablaEvaluacionesDGC() {
        var tb = '';
        var i = 0;
        var mostrar = '';
        var contador = 0;
        var tipo_sexo = '';
        if (aData.length > 0) {
            for (i = 0; i < aData.length; i++) {
                //console.log(aData);
                contador = contador + 1;
                tb += '<tr>';
                tb += '<td>';
                tb += '<center><a href="#" class="btn btn-green btn-xs" onclick="fnEditar(\'' + aData[i].codigo + '\')" ><i class="ion-edit"></i></a>';
                tb += '<a href="#" class="btn btn-red btn-xs" onclick="fnBorrarG(\'' + aData[i].codigo + '\',\'' + aData[i].codpropietario_con + '\')" ><i class="ion-android-cancel"></i></a></td>';
                tb += '</center></td>';
                //tb += '<td style="text-align:center">' + aData[i].codpropietario_con + '</td>';
                //tb += '<td style="text-align:center">' + '<a href=RepConservacionPDF.aspx?CON=' + aData[i].codpropietario + '&DGC=' + $("#paramdgc").val() + ' target="popup" onClick="window.open(this.href, this.target,"width=1000,height=700"); return false;" style="color:blue">' + aData[i].codpropietario_con + "</a>" + '</td>';
                tb += '<td style="text-align:center">' + '<a href=ReporteConservacionPDF.aspx?CON=' + aData[i].nroficha_con + '&DGC=' + $("#paramdgc").val() + ' target="popup" onClick="window.open(this.href, this.target,"width=1000,height=700"); return false;" style="color:blue">' + aData[i].codpropietario_con + "</a>" + '</td>';
                tb += '<td style="text-align:center">' + aData[i].denominacion_con + '</td>';
                tb += '<td style="text-align:center">' + aData[i].codexcavacion_con + '</td>';
                tb += '<td style="text-align:center">' + aData[i].material_con + '</td>';
                if (aData[i].foto_con == "" || aData[i].foto_con == "0") {
                    tb += '<td style="text-align:center"> <img id="' + (i + 1) + '" name="' + (i + 1) + '" style="width:50px;height:50px;" src="assets/images/no-image.png" /> </td>';
                } else {
                    tb += '<td style="text-align:center"> <img id="' + (i + 1) + '" name="' + (i + 1) + '" style="width:50px;height:50px;" src="" /> </td>';
                    fnMostrarImagen(aData[i].foto_con, i + 1);
                }
                tb += '</tr>';
            }
        } else {
            tb = "";
        }
        fnDestroyDataTableDetalle('tbEvaluacion');
        $('#pEvaluacion').html(tb);
        fnResetDataTableTramite('tbEvaluacion', 0, 'asc');
    }

    function fnGuardarEval1() {
        var sw = 0;
        var mensaje = "";
        if ($("#txtCodigoExcavacionE").val() == "") {
            mensaje = "Codigo de Excavación"
            sw = 1;
        }
        if ($("#txtCodPropietarioE").val() == "") {
            mensaje = "Codigo de Propietario"
            sw = 1;
        }
        if ($("#txtNroFichaE").val() == "") {
            mensaje = "Ingrese Nro Ficha"
            sw = 1;
        } else {
            if ($("#txtNroFichaE").val() > 999999) {
                mensaje = "Nro Ficha debe ser menor a 999999";
                $("#txtNroFichaE").select();
                sw = 1;
            }
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gEvaluacion1");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                //type: "POST",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "gEvaluacion1", "txtNroFichaE": $("#txtNroFichaE").val(), "txtCodRegNacE": $("#txtCodRegNacE").val(), "txtCodPropietarioE": $("#txtCodPropietarioE").val(), "txtCodigoExcavacionE": $("#txtCodigoExcavacionE").val(), "txtCodRestaurE": $("#txtCodRestaurE").val(), "paramdgc": $("#paramdgc").val(), "eval": $("#eval").val() },
                //data: form,
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje("success", data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarEval2() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());
        //if ($("#txtPlano").val() > 6000) {
        //    mensaje = "Plano debe ser menor a 6000";
        //    $("#txtPlano").select();
        //    sw = 1;
        //}
        //if ($("#txtCuadricula").val() > 6000) {
        //    mensaje = "Cuadricula debe ser menor a 6000";
        //    $("#txtCuadricula").select();
        //    sw = 1;
        //}
        ////if ($("#txtNivel").val() > 6000) {
        ////    mensaje = "Nivel debe ser menor a 6000";
        ////    $("#txtNivel").select();
        ////    sw = 1;
        ////}
        //if ($("#cboExcavacion").val() == "0") {
        //    mensaje = "Seleccione Excavación"
        //    sw = 1;
        //}
        //if ($("#cboMargen").val() == "0") {
        //    mensaje = "Seleccione Margen"
        //    sw = 1;
        //}
        //if ($("#txtValle").val() == "") {
        //    mensaje = "Ingrese Valle"
        //    sw = 1;
        //}
        //if ($("#txtRegion").val() == "") {
        //    mensaje = "Seleccione Región"
        //    sw = 1;
        //}
        //if ($("#txtNombreClasif").val() == "") {
        //    mensaje = "Ingrese Nombre Clasificación"
        //    sw = 1;
        //}
        //if ($("#cboGeografica").val() == "0") {
        //    mensaje = "Seleccione Área Geográfica"
        //    sw = 1;
        //}
        //if ($("#cboCronologia").val() == "0") {
        //    mensaje = "Seleccione Cronologia"
        //    sw = 1;
        //}
        //if ($("#cboPeriodo").val() == "0") {
        //    mensaje = "Seleccione Periodo"
        //    sw = 1;
        //}
        //if ($("#txtEstilo").val() == "") {
        //    mensaje = "Ingrese Estilo"
        //    sw = 1;
        //}
        //if ($("#txtCultura").val() == "") {
        //    mensaje = "Ingrese Culturas"
        //    sw = 1;
        //}
        if ($("#eval").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabExcavacion"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gEvaluacion2");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gEvaluacion2", "eval": $("#eval").val(), "txtSectorE": $("#txtSectorE").val(), "txtUnidadE": $("#txtUnidadE").val(), "txtCapaE": $("#txtCapaE").val(), "txtNivelE": $("#txtNivelE").val(), "txtCuadriculaE": $("#txtCuadriculaE").val(), "txtPlanoE": $("#txtPlanoE").val(), "txtContextoE": $("#txtContextoE").val(), "txtUbicContextoE": $("#txtUbicContextoE").val(), "txtAlturaObsE": $("#txtAlturaObsE").val(), "txtOtrosDatosE": $("#txtOtrosDatosE").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarEval3() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());
        if ($("#txtAltoE").val() == "") {
            $("#txtAltoE").val(0);
        } else {
            if ($("#txtAltoE").val() > 999999) {
                mensaje = "Alto debe ser menor a 999999";
                $("#txtAltoE").select();
                sw = 1;
            }
        }
        if ($("#txtLargoE").val() == "") {
            $("#txtLargoE").val(0);
        } else { 
            if ($("#txtLargoE").val() > 999999) {
                mensaje = "Largo debe ser menor a 999999";
            $("#txtLargoE").select();
            sw = 1;
            }
        }
        if ($("#txtAnchoE").val() == "") {
            $("#txtAnchoE").val(0);
        } else {
            if ($("#txtAnchoE").val() > 999999) {
                mensaje = "Ancho debe ser menor a 999999";
                $("#txtAnchoE").select();
                sw = 1;
            }
        }
        if ($("#txtEspesorE").val() == "") {
            $("#txtEspesorE").val(0);
        } else {
            if ($("#txtEspesorE").val() > 999999) {
                mensaje = "Espesor debe ser menor a 999999";
                $("#txtEspesorE").select();
                sw = 1;
            }
        }
        if ($("#txtDiamBaseE").val() == "") {
            $("#txtDiamBaseE").val(0);
        } else {
            if ($("#txtDiamBaseE").val() > 999999) {
                mensaje = "Diámetro Base debe ser menor a 999999";
                $("#txtDiamBaseE").select();
                sw = 1;
            }
        }
        if ($("#txtDiamMaxE").val() == "") {
            $("#txtDiamMaxE").val(0);
        } else {
            if ($("#txtDiamMaxE").val() > 999999) {
                mensaje = "Diámetro Maximo debe ser menor a 999999";
                $("#txtDiamMaxE").select();
                sw = 1;
            }
        }
        if ($("#txtDiamMinE").val() == "") {
            $("#txtDiamMinE").val(0);
        } else {
            if ($("#txtDiamMinE").val() > 999999) {
                mensaje = "Diámetro Minimo debe ser menor a 999999";
                $("#txtDiamMinE").select();
                sw = 1;
            }
        }
        if ($("#txtLargoE").val() == "") {
            $("#txtLargoE").val(0);
        } else {
            if ($("#txtDiamBaseE").val() > 999999) {
                mensaje = "Diámetro Base debe ser menor a 999999";
                $("#txtDiamBaseE").select();
                sw = 1;
            }
        }
        if ($("#txtPesoE").val() == "") {
            mensaje = "Ingrese Peso"
            sw = 1;
        } else {
            if ($("#txtPesoE").val() > 999999) {
                mensaje = "Peso debe ser menor a 999999";
                $("#txtPesoE").select();
                sw = 1;
            }
        }

        if ($("#txtMaterialE").val() == "") {
            mensaje = "Ingrese Material"
            sw = 1;
        }
        if ($("#txtDenominacionE").val() == "") {
            mensaje = "Seleccione Denominacion"
            sw = 1;
        }
        if ($("#txtDescripcionE").val() == "") {
            mensaje = "Ingrese Descripcion"
            sw = 1;
        }

        if ($("#cat").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabFisicaDimensaionesE"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gEvaluacion3");
            //var form = $('#frmEvaluacion').serialize();
            //alert("a");
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gEvaluacion3", "eval": $("#eval").val(), "txtMaterialE": $("#txtMaterialE").val(), "txtDenominacionE": $("#txtDenominacionE").val(), "txtDescripcionE": $("#txtDescripcionE").val(), "txtAltoE": $("#txtAltoE").val(), "txtLargoE": $("#txtLargoE").val(), "txtAnchoE": $("#txtAnchoE").val(), "txtEspesorE": $("#txtEspesorE").val(), "txtDiamMaxE": $("#txtDiamMaxE").val(), "txtDiamMinE": $("#txtDiamMinE").val(), "txtDiamBaseE": $("#txtDiamBaseE").val(), "txtPesoE": $("#txtPesoE").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarEval4() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());

        if ($("#txtUbicInmuebleE").val() == "") {
            mensaje = "Ingrese ubicacion del inmueble"
            sw = 1;
        }
        if ($("#txtCajaE").val() == "") {
            mensaje = "Ingrese Caja"
            sw = 1;
        }
        if ($("#txtBolsaE").val() == "") {
            mensaje = "Ingrese Bolsa"
            sw = 1;
        }
        if ($("#cboIntegridadE").val() == "0") {
            mensaje = "Seleccione Integridad"
            sw = 1;
        }
        if ($("#cboConservacionE").val() == "0") {
            mensaje = "Seleccione Conselvacion"
            sw = 1;
        }

        if ($("#txtDetConservacionE").val() == "") {
            mensaje = "Ingrese detalle de conservacion"
            sw = 1;
        }
        if ($("#txtAfectacionE").val() == "") {
            mensaje = "Ingrese afectaciones"
            sw = 1;
        }
        if ($("#txtIntervencionE").val() == "") {
            mensaje = "Ingrese intervenciones"
            sw = 1;
        }
        if ($("#txtTratamiento").val() == "") {
            mensaje = "Ingrese tratamiento"
            sw = 1;
        }
        if ($("#txtLimpieza").val() == "") {
            mensaje = "Ingrese limpieza"
            sw = 1;
        }
        if ($("#eval").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabUbicacionActualE"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gEvaluacion4");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gEvaluacion4", "eval": $("#eval").val(), "txtUbicInmuebleE": $("#txtUbicInmuebleE").val(), "txtCajaE": $("#txtCajaE").val(), "txtBolsaE": $("#txtBolsaE").val(), "cboIntegridadE": $("#cboIntegridadE").val(), "cboConservacionE": $("#cboConservacionE").val(), "txtDetConservacionE": $("#txtDetConservacionE").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarEval5() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());
        if ($("#file_frontalE").val() == "") {
            mensaje = "Seleccione imagen frontal"
            sw = 1;
        }
        if ($("#txtTemperaturaE").val() == "") {
            mensaje = "Ingrese temperatura"
            sw = 1;
        } else {
            if ($("#txtTemperaturaE").val() > 999999) {
                mensaje = "temperatura debe ser menor a 999999";
                $("#txtTemperaturaE").select();
                sw = 1;
            }
        }
        if ($("#txtHumedad").val() == "") {
            mensaje = "Ingrese humedad"
            sw = 1;
        } 
        //else {
        //    if ($("#txtHumedad").val() > 999999) {
        //        mensaje = "temperatura debe ser menor a 999999";
        //        $("#txtHumedad").select();
        //        sw = 1;
        //    }
        //}
        if ($("#txtMinipulacionE").val() == "") {
            mensaje = "Ingrese manipulacion"
            sw = 1;
        }
        if ($("#txtConsCargoE").val() == "") {
            mensaje = "Ingrese conservador a cargo"
            sw = 1;
        }
        if ($("#txtFechaE").val() == "") {
            mensaje = "Ingrese fecha"
            sw = 1;
        }

        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabDatosRegE"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gEvaluacion5");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gEvaluacion5", "eval": $("#eval").val(), "txtObservacionE": $("#txtObservacionE").val(), "txtTemperaturaE": $("#txtTemperaturaE").val(), "txtHumedadE": $("#txtHumedad").val(), "txtMinipulacionE": $("#txtMinipulacionE").val(), "txtOtrosE": $("#txtOtrosE").val(), "txtConsCargoE": $("#txtConsCargoE").val(), "txtFechaE": $("#txtFechaE").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        if ($("#file_frontalE").val() != "") {
                            SubirArchivo($("#txtNroFichaE").val(), "FRONTALE");
                            swvalida = 1;
                        }
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarTrat1() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());

        if ($("#txtNroFichaT").val() == "") {
            mensaje = "Ingrese numero de ficha"
            sw = 1;
        } else {
            if ($("#txtNroFichaT").val() > 999999) {
                mensaje = "Numero de ficha debe ser menor a 999999";
                $("#txtNroFichaT").select();
                sw = 1;
            }
        }
        if ($("#txtCodRegNacT").val() == "") {
            mensaje = "Ingrese codigo de registro nacional"
            sw = 1;
        } else {
            if ($("#txtCodRegNacT").val() > 999999) {
                mensaje = "Codigo de registro nacional debe ser menor a 999999";
                $("#txtCodRegNacT").select();
                sw = 1;
            }
        }
        if ($("#txtCodPropietarioT").val() == "") {
            mensaje = "Ingrese codigo de propietario"
            sw = 1;
        }
        if ($("#txtCodigoExcavacionT").val() == "") {
            mensaje = "Ingrese codigo de excavacion"
            sw = 1;
        }
        if ($("#txtCodRestaurT").val() == "") {
            mensaje = "Ingrese codigo de restauracion"
            sw = 1;
        }

        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionT"]').tab('show')
            } 
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamiento1");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gTratamiento1", "eval": $("#txtNroFichaT").val(), "txtNroFichaT": $("#txtNroFichaT").val(), "txtCodRegNacT": $("#txtCodRegNacT").val(), "txtCodPropietarioT": $("#txtCodPropietarioT").val(), "txtCodigoExcavacionT": $("#txtCodigoExcavacionT").val(), "txtCodRestaurT": $("#txtCodRestaurT").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarTrat2() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
   
        //if ($("#txtCultura").val() == "") {
        //    mensaje = "Ingrese Culturas"
        //    sw = 1;
        //}
        if ($("#eval").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionT"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabExcavacionT"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamiento2");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gTratamiento2", "eval": $("#eval").val(), "txtSectorT": $("#txtSectorT").val(), "txtUnidadT": $("#txtUnidadT").val(), "txtCapaT": $("#txtCapaT").val(), "txtNivelT": $("#txtNivelT").val(), "txtCuadriculaT": $("#txtCuadriculaT").val(), "txtPlanoT": $("#txtPlanoT").val(), "txtContextoT": $("#txtContextoT").val(), "txtUbicContextoT": $("#txtUbicContextoT").val(), "txtAlturaObsT": $("#txtAlturaObsT").val(), "txtOtrosDatosT": $("#txtOtrosDatosT").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarTrat3() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());
        if ($("#txtAltoT").val() == "") {
            $("#txtAltoT").val(0);
        }
        else {
            if ($("#txtAltoT").val() > 999999) {
                mensaje = "Alto debe ser menor a 999999";
                $("#txtAltoT").select();
                sw = 1;
            }
        }
        if ($("#txtLargoT").val() == "") {
            $("#txtLargoT").val(0);
        }
        else {
            if ($("#txtLargoT").val() > 999999) {
                mensaje = "Largo debe ser menor a 999999";
                $("#txtLargoT").select();
                sw = 1;
            }
        }
        if ($("#txtAnchoT").val() == "") {
            $("#txtAnchoT").val(0);
        }
        else {
            if ($("#txtAnchoT").val() > 999999) {
                mensaje = "Ancho debe ser menor a 999999";
                $("#txtAnchoT").select();
                sw = 1;
            }
        }
        if ($("#txtEspesorT").val()== "") {
            $("#txtEspesorT").val(0);
        }
        else {
            if ($("#txtEspesorT").val() > 999999) {
                mensaje = "Espesor debe ser menor a 999999";
                $("#txtEspesorT").select();
                sw = 1;
            }
        }
        if ($("#txtDiamMaxT").val() == "") {
            $("#txtDiamMaxT").val(0);
        }
        else {
            if ($("#txtDiamMaxT").val() > 999999) {
                mensaje = "Diametro Maximo debe ser menor a 999999";
                $("#txtDiamMaxT").select();
                sw = 1;
            }
        }
        if ($("#txtDiamMinT").val() == "") {
            $("#txtDiamMinT").val(0);
        }
        else {
            if ($("#txtDiamMinT").val() > 999999) {
                mensaje = "Diametro Minimo debe ser menor a 999999";
                $("#txtDiamMinT").select();
                sw = 1;
            }
        }
        if ($("#txtDiamBaseT").val() == "") {
            $("#txtDiamBaseT").val(0);
        }
        else {
            if ($("#txtDiamBaseT").val() > 999999) {
                mensaje = "Diametro Base debe ser menor a 999999";
                $("#txtDiamBaseT").select();
                sw = 1;
            }
        }
        if ($("#txtPesoIniT").val() == "") {
            mensaje = "Ingrese Peso inicial"
            sw = 1;
        } else {
            if ($("#txtPesoIniT").val() > 999999) {
                mensaje = "Peso inicial debe ser menor a 999999";
                $("#txtPesoIniT").select();
                sw = 1;
            }
        }
        if ($("#txtPesoFinT").val() == "") {
            mensaje = "Ingrese Peso final"
            sw = 1;
        } else {
            if ($("#txtPesoFinT").val() > 999999) {
                mensaje = "Peso final debe ser menor a 999999";
                $("#txtPesoFinT").select();
                sw = 1;
            }
        }

        if ($("#txtMaterialT").val() == "") {
            mensaje = "Ingrese Material"
            sw = 1;
        }
        if ($("#txtDenominacionT").val() == "") {
            mensaje = "Seleccione DEnominacion"
            sw = 1;
        }
        if ($("#txtDescripcionT").val() == "") {
            mensaje = "Ingrese DEscripcion"
            sw = 1;
        }

        if ($("#eval").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabFisicaDimensaionesT"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamiento3");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gTratamiento3", "eval": $("#eval").val(), "txtMaterialT": $("#txtMaterialT").val(), "txtDenominacionT": $("#txtDenominacionT").val(), "txtDescripcionT": $("#txtDescripcionT").val(), "txtAltoT": $("#txtAltoT").val(), "txtLargoT": $("#txtLargoT").val(), "txtAnchoT": $("#txtAnchoT").val(), "txtEspesorT": $("#txtEspesorT").val(), "txtDiamMaxT": $("#txtDiamMaxT").val(), "txtDiamMinT": $("#txtDiamMinT").val(), "txtDiamBaseT": $("#txtDiamBaseT").val(), "txtPesoIniT": $("#txtPesoIniT").val(), "txtPesoFinT": $("#txtPesoFinT").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarTrat4() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());

        if ($("#txtUbicInmuebleT").val() == "") {
            mensaje = "Ingrese ubicacion del inmueble"
            sw = 1;
        }
        if ($("#txtCajaT").val() == "") {
            mensaje = "Ingrese Caja"
            sw = 1;
        }
        if ($("#txtBolsaT").val() == "") {
            mensaje = "Ingrese Bolsa"
            sw = 1;
        }
        if ($("#cboIntegridadT").val() == "0") {
            mensaje = "Seleccione Integridad"
            sw = 1;
        }
        if ($("#cboConservacionT").val() == "0") {
            mensaje = "Seleccione Conselvacion"
            sw = 1;
        }

        if ($("#txtDetConservacionT").val() == "") {
            mensaje = "Ingrese detalle de conservacion"
            sw = 1;
        }

        if ($("#txtIntervAntT").val() == "") {
            mensaje = "Ingrese intervenciones anteriores"
            sw = 1;
        }
        if ($("#txtFechFinT").val() == "") {
            mensaje = "Ingrese Fecha fin"
            sw = 1;
        }
        if ($("#txtFechaIniT").val() == "") {
            mensaje = "Ingrese Fecha inicial"
            sw = 1;
        }
        if ($("#eval").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionT"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabConservResturacT"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamiento4");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gTratamiento4", "eval": $("#eval").val(), "txtUbicInmuebleT": $("#txtUbicInmuebleT").val(), "txtCajaT": $("#txtCajaT").val(), "txtBolsaT": $("#txtBolsaT").val(), "cboIntegridadT": $("#cboIntegridadT").val(), "cboConservacionT": $("#cboConservacionT").val(), "txtDetConservacionT": $("#txtDetConservacionT").val(), "txtIntervAntT": $("#txtIntervAntT").val(), "txtFechaIniT": $("#txtFechaIniT").val(), "txtFechFinT": $("#txtFechFinT").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarTrat5() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());


        if ($("#txtDetTratamientoT").val() == "") {
            mensaje = "Ingrese detalle de tratamiento"
            sw = 1;
        }
        if ($("#eval").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionT"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabLimpiezaTratT"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamiento5");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gTratamiento5", "eval": $("#eval").val(), "txtDetTratamientoT": $("#txtDetTratamientoT").val(),  "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarTrat6() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#txtPegadoT2').val());

        if ($("#eval").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabProcesoRecomendT"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamiento6");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gTratamiento6", "eval": $("#eval").val(), "txtSecadoT": $("#txtSecadoT").val(), "txtPegadoT": $("#txtPegadoT2").val(), "txtConsolidacionT": $("#txtConsolidacionT").val(), "txtReIntegracT": $("#txtReIntegracT").val(), "txtOtrosPostT": $("#txtOtrosPostT").val(), "txtFechaIniProcT": $("#txtFechaIniProcT").val(), "txtFechaFinProcT": $("#txtFechaFinProcT").val(), "txtTemperaturaT": $("#txtTemperaturaT").val(), "txtHumedadT": $("#txtHumedadT").val(), "txtManipulacionT": $("#txtManipulacionT").val(), "txtIluminacionT": $("#txtIluminacionT").val(), "txtOtrosRecT": $("#txtOtrosRecT").val(), "txtMaterialRecomendT": $("#txtMaterialRecomendT").val(), "txtObservacionesT": $("#txtObservacionesT").val(), "txtConservCargoT": $("#txtConservCargoT").val(), "txtFechaT": $("#txtFechaT").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarTrat7() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());

        if ($('#file_graf2T').html()) {
            sw = 0;
        } else {
            if ($("#file_graf2T").val() == "") {
                mensaje = "Seleccione imagen gráfico 2"
                sw = 1;
            }
        }
        if ($('#file_graf1T').html()) {
            sw = 0;
        } else {
            if ($("#file_graf1T").val() == "") {
                mensaje = "Seleccione imagen gráfico 1"
                sw = 1;
            }
        }
        if ($('#file_detalleT').html()) {
            sw = 0;
        } else {
            if ($("#file_detalleT").val() == "") {
                mensaje = "Seleccione imagen detalle"
                sw = 1;
            }
        }
        if ($('#file_finT').html()) {
            sw = 0;
        } else {
            if ($("#file_finT").val() == "") {
                mensaje = "Seleccione imagen termino"
                sw = 1;
            }
        }
        if ($('#div_fileIniT').html()) {
            sw = 0;
        } else {
            if ($("#file_iniT").val() == "") {
                mensaje = "Seleccione imagen inicial"
                sw = 1;
            }
        }

        if ($("#cat").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabDatosRegT"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamiento7");
            //var form = $('#frmEvaluacion').serialize();
            //$.ajax({
            //    type: "GET",
            //    contentType: "application/json; charset=utf-8",
            //    url: "processmuseo.aspx",
            //    //data: form,
            //    data: { "param0": "gTratamiento7", "eval": $("#eval").val(), "txtCultura": $("#txtCultura").val(), "txtEstilo": $("#txtEstilo").val(), "cboPeriodo": $("#cboPeriodo").val(), "cboCronologia": $("#cboCronologia").val(), "cboGeografica": $("#cboGeografica").val(), "cboClasificacion": $("#cboClasificacion").val(), "txtNombreClasif": $("#txtNombreClasif").val(), "txtRegion": $("#txtRegion").val(), "txtValle": $("#txtValle").val(), "cboMargen": $("#cboMargen").val(), "cboExcavacion": $("#cboExcavacion").val(), "txtSector": $("#txtSector").val(), "txtUnidad": $("#txtUnidad").val(), "txtCapa": $("#txtCapa").val(), "txtNivel": $("#txtNivel").val(), "txtCuadricula": $("#txtCuadricula").val(), "txtPlano": $("#txtPlano").val(), "txtContexto": $("#txtContexto").val(), "txtUbicContexto": $("#txtUbicContexto").val(), "txtAlturaAbsoluta": $("#txtAlturaAbsoluta").val(), "txtOtrosDatos": $("#txtOtrosDatos").val(), "paramdgc": $("#paramdgc").val() },
            //    dataType: "json",
            //    cache: false,
            //    async: false,
            //    success: function (data) {
            //        if (data[0].alert == "success") {
                        
                        //$('#eval').val(data[0].code);
                        if ($("#file_iniT").val() != "") {
                            SubirArchivo($("#eval").val(), "INICIALT");
                        }
                        if ($("#file_finT").val() != "") {
                            SubirArchivo($("#eval").val(), "TERMINOT");
                        }
                        if ($("#file_detalleT").val() != "") {
                            SubirArchivo($("#eval").val(), "DETALLET");
                        }
                        if ($("#file_graf1T").val() != "") {
                            SubirArchivo($("#eval").val(), "GRAFICO1T");
                        }
                        if ($("#file_graf2T").val() != "") {
                            SubirArchivo($("#eval").val(), "GRAFICO2T");
                        }
                        fnMensaje("success", "Proceso realizado con éxito");
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
                        $('.piluku-preloader').addClass('hidden');
            //        } else {
            //            fnMensaje(data[0].alert, data[0].msje);
            //            $('.piluku-preloader').addClass('hidden');
            //        }
            //    },
            //    error: function (result) {
            //        fnMensaje(data[0].alert, data[0].msje);
            //        console.log(result);
            //    }
            //});
        }
        $("#param0").val("");
    }

    function fnGuardarPostT1() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());

        if ($("#txtNroFichaPT").val() == "") {
            mensaje = "Ingrese numero de ficha"
            sw = 1;
        } else {
            if ($("#txtNroFichaPT").val() > 999999) {
                mensaje = "Numero de ficha debe ser menor a 999999";
                $("#txtNroFichaPT").select();
                sw = 1;
            }
        }
        if ($("#txtCodRegNacPT").val() == "") {
            mensaje = "Ingrese codigo de registro nacional"
            sw = 1;
        } else {
            if ($("#txtCodRegNacPT").val() > 999999) {
                mensaje = "Codigo de registro nacional debe ser menor a 999999";
                $("#txtCodRegNacPT").select();
                sw = 1;
            }
        }
        if ($("#txtCodPropietarioPT").val() == "") {
            mensaje = "Ingrese codigo de propietario"
            sw = 1;
        }
        if ($("#txtCodigoExcavacionPT").val() == "") {
            mensaje = "Ingrese codigo de excavacion"
            sw = 1;
        }
        if ($("#txtCodRestaurPT").val() == "") {
            mensaje = "Ingrese codigo de restauracion"
            sw = 1;
        }

        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionPT"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabExcavacionPT"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamientoPT1");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gTratamientoPT1", "eval": $("#txtNroFichaPT").val(), "txtNroFichaPT": $("#txtNroFichaPT").val(), "txtCodRegNacPT": $("#txtCodRegNacPT").val(), "txtCodPropietarioPT": $("#txtCodPropietarioPT").val(), "txtCodigoExcavacionPT": $("#txtCodigoExcavacionPT").val(), "txtCodRestaurPT": $("#txtCodRestaurPT").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarPostT2() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";

        //if ($("#txtCultura").val() == "") {
        //    mensaje = "Ingrese Culturas"
        //    sw = 1;
        //}
        if ($("#eval").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionPT"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamientoPT2");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gTratamientoPT2", "eval": $("#eval").val(), "txtSectorPT": $("#txtSectorPT").val(), "txtUnidadPT": $("#txtUnidadPT").val(), "txtCapaPT": $("#txtCapaPT").val(), "txtNivelPT": $("#txtNivelPT").val(), "txtCuadriculaPT": $("#txtCuadriculaPT").val(), "txtPlanoPT": $("#txtPlanoPT").val(), "txtContextoPT": $("#txtContextoPT").val(), "txtUbicContextoPT": $("#txtUbicContextoPT").val(), "txtAlturaObsPT": $("#txtAlturaObsPT").val(), "txtOtrosDatosPT": $("#txtOtrosDatosPT").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarPostT3() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());
        if ($("#txtAltoPT").val() =="") {
            $("#txtAltoPT").val(0);
        }
        else {
            if ($("#txtAltoPT").val() > 999999) {
                mensaje = "Alto debe ser menor a 999999";
                $("#txtAltoPT").select();
                sw = 1;
            }
        }
        if ($("#txtLargoPT").val() == "" ) {
            $("#txtLargoPT").val(0);
        }
        else {
            if ($("#txtLargoPT").val() > 999999) {
                mensaje = "Largo debe ser menor a 999999";
            $("#txtLargoPT").select();
            sw = 1;
            }
        }
        if ($("#txtAnchoPT").val() == "") {
            $("#txtAnchoPT").val(0);
        }
        else {
            if ($("#txtAnchoPT").val() > 999999) {
                mensaje = "Ancho debe ser menor a 999999";
                $("#txtAnchoPT").select();
                sw = 1;
            }
        }
        if ($("#txtEspesorPT").val() == "") {
            $("#txtEspesorPT").val(0);
        }
        else {
            if ($("#txtEspesorPT").val() > 999999) {
                mensaje = "Espesor debe ser menor a 999999";
                $("#txtEspesorPT").select();
                sw = 1;
            }
        }
        if ($("#txtDiamMaxPT").val() == "") {
            $("#txtDiamMaxPT").val(0);
        }
        else {
            if ($("#txtDiamMaxPT").val() > 999999) {
                mensaje = "Diametro Maximo debe ser menor a 999999";
                $("#txtDiamMaxPT").select();
                sw = 1;
            }
        }
        if ($("#txtDiamMinPT").val() =="") {
            $("#txtDiamMinPT").val(0);
        }
        else {
            if ($("#txtDiamMinPT").val() > 6000) {
                mensaje = "Diametro Minimo debe ser menor a 6000";
                $("#txtDiamMinPT").select();
                sw = 1;
            }
        }
        if ($("#txtDiamBasePT").val() =="") {
            $("#txtDiamBasePT").val(0);
        }
        else {
            if ($("#txtDiamBasePT").val() > 999999) {
                mensaje = "Diametro Base debe ser menor a 999999";
                $("#txtDiamBasePT").select();
                sw = 1;
            }
        }
        if ($("#txtPesoPT").val() == "") {
            mensaje = "Ingrese Peso"
            sw = 1;
        } else {
            if ($("#txtPesoPT").val() > 999999) {
                mensaje = "Peso debe ser menor a 999999";
                $("#txtPesoPT").select();
                sw = 1;
            }
        }

        if ($("#txtMaterialPT").val() == "") {
            mensaje = "Ingrese Material"
            sw = 1;
        }
        if ($("#txtDenominacionPT").val() == "") {
            mensaje = "Seleccione DEnominacion"
            sw = 1;
        }
        if ($("#txtDescripcionPT").val() == "") {
            mensaje = "Ingrese DEscripcion"
            sw = 1;
        }

        if ($("#cat").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionPT"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabFisicaDimensaionesPT"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamientoPT3");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gTratamientoPT3", "eval": $("#eval").val(), "txtMaterialPT": $("#txtMaterialPT").val(), "txtDenominacionPT": $("#txtDenominacionPT").val(), "txtDescripcionPT": $("#txtDescripcionPT").val(), "txtAltoPT": $("#txtAltoPT").val(), "txtLargoPT": $("#txtLargoPT").val(), "txtAnchoPT": $("#txtAnchoPT").val(), "txtEspesorPT": $("#txtEspesorPT").val(), "txtDiamMaxPT": $("#txtDiamMaxPT").val(), "txtDiamMinPT": $("#txtDiamMinPT").val(), "txtDiamBasePT": $("#txtDiamBasePT").val(), "txtPesoPT": $("#txtPesoPT").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarPostT4() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());
        if ($('#div_frontalPT').html()) {
            sw = 0;
        }else{
            if ($("#file_frontalPT").val() == "") {
                mensaje = "Seleccione imagen frontal"
                sw = 1;
            }
        }
        if ($("#txtUbicInmueblePT").val() == "") {
            mensaje = "Ingrese ubicacion del inmueble"
            sw = 1;
        }
        if ($("#txtCajaPT").val() == "") {
            mensaje = "Ingrese Caja"
            sw = 1;
        }
        if ($("#txtBolsaPT").val() == "") {
            mensaje = "Ingrese Bolsa"
            sw = 1;
        }


        if ($("#txtProblemPT").val() == "") {
            mensaje = "Ingrese problematica"
            sw = 1;
        }
        if ($("#txtVariacPT").val() == "") {
            mensaje = "Ingrese variacion"
            sw = 1;
        }
        if ($("#txtReaccionesPT").val() == "") {
            mensaje = "Ingrese reacciones"
            sw = 1;
        }
        if ($("#txtPresAfectPT").val() == "0") {
            mensaje = "Ingrese afectaciones"
            sw = 1;
        }
        if ($("#txtTipoAfecPT").val() == "") {
            mensaje = "Ingrese tipo de afectaciones"
            sw = 1;
        }
        if ($("#txtCausaAfecPT").val() == "") {
            mensaje = "Ingrese causa de afectaciones"
            sw = 1;
        }
        if ($("#txtFechaPT").val() == "") {
            mensaje = "Ingrese fecha"
            sw = 1;
        }
        if ($("#txtConseCargoPT").val() == "") {
            mensaje = "Ingrese conservador a cargo"
            sw = 1;
        }
        if ($("#cat").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
            sw = 1;
            swTab = 0;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabIdentificacionPT"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabUbicacionActualPT"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gTratamientoPT4");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gTratamientoPT4", "eval": $("#eval").val(), "txtUbicInmueblePT": $("#txtUbicInmueblePT").val(), "txtCajaPT": $("#txtCajaPT").val(), "txtBolsaPT": $("#txtBolsaPT").val(), "txtProblemPT": $("#txtProblemPT").val(), "txtVariacPT": $("#txtVariacPT").val(), "txtReaccionesPT": $("#txtReaccionesPT").val(), "txtPresAfectPT": $("#txtPresAfectPT").val(), "txtTipoAfecPT": $("#txtTipoAfecPT").val(), "txtCausaAfecPT": $("#txtCausaAfecPT").val(), "txtRecomenPT": $("#txtRecomenPT").val(), "txtConseCargoPT": $("#txtConseCargoPT").val(), "txtFechaPT": $("#txtFechaPT").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        if ($("#file_frontalpt").val() != "") {
                            SubirArchivo($("#eval").val(), "FRONTALPT");
                            swvalida = 1;
                        }
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarAlmac1() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());

        if ($("#txtTipoLuzA").val() == "") {
            mensaje = "Ingrese tipo de luz"
            sw = 1;
        }
        if ($("#txtVentanasA").val() == "") {
            $("#txtVentanasA").val(0);            
        } else {
            if ($("#txtVentanasA").val() > 999999) {
                mensaje = "numero de ventanas debe ser menor a 999999";
                $("#txtVentanasA").select();
                sw = 1;
            }
        }
        if ($("#txtTipoEstrA").val() == "") {
            mensaje = "Ingrese tipo de estructura"
            sw = 1;
        }
        if ($("#txtAreaA").val() == "") {
            mensaje = "Ingrese área"
            sw = 1;
        }        
        if ($("#txtAmbMonitoreoA").val() == "") {
            mensaje = "Ingrese ambiente monitoreado"
            sw = 1;
        }
        if ($("#txtNroFichaA").val() == "") {
            mensaje = "Ingrese numero de ficha"
            sw = 1;
        } else {
            if ($("#txtNroFichaA").val() > 999999) {
                mensaje = "Numero de ficha debe ser menor a 999999";
                $("#txtNroFichaA").select();
                sw = 1;
            }
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabCaracterA"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabCaracterA"]').tab('show')

            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gAlmacen1");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gAlmacen1", "eval": $("#txtNroFichaA").val(), "txtNroFichaA": $("#txtNroFichaA").val(), "txtAmbMonitoreoA": $("#txtAmbMonitoreoA").val(), "txtAreaA": $("#txtAreaA").val(), "txtTipoEstrA": $("#txtTipoEstrA").val(), "txtVentanasA": $("#txtVentanasA").val(), "txtTipoLuzA": $("#txtTipoLuzA").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarAlmac2() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());
        if ($("#txtCajaMadA").val() == "") {
            $("#txtCajaMadA").val(0);
        } else {
            if ($("#txtCajaMadA").val() > 999999) {
                mensaje = "cantidad de cajas de madera debe ser menor a 999999";
                $("#txtCajaMadA").select();
                sw = 1;
            }
        }
        if ($("#txtCajaCartonA").val() == "") {
            $("#txtCajaCartonA").val(0);
        } else {
            if ($("#txtCajaCartonA").val() > 999999) {
                mensaje = "cantidad de cajas de carton debe ser menor a 999999";
                $("#txtCajaCartonA").select();
                sw = 1;
            }
        }
        if ($("#ttxCajaPlaA").val() == "") {
            $("#ttxCajaPlaA").val(0);
        } else {
            if ($("#ttxCajaPlaA").val() > 999999) {
                mensaje = "cantidad de cajas plasticas debe ser menor a 999999";
                $("#ttxCajaPlaA").select();
                sw = 1;
            }
        }
        if ($("#txtNivelEstA").val() == "") {
            mensaje = "Ingrese numero de niveles de estantes"
            $("#txtNivelEstA").select();
            sw = 1;
        } else {
            if ($("#txtNivelEstA").val() > 999999) {
                mensaje = "La cantidad de niveles debe ser menor a 999999";
                $("#txtNivelEstA").select();
                sw = 1;
            }
        }
        if ($("#txtCantEstA").val() == "") {
            mensaje = "Ingrese cantidad de estantes"
            sw = 1;
        } else {
            if ($("#txtCantEstA").val() > 999999) {
                mensaje = "La cantidad de estantes debe ser menor a 999999";
                $("#txtCantEstA").select();
                sw = 1;
            }
        }
        if ($("#txtCantThermA").val() == "") {
            $("#txtCantThermA").val(0);
        } else {
            if ($("#txtCantThermA").val() > 999999) {
                mensaje = "La cantidad de estantes debe ser menor a 999999";
                $("#txtCantEstA").select();
                sw = 1;
            }
        }
        if ($("#txtCantExtA").val() == "") {
            $("#txtCantExtA").val(0);
        } else {
            if ($("#txtCantExtA").val() > 999999) {
                mensaje = "cantidad de extractores debe ser menor a 999999";
                $("#txtCantExtA").select();
                sw = 1;
            }
        }
        if ($("#txtCantAireA").val() == "") {
            $("#txtCantAireA").val(0);
        } else {
            if ($("#txtCantAireA").val() > 999999) {
                mensaje = "cantidad de aire debe ser menor a 999999";
                $("#txtCantAireA").select();
                sw = 1;
            }
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabCaracterA"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabEquipamientoA"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gAlmacen2");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gAlmacen2", "eval": $("#eval").val(), "txtTipoAireA": $("#txtTipoAireA").val(), "txtCantAireA": $("#txtCantAireA").val(), "txtTipoExtA": $("#txtTipoExtA").val(), "txtCantExtA": $("#txtCantExtA").val(), "txtCantThermA": $("#txtCantThermA").val(), "txtDeshumeA": $("#txtDeshumeA").val(), "txtCantEstA": $("#txtCantEstA").val(), "txtNivelEstA": $("#txtNivelEstA").val(), "ttxCajaPlaA": $("#ttxCajaPlaA").val(), "txtCajaCartonA": $("#txtCajaCartonA").val(), "txtCajaMadA": $("#txtCajaMadA").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarAlmac3() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());

        if ($("#txtColeccionA").val() == "") {
            mensaje = "Ingrese coleciones"
            sw = 1;

        }
        if ($("#txtMaterialA").val() == "") {
            mensaje = "Ingrese material arqueologico"
            sw = 1;
        }

        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabCaracterA"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabBienesA"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gAlmacen3");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gAlmacen3", "eval": $("#eval").val(), "txtColeccionA": $("#txtColeccionA").val(), "txtMaterialA": $("#txtMaterialA").val(), "txtOtrosA": $("#txtOtrosA").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnGuardarAlmac4() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        //alert($('#cat').val());
        if ($("#txtConservCargoA").val() == "") {
            mensaje = "Ingrese Conservador a cargo"
            sw = 1;
        }

        if ($("#txtFechaA").val() == "") {
            mensaje = "Ingrese fecha"
            sw = 1;
        }

        if ($("#txtHraIngAA").val() == "") {
            mensaje = "Ingrese hora de ingreso"
            sw = 1;
        }
        if ($("#txtHraSalAA").val() == "") {
            mensaje = "Ingrese hora de salida"
            sw = 1;
        }
        if ($("#txtPriTaCA").val() == "") {
            mensaje = "Ingrese primera temperatura"
            sw = 1;
        }
        if ($("#txtSegTaCA").val() == "") {
            mensaje = "Ingrese segunda temperatura"
            sw = 1;
        }
        if ($("#txtPriHa").val() == "") {
            mensaje = "Ingrese primera H %"
            sw = 1;
        }
        if ($("#txtSegundaHa").val() == "") {
            mensaje = "Ingrese segunda H %"
            sw = 1;
        }
        if ($("#txtHraIngPA").val() == "") {
            mensaje = "Ingrese hora ingreso"
            sw = 1;
        }
        if ($("#txtHraSalPA").val() == "") {
            mensaje = "Ingrese hora salida"
            sw = 1;
        }
        if ($("#txtPriTpCA").val() == "") {
            mensaje = "Ingrese primera temperatura"
            sw = 1;
        }
        if ($("#txtSegTpCA").val() == "") {
            mensaje = "Ingrese segunda temperatura"
            sw = 1;
        }

        if ($("#txtPrimeraHp").val() == "") {
            mensaje = "Ingrese primera HA"
            sw = 1;
        }
        if ($("#txtSegundaHp").val() == "") {
            mensaje = "Ingrese segunda HA"
            sw = 1;
        }

        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab == 0) {
                $('.nav-tabs a[href="#tabCaracterA"]').tab('show')
            } else {
                $('.nav-tabs a[href="#tabMonitoreoA"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gAlmacen4");
            //var form = $('#frmEvaluacion').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                //data: form,
                data: { "param0": "gAlmacen4", "eval": $("#eval").val(), "txtFechaA": $("#txtFechaA").val(), "txtHraIngAA": $("#txtHraIngAA").val(), "txtHraSalAA": $("#txtHraSalAA").val(), "txtPriTaCA": $("#txtPriTaCA").val(), "txtSegTaCA": $("#txtSegTaCA").val(), "txtPriHa": $("#txtPriHa").val(), "txtSegundaHa": $("#txtSegundaHa").val(), "txtHraIngPA": $("#txtHraIngPA").val(), "txtHraSalPA": $("#txtHraSalPA").val(), "txtPriTpCA": $("#txtPriTpCA").val(), "txtSegTpCA": $("#txtSegTpCA").val(), "txtPrimeraHp": $("#txtPrimeraHp").val(), "txtSegundaHp": $("#txtSegundaHp").val(), "txtObsA": $("#txtObsA").val(), "txtConservCargoA": $("#txtConservCargoA").val(), "paramdgc": $("#paramdgc").val() },
                dataType: "json",
                //cache: false,
                //async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#eval').val(data[0].code);
                        listarEvaluacionesDGC($("#paramdgc").val());
                        tablaEvaluacionesDGC()
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

    function fnMostrarImagen(id_ar, id) {
        var flag = false;
        var form = new FormData();
        form.append("param0", "DownloadSinEnc");
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

    function SubirArchivo(cod, tipo) {

        var flag = false;
        try {
            var data = new FormData();
            data.append("param0", "SurbirArchivoNew");
            data.append("codigo", cod);
            data.append("tipo", tipo);
            //alert(cod);
            if (tipo == "FRONTALE") {
                var files = $("#file_frontalE").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "INICIALT") {
                var files = $("#file_iniT").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "TERMINOT") {
                var files = $("#file_finT").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "DETALLET") {
                var files = $("#file_detalleT").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "GRAFICO1T") {
                var files = $("#file_graf1T").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "GRAFICO2T") {
                var files = $("#file_graf2T").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }
            if (tipo == "FRONTALPT") {
                var files = $("#file_frontalPT").get(0).files;
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

<script type="text/javascript">
    (function () {

        "use strict"


        // Plugin Constructor
        var TagsInput = function (opts) {
            this.options = Object.assign(TagsInput.defaults, opts);
            this.init();
        }

        // Initialize the plugin
        TagsInput.prototype.init = function (opts) {
            this.options = opts ? Object.assign(this.options, opts) : this.options;

            if (this.initialized)
                this.destroy();

            if (!(this.orignal_input = document.getElementById(this.options.selector))) {
                console.error("tags-input couldn't find an element with the specified ID");
                return this;
            }

            this.arr = [];
            this.wrapper = document.createElement('div');
            this.input = document.createElement('input');
            init(this);
            initEvents(this);

            this.initialized = true;
            return this;
        }

        // Add Tags
        TagsInput.prototype.addTag = function (string) {

            if (this.anyErrors(string))
                return;

            this.arr.push(string);
            var tagInput = this;

            var tag = document.createElement('span');
            tag.className = this.options.tagClass;
            tag.innerText = string;

            var closeIcon = document.createElement('a');
            closeIcon.innerHTML = '&times;';

            // delete the tag when icon is clicked
            closeIcon.addEventListener('click', function (e) {
                e.preventDefault();
                var tag = this.parentNode;

                for (var i = 0; i < tagInput.wrapper.childNodes.length; i++) {
                    if (tagInput.wrapper.childNodes[i] == tag)
                        tagInput.deleteTag(tag, i);
                }
            })


            tag.appendChild(closeIcon);
            this.wrapper.insertBefore(tag, this.input);
            this.orignal_input.value = this.arr.join(',');

            return this;
        }

        // Delete Tags
        TagsInput.prototype.deleteTag = function (tag, i) {
            tag.remove();
            this.arr.splice(i, 1);
            this.orignal_input.value = this.arr.join(',');
            return this;
        }

        // Make sure input string have no error with the plugin
        TagsInput.prototype.anyErrors = function (string) {
            if (this.options.max != null && this.arr.length >= this.options.max) {
                console.log('max tags limit reached');
                return true;
            }

            

            return false;
        }

        // Add tags programmatically 
        TagsInput.prototype.addData = function (array) {
            var plugin = this;

            array.forEach(function (string) {
                plugin.addTag(string);
            })
            return this;
        }

        // Get the Input String
        TagsInput.prototype.getInputString = function () {
            return this.arr.join(',');
        }


        // destroy the plugin
        TagsInput.prototype.destroy = function () {
            this.orignal_input.removeAttribute('hidden');

            delete this.orignal_input;
            var self = this;

            Object.keys(this).forEach(function (key) {
                if (self[key] instanceof HTMLElement)
                    self[key].remove();

                if (key != 'options')
                    delete self[key];
            });

            this.initialized = false;
        }

        // Private function to initialize the tag input plugin
        function init(tags) {
            tags.wrapper.append(tags.input);
            tags.wrapper.classList.add(tags.options.wrapperClass);
            tags.orignal_input.setAttribute('hidden', 'true');
            tags.orignal_input.parentNode.insertBefore(tags.wrapper, tags.orignal_input);
        }

        // initialize the Events
        function initEvents(tags) {
            tags.wrapper.addEventListener('click', function () {
                tags.input.focus();
            });


            tags.input.addEventListener('keydown', function (e) {
                var str = tags.input.value.trim();

                if (!!(~[9, 13, 188].indexOf(e.keyCode))) {
                    e.preventDefault();
                    tags.input.value = "";
                    if (str != "")
                        tags.addTag(str);
                }

            });
        }


        // Set All the Default Values
        TagsInput.defaults = {
            selector: '',
            wrapperClass: 'tags-input-wrapper',
            tagClass: 'tag',
            max: null,
            duplicate: false
        }

        window.TagsInput = TagsInput;

    })();

    var tagInput = new TagsInput({
        selector: 'txtDetConservacionE',
        duplicate: false,
        max: 10
    });
    
    var tagInput2 = new TagsInput({
        selector: 'txtIntervAntT',
        duplicate: false,
        max: 10
    });

    var tagInput3 = new TagsInput({
        selector: 'txtDetTratamientoT',
        duplicate: false,
        max: 10
    });

</script>
</head>

<body  >

    <form id="frmEvaluacion" name="frmEvaluacion" runat="server">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="paramdgc" name="paramdgc" value="" runat="server" /> 
    <input type="hidden" id="eval" name="eval" value="" /> 
    <input type="hidden" id="tfu" name="tfu" value="" runat="server"/> 

        <div class="row">
    <div class="panel panel-piluku">

            <div class="panel-heading">
		        <h3 class="panel-title">
			        
                    <div class="col-md-4" align="left" >
                          <div id="titulo" runat="server"> </div>  
                    </div>
                    <div class="col-md-8" align="right">               
                        <a href="#" id="btnCargaMasiva" class="btn btn-white" style="width:30%" ><i class="ion-android-done"></i>&nbsp;Cargas Masivas</a>
                        <button type="button" class="btn btn-white " id="btnExportarRep" runat="server" ><i class="ion-android-download"></i>&nbsp;Evaluaciones</button>	
                        <button type="button" class="btn btn-white " id="btnExportarRepT" runat="server" ><i class="ion-android-download"></i>&nbsp;Tratamiento</button>	
                        <button type="button" class="btn btn-white " id="btnExportarRepPT" runat="server" ><i class="ion-android-download"></i>&nbsp;PostTratamiento</button>	
                        <button type="button" class="btn btn-white " id="btnExportarRepA" runat="server" ><i class="ion-android-download"></i>&nbsp;Almacenes</button>	
                    </div>

                       
                </h3>
	        </div>	  
	        <div class='table-responsive'>	        
                <div class='panel-body' >
                    <center>
                        <a href="#" id="btnAddEvaluacion" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Evaluación</a>
                        <a href="#" id="btnAddTratamiento" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Tratamiento</a>
                        <a href="#" id="btnAddPostTrata" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;PostTratamiento</a>
                        <a href="#" id="btnAddAlmacenes" class="btn btn-primary btn-lg" ><i class="ion-android-done"></i>&nbsp;Almacenes</a>
                    </center>
                    <div class='table-responsive'>
                        <table class='display dataTable cell-border' id='tbEvaluacion' style="width:95%;font-size:smaller">
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
                                <tbody id ="pEvaluacion" runat ="server">
                                </tbody>                             
                                <tfoot>
                                <tr>
                                <th colspan="6"></th>
                                </tr>
                                </tfoot>
                        </table>
                    </div>              
                </div> 
     
            </div> 
        </div>
    </div>

<%--JAZ--%>
<div class="modal fade" id="mdCargamasiva" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
    <div class="modal-dialog">
	    <div class="modal-content">
		    <div class="modal-header" style="background-color:#E33439;" >
			    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			    <h4 class="modal-title"  style="color:White">Carga Masiva de Conversación</h4>
		    </div>
		    <div class="modal-body">
                <div class="panel-body">
                    <div role="tabpanel" class="tab-pane " id="Div4" runat="server" >
                            <div class="row">
                                <div class="form-group">
                                     <label class="col-sm-2 control-label" for="cboEtapa">
                                        Etapa:</label>
                                            <div class="col-sm-4">
                                                <select class="form-control" id="cboEtapa" name="cboEtapa">
                                                    <option value="0">-- Seleccione -- </option>
                                                    <option value="1">Evaluación</option>
                                                    <option value="2">Tratamiento</option>
                                                    <option value="3">Post Tratamiento</option>
                                                    <option value="4">Almacenes</option>
                                                </select> 
                                            </div>
                                 </div>
                                
                            </div>
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
<%--JAZ--%>

<div class="modal fade " id="mdConfirmarEvaluacion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-jr">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Evaluación</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="Li1" runat="server" ><a href="#tabIdentificacionE" aria-controls="home" role="tab" data-toggle="tab" > Identificaci&oacute;n</a></li>
					    <li role="presentationlogin" id="Li2" runat="server" ><a href="#tabExcavacionE" aria-controls="profile" role="tab" data-toggle="tab" > Excavaci&oacute;n</a></li>
                        <li role="presentationlogin" id="Li3" runat="server" ><a href="#tabFisicaDimensaionesE" aria-controls="profile" role="tab" data-toggle="tab" > Descripci&oacute;n F&iacute;sica</a></li>
                        <li role="presentationlogin" id="Li5" runat="server" ><a href="#tabUbicacionActualE" aria-controls="profile" role="tab" data-toggle="tab" > Datos Ubicaci&oacute;n</a></li>
                        <li role="presentationlogin" id="Li7" runat="server" ><a href="#tabDatosRegE" aria-controls="profile" role="tab" data-toggle="tab" > Datos Adic.</a></li>
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacionE" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroFichaE">
                                            N° Ficha [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNroFichaE" name="txtNroFichaE" class="form-control" onKeyPress="return soloNumeros(event,this)" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodRegNacE">
                                            Cod. Reg. Nacional:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodRegNacE" name="txtCodRegNacE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodPropietarioE" >
                                            Código de Propietario:</label>
                                        <div class="col-sm-2">
                                            <input type="text" id="txtCodPropietarioE" name="txtCodPropietarioE" class="form-control" />
                                        </div>
                                        <%--Inicio JAZ--%>
                                        <div class="col-sm-1">
                                            <button type="button" class="btn btn-green" id="btnBuscarI" ><i class="ion-android-done"></i>&nbsp;Buscar</button>	
                                        </div>
                                        <%--Fin JAZ--%>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodigoExcavacionE">
                                            Otros Códigos:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodigoExcavacionE" name="txtCodigoExcavacionE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodRestaurE">
                                            Cod. Restauración:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodRestaurE" name="txtCodRestaurE" class="form-control" />
                                        </div>
                                    </div>     
                                </div>                                 
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarEval1" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
                        <div role="tabpanel" class="tab-pane " id="tabExcavacionE" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSectorE">
                                            Sector:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtSectorE" name="txtSectorE" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUnidadE">
                                            Unidad:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtUnidadE" name="txtUnidadE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCapaE">
                                            Capa:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCapaE" name="txtCapaE" class="form-control" />                
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNivelE">
                                            Nivel:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtNivelE" name="txtNivelE" class="form-control" />                               
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCuadriculaE">
                                            Cuadricula</label>
                                        <div class="col-sm-3">
                                             <input type="text" id="txtCuadriculaE" name="txtCuadriculaE" class="form-control" />             
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPlanoE">
                                            Plano:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtPlanoE" name="txtPlanoE" class="form-control" />               
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtContextoE">
                                            Contexto:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtContextoE" name="txtContextoE" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUbicContextoE">
                                            Ubic. en el Contex.:
                                        </label>
                                        <div class="col-sm-3">   
                                             <input type="text" id="txtUbicContextoE" name="txtUbicContextoE" class="form-control" />         
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAlturaObsE">
                                            Altura Absoluta:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAlturaObsE" name="txtAlturaObsE" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrosDatosE">
                                            Otros Datos:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtOtrosDatosE" name="txtOtrosDatosE" class="form-control" />            
                                        </div>
                                    </div>
                                </div>
               
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarEval2" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

                        </div>
                        <div role="tabpanel" class="tab-pane" id="tabFisicaDimensaionesE" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtMaterialE">
                                            Material:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtMaterialE" name="txtMaterialE" class="form-control" />
                                        </div>
                                    </div>
                                     <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDenominacionE">
                                            Denomicación:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDenominacionE" name="txtDenominacionE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                   <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDescripcionE">
                                            Descripción:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDescripcionE" name="txtDescripcionE" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAltoE">
                                            Alto [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtAltoE" name="txtAltoE" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtLargoE">
                                            Largo [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtLargoE" name="txtLargoE" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAnchoE">
                                            Ancho [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtAnchoE" name="txtAnchoE" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row"> 
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtEspesorE">
                                            Espesor [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtEspesorE" name="txtEspesorE" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                <div class="form-group">

                                        <label class="col-sm-2 control-label" for="txtDiamMaxE">
                                            Diámetro Máx. [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamMaxE" name="txtDiamMaxE" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMinE">
                                            Diámetro Min. [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamMinE" name="txtDiamMinE" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamBaseE">
                                            Diámetro Base [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamBaseE" name="txtDiamBaseE" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPesoE">
                                            Peso [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtPesoE" name="txtPesoE" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>

                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarEval3" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabUbicacionActualE" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUbicInmuebleE">
                                            Ubic. en el Inmueble:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtUbicInmuebleE" name="txtUbicInmuebleE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCajaE">
                                            N° Caja:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtCajaE" name="txtCajaE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtBolsaE">
                                            N° Bolsa:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtBolsaE" name="txtBolsaE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                               <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboIntegridadE">
                                            Estado de integridad:</label>
                                        <div class="col-sm-2">
                                            <select class="form-control" id="cboIntegridadE" name="cboIntegridadE">
                                                   <option value="0">-- Seleccione -- </option>
                                                   <option value="1">Completo</option>
                                                   <option value="2">Incompleto</option>
                                                   <option value="3">Completo Fragmentado</option>
                                                   <option value="4">Completo Reintegrado</option>
                                                   <option value="5">Incompleto Reintegrado</option>
                                                   <option value="6">Incompleto Fragmentado</option>
                                               </select> 
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboConservacionE">
                                           Conservación:</label>
                                        <div class="col-sm-2">
                                            <select class="form-control" id="cboConservacionE" name="cboConservacionE">
                                                   <option value="0">-- Seleccione -- </option>
                                                   <option value="1">Bueno</option>
                                                   <option value="2">Malo</option>
                                                   <option value="3">Regular</option>
                                               </select> 
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="form-field-tags">Detalles de Conservación</label>
                                        <div class="col-sm-4">
                                           <input type="text" id="txtDetConservacionE" placeholder="Agregar Nuevo Detalle" />
                                            * Solo se puede agregar hasta 10 Detalles
                                        </div>
                                    </div>
                                </div>
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarEval4" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabDatosRegE" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtObservacionE">
                                            Observaciones:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtObservacionE" name="txtObservacionE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTemperaturaE">
                                            Temperatura (°):</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtTemperaturaE" name="txtTemperaturaE" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtHumedad">
                                            Humedad (%):</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtHumedad" name="txtHumedad" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtMinipulacionE">
                                            Manipulación:</label>
                                        <div class="col-sm-2">
                                            <input type="text" id="txtMinipulacionE" name="txtMinipulacionE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrosE">
                                            Otros:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtOtrosE" name="txtOtrosE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtConsCargoE">
                                            Conserv. a Cargo:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtConsCargoE" name="txtConsCargoE" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha:</label>
                                    <div class="col-sm-2" id="Div21">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaE" name="txtFechaE" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                    </div>
                                </div>                             
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                            Vista Frontal: </label>
                                        <div class="col-sm-4">
                                            <input type="file" id="file_frontalE" name="file_frontalE" />
                                            <div id="divFrontalE">
                                            </div>
                                        </div>
                                    </div>
                                </div>  
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarEval5" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
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

<div class="modal fade " id="mdConfirmarTratamiento" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-jr">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Tratamiento</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="Li4" runat="server" ><a href="#tabIdentificacionT" aria-controls="home" role="tab" data-toggle="tab" > Identificaci&oacute;n</a></li>
					    <li role="presentationlogin" id="Li6" runat="server" ><a href="#tabExcavacionT" aria-controls="profile" role="tab" data-toggle="tab" > Excavaci&oacute;n</a></li>
                        <li role="presentationlogin" id="Li8" runat="server" ><a href="#tabFisicaDimensaionesT" aria-controls="profile" role="tab" data-toggle="tab" > Descripci&oacute;n F&iacute;sica</a></li>
                        <li role="presentationlogin" id="Li9" runat="server" ><a href="#tabConservResturacT" aria-controls="profile" role="tab" data-toggle="tab" >Estado de conservación</a></li>
                        <li role="presentationlogin" id="Li11" runat="server" ><a href="#tabLimpiezaTratT" aria-controls="profile" role="tab" data-toggle="tab" > Limpieza </a></li>
                        <li role="presentationlogin" id="Li12" runat="server" ><a href="#tabProcesoRecomendT" aria-controls="profile" role="tab" data-toggle="tab" > Proceso Recomendaciones </a></li>
                        <li role="presentationlogin" id="Li10" runat="server" ><a href="#tabDatosRegT" aria-controls="profile" role="tab" data-toggle="tab" > Datos Adic.</a></li>
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacionT" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroFichaT">
                                            N° Ficha [1-9]:</label>
                                        <div class="col-sm-2">
                                            <input type="text" id="txtNroFichaT" name="txtNroFichaT" class="form-control" onKeyPress="return soloNumeros(event,this)" onblur="AsignarEval()"/>
                                        </div>
                                        <div class="col-sm-1">
                                            <button type="button" class="btn btn-green" id="btnBuscarT" ><i class="ion-android-done"></i>&nbsp;Buscar</button>	
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodRegNacT">
                                            Cod. Reg. Nacional:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodRegNacT" name="txtCodRegNacT" class="form-control"  />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodPropietarioT" >
                                            Código de Propietario:</label>
                                        <div class="col-sm-2">
                                            <input type="text" id="txtCodPropietarioT" name="txtCodPropietarioT" class="form-control" />
                                        </div>
                                        <div class="col-sm-1">
                                            <div id="RepPDFT">
                                            </div>
                                         </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodigoExcavacionT">
                                            Otros Códigos:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodigoExcavacionT" name="txtCodigoExcavacionT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodRestaurT">
                                            Cod. Restauración:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodRestaurT" name="txtCodRestaurT" class="form-control" />
                                        </div>
                                    </div>     
                                </div>                                 
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarTrata1" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
                        <div role="tabpanel" class="tab-pane " id="tabExcavacionT" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSectorT">
                                            Sector:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtSectorT" name="txtSectorT" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUnidadT">
                                            Unidad:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtUnidadT" name="txtUnidadT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCapaT">
                                            Capa:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCapaT" name="txtCapaT" class="form-control" />                
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNivelT">
                                            Nivel:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtNivelT" name="txtNivelT" class="form-control" />                               
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCuadriculaT">
                                            Cuadricula</label>
                                        <div class="col-sm-3">
                                             <input type="text" id="txtCuadriculaT" name="txtCuadriculaT" class="form-control" />             
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPlanoT">
                                            Plano:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtPlanoT" name="txtPlanoT" class="form-control" />               
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtContextoT">
                                            Contexto:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtContextoT" name="txtContextoT" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUbicContextoT">
                                            Ubic. en el Contex:
                                        </label>
                                        <div class="col-sm-3">   
                                             <input type="text" id="txtUbicContextoT" name="txtUbicContextoT" class="form-control" />         
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAlturaObsT">
                                            Altura Absoluta:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAlturaObsT" name="txtAlturaObsT" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrosDatosT">
                                            Otros Datos:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtOtrosDatosT" name="txtOtrosDatosT" class="form-control" />            
                                        </div>
                                    </div>
                                </div>
               
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarTrata2" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

                        </div>
                        <div role="tabpanel" class="tab-pane" id="tabFisicaDimensaionesT" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtMaterialT">
                                            Material:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtMaterialT" name="txtMaterialT" class="form-control" />
                                        </div>
                                    </div>
                                     <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDenominacionT">
                                            Denomicación:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDenominacionT" name="txtDenominacionT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                   <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDescripcionT">
                                            Descripción:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDescripcionT" name="txtDescripcionT" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAltoT">
                                            Alto [1-9] :</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtAltoT" name="txtAltoT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtLargoT">
                                            Largo [1-9] :</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtLargoT" name="txtLargoT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAnchoT">
                                            Ancho [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtAnchoT" name="txtAnchoT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row"> 
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtEspesorT">
                                            Espesor [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtEspesorT" name="txtEspesorT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                  <div class="col-sm-2"></div>  
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMaxT">
                                            Diámetro Máx. [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamMaxT" name="txtDiamMaxT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row"> 
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMinT">
                                            Diámetro Min. [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamMinT" name="txtDiamMinT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamBaseT">
                                            Diámetro Base [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamBaseT" name="txtDiamBaseT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPesoIniT">
                                            Peso Inicial [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtPesoIniT" name="txtPesoIniT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPesoFinT">
                                            Peso Final [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtPesoFinT" name="txtPesoFinT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarTrata3" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabConservResturacT" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUbicInmuebleT">
                                            Ubic. en el Inmueble:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtUbicInmuebleT" name="txtUbicInmuebleT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCajaT">
                                            N° Caja:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtCajaT" name="txtCajaT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtBolsaT">
                                            N° Bolsa:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtBolsaT" name="txtBolsaT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                               <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboIntegridadT">
                                            Estado de Integridad:</label>
                                        <div class="col-sm-2">
                                            <select class="form-control" id="cboIntegridadT" name="cboIntegridadT">
                                                   <option value="0">-- Seleccione -- </option>
                                                   <option value="1">Completo</option>
                                                   <option value="2">Incompleto</option>
                                                   <option value="3">Completo-Fragmentado</option>
                                                   <option value="4">Completo-Reintegrado</option>
                                                   <option value="5">Incompleto-Reintegrado</option>
                                                   <option value="6">Incompleto-Fragmentado</option>
                                               </select> 
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboConservacionT">
                                           Conservación:</label>
                                        <div class="col-sm-2">
                                            <select class="form-control" id="cboConservacionT" name="cboConservacionT">
                                                   <option value="0">-- Seleccione -- </option>
                                                   <option value="1">Bueno</option>
                                                   <option value="2">Malo</option>
                                                   <option value="3">Regular</option>
                                               </select> 
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDetConservacionT">
                                            Detalle Conservación:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtDetConservacionT" name="txtDetConservacionT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="form-field-tags">
                                            Intervenciones Ant.:</label>
                                        <div class="col-sm-6">
                                            <input type="text" id="txtIntervAntT" placeholder="Agregar Nueva Intervencion"/> * Solo se pueden registrar hasta 10 intervenciones
                                        </div>
                                    </div>
                                </div>
                               <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Inicio Proceso:</label>
                                    <div class="col-sm-2" id="Div2">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaIniT" name="txtFechaIniT" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                    </div>
                                </div> 
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fin Proceso:</label>
                                    <div class="col-sm-2" id="Div3">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechFinT" name="txtFechFinT" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                    </div>
                                </div> 
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarTrata4" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabLimpiezaTratT" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="form-field-tags">
                                            Detalle Tratam.:</label>
                                        <div class="col-sm-6">
                                            <input type="text" id="txtDetTratamientoT" placeholder="Agregar Nuevo Detalle"/>
                                            * Solo se puede agregar hasta 10 Detalles de Tratamiento
                                        </div>
                                    </div>
                                </div>
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarTrata5" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabProcesoRecomendT" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSecadoT">
                                            Secado:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtSecadoT" name="txtSecadoT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPegadoT2">
                                            Pegado/Armado:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtPegadoT2" name="txtPegadoT2" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtConsolidacionT">
                                            Consolidación:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtConsolidacionT" name="txtConsolidacionT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtReIntegracT">
                                            ReIntegración:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtReIntegracT" name="txtReIntegracT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrosPostT">
                                            Otros Procesos:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtOtrosPostT" name="txtOtrosPostT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha Ini Proceso:</label>
                                    <div class="col-sm-2" id="Div9">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaIniProcT" name="txtFechaIniProcT" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                    </div>
                                </div> 
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha Fin Proceso:</label>
                                    <div class="col-sm-2" id="Div10">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaFinProcT" name="txtFechaFinProcT" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                    </div>
                                </div> 
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTemperaturaT">
                                            Temperatura °():</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtTemperaturaT" name="txtTemperaturaT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtHumedadT">
                                            Humedad (%):</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtHumedadT" name="txtHumedadT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtManipulacionT">
                                            Manipulación:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtManipulacionT" name="txtManipulacionT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtIluminacionT">
                                            Iluminación:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtIluminacionT" name="txtIluminacionT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrosRecT">
                                            Otros Recomendac.:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtOtrosRecT" name="txtOtrosRecT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtMaterialRecomendT">
                                            Material utiliz..:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtMaterialRecomendT" name="txtMaterialRecomendT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtObservacionesT">
                                            Observaciones:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtObservacionesT" name="txtObservacionesT" class="form-control" />
                                        </div>
                                    </div>
                                </div>  
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtConservCargoT">
                                            Conserv. a Cargo:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtConservCargoT" name="txtConservCargoT" class="form-control" />
                                        </div>
                                    </div>
                                </div>                                
                               <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha:</label>
                                    <div class="col-sm-2" id="Div11">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaT" name="txtFechaT" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                    </div>
                                </div> 
                              

                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarTrata6" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabDatosRegT" runat="server" >

                              <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                            Vista Inicial: </label>
                                        <div class="col-sm-4">
                                            <input type="file" id="file_iniT" name="file_iniT" />
                                            <div id="div_fileIniT">
                                            </div>
                                        </div>
                                    </div>
                                </div>  
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                            Vista Termino: </label>
                                        <div class="col-sm-4">
                                            <input type="file" id="file_finT" name="file_finT" />
                                            <div id="div_fileFinT">
                                            </div>
                                        </div>
                                    </div>
                                </div>  
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                            Vista Detalle: </label>
                                        <div class="col-sm-4">
                                            <input type="file" id="file_detalleT" name="file_detalleT" />
                                            <div id="div_fileDetT">
                                            </div>
                                        </div>
                                    </div>
                                </div>  
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                            Gráfico 1: </label>
                                        <div class="col-sm-4">
                                            <input type="file" id="file_graf1T" name="file_graf1T" />
                                            <div id="div_fileGraf1T">
                                            </div>
                                        </div>
                                    </div>
                                </div>  
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                            Gráfico 2: </label>
                                        <div class="col-sm-4">
                                            <input type="file" id="file_graf2T" name="file_graf2T" />
                                            <div id="div_fileGraf2T">
                                            </div>
                                        </div>
                                    </div>
                                </div>  

                                <div class="row"  style="display:none">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtFotoIniT">
                                            Foto Ini:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtFotoIniT" name="txtFotoIniT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row"  style="display:none">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtFotoFinT">
                                            Foto Fin:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtFotoFinT" name="txtFotoFinT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row"  style="display:none">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDetalleT">
                                            Detalle:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtDetalleT" name="txtDetalleT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarTrata7" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
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

<div class="modal fade " id="mdConfirmarPostTratamiento" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-jr">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Post Tratamiento</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="Li13" runat="server" ><a href="#tabIdentificacionPT" aria-controls="home" role="tab" data-toggle="tab" > Identificaci&oacute;n</a></li>
					    <li role="presentationlogin" id="Li14" runat="server" ><a href="#tabExcavacionPT" aria-controls="profile" role="tab" data-toggle="tab" > Excavaci&oacute;n</a></li>
                        <li role="presentationlogin" id="Li15" runat="server" ><a href="#tabFisicaDimensaionesPT" aria-controls="profile" role="tab" data-toggle="tab" > Descripci&oacute;n F&iacute;sica</a></li>
                        <li role="presentationlogin" id="Li16" runat="server" ><a href="#tabUbicacionActualPT" aria-controls="profile" role="tab" data-toggle="tab" > Datos Ubicaci&oacute;n</a></li>
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacionPT" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroFichaPT">
                                            N° Ficha [1-9]:</label>
                                        <div class="col-sm-2">
                                            <input type="text" id="txtNroFichaPT" name="txtNroFichaPT" class="form-control" onKeyPress="return soloNumeros(event,this)" onblur="AsignarEvalPT()"/>
                                        </div>
                                         <div class="col-sm-1">
                                            <button type="button" class="btn btn-green" id="btnBuscarPT" ><i class="ion-android-done"></i>&nbsp;Buscar</button>	
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodRegNacPT">
                                            Cod. Reg. Nacional:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodRegNacPT" name="txtCodRegNacPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodPropietarioPT" >
                                            Código de Propietario:</label>
                                        <div class="col-sm-2">
                                            <input type="text" id="txtCodPropietarioPT" name="txtCodPropietarioPT" class="form-control" />
                                        </div>
                                        <div class="col-sm-1">
                                            <div id="RepPDFPT">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodigoExcavacionPT">
                                            Otros Códigos:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodigoExcavacionPT" name="txtCodigoExcavacionPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodRestaurPT">
                                            Cod. Restauración:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodRestaurPT" name="txtCodRestaurPT" class="form-control" />
                                        </div>
                                    </div>     
                                </div>                                 
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarPostTrat1" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
                        <div role="tabpanel" class="tab-pane " id="tabExcavacionPT" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSectorPT">
                                            Sector:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtSectorPT" name="txtSectorPT" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUnidadPT">
                                            Unidad:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtUnidadPT" name="txtUnidadPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCapaPT">
                                            Capa:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCapaPT" name="txtCapaPT" class="form-control" />                
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNivelPT">
                                            Nivel:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtNivelPT" name="txtNivelPT" class="form-control" />                               
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCuadriculaPT">
                                            Cuadricula</label>
                                        <div class="col-sm-3">
                                             <input type="text" id="txtCuadriculaPT" name="txtCuadriculaPT" class="form-control" />             
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPlanoPT">
                                            Plano:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtPlanoPT" name="txtPlanoPT" class="form-control" />               
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtContextoPT">
                                            Contexto:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtContextoPT" name="txtContextoPT" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUbicContextoPT">
                                            Ubic. en el Contex.:
                                        </label>
                                        <div class="col-sm-3">   
                                             <input type="text" id="txtUbicContextoPT" name="txtUbicContextoPT" class="form-control" />         
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAlturaObsPT">
                                            Altura Absoluta:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAlturaObsPT" name="txtAlturaObsPT" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrosDatosPT">
                                            Otros Datos:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtOtrosDatosPT" name="txtOtrosDatosPT" class="form-control" />            
                                        </div>
                                    </div>
                                </div>
               
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarPostTrat2" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

                        </div>
                        <div role="tabpanel" class="tab-pane" id="tabFisicaDimensaionesPT" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtMaterialPT">
                                            Material:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtMaterialPT" name="txtMaterialPT" class="form-control" />
                                        </div>
                                    </div>
                                     <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDenominacionPT">
                                            Denomicación:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDenominacionPT" name="txtDenominacionPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                   <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDescripcionPT">
                                            Descripción:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDescripcionPT" name="txtDescripcionPT" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAltoPT">
                                            Alto [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtAltoPT" name="txtAltoPT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtLargoPT">
                                            Largo [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtLargoPT" name="txtLargoPT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAnchoPT">
                                            Ancho [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtAnchoPT" name="txtAnchoPT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row"> 
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtEspesorPT">
                                            Espesor [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtEspesorPT" name="txtEspesorPT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMaxPT">
                                            Diámetro Máx. [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamMaxPT" name="txtDiamMaxPT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row">  
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMinPT">
                                            Diámetro Min. [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamMinPT" name="txtDiamMinPT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                <div class="col-sm-2"></div>
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamBasePT">
                                            Diámetro Base [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtDiamBasePT" name="txtDiamBasePT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPesoPT">
                                            Peso [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtPesoPT" name="txtPesoPT" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                            </div>

                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarPostTrat3" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabUbicacionActualPT" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtUbicInmueblePT">
                                            Ubic. en el Inmueble:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtUbicInmueblePT" name="txtUbicInmueblePT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCajaPT">
                                            N° Caja:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtCajaPT" name="txtCajaPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtBolsaPT">
                                            N° Bolsa:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtBolsaPT" name="txtBolsaPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>                               
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtProblemPT">
                                            Problematica:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtProblemPT" name="txtProblemPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtVariacPT">
                                            Variac. mensual T°:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtVariacPT" name="txtVariacPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtReaccionesPT">
                                            Reacc. del bien:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtReaccionesPT" name="txtReaccionesPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPresAfectPT">
                                            Presenta Afectac.:</label>
                                        <div class="col-sm-2">
                                            <!--<input type="text" id="txtPresAfectPT" name="txtPresAfectPT" class="form-control" />-->
                                            <select class="form-control" id="txtPresAfectPT" name="txtPresAfectPT">
                                                <option value="0">-- Seleccione -- </option>
                                                <option value="SI">SI</option>
                                                <option value="NO">NO</option>
                                            </select> 
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTipoAfecPT">
                                            Tipo Afectac.:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtTipoAfecPT" name="txtTipoAfecPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCausaAfecPT">
                                            Causa Afectac.:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtCausaAfecPT" name="txtCausaAfecPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtRecomenPT">
                                            Recomendaciones:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtRecomenPT" name="txtRecomenPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtConseCargoPT">
                                            Conserv. a Cargo:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtConseCargoPT" name="txtConseCargoPT" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                             <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha:</label>
                                    <div class="col-sm-2" id="Div1">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaPT" name="txtFechaPT" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                    </div>
                                </div> 
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                            Vista Frontal: </label>
                                        <div class="col-sm-4">
                                            <input type="file" id="file_frontalPT" name="file_frontalPT" />
                                            <div id="div_frontalPT">
                                            </div>
                                        </div>
                                    </div>
                                </div>     
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarPostTrat4" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
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

<div class="modal fade " id="mdConfirmarAlmacenes" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-jr">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Almacenes</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="Li17" runat="server" ><a href="#tabCaracterA" aria-controls="home" role="tab" data-toggle="tab" > Caracteristica</a></li>
					    <li role="presentationlogin" id="Li18" runat="server" ><a href="#tabEquipamientoA" aria-controls="profile" role="tab" data-toggle="tab" > Equipamiento</a></li>
                        <li role="presentationlogin" id="Li19" runat="server" ><a href="#tabBienesA" aria-controls="profile" role="tab" data-toggle="tab" > Bienes</a></li>
                        <li role="presentationlogin" id="Li20" runat="server" ><a href="#tabMonitoreoA" aria-controls="profile" role="tab" data-toggle="tab" > Monitoreo</a></li>
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">
					    <div role="tabpanel" class="tab-pane active" id="tabCaracterA" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroFichaA">
                                            N° Ficha [1-9]:</label>
                                        <div class="col-sm-2">
                                            <input type="text" id="txtNroFichaA" name="txtNroFichaA" class="form-control" onKeyPress="return soloNumeros(event,this)" />
                                        </div>
                                        <div class="col-sm-1">
                                            <button type="button" class="btn btn-green" id="btnBuscarA"><i class="ion-android-done"></i>&nbsp;Buscar</button>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAmbMonitoreoA">
                                            Amb. Monitoreado:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAmbMonitoreoA" name="txtAmbMonitoreoA" class="form-control"  />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAreaA" >
                                            Área:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAreaA" name="txtAreaA" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTipoEstrA">
                                            Tipo Estructura:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtTipoEstrA" name="txtTipoEstrA" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtVentanasA">
                                            Ventanas:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtVentanasA" name="txtVentanasA" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>     
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTipoLuzA">
                                            Tipo Luz:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtTipoLuzA" name="txtTipoLuzA" class="form-control" />
                                        </div>
                                    </div>     
                                </div>                                
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarAlmac1" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
                        <div role="tabpanel" class="tab-pane " id="tabEquipamientoA" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTipoAireA">
                                            Tipo Aire:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtTipoAireA" name="txtTipoAireA" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCantAireA">
                                            Cant. Aire:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCantAireA" name="txtCantAireA" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTipoExtA">
                                            Tipo Extractor:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtTipoExtA" name="txtTipoExtA" class="form-control" />                
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCantExtA">
                                            Cant. Extractor:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtCantExtA" name="txtCantExtA" class="form-control" onkeypress="return soloNumeros(event,this)"/>                               
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCantThermA">
                                            Cant. Thermohigrometro</label>
                                        <div class="col-sm-3">
                                             <input type="text" id="txtCantThermA" name="txtCantThermA" class="form-control" onkeypress="return soloNumeros(event,this)"/>             
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDeshumeA">
                                            Deshumedecedor de amb.:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtDeshumeA" name="txtDeshumeA" class="form-control"  />               
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCantEstA">
                                            Cant. Estantes:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtCantEstA" name="txtCantEstA" class="form-control" onkeypress="return soloNumeros(event,this) " />               
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNivelEstA">
                                            Nivel Estantes:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNivelEstA" name="txtNivelEstA" class="form-control" onkeypress="return soloNumeros(event,this)" />
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="ttxCajaPlaA">
                                            Cajas Plastica:
                                        </label>
                                        <div class="col-sm-3">   
                                             <input type="text" id="ttxCajaPlaA" name="ttxCajaPlaA" class="form-control" onkeypress="return soloNumeros(event,this)" />         
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCajaCartonA">
                                            Cajas Cartón:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCajaCartonA" name="txtCajaCartonA" class="form-control" onkeypress="return soloNumeros(event,this)" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCajaMadA">
                                            Cajas Madera:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCajaMadA" name="txtCajaMadA" class="form-control" onkeypress="return soloNumeros(event,this)" />            
                                        </div>
                                    </div>
                                </div>
               
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarAlmac2" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

                        </div>
                        <div role="tabpanel" class="tab-pane" id="tabBienesA" runat="server" >
                             <div class="row">
                                  <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtColeccionA">
                                            Colección:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtColeccionA" name="txtColeccionA" class="form-control" />
                                        </div>
                                    </div>
                                    </div>
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtMaterialA">
                                            Material:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtMaterialA" name="txtMaterialA" class="form-control" />
                                        </div>
                                    </div>
                              </div>      
                                <div class="row">
                                   <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtOtrosA">
                                            Otros:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtOtrosA" name="txtOtrosA" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                
                           

                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarAlmac3" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>

				        </div>
                        <div role="tabpanel" class="tab-pane" id="tabMonitoreoA" runat="server" >
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha:</label>
                                    <div class="col-sm-2" id="Div16">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtFechaA" name="txtFechaA" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>
                                    </div>
                                </div> 
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtHraIngAA">
                                            Horas Ingreso AM.:</label>
                                        <div class="col-sm-1">
                                            <input type="time" id="txtHraIngAA" name="txtHraIngAA" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtHraSalAA">
                                            Horas Salida AM:</label>
                                        <div class="col-sm-1">
                                            <input type="time" id="txtHraSalAA" name="txtHraSalAA"class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPriTaCA">
                                            Primera T° C [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtPriTaCA" name="txtPriTaCA" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSegTaCA">
                                            Segunda T° C [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtSegTaCA" name="txtSegTaCA" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPriHa">
                                            Primera H %:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtPriHa" name="txtPriHa" class="form-control"  onkeypress="return soloNumeros(event,this)" />
                                        </div>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSegundaHa">
                                            Segunda H %:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtSegundaHa" name="txtSegundaHa" class="form-control" onkeypress="return soloNumeros(event,this)" />
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtHraIngPA">
                                            Horas Ingreso PM:</label>
                                        <div class="col-sm-1">
                                            <input type="time" id="txtHraIngPA" name="txtHraIngPA" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtHraSalPA">
                                            Horas Salida PM:</label>
                                        <div class="col-sm-1">
                                            <input type="time" id="txtHraSalPA" name="txtHraSalPA" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPriTpCA">
                                            Primera T° C [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtPriTpCA" name="txtPriTpCA" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSegTpCA">
                                            Segunda T° C [1-9]:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtSegTpCA" name="txtSegTpCA" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPrimeraHp">
                                            Primera H %:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtPrimeraHp" name="txtPrimeraHp" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-2"></div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSegundaHp">
                                            Segunda H %:</label>
                                        <div class="col-sm-1">
                                            <input type="text" id="txtSegundaHp" name="txtSegundaHp" class="form-control" onkeypress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtObsA">
                                            Observaciones:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtObsA" name="txtObsA" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtConservCargoA">
                                           Conserv. a Cargo </label>
                                        <div class="col-sm-2">
                                            <input type="text" id="txtConservCargoA" name="txtConservCargoA" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                </div>
                               
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarAlmac4" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
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

