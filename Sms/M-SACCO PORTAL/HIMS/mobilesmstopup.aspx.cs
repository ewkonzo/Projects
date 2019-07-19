using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

namespace HIMS
{
    public partial class mobilesmstopup : System.Web.UI.Page 
    {
        //protected admindesk.GRIDVIEWCLASSES.FullGridPager fullGridPager;
        //protected int MaxVisible = 20;

        private long _staffID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //_staffID = admindesk.Authentication.CurrentUserStaffID;

                if (!IsPostBack)
                {
                    MaintainScrollPositionOnPostBack = true;
                    // this.lblError.Text = "";
                    this.LoadMaps();
                //    //'=== FullGridPager module ============================
                //    fullGridPager = new admindesk.GRIDVIEWCLASSES.FullGridPager(gvTopup, MaxVisible, "Page", "of");
                //    fullGridPager.CreateCustomPager(gvTopup.BottomPagerRow);
                //    fullGridPager.PageGroups(gvTopup.BottomPagerRow);
                //}
                //else
                //{
                //    fullGridPager = new admindesk.GRIDVIEWCLASSES.FullGridPager(gvTopup, MaxVisible, "Page", "of");
                //    fullGridPager.CreateCustomPager(gvTopup.BottomPagerRow);
                //    gvTopup.PageIndexChanging += new GridViewPageEventHandler(gvTopup_PageIndexChanging);
                }
                //SiteFunctions.CurrentActiveFunction = "mobilesmstopup";
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadMaps()
        {
            try
            {
                DataTable dtMap = new admindesk.FUNCTIONCLASSES.mobileSmsTopup().GetTablemobileSmsTopup(string.Empty);
                
                //Persist the table in the Session object.
                Session["dtMapTable"] = dtMap;

                //Bind the GridView control to the data source.
                this.gvTopup.EmptyDataText = "No Records";
                this.gvTopup.DataSource = Session["dtMapTable"];// dtMap;
                this.gvTopup.DataBind();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        protected void gvTopup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvTopup.PageIndex = e.NewPageIndex;
                LoadMaps();

                ////'=== FullGridPager module ============================
                //if (fullGridPager == null)
                //{
                //    fullGridPager = new admindesk.GRIDVIEWCLASSES.FullGridPager(gvTopup, MaxVisible, "Page", "of");
                //}
                //fullGridPager.CreateCustomPager(gvTopup.BottomPagerRow);
                //fullGridPager.PageGroups(gvTopup.BottomPagerRow);
            }
            catch(Exception ex)
            {
            }
        }
        protected void gvTopup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvTopup.SelectedIndex < 0)
            {
                return;
            }

            GridViewRow grw = gvTopup.SelectedRow;
            if (grw == null)
                return;

            string url =string.Format( "~/mobilesmstopupitem.aspx?idx={0}",gvTopup.DataKeys[gvTopup.SelectedRow.RowIndex].Values["ID"].ToString());
            Response.Redirect(url, true);
            
        }
        protected void gvTopup_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["dtMapTable"] as DataTable;

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvTopup.DataSource = Session["dtMapTable"];
                gvTopup.DataBind();
            }
        }

        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void gvTopup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                e.Cancel = true;

                GridViewRow gvr = this.gvTopup.Rows[e.RowIndex];
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        protected void btnNewMap_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/mobilesmstopupitem.aspx", true);
        }

        protected void gvTopup_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void gvTopup_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvTopup_DataBound(object sender, EventArgs e)
        {
        }

        protected void ddlPageGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (fullGridPager == null)
            //{
            //    fullGridPager = new  admindesk.GRIDVIEWCLASSES.FullGridPager(gvTopup, MaxVisible, "Page", "of");
            //}
            //fullGridPager.PageGroupChanged(gvTopup.BottomPagerRow);
            //LoadMaps();
        }


    }
}