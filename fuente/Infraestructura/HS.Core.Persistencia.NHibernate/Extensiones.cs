using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public static class Extensiones
  {
    public static T ValidarNoNull<T>(this T entidad) where T: EntityBase
    {
      if (entidad == null)
        throw new NoRegistroException(typeof(T).Name);
      return entidad;
    }
  }
}
