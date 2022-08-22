<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="TheVintageStore.UserLayer.AdminPages.ManageUsers" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: MANAGE USERS 23/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">

    <br />
    <h2>MANAGE USERS </h2>

    <asp:SqlDataSource ID="ManageUsersDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TheVintageStoreConnectionString %>" 
        SelectCommand="SELECT [CustomerID], [Email], CONCAT(FirstName, ' ', LastName) AS FullName FROM [tblCustomer]">
    </asp:SqlDataSource>

    <asp:GridView ID="GridManageUsers" runat="server" AutoGenerateColumns="False"
        CssClass="table table-hover" UseAccessibleHeader="False" GridLines="None" AllowPaging="True" AllowSorting="True" DataSourceID="ManageUsersDataSource">
        
        <Columns>

            <%-- USER ID --%>
            <asp:BoundField DataField="CustomerID" HeaderText="USER ID" ReadOnly="true" HeaderStyle-HorizontalAlign="Center"
                ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#CCCCCC">
            
<HeaderStyle HorizontalAlign="Center" BackColor="#CCCCCC"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            
            <%-- USERNAME --%>
            <asp:BoundField DataField="FullName" HeaderText="USER NAME" HeaderStyle-BackColor="#CCCCCC" ReadOnly="true" >
            
<HeaderStyle BackColor="#CCCCCC"></HeaderStyle>
            </asp:BoundField>
            
            <%-- EMAIL --%>
            <asp:BoundField DataField="Email" HeaderText="EMAIL" HeaderStyle-BackColor="#CCCCCC" ReadOnly="true" >
            
<HeaderStyle BackColor="#CCCCCC"></HeaderStyle>
            </asp:BoundField>
            
            <%-- 
            <%-- STATUS
            <asp:CheckBoxField DataField="Status" HeaderText="ACTIVATE/SUSPEND" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#CCCCCC" />
            --%>
            
            <%-- ACTION BUTTONS: VIEW PURCHASE HISTORY --%>
            <asp:TemplateField HeaderText="ACTIONS" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#CCCCCC">
                
                <ItemTemplate>
                    <asp:LinkButton ID="View" Text="Purchase History" runat="server" CommandName="View" OnClick="View_Click" />
                </ItemTemplate>
            
<HeaderStyle HorizontalAlign="Center" BackColor="#CCCCCC"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            
            </asp:TemplateField>

            <%-- ACTION BUTTONS: EDIT AND UPDATE --%>
            <asp:TemplateField HeaderText="ACTIONS" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#CCCCCC">
                
                <itemtemplate>
                    <asp:LinkButton Text="Edit" runat="server" CommandName="Edit" />
                </itemtemplate>
                
                <edititemtemplate>
                    <asp:LinkButton Text="Update &nbsp;" runat="server" />
                    <asp:LinkButton Text="Cancel" runat="server" />
                </edititemtemplate>
            
<HeaderStyle HorizontalAlign="Center" BackColor="#CCCCCC"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </asp:Content>
