using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  class ConsultaFactory: IConsultaFactory
  {
    private IKernel _kernel;

    public ConsultaFactory(IKernel kernel)
    {
      _kernel = kernel;
    }

    public T CrearConsulta<T>()
    {
      return _kernel.Resolve<T>();
    }
  }
}
