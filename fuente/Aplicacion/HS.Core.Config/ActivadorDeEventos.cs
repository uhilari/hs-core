using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  class ActivadorDeEventos : IActivadorDeEventos
  {
    private IKernel _kernel;

    public ActivadorDeEventos(IKernel kernel)
    {
      _kernel = kernel;
    }

    public void Activar<T>(T evento) where T: IDomainEvent
    {
      var manejadores = _kernel.ResolveAll<IManejadorDeEvento<T>>();
      foreach (var manejador in manejadores)
      {
        manejador.Ejecutar(evento);
      }
    }
  }
}
