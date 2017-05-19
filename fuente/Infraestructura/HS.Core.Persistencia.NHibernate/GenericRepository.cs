using NHibernate;
using NHibernate.Engine;
using NHibernate.Persister.Entity;
using NHibernate.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class GenericRepository : IGenericRepository
  {
    private ISession _session;
    private IList<Task> _tareas = new List<Task>();

    public GenericRepository(ISessionFactory sessionFactory)
    {
      _session = sessionFactory.NoEsNull(nameof(sessionFactory)).GetCurrentSession();
    }

    public void Ejecutar()
    {
      Task.WaitAll(_tareas.ToArray());
    }

    public T Get<T>(Guid id) where T: EntityBase
    {
      return _session.Get<T>(id).ValidarNoNull();
    }

    public IFuturo<T> GetFuturo<T>(Guid id) where T : EntityBase
    {
      var tarea = Task.Run(() =>
      {
        T entidad = null;
        using (var sessionStateless = _session.SessionFactory.OpenStatelessSession())
        {
          entidad = sessionStateless.Get<T>(id);
        }

        IEntityPersister persister = _session.GetSessionImplementation().GetEntityPersister(NHibernateProxyHelper.GuessClass(entidad).FullName, entidad);
        object[] fields = persister.GetPropertyValues(entidad, _session.ActiveEntityMode);
        object oid = persister.GetIdentifier(entidad, _session.ActiveEntityMode);
        EntityEntry entry = _session.GetSessionImplementation().PersistenceContext.AddEntry(entidad, Status.Loaded, fields, null, id, null, LockMode.None, true, persister, true, false);

        return entidad;
      });
      _tareas.Add(tarea);
      return new Futuro<T>(tarea);
    }
  }
}
