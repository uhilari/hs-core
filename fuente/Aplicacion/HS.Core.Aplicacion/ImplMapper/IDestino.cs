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
}
