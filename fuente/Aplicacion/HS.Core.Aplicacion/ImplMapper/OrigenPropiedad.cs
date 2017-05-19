using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  class OrigenPropiedad<T> : IOrigen<T>
  {
    private PropertyInfo _propiedad;

    public OrigenPropiedad(PropertyInfo propiedad)
    {
      _propiedad = propiedad;
    }

    public T GetValor(object objeto)
    {
      return (T)_propiedad.GetValue(objeto);
    }
  }
}
