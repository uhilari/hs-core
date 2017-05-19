using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Core.Persistencia.NHibernate.Test
{
  public class DataGenerator: IDisposable
  {
    public static DataGenerator Instancia()
    {
      return new DataGenerator();
    }

    private ISession _session;
    private IList<Guid> _listaIds = new List<Guid>();

    public DataGenerator()
    {
      _session = InMemorySessionFactoryProvider.Instancia.AbrirSession(true);
    }

    public DataGenerator AddEntidad()
    {
      var entidad = new Entidad
      {
        Entero = 1,
        Cadena = "UNO",
        Lineas = new Lista<LineaEntidad>
        {
          new LineaEntidad{ Detalle = "UNO UNO", Precio = 11 },
          new LineaEntidad{ Detalle = "UNO DOS", Precio = 12 },
          new LineaEntidad{ Detalle = "UNO TRES", Precio = 13 }
        }
      };
      _session.Save(entidad);
      _listaIds.Add(entidad.Id);

      entidad = new Entidad
      {
        Entero = 2,
        Cadena = "DOS",
        Lineas = new Lista<LineaEntidad>
        {
          new LineaEntidad{ Detalle = "DOS UNO", Precio = 21 },
          new LineaEntidad{ Detalle = "DOS DOS", Precio = 22 },
          new LineaEntidad{ Detalle = "DOS TRES", Precio = 23 }
        }
      };
      _session.Save(entidad);
      _listaIds.Add(entidad.Id);

      entidad = new Entidad
      {
        Entero = 3,
        Cadena = "TRES",
        Lineas = new Lista<LineaEntidad>
        {
          new LineaEntidad{ Detalle = "TRES UNO", Precio = 31 },
          new LineaEntidad{ Detalle = "TRES DOS", Precio = 32 },
          new LineaEntidad{ Detalle = "TRES TRES", Precio = 33 }
        }
      };
      _session.Save(entidad);
      _listaIds.Add(entidad.Id);

      entidad = new Entidad
      {
        Entero = 4,
        Cadena = "CUATRO",
        Lineas = new Lista<LineaEntidad>
        {
          new LineaEntidad{ Detalle = "CUATRO UNO", Precio = 41 },
          new LineaEntidad{ Detalle = "CUATRO DOS", Precio = 42 },
          new LineaEntidad{ Detalle = "CUATRO TRES", Precio = 43 }
        }
      };
      _session.Save(entidad);
      _listaIds.Add(entidad.Id);

      return this;
    }

    public Guid[] GetIds()
    {
      return _listaIds.ToArray();
    }

    public DataGenerator Grabar()
    {
      _session.Flush();
      return this;
    }

    public void Dispose()
    {
      _session.Dispose();
    }
  }
}
