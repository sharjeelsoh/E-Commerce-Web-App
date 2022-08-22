<%@ Page Title="About" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TheVintageStore.UserLayer.Pages.About" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: ABOUT 19/26 --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- ABOUT TABLE --%>
    <asp:Table ID="tblAbout" runat="server" GridLines="None" HorizontalAlign="Center" Width="70%" CellPadding="20">
        <asp:TableRow>

            <%-- DESCRIPTION --%>
            <asp:TableCell Width="50%">
                <h2>Company </h2>
                <p>
                    The Vintage Store is a local Australian brand, which reminds us that vintage clothes have a 
                    history and art to them, and they are filled with the stories and memories of the people that
                    came before us and wore them. <br /> <br />
        
                    Our designing to production stage, is all done locally and our customers are at the heart of our small business. <br /> 
                </p>
            </asp:TableCell>

            <%-- IMAGE --%>
            <asp:TableCell Width="50%" HorizontalAlign="Center">
                <img src="UserLayer/Img/About.jpg" width="100%" height="auto" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
