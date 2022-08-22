<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="DeliveryDetails.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.DeliveryDetails" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: DELIVERY DETAILS 15/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="progress">
        <div class="progress-bar" role="progressbar" style="width: 40%;" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100">40%</div>
    </div>
    <br />
    <br />

    <h2>CONFIRM DELIVERY DETAILS </h2>

    <%------------------------------------------------ SHIPPING ADDRESS ------------------------------------------------%>

    <h4>SHIPPING ADDRESS </h4>

    <%-- SHIPPING ADDRESS 1 --%>
    <div class="form-row">
        <div class=" form-group col-6">
            <asp:Label ID="lblAddress1" runat="server" Text="Address "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredAddress" runat="server" Display="Dynamic" ErrorMessage="(Address required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxAddress1" />
            <asp:TextBox ID="txtbxAddress1" runat="server" placeholder="Address" CssClass="form-control" />
        </div>

        <%-- SHIPPING ADDRESS 2 --%>
        <div class="form-group col-6">
            <asp:Label ID="lblAddress2" runat="server" Text="Address 2 "></asp:Label>
            <asp:TextBox ID="txtbxAddress2" runat="server" placeholder="Address 2 (Optional)" CssClass="form-control" />
        </div>

        <%-- SHIPPING SUBURB --%>
        <div class="form-group col-6">
            <asp:Label ID="lblSuburb" runat="server" Text="Suburb "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredSuburb" runat="server" Display="Dynamic" ErrorMessage="(Suburb required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxSuburb" />
            <asp:TextBox ID="txtbxSuburb" runat="server" placeholder="Suburb/City" CssClass="form-control" />
        </div>

        <%-- SHIPPING STATE --%>
        <div class="form-group col-6">
            <asp:Label ID="lblState" runat="server" Text="State "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredState" runat="server" Display="Dynamic" ErrorMessage="(State required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="DropDownState" />
            <asp:DropDownList ID="DropDownState" runat="server" placeholder="State" CssClass="form-control">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>NSW</asp:ListItem>
                <asp:ListItem>ACT</asp:ListItem>
                <asp:ListItem>VIC</asp:ListItem>
                <asp:ListItem>SA</asp:ListItem>
                <asp:ListItem>TAS</asp:ListItem>
                <asp:ListItem>WA</asp:ListItem>
                <asp:ListItem>QLD</asp:ListItem>
            </asp:DropDownList>
        </div>

        <%-- SHIPPING POST CODE --%>
        <div class="form-group col-6">
            <asp:Label ID="lblPost" runat="server" Text="Post Code "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredPost" runat="server" Display="Dynamic" ErrorMessage="(Postcode required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPostCode" />
            <asp:TextBox ID="txtbxPostCode" runat="server" placeholder="Post Code" CssClass="form-control" TextMode="Number" />
            <!--Start: Expression Validation -->
            <asp:RegularExpressionValidator ID="ExpressionPostCode" runat="server" Display="Dynamic" ErrorMessage="(Invalid Postcode, check again)"
                ControlToValidate="txtbxPostCode" ValidationExpression="^(0[289][0-9]{2})|([1-9][0-9]{3})$" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            <!--End: Expression Validation -->
        </div>

        <%-- SHIPPING CONTACT NO. --%>
        <div class="form-group col-6">
            <asp:Label ID="lblPhone" runat="server" Text="Contact "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredPhone" runat="server" Display="Dynamic" ErrorMessage="(Contact required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPhNumber" />
            <asp:TextBox ID="txtbxPhNumber" type="tel" runat="server" placeholder="Phone Number" CssClass="form-control" TextMode="Phone" />
            <!--Start: Expression Validation -->
            <asp:RegularExpressionValidator ID="ExpressionPhone" runat="server" Display="Dynamic" ErrorMessage="(Invalid contact number, check again)"
                ValidationExpression="^(?:\+?(61))? ?(?:\((?=.*\)))?(0?[2-57-8])\)? ?(\d\d(?:[- ](?=\d{3})|(?!\d\d[- ]?\d[- ]))\d\d[- ]?\d[- ]?\d{3})$"
                Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPhNumber"></asp:RegularExpressionValidator>
            <!--End: Expression Validation -->
            <br />
        </div>
    </div>

    <%------------------------------------------------ SHIPPING ADDRESS ------------------------------------------------%>

    <%-- BUTTON  --%>
    <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" CssClass="btn btn-dark" />

</asp:Content>
