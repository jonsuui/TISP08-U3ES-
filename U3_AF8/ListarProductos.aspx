<%@ Page Title="Listar Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ListarProductos.aspx.cs" Inherits="ListarProductos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">Listar productos</p>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvwProductos" runat="server" AutoGenerateColumns="false" DataKeyNames="Id_producto" OnPageIndexChanging="gvwProductos_PageIndexChanging" OnRowCancelingEdit="gvwProductos_RowCancelingEdit" OnRowDeleting="gvwProductos_RowDeleting" OnRowEditing="gvwProductos_RowEditing" OnRowUpdating="gvwProductos_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="Id_producto" HeaderText="No." />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" />
                        <asp:BoundField DataField="Precio" HeaderText="precio" DataFormatString="{0:#.##}"/>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:CommandField EditText="Editar" ShowEditButton="true" />
                        <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblresult" runat="server"></asp:Label> 
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Listar" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />

        <br />

    </div>

</asp:Content>


