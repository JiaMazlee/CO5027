using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using CO5027.Model;


namespace CO5027
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Context.User.Identity;
            if (user.IsAuthenticated)
            {
                litStatus.Text = Context.User.Identity.Name;
                lnkLogin.Visible = false;
                lnkRegister.Visible = false;

                litStatus.Visible = true;
                lnkLogout.Visible = true;

                
                string CustomerID = HttpContext.Current.User.Identity.GetUserId();
                ShoppingCart model = new ShoppingCart();
                litStatus.Text = string.Format("{0} ({1})", Context.User.Identity.Name, model.GetAmountOfOrders(CustomerID)); litStatus.Text = string.Format("{0} ({1})", Context.User.Identity.Name, model.GetAmountOfOrders(CustomerID));

            }
            else
            {
                lnkLogin.Visible = true;
                lnkRegister.Visible = true;

                litStatus.Visible = false;
                lnkLogout.Visible = false;
            }
        }
      
        protected void lnkLogout_Click(object sender, EventArgs e)
        {

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            Response.Redirect("~/Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://validator.w3.org/nu/?doc=http%3A%2F%2F1722759.win.studentwebserver.co.uk%2FCO5027%2F");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://jigsaw.w3.org/css-validator/validator?uri=1722759.win.studentwebserver.co.uk%2FCO5027&profile=css3svg&usermedium=all&warning=1&vextwarning=&lang=en");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }
    }
}