<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="TheVintageStore.UserLayer.AdminPages.AdminProfile" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: ADMIN PROFILE 24/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">

    <!-- Code idea from: https://forums.asp.net/t/2032190.aspx?Show+or+hide+specific+divs+OnClick+of+a+button+javascript+ -->
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script>
        function showDiv(one, second) {
            //Show the div with animations
            $('#' + one).show("slow");
            $('#' + second).hide("slow");
        }
    </script>

    <asp:Table ID="Table1" runat="server" GridLines="None" CellPadding="20">
        <asp:TableRow>

            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top" Width="30%">
                <h2>
                    <asp:Button ID="btnPersonal" runat="server" Text="PERSONAL INFORMATION" BackColor="White" BorderColor="White" BorderWidth="0"
                        OnClientClick="showDiv('PersonalInfo', 'EndSession');return false;" />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnEnd" runat="server" Text="END SESSION" BackColor="White" BorderColor="White" BorderWidth="0"
                        OnClientClick="showDiv('EndSession', 'PersonalInfo');return false;" />
                </h2>
            </asp:TableCell>

            <asp:TableCell HorizontalAlign="Left" Width="70%" VerticalAlign="Top">

                <%-- START: PERSONAL INFORMATION --%>
                <div id="PersonalInfo" style="display: normal">
                    <div class="row g-3">

                        <%-- FIRST NAME --%>
                        <div class="col-6">
                            <asp:TextBox ID="txtbxFName" runat="server" placeholder="First Name" CssClass="form-control" Text="Josh" ReadOnly="true" />
                        </div>

                        <%-- LAST NAME --%>
                        <div class="col-6">
                            <asp:TextBox ID="txtbxLName" runat="server" placeholder="Last Name" CssClass="form-control" Text="Andrew" ReadOnly="true" />
                            <br />
                        </div>

                        <%-- CURRENT PASSWORD --%>
                        <div class="col-12">
                            <asp:TextBox type="password" ID="txtbxCurrentPass" runat="server" placeholder="Current Password" CssClass="form-control" ReadOnly="true" />
                            <br />
                        </div>

                        <%-- NEW PASSWORD --%>
                        <div class="col-6">
                            <asp:TextBox type="password" ID="txtbxPassword" runat="server" placeholder="New Password" CssClass="form-control" ReadOnly="true" />
                        </div>

                        <%-- CONFIRM PASSWORD --%>
                        <div class="col-6">
                            <asp:TextBox type="password" ID="txtbxPasswordVerify" runat="server" placeholder="Verify Password" CssClass="form-control" ReadOnly="true" />
                            <br />

                            <%-- BUTTONS --%>
                            <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn btn-dark" OnClick="btnEdit_Click" />

                            </div>
                            <br />
                            <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                                <asp:Button ID="btnUpdate" class="btn btn-dark" Text="UPDATE" runat="server" OnClick="btnUpdate_Click" />
                            </div>

                        </div>
                    </div>
                </div>
                <%-- END: PERSONAL INFORMATION --%>

                <%-- START: END SESSION --%>
                <div id="EndSession" style="display: none">
                    <div>
                        <h5>Confirm Session Log out? </h5>
                        <br />
                        <asp:Button ID="btnReturnHome" CssClass="btn btn-dark" runat="server" Text="Confirm & Return to Home" OnClick="btnReturnHome_Click" />
                    </div>
                </div>

                <%-- END: END SESSION --%>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
