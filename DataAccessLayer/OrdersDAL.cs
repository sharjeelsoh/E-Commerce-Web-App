using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TheVintageStore.DataAccessLayer.Models;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer
{
    public class OrdersDAL
    {
        // Retrieve the Connection String from Web.Config
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TheVintageStoreConnectionString"].ConnectionString;
            }
        }

        // METHOD: insertOrderDetails()
        // PURPOSE: Inserts Order details in the Database whenever customer makes a purchase,
        // with the values provided like, CustomerID, ShippingID, TotalOrderPrice, and OrderDate
        public int insertOrderDetails(int iCustomerID, int iShippingID, double dTotalPrice, DateTime dtOrderDate)
        {
            int iCase = 0;
            
            // Insert statement 
            string insertStatement = @"INSERT INTO tblOrders VALUES (@CustomerID, @ShippingID, @Fee, @ExpectedDeliveryDate )";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(insertStatement, connection))
                {
                    // Add values to the parameters 
                    command.Parameters.AddWithValue("@CustomerID", iCustomerID);
                    command.Parameters.AddWithValue("@ShippingID", iShippingID);
                    command.Parameters.AddWithValue("@Fee", dTotalPrice);
                    command.Parameters.AddWithValue("@ExpectedDeliveryDate", dtOrderDate);

                    try
                    {
                        // Connection opens here 
                        connection.Open();
                        
                        // As we execute the query, return the value to 
                        iCase = command.ExecuteNonQuery();
                        return iCase;
                    }
                    catch
                    {
                        // If something happens, return -1, so we can handle it nicely 
                        iCase = -1;
                        return iCase;
                    }
                    finally
                    {
                        // Connection closes here
                        connection.Close();
                    }
                }
            }
        }

        // METHOD: getOrderDetails()
        // PURPOSE: Returns an instance of the Orders class with all its attrubutes reading from the database,
        // based on the input providied (Customer ID) 
        public Orders getOrderDetails(int iCustomerID)
        {
            // Select statement 
            string selectStatement = @"SELECT * FROM tblOrders " +
                                     "WHERE CustomerID = @customerID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    // Add values to the parameters
                    command.Parameters.AddWithValue("@customerID", iCustomerID);
                    try
                    {
                        // Connection opens here
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        Orders order = new Orders();
                        
                        // If returns a row
                        if (reader.HasRows)
                        {
                            // Copy the instance of Order from the getOrder() function with the reader
                            while (reader.Read())
                            {
                                order = getOrder(reader);
                            }
                        }

                        // Return the instance
                        return order
;
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        // Connection closes here
                        connection.Close();
                    }
                }
            }
        }

        // METHOD: getOrder()
        // PURPOSE: Returns an instance of Orders Class with the attributes read from the database
        // using the SQL data reader as in input 
        private Models.Orders getOrder(SqlDataReader reader)
        {
            Orders order = new Orders();
            order.iOrderNo = Convert.ToInt32(reader["OrderNo"]);
            order.iCustomerID = Convert.ToInt32(reader["CustomerID"]);
            order.iShippingID = Convert.ToInt32(reader["ShippingID"]);
            order.dTotalPrice = Convert.ToDouble(reader["TotalPrice"]);
            order.dtOrderDate = Convert.ToDateTime(reader["OrderDate"]);

            return order;
        }
    }
}