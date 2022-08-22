using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using TheVintageStore.BusinessLayer;
using TheVintageStore.DataAccessLayer.Models;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.UserLayer.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        #region PAGE LOAD 
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region BTN LOGIN (EVENT HANDLER)
        // METHOD: EVENT HANDLER BTN LOGIN
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // IF CUSTOMER SELECTED, CALL CustomerLogin()
            if (rdbtnCustomer.Checked) CustomerLogin();

            // IF ADMIN SELECTED, CALL AdminLogin()
            else if (rdbtnAdmin.Checked) AdminLogin();
        }
        #endregion

        #region BTN REGISTER (EVENT HANDLER)
        // METHOD: EVENT HANDLER btn Register
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // REDIRECT THEM TO REGISTRATION PAGE
            Response.Redirect("~/Register");
        }
        #endregion

        #region ADMIN LOGIN 
        // METHOD: AdminLogin()
        // PURPOSE: Logs into admin account
        protected void AdminLogin()
        {
            /* iCase
            *  if 3: Successful (Both Correct)
            *  if 2: Username does not exist
            *  if 1: Incorrect Password
            */
            int iCase;

            // Runs the the method in DAL and returns the Integer based on whichever case was successful
            LoginBL methodSource = new LoginBL();
            iCase = methodSource.CheckCredentials(txtbxEmail.Text, txtbxPassword.Text, "Admin");

            // Case 3: Successful (Both correct) Redirect them to Home & save Email into a Session 
            if (iCase == 3)
            {
                Session["AdminLogin"] = txtbxEmail.Text;
                Response.Redirect("~/Admin/HomePage");
            }
            // Case 2: User not found, display message  
            else if (iCase == 2) lblLoginMessage.Text = "(Username does not exist)";

            // Case 1: Incorrect password, display message
            else if (iCase == 1) lblLoginMessage.Text = "(Incorrect Password, try again)";
        }
        #endregion

        #region CUSTOMER LOGIN 
        // METHOD: CustomerLogin()
        // PURPOSE: Logs into Customer account
        protected void CustomerLogin()
        {
            /* iCase
            *  if 3: Successful (Both Correct)
            *  if 2: Username does not exist
            *  if 1: Incorrect Password
            */
            int iCase;

            // Runs the the method in DAL and returns the Integer based on whichever case was successful
            LoginBL methodSource = new LoginBL();
            iCase = methodSource.CheckCredentials(txtbxEmail.Text, txtbxPassword.Text, "Customer");

            // To change the View of MasterPage (User) - We need Customer's Name
            CustomerBL methodSource2 = new CustomerBL();
            Customer customer = methodSource2.getCustomerDetails(txtbxEmail.Text);
            Session["CustomerName"] = customer.sFirstName;

            // Case 3: Credentials are correct, Create a Session, Save details & Redirect
            if (iCase == 3)
            {
                // Maintain consistency if Logged in / Registered 
                Session["CustomerLogin"] = txtbxEmail.Text;

                // For login testing, we may guess that this user exists and 
                // So does all their personal information, so Hard coding all their info &
                // Display all these information in User Profile Area 

                if (Session["Cart"] != null) Response.Redirect("~/Purchase/ChooseDeliveryOption");
                else Response.Redirect("~/HomePage");
            }

            // Case 2: User not found, display message  
            else if (iCase == 2) lblLoginMessage.Text = "(Username does not exist)";

            // Case 1: Incorrect password, display message
            else if (iCase == 1) lblLoginMessage.Text = "(Incorrect Password, try again)";
        }
        #endregion
    }
}