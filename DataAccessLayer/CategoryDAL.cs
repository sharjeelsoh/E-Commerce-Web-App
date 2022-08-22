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
    public class CategoryDAL
    {
        // Retrieve the Connection String from Web.Config
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TheVintageStoreConnectionString"].ConnectionString;
            }
        }

        // METHOD: getCategory()
        // PURPOSE: Returns a List of categories (All those exist in Database)
        public List<Category> getCategory()
        {
            List<Category> lisCategory = new List<Category>();
            
            // Select Statement 
            string selectStatement = @"SELECT * FROM tblCategory;";
            
            // Using the connected made above
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Using the command with Select Statement and the connection made above
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    try
                    {
                        // Connection Opens here 
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        Category category = new Category();

                        // If returns rows
                        if (reader.HasRows)
                        {
                            // For each row until none found
                            while (reader.Read())
                            {
                                // Copy the instance by recalling the createCategory() function
                                // And add that instance into the List
                                category = createCategory(reader);
                                lisCategory.Add(category);
                            }
                        }
                        // Returns the list of all categories
                        return lisCategory;

                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        // Connection Closes here 
                        connection.Close();
                    }
                }
            }
        }

        // METHOD: createCategory()
        // PURPOSE: Returns an instance of Category class with all its
        // attributes set by the SQL data reader
        private static Category createCategory(SqlDataReader reader)
        {
            Category category = new Category();
            category.iCategoryID = Convert.ToInt32(reader["CategoryID"]);
            category.sTitle = reader["Title"].ToString();
            category.sImageURL = reader["ImageURL"].ToString();
            return category;
        }
    }
}