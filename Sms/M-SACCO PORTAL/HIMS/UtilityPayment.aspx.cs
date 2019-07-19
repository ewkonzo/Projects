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
    public partial class UtilityPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Search_PhoneNo = "";
            if ((Session["CorporateNo"] == null) || string.IsNullOrEmpty(Session["CorporateNo"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindGrid();

                }
            }
        }

        private void BindGrid()
        {
            gvutility.DataSource = this.LoadUtilities();
            Session["utility"] = null;
            Session["utility"] = this.LoadUtilities();
            gvutility.DataBind();
        }

        protected void gvutility_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvutility.PageIndex = e.NewPageIndex;
            gvutility.DataSource = (DataTable)Session["utility"];
            gvutility.DataBind();
        }

        private DataTable LoadUtilities()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select [Telephone No],[Date Created],[Utility Payment Type],[Utility Payment Account],[Amount],[Status],[Remarks] " +
                    "from [Sacco].[dbo].[Msacco Utility Payment] where [Corporate No] = @corporateno order by [Date Created] desc";
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


        private DataTable LoadSearchedUtilities(string tel)
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select [Telephone No],[Date Created],[Utility Payment Type],[Utility Payment Account],[Amount],[Status],[Remarks] " +
                    "from [Sacco].[dbo].[Msacco Utility Payment] where [Corporate No] = @corporateno and [Telephone No] Like @telephone order by [Date Created] desc ";
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

            gvutility.DataSource = null;
            Session["utility"] = null;
            Session["utility"] = LoadSearchedUtilities(telephoneNo);
            gvutility.DataSource = LoadSearchedUtilities(telephoneNo);
            gvutility.DataBind();
        }


        protected void gvutility_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvutility_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var dt = Session["utility"] as DataTable;
            var session = dt.Rows[e.NewEditIndex].ItemArray[6];
        }

        protected void gvutility_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }    

    }
}