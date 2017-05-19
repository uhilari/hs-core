using System;
using System.Collections.Generic;
using System.Text;

namespace HS
{
  public interface IValidacion<T> where T: EntityBase
  {
    Error Validar(T entidad);
  }
}
