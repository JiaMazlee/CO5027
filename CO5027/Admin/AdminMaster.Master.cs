using System;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;


namespace CO5027.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
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

            Response.Redirect("~/Account/Login.aspx");
        }
    }
}