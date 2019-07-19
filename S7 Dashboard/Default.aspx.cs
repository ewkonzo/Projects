using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace S7_Dashboard
{
    public partial class _Default : Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        [WebMethod]
        public static double Getvalue(string Temp) {
            double v= 0;
            using (var db = new S7Entities())
            {
                var d = db.Temparatures.OrderByDescending(o => o.Id).FirstOrDefault(o => o.Name == Temp);
                if (d != null)
                    v = (double)d.Value;
            }
            return v;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Gridview2.DataBind();
        }

        protected void Filter_Click(object sender, EventArgs e)
        {
            using(var db = new S7Entities()) {
                var t = db.Temparatures.ToArray() ;
                //string date = Date.Text;
                //    DateTime? date1 = null;
                //    DateTime? date2 = null;
                //    string[] dates;
                //if (! string.IsNullOrEmpty(date))
                //{
                //        if (date.Contains(".."))
                //        {
                //            dates = date.Split(new string[] { ".." }, StringSplitOptions.None);

                //            if (dates[0].ToLower().Equals("t"))
                //                date1 = DateTime.Now.Date;
                //            else
                //            {
                //                string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                //                DateTime.TryParseExact(dates[0], sysFormat,
                //                                       CultureInfo.InvariantCulture, DateTimeStyles.None, out  date1);
                //            }
                //            if (!String.IsNullOrEmpty(dates[1]))
                //            {
                //                if (dates[1].ToLower().Equals("t"))
                //                    date2 = DateTime.Now.Date;
                //                else
                //                {
                //                    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                //                    DateTime.TryParseExact(dates[1], sysFormat,
                //                                           CultureInfo.InvariantCulture, DateTimeStyles.None, out  date2);
                //                }
                //            }
                //        }
                //        else
                //        {
                //            if (date.ToLower().Equals("t"))
                //                date1 = DateTime.Now.Date;
                //            else
                //            {
                //                string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                //                DateTime.TryParseExact(date, sysFormat,
                //                                       CultureInfo.InvariantCulture, DateTimeStyles.None, out date1);
                //            }
                //        }

                //        if (date1 != null && date2 != null)
                //            t = t.Where(o => o.Date <= date1 && o.Date >= date2).ToArray();
                //        else if (date1 !=null )
                //            t = t.Where(o => o.Date == date1 ).ToArray();



                //    }
                    
                } 
            }
    }
}