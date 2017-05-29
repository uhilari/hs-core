using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public abstract class ConsultaHqlLista<T> : Consulta<IList<T>>
  {
    public ConsultaHqlLista(ISessionFactory factory) : base(factory)
    {
    }

    protected override IList<T> EjecutarInterno(IQuery query)
    {
      return query.List<T>();
    }
  }
}
