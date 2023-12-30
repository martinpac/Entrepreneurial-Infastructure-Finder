﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment7.ReportsServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReportsServices.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Weather5Day", ReplyAction="http://tempuri.org/IService1/Weather5DayResponse")]
        string[] Weather5Day(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Weather5Day", ReplyAction="http://tempuri.org/IService1/Weather5DayResponse")]
        System.Threading.Tasks.Task<string[]> Weather5DayAsync(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TaxReport", ReplyAction="http://tempuri.org/IService1/TaxReportResponse")]
        string[] TaxReport(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TaxReport", ReplyAction="http://tempuri.org/IService1/TaxReportResponse")]
        System.Threading.Tasks.Task<string[]> TaxReportAsync(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrimeReport", ReplyAction="http://tempuri.org/IService1/CrimeReportResponse")]
        string[] CrimeReport(string StateAbbreviation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CrimeReport", ReplyAction="http://tempuri.org/IService1/CrimeReportResponse")]
        System.Threading.Tasks.Task<string[]> CrimeReportAsync(string StateAbbreviation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HealthReport", ReplyAction="http://tempuri.org/IService1/HealthReportResponse")]
        string[] HealthReport(string stateAbbreviation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HealthReport", ReplyAction="http://tempuri.org/IService1/HealthReportResponse")]
        System.Threading.Tasks.Task<string[]> HealthReportAsync(string stateAbbreviation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PovertyReport", ReplyAction="http://tempuri.org/IService1/PovertyReportResponse")]
        string[] PovertyReport(string stateAbbreviation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PovertyReport", ReplyAction="http://tempuri.org/IService1/PovertyReportResponse")]
        System.Threading.Tasks.Task<string[]> PovertyReportAsync(string stateAbbreviation);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Assignment7.ReportsServices.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Assignment7.ReportsServices.IService1>, Assignment7.ReportsServices.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] Weather5Day(string zipcode) {
            return base.Channel.Weather5Day(zipcode);
        }
        
        public System.Threading.Tasks.Task<string[]> Weather5DayAsync(string zipcode) {
            return base.Channel.Weather5DayAsync(zipcode);
        }
        
        public string[] TaxReport(string zipcode) {
            return base.Channel.TaxReport(zipcode);
        }
        
        public System.Threading.Tasks.Task<string[]> TaxReportAsync(string zipcode) {
            return base.Channel.TaxReportAsync(zipcode);
        }
        
        public string[] CrimeReport(string StateAbbreviation) {
            return base.Channel.CrimeReport(StateAbbreviation);
        }
        
        public System.Threading.Tasks.Task<string[]> CrimeReportAsync(string StateAbbreviation) {
            return base.Channel.CrimeReportAsync(StateAbbreviation);
        }
        
        public string[] HealthReport(string stateAbbreviation) {
            return base.Channel.HealthReport(stateAbbreviation);
        }
        
        public System.Threading.Tasks.Task<string[]> HealthReportAsync(string stateAbbreviation) {
            return base.Channel.HealthReportAsync(stateAbbreviation);
        }
        
        public string[] PovertyReport(string stateAbbreviation) {
            return base.Channel.PovertyReport(stateAbbreviation);
        }
        
        public System.Threading.Tasks.Task<string[]> PovertyReportAsync(string stateAbbreviation) {
            return base.Channel.PovertyReportAsync(stateAbbreviation);
        }
    }
}
