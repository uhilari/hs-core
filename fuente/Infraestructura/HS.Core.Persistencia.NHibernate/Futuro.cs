using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  internal class Futuro<T> : IFuturo<T> where T : EntityBase
  {
    private Task<T> _tarea;

    internal Futuro(Task<T> tarea)
    {
      _tarea = tarea;
    }

    public T Valor
    {
      get
      {
        if (!_tarea.IsCompleted)
          throw new FuturoNoEjecutadoException();
        return _tarea.Result;
      }
    }
  }
}
