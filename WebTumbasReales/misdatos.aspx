<%@ Page Language="VB" AutoEventWireup="false" CodeFile="misdatos.aspx.vb" Inherits="misdatos" %>

<html id="Html1" lang="en" runat="server">
<head id="Head1" runat="server">
    
<script  type="text/javascript" >

</script>
</head>

<body>
<form id="Form1" action="#"  runat="server">  
    <div class="panel panel-piluku">
		<div class="panel-heading">
				<h3 class="panel-title">
					MIS DATOS
				</h3>
	    </div>
		<div class="panel-piluku">
			<div class="panel-body-add profile-body">
						<div class="row">
							<div class="profile-left">													
								<div class="col-md-7 col-md-offset-1">		
								<div class="panel panel-piluku">
								    <div class="panel-heading">
				                            <h3 class="panel-title">
					                            Datos Personales					
				                            </h3>
	                                </div>                            																						
									<div class="panel-body">									
									    <div class="col-md-14">
                                            <div class="form-group">
							                    <label class="control-label">Nombre</label>
							                   	<input type="text" id="txtNombre" runat="server" class="form-control" readonly="true" />			                    
						                    </div>	
						                    <div class="form-group">
							                    <label class="control-label">E-mail principal:</label>
							                    <input type="text" id="txtEmail" runat="server" class="form-control" readonly="true" />							                    
						                    </div>
						                    <div class="form-group">
							                    <label class="control-label">E-mail alternativo:</label>							                    	
							                    <input type="text" id="txtEmail2" runat="server" class="form-control" readonly="true" />						                    
						                    </div>	
                                                                        <br /><br /><br /><br />			                    
					                    </div>
					                </div>	
								</div>
								
							</div>

							<div class="profile-right">
								<div class="col-md-3">

									<div class="profile-sidebar">
										<div class="profile-sidebar-heading">
											Informaci&oacute;n
										</div>
										<ul class="list-inline list-unstyled profile-personal-info">
											<li>DNI <span id="DNI" runat="server"></span></li>
											<li>SEXO <span id="SEXO" runat="server"></span></li>										
										</ul>										
									</div>								

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

					</div>
			

			</div>
	</div>
	

</form>
</body>
</html>