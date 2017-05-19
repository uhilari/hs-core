using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public interface ICrudService<T> where T: class
  {
    T Get(string id);
    void Crear(T dto);
    void Actualizar(string id, T dto);
    void Anular(string id);
  }
}
