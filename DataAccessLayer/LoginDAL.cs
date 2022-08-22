using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.DataAccessLayer
{
    [DataObject(true)]
    public class LoginDAL
    {
        // Retrieve the Connection String from Web.Config
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TheVintageStoreConnectionString"].ConnectionString;
            }
        }

        // METHOD: checkCredentials()
        // PURPOSE: Check if the customer/Admin exist in the database, if so, check if the password is correct 
        // Return value based on the result
        [DataObjectMethod(DataObjectMethodType.Select)]
        public int checkCredentials(string sEmail, string sPassword, string sUser)
        {
            // IF CUSTOMER IS LOGGING IN, USING THIS SELECT STATEMENT
            string customerSelectStatement = @"SELECT Email, Password "
                                     + "FROM tblCustomer "
                                     + "WHERE Email = @sEmail";

            // IF ADMIN IS LOGGING IN, USING THIS SELECT STATEMENT
            string adminSelectStatement = @"SELECT Email, Password "
                                     + "FROM tblAdminStaff "
                                     + "WHERE Email = @sEmail";

            string selectStatement = "";
            
            // Depends on the input, assigns the selectStatement to that user
            if (sUser == "Admin") selectStatement = adminSelectStatement;
            else if (sUser == "Customer") selectStatement = customerSelectStatement;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    // Add values to the parameters 
                    command.Parameters.AddWithValue("sEmail", sEmail);
                    try
                    {
                        // Connection opens here 
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        /* VARIABLES
                         * bCredentials: Successful (Both Correct)  Set iCase = 3
                         * bUsername   : Username does not exist    Set iCase = 2
                         * bPassword   : Incorrect Password         Set iCase = 1
                         */
                        int iCase = 0;
                        bool bEmail = false;
                        bool bPassword = false;

                        if (reader.HasRows)
                        {
                            // Set booleans to true if email and password both exists 
                            while (reader.Read())
                            {
                                if (reader["Email"].ToString() == sEmail) bEmail = true;
                                if (reader["Password"].ToString() == sPassword) bPassword = true;
                            }
                        }
                        
                        // If sucessfull 
                        if (bEmail && bPassword) iCase = 3;
                        
                        // If email not found
                        else if (!bEmail) iCase = 2;
                        
                        // If password is incorrect
                        else if (!bPassword) iCase = 1;

                        return (iCase);
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