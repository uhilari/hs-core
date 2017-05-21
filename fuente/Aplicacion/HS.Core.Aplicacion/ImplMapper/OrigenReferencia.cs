using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  class OrigenDtoReferencia<TPropiedad>: IOrigen<string>
    where TPropiedad: EntityBase
  {
    private PropertyInfo _propiedad;

    public OrigenDtoReferencia(PropertyInfo propiedad)
    {
      _propiedad = propiedad;
    }

    public string GetValor(object objeto)
    {
      var entidad = (TPropiedad)_propiedad.GetValue(objeto);
      return entidad.Id.Cadena();
    }
  }

  class OrigenEntidadReferencia<T> : IOrigen<T>
    where T: EntityBase
  {
    private Func<object, string> _funcion;
    private IGenericRepository _repository;

    public OrigenEntidadReferencia(IGenericRepository repositorio, Func<object, string> funcion)
    {
      _repository = repositorio;
      _funcion = funcion;
    }

    public T GetValor(object objeto)
    {
      var id = _funcion(objeto).Guid();
      return _repository.Get<T>(id);
    }
  }
}
