using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CO5027.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUser_Click(object sender, EventArgs e)

        {
            var identityDbContext = new IdentityDbContext("co5027_ConnectionString");
            var userStore = new UserStore<IdentityUser>(identityDbContext);
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(txtUserName.Text, txtPassword.Text);
           
            if (txtUserName.Text != ("Admin"))
            {
                //Call OWIN functionality
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in user
                authenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, userIdentity);

                //Redirect user to Product page
                Response.Redirect("~/ProductList.aspx");
            }
            else
            {
                litStatus.Text = "Invalid username or password";
            }
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {

            var identityDbContext = new IdentityDbContext("co5027_ConnectionString");
            var userStore = new UserStore<IdentityUser>(identityDbContext);
            var manager = new UserManager<IdentityUser>(userStore);
            var user = manager.Find(txtUserName.Text, txtPassword.Text);

            if (txtUserName.Text == ("Admin"))
            {
                //Call OWIN functionality
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

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


