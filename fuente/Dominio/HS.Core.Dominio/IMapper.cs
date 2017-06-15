using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public interface IMapper<TDto, TEntity>
    where TDto: class
    where TEntity: EntityBase
  {
    TDto CrearDto(TEntity entity);
    TEntity CrearEntity(TDto dto);
    void ActualizarEntity(TEntity entity, TDto dto);
    ILista<TEntity> CrearEntities(IEnumerable<TDto> dtos);
  }
}
