<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SzukajWybor.aspx.cs" Inherits="KatalogTelefonow.SzukajWybor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    Szukaj
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div>
        Fragment nazwy: 
        <asp:TextBox ID="tbNazwa" runat="server" /><br />
        <div id="validator">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nazwa nie może być pusta!" ControlToValidate="tbNazwa" CssClass="error" Display="Dynamic" />
        </div>
        <asp:Button ID="btZatwierdz" runat="server" Text="Zatwierdź" OnClick="btZatwierdz_Click" />
    </div>
</asp:Content>
