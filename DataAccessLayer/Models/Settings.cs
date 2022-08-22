using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer.Models
{
    public class Settings
    {
        // CLASS LEVEL VARIABLES AND THEIR PROPERTIES 

        public string sExchangeSettings { get; set; }           // Exchange Information
        public string sReturnSettings { get; set; }             // Return Information
        public string sPaymentSettings { get; set; }            // Payment Information
        public string sShippingSettings { get; set; }           // Shipping Information
    }
}