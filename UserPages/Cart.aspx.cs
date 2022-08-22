using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheVintageStore.DataAccessLayer.Models;
using TheVintageStore.BusinessLayer;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.UserLayer.Pages
{

    public partial class Cart : System.Web.UI.Page
    {
        double dTotalPrice;     // TOTAL PRICE OF ALL PRODUCTS
        int iTotalQty;          // TOTAL QUANTITY OF ALL PRODUCTS 
        protected void Page_Load(object sender, EventArgs e)
        {
            // ENSURE PAGE IS SECURED 
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "ShoppingBag";
                Response.Redirect(url);
            }

            // COPY THE CART INTO NEW DICTIONARY CALLED SHOPPING BAG 
            Dictionary<int, int> shoppingBag = (Dictionary<int, int>)Session["Cart"];
            
            // IF SHOPPING BAG (COPIED CART) IS EMPTY, DISPLAY A MESSAGE ("nothing in cart")
            if ((shoppingBag == null) || (shoppingBag.Count == 0))
            {
                divNoItems.Visible = true;
                Session["Cart"] = null;
            }
            
            // IF SHOPPING BAG (COPIED CART) EXISTS
            else
            {
                // CREATE A LIST OF PRODUCTS (FOR DISPLAY)
                List<Product> lisProducts = new List<Product>();
                dTotalPrice = 0;        // INITIALISE VALUES 
                iTotalQty = 0;          // INITIALISE VALUES

                // FOR EACH ITEM IN SHOPPING BAG, GET THAT PRODUCT (BASED ON THE PRODUCT_ID) AND ADD INTO THE LIST
                // KEEP ADDING THE TOTAL PRICE AND QUANTITY UNTIL LAST PRODUCT
                foreach (KeyValuePair<int, int> cartItem in shoppingBag)
                {
                    try
                    {
                        ProductBL methodSource = new ProductBL();
                        Product product = methodSource.getProductDetails(cartItem.Key);     // GET PRODUCT
                        lisProducts.Add(product);                                           // ADD PRODUCT INTO THE LIST
                        dTotalPrice += product.dPrice * shoppingBag[product.iProductCode];  // ADD PRODUCT'S PRICE INTO TOTAL_PRICE
                        iTotalQty += shoppingBag[product.iProductCode];                     // ADD QUANTITY FOR ALL PRODUCTS 
                        
                        // SAVE TOTAL PRICE AND TOTAL QTY IN SESSIONS, FOR LATER USE
                        Session["TotalGrossPrice"] = dTotalPrice;
                        Session["TotalCartQty"] = iTotalQty;
                    }
                    catch
                    {
                        throw;
                    }
                }

                // BIND THE LIST VIEW 
                ListViewCart.DataSource = lisProducts;
                ListViewCart.DataBind();
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            // IF CUSTOMER NOT LOGGED IN OR REGISTERED => REDIRECT TO LOGIN 
            if ((Session["CustomerLogin"] == null) && (Session["Register"] == null)) Response.Redirect("~/Login");
            
            // IF HE IS, PROCEED TO DELIVERY OPTIONS 
            else Response.Redirect("~/Purchase/ChooseDeliveryOption");
        }

        // METHOD: BTN MORE EVENT HANDLER
        protected void btnMore_Command(object sender, CommandEventArgs e)
        {
            // GET THE PRODUCT ID OF THE PRODUCT (THE ONE TO INCREASE QTY)
            int iProductCode = Convert.ToInt32(e.CommandArgument);
            
            // COPY THE CART INTO NEW SHOPPING BAG 
            Dictionary<int, int> shoppingBag = (Dictionary<int, int>)Session["Cart"];
            
            shoppingBag[iProductCode]++;        // INCREMENT THE PRODUCT
            Session["Cart"] = shoppingBag;      // UPDATE THE CART 

            // SAVE THE KEY (QUANTITY) INTO A SESSION TO BE USED LATER
            Session["ProductQty"] = Convert.ToString(shoppingBag[iProductCode]);

            Response.Redirect("~/ShoppingBag");     // RELOAD THE PAGE
        }

        // METHOD: BTN LESS EVENT HANDLER 
        protected void btnLess_Command(object sender, CommandEventArgs e)
        {
            // GET THE PRODUCT ID OF THE PRODUCT (THE ONE TO INCREASE QTY)
            int iProductCode = Convert.ToInt32(e.CommandArgument);

            // COPY THE CART INTO NEW SHOPPING BAG 
            Dictionary<int, int> shoppingBag = (Dictionary<int, int>)Session["Cart"];

            shoppingBag[iProductCode]--;        // DECREMENT THE PRODUCT
            Session["Cart"] = shoppingBag;      // UPDATE THE CART

            // SAVE THE KEY (QUANTITY) INTO A SESSION TO BE USED LATER
            Session["ProductQty"] = Convert.ToString(shoppingBag[iProductCode]);

            Response.Redirect("~/ShoppingBag");     // RELOAD THE PAGE
        }

        // METHOD: BTN REMOVE EVENT HANDLER
        protected void btnRemove_Command(object sender, CommandEventArgs e)
        {
            // GET THE PRODUCT ID OF THE PRODUCT (THE ONE TO INCREASE QTY)
            int iProductCode = Convert.ToInt32(e.CommandArgument);

            // COPY THE CART INTO NEW SHOPPING BAG 
            Dictionary<int, int> shoppingBag = (Dictionary<int, int>)Session["Cart"];

            shoppingBag.Remove(iProductCode);       // REMOVE THE PRODUCT

            // UPDATE THE CART 
            Session["Cart"] = shoppingBag;

            Response.Redirect("~/ShoppingBag");     // RELOAD THE PAGE
        }

        // METHOD: LIST VIEW DATA BOUND 
        protected void ListViewCart_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            // UPDATE THE QUANTITY OF EACH ITEM SAVED ABOVE IN SESSION, EVERY TIME YOU BIND 
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblQty = (Label)e.Item.FindControl("lblQty");
                lblQty.Text = Session["ProductQty"].ToString();
            }
        }

        // METHOD: LIST VIEW PRE RENDER (TO ACCESS LAYOUT TEMPLATE LABELS)
        protected void ListViewCart_PreRender(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                if (dTotalPrice > 0)
                {
                    // DISPLAY THE TOTAL PRICE 
                    Label lblTotalPrice = ListViewCart.FindControl("lblTotalPrice") as Label;
                    lblTotalPrice.Text = String.Format("TOTAL: $" + dTotalPrice);
                    
                    // DISPLAY THE TOTAL ITEMS 
                    Label lblTotalQty = ListViewCart.FindControl("lblItems") as Label;
                    lblTotalQty.Text = iTotalQty + " Item(s)";
                }
            }
        }
    }
}