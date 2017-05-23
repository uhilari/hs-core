using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HS
{
  public static class GestorEventos
  {
    private const string KeyContext = "GESTOR-EVENTOS";

    public static IActivadorDeEventos Activador
    {
      get { return (IActivadorDeEventos)CallContext.LogicalGetData(KeyContext); }
      set { CallContext.LogicalSetData(KeyContext, value); }
    }

    public static void LanzarEvento<T>(T evento) where T: IDomainEvent
    {
      if (Activador != null)
        Activador.Activar(evento);
    }
  }
}
