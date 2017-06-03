using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  class OrigenMapper<TDto, TEntity> : IOrigenMapper<TDto, TEntity>
    where TDto : class
    where TEntity : EntityBase
  {
    private IMapper<TDto, TEntity> _mapper;
    private PropertyInfo _propiedad;

    public OrigenMapper(PropertyInfo propiedad)
    {
      _propiedad = propiedad;
    }

    public IEnumerable<TEntity> GetValor(object objeto)
    {
      var lista = (IEnumerable<TDto>)_propiedad.GetValue(objeto);
      return lista.Select(c => _mapper.CrearEntity(c));
    }

    public void Mapper(IMapper<TDto, TEntity> mapper)
    {
      _mapper = mapper;
    }
  }
}
