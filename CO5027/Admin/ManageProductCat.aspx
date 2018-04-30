<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageProductCat.aspx.cs" Inherits="CO5027.Admin.ManageProductCat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p>
                Product Category Name:</p>
            <p>
                <asp:TextBox ID="txtCat" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btn btn-lg btn-success btn-block"/>
            </p>
            <p>
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </p> 


</asp:Content>

