using Microsoft.Practices.Unity;
using _02.RealEstate.Domain.IRepositories;
using _02.RealEstate.Domain.IServices;
using _02.RealEstate.Domain.Services;
using _03.RealEstate.Data.Context;
using _03.RealEstate.Data.Repositories;

namespace _01.RealEstate.API.IoC
{
    public static class UnityMappings
    {
        public static UnityContainer RegisterTypes()
        {
            // Set UnityResolver as DependencyResolver
            var container = new UnityContainer();

            // Services
            container.RegisterType<IPropertyService, PropertyService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBrokerService, BrokerService>(new HierarchicalLifetimeManager());

            // Repositories
            container.RegisterType<IPropertyRepository, PropertyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBrokerRepository, BrokerRepository>(new HierarchicalLifetimeManager());

            // Context
            container.RegisterType<IRealStateContext, RealEstateContext>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}