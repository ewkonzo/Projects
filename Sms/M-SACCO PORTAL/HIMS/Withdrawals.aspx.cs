using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIMS
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Telephone.Focus();
            string Search_PhoneNo = "";
            if ((Session["CorporateNo"] == null) || string.IsNullOrEmpty(Session["CorporateNo"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["Search_Pin_No"] != null)
                    {
                        Search_PhoneNo = Request.QueryString["Search_Pin_No"].Trim();
                    }
                    Telephone.Text = Search_PhoneNo;
                }
            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            string Search_Pin_No = "";

            Search_Pin_No = Telephone.Text;

            string CurrentPage = "Withdrawals.aspx?action=Withdrawals&Show=False&Search_Pin_No=" + Search_Pin_No;
            Response.Redirect(CurrentPage, false);
            Context.ApplicationInstance.CompleteRequest();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Search_Pin_No = "";

            Search_Pin_No = Telephone.Text;

            string CurrentPage = "Withdrawals.aspx?action=Withdrawals&Show=False";
            Response.Redirect(CurrentPage, false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}