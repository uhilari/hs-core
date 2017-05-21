using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  class DestinoDtoReferencia<TOrigen> : IDestino, IDestinoDtoReferencia<TOrigen>
    where TOrigen : EntityBase
  {
    private PropertyInfo _propiedad;
    private IOrigen<string> _origen;

    public DestinoDtoReferencia(PropertyInfo propiedad)
    {
      _propiedad = propiedad;
    }

    public void Ejecutar(object destino, object origen)
    {
      _propiedad.SetValue(destino, _origen.GetValor(origen));
    }

    public IDestino Referencia<TPropiedad>(Expression<Func<TOrigen, TPropiedad>> expr) where TPropiedad : EntityBase
    {
      _origen = new OrigenDtoReferencia<TPropiedad>(LambdaHelper.GetPropertyInfo(expr));
      return this;
    }

    public IDestino Referencia(PropertyInfo propiedad)
    {
      _origen = new OrigenDtoReferencia<EntityBase>(propiedad);
      return this;
    }
  }

  class DestinoEntityReferencia<TPropiedad, TOrigen> : IDestino, IDestinoEntityReferencia<TPropiedad, TOrigen>
    where TPropiedad: EntityBase
  {
    private PropertyInfo _propiedad;
    private IOrigen<TPropiedad> _origen;
    private IGenericRepository _repository;

    public DestinoEntityReferencia(PropertyInfo propiedad, IGenericRepository repository)
    {
      _propiedad = propiedad;
      _repository = repository;
    }

    public void Ejecutar(object destino, object origen)
    {
      _propiedad.SetValue(destino, _origen.GetValor(origen));
    }

    public IDestino Referencia(Expression<Func<TOrigen, string>> expr)
    {
      _origen = new OrigenEntidadReferencia<TPropiedad>(_repository, c => expr.Compile()((TOrigen)c));
      return this;
    }

    public IDestino Referencia(PropertyInfo propiedad)
    {
      _origen = new OrigenEntidadReferencia<TPropiedad>(_repository, c => (string)propiedad.GetValue(c));
      return this;
    }
  }
}
