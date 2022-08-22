<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateProducts.aspx.cs" Inherits="TheVintageStore.UserLayer.AdminPages.UpdateProducts" %>

<%-- AUTHOR: SHARJEEL SOHAIL --%>
<%-- DATE: 03/APRIL/2021 --%>
<%-- PROJECT: INFT3050 ASSIGNMENT PART 1 --%>
<%-- PAGE: UPDATE PRODUCTS 21/26 --%>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">

    <br />
    <h2>UPDATE PRODUCTS </h2>

    <%-- START: GRIDVIEW TO UPDATE PRODUCTS --%>

    <asp:GridView ID="GridUpdateProducts" runat="server" AutoGenerateColumns="False"
        CssClass="table table-hover" UseAccessibleHeader="False" GridLines="None" DataSourceID="UpdateProductsSqlDataSource" AllowPaging="True" AllowSorting="True">
        
        <Columns>

            <%-- PRODUCT CODE --%>
            <asp:BoundField DataField="ProductCode" HeaderText="CODE" ReadOnly="true" HeaderStyle-HorizontalAlign="Center"
                ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#CCCCCC" />

            <%-- PRODUCT TITLE --%>
            <asp:BoundField DataField="Title" HeaderText="TITLE" HeaderStyle-BackColor="#CCCCCC" />

            <%-- PRODUCT DESCRIPTION --%>
            <asp:BoundField DataField="Description" HeaderText="DESCRIPTION" HeaderStyle-BackColor="#CCCCCC" />

            <%-- PRODUCT QUANTITY --%>
            <asp:BoundField DataField="TotalQuantity" HeaderText="QUANTITY" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#CCCCCC" />

            <%-- PRODUCT PRICE --%>
            <asp:BoundField DataField="Price" HeaderText="PRICE" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#CCCCCC" />
            <%-- 
            <%-- PRODUCT STATUS (ACTIVE/DISABLE)
            <asp:CheckBoxField DataField="Status" HeaderText="ACTIVATE/SUSPEND" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#CCCCCC" />
            --%>

            <%-- START: ACTION BUTTONS - EDIT, UPDATE, AND CANCEL --%>
            <asp:TemplateField HeaderText="ACTIONS" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#CCCCCC">
                
                <ItemTemplate>
                    <asp:LinkButton Text="Edit" runat="server" CommandName="Edit" />
                </ItemTemplate>
                
                <EditItemTemplate>
                    <asp:LinkButton Text="Update &nbsp;" runat="server"  />
                    <asp:LinkButton Text="Cancel" runat="server"  />
                </EditItemTemplate>

            </asp:TemplateField>
            <%-- END: ACTION BUTTONS - EDIT, UPDATE, AND CANCEL --%>
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource 
        ID="UpdateProductsSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TheVintageStoreConnectionString %>" 
        SelectCommand="SELECT [ProductCode], [Title], [Description], [TotalQuantity], [Price] FROM [tblProduct]">
    </asp:SqlDataSource>

    <%-- END: GRIDVIEW TO UPDATE PRODUCTS --%>

    <%-- START: ADD PRODUCTS SECTION --%>
    <div>
        <br />
        <br />
        <br />
        <h2>ADD NEW PRODUCT </h2>
        <div class="form-row">

            <%-- ADD PRODCUCT CODE --%>
            <div class="form-group col-md-4">
                <asp:TextBox ID="txtbxCode" runat="server" placeholder="Product Code" CssClass="form-control" />
            </div>
            
            <%-- ADD PRODCUCT TITLE --%>
            <div class="form-group col-md-8">
                <asp:TextBox ID="txtbxTitle" runat="server" placeholder="Title" CssClass="form-control" />
            </div>

            <%-- ADD PRODCUCT DESCRIPTION --%>
            <div class="form-group col-md-12">
                <asp:TextBox ID="txtbxDescription" runat="server" placeholder="Description" CssClass="form-control" />
            </div>

            <%-- ADD PRODCUCT QUANTITY --%>
            <div class="form-group col-md-2">
                <asp:TextBox ID="txtbxQuantity" runat="server" placeholder="Quantity" CssClass="form-control" />
            </div>

            <%-- ADD PRODCUCT PRICE --%>
            <div class="form-group col-md-2">
                <asp:TextBox ID="txtbxPrice" runat="server" placeholder="Price" CssClass="form-control" />
            </div>

            <%-- ADD PRODCUCT STATUS (ACTIVE/DISBALE) --%>
            <div class="form-group col-md-2">
                <asp:DropDownList ID="DropDownStatus" runat="server" placeholder="Status" CssClass="form-control">
                    <asp:ListItem> Activate </asp:ListItem>
                    <asp:ListItem> Suspend </asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <%-- ADD PRODCUCT IMAGE --%>
        <div class="form-group">
            <asp:Label ID="lblUpload" runat="server" Text="Upload product image" />
            <br />
            <asp:FileUpload ID="FileProduct" runat="server" ToolTip="Upload Product picture" />
        </div>

        <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="btn btn-dark" />
    </div>
    <%-- END: ADD PRODUCTS SECTION --%>

</asp:Content>
