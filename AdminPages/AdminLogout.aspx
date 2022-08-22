<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminLogout.aspx.cs" Inherits="TheVintageStore.UserLayer.AdminPages.AdminLogout" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: ADMIN LOGOUT 25/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">

    <div>
        <h2>SESSION ENDED SUCCESSFULLY </h2>
        <asp:Button ID="btnReturn" CssClass="btn btn-dark" runat="server" Text="Return to Home" OnClick="btnReturn_Click" />
    </div>

</asp:Content>

