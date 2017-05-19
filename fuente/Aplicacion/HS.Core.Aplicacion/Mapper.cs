using HS.ImplMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class Mapper<TDto, TEntity> : IMapper<TDto, TEntity>
    where TDto : class, new()
    where TEntity : EntityBase, new()
  {
    private IGenericRepository _repository;
    private IDictionary<string, IDestino> _dtoDestinos = new Dictionary<string, IDestino>();
    private IDictionary<string, IDestino> _entityDestinos = new Dictionary<string, IDestino>();

    public Mapper(IGenericRepository repository)
    {
      _repository = repository;
    }

    protected IDestino<S, TEntity> DestinoDto<S>(Expression<Func<TDto, S>> expression)
    {
      var propiedad = LambdaHelper.GetPropertyInfo(expression);
      var destino = new Destino<S, TEntity>(propiedad);
      _dtoDestinos.Add(propiedad.Name, destino);
      return destino;
    }

    protected IDestino<S, TDto> DestinoEntity<S>(Expression<Func<TEntity, S>> expression)
    {
      var propiedad = LambdaHelper.GetPropertyInfo(expression);
      var destino = new Destino<S, TDto>(propiedad);
      _entityDestinos.Add(propiedad.Name, destino);
      return destino;
    }

    protected void MapeoAutomatico()
    {
      var propsDto = typeof(TDto).GetProperties();
      foreach (var prop in propsDto)
      {
        var propEntidad = typeof(TEntity).GetProperty(prop.Name);
        if (prop.Name == "Id")
        {
          _dtoDestinos.Add(prop.Name, new Destino<string, TEntity>(prop).Funcion(c => c.Id.Cadena()));
        }
        else if (propEntidad != null)
        {
          if (!_dtoDestinos.Keys.Any(c => c == prop.Name))
            _dtoDestinos.Add(prop.Name, new Destino<object, TEntity>(prop).Propiedad(propEntidad));
          if (!_entityDestinos.Keys.Any(c => c == prop.Name))
            _entityDestinos.Add(prop.Name, new Destino<object, TDto>(propEntidad).Propiedad(prop));
        }
      }
    }

    public void ActualizarEntity(TEntity entity, TDto dto)
    {
      entity.NoEsNull(nameof(entity));
      dto.NoEsNull(nameof(dto));
      if (_entityDestinos.Count == 0)
        MapeoAutomatico();

      foreach (var item in _entityDestinos)
      {
        item.Value.Ejecutar(entity, dto);
      }
    }

    public TDto CrearDto(TEntity entity)
    {
      entity.NoEsNull(nameof(entity));
      if (_dtoDestinos.Count == 0)
        MapeoAutomatico();

      TDto res = new TDto();
      foreach (var item in _dtoDestinos)
      {
        item.Value.Ejecutar(res, entity);
      }
      return res;
    }

    public TEntity CrearEntity(TDto dto)
    {
      dto.NoEsNull(nameof(dto));
      if (_entityDestinos.Count == 0)
        MapeoAutomatico();

      TEntity res = new TEntity();
      foreach (var item in _entityDestinos)
      {
        item.Value.Ejecutar(res, dto);
      }
      return res;
    }
  }
}
