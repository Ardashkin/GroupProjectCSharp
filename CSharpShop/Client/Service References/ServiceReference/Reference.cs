﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IShopServiceBaseOf_BaseModel")]
    public interface IShopServiceBaseOf_BaseModel {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopServiceBaseOf_BaseModel/Create", ReplyAction="http://tempuri.org/IShopServiceBaseOf_BaseModel/CreateResponse")]
        void Create(DomainModel.BaseModel item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopServiceBaseOf_BaseModel/Create", ReplyAction="http://tempuri.org/IShopServiceBaseOf_BaseModel/CreateResponse")]
        System.Threading.Tasks.Task CreateAsync(DomainModel.BaseModel item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopServiceBaseOf_BaseModel/GetItems", ReplyAction="http://tempuri.org/IShopServiceBaseOf_BaseModel/GetItemsResponse")]
        DomainModel.BaseModel[] GetItems();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopServiceBaseOf_BaseModel/GetItems", ReplyAction="http://tempuri.org/IShopServiceBaseOf_BaseModel/GetItemsResponse")]
        System.Threading.Tasks.Task<DomainModel.BaseModel[]> GetItemsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopServiceBaseOf_BaseModel/Update", ReplyAction="http://tempuri.org/IShopServiceBaseOf_BaseModel/UpdateResponse")]
        void Update(DomainModel.BaseModel item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopServiceBaseOf_BaseModel/Update", ReplyAction="http://tempuri.org/IShopServiceBaseOf_BaseModel/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(DomainModel.BaseModel item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopServiceBaseOf_BaseModel/Delete", ReplyAction="http://tempuri.org/IShopServiceBaseOf_BaseModel/DeleteResponse")]
        void Delete(DomainModel.BaseModel item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopServiceBaseOf_BaseModel/Delete", ReplyAction="http://tempuri.org/IShopServiceBaseOf_BaseModel/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(DomainModel.BaseModel item);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IShopServiceBaseOf_BaseModelChannel : Client.ServiceReference.IShopServiceBaseOf_BaseModel, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ShopServiceBaseOf_BaseModelClient : System.ServiceModel.ClientBase<Client.ServiceReference.IShopServiceBaseOf_BaseModel>, Client.ServiceReference.IShopServiceBaseOf_BaseModel {
        
        public ShopServiceBaseOf_BaseModelClient() {
        }
        
        public ShopServiceBaseOf_BaseModelClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ShopServiceBaseOf_BaseModelClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShopServiceBaseOf_BaseModelClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShopServiceBaseOf_BaseModelClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Create(DomainModel.BaseModel item) {
            base.Channel.Create(item);
        }
        
        public System.Threading.Tasks.Task CreateAsync(DomainModel.BaseModel item) {
            return base.Channel.CreateAsync(item);
        }
        
        public DomainModel.BaseModel[] GetItems() {
            return base.Channel.GetItems();
        }
        
        public System.Threading.Tasks.Task<DomainModel.BaseModel[]> GetItemsAsync() {
            return base.Channel.GetItemsAsync();
        }
        
        public void Update(DomainModel.BaseModel item) {
            base.Channel.Update(item);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(DomainModel.BaseModel item) {
            return base.Channel.UpdateAsync(item);
        }
        
        public void Delete(DomainModel.BaseModel item) {
            base.Channel.Delete(item);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(DomainModel.BaseModel item) {
            return base.Channel.DeleteAsync(item);
        }
    }
}
