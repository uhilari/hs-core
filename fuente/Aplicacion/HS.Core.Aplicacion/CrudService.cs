using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class CrudService<TDto, TEntity> : ICrudService<TDto>
    where TDto: class
    where TEntity: EntityBase
  {
    private IRepository<TEntity> _repository;
    private IMapper<TDto, TEntity> _mapper;

    public CrudService(IRepository<TEntity> repository, IMapper<TDto, TEntity> mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [UnitOfWork]
    public void Actualizar(string id, TDto dto)
    {
      _mapper.ActualizarEntity(_repository.BuscarUno(id.Guid()), dto);
    }

    [UnitOfWork]
    public void Anular(string id)
    {
      var entity = _repository.BuscarUno(id.Guid());
      entity.Eliminar();
    }

    [UnitOfWork]
    public void Crear(TDto dto)
    {
      _repository.Agregar(_mapper.CrearEntity(dto));
    }

    public TDto Get(string id)
    {
      return _mapper.CrearDto(_repository.BuscarUno(id.Guid()));
    }
  }
}
