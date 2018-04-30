using System;
using System.Collections;
using System.IO;
using CO5027.Model;


namespace CO5027.Admin
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetImages();

                //Check if the url contains an ID parameter
                if (!String.IsNullOrWhiteSpace(Request.QueryString["ProductID"]))
                {
                    int ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
                    FillPage(ProductID);
                }
            }
        }

        private Product CreateProduct()
        {
            Product Product = new Product();

            Product.ProductName = txtProductName.Text;
            Product.Category = Convert.ToInt32(ddlCat.SelectedValue);
            Product.Price = Convert.ToDecimal(txtPrice.Text);
            Product.Description = txtDescription.Text;
            Product.Image = ddlImage.SelectedValue;

            return Product;
        }

        private void FillPage(int ProductID)
        {
            //Get selected product from DB
            ReadyMixProduct productModel = new ReadyMixProduct();
            Product product = productModel.GetProduct(ProductID);

            //Fill textboxes
            txtDescription.Text = product.Description;
            txtProductName.Text = product.ProductName;
            txtPrice.Text = product.Price.ToString();

            //set dropdownlist values
            ddlImage.SelectedValue = product.Image;
            ddlCat.SelectedValue = product.Category.ToString();
        }

        private void FillForm(int ProductID)
        {
            try
            {
                ReadyMixProduct productModel = new ReadyMixProduct();
                Product product = productModel.GetProduct(ProductID);

                txtDescription.Text = product.Description;
                txtProductName.Text = product.ProductName;
                txtPrice.Text = product.Price.ToString();

                ddlImage.SelectedValue = product.Image;
                ddlCat.SelectedValue = product.Category.ToString();
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ReadyMixProduct productModel = new ReadyMixProduct();
            Product product = CreateProduct();

            //Check if the url contains an ID parameter
            if (!String.IsNullOrWhiteSpace(Request.QueryString["ProductID"]))
            {
                //ID exists -> Update existing row
                int ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
                lblResult.Text = productModel.UpdateProduct(ProductID, product);
            }
            else
            {
                //ID does not exist -> Create a new row
                lblResult.Text = productModel.InsertProduct(product);
            }
        }

        private void GetImages()
        {
            try
            {
                //Get all filepaths
                string[] images = Directory.GetFiles(Server.MapPath("~/RCB"));

                //Get all filenames and add them to an arraylist
                ArrayList imageList = new ArrayList();
                foreach (string image in images)
                {
                    string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                    imageList.Add(imageName);
                }

                //Set the arraylist as the dropdown's view datasource and refresh
                ddlImage.DataSource = imageList;
                ddlImage.AppendDataBoundItems = true;
                ddlImage.DataBind();
            }
            catch (Exception e)
            {
                lblResult.Text = e.ToString();
            }
        }
    }
}