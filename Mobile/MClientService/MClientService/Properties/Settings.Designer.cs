﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MClientService.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:7002/Hazina2016/WS/Hazina%20Sacco%20Ltd/Page/SMS")]
        public string MClientService_Bulk_Sms_Service {
            get {
                return ((string)(this["MClientService_Bulk_Sms_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:7002/Hazina2016/WS/Hazina%20Sacco%20Ltd/Page/Smobile")]
        public string MClientService_SmobileTransactions_Smobile_Service {
            get {
                return ((string)(this["MClientService_SmobileTransactions_Smobile_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:7002/Hazina2016/WS/Hazina%20Sacco%20Ltd/Page/SmobileTransactiontypes" +
            "")]
        public string MClientService_Stypes_SmobileTransactiontypes_Service {
            get {
                return ((string)(this["MClientService_Stypes_SmobileTransactiontypes_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:7002/Hazina2016/WS/Hazina%20Sacco%20Ltd/Page/Smobilemembers")]
        public string MClientService_Customers_Smobilemembers_Service {
            get {
                return ((string)(this["MClientService_Customers_Smobilemembers_Service"]));
            }
        }
    }
}