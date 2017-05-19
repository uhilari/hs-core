using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HS
{
  public class Lista<T> : List<T>, ILista<T> where T : EntityBase
  {
    public T Buscar(Guid id)
    {
      return Buscar(c => c.Id == id);
    }

    public T Buscar(Expression<Func<T, bool>> expresion)
    {
      return this.FirstOrDefault(expresion.Compile());
    }

    public IEnumerable<T> Filtrar(Expression<Func<T, bool>> expresion)
    {
      return this.Where(expresion.Compile()).ToList();
    }
  }
}
