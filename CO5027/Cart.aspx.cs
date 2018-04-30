using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using CO5027.Model;

namespace CO5027
{
    public partial class Cart1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if user is logged in
            string CustomerID = User.Identity.GetUserId();

            //Display all items in user's cart.
            GetPurchasesInCart(CustomerID);
        }

        protected void Delete_Item(object sender, EventArgs e)
        {
            LinkButton selectedLink = (LinkButton)sender;
            string link = selectedLink.ID.Replace("del", "");
            int ShoppingCartID = Convert.ToInt32(link);

            ShoppingCart ShoppingCart = new ShoppingCart();
            ShoppingCart.DeleteShoppingCart(ShoppingCartID);

            Response.Redirect("~/Cart.aspx");
        }

        private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get ID of product that has had its quantity dropdownlist changed.
            DropDownList selectedList = (DropDownList)sender;
            int ShoppingCartID = Convert.ToInt32(selectedList.ID);
            int Quantity = Convert.ToInt32(selectedList.SelectedValue);

            //Update purchase with new quantity and refresh page
            ShoppingCart ShoppingCart = new ShoppingCart();
            ShoppingCart.UpdateQuantity(ShoppingCartID, Quantity);
            Response.Redirect("~/Cart.aspx");
        }

        private void GetPurchasesInCart(string CustomerID)
        {
            ShoppingCart ShoppingCart = new ShoppingCart();
            double subTotal = 0;

            //Get all purchases for current user and display in table
            List<Cart> list = ShoppingCart.GetOrdersInCart(CustomerID);
            CreateShopTable(list, out subTotal);

            //Add totals to webpage
            double totalAmount = subTotal;

            litTotal.Text = "BND$ " + subTotal;
            litTotalAmount.Text = "BND$ " + totalAmount;
        }

        private void CreateShopTable(IEnumerable<Cart> Carts, out double subTotal)
        {
            subTotal = new double();
            ReadyMixProduct model = new ReadyMixProduct();

            foreach (Cart shoppingcart in Carts)
            {
                //Create HTML elements and fill values with database data
                Product product = model.GetProduct(shoppingcart.ProductID);

                ImageButton btnImage = new ImageButton
                {
                    ImageUrl = string.Format("~/RCB/{0}", product.Image),
                    PostBackUrl = string.Format("~/Product.aspx?id={0}", product.ProductID)
                };

                LinkButton lnkDelete = new LinkButton
                {
                    PostBackUrl = string.Format("~/Cart.aspx?productId={0}", shoppingcart.ShoppingCartID),
                    Text = "Delete Item",
                    ID = "del" + shoppingcart.ShoppingCartID,
                };

                lnkDelete.Click += Delete_Item;

                //Fill amount list with numbers 1-50
                int[] amountpurchased = Enumerable.Range(1, 50).ToArray();
                DropDownList ddlAmount = new DropDownList
                {
                    DataSource = amountpurchased,
                    AppendDataBoundItems = true,
                    AutoPostBack = true,
                    ID = shoppingcart.ShoppingCartID.ToString()
                };
                ddlAmount.DataBind();
                ddlAmount.SelectedValue = shoppingcart.AmountPurchased.ToString();
                ddlAmount.SelectedIndexChanged += ddlAmount_SelectedIndexChanged;

                //Create table to hold shopping cart details
                Table table = new Table { CssClass = "CartTable" };
                TableRow row1 = new TableRow();
                TableRow row2 = new TableRow();

                TableCell cell1_1 = new TableCell { RowSpan = 2, Width = 50 };
                TableCell cell1_2 = new TableCell
                {
                    Text = string.Format("<h4>{0}</h4><br />{1}<br/>In Stock",
                    product.ProductName, "Item No:" + product.ProductID),
                    HorizontalAlign = HorizontalAlign.Left,
                    Width = 350,
                };
                TableCell cell1_3 = new TableCell { Text = "Unit Price<hr/>" };
                TableCell cell1_4 = new TableCell { Text = "Quantity<hr/>" };
                TableCell cell1_5 = new TableCell { Text = "Item Total<hr/>" };
                TableCell cell1_6 = new TableCell();

                TableCell cell2_1 = new TableCell();
                TableCell cell2_2 = new TableCell { Text = "BND$" + product.Price };
                TableCell cell2_3 = new TableCell();
                TableCell cell2_4 = new TableCell { Text = "BND$" + Math.Round((shoppingcart.AmountPurchased * (double)product.Price), 2) };
                TableCell cell2_5 = new TableCell();



                //Set custom controls
                cell1_1.Controls.Add(btnImage);
                cell1_6.Controls.Add(lnkDelete);
                cell2_3.Controls.Add(ddlAmount);

                //Add rows & cells to table
                row1.Cells.Add(cell1_1);
                row1.Cells.Add(cell1_2);
                row1.Cells.Add(cell1_3);
                row1.Cells.Add(cell1_4);
                row1.Cells.Add(cell1_5);
                row1.Cells.Add(cell1_6);

                row2.Cells.Add(cell2_1);
                row2.Cells.Add(cell2_2);
                row2.Cells.Add(cell2_3);
                row2.Cells.Add(cell2_4);
                row2.Cells.Add(cell2_5);
                table.Rows.Add(row1);
                table.Rows.Add(row2);
                pnlShoppingCart.Controls.Add(table);

                //Add total of current purchased item to subtotal
                subTotal += (shoppingcart.AmountPurchased * (double)product.Price);
            }

            //Add selected objects to Session
            Session[User.Identity.GetUserId()] = Carts;
        }
    }
}