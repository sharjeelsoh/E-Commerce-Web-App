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
    public class FindEmailDAL
    {
        // Retrieve the Connection String from Web.Config
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TheVintageStoreConnectionString"].ConnectionString;
            }
        }

        // METHOD: findEmail()
        // PURPOSE: Checks in the database if the email provided as an input in already in there
        // Returns a bool based on the result, if found return true, if not, return false
        public bool findEmail(string sEmail)
        {
            // Select Statement 
            string selectStatement = @"SELECT Email "
                                     + "FROM tblCustomer "
                                     + "WHERE Email = @sEmail";

            // Using connection made at the top 
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Using the command by Select statement and connection
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    // Add values to the parameters 
                    command.Parameters.AddWithValue("sEmail", sEmail);
                    try
                    {
                        // Connection opens here 
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        bool bFound = false;
                        
                        // If reader returns rows 
                        if (reader.HasRows)
                        {
                            // For each row, check if email exist, if found, set bFound to true 
                            while (reader.Read())
                            {
                                if (reader["Email"].ToString() == sEmail) bFound = true;
                            }
                        }

                        // return the bool value
                        return bFound;
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