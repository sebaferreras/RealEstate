using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using _01.RealEstate.API.IoC;
using _02.RealEstate.Domain.IRepositories;
using _02.RealEstate.Domain.IServices;
using _02.RealEstate.Domain.Services;
using _03.RealEstate.Data.Repositories;

namespace _01.RealEstate.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Set UnityResolver as DependencyResolver
            var container = new UnityContainer();

            // Services
            container.RegisterType<IPropertyService, PropertyService>(new HierarchicalLifetimeManager());

            // Repositories
            container.RegisterType<IPropertyRepository, PropertyRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
