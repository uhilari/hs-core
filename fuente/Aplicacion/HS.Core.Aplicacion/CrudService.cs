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
    private IMapper<TDto, TEntity> _mapper = null;

    public CrudService(IRepository<TEntity> repository, IMapperFactory mapperFactory)
    {
      Repository = repository;
      MapperFactory = mapperFactory;
    }

    protected IRepository<TEntity> Repository { get; }
    protected IMapperFactory MapperFactory { get; }
    protected IMapper<TDto, TEntity> Mapper => _mapper ?? (_mapper = MapperFactory.GetMapper<TDto, TEntity>());

    [UnitOfWork]
    public void Actualizar(string id, TDto dto)
    {
      Mapper.ActualizarEntity(Repository.BuscarUno(id.Guid()), dto);
    }

    [UnitOfWork]
    public void Anular(string id)
    {
      var entity = Repository.BuscarUno(id.Guid());
      entity.Eliminar();
    }

    [UnitOfWork]
    public void Crear(TDto dto)
    {
      Repository.Agregar(Mapper.CrearEntity(dto));
    }

    public TDto Get(string id)
    {
      return Mapper.CrearDto(Repository.BuscarUno(id.Guid()));
    }

    public IEnumerable<TDto> Listar()
    {
      return Repository.BuscarVarios(c => c.Eliminado == false)
        .Select(c => Mapper.CrearDto(c))
        .ToList();
    }
  }
}
