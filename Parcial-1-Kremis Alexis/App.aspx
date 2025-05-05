<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="App.aspx.cs" Inherits="Parcial_1_Kremis_Alexis.App" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listado de Vuelos</title>
    <style>
        body {
            font-family: Arial;
            margin: 20px;
        }

        h2 {
            margin-bottom: 20px;
        }

        .filtro {
            margin-bottom: 10px;
        }

        .grilla {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Listado de Vuelos</h2>
        <div class="filtro">
            <asp:TextBox ID="TextBox1" runat="server" Width="300px" Placeholder="Buscar por Aerolínea o Modelo de Avión" />
            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />
        </div>

        <div class="grilla">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" />
                    <asp:BoundField DataField="numeroVuelo" HeaderText="Número de Vuelo" />
                    <asp:BoundField DataField="Aerolinea" HeaderText="Aerolínea" />
                    <asp:BoundField DataField="ModeloAvion" HeaderText="Modelo de Avión" />
                </Columns>
            </asp:GridView>
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:IssdTP42023ConnectionString %>"
            SelectCommand="">
        </asp:SqlDataSource>

        

   <h2> Redireccion </h2>
 <asp:Button ID="btnIrAerolineas" runat="server" Text="ABM Aerolíneas" OnClick="btnIrAerolineas_Click" />
<asp:Button ID="btnIrModelos" runat="server" Text="ABM Modelos de Avión" OnClick="btnIrModelos_Click" />
<asp:Button ID="btnIrVuelos" runat="server" Text="ABM Vuelos" OnClick="btnIrVuelos_Click" />
    </form>
</body>
</html>
