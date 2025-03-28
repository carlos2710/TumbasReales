<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RepCatalogoPDF.aspx.vb" Inherits="RepCatalogoPDF" %>



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

        
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsTumbasReales1TableAdapters.cat_reportePDFTableAdapter">
            <SelectParameters>
                <asp:Parameter Name="codigo_cat" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsTumbasRealesTableAdapters.cat_reportePDFTableAdapter">
            <SelectParameters>
                <asp:Parameter Name="codigo_cat" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsMuseoSipanTableAdapters.cat_reportePDFTableAdapter">
            <SelectParameters>
                <asp:Parameter Name="codigo_cat" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
