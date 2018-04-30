<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="CO5027.Admin.ManageProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-5 left-2">
        	<h3 class="h3-line"></h3>
            <form id="form" method="post" >
                <p>Product Name:</p>
                <p>
                    <asp:TextBox ID="txtProductName" runat="server" Width="300px"></asp:TextBox>
                </p>
                <p>Product Category:</p>
                <p>
                    <asp:DropDownList ID="ddlCat" runat="server" DataSourceID="SqlProductCat" DataTextField="ProductCatName" DataValueField="ProductCatID" Width="300px"></asp:DropDownList>        
                    
                    <asp:SqlDataSource ID="SqlProductCat" runat="server" ConnectionString="<%$ ConnectionStrings:co5027_ConnectionString %>" SelectCommand="SELECT * FROM [ProductCat] ORDER BY [ProductCatName]"></asp:SqlDataSource>
                    
                <p>Price:</p>
                <p>
                    <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>
                </p>
                <p>Image:</p>
                <p>
                    <asp:DropDownList ID="ddlImage" runat="server" Width="300px">
                    </asp:DropDownList>
                </p>
                <p>Description:<p>
                    <asp:TextBox ID="txtDescription" runat="server" Height="70px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                </p>

 

                <p>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-lg btn-success btn-block"/>
                </p>
                <p>
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                </p>
            </form>  
            
        </div>
       </div>
</asp:Content>
