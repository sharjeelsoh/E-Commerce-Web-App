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
    public class MoreSettingsDAL
    {
        // Retrieve the Connection String from Web.Config
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TheVintageStoreConnectionString"].ConnectionString;
            }
        }

        // METHOD: getMoreSettings()
        // PURPOSE: Returns an instance of Settings Class filled with all the attributes from the Database 
        public Settings getMoreSettings()
        {
            // Select statement 
            string selectStatement = @"SELECT * FROM tblSettings";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    try
                    {
                        // Connection opens here
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        Settings moreSettings = new Settings();
                        reader.Read();
                        
                        // If reader returns rows
                        if (reader.HasRows)
                        {
                            // Set instance attributes from the attributes 
                            moreSettings.sExchangeSettings = reader["ExchangeSettings"].ToString();
                            moreSettings.sPaymentSettings = reader["PaymentSettings"].ToString();
                            moreSettings.sReturnSettings = reader["ReturnSettings"].ToString();
                            moreSettings.sShippingSettings = reader["ShippingSettings"].ToString();
                        }

                        // Return the instance
                        return moreSettings;
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