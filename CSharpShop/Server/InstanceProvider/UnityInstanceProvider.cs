using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Server.Dependency;

namespace Server.InstanceProvider
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        private readonly Type contractType;
        public UnityInstanceProvider(Type contractType)
        {
            this.contractType = contractType;
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return DependencyManager.Container.Resolve(contractType);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            DependencyManager.Container.Teardown(instance);
        }
    }
}