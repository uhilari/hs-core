using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public interface ILista<T>: IList<T> where T: EntityBase
  {
    T Agregar(T entidad);
    void AgregarVarios(IEnumerable<T> entidades);
    T Buscar(Guid id);
    T Buscar(Expression<Func<T, bool>> expresion);
    IEnumerable<T> Filtrar(Expression<Func<T, bool>> expresion);
    void ForEach(Action<T> accion);
  }
}
