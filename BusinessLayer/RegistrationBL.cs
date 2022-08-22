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
    public class RegistrationBL
    {
        // METHOD: registerCustomer
        // PURPOSE: Creates (registers) a customer in the database by calling a function down from DAL class
        // by providing Customers information like email, first name, last name, password, ph number, status (active/inactive),
        // address 1, address 2, suburb, state, postcode
        // Checks if successful, if so, returns true, if not, return false
        public bool registerCustomer(string sFName, string sLName, string sEmail, string sPassword, string sPhoneNumber, int iStatus, 
            string sAddress1, string sAddress2, string sSuburb, string sState, int iPostCode)
        {
            bool bStatus;
            RegistrationDAL methodSource = new RegistrationDAL();
            
            // Register Customer
            int iRowsAffectedCustomer = methodSource.registerCustomer(sFName, sLName, sEmail, sPassword, sPhoneNumber, iStatus);
            
            // Insert the address of the customer
            int iRowsAffectedAddress = methodSource.insertCustomerAddress(sEmail, sAddress1, sAddress2,
               sSuburb, sState, iPostCode);
            
            // If both inserted successfully, returns true
            if ((iRowsAffectedCustomer > 0) && (iRowsAffectedAddress > 0))
            {
                bStatus = true;
            }
            
            // If one of them failed, or both, returns false
            else bStatus = false;
            
            return bStatus;
        }
    }
}