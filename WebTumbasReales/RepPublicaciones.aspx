<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RepPublicaciones.aspx.vb" Inherits="RepPublicaciones" %>

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
        fnLstAnios("", "cboAnio");

        $("#btnBuscarPub").click(fnBuscarPub);

    });


    function fnBuscarPub() {
        var sw = 0;
        var sms = '';
        if ($("#cboAnio").val() == "0") {
            sw = 1;
            sms = "Seleccione Año";
        }
        if (sw == 1) {
            fnMensaje("error", sms);
            return false;
        }
        else {
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "RepPublicaciones", "param1": $("#cboAnio").val() },
                dataType: "json",
                async: false,
                success: function (data) {
                    var tb = '';
                    var i = 0;
                    var mostrar = '';
                    var contador = 0;
                    var tipo_sexo = '';
                    //console.log(data);
                    if (data.length > 0) {
                        aData = data;
                        for (i = 0; i < aData.length; i++) {
                            contador = contador + 1;
                            tb += '<tr>';
                            tb += '<td>';
                            tb += '</td>';
                            tb += '<td style="text-align:center">' + aData[i].anio_pub + '</td>';
                            tb += '<td style="text-align:center">' + aData[i].denominacion_pub + '</td>';
                            tb += '<td style="text-align:center">' + aData[i].autores_pub + '</td>';
                            tb += '<td style="text-align:center">' + aData[i].contexto_pub + '</td>';
                            tb += '</tr>';
                        }
                    } else {
                        tb = "";
                        fnMensaje("error", "No se encontró información");
                    }
                    fnDestroyDataTableDetalle('tbPublicacion');
                    $('#pPublicacion').html(tb);
                    fnResetDataTableTramite('tbPublicacion', 0, 'asc');
                },
                error: function (result) {
                    console.log('error');
                }
            });

        }
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
                tb += '<td style="text-align:center">' + aData[i].codpropietario + '</td>';
                tb += '<td style="text-align:center">' + aData[i].codexcavacion + '</td>';
                tb += '<td style="text-align:center">' + aData[i].denominacion + '</td>';
                tb += '<td style="text-align:center">' + aData[i].sitio + '</td>';
                tb += '</tr>';
            }
        } else {
            tb = "";
        }
        fnDestroyDataTableDetalle('tbPublicacion');
        $('#pPublicacion').html(tb);
        fnResetDataTableTramite('tbPublicacion', 0, 'asc');
    }

    function fnLstAnios(param1, combo) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "cboAnioPublicaciones" },
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


</script>


</head>

<body  >

    <form id="frmPublicaciones" name="frmPublicaciones" runat="server">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="paramdgc" name="paramdgc" value="" runat="server" /> 
    <input type="hidden" id="pub" name="pub" value="" /> 
        <div class="row">
    <div class="panel panel-piluku">

            <div class="panel-heading">
		        <h3 class="panel-title">
			        
                    <div class="col-md-6" align="left" >
                          <div id="titulo" runat="server"> PUBLICACIONES </div>  
                    </div>
                    <div class="col-md-5" align="right">
                            <button type="button" class="btn btn-white " id="btnExportarRep" runat="server" ><i class="ion-android-download"></i>&nbsp;Exportar Publicación</button>	
                    </div>

                       
                </h3>
	        </div>	
        
    <div class='table-responsive'>	        
        <div class='panel-body' >
            <div class="row">
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="cboAnio">
                        Año:</label>
                    <div class="col-sm-2">
                        <select class="form-control" id="cboAnio" name="cboAnio" runat="server"></select>             
                    </div>
                </div>
                <div class="form-group">
                    <a href="#" id="btnBuscarPub" class="btn btn-primary" ><i class="ion-android-done"></i>&nbsp;Buscar</a> 
                </div>
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
     
                </div> 

         
        </div> 

            
                                
           </div> 

          
	    
        </div>
    </div>
    

</form>

</body>
</html>

