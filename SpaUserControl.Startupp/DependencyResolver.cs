using Microsoft.Practices.Unity;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.InfraEstructure.Data;
using SpaUserControl.InfraEstructure.Data.Repositories;
//using Unity;
//using Unity.Lifetime;
using SpaUserControl.Business.Services;
using SpaUserControl.Domain.Models;
//using Microsoft.Practices.Unity;



namespace SpaUserControl.Startupp
{
    public static class DependencyResolver
    {
        //public static void Resolver(UnityContainer container)
        //{
        //    container.RegisterType<DataContext, DataContext>(new HierarchicalLifetimeManager());
        //    container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
        //    container.RegisterType<IUserServices, UserServices>(new HierarchicalLifetimeManager());

        //    container.RegisterType<User, User>(new HierarchicalLifetimeManager());
        //}

        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DataContext, DataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserServices, UserServices>(new HierarchicalLifetimeManager());

            container.RegisterType<User, User>(new HierarchicalLifetimeManager());
        }
    }
}
