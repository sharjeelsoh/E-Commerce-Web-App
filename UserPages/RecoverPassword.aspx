<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.RecoverPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="TableLogin" runat="server" GridLines="None">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top">

                <%-- HEADING --%>
                <div class="col-md-12">
                    <h2>RESET PASSWORD</h2>
                    <asp:Label ID="lblPassword" runat="server"
                        Text="If you've forgotten your password, enter your e-mail address and we'll send you an e-mail with a 6-digit
                        code to enter here." />
                </div>

                <div class="col-md-6">
                   
                    <%-- EMAIL AND CODE --%>

                    <asp:Panel ID="PanelRetrieveInfo" runat="server" Visible="true">
                        <!-- Expression Validation -->
                        <asp:RegularExpressionValidator ID="ValidateEmail" runat="server" ErrorMessage="Invalid Email"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtbxEmail" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
                        <!-- Expression Validation -->
                        <asp:TextBox ID="txtbxEmail" CssClass="form-control" runat="server" placeholder="Email" />
                        <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ErrorMessage="Email Required" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxEmail" />
                        <br />

                        <asp:TextBox ID="txtbxCode" runat="server" CssClass="form-control" placeholder="Enter Code" Visible="false" />
                        <br />
                    </asp:Panel>

                    <%-- SET PASSWORD --%>

                    <asp:Panel ID="PanelSetPassword" runat="server" Visible="false">
                        <br />
                        <%-- PASSWORD 1 --%>
                        <div>
                            <asp:Label ID="lblPassword1" runat="server" Text="New Password: "></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredPassword1" runat="server" ErrorMessage="Password required" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPassword" />
                            <asp:TextBox type="password" ID="txtbxPassword" runat="server" placeholder="****" CssClass="form-control" />
                        </div>
                        <br />

                        <%-- PASSWORD 2 --%>
                        <div>
                            <asp:Label ID="lblPassword2" runat="server" Text="Verify Password: "></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredPassword2" runat="server" ErrorMessage="Verification required" Font-Size="Smaller" ForeColor="Red" ControlToValidate="txtbxPasswordVerify" />
                            <asp:TextBox type="password" ID="txtbxPasswordVerify" runat="server" placeholder="****" CssClass="form-control" />
                        </div>
                    </asp:Panel>

                    <%-- LBL MESSAGE AND BUTTON CONTINUE --%>

                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Size="Smaller" />
                    <br />
                    <asp:Button ID="btnContinue" runat="server" Text="Continue" CssClass="btn btn-dark" OnClick="btnContinue_Click" />
                </div>

            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
