﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AGENCY.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.0.1.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://197.232.21.217:4000/Sms/Service1.svc")]
        public string AGENCY_Smsservice_Demosms {
            get {
                return ((string)(this["AGENCY_Smsservice_Demosms"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\;Integrated Security=True;Connect Timeout=60")]
        public string Setting {
            get {
                return ((string)(this["Setting"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:2012/Coretec/WS/Coretec/Page/AgentTransactions")]
        public string AGENCY_AgencyTransactions_AgentTransactions_Service {
            get {
                return ((string)(this["AGENCY_AgencyTransactions_AgentTransactions_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://192.168.1.108:1112/Agency/WS/TrimLine/Page/Vendors")]
        public string AGENCY_Accounts_Vendors_Service {
            get {
                return ((string)(this["AGENCY_Accounts_Vendors_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:2012/Coretec/WS/Coretec/Codeunit/Post")]
        public string AGENCY_PostAgent_Post {
            get {
                return ((string)(this["AGENCY_PostAgent_Post"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:2012/Coretec/WS/Coretec/Page/Customers")]
        public string AGENCY_Customer_Customers_Service {
            get {
                return ((string)(this["AGENCY_Customer_Customers_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:2012/Coretec/WS/Coretec/Page/CustomerDetails")]
        public string AGENCY_AccountDetails_CustomerDetails_Service {
            get {
                return ((string)(this["AGENCY_AccountDetails_CustomerDetails_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:2012/Coretec/WS/Coretec/Page/AgentApplications")]
        public string AGENCY_Agents_AgentApplications_Service {
            get {
                return ((string)(this["AGENCY_Agents_AgentApplications_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:2012/Coretec/WS/Coretec/Page/Loans")]
        public string AGENCY_Loan_Loans_Service {
            get {
                return ((string)(this["AGENCY_Loan_Loans_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:2012/Coretec/WS/Coretec/Page/LoanProducts")]
        public string AGENCY_Loanproducts_LoanProducts_Service {
            get {
                return ((string)(this["AGENCY_Loanproducts_LoanProducts_Service"]));
            }
        }
    }
}
