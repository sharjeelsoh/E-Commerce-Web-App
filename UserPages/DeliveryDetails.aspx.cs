using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class DeliveryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // CONNECTION HAS TO BE SECURE
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "Purchase/DeliveryDetails";
                Response.Redirect(url);
            }

            if (!this.IsPostBack)
            {
                // Display the Delivery details for confirmation
                setCustomerDetails(txtbxAddress1, txtbxAddress2, txtbxSuburb, DropDownState, txtbxPostCode, txtbxPhNumber);
            }
        }

        // METHOD: BTN CONTINUE EVENT HANDLER 
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Purchase/PaymentMethod");
        }

        // METHOD: setCustomerDetails()
        // PURPOSE: Update the customer details if the changes or not (For the safe side if they change)
        protected void setCustomerDetails(TextBox address1, TextBox address2, TextBox suburb, DropDownList state, TextBox postcode, TextBox phoneNumber)
        {
            try
            {
                CustomerBL methodSource = new CustomerBL();

                // Check if Customer is logged in => 
                if (Session["CustomerLogin"] != null)
                {
                    // INFO: PART 1 => 
                    // To populate instance of Customer class, Call method from BusinessLayer, with given Email address (Person logged in)
                    
                    // Get Customer Data
                    Customer customer = methodSource.getCustomerDetails(Session["CustomerLogin"].ToString());
                    
                    // Get Address of the Customer
                    Address address = methodSource.getCustomerAddress(customer.iCustomerID);

                    // Display information in textboxes 
                    address1.Text = address.sAddress1;
                    address2.Text = address.sAddress2;
                    suburb.Text = address.sSuburb;
                    state.SelectedValue = address.sState;
                    postcode.Text = Convert.ToString(address.iPostCode);
                    phoneNumber.Text = customer.sPhoneNumber;
                }
            }
            catch
            {
                throw;
            }

        }
    }
}