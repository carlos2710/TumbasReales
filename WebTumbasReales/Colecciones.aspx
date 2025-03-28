<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Colecciones.aspx.vb" Inherits="Colecciones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>	.: Colecciones :.</title>
    <script type="text/javascript" src='assets/js/jquery.dataTables.min.js'></script>
    <link rel='stylesheet' href='assets/css/jquery.dataTables.min.css'/>   
    <script src='assets/js/funcionesDataTable.js?y=2'></script>

    <script src="assets/js/bootstrap-datepicker.js" type="text/javascript"></script>
    
    <link rel='stylesheet' href='assets/css/validaform.css'/> 

<script  type="text/javascript" >
    var aDataC = [];   

    jQuery(document).ready(function () {
        fnResetDataTableTramite('tbColecciones', 0, 'desc');
        $('#btnAgregarColeccion').click(function () {
            var sw = 0;
            var mensaje = "";
            limpia();
            $("input#param1").val("0");
            var nombre = $('select[name="cboGrupoCole"] option:selected').text();
            if (nombre == "-- Seleccione --") {
                sw = 1;
                mensaje = "Debe seleccionar una Colección";
            }
            if (sw == 1) {
                fnMensaje("error", mensaje);
            }
            else {
                $("#txtGrupoCol").val(nombre);
                $('div#mdMenu').modal('show');
            }
        });

        $("#cboGrupoCole").change(function () {
            fnLstColeccionesGrupo($('#cboGrupoCole').val());
            fnTablaColeccionesGrupo();
        });

        fnLstColecciones();
        
        $("#btnGuardarMenu").click(fnGuardarMenu);
   
        $("#btnDelReg").click(fnDelRegistro);

        permisos();

    });

    function permisos() {
        if ($("#tfu").val() == "3" || $("#tfu").val() == "5") {
            $("#btnAgregarColeccion").hide();
            $("#btnGuardarMenu").hide();
            $("#btnDelReg").hide();
        } else {
            $("#btnAgregarColeccion").show();
            $("#btnGuardarMenu").show();
            $("#btnDelReg").show();
        }
    }

    function fnDelRegistro() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("DelColeccion");
        var form = $('#frmColecciones').serialize();
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "DelColeccion", "param1": $("#param1").val() },
            dataType: "json",
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                fnLstColeccionesGrupo($('#cboGrupoCole').val());
                fnTablaColeccionesGrupo();
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

    function fnGuardarMenu() {
        //JAZ
        var sw = 0;
        var mensaje = "";
        if ($("#txtColeccion").val() == "") {
            sw = 1;
            mensaje = "Debe especificar el nombre del nuevo sitio";
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
        }
        else {
        //JAZ
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gColeccion");
            var form = $('#frmColecciones').serialize();
            $.ajax({
                type: "POST",
                //contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {
                    fnMensaje(data[0].alert, data[0].msje);
                    fnLstColeccionesGrupo($('#cboGrupoCole').val());
                    fnTablaColeccionesGrupo();
                    $('div#mdMenu').modal('hide');
                    $('.piluku-preloader').addClass('hidden');

                },
                error: function (result) {
                    fnMensaje(data[0].alert, data[0].msje);
                    //console.log(result);
                    $('.piluku-preloader').addClass('hidden');
                }
            });
        }
    }

    function limpia() {
        $("#txtGrupoCol").val("");
        $("#txtColeccion").val("");
    }

    function fnBorrar(c, d) {
        $("#param1").val(c);
        $("#Dato").html("<label class='col-md-12 control-label'> Desea Confirmar la Eliminaci&oacute;n del Registro: " + d + "</label>");
        $('div#mdDelRegistro').modal('show');
        return true;
    }

    function fnEditar(c) {
        var x = fnBuscar(c);
        if (x >= 0) {
            $("#param1").val(aDataC[x].dgc);
            $("#txtGrupoCol").val(aDataC[x].dgco);
            $("#txtColeccion").val(aDataC[x].ddgc);
            
        }
        $('div#mdMenu').modal('show');
        return true;
    }

    function fnBuscar(c) {
        var i;
        var j = -1;
        var l;
        l = aDataC.length;
        for (i = 0; i < l; i++) {
            if (aDataC[i].dgc == c) {
                j = i;
                return j;
            }
        }
    }

    function fnLstColeccionesGrupo(param1) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstColeccionesXGrupo", "param1": param1 },
            dataType: "json",
            async: false,
            success: function (data) {
                aDataC = data;
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function fnTablaColeccionesGrupo() {
        var tb = '';
        var i = 0;
        var contador = 0;
        if (aDataC.length > 0) {
            for (i = 0; i < aDataC.length; i++) {
                contador = contador + 1;
                tb += '<tr>';
                tb += '<td>';
                tb += '<center><a href="#" class="btn btn-green btn-xs" onclick="fnEditar(\'' + aDataC[i].dgc + '\')" ><i class="ion-edit"></i></a>';
                tb += '<a href="#" class="btn btn-red btn-xs" onclick="fnBorrar(\'' + aDataC[i].dgc + '\',\'' + aDataC[i].ddgc + '\')" ><i class="ion-android-cancel"></i></a></td>';
                tb += '</center></td>';
                tb += '<td style="text-align:center">' + aDataC[i].dgco + '</td>';
                tb += '<td style="text-align:center">' + aDataC[i].ddgc + '</td>';
                tb += '</tr>';
            }
        } else {
            tb = "";
        }
        fnDestroyDataTableDetalle('tbColecciones');
        $('#pColecciones').html(tb);
        fnResetDataTableTramite('tbColecciones', 0, 'asc');

    }

    function fnLstColecciones() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "cboReportes", "param1": "GCO" },
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
                $('#cboGrupoCole').html(t);
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function soloNumeros(e) {
        var key = window.Event ? e.which : e.keyCode
        return (key >= 48 && key <= 57)
    }
    
    </script>


</head>

<body  class="" runat="server" id="bodyPrincipal" >

    <form id="frmColecciones" name="frmColecciones">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="tfu" name="tfu" value="" runat="server"/> 

    <div class="panel panel-piluku">
        <div class="panel-heading">
		    <h3 class="panel-title">
			        COLECCIONES        
		    </h3>
	    </div>	  
	    <div class='table-responsive'>	        
            <div class='panel-body' >
                 <div role="tabpanel" >
                     <div class="row">
                        <div class="form-group">
                            <center>
                            <label class="col-sm-2 control-label" for="cboGrupoCole">
                                Grupo de Colecciones</label>
                            <div class="col-sm-2">
                                <select class="form-control" id="cboGrupoCole" name="cboGrupoCole"></select> 
                            </div>
                            </center>
                        </div>
                    </div>
                     <div class="row">
                        <div class="form-group">
                            <div class='table-responsive'>
                                <table class='display dataTable cell-border' id='tbColecciones' style="width:100%;font-size:smaller">
                                    <thead>
                                    <tr>
                                        <th style="width:6%;text-align:center;"></th>
                                        <th style="width:6%;text-align:center;">Item</th>
                                        <th style="width:25%;text-align:center;">Descripcion</th>
                                      </tr>
                                    </thead>     
                                    <tbody id ="pColecciones" runat ="server">
                                    </tbody>                             
                                    <tfoot>
                                        <tr>
                                            <th colspan="3"></th>
                                        </tr>
                                    </tfoot>
                                </table>

                            </div>  
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnAgregarColeccion" ><i class="ion-android-add-circle"></i>&nbsp;Agregar Colección</button>	
		                           </div>
		                      </center>
		                    </div>
                        </div>
                    </div> 
                    
	            </div>    
            </div> 
        <br/>  
                                
        </div> 


<div class="modal fade" id="mdMenu" role="dialog" aria-labelledby="myModalLabel" style="z-index: 5;" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;">
                        <div class="modal-dialog modal-lg" id="Div5">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<%--<h4 class="modal-title"  style="color:White">Registrar/Actualizar Men&uacute;</h4> JAZ--%>
            <h4 class="modal-title"  style="color:White">Registrar/Actualizar S&iacutetio;</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <div class="tab-content piluku-tab-content">
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacion" runat="server" >
                             <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtGrupoCol">
                                        Grupo colección:</label>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtGrupoCol" name="txtGrupoCol" class="form-control" readonly="true"/>
                                    </div>
                                </div>
                                </div>
                                <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtColeccion">
                                        Descripción del S&iacutetio:</label>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtColeccion" name="txtColeccion" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarMenu" ><i class="ion-android-done"></i>&nbsp;Guardar S&iacutetio;</button>	
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

</div>
</form>

</body>
</html>
