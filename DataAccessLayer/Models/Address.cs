using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer.Models
{
    public class Address
    {
        // CLASS LEVEL VARIABLES AND THEIR PROPERTIES 

        public int iAddressID { get; set; }         // PRIMARY KEY (Address ID) 
        public int iCustomerID { get; set; }        // FOREIGN KEY (Customer ID)
        public string sAddress1 { get; set; }       // Address Field 1
        public string sAddress2 { get; set; }       // Address Field 2
        public string sSuburb { get; set; }         // Suburb
        public string sState { get; set; }          // State
        public int iPostCode { get; set; }          // Post Code
    }
}