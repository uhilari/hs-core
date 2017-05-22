using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Eventos
{
  public class AntesGrabarEntidad<T>: IDomainEvent where T: EntityBase
  {
    public AntesGrabarEntidad(T entidad)
    {
      Entidad = entidad;
    }

    public T Entidad { get; }
  }
}
