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

namespace NewTests.OneCReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="GetCirculationSoapBinding", Namespace="http://www.sample-package.org")]
    public partial class GetCirculation : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetDocOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GetCirculation() {
            this.Url = global::NewTests.Properties.Settings.Default.NewTests_OneCReference_WebTest;
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
        public event GetDocCompletedEventHandler GetDocCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.sample-package.org#GetCirculation:GetDoc", RequestNamespace="http://www.sample-package.org", ResponseNamespace="http://www.sample-package.org", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return")]
        public string GetDoc(ObjectCalculation Object) {
            object[] results = this.Invoke("GetDoc", new object[] {
                        Object});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetDocAsync(ObjectCalculation Object) {
            this.GetDocAsync(Object, null);
        }
        
        /// <remarks/>
        public void GetDocAsync(ObjectCalculation Object, object userState) {
            if ((this.GetDocOperationCompleted == null)) {
                this.GetDocOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDocOperationCompleted);
            }
            this.InvokeAsync("GetDoc", new object[] {
                        Object}, this.GetDocOperationCompleted, userState);
        }
        
        private void OnGetDocOperationCompleted(object arg) {
            if ((this.GetDocCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDocCompleted(this, new GetDocCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.GetStatus.org")]
    public partial class ObjectCalculation {
        
        private string idField;
        
        private string typeField;
        
        private string statusField;
        
        private string lIDField;
        
        private string circulationField;
        
        private string managerField;
        
        private string commentField;
        
        private string specificationField;
        
        private System.DateTime dateExecuteField;
        
        private string lIDBuyerField;
        
        private string buyerField;
        
        private string contactPersonField;
        
        private System.DateTime dateDocField;
        
        /// <remarks/>
        public string ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string LID {
            get {
                return this.lIDField;
            }
            set {
                this.lIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string Circulation {
            get {
                return this.circulationField;
            }
            set {
                this.circulationField = value;
            }
        }
        
        /// <remarks/>
        public string Manager {
            get {
                return this.managerField;
            }
            set {
                this.managerField = value;
            }
        }
        
        /// <remarks/>
        public string Comment {
            get {
                return this.commentField;
            }
            set {
                this.commentField = value;
            }
        }
        
        /// <remarks/>
        public string Specification {
            get {
                return this.specificationField;
            }
            set {
                this.specificationField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DateExecute {
            get {
                return this.dateExecuteField;
            }
            set {
                this.dateExecuteField = value;
            }
        }
        
        /// <remarks/>
        public string LIDBuyer {
            get {
                return this.lIDBuyerField;
            }
            set {
                this.lIDBuyerField = value;
            }
        }
        
        /// <remarks/>
        public string Buyer {
            get {
                return this.buyerField;
            }
            set {
                this.buyerField = value;
            }
        }
        
        /// <remarks/>
        public string ContactPerson {
            get {
                return this.contactPersonField;
            }
            set {
                this.contactPersonField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DateDoc {
            get {
                return this.dateDocField;
            }
            set {
                this.dateDocField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetDocCompletedEventHandler(object sender, GetDocCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDocCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDocCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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