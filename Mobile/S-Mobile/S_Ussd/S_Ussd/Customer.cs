//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S_Ussd
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public string Telephone { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Client { get; set; }
        public string Comments { get; set; }
        public Nullable<decimal> Daily_Limit { get; set; }
        public Nullable<System.DateTime> Date_Registered { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public Nullable<bool> PinChanged { get; set; }
        public Nullable<short> Status { get; set; }
        public Nullable<short> Subscribed { get; set; }
        public Nullable<decimal> Transaction_Limit { get; set; }
        public string Verification_Code { get; set; }
        public Nullable<bool> Registration_Sms_sent { get; set; }
    }
}
