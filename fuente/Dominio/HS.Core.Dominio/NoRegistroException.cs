using System;
using System.Collections.Generic;
using System.Text;

namespace HS
{
  public class NoRegistroException : Exception
  {
    public NoRegistroException(string tipoEntidad)
    {
      TipoEntidad = tipoEntidad;
    }

    public string TipoEntidad { get; }

    public override string Message => string.Format("No existe la entidad '{0}'", TipoEntidad);
  }
}
