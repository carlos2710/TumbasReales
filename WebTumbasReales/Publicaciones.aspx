<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Publicaciones.aspx.vb" Inherits="Publicaciones" %>

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
        fnResetDataTableTramite('tbPublicacion', 0, 'desc');
        fnLstCombos("TIT", "cbTipoBio");

        listarPublicaciones(0);
        tablaPublicaciones();

        $('#btnAgregarPublicacion').click(function () {
            limpia();
            $('.nav-tabs a[href="#tabIdentificacion"]').tab('show')
            $('div#mdConfirmarPublicacion').modal('show');
        });

        $("#btnGuardarPub1").click(fnGuardarParte1);
        $("#btnGuardarPub2").click(fnGuardarParte2);

        $("#btnDelReg").click(fnDelRegistro);
        permisos();

    });

    function permisos() {
        if ($("#tfu").val() == "3" || $("#tfu").val() == "5") {
            $("#btnAgregarPublicacion").hide();
            $("#btnGuardarPub1").hide();
            $("#btnGuardarPub2").hide();
            $("#btnDelReg").hide();
        } else {
            $("#btnAgregarPublicacion").show();
            $("#btnGuardarPub1").show();
            $("#btnGuardarPub2").show();
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
        $("input#param0").val("DelPublicacion");
        var form = $('#frmPublicaciones').serialize();
        $.ajax({
            type: "POST",
            url: "processmuseo.aspx",
            data: form,
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                listarPublicaciones(0);
                tablaPublicaciones();
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

    function listarPublicaciones(param1) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstPublicaciones", "param1": param1 },
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

    function tablaPublicaciones() {
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
                tb += '<center><a href="#" class="btn btn-green btn-xs" onclick="fnEditar(\'' + aData[i].numeroe + '\')" ><i class="ion-edit"></i></a>';
                tb += '<a href="#" class="btn btn-red btn-xs" onclick="fnBorrarG(\'' + aData[i].numeroe + '\',\'' + aData[i].codpropietario + '\')" ><i class="ion-android-cancel"></i></a></td>';
                tb += '</center></td>';
                tb += '<td style="text-align:center">' + aData[i].anio + '</td>';
                tb += '<td style="text-align:center">' + aData[i].denominacion + '</td>';
                tb += '<td style="text-align:center">' + aData[i].autores + '</td>';
                tb += '<td style="text-align:center">' + aData[i].contexto + '</td>';
                tb += '</tr>';
            }
        } else {
            tb = "";
        }
        fnDestroyDataTableDetalle('tbPublicacion');
        $('#pPublicacion').html(tb);
        fnResetDataTableTramite('tbPublicacion', 0, 'asc');
    }

    function fnEditar(c) {
        var x = fnBuscar(c);
        if (x >= 0) {
            $('#pub').val(aData[x].numeroe);
            $('#txtnro').val(aData[x].numero);
            $('#txtDenominacion').val(aData[x].denominacion);
            $('#txtCodPropietario').val(aData[x].codpropietario);
            $('#txtCodigoExcavacion').val(aData[x].codexcavacion);
            $('#txtSitio').val(aData[x].sitio);
            $('#txtContexto').val(aData[x].contexto);
            if (aData[x].presentabio == "") {
                $('#cbPresentaBio').val(0);
            }
            else {
                $('#cbPresentaBio').val(aData[x].presentabio);
            }
            if (aData[x].tipobio == "") {
                $('#cbTipoBio').val(0);
            }
            else {
                $('#cbTipoBio').val(aData[x].tipobio);
            }
            $('#txtAutor').val(aData[x].autores);
            $('#txtTitulo').val(aData[x].titulo);
            $('#txtAnioPub').val(aData[x].anio);
            $('#txtTituloLibro').val(aData[x].titulolibro);
            $('#txtEdicion').val(aData[x].edicion);
            $('#txtPaginas').val(aData[x].paginas);
            $('#txtNroFigura').val(aData[x].nrofigura);
            $('#txtVolumen').val(aData[x].volumen);
            $('#txtSeccion').val(aData[x].seccion);
            $('#txtFechaConsulta').val(aData[x].fechaconsulta.slice(0, 10));
            $('#txtDirElect').val(aData[x].direccionelect);
        }
        $('div#mdConfirmarPublicacion').modal('show');
        return true;
    }

    function fnBuscar(c) {
        var i;
        var j = -1;
        var l;
        l = aData.length;
        for (i = 0; i < l; i++) {
            if (aData[i].numeroe == c) {
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
        if ($("#txtDenominacion").val() == "") {
            mensaje = "Ingrese Denominación"
            sw = 1;
        }
        if ($("#txtnro").val() == "") {
            mensaje = "Ingrese Nro de Publicación"
            sw = 1;
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
            return false;
        } else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gPublicacion1");
            var form = $('#frmPublicaciones').serialize();
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
                        $('#pub').val(data[0].code);
                        listarPublicaciones(0);
                        tablaPublicaciones();
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
        if ($("#txtAnioPub").val() != "") {
            if ($("#txtAnioPub").val() > 6000) {
                mensaje = "Año de Publicacion debe ser menor a 6000";
                $("#txtAnioPub").select();
                sw = 1;
            }
        }
        if ($("#txtEdicion").val() != "") {
            if ($("#txtEdicion").val() > 9000) {
                mensaje = "Edición debe ser menor a 9000";
                $("#txtEdicion").select();
                sw = 1;
            }
        }
        if ($("#txtPaginas").val() != "") {
            if ($("#txtPaginas").val() > 9000) {
                mensaje = "Paginas debe ser menor a 9000";
                $("#txtPaginas").select();
                sw = 1;
            }
        }
        if ($("#txtNroFigura").val() != "") {
            if ($("#txtNroFigura").val() > 9000) {
                mensaje = "Nro Figura debe ser menor a 9000";
                $("#txtNroFigura").select();
                sw = 1;
            }
        }
        if ($("#txtVolumen").val() != "") {
            if ($("#txtVolumen").val() > 9000) {
                mensaje = "Volumen debe ser menor a 9000";
                $("#txtVolumen").select();
                sw = 1;
            }
        }
        if ($("#txtFechaConsulta").val() == "") {
            mensaje = "Ingrese Fecha de consulta"
            sw = 1;
        }
        if ($("#txtTitulo").val() == "") {
            mensaje = "Ingrese Titulo"
            sw = 1;
        }
        if ($("#cbTipoBio").val() == "0") {
            mensaje = "Seleccione tipo bibliografía"
            sw = 1;
        }
        if ($("#cbPresentaBio").val() == "0") {
            mensaje = "Seleccione Presenta bibliografía"
            sw = 1;
        }
        if ($("#pub").val() == "") {
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
            $("input#param0").val("gPublicacion2");
            var form = $('#frmPublicaciones').serialize();
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
                        $('#pub').val(data[0].code);
                        listarPublicaciones(0);
                        tablaPublicaciones();
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
        $('#pub').val("");
        $('#txtnro').val("");
        $('#txtDenominacion').val("");
        $('#txtCodPropietario').val("");
        $('#txtCodigoExcavacion').val("");
        $('#txtSitio').val("");
        $('#txtContexto').val("");
        $('#cbPresentaBio').val(0);
        $('#cbTipoBio').val(0);
        $('#txtAutor').val("");
        $('#txtTitulo').val("");
        $('#txtAnioPub').val("");
        $('#txtTituloLibro').val("");
        $('#txtEdicion').val("");
        $('#txtPaginas').val("");
        $('#txtNroFigura').val("");
        $('#txtVolumen').val("");
        $('#txtSeccion').val("");
        $('#txtFechaConsulta').val("");
        $('#txtDirElect').val("");
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

    <form id="frmPublicaciones" name="frmPublicaciones" runat="server">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="paramdgc" name="paramdgc" value="" runat="server" /> 
    <input type="hidden" id="pub" name="pub" value="" /> 
        <input type="hidden" id="tfu" name="tfu" value="" runat="server"/> 

        <div class="row">
    <div class="panel panel-piluku">

            <div class="panel-heading">
		        <h3 class="panel-title">
			        
                    <div class="col-md-6" align="left" >
                          <div id="titulo" runat="server"> PUBLICACIONES </div>  
                    </div>
                    <div class="col-md-5" align="right">
                            <button type="button" class="btn btn-white " id="btnExportarRep" runat="server" ><i class="ion-android-download"></i>&nbsp;Exportar Reporte</button>	
                    </div>

                       
                </h3>
	        </div>	  
	        <div class='table-responsive'>	        
                <div class='panel-body' >
                    <div class='table-responsive'>
                        <table class='display dataTable cell-border' id='tbPublicacion' style="width:95%;font-size:smaller">
                            <thead>
                            <tr>
                                    <th style="width:6%;text-align:center;"></th>
                                    <th style="width:15%;text-align:center;">Código Propietario</th>
                                    <th style="width:20%;text-align:center;">Denominación</th>
                                    <th style="width:10%;text-align:center;">Código excavación</th>
                                    <th style="width:10%;text-align:center;">Materia Prima</th>
                                </tr>
                                </thead>     
                                <tbody id ="pPublicacion" runat ="server">
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
                    <a href="#" id="btnAgregarPublicacion" class="btn btn-primary btn-lg" style="width:30%" ><i class="ion-android-done"></i>&nbsp;Agregar Publicación</a>                
                </center>
     
            </div> 
        </div>
    </div>


<div class="modal fade " id="mdConfirmarPublicacion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
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
					    <li role="presentationlogin" class="active" id="Li1" runat="server" ><a href="#tabIdentificacion" aria-controls="home" role="tab" data-toggle="tab" > Identificaci&oacute;n</a></li>
					    <li role="presentationlogin" id="Li2" runat="server" ><a href="#tabOrigen" aria-controls="profile" role="tab" data-toggle="tab" > Datos Origen</a></li>
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">
	
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacion" runat="server" >
                             <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtnro">
                                            N° [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtnro" name="txtnro" class="form-control" onKeyPress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDenominacion">
                                            Denominación:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDenominacion" name="txtDenominacion" class="form-control" />
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
                                        <label class="col-sm-2 control-label" for="txtSitio">
                                            Sitio:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtSitio" name="txtSitio" class="form-control"  />
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
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarPub1" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
                        <div role="tabpanel" class="tab-pane " id="tabOrigen" runat="server" >
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cbPresentaBio">
                                            Presenta bibliografía:</label>
                                        <div class="col-sm-3">
                                            <select class="form-control" id="cbPresentaBio" name="cbPresentaBio">
                                                <option value="0">-- Seleccione -- </option>
                                                <option value="1">Si</option>
                                                <option value="2">No</option>
                                                <option value="3">No Determinada</option>
                                            </select>    
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="cbTipoBio">
                                            Tipo bibliografía:</label>
                                        <div class="col-sm-3">
                                            <select class="form-control" id="cbTipoBio" name="cbTipoBio"></select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAutor">
                                            Autor(es):</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAutor" name="txtAutor" class="form-control" />             
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTitulo">
                                            Titulo en Libro/Revista:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtTitulo" name="txtTitulo" class="form-control" />                
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtAnioPub">
                                            Año Publicación [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtAnioPub" name="txtAnioPub" class="form-control"  onKeyPress="return soloNumeros(event,this)"/>                                                                      
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtTituloLibro">
                                            Titulo en libro:</label>
                                        <div class="col-sm-3">
                                              <input type="text" id="txtTituloLibro" name="txtTituloLibro" class="form-control" />              
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtEdicion">
                                            Edición/número :</label>
                                        <div class="col-sm-3">
                                                <input type="text" id="txtEdicion" name="txtEdicion" class="form-control" />               
                          
                                        </div>  
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtPaginas">
                                            Páginas [1-9]:</label>
                                        <div class="col-sm-3">
                                             <input type="text" id="txtPaginas" name="txtPaginas" class="form-control" onKeyPress="return soloNumeros(event,this)"/>         
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtNroFigura">
                                            Nro de Figura [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtNroFigura" name="txtNroFigura" class="form-control" onKeyPress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtVolumen">
                                            Volumen [1-9]:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtVolumen" name="txtVolumen" class="form-control" onKeyPress="return soloNumeros(event,this)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtSeccion">
                                            Lugar de Edición:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtSeccion" name="txtSeccion" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                        Fecha Consulta:</label>
                                        <div class="col-sm-2" id="Div17">
                                            <div class="input-group date">
									            <input type="text" class="form-control" id="txtFechaConsulta" name="txtFechaConsulta" data-provide="datepicker" />
									            <span class="input-group-addon bg">
										            <i class="ion ion-ios-calendar-outline"></i>
									            </span>
							                </div>	
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDirElect">
                                            Direc. Electrónica:</label>
                                        <div class="col-sm-3">
                                            <input type="text" id="txtDirElect" name="txtDirElect" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                      
               
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarPub2" ><i class="ion-android-done"></i>&nbsp;Guardar</button>	
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
