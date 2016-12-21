using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Behavior;
using System.ServiceModel;
using Microsoft.Practices.Unity;

namespace Server.Host
{
    public class UnityServiceHost : ServiceHost
    {
        private IUnityContainer unityContainer;

        public UnityServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        protected override void OnOpening()
        {
            base.OnOpening();

            if (this.Description.Behaviors.Find<UnityServiceBehavior>() == null)
                this.Description.Behaviors.Add(new UnityServiceBehavior());
        }
    }
}