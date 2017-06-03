using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  public interface IOrigen<T>
  {
    T GetValor(object objeto);
  }

  public interface IOrigenMapper<TDto, TEntity>: IOrigen<IEnumerable<TEntity>>
    where TDto: class
    where TEntity: EntityBase
  {
    void Mapper(IMapper<TDto, TEntity> mapper);
  }
}
