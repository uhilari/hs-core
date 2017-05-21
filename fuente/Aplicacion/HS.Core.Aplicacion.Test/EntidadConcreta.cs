using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class EntidadConcreta: EntityBase
  {
    public string Cadena { get; set; }
    public int Entero { get; set; }
    public EntidadEstatic Estatica { get; set; }
  }

  public class EntidadEstatic : EntityBase
  {
    public decimal Real { get; set; }

    public void SetId(Guid id)
    {
      base.Id = id;
    }
  }
}
