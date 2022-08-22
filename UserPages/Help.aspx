<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="TheVintageStore.UserLayer.Pages.Help" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: HELP 13/26 --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Code idea from: https://forums.asp.net/t/2032190.aspx?Show+or+hide+specific+divs+OnClick+of+a+button+javascript+ -->
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script>
        function showDiv(one, second, third, fourth) {
            //Show the div with animations
            $('#' + one).show("slow");
            $('#' + second).hide("slow");
            $('#' + third).hide("slow");
            $('#' + fourth).hide("slow");
        }
    </script>

    <asp:Table ID="TableHelp" runat="server" GridLines="None" CellPadding="20">
        <asp:TableRow>

            <%-- BUTTONS (LEFT SIDE OF THE PAGE --%>
            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top" Width="30%">
                <h2>
                    <asp:Button ID="btnPurchaseReturns" runat="server" Text="PURCHASE & RETURNS" BackColor="White" BorderColor="White" BorderWidth="0"
                        OnClientClick="showDiv('ExchangeReturns', 'Shipping', 'Payment', 'Contact');return false;" />
                    <br />
                    <br />
                    <asp:Button ID="btnShipping" runat="server" Text="SHIPPING" BackColor="White" BorderColor="White" BorderWidth="0"
                        OnClientClick="showDiv('Shipping', 'ExchangeReturns', 'Payment', 'Contact');return false;" />
                    <br />
                    <br />
                    <asp:Button ID="btnPayment" runat="server" Text="PAYMENT" BackColor="White" BorderColor="White" BorderWidth="0"
                        OnClientClick="showDiv('Payment', 'Shipping', 'Contact', 'ExchangeReturns');return false;" />
                    <br />
                    <br />
                    <asp:Button ID="btnContact" runat="server" Text="CONTACT US" BackColor="White" BorderColor="White" BorderWidth="0"
                        OnClientClick="showDiv('Contact', 'Payment', 'ExchangeReturns', 'Shipping');return false;" />
                </h2>
            </asp:TableCell>

            <%-- FIELDS: RIGHT SIDE OF THE PAGE --%>
            <asp:TableCell HorizontalAlign="Left" Width="70%" VerticalAlign="Top">

                    <%-- START: PURCHASE & RETURNS --%>
                    <div id="ExchangeReturns" style="display: normal">
                        <h5>
                            <asp:Label ID="lblExchange" runat="server" Text="Purchase"></asp:Label>
                        </h5>
                        <asp:TextBox ID="txtbxExchange" runat="server" CssClass="form-control"
                            ReadOnly="true"
                            TextMode="MultiLine" Rows="8" />
                        <h5>
                            <asp:Label ID="lblReturn" runat="server" Text="Returns"></asp:Label>
                        </h5>
                        <asp:TextBox ID="txtxbxReturn" runat="server" CssClass="form-control"
                            ReadOnly="true"
                            TextMode="MultiLine" Rows="8" />
                    </div>
                    <%-- END: PURCHASE & RETURNS --%>

                    <%-- START: SHIPPING --%>
                    <div id="Shipping" style="display: none">
                        <asp:TextBox ID="txtbxShipping" runat="server" CssClass="form-control"
                            ReadOnly="true"
                            TextMode="MultiLine" Rows="8" />
                    </div>
                    <%-- END: SHIPPING --%>

                    <%-- START: PAYMENT --%>
                    <div id="Payment" style="display: none">
                        <asp:TextBox ID="txtbxPayment" runat="server" CssClass="form-control"
                            ReadOnly="true"
                            TextMode="MultiLine" Rows="5" />
                    </div>
                    <%-- END: PAYMENT --%>

                    <%-- START: CONTACT --%>
                    <div id="Contact" style="display: none">
                        <div class="row g-3">
                            <div class="form-row">
                                <%-- FULL NAME --%>
                                <div class="form-group col-md-12">
                                    <asp:Label ID="lblFullName" runat="server" Text="Full Name "></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFullName" runat="server" ErrorMessage="(Full name required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxFullName" />
                                    <asp:TextBox ID="txtbxFullName" runat="server" CssClass="form-control" />
                                </div>

                                <%-- EMAIL --%>
                                <div class="form-group col-md-12">
                                    <asp:Label ID="lblEmail" runat="server" Text="Email "></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ErrorMessage="(Email required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxEmail" />
                                    <asp:TextBox ID="txtbxEmail" runat="server" CssClass="form-control" />
                                </div>

                                <%-- SUBJECT CATEGORY --%>
                                <div class="form-group col-md-12">
                                    <asp:Label ID="lblCategory" runat="server" Text="Subject Category "></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredCategory" runat="server" ErrorMessage="(Subject category required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="DropDownCategory" />
                                    <asp:DropDownList ID="DropDownCategory" runat="server" CssClass="form-control">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>General Qs about TheVintageStore</asp:ListItem>
                                        <asp:ListItem>Product</asp:ListItem>
                                        <asp:ListItem>Exchange & Returns</asp:ListItem>
                                        <asp:ListItem>Order Status</asp:ListItem>
                                        <asp:ListItem>Suggestions</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <%-- MESSAGE --%>
                                <div class="form-group col-md-12">
                                    <asp:Label ID="lblMessage" runat="server" Text="Message "></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredMessage" runat="server" ErrorMessage="(Message required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxMessage" />
                                    <asp:TextBox ID="txtbxMessage" runat="server" placeholder="type ypur message here" CssClass="form-control" TextMode="MultiLine" Rows="10" />
                                </div>

                                <%-- BUTTON --%>
                                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CssClass="btn btn-dark" />
                            </div>
                        </div>
                    </div>
                    <%-- END: CONTACT --%>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
