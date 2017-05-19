using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public interface IServiceFactory
  {
    ICrudService<TDto> CreateCrud<TDto>() where TDto : class;
    ICrudService<TDto> CreateCrud<TDto>(string entidad) where TDto : class;
  }
}
