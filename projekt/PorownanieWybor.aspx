<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PorownanieWybor.aspx.cs" Inherits="KatalogTelefonow.PorownanieWybor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    Porównaj
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="ddlContainer">
        <div id="ddlLewy">
            <asp:DropDownList ID="ddlModel1" runat="server" />
        </div>
        <div id="ddlPrawy">
            <asp:DropDownList ID="ddlModel2" runat="server" />
        </div>
        <div id="divSrodek">
            VS
        </div>
    </div><br />
    <div id="validator">
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Nie można porównać tego samego telefonu!" ControlToValidate="ddlModel1" ControlToCompare="ddlModel2" Operator="NotEqual" CssClass="error" Display="Dynamic" />
    </div>
    <div id="centerButtonDiv">
        <asp:Button ID="btZatwierdz" runat="server" Text="Zatwierdź" OnClick="btZatwierdz_Click" />
    </div>
</asp:Content>
