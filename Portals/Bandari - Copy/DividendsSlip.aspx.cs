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
        protected void Page_Load(object sender, EventArgs e)
        {
            string membernumber = Session["Member_No"].ToString();
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                GenerateReport(membernumber);
            }
        }

        protected void GenerateReport(string membernumber)
        {
            try
            {
                string filename = cSite.Bandari_WebService.Dividends(membernumber);
                string sourcefile = @"\\172.17.1.3\Statements\Dividends Statements\" + membernumber + ".pdf";
                string destinationfile = @"C:\Portal\LIVE2\App_Temp_Reports\Dividends Statements\" + membernumber + ".pdf";
                //string destinationfile = @"A:\Portals\Creation\Bandari\App_Temp_Reports\Dividends Statements\" + membernumber + ".pdf";

                if (System.IO.File.Exists(destinationfile) == true)
                {
                    System.IO.File.Delete(destinationfile);
                    System.IO.File.Move(sourcefile, destinationfile);
                }
                if (System.IO.File.Exists(destinationfile) == false)
                {
                    System.IO.File.Move(sourcefile, destinationfile);
                }

                pdfLoans.Attributes.Add("src",
                    ResolveUrl("~/App_Temp_Reports/Dividends Statements/" + String.Format("{0}.pdf", membernumber)));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}