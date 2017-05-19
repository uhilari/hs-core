using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Core.Dominio.Test
{
  public class EntidadConcreta : EntityBase
  {
    public new Guid Id
    {
      get { return base.Id; }
      set { base.Id = value; }
    }
    public string Cadena { get; set; }
    public int Entero { get; set; }
  }
}
