<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GrupoColecciones.aspx.vb" Inherits="GrupoColecciones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>	.: AVA - SIP&Aacute;N :.</title>
    <script type="text/javascript" src='assets/js/jquery.dataTables.min.js'></script>
    <link rel='stylesheet' href='assets/css/jquery.dataTables.min.css'/>   
    <script src='assets/js/funcionesDataTable.js?y=1'></script>

    <script src="assets/js/bootstrap-datepicker.js" type="text/javascript"></script>
    
    <link rel='stylesheet' href='assets/css/validaform.css'/> 

<script  type="text/javascript" >

    var aData = [];

    jQuery(document).ready(function () {
        fnResetDataTableTramite('tbCatalogo', 0, 'desc');
        fnLstCombos("PER", "cboPeriodo");
        fnLstCombos("CRO", "cboCronologia");
        fnLstCombos("GEO", "cboGeografica");
        fnLstCombos("CLA", "cboClasificacion");
        fnLstCombos("CUS", "cbocustodio");
        fnLstCombos("ADQ", "cboAquisicion");
        fnLstCombos("DOC", "cboDocumentos");

        fnLstCatalogos();

        $('#btnAgregarCatalogo').click(function () {
            limpia();
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

    });

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
        $('#txtCodRegNac').val("");
        $('#txtCodPropietario').val("");
        $('#txtCodigoExcavacion').val("");
        $('#txtRegINC').val("");
        $('#txtInvINVC').val("");
        $('#txtOtrosCod').val("");
    }

    function fnBorrarG(c) {
        $("#param1").val(c);
        $("#Dato").html("<label class='col-md-12 control-label'> Desea Confirmar la Eliminaci&oacute;n del Registro: " + c + "</label>");
        $('div#mdDelRegistro').modal('show');
        return true;
    }

    function fnBuscar(c) {
        var i;
        var j = -1;
        var l;
        l = aData.length;
        for (i = 0; i < l; i++) {
            if (aData[i].id == c) {
                j = i;
                return j;
            }
        }
    }

    function fnEditar(c) {
        var x = fnBuscar(c);
        if (x >= 0) {
            $('#cat').val(aData[x].id);
            $('#txtCodRegNac').val(aData[x].codregnac);
            $('#txtCodPropietario').val(aData[x].id);
            $('#txtCodigoExcavacion').val(aData[x].codexcavacion);
            $('#txtRegINC').val(aData[x].codreginc);
            $('#txtInvINVC').val(aData[x].codinvinc);
            $('#txtOtrosCod').val(aData[x].otrocodigos);
        }
        $('div#mdConfirmarCatalogo').modal('show');
        return true;
    }

    function fnDelRegistro() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("DelCatalogo");
        var form = $('#frmCatalogo').serialize();
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: form,
            dataType: "json",
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                $('.piluku-preloader').addClass('hidden');
                f_Menu("information.aspx");
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

    function fnGuardarParte1() {
        var sw = 0;
        var mensaje = "";
        if ($("#txtCodPropietario").val() == "") {
            mensaje = "Codigo de Propietario"
            sw = 1;
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
            var form = $('#frmCatalogo').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                success: function (data) {
                    fnMensaje(data[0].alert, data[0].msje);
                    $('#cat').val(data[0].code);
                    $('.piluku-preloader').addClass('hidden');
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

    function fnGuardarParte2() {
        var sw = 0;
        var swTab = 0;
        var mensaje = "";
        if ($("#cboExcavacion").val() == 0) {
            mensaje = "Seleccione Margen"
            sw = 1;
        }
        if ($("#cboMargen").val() == 0) {
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
        if ($("#cboGeografica").val() == 0) {
            mensaje = "Seleccione Área Geográfica"
            sw = 1;
        }
        if ($("#cboCronologia").val() == 0) {
            mensaje = "Seleccione Cronologia"
            sw = 1;
        }
        if ($("#cboPeriodo").val() == 0) {
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
            swTab = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            if (swTab = 1) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gCatalogo2");
            var form = $('#frmCatalogo').serialize();
            alert("entra");
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                success: function (data) {
                    fnMensaje(data[0].alert, data[0].msje);
                    $('.piluku-preloader').addClass('hidden');
                    //f_Menu("gytegresado.aspx");
                },
                error: function (result) {
                    //f_Menu("gytegresado.aspx");
                    fnMensaje(data[0].alert, data[0].msje);
                    console.log(result);

                    //$('.piluku-preloader').addClass('hidden');
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
            if (swTab = 1) {
                $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            }
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gCatalogo3");
            var form = $('#frmCatalogo').serialize();
            alert("entra");
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                success: function (data) {
                    fnMensaje(data[0].alert, data[0].msje);
                    $('.piluku-preloader').addClass('hidden');
                    //f_Menu("gytegresado.aspx");
                },
                error: function (result) {
                    //f_Menu("gytegresado.aspx");
                    fnMensaje(data[0].alert, data[0].msje);
                    console.log(result);

                    //$('.piluku-preloader').addClass('hidden');
                }
            });
        }
        $("#param0").val("");
    }

    function fnGuardarParte4() {

    }

    function fnGuardarParte5() {

    }

    function fnGuardarParte6() {

    }

    function fnGuardarParte7() {

    }

    function soloNumeros(e) {
        var key = window.Event ? e.which : e.keyCode
        return (key >= 48 && key <= 57)
    }

</script>


</head>

<body  >

    <form id="frmCatalogo" name="frmCatalogo">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="cat" name="cat" value="" /> 

    <div class="panel panel-piluku">
        <div class="panel-heading">
		    <h3 class="panel-title">
			        CATALOGOS        
		    </h3>
	    </div>	  
	    <div class='table-responsive'>	        
        <div class='panel-body' >
            <div class='table-responsive'>
                <table class='display dataTable cell-border' id='tbCatalogo' style="width:100%;font-size:smaller">
                    <thead>
                    <tr>
                            <th style="width:6%;text-align:center;"></th>
                            <th style="width:8%;">Cod Reg Nac</th>
                            <th style="width:8%;">Cod Excavacion</th>
                            <th style="width:8%;">Cod Reg INC</th>
                            <th style="width:25%;">Cod INV</th>
                            <th style="width:25%;">Otro Codigos</th>
                        </tr>
                        </thead>     
                        <tbody id ="pDatosGradoEgresado" runat ="server">
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
                <a href="#" id="btnAgregarCatalogo" class="btn btn-primary btn-lg" style="width:30%" ><i class="ion-android-done"></i>&nbsp;Agregar Catalogo</a>                
            </center>
                </br>  
                                
    </div> 
    </div>


<div class="modal fade " id="mdConfirmarCatalogo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-jr">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#000000;" >
			<button type="button" class="
                " data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Catálogo</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="Li1" runat="server" ><a href="#tabIdentificacion" aria-controls="home" role="tab" data-toggle="tab" '> Identificaci&oacute;n</a></li>
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
                                            Cod. Reg. Nacional [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCodRegNac" name="txtCodRegNac" class="form-control"  />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCodPropietario">
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
                                            <input type="text" id="txtRegINC" name="txtRegINC" class="form-control" onKeyPress="return soloNumeros(event)" />
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
                                            Cultura:</label>
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
                                            Excavación:</label>
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
                                            Nivel [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNivel" name="txtNivel" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtCuadricula">
                                            Cuadr&iacute;cula [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtCuadricula" name="txtCuadricula" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPlano">
                                            Plano [1-9]:</label>
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
                                            Decorativo:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDecorativo" name="txtDecorativo" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAlto">
                                            Alto [9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAlto" name="txtAlto" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtLargo">
                                            Largo [9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtLargo" name="txtLargo" class="form-control" />
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAncho">
                                            Ancho [9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAncho" name="txtAncho" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtEspesor">
                                            Espesor [9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtEspesor" name="txtEspesor" class="form-control" />
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMax">
                                            Diámetro Máx. [9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDiamMax" name="txtDiamMax" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamMin">
                                            Diámetro Min. [9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDiamMin" name="txtDiamMin" class="form-control" />
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDiamBase">
                                            Diámetro Base [9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDiamBase" name="txtDiamBase" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPeso">
                                            Peso [9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtPeso" name="txtPeso" class="form-control" />
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
                                        <div class="col-sm-4">
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
                                        <div class="col-sm-4">
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
                                        <div class="col-sm-4">            
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
                                            Ubicación Inmueble:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtUbicacionInmueble" name="txtUbicacionInmueble" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboSituacion">
                                            Situación:</label>
                                        <div class="col-sm-4">
                                            <select class="form-control" id="cboSituacion" name="cboSituacion">
                                                   <option value="0">-- Seleccione -- </option>
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
                                            N° Caja o Contenedor:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtCajaContenedor" name="txtCajaContenedor" class="form-control" />
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
                                            Ficha Campo Elaborada:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtFichaCampo" name="txtFichaCampo" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha Ficha Campo:</label>
                                    <div class="col-sm-3" id="Div17">
                                        <div id="Div18">
                                        </div>
                                        <div class="input-group date">
                                            <input name="txtFechaFichaC" class="form-control" id="txtFechaFichaC" style="text-align: right;"
                                                type="text" placeholder="__/__/____" data-provide="datepicker" />
                                            <span class="input-group-addon sm"><i class="ion ion-ios-calendar-outline" id="I3">
                                            </i></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtFotoTomada">
                                            Fotografía Tomada:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtFotoTomada" name="txtFotoTomada" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha Toma Fotografía:</label>
                                    <div class="col-sm-3" id="Div19">
                                        <div id="Div20">
                                        </div>
                                        <div class="input-group date">
                                            <input name="txtFechaTomaFoto" class="form-control" id="txtFechaTomaFoto" style="text-align: right;"
                                                type="text" placeholder="__/__/____" data-provide="datepicker" />
                                            <span class="input-group-addon sm"><i class="ion ion-ios-calendar-outline" id="I4">
                                            </i></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cboDocumentos">
                                            Tipo Documento:</label>
                                        <div class="col-sm-4">
                                            <select class="form-control" id="cboDocumentos" name="cboDocumentos"></select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroDoc">
                                            Nro Documento:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtNroDoc" name="txtNroDoc" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Fecha Documento:</label>
                                    <div class="col-sm-3" id="Div21">
                                        <div id="Div22">
                                        </div>
                                        <div class="input-group date">
                                            <input name="txtFechaDoc" class="form-control" id="txtFechaDoc" style="text-align: right;"
                                                type="text" placeholder="__/__/____" data-provide="datepicker" />
                                            <span class="input-group-addon sm"><i class="ion ion-ios-calendar-outline" id="I5">
                                            </i></span>
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
		<div class="modal-header" style="background-color:#000000;" >
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
