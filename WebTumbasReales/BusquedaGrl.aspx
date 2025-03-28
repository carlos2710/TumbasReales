<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BusquedaGrl.aspx.vb" Inherits="BusquedaGrl" %>
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
        fnResetDataTableTramite('tbSearchGrl', 0, 'desc');

    });

 
</script>


</head>

<body  >

    <form id="frmBusquedaGrl" name="frmBusquedaGrl" runat="server">	
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 

    <div class="panel panel-piluku">
        <div class="panel-heading">
		    <h3 class="panel-title">
			        
                <div class="col-md-6" align="left" >
                      <div id="titulo" > Resultado de Búsqueda</div>  
                    
                </div>
                       
            </h3>
	    </div>	  
	    <div class='table-responsive'>	        
        <div class='panel-body' >
            <div class='table-responsive'>
                <table class='display dataTable cell-border' id='tbSearchGrl' style="width:100%;font-size:smaller">
                    <thead>
                    <tr>
                            <th style="width:15%;text-align:center;">Sitios/Coleccion</th>
                            <th style="width:15%;text-align:center;">Cultura</th>
                            <th style="width:15%;text-align:center;">Material</th>
                            <th style="width:15%;text-align:center;">Tipo</th>
                            <th style="width:15%;text-align:center;">Tipo Info</th>
                        </tr>
                        </thead>     
                        <tbody id ="pSearchGrl" runat ="server">
                        </tbody>                             
                        <tfoot>
                        <tr>
                        <th colspan="5"></th>
                        </tr>
                        </tfoot>
                        </table>
        </div>              
    </div> 
                <br/>  
                                
    </div> 
    </div>
    
    

</form>

</body>
</html>
