using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer.Models
{
    public class Orders
    {
        // CLASS LEVEL VARIABLES AND THEIR PROPERTIES 

        public int iOrderNo { get; set; }           // PRIMARY KEY (Order no.)
        public int iCustomerID { get; set; }        // FOREIGN KEY (Customer ID)
        public int iShippingID { get; set; }        // FOREIGN KEY (Shipping ID)
        public double dTotalPrice { get; set; }     // Total Order price
        public DateTime dtOrderDate { get; set; }   // Date the order was made
    }
}