using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer.Models
{
    public class Shipping
    {
        // CLASS LEVEL VARIABLES AND THEIR PROPERTIES 

        public int iShippingID { get; set; }                    // PRIMARY KEY (Shipping ID)
        public int iCustomerID { get; set; }                    // FOREIGN KEY (Customer ID)
        public string sShippingType { get; set; }               // Shipping Type (Standard or Express)
        public double dFee { get; set; }                        // Shipping Fee 
        public DateTime dtExpectedDeliveryDate { get; set; }    // Expected Delivery Date
    }
}