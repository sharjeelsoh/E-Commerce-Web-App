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

namespace TheVintageStore.UserLayer.Pages
{
    public partial class Help : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // DISPLAY THE MORE DESCRIPTION AS SOON AS THE PAGE LOADS INTO TEXTBOXES
            try
            {
                MoreSettingsBL methodSource = new MoreSettingsBL();
                Settings moreSettings = methodSource.getMoreSettings();
                txtbxExchange.Text = moreSettings.sExchangeSettings;
                txtxbxReturn.Text = moreSettings.sReturnSettings;
                txtbxPayment.Text = moreSettings.sPaymentSettings;
                txtbxShipping.Text = moreSettings.sShippingSettings;
            }
            catch
            {
                throw;
            }
        }

        // METHOD: EVENT HANDLER BTN SEND
        protected void btnSend_Click(object sender, EventArgs e)
        {
            // SEND THE INQUIRY TO THE COMPANY 
            // Using SendEmail class
            SendEmail email = new SendEmail();
            try
            {
                email.sFromName = txtbxFullName.Text;
                email.sFromAddress = txtbxEmail.Text;
                email.sSubject = DropDownCategory.SelectedValue;
                email.sBody = txtbxMessage.Text;
                email.sToAddress = "thevintagestoreshop@gmail.com";
                email.SendAnEmail(1);

                // DISPLAY MESSAGE 
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Email Sent! A copy of your query has been sent to you via email.');", true);
            }
            catch
            {
                throw;
            }

        }
    }
}
