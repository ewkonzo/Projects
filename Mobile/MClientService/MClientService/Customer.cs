using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MClientService.Customers;

namespace MClientService
{
    public class Customer : Smobilemembers
    {
        public static List<Smobilemembers> Getcustomer(string phone)
        {
            List<Smobilemembers> c = null;
            try
            {
                c = Mobile.Cservice.ReadMultiple(new Customers.Smobilemembers_Filter[] { new Customers.Smobilemembers_Filter { Criteria = phone, Field = Customers.Smobilemembers_Fields.Mobile_Phone_No } }, null, 10).ToList(); 
            }
            catch (Exception ex)
            {
                CUtilities.ReportError(ex);
            }
            return c;
        }
    }
}