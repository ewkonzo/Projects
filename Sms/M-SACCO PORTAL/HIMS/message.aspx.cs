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
    public partial class message : System.Web.UI.Page
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
            gvmessage.DataSource = this.LoadLoans();
            Session["Loans"] = null;
            Session["Loans"] = this.LoadLoans();
            gvmessage.DataBind();
        }


        protected void gvmessage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvmessage.PageIndex = e.NewPageIndex;
            gvmessage.DataSource = (DataTable)Session["loans"];
            gvmessage.DataBind();
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
                    command.CommandText = "Select [ToAddress],[Datetime],[Body],[Trace] " +
                    "from [Messages].[dbo].[Messages2] where [Corporate No] = @corporateno order by [Datetime] desc";
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
                    command.CommandText = "Select [ToAddress],[Datetime],[Body],[Trace] " +
                    "from [Messages].[dbo].[Messages2] where [Corporate No] = @corporateno and [ToAddress] Like @telephone order by [Datetime] desc ";
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

            gvmessage.DataSource = null;
            Session["Loans"] = null;
            Session["Loans"] = LoadSearchedLoans(telephoneNo);
            gvmessage.DataSource = LoadSearchedLoans(telephoneNo);
            gvmessage.DataBind();
        }

        protected void gvmessage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvmessage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var dt = Session["Loans"] as DataTable;
            var session = dt.Rows[e.NewEditIndex].ItemArray[6];    

        }

        protected void gvmessage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {               

            }                     
        }    
    }
}