using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CO5027.Model
{
    public class ShoppingCart { 
    public string InsertShoppingCart(Cart Cart)
    {
        try
        {
            db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
            db.Carts.Add(Cart);
            db.SaveChanges();

            return "Order was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateShoppingCart(int ShoppingCartID, Cart Cart)
    {
        try
        {
            db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();

            //Fetch object from db
            Cart p = db.Carts.Find(ShoppingCartID);

            p.DatePurchased = Cart.DatePurchased;
            p.CustomerID = Cart.CustomerID;
            p.ProductID = Cart.ProductID;
            p.AmountPurchased = Cart.AmountPurchased;
            p.ProductInCart = Cart.ProductInCart;


            db.SaveChanges();
            return Cart.DatePurchased + " was succesfully updated";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteShoppingCart(int ShoppingCartID)
    {
        try
        {
            db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
            Cart Cart = db.Carts.Find(ShoppingCartID);

            db.Carts.Attach(Cart);
            db.Carts.Remove(Cart);
            db.SaveChanges();

            return Cart.DatePurchased + "was succesfully deleted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public List<Cart> GetOrdersInCart(string CustomerID)
    {
        db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
        List<Cart> orders = (from x in db.Carts
                                     where x.CustomerID == CustomerID
                             && x.ProductInCart
                                     orderby x.DatePurchased descending
                                     select x).ToList();
        return orders;
    }

    public int GetAmountOfOrders(string CustomerID)
    {
        try
        {
            db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
            int amountPurchased = (from x in db.Carts
                                   where x.CustomerID == CustomerID
                                   && x.ProductInCart
                                   select x.AmountPurchased).Sum();

            return amountPurchased;
        }
        catch
        {
            return 0;
        }
    }

    public void UpdateQuantity(int ProductID, int quantity)
    {
        db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
        Cart p = db.Carts.Find(ProductID);
        p.AmountPurchased = quantity;

        db.SaveChanges();
    }

    public void MarkOrdersAsPaid(List<Cart> Carts)
    {
            db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();

        if (Carts != null)
        {
            foreach (Cart cart in Carts)
            {
                Cart oldCart = db.Carts.Find(cart.ShoppingCartID);
                oldCart.DatePurchased = DateTime.Now;
                oldCart.ProductInCart = false;
            }
            db.SaveChanges();
        }
    }
}
}