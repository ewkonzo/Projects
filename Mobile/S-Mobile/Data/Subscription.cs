//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscription
    {
        public long Id { get; set; }
        public string MSISDN { get; set; }
        public Nullable<long> Service_id { get; set; }
        public string Product_id { get; set; }
        public Nullable<int> Update_type { get; set; }
        public Nullable<System.DateTime> Date_time { get; set; }
    }
}