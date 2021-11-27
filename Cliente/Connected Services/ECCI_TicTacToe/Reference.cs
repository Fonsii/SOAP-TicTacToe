﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HolaMundo.ECCI_TicTacToe {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:ECCI_TicTacToe", ConfigurationName="ECCI_TicTacToe.ECCI_TicTacToePort")]
    internal interface ECCI_TicTacToePort {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ECCI_TicTacToe#TicTacToe#doMove", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        int doMove(int moveIndex);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ECCI_TicTacToe#TicTacToe#resetBoard", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        void resetBoard();
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ECCI_TicTacToe#TicTacToe#getBoardStatus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        int getBoardStatus();
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ECCI_TicTacToe#TicTacToe#topPlays", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        string topPlays();
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ECCI_TicTacToe#TicTacToe#leaderboardCheck", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        int leaderboardCheck(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface ECCI_TicTacToePortChannel : HolaMundo.ECCI_TicTacToe.ECCI_TicTacToePort, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class ECCI_TicTacToePortClient : System.ServiceModel.ClientBase<HolaMundo.ECCI_TicTacToe.ECCI_TicTacToePort>, HolaMundo.ECCI_TicTacToe.ECCI_TicTacToePort {
        
        public ECCI_TicTacToePortClient() {
        }
        
        public ECCI_TicTacToePortClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ECCI_TicTacToePortClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ECCI_TicTacToePortClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ECCI_TicTacToePortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int doMove(int moveIndex) {
            return base.Channel.doMove(moveIndex);
        }
        
        public void resetBoard() {
            base.Channel.resetBoard();
        }
        
        public int getBoardStatus() {
            return base.Channel.getBoardStatus();
        }
        
        public string topPlays() {
            return base.Channel.topPlays();
        }
        
        public int leaderboardCheck(string name) {
            return base.Channel.leaderboardCheck(name);
        }
    }
}
