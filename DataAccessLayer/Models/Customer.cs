using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer.Models
{
    public class Customer
    {
        // CLASS LEVEL VARIABLES AND THEIR PROPERTIES 

        public int iCustomerID { get; set; }            // PRIMARY KEY (Customer ID)
        public string sEmail { get; set; }              // Email address
        public string sPassword { get; set; }           // Password
        public string sFirstName { get; set; }          // First Name
        public string sLastName { get; set; }           // Last Name
        public string sPhoneNumber { get; set; }        // Phone Number
        public int iStatus { get; set; }                // Status: Active(1) Inactive(0) 
    }
}