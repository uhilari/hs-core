using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public interface IManejadorDeEvento<T> where T: IDomainEvent
  {
    void Ejecutar(T evento);
  }
}
