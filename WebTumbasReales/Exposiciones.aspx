<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Exposiciones.aspx.vb" Inherits="Exposiciones" %>

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

    jQuery(document).ready(function () {
        fnResetDataTableTramite('tbExposicion', 0, 'desc');
        //fnLstCombos("TIT", "cbTipoBio");

        listarExposiciones(0);
        tablaExposiciones();

        $('#btnAgregarPublicacion').click(function () {
            limpia();
            $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            $('div#mdConfirmarExposicion').modal('show');
        });

        $("#btnGuardarExp1").click(fnGuardarParte1);
        $("#btnGuardarExp2").click(fnGuardarParte2);

        $("#btnDelReg").click(fnDelRegistro);

        permisos();

    });

    function permisos() {
        if ($("#tfu").val() == "3" || $("#tfu").val() == "5") {
            $("#btnAgregarPublicacion").hide();
            $("#btnGuardarExp1").hide();
            $("#btnGuardarExp2").hide();
            $("#btnDelReg").hide();
        } else {
            $("#btnAgregarPublicacion").show();
            $("#btnGuardarExp1").show();
            $("#btnGuardarExp2").show();
            $("#btnDelReg").show();
        }
    }

    function fnBorrarG(c, d) {
        $("#param1").val(c);
        $("#Dato").html("<label class='col-md-12 control-label'> Desea Confirmar la Eliminaci&oacute;n del Registro: " + d + "</label>");
        $('div#mdDelRegistro').modal('show');
        return true;
    }

    function fnDelRegistro() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("DelExposicion");
        var form = $('#frmExposiciones').serialize();
        $.ajax({
            type: "POST",
            url: "processmuseo.aspx",
            data: form,
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarExposiciones(0);
                tablaExposiciones();
                $('.piluku-preloader').addClass('hidden');
            },
            error: function (result) {
                $('.piluku-preloader').addClass('hidden');
                f_Menu("Publicaciones.aspx");
            }
        });
        //document.getElementById("param0").value = "";
        $("#param0").val("");
        $('div#mdDelRegistro').modal('hide');
    }

    function listarExposiciones(param1) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstExposiciones", "param1": param1 },
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

    function tablaExposiciones() {
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
                tb += '<center><a href="#" class="btn btn-green btn-xs" onclick="fnEditar(\'' + aData[i].numero + '\')" ><i class="ion-edit"></i></a>';
                tb += '<a href="#" class="btn btn-red btn-xs" onclick="fnBorrarG(\'' + aData[i].numero + '\',\'' + aData[i].codpropietario + '\')" ><i class="ion-android-cancel"></i></a></td>';
                tb += '</center></td>';
                tb += '<td style="text-align:center">' + aData[i].salida.slice(0, 10) + '</td>';
                tb += '<td style="text-align:center">' + aData[i].denominacion + '</td>';
                tb += '<td style="text-align:center">' + aData[i].pais + '</td>';
                tb += '<td style="text-align:center">' + aData[i].contexto + '</td>';
                tb += '</tr>';
            }
        } else {
            tb = "";
        }
        fnDestroyDataTableDetalle('tbExposicion');
        $('#pExposicion').html(tb);
        fnResetDataTableTramite('tbExposicion', 0, 'asc');
    }

    function fnEditar(c) {
        var x = fnBuscar(c);
        if (x >= 0) {
            $('#exp').val(aData[x].numero);
            $('#txtnro').val(aData[x].numeroe);
            $('#txtRegNac').val(aData[x].codregnac);
            $('#txtCodPropietario').val(aData[x].codpropietario);
            $('#txtCodigoExcavacion').val(aData[x].codexcavacion);
            $('#txtOtrosCod').val(aData[x].otroscodigos);
            $('#txtDenominacion').val(aData[x].denominacion);
            $('#txtSitio').val(aData[x].sitio);
            $('#txtContexto').val(aData[x].contexto);
            $('#txtNombreExp').val(aData[x].nombre);
            $('#txtLugar').val(aData[x].lugar);
            $('#txtPais').val(aData[x].pais);
            $('#txtInmueble').val(aData[x].inmueble);
            $('#txtResolucion').val(aData[x].resolucacion);
            $('#txtInstitucion').val(aData[x].institucion);
            $('#txtComisario').val(aData[x].comisario);
            $('#txtSalida').val(aData[x].salida.slice(0, 10));
            $('#txtRetorno').val(aData[x].retorno.slice(0, 10));
            $('#txtPoliza').val(aData[x].nropiliza);
            $('#txtMonto').val(aData[x].monto_exp);
        }
        $('div#mdConfirmarExposicion').modal('show');
        return true;
    }

    function fnBuscar(c) {
        var i;
        var j = -1;
        var l;
        l = aData.length;
        for (i = 0; i < l; i++) {
            if (aData[i].numero == c) {
                j = i;
                return j;
            }
        }
    }

    function fnGuardarParte1() {
        var sw = 0;
        var mensaje = "";
        if ($("#txtCodigoExcavacion").val() == "") {
            mensaje = "Codigo de Excavación"
            sw = 1;
        }
        if ($("#txtCodPropietario").val() == "") {
            mensaje = "Codigo de Propietario"
            sw = 1;
        }
        if ($("#txtRegNac").val() == "") {
            mensaje = "Ingrese Código de Reg. Nacional"
            sw = 1;
        }
        if ($("#txtnro").val() == "") {
            mensaje = "Ingrese Nro de Exposición"
            sw = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gExposicion1");
            var form = $('#frmExposiciones').serialize();
            $.ajax({
                type: "POST",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#exp').val(data[0].code);
                        listarExposiciones(0);
                        tablaExposiciones();
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

    function fnGuardarParte2() {
        var sw = 0;
        var swTab = 1;
        var mensaje = "";
        if ($("#txtRetorno").val() == "") {
            mensaje = "Ingrese Retorno"
            sw = 1;
        }
        if ($("#txtSalida").val() == "") {
            mensaje = "Ingrese Salida"
            sw = 1;
        }
        if ($("#txtMonto").val() == "") {
            mensaje = "Ingrese Monto"
            sw = 1;
        }
        if ($("#txtPoliza").val() == "") {
            mensaje = "Ingrese Póliza"
            sw = 1;
        }
        if ($("#txtComisario").val() == "") {
            mensaje = "Ingrese Comisario"
            sw = 1;
        }
        if ($("#txtInstitucion").val() == "") {
            mensaje = "Ingrese Institución solicitante"
            sw = 1;
        }
        if ($("#txtResolucion").val() == "") {
            mensaje = "Ingrese Resolución"
            sw = 1;
        }
        if ($("#txtInmueble").val() == "") {
            mensaje = "Ingrese Inmueble de la Exposición"
            sw = 1;
        }
        if ($("#txtPais").val() == "") {
            mensaje = "Ingrese Pais de la Exposición"
            sw = 1;
        }
        if ($("#txtLugar").val() == "") {
            mensaje = "Ingrese Nombre de Lugar"
            sw = 1;
        }
        if ($("#txtNombreExp").val() == "") {
            mensaje = "Ingrese Nombre de Exposición"
            sw = 1;
        }
        if ($("#txtContexto").val() == "") {
            mensaje = "Ingrese Contexto"
            sw = 1;
        }
        if ($("#txtSitio").val() == "") {
            mensaje = "Ingrese Sitio"
            sw = 1;
        }
        if ($("#txtDenominacion").val() == "") {
            mensaje = "Ingrese Denominación"
            sw = 1;
        }
        if ($("#exp").val() == "") {
            mensaje = "Debe Registrar primero pestaña de IDENTIFICACIÓN"
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
            $("input#param0").val("gExposicion2");
            var form = $('#frmExposiciones').serialize();
            $.ajax({
                type: "POST",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {
                    if (data[0].alert == "success") {
                        fnMensaje(data[0].alert, data[0].msje);
                        $('#exp').val(data[0].code);
                        listarExposiciones(0);
                        tablaExposiciones();
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

    function fnLstCombos(param1, combo) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "CboPublicaciones", "param1": param1 },
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

    function limpia() {
        $('#exp').val("");
        $('#txtnro').val("");
        $('#txtRegNac').val("");
        $('#txtCodPropietario').val("");
        $('#txtCodigoExcavacion').val("");
        $('#txtOtrosCod').val("");
        $('#txtDenominacion').val("");
        $('#txtSitio').val("");
        $('#txtContexto').val("");
        $('#txtNombreExp').val("");
        $('#txtLugar').val("");
        $('#txtPais').val("");
        $('#txtInmueble').val("");
        $('#txtResolucion').val("");
        $('#txtInstitucion').val("");
        $('#txtComisario').val("");
        $('#txtSalida').val("");
        $('#txtRetorno').val("");
        $('#txtPoliza').val("");
        $('#txtMonto').val("");
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

    <form id="frmExposiciones" name="frmExposiciones" runat="server">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="paramdgc" name="paramdgc" value="" runat="server" /> 
    <input type="hidden" id="exp" name="exp" value="" /> 
    <input type="hidden" id="tfu" name="tfu" value="" runat="server"/> 

        <div class="row">
    <div class="panel panel-piluku">

            <div class="panel-heading">
		        <h3 class="panel-title">
			        
                    <div class="col-md-6" align="left" >
                          <div id="titulo" runat="server"> EXPOSICIONES </div>  
                    </div>
                    <div class="col-md-5" align="right">
                            <button type="button" class="btn btn-white " id="btnExportarRep" runat="server" ><i class="ion-android-download"></i>&nbsp;Exportar Reporte</button>	
                    </div>

                       
                </h3>
	        </div>	  
	        <div class='table-responsive'>	        
                <div class='panel-body' >
                    <div class='table-responsive'>
                        <table class='display dataTable cell-border' id='tbExposicion' style="width:95%;font-size:smaller">
                            <thead>
                            <tr>
                                    <th style="width:6%;text-align:center;"></th>
                                    <th style="width:15%;text-align:center;">FECHA</th>
                                    <th style="width:20%;text-align:center;">DENOMINACION</th>
                                    <th style="width:10%;text-align:center;">PAIS EXPOSICION</th>
                                    <th style="width:10%;text-align:center;">CONTEXTO</th>
                                </tr>
                                </thead>     
                                <tbody id ="pExposicion" runat ="server">
                                </tbody>                             
                                <tfoot>
                                <tr>
                                <th colspan="5"></th>
                                </tr>
                                </tfoot>
                        </table>
                    </div>              
                </div> 
                <center>                        
                    <a href="#" id="btnAgregarPublicacion" class="btn btn-primary btn-lg" style="width:30%" ><i class="ion-android-done"></i>&nbsp;Agregar Exposición</a>                
                </center>
     
            </div> 
        </div>
    </div>


<div class="modal fade " id="mdConfirmarExposicion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-jr">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Publicación</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="Li1" runat="server" ><a href="#tabIdentificacion" aria-controls="home" role="tab" data-toggle="tab" > IDENTIFICACI&Oacute;N</a></li>
					    <li role="presentationlogin" id="Li2" runat="server" ><a href="#tabOrigen" aria-controls="profile" role="tab" data-toggle="tab" > DATOS DEL BIEN Y EXPOSICIÓN</a></li>
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">
	
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacion" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtnro">
                                            N° Ficha [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtnro" name="txtnro" class="form-control" onKeyPress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtRegNac">
                                           Cod. Registro Nac.:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtRegNac" name="txtRegNac" class="form-control" onkeypress="return soloNumeros(event,this)"/>
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
                                        <label class="col-sm-2 control-label" for="txtOtrosCod" >
                                            Otros Códigos:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtOtrosCod" name="txtOtrosCod" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                               
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarExp1" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
                        <div role="tabpanel" class="tab-pane " id="tabOrigen" runat="server" >
                                 <div class="row">
                                     <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDenominacion">
                                            Denominación:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDenominacion" name="txtDenominacion" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSitio">
                                            Sitio:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtSitio" name="txtSitio" class="form-control"  />
                                        </div>
                                    </div>
                                    
                                </div>
                            <div class="row">
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtContexto">
                                            Contexto:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtContexto" name="txtContexto" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNombreExp">
                                            Nombre:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNombreExp" name="txtNombreExp" class="form-control"  />
                                        </div>
                                    </div>
                                    
                                </div>
                            <div class="row">
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtLugar">
                                            Lugar:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtLugar" name="txtLugar" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPais">
                                            Pais:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtPais" name="txtPais" class="form-control"  />
                                        </div>
                                    </div>
                                    
                                </div>
                            <div class="row">
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtInmueble">
                                            Inmueble:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtInmueble" name="txtInmueble" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtResolucion">
                                            Resolución:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtResolucion" name="txtResolucion" class="form-control"  />
                                        </div>
                                    </div>
                                    
                                </div>
                            <div class="row">
                                <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtInstitucion">
                                            Institución:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtInstitucion" name="txtInstitucion" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtComisario">
                                            Comisario:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtComisario" name="txtComisario" class="form-control"  />
                                        </div>
                                    </div>
                                    
                                </div>
                            <div class="row">
                                    <label class="col-sm-2 control-label">
                                        Salida:</label>
                                    <div class="col-sm-3" id="Div1">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtSalida" name="txtSalida" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>	
                                    </div>
                                    <label class="col-sm-2 control-label">
                                        Retorno:</label>
                                    <div class="col-sm-3" id="Div2">
                                        <div class="input-group date">
									        <input type="text" class="form-control" id="txtRetorno" name="txtRetorno" data-provide="datepicker" />
									        <span class="input-group-addon bg">
										        <i class="ion ion-ios-calendar-outline"></i>
									        </span>
							            </div>	
                                    </div>
                                </div>
                             <div class="row">
                                 <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPoliza">
                                            Nro Poliza:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtPoliza" name="txtPoliza" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtMonto">
                                            Monto [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtMonto" name="txtMonto" class="form-control"  onKeyPress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarExp2" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
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
