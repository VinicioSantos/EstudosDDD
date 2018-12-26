using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
//using Unity;
//using Unity.Exceptions;
using Microsoft.Practices.Unity;

namespace SpaUserControl.API.Helpers
{
    public class Unityresolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public Unityresolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new Unityresolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}