﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public interface IMapperFactory
  {
    IMapper<TDto, TEntity> GetMapper<TDto, TEntity>()
      where TDto : class
      where TEntity : EntityBase;
  }
}
