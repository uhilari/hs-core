using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace HS
{
  public class WindsorDependencyScope : IDependencyScope
  {
    private IKernel _kernel;

    public WindsorDependencyScope(IKernel kernel)
    {
      _kernel = kernel;
    }

    public void Dispose()
    {
      _kernel = null;
    }

    public object GetService(Type serviceType)
    {
      return _kernel.Resolve(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      return _kernel.ResolveAll(serviceType).Cast<object>().ToArray();
    }
  }
}
