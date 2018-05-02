using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using CO5027.Model;


namespace CO5027
{
    public partial class Product1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                string CustomerID = Context.User.Identity.GetUserId();

                if (CustomerID != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    int amountPurchased = Convert.ToInt32(ddlAmount.SelectedValue);

                    Cart cart = new Cart

                    {
                        AmountPurchased = amountPurchased,
                        CustomerID = CustomerID,
                        DatePurchased = DateTime.Now,
                        ProductInCart = true,
                        ProductID = id
                    };

                    ShoppingCart model = new ShoppingCart();
                    lblResult.Text = model.InsertShoppingCart(cart);
                    Response.Redirect("~/Cart.aspx");
                }
                else
                {
                    lblResult.Text = "Please Log In To Purchase Items";
                }
            }
        }

            private void FillPage()
            {
                //Get selected product data
                if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    ReadyMixProduct model = new ReadyMixProduct();
                    Product product = model.GetProduct(id);

                    //Fill page with data
                    lblTitle.Text = product.ProductName;
                    lblDescription.Text = product.Description;
                    lblPrice.Text = "Price per unit:<br/>BND " + product.Price;
                    imgProduct.ImageUrl = "~/RCB/" + product.Image;
                    lblItemNr.Text = product.ProductID.ToString();

                    //Fill amount list with numbers 1-20
                    int[] amount = Enumerable.Range(1, 20).ToArray();
                    ddlAmount.DataSource = amount;
                    ddlAmount.AppendDataBoundItems = true;
                    ddlAmount.DataBind();
                }
            }

        }
    }

       