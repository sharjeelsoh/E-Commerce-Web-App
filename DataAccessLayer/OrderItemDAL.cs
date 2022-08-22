using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer
{
    public class OrderItemDAL
    {
        // Retrieve the Connection String from Web.Config
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TheVintageStoreConnectionString"].ConnectionString;
            }
        }

        // METHOD: insertOrderItemDetails()
        // PURPOSE: Inserts into OrderItem table in the database with the details provided as input,
        // When a customer makes a purchase. Values provided like Product code, order no, and product quantity
        public int insertOrderItemDetails(int iProductCode, int iOrderNo, int iProductQuantity)
        {
            int iCase = 0;
            
            // Insert statement 
            string insertStatement = @"INSERT INTO tblOrderItem VALUES (" +
                "@productCode, @orderNo, @productQuantity )";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(insertStatement, connection))
                {
                    // Add values to the parameters
                    command.Parameters.AddWithValue("@productCode", iProductCode);
                    command.Parameters.AddWithValue("@orderNo", iOrderNo);
                    command.Parameters.AddWithValue("@productQuantity", iProductQuantity);

                    try
                    {
                        // Connection opens here 
                        connection.Open();
                        
                        // As we execute query, return value if executed 
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
    }
}