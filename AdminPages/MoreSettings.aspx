<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="MoreSettings.aspx.cs" Inherits="TheVintageStore.UserLayer.AdminPages.MoreSettings" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: MORE SETTINGS 22/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">

    <!-- Code idea from: https://forums.asp.net/t/2032190.aspx?Show+or+hide+specific+divs+OnClick+of+a+button+javascript+ -->
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script>
        function showDiv(one, second, third) {
            //Show the div with animations
            $('#' + one).show("slow");
            $('#' + second).hide("slow");
            $('#' + third).hide("slow");
        }
    </script>

    <asp:Table ID="TableHelp" runat="server" GridLines="None" CellPadding="20">
        <asp:TableRow>

            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top" Width="30%">
                <h2>
                    <asp:Button ID="btnPurchaseReturns" runat="server" Text="PURCHASE & RETURNS" BackColor="White" BorderColor="White" BorderWidth="0"
                        OnClientClick="showDiv('ExchangeReturns', 'Shipping', 'Payment');return false;" />
                    <br />
                    <br />
                    <asp:Button ID="btnShipping" runat="server" Text="SHIPPING" BackColor="White" BorderColor="White" BorderWidth="0"
                        OnClientClick="showDiv('Shipping', 'ExchangeReturns', 'Payment');return false;" />
                    <br />
                    <br />
                    <asp:Button ID="btnPayment" runat="server" Text="PAYMENT" BackColor="White" BorderColor="White" BorderWidth="0"
                        OnClientClick="showDiv('Payment', 'Shipping', 'ExchangeReturns');return false;" />
                </h2>
            </asp:TableCell>

            <asp:TableCell HorizontalAlign="Left" Width="70%" VerticalAlign="Top">

                <%-- START: PURCHASE & RETURNS --%>
                <div id="ExchangeReturns" style="display: normal">
                    <h5>
                        <asp:Label ID="lblExchange" runat="server" Text="Purchase"></asp:Label>
                    </h5>
                    <asp:TextBox ID="txtbxExchange" runat="server" CssClass="form-control"
                        ReadOnly="true"
                        TextMode="MultiLine" Rows="8" />
                    <br />
                    
                    <asp:Button ID="btnUpdateExchange" runat="server" Text="Update" CssClass="btn btn-dark" OnClick="btnUpdateExchange_Click"  />
                    
                    <br />
                    <br />

                    <h5>
                        <asp:Label ID="lblReturn" runat="server" Text="Returns"></asp:Label>
                    </h5>
                    <asp:TextBox ID="txtxbxReturn" runat="server" CssClass="form-control"
                        ReadOnly="true"
                        TextMode="MultiLine" Rows="8" />
                    <br />
                    <asp:Button ID="btnUpdateReturn" runat="server" Text="Update" CssClass="btn btn-dark" OnClick="btnUpdateReturn_Click" />
                </div>
                <%-- END: PURCHASE & RETURNS --%>

                <%-- START: SHIPPING --%>
                <div id="Shipping" style="display: none">
                    <asp:TextBox ID="txtbxShipping" runat="server" CssClass="form-control"
                        ReadOnly="true"
                        TextMode="MultiLine" Rows="8" />
                    <br />
                    <asp:Button ID="btnUpdateShipping" runat="server" Text="Update" CssClass="btn btn-dark" OnClick="btnUpdateShipping_Click" />
                </div>
                <%-- END: SHIPPING --%>

                <%-- START: PAYMENT --%>
                <div id="Payment" style="display: none">
                    <asp:TextBox ID="txtbxPayment" runat="server" CssClass="form-control"
                        ReadOnly="true"
                        TextMode="MultiLine" Rows="5" />
                    <br />
                    <asp:Button ID="btnUpdatePayment" runat="server" Text="Update" CssClass="btn btn-dark" OnClick="btnUpdatePayment_Click"  />
                </div>
                <%-- END: PAYMENT --%>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
