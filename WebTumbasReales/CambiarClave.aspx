<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CambiarClave.aspx.vb" Inherits="CambiarClave" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cambio de Clave</title>
    <script language="javascript">
        $(document).ready(function () {
            $('#txtCNueva').bind('keypress', function (event) {
                var regex = new RegExp("^[a-zA-Z0-9@#]+$");
                var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
                if (!regex.test(key)) {
                    fnMensaje("warning", "No puede usar caracteres especiales")
                    event.preventDefault();
                    return false;
                }
            });
            $('#txtCRepetida').bind('keypress', function (event) {
                var regex = new RegExp("^[a-zA-Z0-9@#]+$");
                var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
                if (!regex.test(key)) {
                    fnMensaje("warning", "No puede usar caracteres especiales")
                    event.preventDefault();
                    return false;
                }
            });


            $('#btnGuardar').click(function () {
                var param1 = $('input:hidden[id=param1]').val();
                var param2 = $("#txtCAntigua").val();
                var param3 = $("#txtCNueva").val();
                var param4 = $("#txtCRepetida").val();
                var param5 = $('input:hidden[id=param5]').val();

                if (param3 != param4) {
                    fnMensaje("warning", "La nueva clave no coincide con la clave repetida")
                    return;
                }

                if (param3.length > 15) {
                    fnMensaje("warning", "No puede exceder m&aacute;s de 15 caracteres")
                    return;
                }

                if (param2 == "" || param3 == "" || param4 == "") {
                    fnMensaje("warning", "Debe llenar todos los campos")
                    return;
                }

                $('.piluku-preloader').removeClass('hidden');
                //alert(param1 + '-' + param2 + '-' + param3 + '-' + param4 + '-' + param5);
                $.ajax({
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    url: "processmuseo.aspx",
                    data: { "param0": "CambioClave", "param5": param5, "param1": param1, "param2": param2, "param3": param3, "param4": param4 },
                    dataType: "json",
                    success: function (data) {
                        $('.piluku-preloader').addClass('hidden');
                        //console.log(data);
                        if (data[0].msje == "OK") {
                            $("#divContent").empty()
                            $("#divContent").html(data);
                            fnMensaje("success", "Se ha actualizado correctamente su contraseña de acceso. Por favor cierre el Sistema e ingrese con su nueva contraseña")
                        } else {
                            fnMensaje("warning", "No se pudo cambiar la contrase&ntilde;a")
                        }
                        f_Menu('CambiarClave.aspx');
                    },
                    error: function (result) {
                        console.log(result)
                        f_Menu('CambiarClave.aspx');
                    }
                });
            });
        });
    </Script>
</head>
<body>
   			
<div class="panel panel-piluku">
					<div class="panel-heading">
						<h3 class="panel-title">
							Cambiar contrase&ntilde;a de acceso							
						</h3>
					</div>
					<div class="panel-piluku">
					    
						<div class="row">
							<div class="col-md-12">
    						<div class="row">
							    <div class="panel-piluku">
							    <div class="panel">
		                                <div class="panel-body">
			                                <!--form-heading-->
			                                <div class="form-heading">
					
			                                </div>
			                                <!--form-heading-->
			                                <form id="Form1" class="form form-horizontal" runat="server">
				                                <asp:HiddenField ID="param1" runat="server" />		    
				                                <asp:HiddenField ID="param5" runat="server" />
				                                <!--Default Horizontal Form-->
				                                <div class="form-group">
					                                <label class="col-sm-2 control-label">Contraseña Actual:</label>
					                                <div class="col-sm-8">
						                                <input id="txtCAntigua" type="password" class="form-control" />
					                                </div>
				                                </div>
				                                <!--Default Horizontal Form-->

				                                <!--Default Horizontal Form with password-->
				                                <div class="form-group">
					                                <label class="col-sm-2 control-label">Contraseña Nueva:</label>
					                                <div class="col-sm-8">
						                                <input id="txtCNueva"  type="password" class="form-control" />
					                                </div>
				                                </div>
				                                <!--Default Horizontal Form with password-->
					
				                                <!--Default Horizontal Form with password-->
				                                <div class="form-group">
					                                <label class="col-sm-2 control-label">Confirmar contraseña nueva:</label>
					                                <div class="col-sm-8">
						                                <input id="txtCRepetida"  type="password" class="form-control" />
					                                </div>
				                                </div>										
				                                <!--Default Horizontal Form with password-->
                                                <br />
				                                <center>                        
                                                    <input type="button" id="btnGuardar" class="btn btn-primary-jr" value="Guardar Cambios" runat="server"/>
				                                </center>	
                                                <br /><br /><br />	<br /><br /><br />	<br />				
			                                </form>
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
							</div>
						</div>
						<!-- /row -->
					</div>
				</div>
        
</body>
</html>
