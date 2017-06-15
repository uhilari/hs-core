using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class GuidFormatException: BaseException
  {
    public GuidFormatException(string cadena)
    {
      Texto = cadena;
      Codigo = 4000;
    }

    public string Texto { get; }

    public override string Message => string.Format("La cadena '{0}' no tiene el formato correcto", Texto);
  }
}
