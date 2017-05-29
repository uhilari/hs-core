using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public abstract class Consulta<T> : IConsulta<T>
  {
    public Consulta(ISessionFactory factory)
    {
      Sesion = factory.GetCurrentSession();
      ResultTransformer = null;
    }

    protected ISession Sesion { get; }
    protected IResultTransformer ResultTransformer { get; set; } 

    protected abstract string GetCadenaConsulta();
    protected abstract void SetParametros(IQuery query);
    protected abstract T EjecutarInterno(IQuery query);

    protected virtual IQuery CrearQuery()
    {
      return Sesion.CreateQuery(GetCadenaConsulta());
    }

    public T Ejecutar()
    {
      var query = CrearQuery();
      SetParametros(query);
      if (ResultTransformer != null)
        query.SetResultTransformer(ResultTransformer);
      return EjecutarInterno(query);
    }
  }
}
