<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        window.onload = () => {
            var reader = new FileReader(),
                picker = document.getElementById("archivo"),
                table = document.getElementById("table");

            picker.onchange = () => reader.readAsText(picker.files[0]);

            reader.onloadend = () => {
                let csv = reader.result;

                table.innerHTML = "";
                let rows = csv.split("\r\n");

                for (let i = 3; i < rows.length;i++) {
                    
                }
            };
        }
    </script>
</head>
<body>
    <form class="form-inline">

	    <div id="tabla"></div>
        <input type="file" id="archivo" />
        <table id="table"></table>
    </form>
</body>
</html>
