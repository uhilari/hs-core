using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using NHibernate.UserTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class ListaDiferidaFactory<T> : IUserCollectionType
    where T: EntityBase
  {
    public bool Contains(object collection, object entity)
    {
      return ((ICollection<T>)collection).Contains((T)entity);
    }

    public IEnumerable GetElements(object collection)
    {
      return (IEnumerable)collection;
    }

    public object IndexOf(object collection, object entity)
    {
      return ((IList<T>)collection).IndexOf((T)entity);
    }

    public IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister)
    {
      return new ListaDiferida<T>(session);
    }

    public object Instantiate(int anticipatedSize)
    {
      return new Lista<T>();
    }

    public object ReplaceElements(object original, object target, ICollectionPersister persister, object owner, IDictionary copyCache, ISessionImplementor session)
    {
      IList<T> result = (IList<T>)target;
      result.Clear();
      foreach (T item in ((IEnumerable)original))
      {
        result.Add(item);
      }
      return result;
    }

    public IPersistentCollection Wrap(ISessionImplementor session, object collection)
    {
      return new ListaDiferida<T>(session, (IEnumerable<T>)collection);
    }
  }
}
