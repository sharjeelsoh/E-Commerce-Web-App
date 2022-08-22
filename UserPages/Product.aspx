<%@ Page Title="Product" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.Product" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: PRODUCT 07/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="tblProduct" runat="server"
        CellPadding="20"
        GridLines="None" HorizontalAlign="Center">

        <%-- ROW 1 --%>
        <asp:TableRow>

            <%-- CELL 1 IMAGE --%>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Image ID="imgProduct" runat="server" Width="360" Height="540" />
                <br />
            </asp:TableCell>

            <%-- CELL 2 DESCRIPTION --%>
            <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">
                <h2>
                    <asp:Label ID="lblTitle" runat="server" />
                </h2>
                <asp:Label ID="lblDescription" runat="server" />
                <br />
                <asp:Label ID="lblPrice" runat="server" />
                <br />
                <asp:Label ID="lblColor" runat="server" />
                <br />
                <br />

                <asp:DropDownList ID="dropdownSize" runat="server" />
                <br />
                <br />

                <%-- BUTTON ADD TO CART --%>
                <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" CssClass="btn btn-dark" OnClick="btnAdd_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
