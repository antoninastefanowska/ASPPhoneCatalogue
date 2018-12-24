<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Recenzja.aspx.cs" Inherits="KatalogTelefonow.Recenzja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    Prześlij opinię
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div>
        <asp:MultiView ID="MV" runat="server">
            <asp:View ID="view1" runat="server">
                Wybierz model: 
                <asp:DropDownList ID="ddlModele" runat="server" /><br />
                <div>
                    <asp:Button ID="bt1" runat="server" Text="Dalej" OnClick="bt1_Click" />
                </div>
            </asp:View>
            <asp:View ID="view2" runat="server">
                Wybrany model:
                <asp:Label ID="lbModel1" runat="server" Text="[lbModel]" /><br />
                Ocena:
                <asp:DropDownList ID="ddlOcena" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList><br />
                Autor:
                <asp:TextBox ID="tbAutor" runat="server" /><br />
                Treść:<br />
                <div id="trescDiv">
                    <asp:TextBox ID="tbTresc" runat="server" TextMode="MultiLine" CssClass="recenzjaTextBox" />
                </div>
                <div id="validator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pole Autor jest wymagane!" ControlToValidate="tbAutor" CssClass="error" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Nazwa autora może składać się tylko z liter." ValidationExpression="^[^\W\d_]+$" ControlToValidate="tbAutor" CssClass="error" Display="Dynamic"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Treść nie może być pusta." ControlToValidate="tbTresc" CssClass="error" Display="Dynamic" />
                </div>
                <div>
                    <asp:Button ID="bt2" runat="server" Text="Dalej" OnClick="bt2_Click" />                
                </div>
            </asp:View>
            <asp:View ID="view3" runat="server">
                <div class="wyroznienie">Podsumowanie</div>
                <hr />
                Wybrany telefon:
                <asp:Label ID="lbModel2" runat="server" Text="[lbModel]" /><br />
                Autor:
                <asp:Label ID="lbAutor" runat="server" Text="[lbAutor]" /><br />
                Ocena:
                <asp:Label ID="lbOcena" runat="server" Text="[lbOcena]" /><br />
                Treść:<br />
                <asp:Label ID="lbTresc" runat="server" Text="[lbTresc]" />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
