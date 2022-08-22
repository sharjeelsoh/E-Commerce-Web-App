<%@ Page Title="Home" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.Home" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: HOME 12/26 --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2 class="display-3">Jump into 90's, Now!</h2>
        <p class="lead">
            There’s much more to vintage clothing than just being old and used clothes.
            There is a history and art to them, and they are filled with the 
            stories and memories of the people that came before us and wore them.
        </p>

        <img src="UserLayer/Img/Slider-1.jpg" width="100%" height="auto" />

        <hr class="my-4">
        <p>Cop our timeless classics and carry them for years! </p>
        <a class="btn btn-primary btn-lg" href='<%= Page.ResolveUrl("~/Shop") %>' role="button">Shop Now</a>
    </div>

</asp:Content>
