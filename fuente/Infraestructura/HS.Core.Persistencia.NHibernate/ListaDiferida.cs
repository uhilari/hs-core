using NHibernate;
using NHibernate.Collection.Generic;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.Impl;
using NHibernate.Persister.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  internal class ListaDiferida<T> : PersistentGenericBag<T>, ILista<T> where T : EntityBase
  {
    public ListaDiferida(ISessionImplementor session) : base(session) { }

    public ListaDiferida(ISessionImplementor session, IEnumerable<T> collection) : base(session, collection) { }

    public string RolLista { get; set; }

    private ICriteria _crearCriteria()
    {
      var entry = this.Session.PersistenceContext.GetCollectionEntry(this);
      var persister = entry.LoadedPersister as OneToManyPersister;
      var criteria = new CriteriaImpl(typeof(T), Session);
      foreach (string columnName in persister.KeyColumnNames)
      {
        criteria.Add(NHibernate.Criterion.Expression.Sql(string.Format("this_.{0} = ?", columnName), Key, NHibernateUtil.Guid));
      }
      return criteria;
    }

    private T _Buscar(Expression<Func<T, bool>> expresion, Action<ICriteria> agregarFiltro)
    {
      T entidad = null;
      if (base.WasInitialized)
      {
        entidad = this.FirstOrDefault(expresion.Compile());
      }
      else
      {
        var criteria = _crearCriteria();
        agregarFiltro(criteria);
        entidad = criteria.UniqueResult<T>();
      }
      return entidad;
    }

    public void Agregar(T entidad)
    {
      entidad.NoEsNull(nameof(entidad));
      GestorEventos.LanzarEvento(new Eventos.AntesGrabarEntidad<T>(entidad));
      base.Add(entidad);
    }

    public T Buscar(Guid id)
    {
      return _Buscar(c => c.Id == id, cr =>
      {
        cr.Add(Restrictions.Eq("Id", id));
      });
    }

    public T Buscar(Expression<Func<T, bool>> expresion)
    {
      return _Buscar(expresion, cr =>
      {
        cr.Add(Restrictions.Where(expresion));
      });
    }

    public IEnumerable<T> Filtrar(Expression<Func<T, bool>> expresion)
    {
      IEnumerable<T> lista;
      if (base.WasInitialized)
      {
        lista = this.Where(expresion.Compile()).ToList();
      }
      else
      {
        var criteria = _crearCriteria();
        criteria.Add(Restrictions.Where(expresion));
        lista = criteria.List<T>();
      }
      return lista;
    }
  }
}
