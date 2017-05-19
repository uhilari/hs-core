using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace HS
{
  public class WindsorDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
  {
    private IKernel _kernel;

    public WindsorDependencyResolver(IKernel kernel)
    {
      _kernel = kernel;
    }

    public IDependencyScope BeginScope()
    {
      return new WindsorDependencyScope(_kernel);
    }

    public void Dispose()
    {
      _kernel = null;
    }

    public object GetService(Type serviceType)
    {
      try
      {
        return _kernel.Resolve(serviceType);
      }
      catch (ComponentNotFoundException)
      {
        return null;
      }
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      return _kernel.ResolveAll(serviceType).Cast<object>().ToArray();
    }
  }
}
