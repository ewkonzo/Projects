using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Global.HIMS;

namespace HIMS
{
    public partial class smstopupmobilenew : System.Web.UI.Page
    {

        public string CorporateNumber = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CorporateNo"] == null) || string.IsNullOrEmpty(Session["CorporateNo"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }

            populateDropdownList();
        }

        public void populateDropdownList()
        {
            using (SqlConnection con = new SqlConnection(CommonUtilities.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Select * from [Source Information]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                corporateDDL.DataTextField = "Sacco Name 1";
                corporateDDL.DataValueField = "Corporate No";

                corporateDDL.DataSource = dt;
                corporateDDL.DataBind();

            }
        }

        protected void save_Click(object sender, EventArgs e)
        {            
            string corporateno = "", smscount = "0", comments = "", userid = "";

            corporateno = corporateDDL.SelectedItem.Value;  
            comments = txtComments.Text.Trim();
            userid = Session["Username"].ToString().ToUpper();
            smscount = "0"+txtsmscount.Text.Trim().Replace (" ","").Replace ("#","").Replace (",","");

            int ismscount = 0;
            if (!Int32.TryParse(smscount, out ismscount))
            {
                Message("Invalid SMS count figure");
            }
            else if (ismscount < 1)
            {
                Message("Cannot topup zero or negative SMS count figure");
            }
            else
            {
                using (SqlConnection con = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    string sql = "INSERT INTO [Sacco].[dbo].[MSacco TopUp]([CorporateNo],[SmsCount],[Comments],[UserID])VALUES(@Sacco,@SmsCount,@Comments,@UserID)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Sacco", corporateno);
                    cmd.Parameters.AddWithValue("@SmsCount", ismscount.ToString());
                    cmd.Parameters.AddWithValue("@Comments", comments );
                    cmd.Parameters.AddWithValue("@UserID", userid);

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd.ExecuteReader();

                    Message("Mobile SMS topup Succesfully");

                    string CurrentPage = "";
                    CurrentPage = "smstopupmobile.aspx?action=mobilesmstopup&Show=False";
                    // Response.Redirect(CurrentPage);

                    Response.AddHeader("REFRESH", "2;URL=" + CurrentPage);
                }
            }           
        }

        protected void corporateddl_click(object sender, EventArgs e)
        {                    
                  
        }

        public void Message(string strMsg)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(strMsg);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

       
    }
}