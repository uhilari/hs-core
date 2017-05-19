using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HS
{
  public interface IRepository<T> where T: EntityBase
  {
    T BuscarUno(Guid id);
    T BuscarUnoONull(Guid id);
    T BuscarUno(Expression<Func<T, bool>> expresion);
    T BuscarUnoONull(Expression<Func<T, bool>> expresion);
    List<T> BuscarVarios(Expression<Func<T, bool>> expresion);
    void Agregar(T entidad);
  }
}
