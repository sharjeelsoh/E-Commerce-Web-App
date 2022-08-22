using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer.Models
{
    public class Category
    {
        // CLASS LEVEL VARIABLES AND THEIR PROPERTIES 

        public int iCategoryID { get; set; }        // PRIMARY KEY (Category ID)
        public string sTitle { get; set; }          // Title of the Category 
        public string sImageURL { get; set; }       // Image Url 
    }
}