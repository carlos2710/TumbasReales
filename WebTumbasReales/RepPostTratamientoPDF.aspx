<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RepPostTratamientoPDF.aspx.vb" Inherits="RepPostTratamientoPDF" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:Button ID="btnGenerarRepCat" runat="server" Text="Visualizar Reporte" Visible="True" />


    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsPostTratamientoTableAdapters.posttrat_reportePDFTableAdapter">
            <SelectParameters>
                <asp:Parameter Name="cod_prop" Type="String" />
                <asp:Parameter Name="id_dgc" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
