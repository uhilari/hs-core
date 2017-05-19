using Castle.DynamicProxy;
using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class UnitOfWorkInterceptor : IInterceptor
  {
    private IKernel _kernel;

    public UnitOfWorkInterceptor(IKernel kernel)
    {
      _kernel = kernel;
    }

    public void Intercept(IInvocation invocation)
    {
      var atributo = invocation.Method.GetCustomAttributes(typeof(UnitOfWorkAttribute), true);
      if (atributo != null)
      {
        using (var uow = _kernel.Resolve<IUnitOfWork>())
        {
          invocation.Proceed();
          uow.Complete();
        }
      }
      else
      {
        invocation.Proceed();
      }
    }
  }
}
