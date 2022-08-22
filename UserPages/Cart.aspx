<%@ Page Title="Cart" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TheVintageStore.UserLayer.Pages.Cart" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: CART 17/26 --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- NO ITEMS YET IN CART --%>
    <div id="divNoItems" runat="server" visible="false">
        <asp:Table runat="server" HorizontalAlign="Center">
            <asp:TableRow VerticalAlign="Middle" HorizontalAlign="Center">
                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                    <h4>
                        <asp:Label runat="server" ID="lblMessage" Text="- Your basket is empty -" CssClass="align-content-center" />
                    </h4>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <%-- LIST VIEW CART --%>
    <asp:ListView ID="ListViewCart" runat="server" GroupItemCount="3" OnItemDataBound="ListViewCart_ItemDataBound" OnPreRender="ListViewCart_PreRender">
        
        <%-- LAYOUT TEMPLATE --%>
        <LayoutTemplate>
            <asp:Table runat="server" HorizontalAlign="Center" CellPadding="10">
                <%-- DISPLAY HEADER AND PRODUCTS --%>
                <asp:TableRow runat="server" HorizontalAlign="Left">
                    <%-- HEADER & IMAGE CELL --%>
                    <asp:TableCell runat="server" ID="img">
                        <h2>SHOPPING BAG </h2>
                        <asp:Label ID="lblItems" runat="server"></asp:Label>
                        <asp:PlaceHolder runat="server" ID="groupPlaceholder"></asp:PlaceHolder>
                    </asp:TableCell>
                    <%-- CONTENT CELL --%>
                    <asp:TableCell runat="server" ID="content">
                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder2"></asp:PlaceHolder>
                    </asp:TableCell>
                </asp:TableRow>
                <%-- FOOTER ROW: DISPLAY TOTAL & CONTINUE BUTTON --%>
                <asp:TableFooterRow HorizontalAlign="Right">
                    <%-- FOR ALIGNMENT PURPOSES --%>
                    <asp:TableCell>
                    </asp:TableCell>
                    <%-- TOTAL & CONTINUE BUTTON --%>
                    <asp:TableCell>
                        <h2>
                            <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                        </h2>
                        <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" CssClass="btn btn-dark" />
                    </asp:TableCell>
                </asp:TableFooterRow>
            </asp:Table>
        </LayoutTemplate>

        <%-- GROUP TEMPLATE --%>
        <GroupTemplate>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </asp:TableCell>
            </asp:TableRow>
        </GroupTemplate>

        <%-- ITEM TEMPLATE --%>
        <ItemTemplate>
            <asp:TableRow runat="server" HorizontalAlign="Left">
                <%-- IMAGE --%>
                <asp:TableCell runat="server" HorizontalAlign="Center" ID="img">
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder">
                        <img id="imgProduct" runat="server" class="img-responsive" width="270" height="405" src='<%# Eval("sImageURL") %>' />
                    </asp:PlaceHolder>
                </asp:TableCell>
                <%-- CONTENT --%>
                <asp:TableCell runat="server" HorizontalAlign="Left" ID="content" VerticalAlign="Top">
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder2">
                        <h4>
                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("sTitle") %>'></asp:Label><br />
                        </h4>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("dPrice") %>'></asp:Label><br />
                        <asp:Label ID="lblColor" runat="server" Text='<%# Eval("sColor") %>'></asp:Label><br />
                        <asp:Label ID="lblSize" runat="server" Text='<%# Eval("sSize") %>'></asp:Label><br />
                        <asp:Button ID="btnMore" runat="server" Text="+" BackColor="White" BorderWidth="0" ForeColor="Black"
                            Font-Size="X-Large" CommandArgument='<%# Eval("iProductCode") %>' OnCommand="btnMore_Command"
                            CausesValidation="false" UseSubmitBehavior="false" />
                        <asp:Label ID="lblQty" runat="server" Text="" />
                        <asp:Button ID="btnLess" runat="server" Text="-" BackColor="White" BorderWidth="0" ForeColor="Black"
                            Font-Size="X-Large" CommandArgument='<%# Eval("iProductCode") %>' OnCommand="btnLess_Command"
                            CausesValidation="false" UseSubmitBehavior="false" />
                        <br />
                        <br />
                        <asp:ImageButton ID="btnRemove" runat="server" ImageUrl="~/UserLayer/Img/RemoveItem.png" Width="30px" Height="30px"
                            CommandArgument='<%# Eval("iProductCode") %>' OnCommand="btnRemove_Command"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </asp:PlaceHolder>
                </asp:TableCell>
            </asp:TableRow>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>


