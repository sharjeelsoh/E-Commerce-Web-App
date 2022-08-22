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

namespace TheVintageStore.UserLayer.AdminPages
{
    public partial class AdminProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "Admin/Profile";
                Response.Redirect(url);
            }
        }

        protected void btnReturnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            txtbxFName.ReadOnly = true;
            txtbxLName.ReadOnly = true;
            txtbxCurrentPass.ReadOnly = true;
            txtbxPassword.ReadOnly = true;
            txtbxPasswordVerify.ReadOnly = true;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
  
            txtbxFName.ReadOnly = false;
            txtbxLName.ReadOnly = false;
            txtbxCurrentPass.ReadOnly = false;
            txtbxPassword.ReadOnly = false;
            txtbxPasswordVerify.ReadOnly = false;

        }
    }
}