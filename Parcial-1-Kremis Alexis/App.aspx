<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="App.aspx.cs" Inherits="Parcial_1_Kremis_Alexis.App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Campo para ingresar el nombre del sector -->
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Ingrese el nombre del sector"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Filtrar" OnClick="Button1_Click" />
            
            <!-- GridView para mostrar la lista de empleados -->
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="apellido" HeaderText="apellido" SortExpression="apellido" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                </Columns>
            </asp:GridView>
            
            <!-- SqlDataSource que obtiene la lista de empleados -->
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:IssdTP42023ConnectionString %>" 
                SelectCommand="SELECT [id], [apellido], [nombre] FROM [Empleados]" DeleteCommand="DELETE FROM [Empleados] WHERE [id] = @id" InsertCommand="INSERT INTO [Empleados] ([apellido], [nombre]) VALUES (@apellido, @nombre)" UpdateCommand="UPDATE [Empleados] SET [apellido] = @apellido, [nombre] = @nombre WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="apellido" Type="String" />
                    <asp:Parameter Name="nombre" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="apellido" Type="String" />
                    <asp:Parameter Name="nombre" Type="String" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
