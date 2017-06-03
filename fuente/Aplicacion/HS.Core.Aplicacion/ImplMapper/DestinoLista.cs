using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  class DestinoLista<TItemDestino, TOrigen> : IDestinoLista<TItemDestino, TOrigen>, IDestino
    where TItemDestino : EntityBase
    where TOrigen : class
  {
    private PropertyInfo _propiedad;
    private IOrigen<IEnumerable<TItemDestino>> _origen;

    public DestinoLista(PropertyInfo propiedad)
    {
      _propiedad = propiedad;
    }

    public IDestino Constante(IEnumerable<TItemDestino> valor)
    {
      _origen = new OrigenConstante<IEnumerable<TItemDestino>>(valor);
      return this;
    }

    public void Ejecutar(object destino, object origen)
    {
      var lista = new Lista<TItemDestino>();
      lista.AgregarVarios(_origen.GetValor(origen));
      _propiedad.SetValue(destino, lista);
    }

    public IOrigenMapper<S, TItemDestino> Funcion<S>(Expression<Func<TOrigen, IEnumerable<S>>> expr) 
      where S : class
    {
      IOrigenMapper<S, TItemDestino> origen;
      _origen = origen = new OrigenMapper<S, TItemDestino>(LambdaHelper.GetPropertyInfo(expr));
      return origen;
    }
  }
}
