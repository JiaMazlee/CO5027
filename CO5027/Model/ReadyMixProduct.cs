using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CO5027.Model
{
    public class ReadyMixProduct
    {
        public string InsertProduct(Product Product)
        {
            try
            {
                db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
                db.Products.Add(Product);
                db.SaveChanges();

                return Product.ProductName + " was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string UpdateProduct(int ProductID, Product Product)
        {
            try
            {
                db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();

                //Fetch object from db
                Product p = db.Products.Find(ProductID);

                p.ProductName = Product.ProductName;
                p.Price = Product.Price;
                p.Category = Product.Category;
                p.Description = Product.Description;
                p.Image = Product.Image;

                db.SaveChanges();
                return Product.ProductName + " was succesfully updated";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string DeleteProduct(int ProductID)
        {
            try
            {
                db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
                Product Product = db.Products.Find(ProductID);

                db.Products.Attach(Product);
                db.Products.Remove(Product);
                db.SaveChanges();

                return Product.ProductName + " was succesfully deleted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public Product GetProduct(int ProductID)
        {
            try
            {
                using (db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities())
                {
                    Product product = db.Products.Find(ProductID);
                    return product;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                using (db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities())
                {
                    List<Product> products = (from x in db.Products
                                              select x).ToList();
                    return products;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Product> GetProductsByCategory(int Category)
        {
            try
            {
                using (db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities())
                {
                    List<Product> products = (from x in db.Products
                                              where x.Category == Category
                                              select x).ToList();
                    return products;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}