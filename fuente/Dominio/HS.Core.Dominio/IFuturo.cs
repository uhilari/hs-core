using System;
using System.Collections.Generic;
using System.Text;

namespace HS
{
  public interface IFuturo<T> where T: EntityBase
  {
    T Valor { get; }
  }
}
