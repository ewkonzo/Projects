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
    public partial class AirtimeTopup : System.Web.UI.Page
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
            gvairtime.DataSource = this.Loadairtime();
            Session["airtime"] = null;
            Session["airtime"] = this.Loadairtime();
            gvairtime.DataBind();
        }

        protected void gvairtime_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvairtime.PageIndex = e.NewPageIndex;
            gvairtime.DataSource = (DataTable)Session["airtime"];
            gvairtime.DataBind();
        }

        private DataTable Loadairtime()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select [TelephoneNo],[Date Created],[Sent To Journal],[Account No],[From MSISDN],[Amount],[Status],[Remarks] " +
                    "from [Sacco].[dbo].[MsaccoAirtimeTopup] where [Corporate No] = @corporateno order by [Date Created] desc";
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

        private DataTable LoadSearchedAirtime(string tel)
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select [TelephoneNo],[Date Created],[Sent To Journal],[Account No],[From MSISDN],[Amount],[Status],[Remarks] " +
                    "from [Sacco].[dbo].[MsaccoAirtimeTopup] where  [Corporate No] = @corporateno and [TelephoneNo] Like @telephone order by [Date Created] desc ";
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

            gvairtime.DataSource = null;
            Session["airtime"] = null;
            Session["airtime"] = LoadSearchedAirtime(telephoneNo);
            gvairtime.DataSource = LoadSearchedAirtime(telephoneNo);
            gvairtime.DataBind();
        }

        protected void gvairtime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        protected void gvairtime_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var dt = Session["airtime"] as DataTable;
            var session = dt.Rows[e.NewEditIndex].ItemArray[6];
        }


        protected void gvairtime_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }    
    }
}