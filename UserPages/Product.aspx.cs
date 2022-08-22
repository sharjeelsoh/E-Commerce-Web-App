using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheVintageStore.BusinessLayer;
using TheVintageStore.DataAccessLayer.Models;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.UserLayer.UserPages
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ProductID"] != null)
            {
                // Get the Product ID from the Session and get the Product instance from BL class using getProductDetails() func
                int iProductCode = Convert.ToInt32(Session["ProductID"]);
                ProductBL methodSource = new ProductBL();
                DataAccessLayer.Models.Product product = methodSource.getProductDetails(iProductCode);

                // Populate tools/fields
                imgProduct.ImageUrl = product.sImageURL;
                lblTitle.Text = product.sTitle;
                lblDescription.Text = product.sDescription;
                lblPrice.Text = String.Format("Price: $" + product.dPrice);
                lblColor.Text = "Color: " + product.sColor;
                dropdownSize.Items.Add(product.sSize);
            }
        }

        // METHOD: EVENT HANDLER BTN ADD
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int iProductCode = Convert.ToInt32(Session["ProductID"]);
            
            // IF CART IS EMPTY => ADD THIS PRODUCT TO CART
            if (Session["Cart"] == null)
            {
                Dictionary<int, int> shoppingBag = new Dictionary<int, int>();
                shoppingBag.Add(iProductCode, 1);
                
                // CREATE CART
                Session["Cart"] = shoppingBag;

                Session["ProductQty"] = Convert.ToString(1);

                // REDIRECT TO CART PAGE
                Response.Redirect("~/ShoppingBag");
            }

            // IF CART ALREADY EXISTS (has items) => CHECK IF THE PRODUCT ALREADY EXISTS,
            // IF SO, INCREASE THE VALUE OF THAT PRODUCT (QTY)
            // IF NOT, ADD THE PRODUCT IN CART
            else if (Session["Cart"] != null)
            {
                Dictionary<int, int> shoppingBag = (Dictionary<int, int>)Session["Cart"];
                
                // CHECK IF ALREADY EXISTS
                if(shoppingBag.ContainsKey(iProductCode))
                {
                    shoppingBag[iProductCode]++;
                }

                // DOES NOT EXIST, ADD PRODUCT
                else
                {
                    shoppingBag.Add(iProductCode, 1);
                }

                // UPDATE CART 
                Session["Cart"] = shoppingBag;

                // REDIRECT TO CART PAGE
                Response.Redirect("~/ShoppingBag");
            }
        }
    }
}