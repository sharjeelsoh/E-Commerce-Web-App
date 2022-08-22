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
    public class OrdersBL
    {
        // METHOD: insertOrderDetails()
        // PURPOSE: Inserts Purchase details (order) into the database by calling DAL
        // Class and provides information like Customer ID, shipping ID, total order price, and
        // the date order was made
        public int insertOrderDetails(int iCustomerID, int iShippingID, double dTotalPrice, DateTime dtOrderDate)
        {
            OrdersDAL methodSource = new OrdersDAL();
            int iRows = methodSource.insertOrderDetails(iCustomerID, iShippingID, dTotalPrice, dtOrderDate);
            return iRows;
        }

        // METHOD: getOrderDetails()
        // PURPOSE: Reads the order details that was just saved above and returns that details
        // in an instance of Order class by calling a function down from DAL class
        public Orders getOrderDetails(int iCustomerID)
        {
            OrdersDAL methodSource = new OrdersDAL();
            Orders order = methodSource.getOrderDetails(iCustomerID);
            return order;
        }
    }
}