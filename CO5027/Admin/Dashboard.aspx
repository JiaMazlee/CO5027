<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CO5027.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content">
        
    <div class="block-2 pad-2">
      <br /><h2 class="h2-line">List of Customer's Orders</h2>

        <asp:GridView ID="grdOrders" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ShoppingCartID" DataSourceID="sdsOrders" ForeColor="#333333" GridLines="None" Width="80%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="ShoppingCartID" HeaderText="ShoppingCartID" InsertVisible="False" ReadOnly="True" SortExpression="ShoppingCartID" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
                <asp:BoundField DataField="AmountPurchased" HeaderText="AmountPurchased" SortExpression="AmountPurchased" />
                <asp:BoundField DataField="DatePurchased" HeaderText="DatePurchased" SortExpression="DatePurchased"/>
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

      
        <asp:SqlDataSource ID="sdsOrders" runat="server" ConnectionString="<%$ ConnectionStrings:co5027_ConnectionString %>" DeleteCommand="DELETE FROM [Cart] WHERE [ShoppingCartID] = @ShoppingCartID" InsertCommand="INSERT INTO [Cart] ([ProductID], [AmountPurchased], [CustomerID], [DatePurchased]) VALUES (@ProductID, @AmountPurchased, @CustomerID, @DatePurchased)" SelectCommand="SELECT [ShoppingCartID], [ProductID], [AmountPurchased], [CustomerID], [DatePurchased] FROM [Cart]" UpdateCommand="UPDATE [Cart] SET [ProductID] = @ProductID, [AmountPurchased] = @AmountPurchased, [CustomerID] = @CustomerID, [DatePurchased] = @DatePurchased WHERE [ShoppingCartID] = @ShoppingCartID">
            <DeleteParameters>
                <asp:Parameter Name="ShoppingCartID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductID" Type="Int32"/>
                <asp:Parameter Name="AmountPurchased" Type="Int32" />
                <asp:Parameter Name="CustomerID" Type="String" />
                <asp:Parameter Name="DatePurchased" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductID" Type="Int32" />
                <asp:Parameter Name="AmountPurchased" Type="Int32" />
                <asp:Parameter Name="CustomerID" Type="String" />
                <asp:Parameter Name="DatePurchased" Type="DateTime" />
                <asp:Parameter Name="ShoppingCartID" Type ="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

               <br /><br />
       <asp:Button ID="btnAddNewProduct" runat="server" Text="Add New Product" CssClass="btn btn-lg btn-success btn-block" Width="250px" PostBackUrl="~/Admin/ManageProduct.aspx" /> &nbsp;&nbsp;    
       <asp:Button ID="btnAddNewProductCat" runat="server" Text="Add New Product Category" CssClass="btn btn-lg btn-success btn-block" Width="250px" PostBackUrl="~/Admin/ManageProductCat.aspx" />     

    

    </div>
    </section> 

</asp:Content>
