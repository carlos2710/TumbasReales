<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CodigosNaciones.aspx.vb" Inherits="CodigosNaciones" %>
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
        fnResetDataTableTramite('tbCodigoNac', 0, 'desc');
        listaCodigosNac();

    });

    function listaCodigosNac() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "PlaniArqueo" },
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
                        tb += '<td style="text-align:center">' + aData[i].codpropietario_cat + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].codreginc_cat + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].cultura_cat + '</td>';
                        tb += '<td style="text-align:center">' + aData[i].denominacion_cat + '</td>';
                        tb += '</tr>';
                    }
                } else {
                    tb = "";
                }
                fnDestroyDataTableDetalle('tbCodigoNac');
                $('#pCodigoNac').html(tb);
                fnResetDataTableTramite('tbCodigoNac', 0, 'asc');
            },
            error: function (result) {
                console.log('error');
            }
        });
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

    <form id="frmCodNacionales" name="frmCodNacionales" runat="server">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="paramdgc" name="paramdgc" value="" runat="server" /> 
    <input type="hidden" id="eval" name="eval" value="" /> 
    <input type="hidden" id="invInm" name="invInm" value="" /> 
    <input type="hidden" id="afeInm" name="afeInm" value="" /> 
        
        <div class="row">
    <div class="panel panel-piluku">

            <div class="panel-heading">
		        <h3 class="panel-title">
			        
                    <div class="col-md-6" align="left" >
                          <div id="titulo" runat="server"> Códigos Nacionales</div>  
                    </div>
                    <div class="col-md-5" align="right">
                            <button type="button" class="btn btn-white " id="btnExportarRep" runat="server" ><i class="ion-android-download"></i>&nbsp;Exportar Reporte</button>	
                    </div>                       
                </h3>
	        </div>	  
	        <div class='table-responsive'>	        
                <div class='panel-body' >
                    <div class='table-responsive' >
                       <table class='display dataTable cell-border' id='tbCodigoNac' style="width:95%;font-size:smaller;" >
                            <thead>
                            <tr>
                                    <th style="width:6%;text-align:center;"></th>
                                    <th style="width:15%;text-align:center;">Código Propietario</th>
                                    <th style="width:20%;text-align:center;">Código Reg INC</th>
                                    <th style="width:10%;text-align:center;">Cultura</th>
                                    <th style="width:10%;text-align:center;">Denominación</th>
                                </tr>
                                </thead>     
                                <tbody id ="pCodigoNac" runat ="server">
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


</form>

</body>
</html>


