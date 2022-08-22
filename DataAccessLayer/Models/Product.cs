using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer.Models
{
    public class Product
    {
        // CLASS LEVEL VARIABLES AND THEIR PROPERTIES 

        public int iProductCode { get; set; }           // PRIMARY KEY (Product Code)
        public int iCategoryID { get; set; }            // Foreign key (Category ID)
        public string sTitle { get; set; }              // Product Title
        public string sDescription { get; set; }        // Product Description
        public string sColor { get; set; }              // Product Color
        public string sSize { get; set; }               // Product Size
        public int iTotalQuantity { get; set; }         // Product total Quantity in Stock
        public double dPrice { get; set; }              // Products price
        public int iStatus { get; set; }                // Status : Active(1) Inactive(0) 
        public string sImageURL { get; set; }           // Image Url
    }
}