using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class NHUnitOfWork : IUnitOfWork
  {
    private ITransaction _transaccion;

    public NHUnitOfWork(ISessionFactory sessionFactory)
    {
      _transaccion = sessionFactory.GetCurrentSession().BeginTransaction();
    }

    public void Complete()
    {
      _transaccion.Commit();
    }

    public void Dispose()
    {
      if (_transaccion.IsActive)
      {
        _transaccion.Rollback();
      }
      _transaccion.Dispose();
    }
  }
}
