using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheVintageStore.DataAccessLayer;
using TheVintageStore.DataAccessLayer.Models;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.BusinessLayer
{
    public class ShippingBL
    {
        // METHOD: insertShippingDetails()
        // PURPOSE: Inserts shipping details of the the Customer such as Customer ID, shipping type (Standard or Express), 
        // Shipping charges, and Expected delivery date by calling down a DAL class function and returns the no. of rows if done
        public int insertShippingDetails(int iCustomerID, string sShippingType, double dFee, DateTime dtExpectedDeliveryDate)
        {
            ShippingDAL methodSource = new ShippingDAL();
            int iRows = methodSource.insertShippingDetails(iCustomerID,sShippingType, dFee, dtExpectedDeliveryDate);
            return iRows;
        }

        // METHOD: getShippingDetails()
        // PURPOSE: Returns the Shipping details of the customer, based on their ID, and 
        // returns an instance of Shipping class by calling down a function down from DAL class
        public Shipping getShippingDetails(int iCustomerID)
        {
            ShippingDAL methodSource = new ShippingDAL();
            Shipping shipping = methodSource.getShippingDetails(iCustomerID);
            return shipping;
        }
    }
}