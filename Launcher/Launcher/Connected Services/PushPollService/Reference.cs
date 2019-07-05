﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Launcher.PushPollService {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LaunchControl", Namespace="http://schemas.datacontract.org/2004/07/PushPollService")]
    public enum LaunchControl : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Start = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Stop = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PushPollService.IContract", CallbackContract=typeof(Launcher.PushPollService.IContractCallback))]
    public interface IContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/GetConnectionConfirmation", ReplyAction="http://tempuri.org/IContract/GetConnectionConfirmationResponse")]
        string GetConnectionConfirmation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/GetConnectionConfirmation", ReplyAction="http://tempuri.org/IContract/GetConnectionConfirmationResponse")]
        System.Threading.Tasks.Task<string> GetConnectionConfirmationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/LaunchToggle", ReplyAction="http://tempuri.org/IContract/LaunchToggleResponse")]
        Launcher.PushPollService.LaunchControl LaunchToggle(Launcher.PushPollService.LaunchControl control);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/LaunchToggle", ReplyAction="http://tempuri.org/IContract/LaunchToggleResponse")]
        System.Threading.Tasks.Task<Launcher.PushPollService.LaunchControl> LaunchToggleAsync(Launcher.PushPollService.LaunchControl control);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/MyMethod", ReplyAction="http://tempuri.org/IContract/MyMethodResponse")]
        void MyMethod();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/MyMethod", ReplyAction="http://tempuri.org/IContract/MyMethodResponse")]
        System.Threading.Tasks.Task MyMethodAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IContractCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContract/OnCallback", ReplyAction="http://tempuri.org/IContract/OnCallbackResponse")]
        void OnCallback();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IContractChannel : Launcher.PushPollService.IContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ContractClient : System.ServiceModel.DuplexClientBase<Launcher.PushPollService.IContract>, Launcher.PushPollService.IContract {
        
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
        
        public Launcher.PushPollService.LaunchControl LaunchToggle(Launcher.PushPollService.LaunchControl control) {
            return base.Channel.LaunchToggle(control);
        }
        
        public System.Threading.Tasks.Task<Launcher.PushPollService.LaunchControl> LaunchToggleAsync(Launcher.PushPollService.LaunchControl control) {
            return base.Channel.LaunchToggleAsync(control);
        }
        
        public void MyMethod() {
            base.Channel.MyMethod();
        }
        
        public System.Threading.Tasks.Task MyMethodAsync() {
            return base.Channel.MyMethodAsync();
        }
    }
}