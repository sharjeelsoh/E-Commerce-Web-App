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
    public class FindEmailBL
    {
        // METHOD: findEmail()
        // PURPOSE: Checks if the email already exist in the Database, return boolean besed on the
        // result. Used when customer tries to reset or register
        public bool findEmail (string sEmail)
        {
            FindEmailDAL methodSource = new FindEmailDAL();
            bool bFound = methodSource.findEmail(sEmail);
            return (bFound);
        }
    }
}