using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Global.HIMS;

namespace HIMS
{
    public partial class Guest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            gvloans.DataSource = this.LoadLoans();
            Session["Loans"] = null;
            Session["Loans"] = this.LoadLoans(); 
            gvloans.DataBind();
        }


        protected void gvloans_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvloans.PageIndex = e.NewPageIndex;
            gvloans.DataSource = (DataTable)Session["loans"];
            gvloans.DataBind();
        }
                
        private DataTable LoadLoans()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select [Telephone No],[Transaction Date],[Loan type], [Amount],[Client Code],[Status],[SESSION_ID] " +
                    "from  [MSaccoSalaryAdvance] where   [Corporate No] = @corporateno order by [Transaction Date] desc";
                    command.Parameters.AddWithValue("@corporateno", Session["CorporateNo"].ToString());
                    command.Connection = connection;

                    //check connection state
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                   
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    connection.Close();
                }
            }
            catch
            {
            }
            return dt;

        }


        private DataTable LoadSearchedLoans(string tel)
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select TOP (50) [Telephone No],[Transaction Date],[Loan type], [Amount],[Client Code],[Status],[SESSION_ID] " +
                    "from  [MSaccoSalaryAdvance] where   [Corporate No] = @corporateno and [Telephone No] = @telephone order by [Transaction Date] desc";
                    command.Parameters.AddWithValue("@corporateno", Session["CorporateNo"].ToString());
                    command.Parameters.AddWithValue("@telephone", tel.ToString());
                    command.Connection = connection;

                    //check connection state
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    connection.Close();
                }
            }
            catch
            {
            }
            return dt;

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            
            var telephoneNo = txtNo.Text;

            if (telephoneNo.StartsWith("0"))
            {
                telephoneNo = "+254" + telephoneNo.Substring(telephoneNo.Length - 9);
            }
            
            gvloans.DataSource = null;
            Session["Loans"] = null;
            Session["Loans"] = LoadSearchedLoans(telephoneNo);
            gvloans.DataSource = LoadSearchedLoans(telephoneNo);
            gvloans.DataBind();
        }

        protected void gvloans_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvloans_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var dt = Session["Loans"] as DataTable;
            var session = dt.Rows[e.NewEditIndex].ItemArray[6];
            Response.Redirect("~/Loandetails.aspx?action=Loan&session=" + session, true);

        }

        protected void gvloans_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["dtLoansTable"] as DataTable;

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvloans.DataSource = Session["dtFeeTable"];
                gvloans.DataBind();
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

        protected void gvloans_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {               

            }                     
        }    
    }
}