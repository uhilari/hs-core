using System;
using System.Collections.Generic;
using System.Text;

namespace HS
{
  public interface IActivadorDeEventos
  {
    void Activar<T>(T evento) where T: IDomainEvent;
  }
}
