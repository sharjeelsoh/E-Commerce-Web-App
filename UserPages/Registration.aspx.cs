using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheVintageStore.BusinessLayer;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.UserLayer.UserPages
{
    public partial class Registration : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // METHOD: EVENT HANDLER BTN REGISTER
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            bool bPasswordMatch, bStatus;
            RegistrationBL methodSource = new RegistrationBL();
            
            // VERIFY BOTH; PASWWORD 1 AND PASSWORD 2 
            bPasswordMatch = verifyPassword(txtbxPassword.Text, txtbxPasswordVerify.Text);
            string sEmail, sFName, sLName, sPassword, sPhoneNumber, sAddress1, sAddress2, sSuburb, sState;
            int iPostCode, iStatus;
            
            try
            {
                // SAVE ALL TEXT FIELDS INTO VARIABLES
                sEmail = txtbxEmail.Text;
                sFName = txtbxFName.Text;
                sLName = txtbxLName.Text;
                sPassword = txtbxPassword.Text;
                sPhoneNumber = txtbxPhNumber.Text;
                iStatus = 1;    // Active (When you register)
                sAddress1 = txtbxAddress1.Text;
                sAddress2 = txtbxAddress2.Text;
                sSuburb = txtbxSuburb.Text;
                sState = DropDownState.SelectedValue;
                iPostCode = Convert.ToInt32(txtbxPostCode.Text);

                // IF PASSWORD MATCHES 
                if (bPasswordMatch)
                {
                    // REGISTER CUSTOMER BY USING registerCustomer() IN THE BL CLASS by giving all the fields as input
                    bStatus = methodSource.registerCustomer(sFName, sLName, sEmail, sPassword, sPhoneNumber, iStatus, sAddress1,
                        sAddress2, sSuburb, sState, iPostCode);

                    // if registered, redirect to the respected page based on Sessions 
                    if (bStatus)
                    {
                        Session["Register"] = sEmail;
                        Session["CustomerLogin"] = sEmail;
                        Session["CustomerName"] = sFName;
                        if (Session["Cart"] != null) Response.Redirect("~/Purchase/ChooseDeliveryOption");
                        else Response.Redirect("~/HomePage");
                    }

                    // If email already exists, Ask to login instead 
                    else
                    {
                        HyperLogin.Visible = true;
                    }
                }
            }
            catch
            {
                throw;
            }

        }

        // METHOD: verifyPassword()
        // PURPOSE: Verify two passwords, if they're the same and returns a bool based on it 
        private bool verifyPassword(string sPassword1, string sPassword2)
        {
            // PASSWORDS DO NOT MATCH
            if (sPassword1 != sPassword2)
            {
                lblMessage.Text = "Passwords do not match. Please enter both fields again.";
                txtbxPassword.Text = null;
                txtbxPasswordVerify.Text = null;
                txtbxPassword.BorderColor = System.Drawing.Color.Red;
                txtbxPasswordVerify.BorderColor = System.Drawing.Color.Red;
                return false;
            }

            // PASSWORD MATCH
            else
            {
                lblMessage.Text = "";
                txtbxPassword.BorderColor = System.Drawing.Color.Black;
                txtbxPasswordVerify.BorderColor = System.Drawing.Color.Black;
                return true;
            }
        }
    }
}