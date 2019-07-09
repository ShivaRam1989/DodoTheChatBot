﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LaunchControl", Namespace="http://schemas.datacontract.org/2004/07/IISHost")]
    public enum LaunchControl : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Start = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Stop = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Play = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Pause = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Hop = 4,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MetaData", Namespace="http://schemas.datacontract.org/2004/07/IISHost")]
    [System.SerializableAttribute()]
    public partial class MetaData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IntervalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PptIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VideoIdField;
        
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
        public string Interval {
            get {
                return this.IntervalField;
            }
            set {
                if ((object.ReferenceEquals(this.IntervalField, value) != true)) {
                    this.IntervalField = value;
                    this.RaisePropertyChanged("Interval");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PptId {
            get {
                return this.PptIdField;
            }
            set {
                if ((object.ReferenceEquals(this.PptIdField, value) != true)) {
                    this.PptIdField = value;
                    this.RaisePropertyChanged("PptId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VideoId {
            get {
                return this.VideoIdField;
            }
            set {
                if ((object.ReferenceEquals(this.VideoIdField, value) != true)) {
                    this.VideoIdField = value;
                    this.RaisePropertyChanged("VideoId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IContract", CallbackContract=typeof(WebApplication1.ServiceReference1.IContractCallback))]
    public interface IContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/GetConnectionConfirmation", ReplyAction="http://tempuri.org/IContract/GetConnectionConfirmationResponse")]
        string GetConnectionConfirmation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/GetConnectionConfirmation", ReplyAction="http://tempuri.org/IContract/GetConnectionConfirmationResponse")]
        System.Threading.Tasks.Task<string> GetConnectionConfirmationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/LaunchToggle", ReplyAction="http://tempuri.org/IContract/LaunchToggleResponse")]
        void LaunchToggle(WebApplication1.ServiceReference1.LaunchControl control, WebApplication1.ServiceReference1.MetaData metaData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/LaunchToggle", ReplyAction="http://tempuri.org/IContract/LaunchToggleResponse")]
        System.Threading.Tasks.Task LaunchToggleAsync(WebApplication1.ServiceReference1.LaunchControl control, WebApplication1.ServiceReference1.MetaData metaData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/ShowPpt", ReplyAction="http://tempuri.org/IContract/ShowPptResponse")]
        void ShowPpt(WebApplication1.ServiceReference1.MetaData metaData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/ShowPpt", ReplyAction="http://tempuri.org/IContract/ShowPptResponse")]
        System.Threading.Tasks.Task ShowPptAsync(WebApplication1.ServiceReference1.MetaData metaData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IContractCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/PlayVideo", ReplyAction="http://tempuri.org/IContract/PlayVideoResponse")]
        void PlayVideo(WebApplication1.ServiceReference1.MetaData metaData, WebApplication1.ServiceReference1.LaunchControl control);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/OpenPPT", ReplyAction="http://tempuri.org/IContract/OpenPPTResponse")]
        void OpenPPT(WebApplication1.ServiceReference1.MetaData metaData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/MyMethod", ReplyAction="http://tempuri.org/IContract/MyMethodResponse")]
        void MyMethod(WebApplication1.ServiceReference1.LaunchControl control, WebApplication1.ServiceReference1.MetaData metaData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IContractChannel : WebApplication1.ServiceReference1.IContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ContractClient : System.ServiceModel.DuplexClientBase<WebApplication1.ServiceReference1.IContract>, WebApplication1.ServiceReference1.IContract {
        
        public ContractClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ContractClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public string GetConnectionConfirmation() {
            return base.Channel.GetConnectionConfirmation();
        }
        
        public System.Threading.Tasks.Task<string> GetConnectionConfirmationAsync() {
            return base.Channel.GetConnectionConfirmationAsync();
        }
        
        public void LaunchToggle(WebApplication1.ServiceReference1.LaunchControl control, WebApplication1.ServiceReference1.MetaData metaData) {
            base.Channel.LaunchToggle(control, metaData);
        }
        
        public System.Threading.Tasks.Task LaunchToggleAsync(WebApplication1.ServiceReference1.LaunchControl control, WebApplication1.ServiceReference1.MetaData metaData) {
            return base.Channel.LaunchToggleAsync(control, metaData);
        }
        
        public void ShowPpt(WebApplication1.ServiceReference1.MetaData metaData) {
            base.Channel.ShowPpt(metaData);
        }
        
        public System.Threading.Tasks.Task ShowPptAsync(WebApplication1.ServiceReference1.MetaData metaData) {
            return base.Channel.ShowPptAsync(metaData);
        }
    }
}
