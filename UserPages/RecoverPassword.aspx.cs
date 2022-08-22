using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // CONNECTION HAS TO BE SECURED
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "RecoverPassword";
                Response.Redirect(url);
            }
        }

        // METHOD: EVENT HANDLER BTN CONTINUE 
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            // Check if the Email exist in the Database or not 
            FindEmailBL methodSource = new FindEmailBL();
            bool bFound = methodSource.findEmail(txtbxEmail.Text);
            
            // If email exist
            if (bFound)
            {
                // SEND A RANDOM CODE IN THE EMAIL (Provided in the textbox)
                if (btnContinue.Text == "Continue")
                {
                    lblMessage.Text = "";
                    lblMessage.Visible = false;
                    SendEmail email = new SendEmail();
                    
                    try
                    {
                        email.sFromName = "The Vintage Store"; // Website.Fullname
                        email.sFromAddress = "thevintagestoreau@gmail.com"; // Website.email
                        email.sSubject = "Request to change password"; // Predefined

                        // RANDOM CODE
                        Random iRand = new Random();
                        int iRandomCode = iRand.Next(150000, 250000);
                        // Save that random code in a Session to check later 
                        Session["Code"] = iRandomCode;

                        email.sBody = "You have requested to change your password" + " \r\n" + "Your 6-digit code is: " + iRandomCode + "\r\n" + "Please enter this code on the web and follow the process to change your password.";
                        email.sToAddress = txtbxEmail.Text; // Customer.email
                        email.SendAnEmail(2);
                        
                        // DISPLAY A MESSAGE 
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Your request to retrieve your password has been received correctly. You will shortly receive a mail with a 6-digit code to enter here in order to complete the process');", true);
                        txtbxCode.Visible = true;

                        btnContinue.Text = "Submit";
                    }
                    catch
                    {
                        throw;
                    }
                }

                // CHECK IF THE CODE MATCHES 
                else if (btnContinue.Text == "Submit")
                {
                    // If code matches, Show other fields 
                    if (txtbxCode.Text == Session["Code"].ToString())
                    {
                        PanelRetrieveInfo.Visible = false;
                        PanelSetPassword.Visible = true;
                        btnContinue.Text = "Save";
                    }

                    // If code different, alert!
                    else
                    {
                        lblMessage.Text = "Incorrect code, try again";
                    }
                }

                // UPDATE THE NEW CUSTOMER'S PASSWORD IN THE DATABASE
                else if (btnContinue.Text == "Save")
                {
                    CustomerBL methodSource2 = new CustomerBL();
                    // Call updateCustomerPassword() in the BL class, giving email and password to update in the database
                    int iRows = methodSource2.updateCustomerPassword(txtbxEmail.Text, txtbxPassword.Text);
                    
                    // IF SUCCESSFULLY ADDED
                    if (iRows > 0)
                    {
                        // Display message and redirect
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password successfully updated!');", true);
                        Response.Redirect("~/Login");
                    }

                    // SOME ERROR HAPPENED, Redirect them to error page
                    else Response.Redirect("~/ErrorHandling");
                }
            }

            // Email does not exist in the database
            else
            {
                lblMessage.Text = "Email not found, check email again!";
            }
        }
    }
}