<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="PaymentMethod.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.PaymentMethod" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: PAYMENT METHOD 08/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="progress">
        <div class="progress-bar" role="progressbar" style="width: 60%;" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100">60%</div>
    </div>
    <br />
    <br />

    <h2>CHOOSE A PAYMENT METHOD </h2>

    <%-- VISA --%>
    <asp:RadioButton ID="rdbtnVisa" runat="server" Text="&nbsp; VISA" CssClass="form-check-input" GroupName="payment" /><br />
    
    <%-- MASTER CARD --%>
    <asp:RadioButton ID="rdbtnMasterard" runat="server" Text="&nbsp; Master Card" CssClass="form-check-input" GroupName="payment" /><br />
    
    <%-- PAYPAL --%>
    <asp:RadioButton ID="rdbtnPaypal" runat="server" Text="&nbsp; Pay Pal" CssClass="form-check-input" GroupName="payment" /><br />
    <br />

    <asp:Label ID="lblMessage" runat="server" Text="" Font-Size="Small" ForeColor="Red" />
    <br />

    <asp:Button ID="BtnContinue" runat="server" Text="Continue" OnClick="BtnContinue_Click" CssClass="btn btn-dark" />

</asp:Content>
