<%@ Page Title="Login" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheVintageStore.UserLayer.Pages.Login" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: LOGIN 11/26 --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="TableLogin" runat="server" GridLines="None">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top">

                <%-- START: LOGIN --%>
                <div class="col-md-6">
                    <h2>LOG IN </h2>

                    <div class="form-check form-check-inline">
                        <asp:RadioButton ID="rdbtnCustomer" runat="server" Text="&nbsp; Customer &nbsp; &nbsp;" CssClass="form-check-label" Checked="true" GroupName="login" />
                        <asp:RadioButton ID="rdbtnAdmin" runat="server" Text="&nbsp; Admin" CssClass="form-check-label" GroupName="login" />
                    </div>
                    <br />
                    <!-- Expression Validation -->
                    <asp:RegularExpressionValidator ID="ValidateEmail" runat="server" Display="Dynamic" ErrorMessage="(Invalid Email)"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtbxEmail" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
                    <!-- Expression Validation -->
                    <asp:TextBox ID="txtbxEmail" CssClass="form-control" runat="server" placeholder="Email" />
                    <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" Display="Dynamic" ErrorMessage="(Email Required)" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxEmail" />
                    <br />
                    <asp:TextBox ID="txtbxPassword" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" Display="Dynamic" ErrorMessage="(Password Required)" ControlToValidate="txtbxPassword" Font-Size="Smaller" ForeColor="Red" />
                    <br />

                    <asp:HyperLink ID="HyperForgotPassword" runat="server" Font-Size="Smaller" Font-Underline="true" NavigateUrl="~/RecoverPassword">Have you forgotten your password?</asp:HyperLink>
                    <br /><br />
                </div>
                <%-- END: LOGIN --%>
            </asp:TableCell>

            <%-- START: REGISTER --%>
            <asp:TableCell VerticalAlign="Top">
                <div>
                    <h2>REGISTER </h2>
                    <p>
                        If you don't have an account, use this option
                        to access the registration form.
                        <br />
                        <br />
                        By giving us your details, purchasing will be
                        faster and an enjoyable experience 
                    </p>
                </div>
            </asp:TableCell>
            <%-- END: REGISTER --%>
        </asp:TableRow>

        <%-- BUTTONS & MESSAGE LABEL --%>
        <asp:TableRow>
            <%-- LOGIN BUTTON --%>
            <asp:TableCell Width="50%" CssClass="col-md-6">
                <asp:Button CssClass="btn btn-dark" Text="Log In" ID="btnLogin" runat="server" OnClick="btnLogin_Click" />
                <br />
                <asp:Label ID="lblLoginMessage" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
            </asp:TableCell>
            
            <%-- REGISTER BUTTON --%>
            <asp:TableCell Width="50%">
                <asp:Button CausesValidation="false" CssClass="btn btn-dark" Text="Register" ID="btnRegister" runat="server" OnClick="btnRegister_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
