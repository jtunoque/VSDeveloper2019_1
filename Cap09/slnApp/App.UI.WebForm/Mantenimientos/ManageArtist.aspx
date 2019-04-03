<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ManageArtist.aspx.cs"
    Inherits="App.UI.WebForm.Mantenimientos.ManageArtist"
    MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-inline">
        <div class="form-group mb-10">
            <asp:TextBox ID="txtFiltroPorNombre" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
         <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
    </div>
    <br />
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
    <br />
    <asp:GridView ID="gvListado" runat="server" CssClass="table"
        GridLines="None" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Nombre" />
            <asp:HyperLinkField HeaderText="Acción"
                Text="Editar"
                DataNavigateUrlFormatString="NewArtist.aspx?id={0}&name={1}"
                DataNavigateUrlFields="ArtistId,Name"
                />



        </Columns>

    </asp:GridView>

</asp:Content>




