using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class CustomMapper : MapperOld<DtoConcreta, EntidadConcreta>
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

    public void PonerDtoEnlace()
    {
      ReferenciaDto(c => c.IdEstatica).Referencia(c => c.Estatica);
    }

    public void PonerEntityEnlace()
    {
      ReferenciaEntity(c => c.Estatica).Referencia(c => c.IdEstatica);
    }
  }
}
