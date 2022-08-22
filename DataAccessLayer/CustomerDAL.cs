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
    public class CustomerDAL
    {
        // Retrieve the Connection String from Web.Config
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TheVintageStoreConnectionString"].ConnectionString;
            }
        }

        // METHOD: getCustomerAddress()
        // PURPOSE: Returns an instance of Address Class of the Customer (based on Customer ID)
        public Address getCustomerAddress(int iCustomerID)
        {
            // Select Statement
            string selectAddress = @"SELECT * FROM tblAddress " +
                                    "WHERE CustomerID = @ID";

            // Using the connection that was made at the top 
            using (SqlConnection conection = new SqlConnection(ConnectionString))
            {
                // Using the command by Select statement and connection 
                using (SqlCommand command = new SqlCommand(selectAddress, conection))
                {
                    // Give values to the parameters
                    command.Parameters.AddWithValue("@ID", iCustomerID);
                    try
                    {
                        // Connection opens here 
                        conection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        Address address = new Address();
                        
                        // If reader returns any rows 
                        if (reader.HasRows)
                        {
                            // Copy the instance coming from getAddress() function using reader
                            while (reader.Read())
                            {
                                address = getAddress(reader);
                            }
                        }
                        
                        // Return the instance
                        return address;
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        // Connection closes here
                        conection.Close();
                    }
                }
            }
        }

        // METHOD: getCustomerDetails()
        // PURPOSE: Returns an instance of the Customer Class with all their details from the Database
        // Based on their email address 
        public Customer getCustomerDetails(string sEmail)
        {
            // Select Statement
            string selectCustomer = @"SELECT * FROM tblCustomer " +
                                    "WHERE Email = @Email";

            // Using the connection that was made at the top 
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Using the command by Select statement and connection 
                using (SqlCommand command = new SqlCommand(selectCustomer, connection))
                {
                    // Give values to the parameters
                    command.Parameters.AddWithValue("@Email", sEmail);
                    try
                    {
                        // Connection opens here 
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        Customer customer = new Customer();
                        
                        // If readers reads and return rows 
                        if (reader.HasRows)
                        {
                            // Copy the instance made in getCustomer() function using the reader
                            while (reader.Read())
                            {
                                customer = getCustomer(reader);
                            }
                        }

                        // Return the instance
                        return customer;
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

        // METHOD: getCustomer()
        // PURPOSE: Returns an instance of Customer class and set all the attributes
        // using SQL data reader
        private Models.Customer getCustomer(SqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.iCustomerID = Convert.ToInt32(reader["CustomerID"]);
            customer.sEmail = reader["Email"].ToString();
            customer.sPassword = reader["Password"].ToString();
            customer.sFirstName = reader["FirstName"].ToString();
            customer.sLastName = reader["LastName"].ToString();
            customer.sPhoneNumber = reader["PhoneNumber"].ToString();
            customer.iStatus = Convert.ToInt32(reader["Status"]);

            return customer;
        }

        // METHOD: getAddress()
        // PURPOSE: Returns an instance of Address class and set all the attributes
        // using SQL data reader
        private Models.Address getAddress(SqlDataReader reader)
        {
            Address address = new Address();
            address.iCustomerID = Convert.ToInt32(reader["CustomerID"]);
            address.sAddress1 = reader["Address1"].ToString();
            address.sAddress2 = reader["Address2"].ToString();
            address.sSuburb = reader["Suburb"].ToString();
            address.sState = reader["State"].ToString();
            address.iPostCode = Convert.ToInt32(reader["PostCode"]);

            return address;
        }

        // METHOD: updateCustomerDetails()
        // PURPOSE: Updates the Customer details in the database based on the details 
        // providded as an input (Email, phone number, address 1, address 2, suburub, state, postcode)
        public int updateCustomerDetails(string sEmail, string sPhNumber, string sAddress1,
            string sAddress2, string sSuburb, string sState, int iPostCode)
        {
            // Get the customer ID from the Function above, using their email
            Customer customer = getCustomerDetails(sEmail);
            int iCustomerID = customer.iCustomerID;
            
            // Join Update statement using one transaction 
            string updateStatement =
                "BEGIN TRANSACTION; " +
                "UPDATE tblCustomer SET " +
                "PhoneNumber = @phNumber " +
                "WHERE Email = @email; " +
                "UPDATE tblAddress SET " +
                "Address1 = @address1, Address2 = @address2, Suburb = @suburb, State = @state, PostCode = @postcode " +
                "WHERE CustomerID = @customerID;" +
                "COMMIT;";

            // Using the connection that was made at the top 
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Using the command by Update statement and connection 
                using (SqlCommand command = new SqlCommand(updateStatement, connection))
                {
                    // Give values to the parameters
                    // Customer Table
                    command.Parameters.AddWithValue("@phNumber", sPhNumber);
                    command.Parameters.AddWithValue("@email", sEmail);

                    // Address Table
                    command.Parameters.AddWithValue("@address1", sAddress1);
                    command.Parameters.AddWithValue("@address2", sAddress2);
                    command.Parameters.AddWithValue("@suburb", sSuburb);
                    command.Parameters.AddWithValue("@state", sState);
                    command.Parameters.AddWithValue("@postcode", iPostCode);
                    command.Parameters.AddWithValue("@customerID", iCustomerID);

                    try
                    {
                        // Connection opens here
                        // Execute the query and return the no. of rows affected 
                        connection.Open();
                        int iRows = command.ExecuteNonQuery();
                        
                        // Return no. of rows 
                        return iRows;
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

        // METHOD: updateCustomerPassword()
        // PURPOSE: Updates the Customer password in the database, based on the email and Password provided
        // and returns a no. of rows affected
        public int updateCustomerPassword(string sEmail, string sPassword)
        {
            // Update Statement 
            string updateStatement = "UPDATE tblCustomer SET Password = @password WHERE Email = @email";

            // Using the connection that was made at the top 
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Using the command by Update statement and connection 
                using (SqlCommand command = new SqlCommand(updateStatement, connection))
                {
                    // Give values to the parameters
                    command.Parameters.AddWithValue("@password", sPassword);
                    command.Parameters.AddWithValue("@email", sEmail);

                    try
                    {
                        // Connection opens here, Execute query and return the no. of rows
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                    catch
                    {
                        // If something happens, Redirect to error page
                        return -1;
                    }
                    finally
                    {
                        // Close the connection
                        connection.Close();
                    }
                }
            }
        }
    }
}