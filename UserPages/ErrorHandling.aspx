<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ErrorHandling.aspx.cs" Inherits="TheVintageStore.UserLayer.UserPages.ErrorHandling1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="lblHeading" runat="server" Text="Oops! Something went wrong." ForeColor="Red" Font-Italic="true" />
    </h2>
    <br />
    <asp:Button ID="btnHome" runat="server" Text="Back To Home" CssClass="btn btn-dark" OnClick="btnHome_Click" />
</asp:Content>
