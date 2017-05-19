using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Core.Persistencia.NHibernate.Test
{
  public class Entidad: EntityBase
  {
    public virtual string Cadena { get; set; }
    public virtual int Entero { get; set; }
    public virtual ILista<LineaEntidad> Lineas { get; set; }
    public virtual void SetId(Guid id)
    {
      Id = id;
    }
  }

  public class LineaEntidad: EntityBase
  {
    public virtual Entidad Patron { get; set; }
    public virtual string Detalle { get; set; }
    public virtual decimal Precio { get; set; }
  }
}
