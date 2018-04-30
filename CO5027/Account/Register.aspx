<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CO5027.Account.Register" enableEventValidation="false" validateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   
        <div class="col-5 left-2">
        	<h3 class="h3-line">User Register:</h3>
            <form id="form" method="post" >
              <fieldset>
              <p>
        <asp:Literal runat="server" ID="litStatusMessage" />
        <asp:Literal runat="server" ID="literal1" />
            </p>

            User name:<br />
            <asp:TextBox runat="server" ID="txtUserName" CssClass="inputs" /><br />

            Password:
            <br />
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="inputs" /><br />

            Confirm password:
            <br />
            <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="inputs" /><br />

            Customer Name:<br />
            <asp:TextBox runat="server" ID="txtCustomerName" CssClass="inputs" /><br />

             Address:<br />
            <asp:TextBox runat="server" ID="txtAddress" CssClass="inputs" /><br />

            E-Mail:<br />
            <asp:TextBox runat="server" ID="txtEmail" CssClass="inputs" /><br />

            Phone Number:<br />
            <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="inputs" /><br />

              </fieldset>  
            </form>
            
            <p>
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-lg btn-success btn-block" Width="150px" />
            </p> 
            
        </div>
     

</asp:Content>