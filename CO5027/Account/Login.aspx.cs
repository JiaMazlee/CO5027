using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Collections.Generic;

namespace CO5027.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUser_Click(object sender, EventArgs e)

        {

                 UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["co5027_ConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);
            var user = manager.Find(txtUserName.Text, txtPassword.Text);

            if (txtUserName.Text != ("Admin"))
            {
                //Call OWIN functionality
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in user
                authenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, userIdentity);

                //Redirect user to Product page
                Response.Redirect("~/Product.aspx");
            }
            else
            {
                litStatus.Text = "Invalid username or password";
            }
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {

            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["co5027_ConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            var Admin = manager.Find(txtUserName.Text, txtPassword.Text);

            if (txtUserName.Text == ("Admin"))
            {
                //Call OWIN functionality
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(Admin, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in user
                authenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, userIdentity);

                //Redirect user to Home page
                Response.Redirect("~/Admin/Dashboard.aspx");
            }
            else
            {
                litStatus.Text = "Username is not an Admin, please enter a valid Admin username and password";
            }
        }
    }
}


