﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aerolineas.aspx.cs" Inherits="Parcial_1_Kremis_Alexis.Aerolineas" %>

<!DOCTYPE html>
<html>
<head>
    <title>ABM Aerolíneas</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Aerolíneas</h2>
        ID: <asp:TextBox ID="txtId" runat="server" /><br />
        Nombre: <asp:TextBox ID="txtNombre" runat="server" /><br />

        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

        <hr />
        <asp:GridView ID="gvAerolineas" runat="server" AutoGenerateColumns="True" />
    </form>
</body>
</html>
