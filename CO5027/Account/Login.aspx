<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CO5027.Account.Login" enableEventValidation="false" validateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-5 left-2">
        	<h3 class="h3-line">User Login:</h3>
            <form id="form" method="post" >
              <fieldset>
              <asp:Literal ID="litStatus" runat="server"></asp:Literal>
                <br />
                <br />
                Username:<br />
                <asp:TextBox ID="txtUserName" runat="server" CssClass="inputs"></asp:TextBox>
                <br />
                <br />
                Password:<br />
                <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Button ID="btnUser" runat="server" CssClass="btn btn-lg btn-success btn-block" OnClick="btnUser_Click" Text="User Login" />
                <asp:Button ID="btnAdmin" runat="server" CssClass="btn btn-lg btn-success btn-block" OnClick="btnAdmin_Click" Text="Admin Login" /> 
              </fieldset>  
            </form>  
            
        </div>

</asp:Content>
