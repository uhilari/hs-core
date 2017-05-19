using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Core.Persistencia.NHibernate.Test
{
  public class LineaMapa: ClassMapping<LineaEntidad>
  {
    public LineaMapa()
    {
      Id(c => c.Id, m => m.Generator(Generators.GuidComb));
      Property(c => c.Detalle, m => m.Length(250));
      Property(c => c.Precio);
      Property(c => c.Eliminado);
      ManyToOne(c => c.Patron, m => m.Column("IdEntidad"));
    }
  }
}
