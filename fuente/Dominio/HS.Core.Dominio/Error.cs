using System;
using System.Collections.Generic;
using System.Text;

namespace HS
{
  public class Error
  {
    public Error(string codigo, string descripcion)
    {
      Codigo = codigo;
      Descripcion = descripcion;
    }

    public string Codigo { get; }
    public string Descripcion { get; }
  }
}
