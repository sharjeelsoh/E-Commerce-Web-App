using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheVintageStore.DataAccessLayer;
using TheVintageStore.DataAccessLayer.Models;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.BusinessLayer
{
    public class CategoryBL
    {
        // METHOD: getCategory()
        // PURPOSE: Returns a list of categories by calling a function from DAL
        public List<Category> getCategory()
        {
            List<Category> lisCategory = new List<Category>();
            CategoryDAL methodSource = new CategoryDAL();
            lisCategory = methodSource.getCategory();
            return lisCategory;
        }
    }
}