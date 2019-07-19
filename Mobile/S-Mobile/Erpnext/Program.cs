using GizmoFort.Connector.ERPNext.PublicInterfaces;
using GizmoFort.Connector.ERPNext.PublicTypes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erpnext
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ERPNextClient("http://localhost:8000", "Administrator", "admin");

            var active_username = client.GetActiveUserName();
            dynamic data = client.RPC("frappe.auth.get_logged_user", Method.GET);
            string active_userna = data.message;


            ERPObject new_erp_object = new ERPObject(DocType.Customer);
            new_erp_object.Data.customer_type = "Individual";
            new_erp_object.Data.customer_name = "John Doe";
            new_erp_object.Data.customer_group = "Individual";
            new_erp_object.Data.website = "http://yourcustomerwebsite.com";
            new_erp_object.Data.territory = "Australia";

            client.InsertObject(new_erp_object);

            FetchListOption listOption = new FetchListOption();

            // you can use filter
           // listOption.Filters.Add(new ERPFilter(DocType.Customer, "name", OperatorFilter.Equals, "John Doe"));

            // by default, list only return field "name" only.
            // you can include specific fields in the listing operation by doing following:
            listOption.IncludedFields.AddRange(new string[] { "name", "website" });

            // You can also paginate listing result
            listOption.PageSize = 50;
            //listOption.PageStartIndex = 20;

            // finally perform listing operation
            List<ERPObject> object_list = client.ListObjects(DocType.Customer, listOption);
        }
    }
}
