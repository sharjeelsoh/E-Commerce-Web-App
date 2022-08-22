using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

// MAY NOT USE IT; BUSINESS RULE: SHOULDN'T BE SAVING CARD DETAILS OF ANY CUSTOMER 
// NOT EVEN IN THE SESSION, AS PAGE DISAPPEARS, CARD DETAILS GONE. ENTER AGAIN. I GUESS?
// WE'LL SEE LATER ON 

namespace TheVintageStore.DataAccessLayer.Models
{
    public class PaymentDetails
    {
        // CLASS LEVEL VARIABLES AND THEIR PROPERTIES 
        // NOT IN USE AT THIS POINT 

        public int iPayID { get; set; }                 // PRIMARY KEY (PaymentID)
        public int iCustomerID { get; set; }            // FOREIGN KEY (Customer ID)
        public int iCardNumber { get; set; }            // Card Number 
        public string sCardholderName { get; set; }     // Card holder's name 
        public DateTime dtExpiryDate { get; set; }      // Expiry Date
        public int iSecurityCode { get; set; }          // Security Code (CVV)
    }
}