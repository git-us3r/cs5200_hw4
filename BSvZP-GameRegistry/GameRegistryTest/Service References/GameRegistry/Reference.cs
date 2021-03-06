﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameRegistryTester.GameRegistry {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameRegistry.IRegistrar")]
    public interface IRegistrar {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrar/RegisterGame", ReplyAction="http://tempuri.org/IRegistrar/RegisterGameResponse")]
        Common.GameInfo RegisterGame(string label, Common.EndPoint publicEP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrar/RegisterGame", ReplyAction="http://tempuri.org/IRegistrar/RegisterGameResponse")]
        System.Threading.Tasks.Task<Common.GameInfo> RegisterGameAsync(string label, Common.EndPoint publicEP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrar/GetGames", ReplyAction="http://tempuri.org/IRegistrar/GetGamesResponse")]
        Common.GameInfo[] GetGames(Common.GameInfo.GameStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrar/GetGames", ReplyAction="http://tempuri.org/IRegistrar/GetGamesResponse")]
        System.Threading.Tasks.Task<Common.GameInfo[]> GetGamesAsync(Common.GameInfo.GameStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrar/AmAlive", ReplyAction="http://tempuri.org/IRegistrar/AmAliveResponse")]
        void AmAlive(int gameId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrar/AmAlive", ReplyAction="http://tempuri.org/IRegistrar/AmAliveResponse")]
        System.Threading.Tasks.Task AmAliveAsync(int gameId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrar/ChangeStatus", ReplyAction="http://tempuri.org/IRegistrar/ChangeStatusResponse")]
        void ChangeStatus(int gameId, Common.GameInfo.GameStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrar/ChangeStatus", ReplyAction="http://tempuri.org/IRegistrar/ChangeStatusResponse")]
        System.Threading.Tasks.Task ChangeStatusAsync(int gameId, Common.GameInfo.GameStatus status);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRegistrarChannel : GameRegistryTester.GameRegistry.IRegistrar, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegistrarClient : System.ServiceModel.ClientBase<GameRegistryTester.GameRegistry.IRegistrar>, GameRegistryTester.GameRegistry.IRegistrar {
        
        public RegistrarClient() {
        }
        
        public RegistrarClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RegistrarClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrarClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrarClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Common.GameInfo RegisterGame(string label, Common.EndPoint publicEP) {
            return base.Channel.RegisterGame(label, publicEP);
        }
        
        public System.Threading.Tasks.Task<Common.GameInfo> RegisterGameAsync(string label, Common.EndPoint publicEP) {
            return base.Channel.RegisterGameAsync(label, publicEP);
        }
        
        public Common.GameInfo[] GetGames(Common.GameInfo.GameStatus status) {
            return base.Channel.GetGames(status);
        }
        
        public System.Threading.Tasks.Task<Common.GameInfo[]> GetGamesAsync(Common.GameInfo.GameStatus status) {
            return base.Channel.GetGamesAsync(status);
        }
        
        public void AmAlive(int gameId) {
            base.Channel.AmAlive(gameId);
        }
        
        public System.Threading.Tasks.Task AmAliveAsync(int gameId) {
            return base.Channel.AmAliveAsync(gameId);
        }
        
        public void ChangeStatus(int gameId, Common.GameInfo.GameStatus status) {
            base.Channel.ChangeStatus(gameId, status);
        }
        
        public System.Threading.Tasks.Task ChangeStatusAsync(int gameId, Common.GameInfo.GameStatus status) {
            return base.Channel.ChangeStatusAsync(gameId, status);
        }
    }
}
