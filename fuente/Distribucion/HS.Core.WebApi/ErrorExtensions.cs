using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public static class ErrorExtensions
  {
    public static HttpResponseMessage GetResponseMessage(this BaseException exception)
    {
      HttpResponseMessage response = new HttpResponseMessage(GetHttpCode(exception.Codigo));
      response.Content = new StringContent(JsonConvert.SerializeObject(exception.GetDatos()), Encoding.UTF8, "application/json");
      response.ReasonPhrase = exception.Message;
      return response;
    }

    private static HttpStatusCode GetHttpCode(int codigo)
    {
      if (codigo == 4000)
        return HttpStatusCode.BadRequest;
      if (codigo == 4040)
        return HttpStatusCode.NotFound;
      return HttpStatusCode.InternalServerError;
    }
  }
}
