using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HS
{
  public static class OwinExtensiones
  {
    public static IAppBuilder UseHs(this IAppBuilder app, Action<IWindsorContainer, HttpConfiguration> cfgContainer = null)
    {
      var container = new WindsorContainer();
      var config = new HttpConfiguration();
      config.DependencyResolver = new WindsorDependencyResolver(container.Kernel);
      cfgContainer?.Invoke(container, config);
      GestorEventos.Activador = new ActivadorDeEventos(container.Kernel);
      return app
        .Use<HsMiddleware>(container.Kernel)
        .UseWebApi(config);
    }
  }
}
