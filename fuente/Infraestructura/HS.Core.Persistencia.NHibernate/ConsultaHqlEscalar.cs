using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public abstract class ConsultaHqlEscalar<T> : Consulta<T>
  {
    public ConsultaHqlEscalar(ISessionFactory factory) : base(factory)
    {
    }

    protected override T EjecutarInterno(IQuery query)
    {
      return query.UniqueResult<T>();
    }
  }
}
