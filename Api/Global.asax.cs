using Api.App_Start;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config => config.Register(new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.Build())));

        }
    }
}
