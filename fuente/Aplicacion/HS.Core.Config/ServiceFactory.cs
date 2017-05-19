using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class ServiceFactory : IServiceFactory
  {
    private IKernel _kernel;

    public ServiceFactory(IKernel kernel)
    {
      _kernel = kernel;
    }

    public ICrudService<TDto> CreateCrud<TDto>() where TDto: class
    {
      return _kernel.Resolve<ICrudService<TDto>>();
    }

    public ICrudService<TDto> CreateCrud<TDto>(string entidad) where TDto : class
    {
      return _kernel.Resolve<ICrudService<TDto>>(entidad);
    }
  }
}
