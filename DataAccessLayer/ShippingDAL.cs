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
    public class ShippingDAL
    {
        // Retrieve the Connection String from Web.Config
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TheVintageStoreConnectionString"].ConnectionString;
            }
        }

        // METHOD: insertShippingDetails()
        // PURPOSE: Inserts the shipping details of the customer into the Database based on the values provided 
        public int insertShippingDetails(int iCustomerID, string sShippingType, double dFee, DateTime dtExpectedDeliveryDate)
        {
            int iCase = 0;
            
            // Insert statement
            string insertStatement = @"INSERT INTO tblShipping VALUES (@CustomerID, @ShippingType, @Fee, @ExpectedDeliveryDate )";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(insertStatement, connection))
                {
                    // Add values to the parameters 
                    command.Parameters.AddWithValue("@CustomerID", iCustomerID);
                    command.Parameters.AddWithValue("@ShippingType", sShippingType);
                    command.Parameters.AddWithValue("@Fee", dFee);
                    command.Parameters.AddWithValue("@ExpectedDeliveryDate", dtExpectedDeliveryDate);

                    try
                    {
                        // Connection opens here 
                        connection.Open();
                        
                        // Retuns if command executed 
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

        // METHOD: getShippingDetails()
        // PURPOSE: Returns an instance of Shipping class using the provided CustomerID
        public Shipping getShippingDetails(int iCustomerID)
        {
            // Select statement 
            string selectStatement = @"SELECT * FROM tblShipping " +
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
                        Shipping shipping = new Shipping();
                        
                        // If reader returns the rows
                        if(reader.HasRows)
                        {
                            // Copy the instance of the Shipping Class by calling thr getShipping() func
                            while(reader.Read())
                            {
                                shipping = getShipping(reader);
                            }
                        }

                        // return the instance
                        return shipping;
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        // close the connection
                        connection.Close();
                    }
                }
            }
        }

        // METHOD: getShipping()
        // PURPOSE: Returns an instance of Shipping class with attributes filled with the values 
        // read from the database using SQL data reader provided 
        private Models.Shipping getShipping(SqlDataReader reader)
        {
            Shipping shipping = new Shipping();
            shipping.iShippingID = Convert.ToInt32(reader["ShippingID"]);
            shipping.iCustomerID = Convert.ToInt32(reader["CustomerID"]);
            shipping.sShippingType = reader["ShippingType"].ToString();
            shipping.dFee = Convert.ToDouble(reader["Fee"]);
            shipping.dtExpectedDeliveryDate = Convert.ToDateTime(reader["ExpectedDeliveryDate"]);

            return shipping;
        }
    }
}