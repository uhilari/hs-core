using NHibernate.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class DtoTransform<T> : IResultTransformer where T : class, new()
  {
    public PropertyInfo[] _propiedades;

    public DtoTransform()
    {
      _propiedades = typeof(T).GetProperties();
    }

    public IList TransformList(IList collection)
    {
      return collection.Cast<T>().ToList();
    }

    public object TransformTuple(object[] tuple, string[] aliases)
    {
      var dto = new T();
      foreach (var propiedad in _propiedades)
      {
        if (aliases.Contains(propiedad.Name))
        {
          var valor = tuple[Array.IndexOf(aliases, propiedad.Name)];
          if (valor.GetType() == typeof(Guid))
          {
            valor = ((Guid)valor).Cadena();
          }
          propiedad.SetValue(dto, valor);
        }
      }
      return dto;
    }
  }
}
