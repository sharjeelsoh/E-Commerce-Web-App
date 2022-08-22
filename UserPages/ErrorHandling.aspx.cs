﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.UserLayer.UserPages
{
    public partial class ErrorHandling1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // METHOD: EVENT HANDLER BTN HOME
        protected void btnHome_Click(object sender, EventArgs e)
        {
            // REDIRECT TO HOME 
            Response.Redirect("~/HomePage");
        }
    }
}