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

namespace TheVintageStore.UserLayer.AdminPages
{
    public partial class MoreSettings : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnUpdateExchange_Click(object sender, EventArgs e)
        {
            if (txtbxExchange.ReadOnly == true) txtbxExchange.ReadOnly = false;
            else txtbxExchange.ReadOnly = true;
        }

        protected void btnUpdateReturn_Click(object sender, EventArgs e)
        {
            if (txtxbxReturn.ReadOnly == true) txtxbxReturn.ReadOnly = false;
            else txtxbxReturn.ReadOnly = true;

        }

        protected void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            if (txtbxPayment.ReadOnly == true) txtbxPayment.ReadOnly = false;
            else txtbxPayment.ReadOnly = true;
        }

        protected void btnUpdateShipping_Click(object sender, EventArgs e)
        {
            if (txtbxShipping.ReadOnly == true) txtbxShipping.ReadOnly = false;
            else txtbxShipping.ReadOnly = true;
        }
    }
}