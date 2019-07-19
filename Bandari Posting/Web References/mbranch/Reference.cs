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

namespace RunCodunit.mbranch {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MBranch_Binding", Namespace="urn:microsoft-dynamics-schemas/codeunit/MBranch")]
    public partial class MBranch : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback BalanceOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetErrorCodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback PostOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendSmsOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReplacestringOperationCompleted;
        
        private System.Threading.SendOrPostCallback ChargeOperationCompleted;
        
        private System.Threading.SendOrPostCallback AdvanceEligibilityOperationCompleted;
        
        private System.Threading.SendOrPostCallback PostentryOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MBranch() {
            this.Url = global::RunCodunit.Properties.Settings.Default.RunCodunit_mbranch_MBranch;
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
        public event BalanceCompletedEventHandler BalanceCompleted;
        
        /// <remarks/>
        public event GetErrorCodeCompletedEventHandler GetErrorCodeCompleted;
        
        /// <remarks/>
        public event PostCompletedEventHandler PostCompleted;
        
        /// <remarks/>
        public event SendSmsCompletedEventHandler SendSmsCompleted;
        
        /// <remarks/>
        public event ReplacestringCompletedEventHandler ReplacestringCompleted;
        
        /// <remarks/>
        public event ChargeCompletedEventHandler ChargeCompleted;
        
        /// <remarks/>
        public event AdvanceEligibilityCompletedEventHandler AdvanceEligibilityCompleted;
        
        /// <remarks/>
        public event PostentryCompletedEventHandler PostentryCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/MBranch:Balance", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", ResponseElementName="Balance_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public decimal Balance(string acc) {
            object[] results = this.Invoke("Balance", new object[] {
                        acc});
            return ((decimal)(results[0]));
        }
        
        /// <remarks/>
        public void BalanceAsync(string acc) {
            this.BalanceAsync(acc, null);
        }
        
        /// <remarks/>
        public void BalanceAsync(string acc, object userState) {
            if ((this.BalanceOperationCompleted == null)) {
                this.BalanceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBalanceOperationCompleted);
            }
            this.InvokeAsync("Balance", new object[] {
                        acc}, this.BalanceOperationCompleted, userState);
        }
        
        private void OnBalanceOperationCompleted(object arg) {
            if ((this.BalanceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BalanceCompleted(this, new BalanceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/MBranch:GetErrorCode", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", ResponseElementName="GetErrorCode_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string GetErrorCode(int errorcode) {
            object[] results = this.Invoke("GetErrorCode", new object[] {
                        errorcode});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetErrorCodeAsync(int errorcode) {
            this.GetErrorCodeAsync(errorcode, null);
        }
        
        /// <remarks/>
        public void GetErrorCodeAsync(int errorcode, object userState) {
            if ((this.GetErrorCodeOperationCompleted == null)) {
                this.GetErrorCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetErrorCodeOperationCompleted);
            }
            this.InvokeAsync("GetErrorCode", new object[] {
                        errorcode}, this.GetErrorCodeOperationCompleted, userState);
        }
        
        private void OnGetErrorCodeOperationCompleted(object arg) {
            if ((this.GetErrorCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetErrorCodeCompleted(this, new GetErrorCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/MBranch:Post", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", ResponseElementName="Post_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Post() {
            this.Invoke("Post", new object[0]);
        }
        
        /// <remarks/>
        public void PostAsync() {
            this.PostAsync(null);
        }
        
        /// <remarks/>
        public void PostAsync(object userState) {
            if ((this.PostOperationCompleted == null)) {
                this.PostOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPostOperationCompleted);
            }
            this.InvokeAsync("Post", new object[0], this.PostOperationCompleted, userState);
        }
        
        private void OnPostOperationCompleted(object arg) {
            if ((this.PostCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PostCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/MBranch:SendSms", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", ResponseElementName="SendSms_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SendSms(string source, string telephone, string textsms, string documentNo) {
            this.Invoke("SendSms", new object[] {
                        source,
                        telephone,
                        textsms,
                        documentNo});
        }
        
        /// <remarks/>
        public void SendSmsAsync(string source, string telephone, string textsms, string documentNo) {
            this.SendSmsAsync(source, telephone, textsms, documentNo, null);
        }
        
        /// <remarks/>
        public void SendSmsAsync(string source, string telephone, string textsms, string documentNo, object userState) {
            if ((this.SendSmsOperationCompleted == null)) {
                this.SendSmsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSmsOperationCompleted);
            }
            this.InvokeAsync("SendSms", new object[] {
                        source,
                        telephone,
                        textsms,
                        documentNo}, this.SendSmsOperationCompleted, userState);
        }
        
        private void OnSendSmsOperationCompleted(object arg) {
            if ((this.SendSmsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendSmsCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/MBranch:Replacestring", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", ResponseElementName="Replacestring_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string Replacestring(string @string, string findwhat, string replacewith) {
            object[] results = this.Invoke("Replacestring", new object[] {
                        @string,
                        findwhat,
                        replacewith});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReplacestringAsync(string @string, string findwhat, string replacewith) {
            this.ReplacestringAsync(@string, findwhat, replacewith, null);
        }
        
        /// <remarks/>
        public void ReplacestringAsync(string @string, string findwhat, string replacewith, object userState) {
            if ((this.ReplacestringOperationCompleted == null)) {
                this.ReplacestringOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReplacestringOperationCompleted);
            }
            this.InvokeAsync("Replacestring", new object[] {
                        @string,
                        findwhat,
                        replacewith}, this.ReplacestringOperationCompleted, userState);
        }
        
        private void OnReplacestringOperationCompleted(object arg) {
            if ((this.ReplacestringCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReplacestringCompleted(this, new ReplacestringCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/MBranch:Charge", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", ResponseElementName="Charge_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public decimal Charge(int transaction_Type, decimal amount) {
            object[] results = this.Invoke("Charge", new object[] {
                        transaction_Type,
                        amount});
            return ((decimal)(results[0]));
        }
        
        /// <remarks/>
        public void ChargeAsync(int transaction_Type, decimal amount) {
            this.ChargeAsync(transaction_Type, amount, null);
        }
        
        /// <remarks/>
        public void ChargeAsync(int transaction_Type, decimal amount, object userState) {
            if ((this.ChargeOperationCompleted == null)) {
                this.ChargeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChargeOperationCompleted);
            }
            this.InvokeAsync("Charge", new object[] {
                        transaction_Type,
                        amount}, this.ChargeOperationCompleted, userState);
        }
        
        private void OnChargeOperationCompleted(object arg) {
            if ((this.ChargeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ChargeCompleted(this, new ChargeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/MBranch:AdvanceEligibility", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", ResponseElementName="AdvanceEligibility_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public decimal AdvanceEligibility(string account) {
            object[] results = this.Invoke("AdvanceEligibility", new object[] {
                        account});
            return ((decimal)(results[0]));
        }
        
        /// <remarks/>
        public void AdvanceEligibilityAsync(string account) {
            this.AdvanceEligibilityAsync(account, null);
        }
        
        /// <remarks/>
        public void AdvanceEligibilityAsync(string account, object userState) {
            if ((this.AdvanceEligibilityOperationCompleted == null)) {
                this.AdvanceEligibilityOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAdvanceEligibilityOperationCompleted);
            }
            this.InvokeAsync("AdvanceEligibility", new object[] {
                        account}, this.AdvanceEligibilityOperationCompleted, userState);
        }
        
        private void OnAdvanceEligibilityOperationCompleted(object arg) {
            if ((this.AdvanceEligibilityCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AdvanceEligibilityCompleted(this, new AdvanceEligibilityCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/MBranch:Postentry", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", ResponseElementName="Postentry_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/MBranch", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Postentry(int entry) {
            this.Invoke("Postentry", new object[] {
                        entry});
        }
        
        /// <remarks/>
        public void PostentryAsync(int entry) {
            this.PostentryAsync(entry, null);
        }
        
        /// <remarks/>
        public void PostentryAsync(int entry, object userState) {
            if ((this.PostentryOperationCompleted == null)) {
                this.PostentryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPostentryOperationCompleted);
            }
            this.InvokeAsync("Postentry", new object[] {
                        entry}, this.PostentryOperationCompleted, userState);
        }
        
        private void OnPostentryOperationCompleted(object arg) {
            if ((this.PostentryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PostentryCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void BalanceCompletedEventHandler(object sender, BalanceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BalanceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BalanceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public decimal Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((decimal)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void GetErrorCodeCompletedEventHandler(object sender, GetErrorCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetErrorCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetErrorCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void PostCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void SendSmsCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void ReplacestringCompletedEventHandler(object sender, ReplacestringCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReplacestringCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReplacestringCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void ChargeCompletedEventHandler(object sender, ChargeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ChargeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ChargeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public decimal Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((decimal)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void AdvanceEligibilityCompletedEventHandler(object sender, AdvanceEligibilityCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AdvanceEligibilityCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AdvanceEligibilityCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public decimal Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((decimal)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void PostentryCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591