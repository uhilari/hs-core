using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace HS
{
  public class CustomErrorHandler: ExceptionHandler
  {
    public override void Handle(ExceptionHandlerContext context)
    {
      var noRegistro = context.Exception as BaseException;
      if (noRegistro != null)
      {
        context.Result = new CustomErrorResult(noRegistro.GetResponseMessage());
      }
      else {
        base.Handle(context);
      }
    }

    class CustomErrorResult : IHttpActionResult
    {
      HttpResponseMessage _response;

      public CustomErrorResult(HttpResponseMessage response)
      {
        _response = response;
      }

      public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
      {
        return Task.FromResult(_response);
      }
    }
  }
}
