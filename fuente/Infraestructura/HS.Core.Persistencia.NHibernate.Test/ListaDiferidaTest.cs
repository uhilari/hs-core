using log4net;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace HS.Core.Persistencia.NHibernate.Test
{
  public class ListaDiferidaTest
  {
    private ILog _log;
    private Guid _id;

    public ListaDiferidaTest()
    {
      _log = LogManager.GetLogger(GetType());
      InMemorySessionFactoryProvider.Instancia.Inicializar();
      using (var generator = DataGenerator.Instancia()) {
        generator.AddEntidad();
        generator.Grabar();
        _id = generator.GetIds()[1];
      }
    }

    ~ListaDiferidaTest()
    {
      InMemorySessionFactoryProvider.Instancia.Dispose();
    }

    [Fact]
    public void CrearLista()
    {
      _log.Warn("Inicio de CrearLista");
      using (var session = InMemorySessionFactoryProvider.Instancia.AbrirSession())
      {
        var entidad = session.Get<Entidad>(_id);
        //var linea = entidad.Lineas[1];
        var hijo = entidad.Lineas.Buscar(Guid.NewGuid());
        entidad.Lineas.Filtrar(c => c.Precio > 40);
      }
    }
  }
}
