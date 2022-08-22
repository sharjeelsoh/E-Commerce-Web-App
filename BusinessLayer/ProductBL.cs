using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheVintageStore.DataAccessLayer.Models;
using TheVintageStore.DataAccessLayer;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.BusinessLayer
{
    public class ProductBL
    {
        // METHOD: getProductsByCategory()
        // PURPOSE: Returns a list of Products in a specific Category (by providing category ID)
        // that in the database by calling a function down at DAL class
        public List<Product> getProductsByCategory(int iCategoryID)
        {
            List<Product> lisProduct = new List<Product>();
            ProductDAL methodSource = new ProductDAL();
            lisProduct = methodSource.getProductsByCategory(iCategoryID);
            return lisProduct;
        }

        // METHOD: getProductDetails()
        // PURPOSE: Returns an instance of Product class, with all the deatils required for 
        // displaying the product, by calling a function down from DAL class
        public Product getProductDetails(int iProductCode)
        {
            ProductDAL methodSource = new ProductDAL();
            Product product = methodSource.getProductDetails(iProductCode);
            return product;
        }
    }
}