<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.Registration" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: REGISTRATION 06/26 --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>PERSONAL DETAILS </h2>

    <div class="form-row">

        <%-- EMAIL --%>
        <div class="form-group col-md-12">
            <asp:Label ID="lblEmail" runat="server" Text="Email "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" Display="Dynamic" ErrorMessage="(Email required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxEmail" />
            <asp:TextBox ID="txtbxEmail" runat="server" CssClass="form-control" />
            <!--Start: Expression Validation -->
            <asp:RegularExpressionValidator ID="ValidateEmail" runat="server" Display="Dynamic" ErrorMessage="(Please enter a valid email address)"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtbxEmail" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            <!--End: Expression Validation -->
            <asp:HyperLink ID="HyperLogin" runat="server" Font-Size="Smaller" Font-Underline="true" NavigateUrl="~/Login"
                Visible="false">Email already exist, log in instead?</asp:HyperLink>
        </div>

        <%-- PASSWORD 1 --%>
        <div class="form-group col-md-6">
            <asp:Label ID="lblPassword" runat="server" Text="Password "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredPassword1" runat="server" Display="Dynamic" ErrorMessage="(Password required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPassword" />
            <asp:TextBox type="password" ID="txtbxPassword" runat="server" CssClass="form-control" />
        </div>

        <%-- PASSWORD 2 --%>
        <div class="form-group col-md-6">
            <asp:Label ID="lblPassword2" runat="server" Text="Verify Password "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredPassword2" runat="server" Display="Dynamic" ErrorMessage="(Verification required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPasswordVerify" />
            <asp:TextBox type="password" ID="txtbxPasswordVerify" runat="server" CssClass="form-control" />
        </div>

        <%-- FIRST NAME --%>
        <div class="form-group col-md-6">
            <asp:Label ID="lblFName" runat="server" Text="First Name "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFName" runat="server" Display="Dynamic" ErrorMessage="(First name required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxFName" />
            <asp:TextBox ID="txtbxFName" runat="server" CssClass="form-control" />
        </div>

        <%-- LAST NAME --%>
        <div class="form-group col-md-6">
            <asp:Label ID="lblLName" runat="server" Text="Last Name "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredLName" runat="server" Display="Dynamic" ErrorMessage="(Last name required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxLName" />
            <asp:TextBox ID="txtbxLName" runat="server" CssClass="form-control" />
        </div>

        <%-- ADDRESS 1 --%>
        <div class="form-group col-md-12">
            <asp:Label ID="lblAddress1" runat="server" Text="Address 1 "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredAddress" runat="server" Display="Dynamic" ErrorMessage="(Address required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxAddress1" />
            <asp:TextBox ID="txtbxAddress1" runat="server" CssClass="form-control" />
        </div>

        <%-- ADDRESS 2 --%>
        <div class="form-group col-md-12">
            <asp:Label ID="lblAddress2" runat="server" Text="Address 2 "></asp:Label>
            <asp:TextBox ID="txtbxAddress2" runat="server" CssClass="form-control" />
        </div>

        <%-- SUBURB --%>
        <div class="form-group col-md-4">
            <asp:Label ID="lblSuburb" runat="server" Text="Suburb "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredSuburb" runat="server" Display="Dynamic" ErrorMessage="(Suburb required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxSuburb" />
            <asp:TextBox ID="txtbxSuburb" runat="server" CssClass="form-control" />
        </div>

        <%-- STATE --%>
        <div class="form-group col-md-4">
            <asp:Label ID="lblState" runat="server" Text="State "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredState" runat="server" Display="Dynamic" ErrorMessage="(State required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="DropDownState" />
            <asp:DropDownList ID="DropDownState" runat="server" CssClass="form-control">
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

        <%-- POST CODE --%>
        <div class="form-group col-md-4">
            <asp:Label ID="lblPost" runat="server" Text="Post Code "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredPost" runat="server" Display="Dynamic" ErrorMessage="(Postcode required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPostCode" />
            <asp:TextBox ID="txtbxPostCode" runat="server" CssClass="form-control" TextMode="Number" />
            <!--Start: Expression Validation -->
            <asp:RegularExpressionValidator ID="ExpressionPostCode" runat="server" Display="Dynamic" ErrorMessage="(Invalid Postcode, check again)"
                ControlToValidate="txtbxPostCode" ValidationExpression="^(0[289][0-9]{2})|([1-9][0-9]{3})$" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            <!--End: Expression Validation -->
        </div>

        <%-- PHONE NUMBER --%>
        <div class="form-group col-md-6">
            <asp:Label ID="lblPhone" runat="server" Text="Contact "></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredPhone" runat="server" Display="Dynamic" ErrorMessage="(Contact required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPhNumber" />
            <asp:TextBox ID="txtbxPhNumber" type="tel" runat="server" CssClass="form-control" TextMode="Phone" />
            <!--Start: Expression Validation -->
            <asp:RegularExpressionValidator ID="ExpressionPhone" runat="server" Display="Dynamic" ErrorMessage="(Invalid contact number, check again)"
                ValidationExpression="^(?:\+?(61))? ?(?:\((?=.*\)))?(0?[2-57-8])\)? ?(\d\d(?:[- ](?=\d{3})|(?!\d\d[- ]?\d[- ]))\d\d[- ]?\d[- ]?\d{3})$"
                Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPhNumber"></asp:RegularExpressionValidator>
            <!--End: Expression Validation -->
        </div>
    </div>
    <asp:Label ID="lblMessage" runat="server" Text="" Font-Size="Smaller" ForeColor="Red"></asp:Label>
    <br />
    <%-- REGISTER BUTTON --%>
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-dark" />


</asp:Content>
