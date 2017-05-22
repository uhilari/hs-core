using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class Repository<T> : IRepository<T> where T : EntityBase
  {
    private ISession _session;

    public Repository(ISessionFactory sessionFactory)
    {
      _session = sessionFactory.NoEsNull(nameof(sessionFactory)).GetCurrentSession();
    }

    protected ISession Session => _session;

    public void Agregar(T entidad)
    {
      entidad.NoEsNull(nameof(entidad));
      GestorEventos.LanzarEvento(new Eventos.AntesGrabarEntidad<T>(entidad));
      _session.Save(entidad);
    }

    public T BuscarUno(Guid id)
    {
      return BuscarUnoONull(id).ValidarNoNull();
    }

    public T BuscarUno(Expression<Func<T, bool>> expresion)
    {
      return BuscarUnoONull(expresion).ValidarNoNull();
    }

    public T BuscarUnoONull(Guid id)
    {
      return _session.Get<T>(id);
    }

    public T BuscarUnoONull(Expression<Func<T, bool>> expresion)
    {
      expresion.NoEsNull(nameof(expresion));
      return _session.Query<T>()
        .FirstOrDefault(expresion);
    }

    public List<T> BuscarVarios(Expression<Func<T, bool>> expresion)
    {
      return _session.Query<T>()
        .Where(expresion)
        .ToList();
    }
  }
}
