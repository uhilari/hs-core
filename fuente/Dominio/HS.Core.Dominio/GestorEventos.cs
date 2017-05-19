using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HS
{
  public static class GestorEventos
  {
    [ThreadStatic]
    private static IActivadorDeEventos _activador = null;

    public static IActivadorDeEventos Activador { get => _activador; set => _activador = value; }

    public static void LanzarEvento(IDomainEvent evento)
    {
      if (_activador != null)
        _activador.Activar(evento);
    }
  }
}
