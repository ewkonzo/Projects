using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Global.HIMS;

namespace HIMS
{
    public partial class ChangePassword : System.Web.UI.Page
    {

        public string CorporateNumber = string.Empty;
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CorporateNo"] == null) || string.IsNullOrEmpty(Session["CorporateNo"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
        
        protected void save_Click(object sender, EventArgs e)
        {
            try
            {
                string oldpassword = txtCurrentPswd.Text;
                string newpassword = txtNewPswd.Text;
                string confirmationpswd = txtConfirmPswd.Text;

                if (!newpassword.Equals(confirmationpswd))
                {
                    Message("Password Mismatch!");
                }
                else if (!checkPassword(oldpassword))
                {
                    Message("Incorrect Current Password Entered");
                }
                else
                {
                    updatePassword(newpassword);
                    Message("Password updated succesfully");
                }
            }
            catch (Exception ex)
            {
                Message("An error occured");
            }
    
        }

        public bool checkPassword(string pswd)
        {
           bool exists = false;
           string UserName = Session["Username"].ToString();
           string corporateNo = Session["CorporateNo"].ToString();

           using (SqlConnection con = new SqlConnection( CommonUtilities.ConnectionString))
           {
               con.Open();
               SqlDataReader dr2 = null;
               string SQL = "SELECT * FROM [Sacco].[dbo].[MSacco Portal Users] where [Username] = @user and [Corporate No] = @corp and [Password] = @password";
               SqlCommand cmd23 = new SqlCommand(SQL, con);
               cmd23.Parameters.AddWithValue("@user", UserName);
               cmd23.Parameters.AddWithValue("@corp", corporateNo);
               cmd23.Parameters.AddWithValue("@password", pswd);
               dr2 = cmd23.ExecuteReader();

               if (dr2.HasRows == true)
               {
                   exists = true;
               }
               con.Close();
           }    
                        
           return exists;
        }

        public void updatePassword(string newPassword)
        {

            string UserName = Session["Username"].ToString();
            string corporateNo = Session["CorporateNo"].ToString();

            using (SqlConnection con = new SqlConnection(CommonUtilities.ConnectionString))
            {
                con.Open();
                SqlDataReader dr2 = null;
                string SQL = "Update [Sacco].[dbo].[MSacco Portal Users] set [Password] = @password where [Username] = @user and [Corporate No] = @corp";
                SqlCommand cmd23 = new SqlCommand(SQL, con);
                cmd23.Parameters.AddWithValue("@user", UserName);
                cmd23.Parameters.AddWithValue("@corp", corporateNo);
                cmd23.Parameters.AddWithValue("@password", newPassword);
                dr2 = cmd23.ExecuteReader();
                con.Close();
            }    
        
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