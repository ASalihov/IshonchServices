﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewTests.TestServiceBPM {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CostCalculationObj", Namespace="http://schemas.datacontract.org/2004/07/Ishonch")]
    [System.SerializableAttribute()]
    public partial class CostCalculationObj : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal OrderPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal UnitPriceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndDate {
            get {
                return this.EndDateField;
            }
            set {
                if ((this.EndDateField.Equals(value) != true)) {
                    this.EndDateField = value;
                    this.RaisePropertyChanged("EndDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal OrderPrice {
            get {
                return this.OrderPriceField;
            }
            set {
                if ((this.OrderPriceField.Equals(value) != true)) {
                    this.OrderPriceField = value;
                    this.RaisePropertyChanged("OrderPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartDate {
            get {
                return this.StartDateField;
            }
            set {
                if ((this.StartDateField.Equals(value) != true)) {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal UnitPrice {
            get {
                return this.UnitPriceField;
            }
            set {
                if ((this.UnitPriceField.Equals(value) != true)) {
                    this.UnitPriceField = value;
                    this.RaisePropertyChanged("UnitPrice");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TestServiceBPM.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCalculationService", ReplyAction="http://tempuri.org/IService/GetCalculationServiceResponse")]
        string GetCalculationService(NewTests.TestServiceBPM.CostCalculationObj obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCalculationService", ReplyAction="http://tempuri.org/IService/GetCalculationServiceResponse")]
        System.Threading.Tasks.Task<string> GetCalculationServiceAsync(NewTests.TestServiceBPM.CostCalculationObj obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetStatus", ReplyAction="http://tempuri.org/IService/GetStatusResponse")]
        string GetStatus(string statusId, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetStatus", ReplyAction="http://tempuri.org/IService/GetStatusResponse")]
        System.Threading.Tasks.Task<string> GetStatusAsync(string statusId, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/TestService2", ReplyAction="http://tempuri.org/IService/TestService2Response")]
        string TestService2(NewTests.TestServiceBPM.CostCalculationObj obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/TestService2", ReplyAction="http://tempuri.org/IService/TestService2Response")]
        System.Threading.Tasks.Task<string> TestService2Async(NewTests.TestServiceBPM.CostCalculationObj obj);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : NewTests.TestServiceBPM.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<NewTests.TestServiceBPM.IService>, NewTests.TestServiceBPM.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetCalculationService(NewTests.TestServiceBPM.CostCalculationObj obj) {
            return base.Channel.GetCalculationService(obj);
        }
        
        public System.Threading.Tasks.Task<string> GetCalculationServiceAsync(NewTests.TestServiceBPM.CostCalculationObj obj) {
            return base.Channel.GetCalculationServiceAsync(obj);
        }
        
        public string GetStatus(string statusId, System.DateTime date) {
            return base.Channel.GetStatus(statusId, date);
        }
        
        public System.Threading.Tasks.Task<string> GetStatusAsync(string statusId, System.DateTime date) {
            return base.Channel.GetStatusAsync(statusId, date);
        }
        
        public string TestService2(NewTests.TestServiceBPM.CostCalculationObj obj) {
            return base.Channel.TestService2(obj);
        }
        
        public System.Threading.Tasks.Task<string> TestService2Async(NewTests.TestServiceBPM.CostCalculationObj obj) {
            return base.Channel.TestService2Async(obj);
        }
    }
}
