using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Event;
using NHibernate.Event.Default;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS.Core.Persistencia.NHibernate.Test
{
  public class InMemorySessionFactoryProvider: IDisposable
  {
    private static InMemorySessionFactoryProvider _instancia;

    public static InMemorySessionFactoryProvider Instancia
    {
      get { return _instancia ?? (_instancia = new InMemorySessionFactoryProvider()); }
    }

    private ISessionFactory _sessionFactory;
    private Configuration _configuration;

    private InMemorySessionFactoryProvider()
    {
    }

    public void Inicializar()
    {
      var cfg = _configuration = new Configuration();
      cfg.DataBaseIntegration(db =>
      {
        db.ConnectionString = "Data Source=nhibernate.db;Version=3";
        db.Dialect<SQLiteDialect>();
        db.Driver<SQLite20Driver>();
      });
      var mapper = new ModelMapper();
      mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
      cfg.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), "NHAlmacen");
      //cfg.EventListeners.LoadEventListeners = new ILoadEventListener[] { new LoadListener(), new DefaultLoadEventListener() };
      //cfg.EventListeners.PostLoadEventListeners = new IPostLoadEventListener[] { new LoadListener(), new DefaultPostLoadEventListener() };
      cfg.EventListeners.InitializeCollectionEventListeners = new IInitializeCollectionEventListener[]
      {
        new LoadListener(),
        new DefaultInitializeCollectionEventListener()
      };
      _sessionFactory = cfg.BuildSessionFactory();
    }

    public ISession AbrirSession(bool exportSchema = false)
    {
      ISession session = _sessionFactory.OpenSession();

      if (exportSchema)
      {
        var export = new SchemaExport(_configuration);
        export.Execute(true, true, false, session.Connection, null);
      }

      return session;
    }

    public void Dispose()
    {
      if (_sessionFactory != null)
        _sessionFactory.Dispose();

      _sessionFactory = null;
      _configuration = null;
    }
  }
}
