using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class MapaEntidad<T>: ClassMapping<T> where T: EntityBase
  {
    public MapaEntidad()
    {
      Id(c => c.Id, m => m.Generator(Generators.GuidComb));
      Property(c => c.Eliminado);
    }

    public void Enumerado<TEnumerado>(Expression<Func<T, TEnumerado>> propiedad)
    {
      Property(propiedad, a => a.Type<EnumStringType<TEnumerado>>());
    }

    public void Lista<TPropiedad>(Expression<Func<T, IEnumerable<TPropiedad>>> propiedad, string key, 
      Action<IBagPropertiesMapper<T, TPropiedad>> actionMapper = null)
      where TPropiedad: EntityBase
    {
      Bag(propiedad, a =>
      {
        a.Key(k => k.Column(key));
        a.Cascade(Cascade.All);
        a.Type<ListaDiferidaFactory<TPropiedad>>();
        actionMapper?.Invoke(a);
      }, m => m.OneToMany());
    }
  }
}
