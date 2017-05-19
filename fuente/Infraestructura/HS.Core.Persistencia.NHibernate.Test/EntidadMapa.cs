using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Core.Persistencia.NHibernate.Test
{
  public class EntidadMapa: EntityMap<Entidad>
  {
    public EntidadMapa()
    {
      Property(c => c.Entero);
      Property(c => c.Cadena, m => m.Length(100));
      Lista(c => c.Lineas, "IdEntidad");
    }
  }
}
