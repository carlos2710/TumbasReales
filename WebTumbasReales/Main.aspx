<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Main.aspx.vb" Inherits="Main" %>
<!DOCTYPE html>
<html lang="es">
<head >
  <meta charset="UTF-8"/>
  

  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0"/> <!--320-->
  <title>	.: AVA - SIP&Aacute;N :.</title>

      <link rel="shortcut icon" href="assets/images/favicon.ico" type="image/x-icon">
  <link rel="icon" href="assets/images/favicon.ico" type="image/x-icon" />

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
<link rel='stylesheet' href='assets/css/jquery.dataTables.min.css'/>



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

    function searchGrl(e) {
        // look for window.event in case event isn't passed in
        e = e || window.event;
        if (e.keyCode == 13) {
            f_Menu('BusquedaGrl.aspx' + '?SEA=' + $('#txtBusqueda').val());
            return false;
        }
        return true;
    }

</script>


</head>

<body class="" runat="server" id="bodyPrincipal" >
<form id="frmContent1" runat="server">
    <div class="piluku-preloader text-center">
        <div class="loader">Loading...</div>
    </div>
<div class="wrapper ">
    <div class="content11" id="content11"  runat="server">

        <!--top - bar -->
	    <div class="top-bar" id="top-bar">
            
	    <nav class="navbar navbar-default top-bar">
		    <div class="logo" >
			        <img class="avatar" src="assets/images/logo.jpg" alt="Ministerio de Cultura del Perú" height="50px" widht="200px">
		    </div>

		    <ul class="nav navbar-nav navbar-right top-elements">
		        
		        <li class="piluku-dropdown dropdown">			
				    <a href="#"  id="lnkHome" class="dropdown-toggle" role="button" aria-expanded="false"><i class="ion-ios-home"></i></a>
			    </li>

			    <li class="piluku-dropdown dropdown">
				    <a href="#" class="dropdown-toggle avatar_width" data-toggle="dropdown" role="button" aria-expanded="false">
                        <span> <i class="icon ti-book"></i></span></a>
				    <ul class="dropdown-menu dropdown-piluku-menu  animated fadeInUp wow avatar_drop neat_drop dropdown-right" data-wow-duration="1500ms" role="menu">
				        <li>
						    <a href="#" onclick="f_Menu('RepInventarios.aspx')"> <i class="ion-clipboard"></i>Inventarios</a>
					    </li>
					    <li>	
						    <a href="#" onclick="f_Menu('RepCatalogos.aspx')"> <i class="ion-clipboard"></i>Catálogos</a>
					    </li>   
                        <li>
						    <a href="#" onclick="f_Menu('RepPublicaciones.aspx')"> <i class="ion-clipboard"></i>Publicaciones</a>
					    </li>
					    <li>	
						    <a href="#" onclick="f_Menu('RepExposiciones.aspx')"> <i class="ion-clipboard"></i>Exposiciones</a>
					    </li> 
				    </ul>
			    </li>

			    <li class="piluku-dropdown dropdown">
					    <a href="#" class="dropdown-toggle avatar_width" data-toggle="dropdown" role="button" aria-expanded="false">
                        <span ><i class="ion ion-ios-contact"></i> </span></a>
				    <ul class="dropdown-menu dropdown-piluku-menu  animated fadeInUp wow avatar_drop neat_drop dropdown-right" data-wow-duration="1500ms" role="menu">
				        <li>
						    <a href="#" onclick="f_Menu('misdatos.aspx')"> <i class="ion-android-create"></i>Mis Datos</a>
					    </li>
                        <li>
						    <a href="#" onclick="f_Menu('Usuarios.aspx')"> <i class="ion-android-person"></i>Usuarios</a>
					    </li>

                        <li>
						    <a href="#" onclick="f_Menu('Colecciones.aspx')"> <i class="icon ion-social-buffer"></i>Colecciones</a>
					    </li>
                        <li>
						    <a href="#" onclick="f_Menu('CambiarClave.aspx')"> <i class="ion-locked"></i>Cambiar Clave</a>
					    </li>
					    <li>	
						    <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="logout_button"></asp:LoginStatus>
					    </li>   
				    </ul>
			    </li>
		    </ul>
	    </nav>
        </div>
    <!-- /top-bar -->
        <div class="col-md-13" >
            <div class="top-bar1 search" id="Div1">
                <div class="col-md-6" align="center" >
                        <h4>ARCHIVO VIRTUAL ARQUEOLÓGICO - SIPÁN</h4> 
                        <h3>AVA - SIPÁN</h3>
                </div>
                <div class="externo col-md-4" align="right">
                    <div class="interno input-group " style="display: table ">
                        <input type="text" id="txtBusqueda" name="txtBusqueda" class="form-control" onkeypress="return searchGrl(event);" placeholder="¿Qué estas buscando?"/>
                        <span class="input-group-addon">
                            <i class="glyphicon glyphicon-search"></i>
                        </span>
                    </div>

                </div>
                <br />
            </div>

        </div>



    <div id="divContent">
	    <div class="col-md-12 panel panel-piluku " >

              <div class='panel-body col-md-3' id ="izquierda" runat="server">
                </div>

                <div class='panel-body col-md-6 museo' style='display: flex;justify-content: center;align-items: center;display: flex;justify-content: center;align-items: center;'>
                    <img src="assets/images/museo-tumbas-reales.jpg" alt="Ministerio de Cultura del Perú" height="40%" widht="80%">
                </div>

                <div class='panel-body col-md-3' id ="derecha" runat="server">
                </div>

                <center>
                    <div class='panel-body col-md-4'>
                    </div>
                        <div class='panel-body col-md-4' id ="medio" runat="server">
                        </div>
                    
                    <div class='panel-body col-md-4'>
                    </div>
                    <div>

                                               
                    </div>
                       
                </center>
            
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
            <
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

<br />
        </div>
        
  

    </div>
   
    </div>  

        

</div>




</form>

</body>
</html>
