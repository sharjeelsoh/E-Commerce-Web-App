using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.UserLayer.UserPages
{
    public partial class PaymentMethod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Connection has to be secured
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "Purchase/PaymentMethod";
                Response.Redirect(url);
            }
        }

        // METHOD: EVENT HANDLER BTN CONTINUE 
        protected void BtnContinue_Click(object sender, EventArgs e)
        {
            string sPaymentMethod = "";

            // If none option selected, alert!
            if ((!rdbtnMasterard.Checked) && (!rdbtnPaypal.Checked) && (!rdbtnVisa.Checked))
            {
                lblMessage.Text = "Please select a Payment option";
            }

            // If selected
            else
            {
                // Based on option selected, save that keyword into the variable 
                if (rdbtnMasterard.Checked) sPaymentMethod = "Mastercard";
                else if (rdbtnPaypal.Checked) sPaymentMethod = "Paypal";
                else if (rdbtnVisa.Checked) sPaymentMethod = "Visa";

                // Save the payment method into the Session
                Session["PaymentMethod"] = sPaymentMethod;

                // Redirect
                Response.Redirect("~/Purchase/CardDetails");
            }
        }
    }
}