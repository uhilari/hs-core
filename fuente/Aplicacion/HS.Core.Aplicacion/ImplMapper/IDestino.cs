using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  public interface IDestino
  {
    void Ejecutar(object destino, object origen);
  }

  public interface IDestino<TPropiedad, TOrigen>
  {
    IDestino Constante(TPropiedad valor);
    IDestino Funcion(Expression<Func<TOrigen, TPropiedad>> expr);
    IDestino Propiedad(PropertyInfo propiedad);
  }

  public interface IDestinoDtoReferencia<TOrigen>
    where TOrigen: EntityBase
  {
    IDestino Referencia<TPropiedad>(Expression<Func<TOrigen, TPropiedad>> expr) where TPropiedad: EntityBase;
    IDestino Referencia(PropertyInfo propiedad);
  }

  public interface IDestinoEntityReferencia<TPropiedad, TOrigen>
    where TPropiedad: EntityBase
  {
    IDestino Referencia(Expression<Func<TOrigen, string>> expr);
    IDestino Referencia(PropertyInfo propiedad);
  }

  public interface IDestinoLista<TItemDestino, TOrigen>
    where TItemDestino: EntityBase
    where TOrigen: class
  {
    IDestino Constante(IEnumerable<TItemDestino> valor);
    IOrigenMapper<S, TItemDestino> Funcion<S>(Expression<Func<TOrigen, IEnumerable<S>>> expr) where S: class;
  }
}
