<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ReviewOrder.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.ReviewOrder" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: REVIEW ORDER 05/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="progress">
        <div class="progress-bar" role="progressbar" style="width: 100%;" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100">100%</div>
    </div>
    <br />
    <br>

    <asp:ListView ID="ListViewReviewOrder" runat="server" OnPreRender="ListViewReviewOrder_PreRender">
        <LayoutTemplate>
            
            <asp:Table runat="server" HorizontalAlign="Center" CellPadding="10" Width="80%">
                <%-- ROW1: DISPLAY HEADER AND PRODUCTS --%>
                <asp:TableRow runat="server" HorizontalAlign="Left">

                    <asp:TableCell runat="server" ID="DeliveryDetails" Width="50%" VerticalAlign="Top">
                        <h2>REVIEW ORDER</h2>
                        <br />
                        <%-- NO. OF ITEMS --%>
                        <h4>TOTAL NO. OF ITEM(S)</h4>
                        <asp:Label ID="lblItems" runat="server" />
                        <br />
                        <br />
                        <h4>SHIPPING DETAILS </h4>
                        <%-- SHIPPING TYPE, COST, AND EXPECTED DELIVER --%>
                        <asp:Label ID="lblDeliveryOption" runat="server" />
                        <br />
                        <asp:Label ID="lblDelivery" runat="server" Text="Expected Delivery Date: " />
                        <asp:Label ID="lblExpectedDeliveryDate" runat="server" />
                        <br />
                        <br />

                        <%-- SHIPPING DETAILS (NAME, ADDRESS, EMAIL, AND CONTACT) --%>
                        <asp:Label ID="lblName" runat="server" Font-Underline="true" />
                        <br />
                        <asp:Label ID="lblAddress" runat="server" />
                        <br />
                        <asp:Label ID="lblEmail" runat="server" />
                        <br />
                        <asp:Label ID="lblContact" runat="server" />
                        <br />
                        <br />

                        <%-- PAYMENT METHOD SELECTED --%>
                        <h4>PAYMENT VIA</h4>
                        <asp:Label ID="lblPayment" runat="server" />
                    </asp:TableCell>

                    <%-- HEADER & IMAGE CELL --%>
                    <asp:TableCell runat="server" ID="img" HorizontalAlign="Right" VerticalAlign="Top">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </asp:TableCell>
                </asp:TableRow>

                <%-- ROW3: FOOTER - DISPLAY TOTAL & CONTINUE BUTTON --%>
                <asp:TableFooterRow HorizontalAlign="Right">
                    <%-- FOR ALIGNMENT PURPOSES --%>
                    <asp:TableCell>
                    </asp:TableCell>
                    <%-- TOTAL & CONTINUE BUTTON --%>
                    <asp:TableCell>
                        <asp:Label ID="lblTotalGross" runat="server" />
                        <br />
                        <asp:Label ID="lblDeliveryCost" runat="server" />
                        <br />
                        <h2>
                            <asp:Label ID="lblTotalNet" runat="server"></asp:Label>
                        </h2>
                        <asp:Button ID="btnContinue" runat="server" Text="Confirm" OnClick="btnConfirm_Click" CssClass="btn btn-dark" />
                    </asp:TableCell>
                </asp:TableFooterRow>
            </asp:Table>
        </LayoutTemplate>

        <%-- ITEM TEMPLATE --%>
        <ItemTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder">
                <img id="imgProduct" runat="server" class="img-responsive" width="180" height="270" src='<%# Eval("sImageURL") %>' />
            </asp:PlaceHolder>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
