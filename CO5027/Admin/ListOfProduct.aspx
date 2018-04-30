<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ListOfProduct.aspx.cs" Inherits="CO5027.Admin.Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section id="content">
    <div class="block-2 pad-2">
        <h3 class="h3-line"></h3>
        
        <asp:LinkButton ID="AddProduct" runat="server" PostBackUrl="~/Admin/ManageProduct.aspx"><strong>Add New Product</strong></asp:LinkButton>
        <p style="clear: both"></p>

        <asp:GridView ID="grdProducts" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ProductID" DataSourceID="sdsProducts" ForeColor="#333333" GridLines="None" Width="100%" OnRowEditing="grdProducts_RowEditing">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
            
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>

        <asp:SqlDataSource ID="sdsProducts" runat="server" ConnectionString="<%$ ConnectionStrings:co5027_ConnectionString %>" DeleteCommand="DELETE FROM [Product] WHERE [ProductID] = @original_ProductID" InsertCommand="INSERT INTO [Product] ([ProductName], [Category], [Price], [Description], [Image]) VALUES (@ProductName, @Category, @Price, @Description, @Image)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Product]" UpdateCommand="UPDATE [Product] SET [ProductName] = @ProductName, [Category] = @Category, [Price] = @Price, [Description] = @Description, [Image] = @Image WHERE [ProductID] = @original_ProductID">
            <DeleteParameters>
                <asp:Parameter Name="original_ProductID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="Category" Type="Int32" />
                <asp:Parameter Name="Price" Type="Decimal" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Image" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="Category" Type="Int32" />
                <asp:Parameter Name="Price" Type="Decimal" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Image" Type="String" />
                <asp:Parameter Name="original_ProductID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

        <h3 class="h3-line"></h3>
        
        <asp:LinkButton ID="AddProductCategory" runat="server" PostBackUrl="~/Admin/ManageProductCat.aspx"><strong>Add New Product Category</strong></asp:LinkButton>
        <p style="clear: both">
            <asp:GridView ID="grdCategory" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ProductCatID" DataSourceID="sdsCategory" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="ProductCatID" HeaderText="ProductCatID" InsertVisible="False" ReadOnly="True" SortExpression="ProductCatID" />
                    <asp:BoundField DataField="ProductCatName" HeaderText="ProductCatName" SortExpression="ProductCatName" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <asp:SqlDataSource ID="sdsCategory" runat="server" ConnectionString="<%$ ConnectionStrings:co5027_ConnectionString %>" DeleteCommand="DELETE FROM [ProductCat] WHERE [ProductCatID] = @original_ProductCatID" InsertCommand="INSERT INTO [ProductCat] ([ProductCatName]) VALUES (@ProductCatName)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [ProductCat]" UpdateCommand="UPDATE [ProductCat] SET [ProductCatName] = @ProductCatName WHERE [ProductCatID] = @original_ProductCatID">
                <DeleteParameters>
                    <asp:Parameter Name="original_ProductCatID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ProductCatName" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ProductCatName" Type="String" />
                    <asp:Parameter Name="original_ProductCatID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </p>

     </div>
    </section> 




</asp:Content>
