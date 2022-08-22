using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheVintageStore.DataAccessLayer;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.BusinessLayer
{
    public class LoginBL
    {
        // METHOD: CheckCredentials()
        // PURPOSE: Checks customer's credentials when they tries to login by calling down a function
        // from DAL by providing Email, password, and user type (Admin or Customer)
        public int CheckCredentials(string sEmail, string sPassword, string sUser)
        {
            /* iCase
            *  if 3: Successful (Both Correct)
            *  if 2: Username does not exist
            *  if 1: Incorrect Password
            */
            int iCase;

            // Runs the the method in DAL and returns the Integer based on whichever case was successful
            LoginDAL methodSource = new LoginDAL();
            iCase = methodSource.checkCredentials(sEmail, sPassword, sUser);

            return (iCase);
        }
    }
}