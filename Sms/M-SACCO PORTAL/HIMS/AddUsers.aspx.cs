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
    public partial class AddUsers : System.Web.UI.Page
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

            string corporateno = "", username = "", password = "", confirmpswd = "", firstname = "", lastname = "";

            corporateno = corporateDDL.SelectedItem.Value;
            username = txtUsername.Text;
            password = txtPassword.Text;
            confirmpswd = txtConfirmPassword.Text;
            firstname = txtFirstName.Text;
            lastname = txtLastName.Text;

            if (checkExistingUser(username,corporateno))
            {
                Message("Username already exists for that Sacco");
            }
            else if (confirmpswd != password)
            {
                Message("Password Mismatch");

            }
            else
            {
                using (SqlConnection con = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Sacco].[dbo].[MSacco Portal Users]([Corporate No],[Username],[Password],[User Type],[Firstname]" +
                    ",[Lastname])VALUES (@corporate,@username,@password,@user,@firstname,@lastname )", con);

                    cmd.Parameters.AddWithValue("@corporate", corporateno);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@user", "User");
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd.ExecuteReader();

                    Message("User Created Succesfully");

                    string CurrentPage = "";
                    CurrentPage = "Users.aspx?action=Users&Show=False";
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

        public bool checkExistingUser(string username, string corporateNo)
        {
            bool exists = false;

            using (SqlConnection con = new SqlConnection(CommonUtilities.ConnectionString))
            {
                con.Open();
                SqlDataReader dr2 = null;
                string SQL = "SELECT * FROM [Sacco].[dbo].[MSacco Portal Users] where [Username] = @user and [Corporate No] = @corp";               
                SqlCommand cmd23 = new SqlCommand(SQL, con);
                cmd23.Parameters.AddWithValue("@user", username);
                cmd23.Parameters.AddWithValue("@corp", corporateNo);
                dr2 = cmd23.ExecuteReader();

                if (dr2.HasRows == true)
                {
                    exists = true;
                }
                con.Close();
            }

            return exists;
        }
    }
}