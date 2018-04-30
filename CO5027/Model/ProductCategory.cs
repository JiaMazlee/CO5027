using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CO5027.Model
{
    public class ProductCategory
    {
        public string InsertProductCategory(ProductCat ProductCat)
        {
            try
            {
                db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
                db.ProductCats.Add(ProductCat);
                db.SaveChanges();

                return ProductCat.ProductCatName + " was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string UpdateProductCat(int ProductCatID, ProductCat ProductCat)
        {
            try
            {
                db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();

                //Fetch object from db
                ProductCat p = db.ProductCats.Find(ProductCatID);

                p.ProductCatName = ProductCat.ProductCatName;

                db.SaveChanges();
                return ProductCat.ProductCatName + " was succesfully updated";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string DeleteProductCat(int ProductCatID)
        {
            try
            {
                db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
                ProductCat ProductCat = db.ProductCats.Find(ProductCatID);

                db.ProductCats.Attach(ProductCat);
                db.ProductCats.Remove(ProductCat);
                db.SaveChanges();

                return ProductCat.ProductCatName + " was succesfully deleted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }
    }
}