using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using CO5027.Model;

namespace CO5027
{
    public partial class Complete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Cart> shoppingcarts = (List<Cart>)Session[User.Identity.GetUserId()];

            ShoppingCart model = new ShoppingCart();
            model.MarkOrdersAsPaid(shoppingcarts);

            Session[User.Identity.GetUserId()] = null;
        }
    }
}