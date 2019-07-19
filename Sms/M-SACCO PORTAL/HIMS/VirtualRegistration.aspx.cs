using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIMS
{
    public partial class VirtualRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CorporateNo"] == null) || string.IsNullOrEmpty(Session["CorporateNo"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
    }
}