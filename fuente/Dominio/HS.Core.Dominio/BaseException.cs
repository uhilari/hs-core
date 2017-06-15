using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class BaseException: Exception
  {
    public BaseException()
    {
      Codigo = 5000;
    }

    public int Codigo { get; protected set; }

    protected virtual IEnumerable<Error> GetErrors()
    {
      return new Error[] { GetError() };
    }

    protected virtual Error GetError()
    {
      return new Error { Codigo = Codigo, Mensaje = Message };
    }

    public virtual object GetDatos()
    {
      return new { Errores = GetErrors() };
    }

    protected class Error
    {
      public int Codigo { get; set; }
      public string Mensaje { get; set; }
    }
  }
}
