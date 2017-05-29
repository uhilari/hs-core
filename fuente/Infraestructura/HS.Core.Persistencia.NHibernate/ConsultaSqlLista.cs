using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace HS
{
  public abstract class ConsultaSqlLista<T> : ConsultaSql<IList<T>>
  {
    public ConsultaSqlLista(ISessionFactory factory) : base(factory)
    {
    }

    protected override IList<T> EjecutarInterno(IQuery query)
    {
      return query.List<T>();
    }
  }
}
