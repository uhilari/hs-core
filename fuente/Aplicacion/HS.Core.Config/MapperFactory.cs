using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  class MapperFactory : IMapperFactory
  {
    private IKernel _kernel;

    public MapperFactory(IKernel kernel)
    {
      _kernel = kernel;
    }

    public IMapper<TDto, TEntity> GetMapper<TDto, TEntity>()
      where TDto : class
      where TEntity : EntityBase
    {
      return _kernel.Resolve<IMapper<TDto, TEntity>>();
    }
  }
}
