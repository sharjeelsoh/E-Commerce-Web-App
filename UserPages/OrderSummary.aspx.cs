using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using TheVintageStore.BusinessLayer;
using System.Configuration;
using TheVintageStore.DataAccessLayer.Models;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.UserLayer.UserPages
{
    public partial class OrderSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Connection has to be secured
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "PurchaseSummary";
                Response.Redirect(url);
            }

            // As soon as you load, Send the receipt to the Customer
            if (!this.IsPostBack)
            {
                SendEmail email = new SendEmail();
                try
                {
                    CustomerBL methodSource = new CustomerBL();
                    Customer customer = methodSource.getCustomerDetails(Session["CustomerLogin"].ToString());

                    email.sFromName = "The Vintage Store"; // Website.Fullname
                    email.sFromAddress = "thevintagestoreshop@gmail.com"; // Website.email
                    email.sSubject = "Thank you for your purchase"; // Predefined

                    // In body, you could add, | Order No. | Customer Name | Expected Delivery Date | OrderItems => Qty, Price | Total Amount | Pay by Card | 
                    email.sBody = "Thank you for your purchase, " + customer.sFirstName + "!" + "\r\n" +
                                   "Order # 678789" + "\r\n";
                    email.sToAddress = customer.sEmail;
                    email.SendAnEmail(3);

                    // Display confirmation message 
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Purchase Successful! A copy of your receipt has been sent to you via email.');", true);
                }
                catch
                {
                    throw;
                }

                // UPDATE THE PURCHASE INTO THE DATABASE by calling updatePurchaseInDatabase()
                updatePurchaseInDatabase();
            }

            // CREATE A DICTIONARY AND COPY THE ITEMS SAVED IN SESSION CART
            Dictionary<int, int> shoppingBag = (Dictionary<int, int>)Session["Cart"];
            
            // CREATE A LIST OF INSTANCES OF THE PRODUCT CLASS
            List<DataAccessLayer.Models.Product> lisProducts = new List<DataAccessLayer.Models.Product>();
            
            // FOR EACH ITEM IN CART, ADD THAT ITEM INTO THE LIST USING PRODUCT CODE (cart.item.key)
            foreach (KeyValuePair<int, int> cartItem in shoppingBag)
            {
                try
                {
                    // Copy the instance of Product class by calling the function getProductDetails() in BL class
                    // And add thatv into the product list
                    ProductBL productMethodSource = new ProductBL();
                    DataAccessLayer.Models.Product product = productMethodSource.getProductDetails(cartItem.Key);
                    lisProducts.Add(product);
                }
                catch
                {
                    throw;
                }
            }

            // BIND THE LIST VIEW 
            ListViewOrderSummary.DataSource = lisProducts;
            ListViewOrderSummary.DataBind();
        }

        // METHOD: EVENT HANDLER BTN SHOP MORE 
        // PURPOSE: Empty the cart & redirect them to Shop page 
        protected void btnShopMore_Click(object sender, EventArgs e)
        {
            // Empty the Cart
            Session["Cart"] = null;

            // REDIRECT
            Response.Redirect("~/Shop");
        }

        // METHOD: EVENT HANDLER PRE RENDER
        protected void ListViewOrderSummary_PreRender(object sender, EventArgs e)
        {
            // DISPLAY THE TOTAL GROSS AMOUNT
            Label lblTotalGross = ListViewOrderSummary.FindControl("lblTotalGross") as Label;
            lblTotalGross.Text = String.Format("Total Gross Amount: $" + Session["TotalGrossPrice"] + "AUD");

            // DELIVERY COST
            Label lblDeliveryCost = ListViewOrderSummary.FindControl("lblDeliveryCost") as Label;
            lblDeliveryCost.Text = String.Format("Delivery: $" + Session["DeliveryCost"] + "AUD");

            // DISPLAY THE TOTAL PRICE 
            Label lblTotalNet = ListViewOrderSummary.FindControl("lblTotalNet") as Label;
            lblTotalNet.Text = String.Format("Total: $" + Session["TotalNetPrice"]);

            // DISPLAY THE TOTAL ITEMS 
            Label lblTotalQty = ListViewOrderSummary.FindControl("lblItems") as Label;
            lblTotalQty.Text = Session["TotalCartQty"] + " Item(s)";

            // DISPLAY SHIPPING DETAILS (ADDRESS, EMAIL, AND CONTACT)
            try
            {
                CustomerBL methodSource = new CustomerBL();
                
                // GET CUSTOMER DETAILS
                Customer customer = methodSource.getCustomerDetails(Session["CustomerLogin"].ToString());
                
                // GET ADDRESS OF THE CUSTOMER BY PROVIDING CUSTOMER ID
                Address address = methodSource.getCustomerAddress(customer.iCustomerID);

                // CREATE AN ADDRESS FORMAT TO DISPLAY
                string sAddress = address.sAddress1 + ", " + address.sSuburb + ", " +
                                   address.sState + ", " + address.iPostCode + ".";

                
                // DISPLAY DATA INTO THE LABELS
                // Customer name
                Label lblName = ListViewOrderSummary.FindControl("lblName") as Label;
                lblName.Text = customer.sFirstName.ToUpper() + " " + customer.sLastName.ToUpper();

                // customer address
                Label lblAddress = ListViewOrderSummary.FindControl("lblAddress") as Label;
                lblAddress.Text = sAddress;

                // customer email
                Label lblEmail = ListViewOrderSummary.FindControl("lblEmail") as Label;
                lblEmail.Text = customer.sEmail;

                // customer contact number
                Label lblContact = ListViewOrderSummary.FindControl("lblContact") as Label;
                lblContact.Text = customer.sPhoneNumber;
            }
            catch
            {
                throw;
            }

            // DISPLAY SHIPPING INFORMATION (DELIVERY OPTION, COST, DELIVERY DATE)
            // DELIVERY OPTION
            Label lblDeliveryOption = ListViewOrderSummary.FindControl("lblDeliveryOption") as Label;
            lblDeliveryOption.Text = Session["DeliveryOption"].ToString() + " Home Delivery ";

            // EXPECTED DELIVERY DATE
            DateTime today = DateTime.Today;
            Label lblExpectedDeliveryDate = ListViewOrderSummary.FindControl("lblExpectedDeliveryDate") as Label;

            // SET EXPECTED DELIVERY DATE
            // STANDARD DELIVERY OPTION
            if (Session["DeliveryOption"].ToString() == "Standard")
            {
                DateTime expectedTime = today.AddDays(10);
                lblExpectedDeliveryDate.Text = string.Format("{0:dd/MM/yyyy}", expectedTime);
                Session["ExpectedDeliveryDate"] = expectedTime;
            }

            // EXPRESS DELIVERY OPTION
            else if (Session["DeliveryOption"].ToString() == "Express")
            {
                DateTime expectedTime = today.AddDays(7);
                lblExpectedDeliveryDate.Text = string.Format("{0:dd/MM/yyyy}", expectedTime);
                Session["ExpectedDeliveryDate"] = expectedTime;
            }

            // PAYMENT METHOD SELECTED
            Label lblPayment = ListViewOrderSummary.FindControl("lblPayment") as Label;
            lblPayment.Text = Session["PaymentMethod"].ToString();
        }

        // METHOD: updatePurchaseInDatabase()
        // PURPOSE: Save the purchase in the database, in all 3 tables, TblOrders, TblOrderItem, TblShipping
        protected void updatePurchaseInDatabase ()
        {
            // UPDATE THE PURCHASE IN DATABASE
            // Get Customer ID
            CustomerBL customerMethodSource = new CustomerBL();
            Customer customer = customerMethodSource.getCustomerDetails(Session["CustomerLogin"].ToString());
            int iCustomerID = customer.iCustomerID;

            // Insert Shipping details
            ShippingBL shippingMethodSource = new ShippingBL();
            string sShippingType = Session["DeliveryOption"].ToString();
            double dFee = Convert.ToDouble(Session["DeliveryCost"]);
            DateTime dtExpectedDeliveryDate; 

            // BASED ON DELIVERY OPTION SELECTED, ADD THE DELIVERY TIME DAYS 
            if (sShippingType == "Standard") dtExpectedDeliveryDate = DateTime.Now.AddDays(10);
            else dtExpectedDeliveryDate = DateTime.Now.AddDays(7);
            
            // INSERT ALL FIELDS INTO THE DATABASE (tblShipping)
            int iShippingRows = shippingMethodSource.insertShippingDetails(iCustomerID, sShippingType, dFee, dtExpectedDeliveryDate);

            // Get Shipping details
            Shipping shipping = shippingMethodSource.getShippingDetails(iCustomerID);
            int iShippingID = shipping.iShippingID;

            // Insert Order
            double dTotalPrice = Convert.ToDouble(Session["TotalNetPrice"]);
            DateTime dtOrderDate = DateTime.Now;
            OrdersBL orderMethodSource = new OrdersBL();
            
            // INSERT ALL FIELDS INTO THE DATABASE (tblOrders)
            int iOrderRows = orderMethodSource.insertOrderDetails(iCustomerID, iShippingID, dTotalPrice, dtOrderDate);

            // Get Order Details
            Orders order = orderMethodSource.getOrderDetails(iCustomerID);
            int iOrderNo = order.iOrderNo;

            // Insert every product in the Cart, into the Database (tblOrderItem)
            OrderItemBL orderItemMethodSource = new OrderItemBL();
            Dictionary<int, int> shoppingBag = (Dictionary<int, int>)Session["Cart"];       // GET THE CART
            foreach (KeyValuePair<int, int> cartItem in shoppingBag)
            {
                // ADD EACH PRODUCT BY CALLING insertOrderItemDetails() IN BL 
                int iOrderItemRows = orderItemMethodSource.insertOrderItemDetails(cartItem.Key, iOrderNo, cartItem.Value);
            }
        }
    }
}