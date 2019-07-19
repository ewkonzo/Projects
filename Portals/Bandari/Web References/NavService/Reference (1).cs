﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Bandari_Sacco.NavService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="NavPortal_Binding", Namespace="urn:microsoft-dynamics-schemas/codeunit/NavPortal")]
    public partial class NavPortal : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AccountStatementOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoanGuarantorsOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoansGuaranteedOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NavPortal() {
            this.Url = global::Bandari_Sacco.Properties.Settings.Default.Bandari_Sacco_NavService_NavPortal;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event AccountStatementCompletedEventHandler AccountStatementCompleted;
        
        /// <remarks/>
        public event LoanGuarantorsCompletedEventHandler LoanGuarantorsCompleted;
        
        /// <remarks/>
        public event LoansGuaranteedCompletedEventHandler LoansGuaranteedCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/NavPortal:AccountStatement", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/NavPortal", ResponseElementName="AccountStatement_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/NavPortal", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string AccountStatement(string memberNo_AccountStatement) {
            object[] results = this.Invoke("AccountStatement", new object[] {
                        memberNo_AccountStatement});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void AccountStatementAsync(string memberNo_AccountStatement) {
            this.AccountStatementAsync(memberNo_AccountStatement, null);
        }
        
        /// <remarks/>
        public void AccountStatementAsync(string memberNo_AccountStatement, object userState) {
            if ((this.AccountStatementOperationCompleted == null)) {
                this.AccountStatementOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAccountStatementOperationCompleted);
            }
            this.InvokeAsync("AccountStatement", new object[] {
                        memberNo_AccountStatement}, this.AccountStatementOperationCompleted, userState);
        }
        
        private void OnAccountStatementOperationCompleted(object arg) {
            if ((this.AccountStatementCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AccountStatementCompleted(this, new AccountStatementCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/NavPortal:LoanGuarantors", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/NavPortal", ResponseElementName="LoanGuarantors_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/NavPortal", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string LoanGuarantors(string memberNo_LoansGuarantors) {
            object[] results = this.Invoke("LoanGuarantors", new object[] {
                        memberNo_LoansGuarantors});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LoanGuarantorsAsync(string memberNo_LoansGuarantors) {
            this.LoanGuarantorsAsync(memberNo_LoansGuarantors, null);
        }
        
        /// <remarks/>
        public void LoanGuarantorsAsync(string memberNo_LoansGuarantors, object userState) {
            if ((this.LoanGuarantorsOperationCompleted == null)) {
                this.LoanGuarantorsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoanGuarantorsOperationCompleted);
            }
            this.InvokeAsync("LoanGuarantors", new object[] {
                        memberNo_LoansGuarantors}, this.LoanGuarantorsOperationCompleted, userState);
        }
        
        private void OnLoanGuarantorsOperationCompleted(object arg) {
            if ((this.LoanGuarantorsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoanGuarantorsCompleted(this, new LoanGuarantorsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/NavPortal:LoansGuaranteed", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/NavPortal", ResponseElementName="LoansGuaranteed_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/NavPortal", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string LoansGuaranteed(string memberNo_LoansGuaranteed) {
            object[] results = this.Invoke("LoansGuaranteed", new object[] {
                        memberNo_LoansGuaranteed});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LoansGuaranteedAsync(string memberNo_LoansGuaranteed) {
            this.LoansGuaranteedAsync(memberNo_LoansGuaranteed, null);
        }
        
        /// <remarks/>
        public void LoansGuaranteedAsync(string memberNo_LoansGuaranteed, object userState) {
            if ((this.LoansGuaranteedOperationCompleted == null)) {
                this.LoansGuaranteedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoansGuaranteedOperationCompleted);
            }
            this.InvokeAsync("LoansGuaranteed", new object[] {
                        memberNo_LoansGuaranteed}, this.LoansGuaranteedOperationCompleted, userState);
        }
        
        private void OnLoansGuaranteedOperationCompleted(object arg) {
            if ((this.LoansGuaranteedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoansGuaranteedCompleted(this, new LoansGuaranteedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    public delegate void AccountStatementCompletedEventHandler(object sender, AccountStatementCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AccountStatementCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AccountStatementCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    public delegate void LoanGuarantorsCompletedEventHandler(object sender, LoanGuarantorsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoanGuarantorsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoanGuarantorsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    public delegate void LoansGuaranteedCompletedEventHandler(object sender, LoansGuaranteedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoansGuaranteedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoansGuaranteedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591