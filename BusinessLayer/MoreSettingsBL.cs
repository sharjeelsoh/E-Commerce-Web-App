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
    public class MoreSettingsBL
    {
        // METHOD: getMoreSettings()
        // PURPOSE: Returns information saved in database by calling DAL class, 
        // Information like Payment, shipping, purchase, and return information
        public Settings getMoreSettings()
        {
            MoreSettingsDAL methodSource = new MoreSettingsDAL();
            Settings moreSettings = methodSource.getMoreSettings();
            return moreSettings;
        }
    }
}