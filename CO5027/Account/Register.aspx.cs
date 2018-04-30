using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using CO5027.Model;

namespace CO5027.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)

        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["co5027_ConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);



            //Create new user and try to store in DB.
            IdentityUser user = new IdentityUser();
            user.UserName = txtUserName.Text;


            if (txtUserName.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "" || txtCustomerName.Text == "" || txtEmail.Text == "" || txtPhoneNumber.Text == "")
            {
                literal1.Text = "Please Complete All The Details";
            }
            else
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {

                    try
                    {
                        //Create user object
                        //Database will be created / expanded automatically.
                        IdentityResult result = manager.Create(user, txtPassword.Text);

                        if (result.Succeeded)
                        {
                            UserDetail info = new UserDetail {

                                CustomerName = txtCustomerName.Text,
                                Address = txtAddress.Text,
                                Email = txtEmail.Text,
                                PhoneNumber = Convert.ToInt32(this.txtPhoneNumber.Text),
                                GUID = user.Id

                            };

                             UserInfo model = new UserInfo();
                            model.InsertUserInfo(info);

                            //Store user in DB
                            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                            //Set to login new user by Cookie
                            var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                            //Log in the new user and redirect to Product page
                            authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                            Response.Redirect("~/Account/Login.aspx");
                        }
                        else
                        {
                            litStatusMessage.Text = result.Errors.FirstOrDefault();
                        }
                    }
                    catch (Exception ex)
                    {
                        litStatusMessage.Text = ex.ToString();
                    }
                }
                else
                {
                    litStatusMessage.Text = "Passwords must match!";
                }

            }
        }
    }
}

