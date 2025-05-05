<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vuelos.aspx.cs" Inherits="Parcial_1_Kremis_Alexis.Vuelos" %>
<!DOCTYPE html>
<html>
<head>
    <title>ABM Vuelos</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Vuelos</h2>

        ID:
        <asp:TextBox ID="txtId" runat="server" /><br />
        Número de Vuelo:
        <asp:TextBox ID="txtNumeroVuelo" runat="server" /><br />
        Aerolínea:
        <asp:DropDownList ID="ddlAerolinea" runat="server" /><br />
        Modelo de Avión:
        <asp:DropDownList ID="ddlModelo" runat="server" /><br />

        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

        <hr />
        <asp:GridView ID="gvVuelos" runat="server" AutoGenerateColumns="True"
                      AutoGenerateSelectButton="True"
                      OnSelectedIndexChanged="gvVuelos_SelectedIndexChanged" />
    </form>
</body>
</html>