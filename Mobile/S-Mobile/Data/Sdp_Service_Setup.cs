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
    
    public partial class Sdp_Service_Setup
    {
        public long ID { get; set; }
        public string ServiceName { get; set; }
        public string Masking { get; set; }
        public long ServiceID { get; set; }
        public long spID { get; set; }
        public Nullable<long> ShortCode { get; set; }
        public Nullable<long> correlator_last_used { get; set; }
        public string ServiceType { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> AccessNo { get; set; }
        public string Client { get; set; }
    }
}
