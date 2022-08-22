using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheVintageStore.BusinessLayer;
using TheVintageStore.DataAccessLayer;
using TheVintageStore.DataAccessLayer.Models;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.UserLayer.UserPages
{
    public partial class ReviewOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Connection has to be secured 
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "Purchase/Review";
                Response.Redirect(url);
            }

            // Retrieve the Cart from the Session and save it into a Dictionary
            Dictionary<int, int> shoppingBag = (Dictionary<int, int>)Session["Cart"];
            
            // Create a list of instances of Product class
            List<DataAccessLayer.Models.Product> lisProducts = new List<DataAccessLayer.Models.Product>();
            
            // For each item in the cart, Copy the instance of the product (with all details) and add that into the list
            foreach (KeyValuePair<int, int> cartItem in shoppingBag)
            {
                try
                {
                    ProductBL methodSource = new ProductBL();
                    DataAccessLayer.Models.Product product = methodSource.getProductDetails(cartItem.Key);
                    lisProducts.Add(product);
                }
                catch
                {
                    throw;
                }
            }

            // Bind the ListView
            ListViewReviewOrder.DataSource = lisProducts;
            ListViewReviewOrder.DataBind();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PurchaseSummary");
        }

        // METHOD: LIST VIEW PRE RENDER
        protected void ListViewReviewOrder_PreRender(object sender, EventArgs e)
        {
            // DISPLAY THE TOTAL GROSS AMOUNT
            Label lblTotalGross = ListViewReviewOrder.FindControl("lblTotalGross") as Label;
            lblTotalGross.Text = String.Format("Total Gross Amount: $" + Session["TotalGrossPrice"] + "AUD");

            // DELIVERY COST
            Label lblDeliveryCost = ListViewReviewOrder.FindControl("lblDeliveryCost") as Label;
            lblDeliveryCost.Text = String.Format("Delivery: $" + Session["DeliveryCost"] + "AUD");

            // DISPLAY THE TOTAL PRICE 
            Label lblTotalNet = ListViewReviewOrder.FindControl("lblTotalNet") as Label;
            lblTotalNet.Text = String.Format("TOTAL: $" + Session["TotalNetPrice"] + "AUD");

            // DISPLAY THE TOTAL ITEMS 
            Label lblTotalQty = ListViewReviewOrder.FindControl("lblItems") as Label;
            lblTotalQty.Text = Session["TotalCartQty"] + " Item(s)";

            // DISPLAY SHIPPING DETAILS (ADDRESS, EMAIL, AND CONTACT)
            try
            {
                CustomerBL methodSource = new CustomerBL();
                // Get customer details
                Customer customer = methodSource.getCustomerDetails(Session["CustomerLogin"].ToString());
                
                // Get address details of that customer
                Address address = methodSource.getCustomerAddress(customer.iCustomerID);

                
                // Create a structure to display as a string 
                string sAddress = address.sAddress1 + ", " + address.sSuburb + ", " +
                                   address.sState + ", " + address.iPostCode + "." ;

                // DISPLAY ON THE LABELS 
                // Customer name 
                Label lblName = ListViewReviewOrder.FindControl("lblName") as Label;
                lblName.Text = customer.sFirstName.ToUpper() + " " + customer.sLastName.ToUpper();

                // customer address
                Label lblAddress = ListViewReviewOrder.FindControl("lblAddress") as Label;
                lblAddress.Text = sAddress;

                // customer email
                Label lblEmail = ListViewReviewOrder.FindControl("lblEmail") as Label;
                lblEmail.Text = customer.sEmail;

                // customer contact
                Label lblContact = ListViewReviewOrder.FindControl("lblContact") as Label;
                lblContact.Text = customer.sPhoneNumber;
            }
            catch
            {
                throw;
            }

            // DISPLAY SHIPPING INFORMATION (DELIVERY OPTION, COST, DELIVERY DATE)
            // DELIVERY OPTION
            Label lblDeliveryOption = ListViewReviewOrder.FindControl("lblDeliveryOption") as Label;
            lblDeliveryOption.Text = Session["DeliveryOption"].ToString() + " Home Delivery ";

            // EXPECTED DELIVERY DATE
            DateTime today = DateTime.Today;
            Label lblExpectedDeliveryDate = ListViewReviewOrder.FindControl("lblExpectedDeliveryDate") as Label;
            
            // DELIVERY OPTION STANDARD
            if (Session["DeliveryOption"].ToString() == "Standard")
            {
                DateTime expectedTime = today.AddDays(10);
                lblExpectedDeliveryDate.Text = string.Format("{0:dd/MM/yyyy}", expectedTime);
            }

            // DELIVERY OPTION EXPRESS
            else if (Session["DeliveryOption"].ToString() == "Express")
            {
                DateTime expectedTime = today.AddDays(7);
                lblExpectedDeliveryDate.Text = string.Format("{0:dd/MM/yyyy}", expectedTime);
            }

            // PAYMENT METHOD SELECTED
            Label lblPayment = ListViewReviewOrder.FindControl("lblPayment") as Label;
            lblPayment.Text = Session["PaymentMethod"].ToString();
        }
    }
}