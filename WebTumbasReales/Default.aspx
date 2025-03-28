<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>	.: AVA - SIP&Aacute;N :.</title>
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css"/>
	<link rel="stylesheet" href="assets/css/material.css?x=1"/>		
	<link rel="stylesheet" type="text/css" href="assets/css/style.css?y=4"/>	
	<link rel="stylesheet" type="text/css" href="assets/css/signup2.css?x=!"/>		

    <link rel="shortcut icon" href="assets/images/favicon.ico" type="image/x-icon" />
  <link rel="icon" href="assets/images/favicon.ico" type="image/x-icon" /> 

	<!-- custom scrollbar stylesheet -->
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0"/> <!--320-->
	<script type="text/javascript" src="assets/js/jquery.js"></script>
	<script type="text/javascript" src="assets/js/bootstrap.min.js"></script>	
	<script type="text/javascript" src='assets/js/noty/jquery.noty.js'></script>
    <script type="text/javascript" src='assets/js/noty/layouts/top.js'></script>
    <script type="text/javascript" src='assets/js/noty/layouts/default.js'></script>
    <script type="text/javascript" src='assets/js/noty/notifications-custom.js'></script>
    <script type="text/javascript" src='assets/js/jquery-ui-1.10.3.custom.min.js'></script>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv='X-UA-Compatible' content='IE=7' />
    <meta http-equiv='X-UA-Compatible' content='IE=8' />
    <meta http-equiv='X-UA-Compatible' content='IE=10' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/> 

<style>
@media all and (max-width: 450px) {
    #labelrps { display:none; }
    #centeripod {width:100%;}
}
#div_carga{
    position:absolute;
    top:0;
    left:0;
    width:100%;
    height:100%;
	/*background: url(images/gris.png) repeat;*/
	background-color:#000000;
	display:none;
	z-index:1;
}
 
#cargador{
    position:absolute;
    top:50%;
    left: 50%;
    margin-top: -25px;
    margin-left: -25px;
}
</style>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $("#btnEnviar").click(function () {
	            var correo = $("#txtcoduniv").val();
	            $('#div_carga').show();
	            $.ajax({
	                type: "GET",
	                contentType: "application/json; charset=utf-8",
	                url: "processmuseo.aspx",
	                data: { "param0": "RCla", "param1": "1", "param2": correo },
	                dataType: "json",
	                success: function (data) {
	                    fnMensaje("success", data[0].aviso + ' a ' + data[0].email)
	                    $('#div_carga').hide();
	                    $('#forgot').modal('hide');
	                },
	                error: function (result) {
	                    $('#div_carga').hide();
	                    fnMensaje("error", "Se ha enviado la contrase&ntilde;a a su correo. Si no la ha recibido el correo comuniquese con comunicaciones@clubunion.com.pe")

	                }
	            });
	        });

	    });

	    function EnterEvent1(e) {
	        if (e.keyCode == 13) {
	            __doPostBack('<%=lnkbtnIngresar1.UniqueID%>', "");
	        }
        }


	</script>
	<script type="text/javascript">
	    document.execCommand('ClearAuthenticationCache');

    </script>
</head>
<body>
<div id="div_carga">
<img id="cargador" src="assets/img/ajax-loader2.gif" />
</div>

<form id="frmLogin" runat="server" method="post" OnAuthenticate= "ValidateUser">
       
       <br />
       
       <div class="col-ld-12 col-md-12 col-xs-12 col-sm-12">
        <!-- *** Responsive Tables *** -->
        <!-- panel -->
        <center>
        <div class='panel panel-piluku-white col-ld-5 col-md-5 col-xs-5 col-sm-5' style="float: none;" id="centeripod" >

           <div class="panel-body">
	            <div role="tabpanel" style=" text-align:center;">
				    <!-- Nav tabs -->
                    <div class='' style=" text-align:center;">
					        <h1 class="heading">
                                <img alt="Logo USAT" src="assets/images/apple-touch-icon-144x144.png" style="width:110px; height: 110px; text-align: center;" /></h1>
                            
                                <label class="control-dorado"> AVA - SIP&Aacute;N <br /> Lambayeque</label>  
                    </div>
                    <br />
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
					    <li role="presentationlogin" class="active" id="loginalumni" runat="server" style="width:49%;"><a href="#loginalumni_tab" aria-controls="home" role="tab" data-toggle="tab" class='ion-android-person'> <div id="labelrps">Administrativo</div></a></li>
					    <!--<li role="presentationlogin" id="loginalumniegre"  runat="server" style="width:49%;"><a href="#loginalumniegre_tab" aria-controls="profile" role="tab" data-toggle="tab" class='ion-university'> <div id="labelrps">Egresado</div></a></li>-->
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">
	
					    <div role="tabpanel" class="tab-pane active" id="loginalumni_tab" runat="server" >
                                    <asp:TextBox id="txtUsername" style="height: 50px;font-weight:bold;color:Black;" runat="server" 
                                            CssClass="form-control" placeholder="Usuario" value="" 
                                            TabIndex="1"  >
                                     </asp:TextBox>	     
                                    <br />
                                     <asp:TextBox ID="txtPassword1" style="height: 50px;font-weight:bold;color:Black;" runat="server" 
                                        CssClass="form-control" placeholder="Contraseña" TextMode="Password" value="" 
                                        onkeypress="return EnterEvent1(event);" TabIndex="2" ></asp:TextBox>	
                                        					
					                 <div class="clearfix"> 
					                    <asp:Label ID="lblMensaje1" runat="server" TabIndex="7"  ForeColor="Red"></asp:Label>              
                                     </div>
					                <a href="#" class="pull-right"  data-toggle="modal" data-target="#forgot" style="color:blue">¿Olvidaste tu contrase&ntilde;a?</a>											
					                <br /><br />
					                <asp:LinkButton ID="lnkbtnIngresar1" runat="server" 
                                        CssClass="btn btn-primary btn-block ion-android-person" TabIndex="3" >&nbsp;INGRESAR</asp:LinkButton>	

				        </div>
                        <%--<div role="tabpanel" class="tab-pane " id="loginalumniegre_tab" runat="server" >

        
                                <asp:TextBox id="txtDni" style="height: 50px;font-weight:bold;color:Black;" runat="server" 
                                    CssClass="form-control" placeholder="DNI" value="" 
                                    TabIndex="4"  ></asp:TextBox>	       
                                <br />
					            <asp:TextBox ID="txtPassword2" style="height: 50px;font-weight:bold;color:Black;" runat="server" 
                                    CssClass="form-control" placeholder="Contraseña" TextMode="Password" value="" 
                                    onkeypress="return EnterEvent2(event);" TabIndex="5" ></asp:TextBox>		
                                    				
					            <div class="clearfix"> <asp:Label ID="lblMensaje2" runat="server" TabIndex="8" 
                                        ForeColor="Red"></asp:Label>              
                                </div>	
					            <a href="#" class="pull-right"  data-toggle="modal" data-target="#forgot2">¿Olvidaste tu contrase&ntilde;a?</a>											
					            <br /> <br />
					            <asp:LinkButton ID="lnkbtnIngresar2" runat="server" 
                                    CssClass="btn btn-orimary btn-block ion-university" TabIndex="6">&nbsp;INGRESAR</asp:LinkButton>	              
                        </div>--%>
                    </div> 
                    
                    <br /> 
                    <div style="text-align:center; font-size: 10px">Museo Tumbas Reales de Sip&aacute;n<br />
                    Av. Juan Pablo Vizcardo y Guzm&aacute;n N° 895 Lambayeque - Lambayeque</div>
                    
	            </div> 
            </div> 
          		
        </div>
        </center>
    </div> 
       
<div class="modal fade" id="forgot" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;z-index: 0;" >
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header" style="background-color:#000000;">
					<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">X</span></button>
					<h4 class="modal-title" id="myModalLabel" style="color:White"><i class="ion-android-settings"></i> Recuperar contrase&ntilde;a </h4>
				</div>
				<div class="modal-body">
					<div class="col-sm-12">
						<input id="txtcoduniv" style="line-height: 40px" type="text" class="form-control"  placeholder="Ingrese DNI" />
						<h6 class="note" ><i class="ion-android-mail"></i> La contrase&ntilde;a ser&aacute; enviada a tu correo </h6>
					</div>
				</div>
				<div class="modal-footer">	
                    <input id="btnEnviar" type="button" class="btn btn-primary" value="Enviar"/>								
                    <button id="btnCancelar" type="button" class="btn btn-red" data-dismiss="modal">Cerrar</button>	
				</div>
			</div>
		</div>
	</div>
    </form>
        
</body>
</html>
