using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer.Models
{
    public class OrderItem
    {
        // CLASS LEVEL VARIABLES AND THEIR PROPERTIES 

        public int iOrderItemID { get; set; }       // PRIMARY KEY (Order Item ID)
        public int iProductCode { get; set; }       // FOREIGN KEY (Product Code)
        public int iOrderNo { get; set; }           // FOREIGN KEY (Order no.)
        public int iQuantity { get; set; }          // Quantity of item
    }
}