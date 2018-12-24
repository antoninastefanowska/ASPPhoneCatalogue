<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Szukaj.aspx.cs" Inherits="KatalogTelefonow.Szukaj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    Wynik
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:XmlDataSource ID="sourceDetails" runat="server" DataFile="Products.xml" />
    <div id="szczegoly">
        <asp:Label ID="lbKomunikat" runat="server">Nie znaleziono</asp:Label>
        <asp:DetailsView ID="details" runat="server" AutoGenerateRows="false" DataSourceID="sourceDetails" CssClass="details" RowStyle-CssClass="detailsRow" FieldHeaderStyle-CssClass="detailsHeader">
            <Fields>
                <asp:TemplateField HeaderText="Nazwa">
                    <ItemTemplate>
                        <%# XPath("Name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marka">
                    <ItemTemplate>
                        <%# XPath("@Brand") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data wypuszczenia">
                    <ItemTemplate>
                        <%# XPath("Release") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Model">
                    <ItemTemplate>
                        <%# XPath("Model") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Budowa">
                    <ItemTemplate>
                        <%# XPath("Type") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Klawiatura">
                    <ItemTemplate>
                        <%# XPath("Keyboard") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rozmiar wyświetlacza">
                    <ItemTemplate>
                        <%# XPath("Size") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ekran dotykowy">
                    <ItemTemplate>
                        <%# XPath("Touchscreen") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Typ karty SIM">
                    <ItemTemplate>
                        <%# XPath("SIM") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dual-SIM">
                    <ItemTemplate>
                        <%# XPath("DualSIM") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Karta pamięci">
                    <ItemTemplate>
                        <%# XPath("MemoryCard") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pamięć wewnętrzna">
                    <ItemTemplate>
                        <%# XPath("Memory") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pamięć RAM">
                    <ItemTemplate>
                        <%# XPath("RAM") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="System operacyjny">
                    <ItemTemplate>
                        <%# XPath("OperatingSystem") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Wersja systemu">
                    <ItemTemplate>
                        <%# XPath("OperatingSystemVersion") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Procesor">
                    <ItemTemplate>
                        <%# XPath("Chipset") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Taktowanie procesora">
                    <ItemTemplate>
                        <%# XPath("CPU") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Liczba rdzeni">
                    <ItemTemplate>
                        <%# XPath("Cores") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bateria">
                    <ItemTemplate>
                        <%# XPath("Battery") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Aparat">
                    <ItemTemplate>
                        <%# XPath("Camera") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lampa błyskowa">
                    <ItemTemplate>
                        <%# XPath("LED") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Odbiornik radiowy">
                    <ItemTemplate>
                        <%# XPath("Radio") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Komunikacja">
                    <ItemTemplate>
                        <asp:DataList ID="DataList1" runat="server" DataSource='<%# XPathSelect("Communications/Communication") %>' >
                            <ItemTemplate>
                                <%# XPath(".") %><br />
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Czujniki">
                    <ItemTemplate>
                        <asp:DataList ID="DataList2" runat="server" DataSource='<%# XPathSelect("Sensors/Sensor") %>' >
                            <ItemTemplate>
                                <%# XPath(".") %><br />
                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
    </div>
</asp:Content>
