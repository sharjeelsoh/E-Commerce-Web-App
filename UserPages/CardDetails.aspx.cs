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
    public partial class CardDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // HAS TO BE SECURE
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "Purchase/CardDetails";
                Response.Redirect(url);
            }

            // DISPLAY DIVs BASED ON SESSION
            displayRespectedDiv();
            
            // POPULATE DROP DOWNS (EXPIRY)
            populateDropDown();
        }

        // METHOD: BTN_EVENTHANDLER
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (Session["PaymentMethod"].ToString() != "Paypal")
            {
                if (validateExpiry()) Response.Redirect("~/Purchase/Review");
            }
            else Response.Redirect("~/Purchase/Review");
        }

        // METHOD: populateDropDown()
        // PURPOSE: Populate the drop downs with expiry months and year based on current date
        protected void populateDropDown()
        {
            // POPULATE EXPIRY MONTH DROP DOWN
            for (int i = 1; i < 12 + 1; i++)
            {
                dropdownMonth.Items.Add(new ListItem(Convert.ToString(i)));
            }

            // POPULATE EXPIRY YEAR DROP DOWN
            DateTime dateToday = DateTime.Today;    // GET TODAY'S DATE
            int iYear = dateToday.Year;             // GET CURRENT YEAR
            for (int i = iYear; i <= iYear + 5; i++) // ADD ITEMS UP UNTIL 5 YEARS FROM NOW
            {
                dropdownYear.Items.Add(new ListItem(Convert.ToString(i)));
            }
        }

        // METHOD: displayRespectedDiv()
        // PURPOSE: Based on whatever option selected, Display the Div
        protected void displayRespectedDiv()
        {
            // IF MASTERCARD
            if (Session["PaymentMethod"].ToString() == "Mastercard")
            {
                divCards.Visible = true;
                divMasterCard.Visible = true;
            }

            // IF VISA
            else if (Session["PaymentMethod"].ToString() == "Visa")
            {
                divCards.Visible = true;
                divVisa.Visible = true;
            }

            // IF PAYPAL
            else
            {
                divPaypal.Visible = true;
            }
        }

        // METHOD: validateExpiry()
        // PURPOSE: Validate the  Expiry date entered by the User
        protected bool validateExpiry()
        {
            DateTime dateToday = DateTime.Today;    // GET TODAY'S DATE
            int iYear = dateToday.Year;             // Current year
            int iMonth = dateToday.Month;           // Current month
            bool bValid;

            // IF THIS YEAR BUT THE MONTH HAS PASSED BY
            if ((Convert.ToInt32(dropdownMonth.SelectedValue) < iMonth) && (Convert.ToInt32(dropdownYear.SelectedValue) == iYear))
            {
                lblExpiryMessage.Text = "(Looks like this card is expired, check expiry date again)";
                bValid = false;
            }

            // ELSE, VALIDATED
            else
            {
                lblExpiryMessage.Text = "";
                bValid = true;
            }
            return bValid;
        }
    }
}