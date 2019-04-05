<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewArtist.aspx.cs" Inherits="App.UI.WebForm.Mantenimientos.NewArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div>
  <div class="form-group">
    <label for="txtNombre">Nombre</label>
    <asp:TextBox ID="txtNombre" runat="server" 
        ClientIDMode="Static"
        CssClass="form-control"></asp:TextBox>
  </div>
  <asp:Button ID="btnGrabar" CssClass="btn btn-primary" 
      runat="server" Text="Guardar" OnClick="btnGrabar_Click" />

</div>

</asp:Content>
