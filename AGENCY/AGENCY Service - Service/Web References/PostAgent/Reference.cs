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

namespace AGENCY.PostAgent {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Post_Binding", Namespace="urn:microsoft-dynamics-schemas/codeunit/Post")]
    public partial class Post : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CallPostOperationCompleted;
        
        private System.Threading.SendOrPostCallback BalOperationCompleted;
        
        private System.Threading.SendOrPostCallback TchargesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Post() {
            this.Url = global::AGENCY.Properties.Settings.Default.AGENCY_PostAgent_Post;
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
        public event CallPostCompletedEventHandler CallPostCompleted;
        
        /// <remarks/>
        public event BalCompletedEventHandler BalCompleted;
        
        /// <remarks/>
        public event TchargesCompletedEventHandler TchargesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/Post:Post", RequestElementName="Post", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/Post", ResponseElementName="Post_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/Post", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void CallPost(string documentNo) {
            this.Invoke("CallPost", new object[] {
                        documentNo});
        }
        
        /// <remarks/>
        public void CallPostAsync(string documentNo) {
            this.CallPostAsync(documentNo, null);
        }
        
        /// <remarks/>
        public void CallPostAsync(string documentNo, object userState) {
            if ((this.CallPostOperationCompleted == null)) {
                this.CallPostOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCallPostOperationCompleted);
            }
            this.InvokeAsync("CallPost", new object[] {
                        documentNo}, this.CallPostOperationCompleted, userState);
        }
        
        private void OnCallPostOperationCompleted(object arg) {
            if ((this.CallPostCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CallPostCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/Post:Bal", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/Post", ResponseElementName="Bal_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/Post", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public decimal Bal(string acc) {
            object[] results = this.Invoke("Bal", new object[] {
                        acc});
            return ((decimal)(results[0]));
        }
        
        /// <remarks/>
        public void BalAsync(string acc) {
            this.BalAsync(acc, null);
        }
        
        /// <remarks/>
        public void BalAsync(string acc, object userState) {
            if ((this.BalOperationCompleted == null)) {
                this.BalOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBalOperationCompleted);
            }
            this.InvokeAsync("Bal", new object[] {
                        acc}, this.BalOperationCompleted, userState);
        }
        
        private void OnBalOperationCompleted(object arg) {
            if ((this.BalCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BalCompleted(this, new BalCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/Post:Tcharges", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/Post", ResponseElementName="Tcharges_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/Post", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public decimal Tcharges(decimal amount, int type) {
            object[] results = this.Invoke("Tcharges", new object[] {
                        amount,
                        type});
            return ((decimal)(results[0]));
        }
        
        /// <remarks/>
        public void TchargesAsync(decimal amount, int type) {
            this.TchargesAsync(amount, type, null);
        }
        
        /// <remarks/>
        public void TchargesAsync(decimal amount, int type, object userState) {
            if ((this.TchargesOperationCompleted == null)) {
                this.TchargesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTchargesOperationCompleted);
            }
            this.InvokeAsync("Tcharges", new object[] {
                        amount,
                        type}, this.TchargesOperationCompleted, userState);
        }
        
        private void OnTchargesOperationCompleted(object arg) {
            if ((this.TchargesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TchargesCompleted(this, new TchargesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void CallPostCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void BalCompletedEventHandler(object sender, BalCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void TchargesCompletedEventHandler(object sender, TchargesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TchargesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TchargesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591