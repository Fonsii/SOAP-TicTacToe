﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HolaMundo.ECCI_HolaMundo {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:ECCI_HolaMundo", ConfigurationName="ECCI_HolaMundo.ECCI_HolaMundoPort")]
    public interface ECCI_HolaMundoPort {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ECCI_HolaMundo#HolaMundo#salude", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="salude")]
        string salude(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ECCI_HolaMundo#HolaMundo#servidorEstampillaDeTiempo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="servidorEstampillaDeTiempo")]
        string servidorEstampillaDeTiempo();
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ECCI_HolaMundo#HolaMundo#ultimoSaludo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="ultimoSaludo")]
        string ultimoSaludo();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ECCI_HolaMundoPortChannel : HolaMundo.ECCI_HolaMundo.ECCI_HolaMundoPort, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ECCI_HolaMundoPortClient : System.ServiceModel.ClientBase<HolaMundo.ECCI_HolaMundo.ECCI_HolaMundoPort>, HolaMundo.ECCI_HolaMundo.ECCI_HolaMundoPort {
        
        public ECCI_HolaMundoPortClient() {
        }
        
        public ECCI_HolaMundoPortClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ECCI_HolaMundoPortClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ECCI_HolaMundoPortClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ECCI_HolaMundoPortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string salude(string nombre) {
            return base.Channel.salude(nombre);
        }
        
        public string servidorEstampillaDeTiempo() {
            return base.Channel.servidorEstampillaDeTiempo();
        }
        
        public string ultimoSaludo() {
            return base.Channel.ultimoSaludo();
        }
    }
}
