using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using TheVintageStore.DataAccessLayer.Models;
using System.Data.SqlClient;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer
{
    public class RegistrationDAL
    {
        // Retrieve the Connection String from Web.Config
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TheVintageStoreConnectionString"].ConnectionString;
            }
        }

        // METHOD: REGISTER CUSTOMER 
        // PURPOSE: ADD A NEW CUSTOMER RECORD INTO THE DATABASE 
        public int registerCustomer(string sFName, string sLName, string sEmail, string sPassword, string sPhoneNumber, int iStatus)
        {
            int iCase = 0;
            
            // Check if the email already exists
            FindEmailDAL methodSource = new FindEmailDAL();
            bool bEmailFound = methodSource.findEmail(sEmail);

            // If email does not exist already 
            if (!bEmailFound)
            {
                // INSERT STATEMENT 
                string InsertStatement = @"INSERT INTO tblCustomer VALUES " +
                    "(@Email, @Password, @FirstName, @LastName, @PhoneNumber, @Status) ";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(InsertStatement, connection))
                    {
                        // ADD VALUES 
                        command.Parameters.AddWithValue("@Email", sEmail);
                        command.Parameters.AddWithValue("@Password", sPassword);
                        command.Parameters.AddWithValue("@FirstName", sFName);
                        command.Parameters.AddWithValue("@LastName", sLName);
                        command.Parameters.AddWithValue("@PhoneNumber", sPhoneNumber);
                        command.Parameters.AddWithValue("@Status", iStatus);

                        try
                        {
                            // OPEN THE CONNECTION AND EXECUTE QUERY 
                            connection.Open();
                            iCase = command.ExecuteNonQuery();
                            return iCase;
                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            // CLOSE THE CONNECTION
                            connection.Close();
                        }
                    }
                }
            }
            else
            {
                return iCase;
            }
        }

        // METHOD: REGISTER CUSTOMER ADDRESS
        // PURPOSE: ADDS THE CUSTOMER'S ADDRESS
        public int insertCustomerAddress(string sEmail, string sAddress1, string sAddress2,
            string sSuburb, string sState, int iPostCode)
        {
            // Get the CustomerID by calling getCustomerID() function
            int iCustomerID = getCustomerID(sEmail);
            
            // INSERT STATEMENT 
            string insertStatement = "INSERT INTO tblAddress VALUES " +
            "(@CustomerID, @Address1, @Address2, @Suburb, @State, @PostCode)";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(insertStatement, connection))
                {
                    // ADD VALUES 
                    command.Parameters.AddWithValue("@CustomerID", iCustomerID);
                    command.Parameters.AddWithValue("@Address1", sAddress1);
                    command.Parameters.AddWithValue("@Address2", sAddress2);
                    command.Parameters.AddWithValue("@Suburb", sSuburb);
                    command.Parameters.AddWithValue("@State", sState);
                    command.Parameters.AddWithValue("@PostCode", iPostCode);

                    try
                    {
                        // OPEN THE CONNECTION AND EXECUTE QUERY
                        // RETURN NO. OF ROWS AFFECTED 
                        connection.Open();
                        int iRows = command.ExecuteNonQuery();
                        return iRows;
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        // CLOSE THE CONNECTION 
                        connection.Close();
                    }
                }
            }
        }

        // METHOD: GETS THE CUSTOMER ID 
        // PURPOSE: ADDS THE ADDRESS FOR THE NEWLY REGISTERED USER
        private int getCustomerID(string sEmail)
        {
            int iCustomerID = 0;
            
            // Insert statement 
            string InsertStatement = @"SELECT CustomerID FROM tblCustomer " +
                                      "WHERE Email = @email";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(InsertStatement, connection))
                {
                    // ADD VALUES
                    command.Parameters.AddWithValue("@email", sEmail);
                    try
                    {
                        // connection opens here
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        
                        // If reader returns the rows 
                        if (reader.HasRows)
                        {
                            // Get the customerID
                            iCustomerID = Convert.ToInt32(reader["CustomerID"]);
                        }

                        // Return the CustomerID
                        return iCustomerID;
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
    }
}