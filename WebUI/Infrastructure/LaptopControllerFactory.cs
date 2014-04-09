using DomainLogic;
using SqlDataAccess;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebUI.Controllers;

namespace WebUI.Infrastructure
{
    public class LaptopControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == typeof(HomeController) )
            {
                ObjectFactory.Initialize(x =>
                {
                    var connectionString = "";
                        //ConfigurationManager.ConnectionStrings["LaptopDb"].ConnectionString;
                    x.For<LaptopRepository>().Use<SqlLaptopRespository>().Ctor<String>().Is(connectionString);
                });

                if (controllerType == typeof(AdministratorController))
                    return (IController)ObjectFactory.GetInstance<AdministratorController>();

                if (controllerType == typeof(HomeController))
                    return (IController)ObjectFactory.GetInstance<HomeController>();
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}