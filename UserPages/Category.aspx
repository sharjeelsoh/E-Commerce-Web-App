<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.Category" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: CATEGORY 16/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%-- LIST VIEW CATEGORY --%>
    <asp:ListView ID="ListViewCategory" runat="server" GroupItemCount="3">
        
        <%-- LAYOUT TEMPLATE --%>
        <LayoutTemplate>
            <asp:Table runat="server" HorizontalAlign="Center" CellPadding="10">
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server">
                        <asp:PlaceHolder runat="server" ID="groupPlaceholder"></asp:PlaceHolder>
                    </asp:TableCell>
                </asp:TableRow>
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
            <asp:TableCell runat="server" HorizontalAlign="Center">
                <asp:PlaceHolder runat="server" ID="itemPlaceholder">
                    <asp:LinkButton ID="linkbtnProduct" runat="server" CommandArgument='<%# Eval("iProductCode") %>' OnCommand="linkbtnProduct_Command">
                        <img id="imgProducts" runat="server" class="img-responsive" width="360" height="540" src='<%# Eval("sImageURL") %>' />
                        <br />
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("sTitle").ToString().ToUpper() %>' ForeColor="Black" />
                        <br />
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("dPrice", "{0:c}") %>' ForeColor="Black" />
                        <br />
                    </asp:LinkButton>
                </asp:PlaceHolder>
            </asp:TableCell>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
