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
    public class ProductDAL
    {
        // Retrieve the Connection String from Web.Config
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TheVintageStoreConnectionString"].ConnectionString;
            }
        }

        // METHOD: getProductDetails()
        // PURPOSE: Returns an instance of the Product with all its details (One product) class based on the ProductCode provided 
        public Product getProductDetails(int iProductCode)
        {
            // Select statement 
            string selectStatement = @"SELECT * FROM tblProduct " +
                                     "WHERE ProductCode = @Code;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    // Add values to the parameters 
                    command.Parameters.AddWithValue("Code", iProductCode);
                    try
                    {
                        // Connection opens here
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        Product product = new Product();
                        reader.Read();

                        // If reader returns rows / executed 
                        if (reader.HasRows)
                        {
                            // Cope the instance coming from createProduct() function using the Reader
                            product = createProduct(reader);
                        }

                        // return the instance
                        return product;
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

        // METHOD: getProductsByCategory()
        // PURPOSE: Returns a list of instances of Product Class based on the Category (CategoryID)
        public List<Product> getProductsByCategory(int iCategoryID)
        {
            List<Product> lisProduct = new List<Product>();
            
            // Select statement
            string selectStatement = @"SELECT * FROM tblProduct " +
                                     "WHERE CategoryID = @id;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    // Add values to the parameters 
                    command.Parameters.AddWithValue("id", iCategoryID);
                    try
                    {
                        // Connection opens here
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        Product product = new Product();

                        // If reader return rows 
                        if (reader.HasRows)
                        {
                            // For every product in that category
                            while(reader.Read())
                            {
                                // Copy the instance from createProduct() function using the Reader
                                // And add that into the list 
                                product = createProduct(reader);
                                lisProduct.Add(product);
                            }
                        }

                        // Return the list 
                        return lisProduct;

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

        // METHOD: createProduct()
        // PURPOSE: Returns an instance of the Product Class and set attributes read from the SQL data reader
        private static Product createProduct(SqlDataReader reader)
        {
            Product product = new Product();
            product.iProductCode = Convert.ToInt32(reader["ProductCode"]);
            product.iCategoryID = Convert.ToInt32(reader["CategoryID"]);
            product.sTitle = reader["Title"].ToString();
            product.sDescription = reader["Description"].ToString();
            product.sColor = reader["Color"].ToString();
            product.sSize = reader["Size"].ToString();
            product.iTotalQuantity = Convert.ToInt32(reader["TotalQuantity"]);
            product.dPrice = Convert.ToDouble(reader["Price"]);
            product.iStatus = Convert.ToInt32(reader["Status"]);
            product.sImageURL = reader["ImageURL"].ToString();

            return product;
        }
    }
}