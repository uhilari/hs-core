using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class CustomMapper : Mapper<DtoConcreta, EntidadConcreta>
  {
    public CustomMapper(IGenericRepository repository) : base(repository)
    {
    }

    public void PonerDtoConstante()
    {
      DestinoDto(c => c.Edad).Constante(35);
    }

    public void PonerDtoPropiedad()
    {
      DestinoDto(c => c.Cadena).Funcion(c => c.Cadena);
    }
  }
}
