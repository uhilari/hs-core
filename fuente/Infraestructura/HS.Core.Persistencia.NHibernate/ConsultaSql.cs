using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public abstract class ConsultaSql<T> : Consulta<T>
  {
    public ConsultaSql(ISessionFactory factory) : base(factory)
    {
    }

    protected override IQuery CrearQuery()
    {
      return Sesion.CreateSQLQuery(GetCadenaConsulta());
    }
  }
}
