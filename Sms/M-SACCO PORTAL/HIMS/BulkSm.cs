//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HIMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class BulkSm
    {
        public long Id { get; set; }
        public string Source_Id { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Value { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
        public string Client { get; set; }
        public Nullable<int> Balance { get; set; }
        public Nullable<int> Type { get; set; }
        public string Destination_Id { get; set; }
        public Nullable<int> Status { get; set; }
        public string Trace { get; set; }
        public Nullable<decimal> SMSCost { get; set; }
        public Nullable<bool> SMSCharged { get; set; }
    }
}