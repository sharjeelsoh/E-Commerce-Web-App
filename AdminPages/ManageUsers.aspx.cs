using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

// CRUD operations in GridView concept taken from:
// Reference: https://www.c-sharpcorner.com/uploadfile/15208c/how-to-insert-edit-update-and-delete-records-in-gridview-wit/
// However, completely understood and made changes to integrate in my application 

namespace TheVintageStore.UserLayer.AdminPages
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "Admin/ManageUserAccounts";
                Response.Redirect(url);
            }
            //    if (!this.IsPostBack)
            //    {
            //        //Using binded columns: Fill GridView with default hard - coded data
            //        DataTable dtUsers = new DataTable();
            //        dtUsers.Columns.Add("UserId");
            //        dtUsers.Columns.Add("Username");
            //        dtUsers.Columns.Add("Email");
            //        dtUsers.Columns.Add("Status");
            //        dtUsers.Rows.Add(610010, "Sharjeel Sohail", "sharjeelsohail@uon.edu.au", true);
            //        dtUsers.Rows.Add(610011, "Geoff Skinner", "geoff.skinner@uon.edu.au", false);
            //        dtUsers.Rows.Add(610012, "Patrick Wells", "patrickwells3@gmail.com", false);
            //        dtUsers.Rows.Add(610013, "Ken Adams", "kenadams@hotmail.com", true);
            //        ViewState["dtUsers"] = dtUsers;
            //        BindGrid();
            //    }
        }

        ////Method: BindGrid()
        //// Purpose: Binds data to the GridView / We recalls this whenever we make a change into the table
        //protected void BindGrid()
        //{
        //    GridManageUsers.DataSource = ViewState["dtUsers"] as DataTable;
        //    GridManageUsers.DataBind();
        //}

        ////Method: Event handler(GridManageUsers)
        //// Purpose: whenever the Edit button is selected on a row
        ////          Changes buttons and show textboxes and binds data
        //protected void GridManageUsers_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridManageUsers.EditIndex = e.NewEditIndex;
        //    BindGrid();
        //}

        ////Method: OnUpdate Event Handler(linkbutton Update)
        //// Purpose: when clicked, grabs the data from textboxes and updates them
        ////          into all columns in that row
        //protected void OnUpdate(object sender, EventArgs e)
        //{
        //    GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
        //    string sUsername = ((TextBox)row.Cells[1].Controls[0]).Text;
        //    string sEmail = ((TextBox)row.Cells[2].Controls[0]).Text;
        //    bool bStatus = ((CheckBox)row.Cells[3].Controls[0]).Checked;

        //    DataTable dtUsers = ViewState["dtUsers"] as DataTable;
        //    dtUsers.Rows[row.RowIndex]["Username"] = sUsername;
        //    dtUsers.Rows[row.RowIndex]["Email"] = sEmail;
        //    dtUsers.Rows[row.RowIndex]["Status"] = bStatus;
        //    ViewState["dtUsers"] = dtUsers;
        //    GridManageUsers.EditIndex = -1;
        //    BindGrid();
        //}

        ////Method: OnCancel Event Handler(Linkbutton Cancel)
        //// Purpose: when clicked, does not update anything into the columns
        ////          and cancels the edit request basically
        //protected void OnCancel(object sender, EventArgs e)
        //{
        //    GridManageUsers.EditIndex = -1;
        //    BindGrid();
        //}

        protected void View_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/UserPurchaseHistory");
        }
    }
}