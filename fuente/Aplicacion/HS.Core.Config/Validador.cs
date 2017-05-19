using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS
{
  class Validador<T> : IValidador<T> where T : EntityBase
  {
    private IKernel _kernel;

    public Validador(IKernel kernel)
    {
      _kernel = kernel;
    }

    public IEnumerable<Error> Validar(T entidad)
    {
      var validaciones = _kernel.ResolveAll<IValidacion<T>>();
      var errores = new List<Error>();
      foreach (var item in validaciones)
      {
        var error = item.Validar(entidad);
        if (error != null)
          errores.Add(error);
      }
      return errores;
    }
  }
}
