using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheVintageStore.BusinessLayer;
using TheVintageStore.DataAccessLayer;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.UserLayer.UserPages
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CategoryID"] != null)
            {
                // Get the CategoryID from the Session
                int iCategoryID = Convert.ToInt32(Session["CategoryID"]);
                ProductBL methodSource = new ProductBL();
                
                // Create a list of instances of Product Class  
                List<DataAccessLayer.Models.Product> lisProducts = new List<DataAccessLayer.Models.Product>();
                
                // Copy the list of instances by calling down the function from BL passing the CategoryID
                lisProducts = methodSource.getProductsByCategory(iCategoryID);
                
                // Data bind the listView 
                ListViewCategory.DataSource = lisProducts;
                ListViewCategory.DataBind();
            }
        }

        // Method: LinkbtnProduct
        // Purpose: Save the product ID selected in a Session
        protected void linkbtnProduct_Command(object sender, CommandEventArgs e)
        {
            Session["ProductID"] = e.CommandArgument;
            Response.Redirect("~/Shop/Product");
        }
    }
}