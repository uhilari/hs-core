using Castle.MicroKernel;
using Microsoft.Owin;
using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HS
{
  public class HsMiddleware : OwinMiddleware
  {
    internal static AsyncLocal<ISession> Actual = new AsyncLocal<ISession>();

    private IKernel _kernel;

    public HsMiddleware(OwinMiddleware next, IKernel kernel) 
      : base(next)
    {
      _kernel = kernel;
    }

    public async override Task Invoke(IOwinContext context)
    {
      var sessionFactory = _kernel.Resolve<ISessionFactory>();
      using (var session = sessionFactory.OpenSession())
      {
        CurrentSessionContext.Bind(session);
        await Next.Invoke(context);
        CurrentSessionContext.Unbind(sessionFactory);
      }
    }
  }
}
