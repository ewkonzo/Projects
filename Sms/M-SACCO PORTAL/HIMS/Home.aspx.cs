using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIMS
{
    public partial class Home1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Search_PhoneNo = "";
            if ((Session["CorporateNo"] == null) || string.IsNullOrEmpty(Session["CorporateNo"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
    }
}