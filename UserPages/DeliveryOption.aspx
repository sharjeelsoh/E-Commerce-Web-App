<%@ Page Title="Delivery Option" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="DeliveryOption.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.DeliveryOption" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: DELIVERY OPTION 14/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="progress">
        <div class="progress-bar" role="progressbar" style="width: 20%;" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">20%</div>
    </div>
    <br /> <br />
    <asp:Table ID="tblDeliveryOption" runat="server" GridLines="None">
        <asp:TableRow>
            <asp:TableCell>
                <h2>SELECT DELIVERY OPTION </h2>

                <%-- STANDARD SHIPPING --%>
                <asp:RadioButton ID="rdbtnStandard" runat="server" Text="&nbsp; Standard Shipping: $7.95 AUD (7-10 Estimated days)" CssClass="form-check-input" GroupName="delivery" />
                <br />

                <%-- EXPRESS SHIPPING --%>
                <asp:RadioButton ID="rdbtnExpress" runat="server" Text="&nbsp; Express Shipping: $11.95 AUD (5-7 Estimated days)" CssClass="form-check-input" GroupName="delivery" />
                <br />
                <br />

                <asp:Label ID="lblMessage" runat="server" Text="" Font-Size="Small" ForeColor="Red" />
                <br />
                <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" CssClass="btn btn-dark" />
            </asp:TableCell>
            
            <%-- FOR ALIGNMENT PURPOSES --%>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

</asp:Content>
