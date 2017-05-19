using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  class Destino<TPropiedad, TOrigen> : IDestino, IDestino<TPropiedad, TOrigen>
  {
    private PropertyInfo _propiedad;
    private IOrigen<TPropiedad> _origen;

    public Destino(PropertyInfo propiedad)
    {
      _propiedad = propiedad.NoEsNull(nameof(propiedad));
    }

    public void Ejecutar(object destino, object origen)
    {
      _propiedad.SetValue(destino, _origen.GetValor(origen));
    }

    public IDestino Constante(TPropiedad valor)
    {
      _origen = new OrigenConstante<TPropiedad>(valor);
      return this;
    }

    public IDestino Funcion(Expression<Func<TOrigen, TPropiedad>> expr)
    {
      _origen = new OrigenExpresion<TOrigen, TPropiedad>(expr.Compile());
      return this;
    }

    public IDestino Propiedad(PropertyInfo propiedad)
    {
      _origen = new OrigenPropiedad<TPropiedad>(propiedad);
      return this;
    }
  }
}
