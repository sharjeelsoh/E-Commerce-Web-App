<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CardDetails.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.CardDetails" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: CARD DETAILS 18/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="progress">
        <div class="progress-bar" role="progressbar" style="width: 80%;" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100">80%</div>
    </div>
    <br />
    <br />

    <%-- START: DIV => CARD DETAILS (MASTERCARD OR VISA) --%>
    <div id="divCards" runat="server" visible="false">
        <%-- DIV => MASTER CARD DETAILS --%>
        <div id="divMasterCard" runat="server" visible="false">
            <h2>MASTER CARD </h2>
        </div>

        <%-- DIV => VISA --%>
        <div id="divVisa" runat="server" visible="false">
            <h2>VISA</h2>
        </div>

        <div class="row g-3">
            <%-- CARD NO. --%>
            <div class="col-6">
                <asp:Label ID="lblCardNo" runat="server" Text="Card no "></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredCardNo" runat="server" Display="Dynamic" ErrorMessage="(Card no. required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxCardNo" />
                <asp:TextBox ID="txtbxCardNo" runat="server" placeholder="Card Number" CssClass="form-control" />
                <asp:RegularExpressionValidator ID="ExpressionCard" runat="server" Display="Dynamic" ErrorMessage="Invalid card no. (Hint: remove spaces if any)"
                    ValidationExpression="^5[1-5][0-9]{14}|^(222[1-9]|22[3-9]\\d|2[3-6]\\d{2}|27[0-1]\\d|2720)[0-9]{12}$"
                    Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxCardNo" />
            </div>

            <%-- CARD HOLDER NAME --%>
            <div class="col-6">
                <asp:Label ID="lblCardholderName" runat="server" Text="Card holder name "></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredCardName" runat="server" Display="Dynamic" ErrorMessage="(Card holder's name required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxCardHolder" />
                <asp:TextBox ID="txtbxCardHolder" runat="server" placeholder="Card Holder" CssClass="form-control" />
                <br />
            </div>

            <%-- EXPIRY DATE MONTH --%>
            <div class="col-3">
                <asp:Label ID="lblExpiryMonth" runat="server" Text="Expiry (Month) "></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredExpiryMonth" runat="server" Display="Dynamic" ErrorMessage="(Expiry month required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="dropdownMonth" />
                <asp:DropDownList ID="dropdownMonth" runat="server" CssClass="form-control">
                    <asp:ListItem> </asp:ListItem>
                </asp:DropDownList>
            </div>

            <%-- EXPIRY DATE YEAR --%>
            <div class="col-3">
                <asp:Label ID="lblExpiryYear" runat="server" Text="Expiry (Year) "></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredExpiryYear" runat="server" Display="Dynamic" ErrorMessage="(Expiry year required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="dropdownYear" />
                <asp:DropDownList ID="dropdownYear" runat="server" CssClass="form-control">
                    <asp:ListItem> </asp:ListItem>
                </asp:DropDownList>
            </div>

            <%-- CVV --%>
            <div class="col-3">
                <asp:Label ID="lblCVV" runat="server" Text="CVV "></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredCVV" runat="server" Display="Dynamic" ErrorMessage="(Security code required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxCVV" />
                <asp:TextBox ID="txtbxCVV" runat="server" placeholder="CVV Security Code" CssClass="form-control" TextMode="Number" />
                <asp:RegularExpressionValidator ID="ExpressionCVV" runat="server" Display="Dynamic" ErrorMessage="(Invalid CVV)" ValidationExpression="^[0-9]{3}$"
                    Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxCVV" />
            </div>

            <div class="col-12">
                <asp:Label ID="lblExpiryMessage" runat="server" Font-Size="Smaller" ForeColor="Red" />
            </div>

        </div>
    </div>
    <%-- END: DIV => CARD DETAILS (MASTERCARD OR VISA) --%>

    <%-- START: DIV => PAYPAL --%>

    <div id="divPaypal" runat="server" visible="false">
        <div class="form-row">
            <%-- EMAIL --%>
            <div class="form-group col-md-6">
                <asp:Label ID="lblEmail" runat="server" Text="Email "></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" Display="Dynamic" ErrorMessage="(Email required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxEmail" />
                <asp:TextBox ID="txtbxEmail" runat="server" CssClass="form-control" />
                <!--Start: Expression Validation -->
                <asp:RegularExpressionValidator ID="ValidateEmail" runat="server" Display="Dynamic" ErrorMessage="(Please enter a valid email address)"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtbxEmail" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
                <!--End: Expression Validation -->
            </div>

            <%-- PASSWORD 1 --%>
            <div class="form-group col-md-6">
                <asp:Label ID="lblPassword" runat="server" Text="Password "></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" Display="Dynamic" ErrorMessage="(Password required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPassword" />
                <asp:TextBox type="password" ID="txtbxPassword" runat="server" CssClass="form-control" />
            </div>
        </div>
    </div>

    <%-- END: DIV => PAYPAL --%>
    <br />
    <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" CssClass="btn btn-dark" />

</asp:Content>
