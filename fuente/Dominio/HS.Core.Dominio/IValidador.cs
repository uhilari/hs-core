using System;
using System.Collections.Generic;
using System.Text;

namespace HS
{
  public interface IValidador<T> where T: EntityBase
  {
    IEnumerable<Error> Validar(T entidad);
  }
}
