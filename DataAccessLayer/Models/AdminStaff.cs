using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

// NOT IN USE AT THE MOMENT, AS WE HAVE ONLY 1 ADMIN
// AND NO BUSINESS RULE FOR SIGNING UP ANOTHER ADMIN

namespace TheVintageStore.DataAccessLayer.Models
{
    public class AdminStaff
    {
        // CLASS LEVEL VARIABLES AND THEIR PROPERTIES 

        public int iAdminID { get; set; }           // PRIMARY KEY (Admin ID)
        public string sEmail { get; set; }          // Email Address
        public string sPassword { get; set; }       // Password
        public string sFirstName { get; set; }      // First Name
        public string sLastName { get; set; }       // Last Name
    }
}