using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheVintageStore.DataAccessLayer;
using TheVintageStore.DataAccessLayer.Models;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.BusinessLayer
{
    public class CustomerBL
    {
        // METHOD: getCustomerDetails()
        // PURPOSE: Returns an instance of Customer class, filled with Customer details 
        // By calling a function from DAL providing an Email (FK)
        public Customer getCustomerDetails (string sEmail)
        {
            // Call the layer down, DAL, and uses the method to Get Customer Details
            CustomerDAL methodSource = new CustomerDAL();
            Customer customer = methodSource.getCustomerDetails(sEmail);
            return customer;
        }

        // METHOD: getCustomerAddress()
        // PURPOSE: Returns an instance of Address class, filled with Customer's Address details
        // by calling a function from DAL providing the Customer's ID (FK)
        public Address getCustomerAddress (int iCustomerID)
        {
            CustomerDAL methodSource = new CustomerDAL();
            Address address = methodSource.getCustomerAddress(iCustomerID);
            return address;
        }

        // METHOD: updateCustomerDetails()
        // PURPOSE: Updates the Customer personal details (User profile) based on 
        // providing the inputs, all the fields, and by calls a function from DAL to update in Database
        public int updateCustomerDetails(string sEmail, string sPhNumber, string sAddress1,
            string sAddress2, string sSuburb, string sState, int iPostCode)
        {
            CustomerDAL methodSource = new CustomerDAL();
            int iRows = methodSource.updateCustomerDetails(sEmail, sPhNumber, sAddress1, sAddress2, sSuburb, sState, iPostCode); 
            return iRows;
            
        }

        // METHOD: updateCustomerPassword()
        // PURPOSE: Updates the Customer password, when they try to reset them using a page, 
        // Calls down a function in DAL and updates their new password based on their email
        public int updateCustomerPassword(string sEmail, string sPassword)
        {
            CustomerDAL methodSource = new CustomerDAL();
            int iRows = methodSource.updateCustomerPassword(sEmail, sPassword);
            return iRows;
        }
    }
}