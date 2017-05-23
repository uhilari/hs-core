using Castle.DynamicProxy;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class LogInterceptor : IInterceptor
  {
    public void Intercept(IInvocation invocation)
    {
      var log = LogManager.GetLogger(invocation.TargetType);
      log.DebugFormat("Llamada a '{0}'", invocation.Method.Name);
      invocation.Proceed();
      log.DebugFormat("Salida de '{0}'", invocation.Method.Name);
    }
  }
}
