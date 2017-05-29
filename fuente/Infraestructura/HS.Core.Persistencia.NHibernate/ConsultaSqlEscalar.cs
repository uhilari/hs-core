using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace HS
{
  public abstract class ConsultaSqlEscalar<T> : ConsultaSql<T>
  {
    public ConsultaSqlEscalar(ISessionFactory factory) : base(factory)
    {
    }

    protected override T EjecutarInterno(IQuery query)
    {
      return query.UniqueResult<T>();
    }
  }
}
