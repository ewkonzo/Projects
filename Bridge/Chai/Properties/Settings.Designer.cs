﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bridge.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:212/Bandari/WS/BANDARI/Page/Atm_Transactions")]
        public string Bridge_Atm_Transactions_Atm_Transactions_Service {
            get {
                return ((string)(this["Bridge_Atm_Transactions_Atm_Transactions_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:212/Bandari/WS/BANDARI/Page/Atm_Logs")]
        public string Bridge_Atm_Logs_Atm_Logs_Service {
            get {
                return ((string)(this["Bridge_Atm_Logs_Atm_Logs_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:212/Bandari/WS/BANDARI/Page/Atm_Charges")]
        public string Bridge_Atm_Charges_Atm_Charges_Service {
            get {
                return ((string)(this["Bridge_Atm_Charges_Atm_Charges_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:212/Bandari/WS/BANDARI/Page/Pos_Commissions")]
        public string Bridge_Pos_Commissions_Pos_Commissions_Service {
            get {
                return ((string)(this["Bridge_Pos_Commissions_Pos_Commissions_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:212/Bandari/WS/BANDARI/Page/Accounts")]
        public string Bridge_Accounts_Accounts_Service {
            get {
                return ((string)(this["Bridge_Accounts_Accounts_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:212/Bandari/WS/BANDARI/Page/Account_Entries")]
        public string Bridge_Account_Entries_Account_Entries_Service {
            get {
                return ((string)(this["Bridge_Account_Entries_Account_Entries_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://paulo:212/Bandari/WS/BANDARI/Codeunit/PostAtm")]
        public string Bridge_PostAtm_PostAtm {
            get {
                return ((string)(this["Bridge_PostAtm_PostAtm"]));
            }
        }
    }
}