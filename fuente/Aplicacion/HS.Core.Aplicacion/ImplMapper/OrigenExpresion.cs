using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  class OrigenExpresion<TClase, T> : IOrigen<T>
  {
    private Func<TClase, T> _funcion;

    public OrigenExpresion(Func<TClase, T> funcion)
    {
      _funcion = funcion;
    }

    public T GetValor(object objeto)
    {
      return _funcion((TClase)objeto);
    }
  }
}
