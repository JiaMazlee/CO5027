<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="CO5027.Cart1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="content">
    <div class="block-2 pad-2">
     <h3 class="h3-line"></h3>

        <asp:Panel ID="pnlShoppingCart" runat="server"></asp:Panel> 
       
        <table>
            <tr>
                <td>
                    <b>Total: </b>
                </td>
                <td>
                    <asp:Literal ID="litTotal" runat="server" Text=""></asp:Literal>
                </td>
            </tr>

            <tr>
                <td>
                    <b>Total Amount: </b>
                </td>
                <td>
                    <asp:Literal ID="litTotalAmount" runat="server" Text="" />
                </td>
            </tr>

            <tr>
                <td>
                    <br />
                    <asp:LinkButton ID="ContShop" runat="server" PostBackUrl="~/Products.aspx">Continue Shopping</asp:LinkButton><br />OR<br />                    
                    <asp:Button ID="btnCheckout" runat="server" Text="Check Out" CssClass="btn btn-lg btn-success btn-block" Width="250px" PostBackUrl="~/Complete.aspx" />

                </td>
            </tr>

        </table>

    </div>
    </section>
</asp:Content>
