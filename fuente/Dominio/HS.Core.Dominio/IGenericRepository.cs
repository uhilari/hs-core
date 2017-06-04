using System;
using System.Collections.Generic;
using System.Text;

namespace HS
{
  public interface IGenericRepository
  {
    T Get<T>(Guid? id) where T : EntityBase;
    IFuturo<T> GetFuturo<T>(Guid id) where T : EntityBase;
    void Ejecutar();
  }
}
