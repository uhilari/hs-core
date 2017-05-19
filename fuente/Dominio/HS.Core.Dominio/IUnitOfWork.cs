using System;
using System.Collections.Generic;
using System.Text;

namespace HS
{
  public interface IUnitOfWork : IDisposable
  {
    void Complete();
  }
}
