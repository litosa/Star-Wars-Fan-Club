﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SWFC.DiceServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DiceServiceReference.IDiceService")]
    public interface IDiceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiceService/GetNumbers", ReplyAction="http://tempuri.org/IDiceService/GetNumbersResponse")]
        int GetNumbers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiceService/GetNumbers", ReplyAction="http://tempuri.org/IDiceService/GetNumbersResponse")]
        System.Threading.Tasks.Task<int> GetNumbersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDiceServiceChannel : SWFC.DiceServiceReference.IDiceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DiceServiceClient : System.ServiceModel.ClientBase<SWFC.DiceServiceReference.IDiceService>, SWFC.DiceServiceReference.IDiceService {
        
        public DiceServiceClient() {
        }
        
        public DiceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DiceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetNumbers() {
            return base.Channel.GetNumbers();
        }
        
        public System.Threading.Tasks.Task<int> GetNumbersAsync() {
            return base.Channel.GetNumbersAsync();
        }
    }
}
