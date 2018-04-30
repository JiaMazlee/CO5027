using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CO5027.Model;

namespace CO5027.Admin
{
    public partial class ManageProductCat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductCategory model = new ProductCategory();
            ProductCat pt = CreateProductCat();

            lblResult.Text = model.InsertProductCategory(pt);
        }

        private ProductCat CreateProductCat()
        {
            ProductCat p = new ProductCat();
            p.ProductCatName = txtCat.Text;

            return p;
        }
    }
}