using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Global.HIMS;

using System.Configuration;
using System.IO;
using System.Data.OleDb;

namespace HIMS
{
    public partial class smsmsg : System.Web.UI.Page
    {

        public string CorporateNumber = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CorporateNo"] == null) || string.IsNullOrEmpty(Session["CorporateNo"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            else
            {
                CorporateNumber = Session["CorporateNo"].ToString();
            }
            
            //populateDropdownList();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblSMSMsgInfo.Text = "";
            GridView1.DataSource = "";
            GridView1.DataBind();

            //if (txtMsg.Text.Trim() == "")
            //{
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //    lblMsg.Text = "Cannot send zero length message, please specify message"; 
            //    return;
            //}

            //Get path from web.config file to upload
            string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            string filename = string.Empty;
            //To check whether file is selected or not to uplaod
            if (FileUploadToServer.HasFile)
            {
                try
                {
                    string[] allowdFile = { ".xls", ".xlsx" };
                    //Here we are allowing only excel file so verifying selected file pdf or not
                    string FileExt = System.IO.Path.GetExtension(FileUploadToServer.PostedFile.FileName);

                    //Check whether selected file is valid extension or not
                    //bool isValidFile = allowdFile.Contains(FileExt);
                    //if (!isValidFile)
                    if (!((FileExt == ".xls") || (FileExt == ".xlsx")))
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Please upload only Excel";
                    }
                    else
                    {
                        // Get size of uploaded file, here restricting size of file
                        int FileSize = FileUploadToServer.PostedFile.ContentLength;
                        if (FileSize <= 1048576)//1048576 byte = 1MB
                        {
                            //Get file name of selected file
                            filename = Path.GetFileName(Server.MapPath(FileUploadToServer.FileName));

                            //Save selected file into server location
                            FileUploadToServer.SaveAs(Server.MapPath(FilePath) + filename);
                            //Get file path
                            string filePath = Server.MapPath(FilePath) + filename;
                            //Open the connection with excel file based on excel version
                            OleDbConnection con = null;
                            if (FileExt == ".xls")
                            {
                                con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0;");

                            }
                            else if (FileExt == ".xlsx")
                            {
                                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;");
                            }
                            con.Open();
                            //Get the list of sheet available in excel sheet
                            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            //Get first sheet name
                            string getExcelSheetName = dt.Rows[0]["Table_Name"].ToString();
                            //Select rows from first sheet in excel sheet and fill into dataset
                            OleDbCommand ExcelCommand = new OleDbCommand(@"SELECT * FROM [" + getExcelSheetName + @"]", con);
                            OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
                            DataSet ExcelDataSet = new DataSet();
                            ExcelAdapter.Fill(ExcelDataSet);
                            con.Close();

                            //lblSMSMsg.Text = txtMsg.Text.Trim();
                            lblSMSMsgInfo.Text = "Recipients Count:" + ExcelDataSet.Tables[0].Rows.Count.ToString();

                            //Bind the dataset into gridview to display excel contents
                            GridView1.DataSource = ExcelDataSet;
                            GridView1.DataBind();
                        }
                        else
                        {
                            lblMsg.Text = "Attachment file size should not be greater then 1 MB!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Error occurred while uploading a file: " + ex.Message;
                }
            }
            else
            {
                lblMsg.Text = "Please select a file to upload.";
            }
        }
    
        protected void save_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                if (txtMsg.Text.Trim() == "")
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Cannot send zero length message, please specify message";
                    return;
                }

                msg = txtMsg.Text.Trim();

                foreach (GridViewRow grw in GridView1.Rows)
                {
                    string pnum = grw.Cells[0].Text;
                    pnum = pnum.Replace(" ", "").Replace("-", "").Replace(".", "").Replace("+", "");

                    if (pnum.Length < 9) continue;

                    long lpnum = 0;
                    if (!long.TryParse(pnum, out lpnum)) continue;

                    string pnumf = "+254" + pnum.Substring(pnum.Length - 9).Trim();
                    string s = pnumf.Substring(0,5);
                    if (s != "+2547") continue;

                    bool b = CommonUtilities.sendSms_(pnumf, msg, CorporateNumber, "BULKSMS");
                    
                }                
                Message("Bulk SMS operation complete");
                Response.Redirect("smsmsg.aspx");
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                Message("A problem occured during operation, please contact your administrator");
            }

            //string corporateno = "", username = "", password = "", confirmpswd = "", firstname = "", lastname = "";
            //corporateno = corporateDDL.SelectedValue.ToString();
            //username = txtUsername.Text;
            //password = txtPassword.Text;
            //confirmpswd = txtConfirmPassword.Text;
            //firstname = txtFirstName.Text;
            //lastname = txtLastName.Text;
            //if (checkExistingUser(username,corporateno))
            //{
            //    Message("Username already exists for that Sacco");
            //}
            //else if (confirmpswd != password)
            //{
            //    Message("Password Mismatch");
            //}
            //else
            //{
            //    using (SqlConnection con = new SqlConnection(CommonUtilities.ConnectionString))
            //    {
            //        SqlCommand cmd = new SqlCommand("INSERT INTO [Sacco].[dbo].[MSacco Portal Users]([Corporate No],[Username],[Password],[User Type],[Firstname]" +
            //        ",[Lastname])VALUES (@corporate,@username,@password,@user,@firstname,@lastname )", con);
            //        cmd.Parameters.AddWithValue("@corporate", corporateno);
            //        cmd.Parameters.AddWithValue("@username", username);
            //        cmd.Parameters.AddWithValue("@password", password);
            //        cmd.Parameters.AddWithValue("@user", "User");
            //        cmd.Parameters.AddWithValue("@firstname", firstname);
            //        cmd.Parameters.AddWithValue("@lastname", lastname);
            //        if (con.State == ConnectionState.Closed)
            //            con.Open();
            //        cmd.ExecuteReader();

            //        Message("User Created Succesfully");
            //    }
            //}           
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

            //using (SqlConnection con = new SqlConnection(CommonUtilities.ConnectionString))
            //{
            //    con.Open();
            //    SqlDataReader dr2 = null;
            //    string SQL = "SELECT * FROM [Sacco].[dbo].[MSacco Portal Users] where [Username] = @user and [Corporate No] = @corp";               
            //    SqlCommand cmd23 = new SqlCommand(SQL, con);
            //    cmd23.Parameters.AddWithValue("@user", username);
            //    cmd23.Parameters.AddWithValue("@corp", corporateNo);
            //    dr2 = cmd23.ExecuteReader();

            //    if (dr2.HasRows == true)
            //    {
            //        exists = true;
            //    }
            //    con.Close();
            //}

            return exists;
        }

    }
}