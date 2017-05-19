using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  public interface IOrigen<T>
  {
    T GetValor(object objeto);
  }
}
