<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RepInventarios.aspx.vb" Inherits="RepInventarios" %>

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
        fnResetDataTableTramite('tbInventario', 0, 'desc');
        fnLstCombos("COL", "cboColeccion");
        fnLstCombos("IEX", "cboUnidades");
        fnLstCombos("ITM", "cboTipoMat");

        $("#btnBuscarInv").click(fnBuscarInv);

    });

    function fnLstCombos(param1, combo) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "cboReportes", "param1": param1 },
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

    function fnBuscarInv() {
        var sw = 0;
        var sms = '';
        if ($("#cboColeccion").val() == "0") {
            sw = 1;
            sms = "Seleccione Colección";
        }
        if ($("#cboUnidades").val() =="0"){
            sw = 1;
            sms = "Seleccione Unidades";
        }
        if ($("#cboTipoMat").val() == "0") {
            sw = 1;
            sms = "Seleccione Tipo de Material";
        }
        if (sw == 1)
        {
            fnMensaje("error", sms);
            return false;
        }
        else {
            $("#param1").val($("#cboUnidades").val());
            $("#param2").val($("#cboTipoMat").val());
            $("#param3").val($("#cboColeccion").val());
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "RepInventarios", "param1": $("#cboUnidades").val(), "param2": $("#cboTipoMat").val(), "param3": $("#cboColeccion").val() },
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
                            tb += '<td style="text-align:center">' + aData[i].unidad_inv + '</td>';
                            tb += '<td style="text-align:center">' + aData[i].contexto_inv + '</td>';
                            tb += '<td style="text-align:center">' + aData[i].cultura_inv + '</td>';
                            tb += '<td style="text-align:center">' + aData[i].tipomaterial_inv + '</td>';
                            tb += '<td style="text-align:center">' + aData[i].nrobolsa_inv + '</td>';
                            tb += '<td style="text-align:center">' + aData[i].nrocaja_inv + '</td>';
                            tb += '</tr>';
                        }
                    } else {
                        tb = "";
                        fnMensaje("error", "No se encontró información");
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
    }

</script>


</head>

<body>

    <form id="frmInventario" name="frmInventario" runat="server">	
    <input type="hidden" id="param0" name="param0" value="" runat="server"/>   
    <input type="hidden" id="param1" name="param1" value="" runat="server"/> 
    <input type="hidden" id="param2" name="param2" value="" runat="server"/> 
    <input type="hidden" id="param3" name="param3" value="" runat="server"/> 
    <input type="hidden" id="paramdgc" name="paramdgc" value="" runat="server" /> 
    <input type="hidden" id="inv" name="inv" value="" /> 

    <div class="panel panel-piluku">
        <div class="panel-heading">
		    <h3 class="panel-title">
                <div class="col-md-6" align="left" id="lblReporte" runat="server">
                      Reporte de Inventarios
                </div>
                <div class="col-md-5" align="right">
                        <button type="button" class="btn btn-white " id="btnExportarRep" runat="server" ><i class="ion-android-download"></i>&nbsp;Exportar Reporte</button>	
                </div>
		    </h3>
	    </div>	  
	    <div class='table-responsive'>	        
        <div class='panel-body' >
            <div class="row">
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="cboColeccion">
                        Coleccion:</label>
                    <div class="col-sm-2">
                        <select class="form-control" id="cboColeccion" name="cboColeccion"></select>             
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="cboUnidades">
                        Unid. Excavación:</label>
                    <div class="col-sm-2">
                        <select class="form-control" id="cboUnidades" name="cboUnidades"></select>             
                    </div>
                </div>
                <div class="form-group">
                    <a href="#" id="btnBuscarInv" class="btn btn-primary" ><i class="ion-android-done"></i>&nbsp;Buscar</a> 
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="cboTipoMat">
                        Tipos de Material:</label>
                    <div class="col-sm-2">
                            <select class="form-control" id="cboTipoMat" name="cboTipoMat"></select>                
                    </div>
                </div>
            </div>

            <div class='table-responsive'>
                <table class='display dataTable cell-border' id='tbInventario' style="width:100%;font-size:smaller">
                    <thead>
                    <tr>
                            <th style="width:6%;text-align:center;"></th>
                            <th style="width:8%;text-align:center;">Unidad</th>
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

    </br>  
                                
    </div> 
    </div>

</form>

</body>
</html>
