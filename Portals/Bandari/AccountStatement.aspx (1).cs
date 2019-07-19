using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bandari_Sacco.controller;

namespace Bandari_Sacco
{
    public partial class AccountStatement : System.Web.UI.Page
    {
        private Member.mobile_Member member = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            string membernumber = Session["Member_No"].ToString();
            member = Global.member_Service.Read(Session["user_id"].ToString());
            if (!IsPostBack)
            {
                PopulateDropDownList(membernumber);
            }
            
        }

        private void PopulateDropDownList(string membernumber)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = null;
                ddlAccount.Items.Clear();

                if (member!= null)
                {
                    foreach (var m in member.Mobile_Accounts)
                    {
                        ddlAccount.Items.Add(m.No);
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
              
 string accountnumber = ddlAccount.SelectedItem.Text;
                string path1 = HttpRuntime.AppDomainAppPath;
                string path2 = string.Format(@"App_Temp_Reports\Account Statement\{1}{2}.pdf", path1, accountnumber,DateTime.Now.Second) ;
                string path = path1 + path2;

                Global.mBranch.AccountStatement(accountnumber,path);

                //string sourcefile = @"\\172.17.1.3\Statements\Account Statements\" + accountnumber + ".pdf";
                //string destinationfile = @"C:\Portal\LIVE\App_Temp_Reports\Account Statements\" + accountnumber + ".pdf";

                //string sourcefile = @"\\172.17.1.3\Statements\Account Statements\" + accountnumber + ".pdf";
                //string destinationfile = @"C:\Portal\LIVE2\App_Temp_Reports\Account Statements\" + accountnumber + ".pdf";
                ////string destinationfile = @"C:\Portal\BandariSacco\App_Temp_Reports\Account Statements\" + accountnumber + ".pdf";

                //if (System.IO.File.Exists(destinationfile) == true)
                //{
                //    System.IO.File.Delete(destinationfile);
                //    System.IO.File.Move(sourcefile, destinationfile);
                //}
                //if (System.IO.File.Exists(destinationfile) == false)
                //{
                //    System.IO.File.Move(sourcefile, destinationfile);
                //}

                // pdfLoans.Attributes.Add("src",
                // ResolveUrl("~/App_Temp_Reports/Account Statements/" + String.Format("{0}.pdf", accountnumber)));
                pdfLoans.Attributes.Add("src", ResolveUrl("~/" + path2));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void Sendemail_Click(object sender, EventArgs e)
        {
try
            {

                string accountnumber = ddlAccount.SelectedItem.Text;
                string path1 = HttpRuntime.AppDomainAppPath ;
                string name = string.Format(@"{0}{1}.pdf", accountnumber, DateTime.Now.Second);
                string path2 = string.Format(@"{0}App_Temp_Reports\Account Statement\{1}", path1, name);
                string path = path1 + path2;
          
                Global.mBranch.Emailstatement(accountnumber, path2, name);

               
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}