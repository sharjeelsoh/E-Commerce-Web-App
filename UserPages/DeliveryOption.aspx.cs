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
    public partial class DeliveryOption : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Connection has to be secure 
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "Purchase/ChooseDeliveryOption";
                Response.Redirect(url);
            }
        }

        // METHOD: EVENT HANDLER BTN CONTINUE
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            string sShippingType = "";
            double dShippingCost = 0;
            double dTotalPrice = Convert.ToDouble(Session["TotalGrossPrice"]);

            // IF NONE OPTION SELECTED, ALERT
            if ((!rdbtnStandard.Checked) && (!rdbtnExpress.Checked)) lblMessage.Text = "(Please select a Shipping option)";
            
            // IF SELECTED
            else
            {
                // STANDARD SHIPPING
                if (rdbtnStandard.Checked)
                {
                    sShippingType = "Standard";
                    dShippingCost = 7.95;

                    // SET THE TOTAL NET PRICE BY ADDING SHIPPING COST INTO GROSS PRICE
                    dTotalPrice += dShippingCost;
                    Session["TotalNetPrice"] = dTotalPrice;
                }

                // EXPRESS SHIPPING
                else if (rdbtnExpress.Checked)
                {
                    sShippingType = "Express";
                    dShippingCost = 11.95;

                    // SET THE TOTAL NET PRICE BY ADDING SHIPPING COST INTO GROSS PRICE
                    dTotalPrice += dShippingCost;
                    Session["TotalNetPrice"] = dTotalPrice;
                }

                // SAVE INFO INTO SESSION
                Session["DeliveryOption"] = sShippingType;
                Session["DeliveryCost"] = dShippingCost;

                // REDIRECT
                Response.Redirect("~/Purchase/DeliveryDetails");
            }
            
        }
    }
}