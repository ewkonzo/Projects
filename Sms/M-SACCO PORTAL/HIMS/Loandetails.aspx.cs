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
    public partial class loandetails : System.Web.UI.Page
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
            gvloans.DataSource = this.LoadGuarantors();
            gvloans.DataBind();
        }

        private DataTable LoadGuarantors()
        {

            var session = Request.QueryString["session"];
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select [Source],[Guarantor],[Loan type],[Status],[Remarks] " +
                    "from  [Guarantors] where [Session] = @session ";
                    command.Parameters.AddWithValue("@session", session.ToString());
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
    }
      
}