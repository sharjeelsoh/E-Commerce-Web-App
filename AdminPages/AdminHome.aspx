<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="TheVintageStore.UserLayer.AdminPages.AdminHome" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: ADMIN HOME 26/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">

    <div class="jumbotron">
        <h2 class="display-3">
            <asp:Label ID="lblHome" runat="server" Text=""></asp:Label>
        </h2>
        <hr class="my-4">
        <p>Let's get into Editing mode. </p>
        <a class="btn btn-primary btn-lg" href='<%= Page.ResolveUrl("~/Admin/UpdateProducts") %>' role="button">Update Products</a>
    </div>

</asp:Content>
