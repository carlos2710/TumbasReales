<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReporteConservacionPDF.aspx.vb" Inherits="ReporteConservacionPDF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>	.: AVA - SIP&Aacute;N :.</title>

      
    <script type="text/javascript" src="assets/js/jquery-2.1.1.js"></script>
    <link rel='stylesheet' href='assets/css/jquery.dataTables.min.css'/>  
     
    <link rel='stylesheet' href='assets/css/validaform.css'/>     
    <script src="assets/js/funciones.js" type="text/javascript"></script> 
    
    <script src='assets/js/bootstrap-datepicker.js'></script>
    <script src='assets/js/funcionesDataTable.js?y=1'></script>
    <style>
        #img_vista{
            width:300px;
            height:300px;
        }
    </style>
    <script type="text/javascript">
        var aData = [];
        var aData2 = [];

        jQuery(document).ready(function () {

            const valores = window.location.search;
            const url = new URLSearchParams(valores);
            var codigo = url.get("CON");

            listarEvaluacionesDGC(codigo);
            mostrarData();
        });



        function listarEvaluacionesDGC(val) {

            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "lstEvaluacionesDGC", "param1": val, "param2": "MQA=" },
                dataType: "json",
                async: false,
                success: function (data) {
                    aData = data;
                },
                error: function (result) {
                    console.log('error');
                }
            });
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": "lstTratamientoDGC", "param1": val, "param2": "MQA=" },
                dataType: "json",
                async: false,
                success: function (data) {
                    aData2 = data;
                },
                error: function (result) {
                    console.log('error');
                }
            });
        }

        function mostrarData() {
            document.getElementById("num_ficha").innerHTML = aData[0].nroficha_con;
            document.getElementById("reg_nac").innerHTML = aData[0].codregnac_con;
            document.getElementById("propietario").innerHTML = aData[0].codpropietario_con;
            document.getElementById("excavacion").innerHTML = aData[0].codexcavacion_con;
            document.getElementById("restauracion").innerHTML = aData[0].codrestauracion_con;
            document.getElementById("sector").innerHTML = aData[0].sector_con;
            document.getElementById("unidad").innerHTML = aData[0].unidad_con;
            document.getElementById("capa").innerHTML = aData[0].capa_con;
            document.getElementById("nivel").innerHTML = aData[0].nivel_con;
            document.getElementById("plano").innerHTML = aData[0].plano_con;
            document.getElementById("contexto").innerHTML = aData[0].contexto_con;
            document.getElementById("ubicacion").innerHTML = aData[0].ubicontexto_con;
            document.getElementById("altura").innerHTML = aData[0].alturaobs_con;
            document.getElementById("otros_datos").innerHTML = aData[0].otrosdatos_con;
            document.getElementById("cons_carg").innerHTML = aData[0].conservadorcargo_con;
            document.getElementById("cons_fech").innerHTML = aData[0].fecha_con;
            document.getElementById("materiales").innerHTML = aData[0].material_con;
            document.getElementById("descripcion").innerHTML = aData[0].descripcion_con;
            document.getElementById("denominacion").innerHTML = aData[0].denominacion_con;
            document.getElementById("alto").innerHTML = aData[0].alto_con;
            document.getElementById("largo").innerHTML = aData[0].largo_con;
            document.getElementById("ancho").innerHTML = aData[0].ancho_con;
            document.getElementById("espesor").innerHTML = aData[0].espesor_con;
            document.getElementById("diammax").innerHTML = aData[0].diametromax_con;
            document.getElementById("diammin").innerHTML = aData[0].diametromin_con;
            document.getElementById("diambase").innerHTML = aData[0].diametrobase_con;
            document.getElementById("peso").innerHTML = aData[0].peso_con;
            document.getElementById("ubic_espec").innerHTML = aData[0].ubicinmueble_con;
            document.getElementById("caja").innerHTML = aData[0].nrocaja_con;
            document.getElementById("bolsa").innerHTML = aData[0].nrobolsa_con;
            var integri = aData[0].integridadbien_con;
            var inte = "";
            if (integri == "1") {
                inte = "Completo";
            }
            if (integri == "2") {
                inte = "Incompleto";
            }
            if (integri == "3") {
                inte = "Completo Fragmentado";
            }
            if (integri == "4") {
                inte = "Completo Reintegrado";
            }
            if (integri == "5") {
                inte = "Incompleto Reintegrado";
            }
            if (integri == "6") {
                inte = "Incompleto Fragmentado";
            }
            document.getElementById("integridad").innerHTML = inte;
            var conserv = aData[0].conservacionbien_con;
            var cons_resp = "";
            if (conserv == "1") {
                cons_resp = "Bueno";
            }
            if (conserv == "2") {
                cons_resp = "Malo";
            }
            if (conserv == "3") {
                cons_resp = "Regular";
            }
            document.getElementById("conserv_bien").innerHTML = cons_resp;
            document.getElementById("detalle_cons").innerHTML = aData[0].detconservacion_con;
            if (aData2.length > 0) {
                document.getElementById("interv_ant").innerHTML = aData2[0].intervenciones_tra;
                document.getElementById("tratamiento").innerHTML = aData2[0].dettratamiento_tra;
                document.getElementById("limpieza").innerHTML = aData2[0].dettratamiento_tra;
            }
            document.getElementById("afectacion").innerHTML = aData[0].detconservacion_con;            
            document.getElementById("deta_obs").innerHTML = aData[0].observaciones_con;
            document.getElementById("temperatura").innerHTML = aData[0].temperatura_con;
            document.getElementById("humedad").innerHTML = aData[0].humedad_con;
            document.getElementById("manipulacion").innerHTML = aData[0].manipulacion_con;


            fnMostrarImagen(aData[0].foto_con)
            
        }

        function fnMostrarImagen(id_ar) {
            var flag = false;
            var form = new FormData();
            form.append("param0", "DownloadSinEnc");
            form.append("IdArchivo", id_ar);
            form.append("area", 1);
            // alert();
            //            console.log(form);
            $.ajax({
                type: "POST",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                cache: false,
                contentType: false,
                processData: false,
                success: function (data) {
                    flag = true;

                    var file = 'data:application/octet-stream;base64,' + data[0].File;
                    $('#img_vista').attr('src', file);
                },
                error: function (result) {
                    console.log(result);
                    flag = false;
                }
            });
            return flag;
        }
    </script>
    <script>

        document.addEventListener("DOMContentLoaded", () => {
            let boton = document.getElementById("crearpdf");
            let container = document.getElementById("contenedor");

            boton.addEventListener("click", event => {
                event.preventDefault();
                boton.style.display = "none";
                window.print();
            }, false);

            container.addEventListener("click", event => {
                boton.style.display = "initial";
            }, false);

        }, false);

    </script>
    
    <link rel="stylesheet" href= "assets/css/RepConservacion.css" />
</head>
<body>
    <form id="frmReporte" runat="server">
        <div>
            <div id="cabecera">
                <div id="ministerio">
                    <img src="assets/images/logo.jpg" width="200px"/>
                </div>
                <div id="titulo">
                    <h4 id="subtitulo">
                        UNIDAD EJECUTORA 005 - NAYLAMP LAMBAYEQUE<br />
                               MUSEO TUMBAS REALES DE SIPAN<br />
                    </h4>
                    <h3>FICHA DE EVALUACIÓN DE CONSERVACIÓN</h3>
                </div>
                <div id="museo">
                    <img src="assets/images/museo-tumbas-reales3.jpg" width="200px"/>
                </div>
            </div>
            <div id="contenedor">
                <div id="div_ficha">
                    <p id="cab_ficha"><b>N° de Ficha:</b></p>
                    <p id="num_ficha"></p>
                </div>
                <div id="identif_cab">
                    <p id="cab_ident"><b>1. IDENTIFICACIÓN Y CÓDIGOS ADICIONALES</b></p>
                </div>
                <div id="datos_ident">
                    <div id ="ident_cab">
                        <b>Código de Registro Nacional</b><br /><br />
                        <b>Código de Propietario</b><br /><br />
                        <b>Código de Excavación</b><br /><br />
                        <b>Código de Restauración</b><br /><br />
                    </div>
                    <div id="ident_det"> 
                        <p id="reg_nac"></p>
                        <p id="propietario"></p>
                        <p id="excavacion"></p>
                        <p id="restauracion"></p>
                    </div>
                </div>
                <div id="excab_cab">
                    <p id="excab"><b>2. EXCAVACIÓN</b></p>
                </div>
                <div id="excab_det">
                    <div id ="excab_tit">
                        <b>Sector</b><br /><br />
                        <b>Unidad</b><br /><br />
                        <b>Capa</b><br /><br />
                        <b>Nivel</b><br /><br />
                        <b>Cuadrícula</b><br /><br />
                        <b>Plano</b><br /><br />
                        <b>Contexto</b><br /><br />
                        <b>Ubicación en el contexto</b><br /><br />
                        <b>Altura absoluta</b><br /><br />
                        <b>Otros datos</b><br /><br />
                    </div>
                    <div id="excab_res">
                        <p id="sector"></p>
                        <p id="unidad"></p>
                        <p id="capa"></p>
                        <p id="nivel"></p>
                        <p id="cuadricula"></p>
                        <p id="plano"></p>
                        <p id="contexto"></p>
                        <p id="ubicacion"></p>
                        <p id="altura"></p>
                        <p id="otros_datos"></p>
                    </div>
                </div>
                <div id="vista_cab">
                    <p id="cab_vista"><b>VISTA FRONTAL</b></p>
                </div>
                <div id="vista">
                    <img id="img_vista" src="" />
                </div>
                <div id="conserv">
                    <div id="cons_tit">
                        <b>Conservador a Cargo</b><br /><br />
                        <b>Fecha</b>
                    </div>
                    <div id="cons_det">
                        <p id="cons_carg"></p>
                        <p id="cons_fech"></p>
                    </div>
                </div>
                <div id="desc_cab">
                    <p id="cab_desc"><b>3. DESCRIPCIÓN FÍSICA</b></p>
                </div>
                <div id="desc_det">
                    <div id="izquierda_desc">
                        <div id="desc_tit">
                            <b>Materiales</b><br /><br />
                            <b>Descripcion</b>
                        </div>
                        <div id="desc_deta">
                            <p id="materiales"></p>
                            <p id="descripcion"></p>
                        </div>
                    </div>
                    <div id="derecha_desc">
                        <div id="desc_tit2">
                            <b>Denominación</b>
                        </div>
                        <div id="desc_deta2">
                            <p id="denominacion"></p>
                        </div>
                    </div>
                </div>
                <div id="dime_cab">
                    <p id="dime_desc"><b>4. DIMENSIONES</b></p>
                </div>
                <div id="dime_det">
                    <div id="izq_dime">
                        <div id="dime_titu">
                            <b>Alto (mm)</b><br /><br />
                            <b>Largo (mm)</b><br /><br />
                            <b>Ancho (mm)</b><br /><br />
                            <b>Espesor (mm)</b><br /><br />
                        </div>
                        <div id="dime_deta">
                            <p id="alto"></p>
                            <p id="largo"></p>
                            <p id="ancho"></p>
                            <p id="espesor"></p>
                        </div>
                    </div>
                    <div id="der_dime">
                        <div id="dime_titu2">
                            <b>Diametro Max (mm)</b><br /><br />
                            <b>Diametro Min (mm)</b><br /><br />
                            <b>Diametro Base (mm)</b><br /><br />
                            <b>Peso Inicial (g)</b><br /><br />
                        </div>
                        <div id="dime_deta2">
                            <p id="diammax"></p>
                            <p id="diammin"></p>
                            <p id="diambase"></p>
                            <p id="peso"></p>
                        </div>
                    </div>
                </div>
                <div id="ubic">
                    <p id="ubic_datos"><b>5. DATOS DE UBICACIÓN ACTUAL</b></p>
                </div>
                <div id="ubic_det">
                    <div id="izqubic">
                        <div id="ubic_tit">
                            <b>Ubicación Específica en el Inmueble</b><br /><br />
                            <b>N° Caja o Contenedor</b>
                        </div>
                        <div id="ubic_deta">
                            <p id="ubic_espec"></p>
                            <p id="caja"></p>
                        </div>
                    </div>
                    <div id="derubic">
                        <div id="ubic_tit2">
                            <b>N° Bolsa</b>
                        </div>
                        <div id="ubic_deta2">
                            <p id="bolsa"></p>
                        </div>
                    </div>
                </div>
                <div id="estado">
                    <p id="est_cons"><b>6. ESTADO DE CONSERVACION</b></p>
                </div>
                <div id="est_deta">
                    <div id ="excab_tit">
                        <b>Integridad del Bien</b><br /><br />
                        <b>Conservación del Bien</b><br /><br />
                        <b>Detalle de conservación</b><br />
                        <b id="inta">Intervenciones anteriores</b><br /><br />
                        <b id="afec">Afectación</b><br /><br />
                        <b id="trat">Tratamiento</b><br /><br />
                        <b id="limp">Limpieza</b><br /><br />
                    </div>
                    <div id="excab_res">
                        <p id="integridad"></p>
                        <p id="conserv_bien"></p>
                        <p id="detalle_cons"></p>
                        <p id="interv_ant"></p>
                        <p id="afectacion"></p>
                        <p id="tratamiento"></p>
                        <p id="limpieza"></p>
                    </div>
                </div>
                <div id="obs">
                    <p id="obse"><b>7. OBSERVACIONES</b></p>
                </div>
                <div id="obs_det">
                    <p id="deta_obs"></p>
                </div>
                <div id="rec">
                    <p id="reco"><b>8. RECOMENDACIONES</b></p>
                </div>
                <div id="rec_det">
                    <div id ="rec_tit">
                        <b>Temperatura</b><br /><br />
                        <b>Humedad</b><br /><br />
                        <b>Manipulación</b><br /><br />
                    </div>
                    <div id="rec_deta">
                        <p id="temperatura"></p>
                        <p id="humedad"></p>
                        <p id="manipulacion"></p>
                    </div>
                </div>
            </div>              
        </div>
        <div id="footer">
            <a class="btn btn-success" id="crearpdf">Imprimir PDF</a>
        </div>
        
    </form>
</body>
</html>
