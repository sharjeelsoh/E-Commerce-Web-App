<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserPurchaseHistory.aspx.cs" Inherits="TheVintageStore.UserLayer.AdminPages.UserPurchaseHistory" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: USER PURCHASE HISTORY 20/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">


    <h2>MANAGE USERS </h2>
    <h3>PURCHASE HISTORY </h3>

    <div id="Purchases"">
        <asp:Table ID="tblSummary" runat="server"
            CellPadding="10"
            GridLines="None">
            <asp:TableRow BackColor="#ededed">
                <asp:TableCell VerticalAlign="Top">
                                <img src="../Img/ProductModel.png" width="180" height="270" /><br />
                </asp:TableCell>
                <asp:TableCell VerticalAlign="Top">
                    <h4>
                        <asp:Label ID="lblOrderNo" runat="server" Text="Order # 767009"></asp:Label>
                    </h4>
                    <asp:Label ID="lblTitle" runat="server" Text="Levi's Bomber Jacket"></asp:Label><br />
                    <asp:Label ID="lblPrice" runat="server" Text="$49.95 AUD"></asp:Label><br />
                    <asp:Label ID="lblC" runat="server" Text="Color: "></asp:Label>
                    <asp:Label ID="lblColor" runat="server" Text="Blue"></asp:Label><br />
                    <asp:Label ID="lblS" runat="server" Text="Size: "></asp:Label>
                    <asp:Label ID="lblSize" runat="server" Text="Medium"></asp:Label><br />
                    <asp:Label ID="lblQuantity" runat="server" Text="Qty: 1"></asp:Label><br />
                    <asp:Label ID="lblDate" runat="server" Text="Date: 19/03/21"></asp:Label><br />
                    <asp:Label ID="lblTotalP" runat="server" Text="Total: $49.95 AUD"></asp:Label><br />
                    <asp:Label ID="lblStatus" runat="server" Text="Delivered" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

</asp:Content>
