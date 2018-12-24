<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Porownanie.aspx.cs" Inherits="KatalogTelefonow.Porownanie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    Wyniki porównania
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div>
        <asp:GridView ID="Grid" runat="server" AutoGenerateColumns="true" OnRowDataBound="Grid_OnRowDataBound" CssClass="grid" RowStyle-CssClass="gridRow" />
    </div>
</asp:Content>
