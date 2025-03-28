<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Conservacion.aspx.vb" Inherits="Conservacion" %>

<%--<!DOCTYPE html>
<html lang="en">
<head >
  <meta charset="utf-8"/>

  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0"/> <!--320-->
  <title>	.: AVA - SIP&Aacute;N :.</title>

  <!-- <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon">
  <link rel="icon" href="images/favicon.ico" type="image/x-icon"> -->
  <!-- Bootstrap CSS -->
  <!-- <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon">
  <link rel="icon" href="images/favicon.ico" type="image/x-icon"> -->
  <!-- Bootstrap CSS -->
<link rel='stylesheet' href='assets/css/bootstrap.min.css'/>
<link rel='stylesheet' href='assets/css/material.css'/>
<link rel='stylesheet' href='assets/css/style.css?a=1'/>
<link rel='stylesheet' href='assets/css/sweet-alerts/sweetalert.css'/>

<script type="text/javascript" src='assets/js/jquery.js'></script>
<script type="text/javascript" src='assets/js/app.js'></script>

<script type="text/javascript" src='assets/js/noty/jquery.noty.js'></script>
<script type="text/javascript" src='assets/js/noty/layouts/top.js'></script>
<script type="text/javascript" src='assets/js/noty/layouts/default.js'></script>
<script type="text/javascript" src='assets/js/noty/notifications-custom.js'></script>
<script type="text/javascript" src='assets/js/noty/notificacioncve.js'></script>

<script type="text/javascript" src='assets/js/jquery-ui-1.10.3.custom.min.js'></script>
<script type="text/javascript" src='assets/js/bootstrap.min.js'></script>
<script type="text/javascript" src='assets/js/jquery.nicescroll.min.js'></script>
<script type="text/javascript" src='assets/js/wow.min.js'></script>
<script type="text/javascript" src='assets/js/jquery.loadmask.min.js'></script>
<script type="text/javascript" src='assets/js/jquery.accordion.js'></script>
<script type="text/javascript" src='assets/js/materialize.js'></script>
<script type="text/javascript" src='assets/js/bic_calendar.js'></script>

<script type="text/javascript" src='assets/js/core.js'></script>
<script type="text/javascript" src="assets/js/jquery.countTo.js"></script>
<link rel='stylesheet' href='assets/css/jquery.dataTables.min.css'/>--%>

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

    jQuery(document).ready(function () {

        _H = $('#top-bar').height();
        $('#imgLogo').click(function () {
            f_Menu('bienvenida.aspx');
        });
        $('#lnkMail').click(function () {
            f_Menu('infomail.aspx');
        });

        $('.piluku-preloader').addClass('hidden');
        $('#lnkHome').click(function () {
            window.location.reload();
        });


    });


    function f_Menu(page) {

        if (page.length > 0) {
            if (page != 'notificaciones.aspx') {
                $("#divNotificacion").html('');
            }
            $("#divleft").removeClass("left-bar menu_appear").addClass("left-bar");
            $("#divleft").css(["overflow", "hidden", "outline", "none"]);
            $("#divOverlay").removeClass("overlay show").addClass("overlay");
            $('.piluku-preloader').removeClass('hidden');
            $.post(page, {
            }, function (data, status) {
                if (status == 'success') {
                    $("#divContent").empty();
                    $("#divContent").html(data);
                } else {
                    $("#divContent").html("");
                    location.reload();
                }
                $('.piluku-preloader').addClass('hidden');
            });
        }
    }

    function fnResizeimg() {
        var tamhDiv = $("#divColDatos").height();
        var tamwDiv = $("#divColDatos").width();
        $("#imgDatos").height(tamhDiv);
        $("#imgDatos").width(tamwDiv);
    }

    function fnDivRefresh(div, time) {
        var $target = $('#' + div);
        $target.mask('<i class="fa fa-refresh fa-spin"></i> Cargando...');
        setTimeout(function () {
            $target.unmask();
            //console.log('ended');
        }, time);
    }



</script>


</head>

<body class="" runat="server" id="bodyPrincipal" >
<form id="Form1" action="#"  runat="server">  
    <div class="panel panel-piluku">
		<div class="panel-heading">
				<h3 class="panel-title">
					<div id="titulo_TI" runat="server"></div>
				</h3>
	    </div>
		<div class="panel-body">
			<div class="panel-body profile-body">
				<div class="row">
                    <div class="panel panel-piluku" runat="server" id="conservaciones">
    		        </div>
				</div>
			
			</div>

                    <div class="col-md-12 panel panel-piluku ">
            <div class="linea"></div>
        </div>
    
        <footer class="page-footer">
                    
        <div class="col-md-2 museoTR" align="center" style="border:1px solid black;">
            <br />
            <table width="100%">
              <tr>
                <td rowspan="2"><p class="copy">&copy;</p></td>
                <td ><p class="museotumbasreales">MUSEO TUMBAS</p></td>
              </tr>
              <tr>
                <td ><p class="museotumbasreales">REALES DE SIPAN</p><br /></td>
              </tr>
            </table>
        </div>
        <div class="col-md-10 museoTRS" align="center" style="border:1px solid black;">
            
            <table width="100%">
              <tr>
                <td ><p class="sipan">Colección</p></td>
                <td ><p class="sipan">Ubicación</p></td>
                <td ><p class="sipan">Teléfono</p></td>
              </tr>
              <tr>
                <%--<td ><p class="reales">paleontologíca,Arqueológica</p></td> #JAZ--%> 
                <td ><p class="reales">Paleontologíca,Arqueológica</p></td>
                <td ><p class="reales">Lambayeque-Lambayeque-Lambayeque</p></td>
                <%--<td ><p class="reales">(074)-283978</p></td> #JAZ--%>
                <td ><p class="reales">(074)-687630</p></td>
              </tr>
              <tr>
                <td ><p class="sipan">Administración</p></td>
                <td ><p class="sipan">Dirección</p></td>
                <td ><p class="sipan">Email</p></td>
              </tr>
               <tr>
                 <%--<td ><p class="reales">Museo Tumbas Reales de Sipán / Nministerio de cultura</p></td #JAZ--%>
                 <td ><p class="reales">Museo Tumbas Reales de Sipán / Ministerio de cultura</p></td> 
                 <td ><p class="reales">Av. Juan Pablo Vizcardo y Guzmán N° 295</p></td>
                 <td ><p class="reales">tumbasdesipan@hotmail.com</p></td>
              </tr>
            </table>
            <br />
        </div>


 </footer>
	</div>
	
</div>
</form>

</body>
</html>
