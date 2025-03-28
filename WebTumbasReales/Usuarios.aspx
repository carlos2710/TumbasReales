<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Usuarios.aspx.vb" Inherits="Usuarios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>	.: Club de la Unión :.</title>
    <script type="text/javascript" src='assets/js/jquery.dataTables.min.js'></script>
    <link rel='stylesheet' href='assets/css/jquery.dataTables.min.css'/>   
    <script src='assets/js/funcionesDataTable.js?y=2'></script>

    <script src="assets/js/bootstrap-datepicker.js" type="text/javascript"></script>
    
    <link rel='stylesheet' href='assets/css/validaform.css'/> 

<script  type="text/javascript" >
    var nombre_raiz;
    var codigo_raiz;
    var lstRaiz;
    var aDataM = [];
    var aDataFM = [];
    var aDataUF = [];

    jQuery(document).ready(function () {
        //fnResetDataTableTramite('tbMenus', 0, 'desc');
        //fnResetDataTableTramite('tbFunciones', 0, 'desc');
        fnResetDataTableTramite('tbUsuarios', 0, 'desc');
        $('#btnAgregarMenu').click(function () {
            limpia();
            $('div#mdMenu').modal('show');
        });

        document.getElementById('chkRaiz').style.visibility = 'visible';
        document.getElementById('chkRaiz2').style.visibility = 'hidden';

        //fnLstMenus();
        //fnTablaMenus();

        //lstRaiz = fnCargaLista("lstRaiz");
        //var jsonStringU = JSON.parse(lstRaiz);

        //$('#txtCodigoRaiz').autocomplete({
        //    source: $.map(jsonStringU, function (item) {
        //        return item.nombre_raiz;
        //    }),
        //    select: function (event, ui) {
        //        var selectecItem = jsonStringU.filter(function (value) {
        //            return value.nombre_raiz == ui.item.value;
        //        });
        //        codigo_raiz = selectecItem[0].codigo_raiz;
        //        nombre_raiz = selectecItem[0].nombre_raiz;
        //        $('#txtRaiz').val(codigo_raiz);
        //    },
        //    minLength: 3,
        //    delay: 100
        //});

        //$('#txtCodigoRaiz').keyup(function () {
        //    var l = parseInt($(this).val().length);
        //    if (l == 0) {
        //        codigo_raiz = "";
        //        nombre_raiz = "";
        //    }
        //});

        $('#chkbxRaiz').change(function () {
            if ($(this).is(':checked')) {
                document.getElementById('chkRaiz').style.visibility = 'visible';
                document.getElementById('chkRaiz2').style.visibility = 'visible';
            } else {
                $('#txtRaiz').val(0);
                document.getElementById('chkRaiz').style.visibility = 'visible';
                document.getElementById('chkRaiz2').style.visibility = 'hidden';
            }
        });

        $("#btnGuardarMenu").click(fnGuardarMenu);
        $("#btnDelReg").click(fnDelRegistro);
        $("#btnDelRegUsuFn").click(fnDelRegUsuFn);

        fnLstFunciones();

        //fnLstFuncionMenu($('#cbFunciones').val());
        //fnTablaFuncionMenu();

        $("#cbFunciones").change(function () {
            fnLstFuncionMenu($('#cbFunciones').val());
            fnTablaFuncionMenu();
        });

        $("#btnGuardarFnMenu").click(fnGuardarFnMenu);

        fnLstPersonaFuncion();
        fnTablaPersonaFuncion();

        $('#btnUsuarioFuncion').click(function () {
            limpiaUsuFn();
            $('div#mdUsuarioFuncion').modal('show');
        });

        //fnLstFuncionesUsu();

        $("#btnAgregarUsuFuncion").click(fnAgregarUsuFuncion);

        permisos();

    });

    function permisos() {
        if ($("#tfu").val() == "3" || $("#tfu").val() == "5") {
            $("#btnUsuarioFuncion").hide();
            $("#btnAgregarUsuFuncion").hide();
            $("#btnDelRegUsuFn").hide();
        } else {
            $("#btnUsuarioFuncion").show();
            $("#btnAgregarUsuFuncion").show();
            $("#btnDelRegUsuFn").show();
        }
    }

    function fnBorrarGUF(c,d) {
        $("#param1").val(c);
        $("#DatoUfn").html("<label class='col-md-12 control-label'> Desea Confirmar la Eliminaci&oacute;n a: " + d + "</label>");
        $('div#mdDelRegistroUsuFn').modal('show');
        return true;
    }

    function limpiaUsuFn() {
        $('#hdTipo').val("G");
        $('#param0').val("");
        $('#param1').val("");
        $('#txtPaterno').val("");
        $('#txtMaterno').val("");
        $('#txtNombres').val("");
        $('#txtDNI').val("");
        $("#c5").attr('checked', true);
        $("#c7").attr('checked', false);
        $('#txtEmail').val("");
        $('#txtEmail2').val("");
        $('#dpTipoInst').val("0");
        $('#cboFunciones').val("0");
        $('#hdTSexo').val("");
    }

    function fnAgregarUsuFuncion() {
        var sw = 0;
        var sws = "";
        var mensaje = "";
        if ($("#txtEmail2").val() != "") {
            if ($("#emailpri2").val() == "1") {
                sw = 1;
                mensaje = "Email primario con formato incorrecto";
            }
        }
        if ($("#txtEmail").val() != "") {
            if ($("#emailpri").val() == "0") {
                sw = 1;
                mensaje = "Email primario con formato incorrecto";
            }
        } else {
            sw = 1;
            mensaje = "Debe ingresar Email primario";
        }
        if ($("#cboFunciones").val() == "0") {
            sw = 1;
            mensaje = "Seleccione Función";
        }
        if ($("[name='radio']:checked").val() != undefined) {
            sws = $("[name='radio']:checked").val();
            $("#hdTSexo").val(sws);
        }
        if (sws == "") {
            sw = 1;
            mensaje = "Seleccion Tipo de Sexo";
        }
        if ($("#txtDNI").val() == "") {
            sw = 1;
            mensaje = "Ingrese Documento de Identidad (DNI)";
        }
        if ($("#txtNombres").val() == "") {
            sw = 1;
            mensaje = "Ingrese Nombres";
        }
        if ($("#txtMaterno").val() == "") {
            sw = 1;
            mensaje = "Ingrese Apellido Materno";
        }
        if ($("#txtPaterno").val() == "") {
            sw = 1;
            mensaje = "Ingrese Apellido Paterno";
        }
        if (sw == 1) {
            fnMensaje("error", mensaje);
        }
        else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gUsuarioFuncion");
            var form = $('#frmUsuarios').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                success: function (data) {
                    fnMensaje(data[0].alert, data[0].msje);
                    //if ($("#file_foto").val() != "") {
                    //    SubirArchivo(data[0].Code, "FOTOU");
                    //}

                    fnLstPersonaFuncion();
                    fnTablaPersonaFuncion();

                    if (data[0].alert == "error") {
                        return false;
                    } else {

                        $('.piluku-preloader').addClass('hidden');
                        f_Menu("Usuarios.aspx");
                    }
                },
                error: function (result) {
                    $('.piluku-preloader').addClass('hidden');
                    return false;
                }
            });
            //document.getElementById("param0").value = "";
            $("#param0").val("");
            $('div#mdMenu').modal('hide');
        }
    }

    function SubirArchivo(cod, tipo) {
        var flag = false;
        try {

            var data = new FormData();
            data.append("param0", "SurbirArchivoNew");
            data.append("codigo", cod);
            data.append("tipo", tipo);

            if (tipo == "FOTOU") {
                var files = $("#file_foto").get(0).files;
                if (files.length > 0) {
                    data.append("ArchivoASubir", files[0]);
                }
            }

            if (files.length > 0) {
                $.ajax({
                    type: "POST",
                    url: "processmuseo.aspx",
                    data: data,
                    dataType: "json",
                    cache: false,
                    contentType: false,
                    processData: false,
                    async: false,
                    success: function (data) {
                        flag = true;
                        //console.log('ARCHIVO SUBIDO');
                    },
                    error: function (result) {
                        //console.log('falseee');
                        flag = false;
                    }
                });
            }
            return flag;

        }
        catch (err) {
            return false;
        }
    }

    function fnLstFuncionesUsu() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstFuncionesUsu" },
            dataType: "json",
            async: false,
            success: function (data) {
                var i = 0;
                var t = '';
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        t += '<option value="' + data[i].codigo + '" ' + data[i].selected + '>' + data[i].descripcion + '</option>';
                    }
                }
                $('#cboFunciones').html(t);
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function fnLstPersonaFuncion() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstUsuarioFuncion" },
            dataType: "json",
            async: false,
            success: function (data) {
                aDataUF = data;
            },
            error: function (result) {
                console.log('error');
            }
        });

    }

    function fnTablaPersonaFuncion() {
        var tb = '';
        var i = 0;
        var mostrar = '';
        var contador = 0;
        var tipo_sexo = ''
        if (aDataUF.length > 0) {
            for (i = 0; i < aDataUF.length; i++) {
                contador = contador + 1;
                if (aDataUF[i].sexo_per == 'M') {
                    tipo_sexo = 'Hombre';
                } else {
                    tipo_sexo = 'Mujer';
                }
                tb += '<tr>';
                tb += '<td>';
                tb += '<center><a href="#" class="btn btn-green btn-xs" onclick="fnEditarUF(\'' + aDataUF[i].codigo + '\')" ><i class="ion-edit"></i></a>';
                tb += '<a href="#" class="btn btn-red btn-xs" onclick="fnBorrarGUF(\'' + aDataUF[i].codigo + '\',\'' + aDataUF[i].colaborador + '\')" ><i class="ion-android-cancel"></i></a></td>';
                tb += '</center></td>';
                tb += '<td style="text-align:center">' + aDataUF[i].colaborador + '</td>';
                tb += '<td style="text-align:center">' + tipo_sexo + '</td>';
                tb += '<td style="text-align:center">' + aDataUF[i].nroDocIdent_per + '</td>';
                tb += '<td style="text-align:center">' + aDataUF[i].eMail_per + '</td>';
                tb += '<td style="text-align:center">' + aDataUF[i].email2_per + '</td>';
                //tb += '<td style="text-align:center">' + aDataUF[i].funcion + '</td>';
                tb += '</tr>';
            }
        } else {
            tb = "";
        }
        fnDestroyDataTableDetalle('tbUsuarios');
        $('#pUsuarios').html(tb);
        fnResetDataTableTramite('tbUsuarios', 0, 'asc');

    }

    function fnGuardarFnMenu() {
        CapturarDetalle();
        if ($('#hdDetalle').val() == "") {
            fnMensaje("error", "Seleccione al menos una fila");
        } else {
            $('#param1').val();
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gactualizarFuncionMenu");
            var form = $('#frmUsuarios').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                success: function (data) {
                    fnMensaje(data[0].alert, data[0].msje);
                    $('.piluku-preloader').addClass('hidden');
                    f_Menu("Usuarios.aspx");
                },
                error: function (result) {
                    $('.piluku-preloader').addClass('hidden');
                    f_Menu("Usuarios.aspx");
                }
            });
            //document.getElementById("param0").value = "";
            $("#param0").val("");
            $("#param1").val("");
            $("#hdDetalle").val("");
        }
    }

    function CapturarDetalle() {
        var form = document.all("frmUsuarios");
        var contador = 0
        var detalle = ""
        $('#tbFunciones').DataTable().$('input[type="checkbox"]').each(function () {
            if (this.checked) {
                if (contador > 0) {
                    detalle = detalle + ",";
                }
                detalle = detalle + this.value;
            }
            contador++;
        });
        //alert(detalle);
        $('#hdDetalle').val(detalle);

    }

    function fnLstFunciones() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstFunciones" },
            dataType: "json",
            async: false,
            success: function (data) {
                var i = 0;
                var t = '';
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        t += '<option value="' + data[i].codigo + '" ' + data[i].selected + '>' + data[i].descripcion + '</option>';
                    }
                }
                $('#cboFunciones2').html(t);
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function fnLstFuncionMenu(param1) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstfuncionMenu", "param1": param1 },
            dataType: "json",
            async: false,
            success: function (data) {
                aDataFM = data;
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function fnTablaFuncionMenu() {
        var tb = '';
        var i = 0;
        var mostrar = '';
        var contador = 0;
        if (aDataFM.length > 0) {
            for (i = 0; i < aDataFM.length; i++) {
                contador = contador + 1;
                tb += '<tr>';
                tb += '<td></td>';
                if (aDataFM[i].seleccion != 0) {
                    tb += '<td><div class="ms-hover""><input type="checkbox" class="mark-complete" name="chkAC[' + i + ']" id="chkAC[' + i + ']" value="' + aDataFM[i].codigo + '" checked >';
                    tb += '<label for="chkAC[' + i + ']" control-label><span></span>Raiz</label></div>';
                } else {
                    tb += '<td><div class="ms-hover""><input type="checkbox" class="mark-complete" name="chkAC[' + i + ']" id="chkAC[' + i + ']" value="' + aDataFM[i].codigo + '" >';
                    tb += '<label for="chkAC[' + i + ']" control-label><span></span>Raiz</label></div>';
                }
                tb += '<input type="hidden" id="txtComp[' + i + ']" name="txtComp[' + i + ']" value="' + aDataFM[i].codigo + '" /></td>';
                tb += '<td style="text-align:center">' + aDataFM[i].draiz + '</td>';
                tb += '<td style="text-align:center">' + aDataFM[i].descripcion + '</td>';
                tb += '</tr>';
            }
        } else {
            tb = "";
        }
        fnDestroyDataTableDetalle('tbFunciones');
        $('#pFunciones').html(tb);
        fnResetDataTableTramite('tbFunciones', 0, 'asc');

    }

    function fnCargaLista(param) {
        try {
            var arr;
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: { "param0": param },
                async: false,
                cache: false,
                success: function (data) {
                    arr = data;
                },
                error: function (result) {
                    arr = null;
                }
            })
            return arr;
        }
        catch (err) {
            //alert(err.message);
            console.log('error');
        }
    }

    function fnGuardarMenu() {
        var sw = 0;
        var mensaje = "";
        var estadochkbx = ($('#chkbxRaiz').is(':checked')) ? $('#chkbxRaiz').val() : '';

        if (estadochkbx == "0") {
            if ($("#txtIcono").val() == "") {
                sw = 1;
                mensaje = "Ingrese Icono";
            }
        }
        else {
            if ($("#txtCodigoRaiz").val() == "") {
                sw = 1;
                mensaje = "Seleccione Raiz";
            }
            if ($("#txtEnlace").val() == "") {
                sw = 1;
                mensaje = "Ingrese Enlace";
            }
        }
        if ($("#txtOrden").val() == "") {
            sw = 1;
            mensaje = "Ingrese Orden";
        }
        if ($("#txtNivel").val() == "") {
            sw = 1;
            mensaje = "Ingrese Nivel";
        }
        if ($("#txtDescripcion").val() == "") {
            sw = 1;
            mensaje = "Ingrese Descripción de menu";
        }

        if (sw == 1) {
            fnMensaje("error", mensaje);
        }
        else {
            $('.piluku-preloader').removeClass('hidden');
            $("input#param0").val("gMenu");
            var form = $('#frmUsuarios').serialize();
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "processmuseo.aspx",
                data: form,
                dataType: "json",
                success: function (data) {
                    fnMensaje(data[0].alert, data[0].msje);
                    $('.piluku-preloader').addClass('hidden');
                    f_Menu("Usuarios.aspx");
                },
                error: function (result) {
                    $('.piluku-preloader').addClass('hidden');
                    f_Menu("Usuarios.aspx");
                }
            });
            //document.getElementById("param0").value = "";
            $("#param0").val("");
            $('div#mdMenu').modal('hide');

        }
    }

    function fnLstMenus() {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: { "param0": "lstMenu" },
            dataType: "json",
            async: false,
            success: function (data) {
                aDataM = data;
            },
            error: function (result) {
                console.log('error');
            }
        });
    }

    function fnTablaMenus() {
        var tb = '';
        var i = 0;
        var mostrar = '';
        var contador = 0;
        if (aDataM.length > 0) {
            for (i = 0; i < aDataM.length; i++) {
                contador = contador + 1;
                tb += '<tr>';
                tb += '<td>';
                tb += '<center><a href="#" class="btn btn-green btn-xs" onclick="fnEditar(\'' + aDataM[i].codigo + '\')" ><i class="ion-edit"></i></a>';
                tb += '<a href="#" class="btn btn-red btn-xs" onclick="fnBorrarG(\'' + aDataM[i].codigo + '\')" ><i class="ion-android-cancel"></i></a></td>';
                tb += '</center></td>';
                tb += '<td style="text-align:center">' + aDataM[i].item + '</td>';
                tb += '<td style="text-align:center">' + aDataM[i].descripcion_Men + '</td>';
                tb += '<td style="text-align:center">' + aDataM[i].enlace + '</td>';
                tb += '<td style="text-align:center">' + aDataM[i].nivel_men + '</td>';
                tb += '<td style="text-align:center">' + aDataM[i].orden_men + '</td>';
                tb += '</tr>';
            }
        } else {
            tb = "";
        }
        fnDestroyDataTableDetalle('tbMenus');
        $('#pMenus').html(tb);
        fnResetDataTableTramite('tbMenus', 0, 'asc');

    }

    function limpia() {
        $('#chkbxRaiz').prop('checked', true);
        document.getElementById('chkRaiz').style.visibility = 'visible';
        document.getElementById('chkRaiz2').style.visibility = 'hidden';
        $('#param0').val("");
        $('#param1').val("");
        $('#txtDescripcion').val("");
        $('#txtNivel').val("");
        $('#txtOrden').val("");
        $('#txtEnlace').val("");
        $('#txtCodigoRaiz').val("");
        $('#txtIcono').val("");
        $('#hdTipo').val("G");
    }

    function fnBorrarG(c) {
        $("#param1").val(c);
        $("#Dato").html("<label class='col-md-12 control-label'> Desea Confirmar la Eliminaci&oacute;n del Registro: " + c + "</label>");
        $('div#mdDelRegistroMenu').modal('show');
        return true;
    }

    function fnBuscar(c) {
        var i;
        var j = -1;
        var l;
        l = aDataM.length;
        for (i = 0; i < l; i++) {
            if (aDataM[i].codigo == c) {
                j = i;
                return j;
            }
        }
    }

    function fnBuscarUF(c) {
        var i;
        var j = -1;
        var l;
        l = aDataUF.length;
        for (i = 0; i < l; i++) {
            if (aDataUF[i].codigo == c) {
                j = i;
                return j;
            }
        }
    }

    function fnEditarUF(c) {
        var x = fnBuscarUF(c);
        if (x >= 0) {
            $('#param1').val(aDataUF[x].codigo);
            $('#txtPaterno').val(aDataUF[x].apellidoPat_per);
            $('#txtMaterno').val(aDataUF[x].apellidoMat_per);
            $('#txtNombres').val(aDataUF[x].nombres_per);
            $('#txtDNI').val(aDataUF[x].nroDocIdent_per);
            $('#txtEmail').val(aDataUF[x].eMail_per);
            $('#txtEmail2').val(aDataUF[x].email2_per);
            $('#cboFunciones2').val(aDataUF[x].codigotfu);
            if (aDataUF[x].foto_per != "") {
                $("#divFoto").html("<a href='" + aDataUF[x].foto_per + "' target='_blank' style='font-weight:bold'>Descargar</a>")
            } else {
                $("#divFoto").html("");
            }
            if (aDataUF[x].sexo_per == "M") {
                $("#c5").attr('checked', true);
                $("#c7").attr('checked', false);
            } else {
                $("#c7").attr('checked', true);
                $("#c5").attr('checked', false);

            }
            $('#hdTipo').val("A");
        }
        $('div#mdUsuarioFuncion').modal('show');
        return true;
    }

    function fnEditar(c) {
        var x = fnBuscar(c);
        if (x >= 0) {
            $('#param1').val(aDataM[x].codigo);
            $('#txtDescripcion').val(aDataM[x].descripcion_Men);
            $('#txtNivel').val(aDataM[x].nivel_men);
            $('#txtOrden').val(aDataM[x].orden_men);
            $('#txtEnlace').val(aDataM[x].enlace);
            //$('#txtCodigoRaiz').val(aData[x].codigoRaiz_Men);
            $('#txtIcono').val(aDataM[x].icono);
            $('#hdTipo').val("A");
            if (aDataM[x].codigoRaiz_Men == '0') {
                $('#chkbxRaiz').prop('checked', true);
                document.getElementById('chkRaiz').style.visibility = 'visible';
                document.getElementById('chkRaiz2').style.visibility = 'visible';
            } else {
                $('#chkbxRaiz').prop('checked', false);
                document.getElementById('chkRaiz').style.visibility = 'visible';
                document.getElementById('chkRaiz2').style.visibility = 'hidden';
            }
        }
        $('div#mdMenu').modal('show');
        return true;
    }

    function fnDelRegUsuFn() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("DelUsuFn");
        var form = $('#frmUsuarios').serialize();
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: form,
            dataType: "json",
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                $('.piluku-preloader').addClass('hidden');
                f_Menu("Usuarios.aspx");
            },
            error: function (result) {
                $('.piluku-preloader').addClass('hidden');
                f_Menu("Usuarios.aspx");
            }
        });
        //document.getElementById("param0").value = "";
        $("#param0").val("");
        $("#param1").val("");
        $('div#mdDelRegistroUsuFn').modal('hide');
    }

    function fnDelRegistro() {
        $('.piluku-preloader').removeClass('hidden');
        $("input#param0").val("DelMenu");
        var form = $('#frmUsuarios').serialize();
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "processmuseo.aspx",
            data: form,
            dataType: "json",
            success: function (data) {
                fnMensaje(data[0].alert, data[0].msje);
                $('.piluku-preloader').addClass('hidden');
                f_Menu("Usuarios.aspx");
            },
            error: function (result) {
                $('.piluku-preloader').addClass('hidden');
                f_Menu("Usuarios.aspx");
            }
        });
        //document.getElementById("param0").value = "";
        $("#param0").val("");
        $("#param1").val("");
        $('div#mdDelRegistroMenu').modal('hide');
    }

    function soloNumeros(e) {
        var key = window.Event ? e.which : e.keyCode
        return (key >= 48 && key <= 57)
    }

    function validateMail1(idMail) {
        object = document.getElementById(idMail);
        valueForm = object.value;

        var patron = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
        if (valueForm.search(patron) == 0 ) {
            object.style.color = "#a1a5ac";
            document.getElementById("emailpri").value = "1";

        } else {
            object.style.color = "#f00";
            document.getElementById("emailpri").value = "0";
        }
    }
    
    function validateMail2(idMail) {
        object = document.getElementById(idMail);
        valueForm = object.value;

        var patron = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
        if (valueForm.search(patron) == 0 ) {
            object.style.color = "#a1a5ac";
            document.getElementById("emailpri2").value = "1";

        } else {
            object.style.color = "#f00";
            document.getElementById("emailpri2").value = "0";
        }
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


</script>


</head>

<body  class="" runat="server" id="bodyPrincipal" >

    <form id="frmUsuarios" name="frmUsuarios">	
    <input type="hidden" id="hdTipo" name="hdTipo" value="" />
    <input type="hidden" id="hdTipoUsu" name="hdTipoUsu" value="" />
    <input type="hidden" id="param0" name="param0" value="" />   
    <input type="hidden" id="param1" name="param1" value="" /> 
    <input type="hidden" id="user" name="user" value="" />
    <input type="hidden" id="txtRaiz" name="txtRaiz" value="0" />
    <input type="hidden" id="hdDetalle" name="hdDetalle" value="" />     
    <input type="hidden" id="hdTSexo" name="hdTSexo" value="" />  
    <input type="hidden" id="emailpri" name="emailpri" value="" />  
    <input type="hidden" id="emailpri2" name="emailpri2" value="" />  
    <input type="hidden" id="tfu" name="tfu" value="" runat="server"/> 

    <div class="panel panel-piluku">
        <div class="panel-heading">
		    <h3 class="panel-title">
			        USUARIOS        
		    </h3>
	    </div>	  
	    <div class='table-responsive'>	        
            <div class='panel-body' >
                 <div role="tabpanel" >
				    <ul class="nav nav-tabs piluku-tabs" role="tablist" >
                        <li role="presentationUsuarios" class="active" id="Li3" runat="server" ><a href="#tabUsuarios" aria-controls="home" role="tab" data-toggle="tab" > Usuarios</a></li>
					    <%--<li role="presentationUsuarios"  id="Li1" runat="server" ><a href="#tabMenus" aria-controls="profile" role="tab" data-toggle="tab" > Lista de men&uacute;s</a></li>
					    <li role="presentationUsuarios" id="Li2" runat="server" ><a href="#tabFunciones" aria-controls="profile" role="tab" data-toggle="tab" > Funciones</a></li>--%>
				    </ul>
    				<br />
				    <div class="tab-content piluku-tab-content">

                        <div role="tabpanel" class="tab-pane active" id="tabUsuarios" runat="server" >
                            <div class='table-responsive'>
                                <table class='display dataTable cell-border' id='tbUsuarios' style="width:100%;font-size:smaller">
                                    <thead>
                                    <tr>
                                        <th style="width:6%;text-align:center;"></th>
                                        <th style="width:25%;">Usuarios</th>
                                        <th style="width:10%;">Sexo</th>
                                        <th style="width:15%;">Nro Doc</th>
                                        <th style="width:15%;">Email</th>
                                        <th style="width:15%;">Email 2</th>
                                        <%--<th style="width:10%;">Funci&oacute;n</th>--%>
                                    </tr>
                                    </thead>     
                                    <tbody id ="pUsuarios" runat ="server">
                                    </tbody>                             
                                    <tfoot>
                                        <tr>
                                            <%--<th colspan="7"></th>--%>
                                            <th colspan="6"></th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>  
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnUsuarioFuncion" ><i class="ion-android-add-circle"></i>&nbsp;Agregar Usuario</button>	
		                           </div>
		                      </center>
		                    </div>


				        </div>


                    </div> 
                    
	            </div>    
            </div> 
        <br />  
                                
        </div> 
    </div>



<div class="modal fade" id="mdMenu" role="dialog" aria-labelledby="myModalLabel" style="z-index: 5;" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;">
                        <div class="modal-dialog modal-lg" id="Div5">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Men&uacute;</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <div class="tab-content piluku-tab-content">
					    <div role="tabpanel" class="tab-pane active" id="tabIdentificacion" runat="server" >
                             <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtDescripcion">
                                        Descripción:</label>
                                    <div class="col-sm-4">
                                        <input type="text" id="txtDescripcion" name="txtDescripcion" class="form-control" />
                                    </div>
                                </div>
                                </div>
                                <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtNivel">
                                        Nivel [1-9]:</label>
                                    <div class="col-sm-2">
                                        <input type="text" id="txtNivel" name="txtNivel" class="form-control" onKeyPress="return soloNumeros(event)" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtOrden">
                                        Orden [1-9]:</label>
                                    <div class="col-sm-2">
                                        <input type="text" id="txtOrden" name="txtOrden" class="form-control" onKeyPress="return soloNumeros(event)" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">				        
                                    <div class="col-md-3">
                                        <div class="ms-hover">                            
                                            <input type="checkbox" class="mark-complete" id="chkbxRaiz" value="0" />
                                            <label for="chkbxRaiz" control-label><span></span>Codigo Raiz</label>
                                        </div>    
					                </div>					    
			                    </div>
			                </div>
                            <div id="chkRaiz">	        
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="txtEnlace">
                                            Enlace:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtEnlace" name="txtEnlace" class="form-control"  />
                                        </div>
                                    </div>
                                </div>
			                </div>
                            <div  id="chkRaiz2">	
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="txtCodigoRaiz">
                                            Raiz:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtCodigoRaiz" name="txtCodigoRaiz" class="form-control" />
                                        </div>
                                    </div>
                                </div>     
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="txtIcono">
                                            Icono:</label>
                                        <div class="col-sm-4">
                                            <input type="text" id="txtIcono" name="txtIcono" class="form-control" />
                                        </div>
                                    </div>
                                </div>
			                </div>
                                
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnGuardarMenu" ><i class="ion-android-done"></i>&nbsp;Guardar Men&uacute;</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
                    </div> 
                    
	            </div> 
            </div> 

        </div>
    </div>
</div>
</div>


<div class="modal fade" id="mdDelRegistroMenu" role="dialog" aria-labelledby="myModalLabel" style="z-index: 5;" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 0;">
<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header" style="background-color:#E33439;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Confirmar Operaci&oacute;n</h4>
		</div>
		<div class="modal-body">
            <div class="row">
	            <div class="col-md-12" id="Dato">
	                
	            </div>
            </div>
	            
		</div>		
		<div class="modal-footer">
		  <center>
		      <div class="btn-group">			      
		            <button type="button" class="btn btn-primary" id="btnDelReg" ><i class="ion-android-done"></i>&nbsp;SI</button>	
		            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="ion-android-cancel"></i>&nbsp;NO</button>		
		       </div>
		  </center>
		</div>
	</div>
</div>
</div>

<div class="modal fade" id="mdDelRegistroUsuFn" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;"> 
<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header" style="background-color:#E33439;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Confirmar Operaci&oacute;n</h4>
		</div>
		<div class="modal-body">
            <div class="row">
	            <div class="col-md-12" id="DatoUfn">
	                
	            </div>
            </div>
	            
		</div>		
		<div class="modal-footer">
		  <center>
		      <div class="btn-group">			      
		            <button type="button" class="btn btn-primary" id="btnDelRegUsuFn" ><i class="ion-android-done"></i>&nbsp;SI</button>	
		            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="ion-android-cancel"></i>&nbsp;NO</button>		
		       </div>
		  </center>
		</div>
	</div>
</div>
</div>
    
<div class="modal fade" id="mdUsuarioFuncion" role="dialog" aria-labelledby="myModalLabel" style="z-index: 5;" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="z-index: 5;">
                        <div class="modal-dialog modal-lg" id="Div2">
	<div class="modal-content ">
		<div class="modal-header" style="background-color:#4C4C4C;" >
			<button type="button" class="close" data-dismiss="modal" aria-label="Close" style="color:White;"><span aria-hidden="true" class="ti-close" style="color:White;"></span></button>
			<h4 class="modal-title"  style="color:White">Registrar/Actualizar Usuario</h4>
		</div>
		<div class="modal-body">
            <div class="panel-body">
	            <div role="tabpanel" >
				    <div class="tab-content piluku-tab-content">
					    <div role="tabpanel" class="tab-pane active" id="Div3" runat="server" >
                             <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtPaterno">
                                        Apellido Paterno:</label>
                                    <div class="col-sm-5">
                                        <input type="text" id="txtPaterno" name="txtPaterno" class="form-control" onkeyup="this.value = this.value.toUpperCase();"/>
                                    </div>
                                </div>
                                </div>
                                <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtMaterno">
                                        Apellido Materno:</label>
                                    <div class="col-sm-5">
                                        <input type="text" id="txtMaterno" name="txtMaterno" class="form-control" onkeyup="this.value = this.value.toUpperCase();" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtNombres">
                                        Nombres:</label>
                                    <div class="col-sm-5">
                                        <input type="text" id="txtNombres" name="txtNombres" class="form-control" onkeyup="this.value = this.value.toUpperCase();"/>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtDNI">
                                        DNI:</label>
                                    <div class="col-sm-3">
                                        <input type="text" id="txtDNI" name="txtDNI" class="form-control" onKeyPress="return soloNumeros(event,this)"/>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtFoto">
                                        Foto:</label>
                                        <div class="col-sm-8">
                                            <input type="file" id="file_foto" name="file_foto" />
                                            <div id="divFoto">
                                            </div>
                                        </div>
                                </div>
                            </div>--%>
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtNombres">
                                        Sexo:</label>
                                    <div class="col-sm-4">
                                        <ul class="list-inline checkboxes-radio">
                                            <li class="ms-hover has-success">
									            <input name="radio" type="radio" data-validation="required" value="M" id="c5" class="valid" />
									            <label for="c5"><span></span>Hombre</label>
								            </li>
                                            <li class="ms-hover">
									            <input name="radio" type="radio" value="F" id="c7" />
									            <label for="c7"><span></span>Mujer</label>
								            </li>

                                        </ul>
                                    </div>
                                </div>
                            </div>
                           <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtEmail">
                                        Email:</label>
                                    <div class="col-sm-5">
                                        <input type="text" id="txtEmail" name="txtEmail" class="form-control" onKeyUp="javascript:validateMail1('txtEmail')"/>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="txtEmail2">
                                        Email secundario:</label>
                                    <div class="col-sm-5">
                                        <input type="text" id="txtEmail2" name="txtEmail2" class="form-control" onKeyUp="javascript:validateMail2('txtEmail2')" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" for="cboFunciones2">
                                        Funci&oacute;n:</label>
                                    <div class="col-sm-3">
                                        <select class="form-control" id="cboFunciones2" name="cboFunciones2"></select> 
                                    </div>
                                </div>
                            </div>
                                
                            <div class="modal-footer">
		                      <center>
		                          <div class="btn-group">			      
		                                <button type="button" class="btn btn-primary" id="btnAgregarUsuFuncion" ><i class="ion-android-done"></i>&nbsp;Guardar Usuario</button>	
		                           </div>
		                      </center>
		                    </div>
                                
				        </div>
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
