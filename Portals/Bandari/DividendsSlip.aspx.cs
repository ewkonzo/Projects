using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bandari_Sacco.controller;

namespace Bandari_Sacco
{
    public partial class DividendsSlip : System.Web.UI.Page
    {
        private Member.mobile_Member member = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string membernumber = Session["Member_No"].ToString();
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }            
            member = Global.member_Service.Read(Session["user_id"].ToString());
            if (!IsPostBack)
            {
                GenerateReport(membernumber);
            }
        }

        protected void GenerateReport(string membernumber)
        {
            try
            {              
                string path1 = HttpRuntime.AppDomainAppPath;
                string path2 = string.Format(@"App_Temp_Reports\Account Statement\{1}{2}.pdf", path1, member.No, DateTime.Now.Second);
                string path = path1 + path2;

                Global.mBranch.DivindedReport(member.No, path);
                pdfLoans.Attributes.Add("src", ResolveUrl("~/" + path2));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}