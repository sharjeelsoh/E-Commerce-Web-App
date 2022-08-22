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
    public partial class UpdateProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "Admin/UpdateProducts";
                Response.Redirect(url);
            }

            if (!this.IsPostBack)
            {
                //        // Using binded columns: Fill GridView with default hard-coded data
                //        DataTable dtProducts = new DataTable();
                //        dtProducts.Columns.Add("ProductCode");
                //        dtProducts.Columns.Add("Title");
                //        dtProducts.Columns.Add("Description");
                //        dtProducts.Columns.Add("Quantity");
                //        dtProducts.Columns.Add("Price");
                //        dtProducts.Columns.Add("Status");
                //        dtProducts.Rows.Add(545, "Levi's Bomber Jacket", "Relaxed-fit Varsity Jacket with front and back patches", 10, 49.95, true);
                //        dtProducts.Rows.Add(546, "Textured Blue Shirt", "Relaxed-fit Collared Shirt featuring long sleeves with button-up front", 5, 29.95, false);
                //        ViewState["dtProducts"] = dtProducts;
                //        BindGrid();
            }
        }

        //// Method: BindGrid()
        //// Purpose: Binds data to the GridView / We recalls this whenever we make a change into the table
        //protected void BindGrid()
        //{
        //    GridUpdateProducts.DataSource = ViewState["dtProducts"] as DataTable;
        //    GridUpdateProducts.DataBind();
        //}

        //// Method: Event handler (GridUpdateProducts)
        //// Purpose: whenever the Edit button is selected on a row
        ////          Changes buttons and show textboxes and binds data 
        //protected void GridUpdateProducts_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridUpdateProducts.EditIndex = e.NewEditIndex;
        //    BindGrid();
        //}

        //// Method: OnUpdate Event Handler (linkbutton Update)
        //// Purpose: when clicked, grabs the data from textboxes and updates them 
        ////          into all columns in that row 
        //protected void OnUpdate(object sender, EventArgs e)
        //{
        //    GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
        //    string sTitle = ((TextBox)row.Cells[1].Controls[0]).Text;
        //    string sDescription = ((TextBox)row.Cells[2].Controls[0]).Text;
        //    int iQuantity = Convert.ToInt32(((TextBox)row.Cells[3].Controls[0]).Text);
        //    double dPrice = Convert.ToDouble(((TextBox)row.Cells[4].Controls[0]).Text);
        //    bool bStatus = ((CheckBox)row.Cells[5].Controls[0]).Checked;

        //    DataTable dtProducts = ViewState["dtProducts"] as DataTable;
        //    dtProducts.Rows[row.RowIndex]["Title"] = sTitle;
        //    dtProducts.Rows[row.RowIndex]["Description"] = sDescription;
        //    dtProducts.Rows[row.RowIndex]["Quantity"] = iQuantity;
        //    dtProducts.Rows[row.RowIndex]["Price"] = dPrice;
        //    dtProducts.Rows[row.RowIndex]["Status"] = bStatus;
        //    ViewState["dtProducts"] = dtProducts;
        //    GridUpdateProducts.EditIndex = -1;
        //    BindGrid();
        //}

        //// Method: OnCancel Event Handler (Linkbutton Cancel)
        //// Purpose: when clicked, does not update anything into the columns 
        ////          and cancels the edit request basically
        //protected void OnCancel(object sender, EventArgs e)
        //{
        //    GridUpdateProducts.EditIndex = -1;
        //    BindGrid();
        //}

        //// Method: btnAdd Event Handler (Add button)
        //// Purpose: when clicked, collects information from the fields 
        ////          and adds them into gridView 
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    // Product status management 
        //    bool bStatus = true;
        //    if (DropDownStatus.SelectedValue == "Activate") bStatus = true;
        //    else if (DropDownStatus.SelectedValue == "Suspend") bStatus = false;

        //    // Adds and binds data 
        //    DataTable dtProducts = ViewState["dtProducts"] as DataTable;
        //    dtProducts.Rows.Add(txtbxCode.Text, txtbxTitle.Text, txtbxDescription.Text, txtbxQuantity.Text, txtbxPrice.Text, bStatus);
        //    ViewState["dtProducts"] = dtProducts;
        //    BindGrid();

        //    // Empty textboxes
        //    txtbxCode.Text = string.Empty;
        //    txtbxTitle.Text = string.Empty;
        //    txtbxDescription.Text = string.Empty;
        //    txtbxQuantity.Text = string.Empty;
        //    txtbxPrice.Text = string.Empty;
        //}
    }
}