using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheVintageStore.DataAccessLayer;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.BusinessLayer
{
    public class OrderItemBL
    {
        // METHOD: insertOrderItemDetails()
        // PURPOSE: Inserts orderItem details (Each product in order) in the database by calling
        // DAL class, saves information like productcode, ordernumber, and each product quantity
        public int insertOrderItemDetails(int iProductCode, int iOrderNo, int iProductQuantity)
        {
            OrderItemDAL methodSource = new OrderItemDAL();
            int iRows = methodSource.insertOrderItemDetails(iProductCode, iOrderNo, iProductQuantity);
            return iRows;
        }
    }
}