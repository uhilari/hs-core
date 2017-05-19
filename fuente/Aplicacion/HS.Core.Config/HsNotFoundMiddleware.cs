using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class HsNotFoundMiddleware : OwinMiddleware
  {
    public HsNotFoundMiddleware(OwinMiddleware next) : base(next)
    {
    }

    public async override Task Invoke(IOwinContext context)
    {
      context.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
      context.Response.ReasonPhrase = "Ruta no implementada";
      await context.Response.WriteAsync("");
    }
  }
}
