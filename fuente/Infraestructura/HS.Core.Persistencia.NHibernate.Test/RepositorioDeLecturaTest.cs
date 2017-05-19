using Moq;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HS.Core.Persistencia.NHibernate.Test
{
  public class RepositorioDeLecturaTest
  {
    private IGenericRepository _repositorio;
    private Mock<ISession> session;

    public RepositorioDeLecturaTest()
    {
      session = new Mock<ISession>();
      _repositorio = new GenericRepository(session.Object);
    }

    [Fact]
    public void Get_NoNull()
    {
      var entidad = _repositorio.Get<Entidad>(Guid.NewGuid());
      Assert.NotNull(entidad);
    }

    [Fact]
    public void Get_NoEjecutar()
    {
      var entidad = _repositorio.Get<Entidad>(Guid.NewGuid());
      Assert.Throws<FuturoNoEjecutadoException>(() =>
      {
        entidad.Valor.Cadena.ToString();
      });
    }
  }
}
