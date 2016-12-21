using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Description;
using Microsoft.Practices.Unity;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using Server.InstanceProvider;

namespace Server.Behavior
{
    public class UnityServiceBehavior : IServiceBehavior
    {
        private readonly IUnityContainer container;

        public UnityServiceBehavior()
        {
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    string contractName = endpointDispatcher.ContractName;
                    if (contractName != "IMetadataExchange" && contractName != "IHttpGetHelpPageAndMetadataContract")
                    {
                        ServiceEndpoint serviceEndpoint = serviceDescription.Endpoints.FirstOrDefault(e => e.Contract.Name == contractName);
                        endpointDispatcher.DispatchRuntime.InstanceProvider =
                            new UnityInstanceProvider(serviceEndpoint.Contract.ContractType);
                    }
                }
            }
        }
    }
}