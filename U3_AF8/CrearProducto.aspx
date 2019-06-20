<%@ Page Title="Crear Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CrearProducto.aspx.cs" Inherits="CrearProducto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">Creacion de productos</p>
        <br />
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    Nombre
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="Nombre" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    Marca
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="Marca" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    Precio
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="Precio" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        ControlToValidate="Precio" runat="server"
                        ErrorMessage="Solo debe ingresar numeros"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    Descripcion
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="Descripcion" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" />
    </div>
    

</asp:Content>
