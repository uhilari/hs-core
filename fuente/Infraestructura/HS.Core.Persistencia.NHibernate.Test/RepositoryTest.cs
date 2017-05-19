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
  public class RepositoryTest
  {
    private IRepository<Entidad> _repositorio;
    private Mock<ISession> _session;

    public RepositoryTest()
    {
      _session = new Mock<ISession>();
      _repositorio = new Repository<Entidad>(_session.Object);
    }

    [Fact]
    public void Constructor()
    {
      Assert.NotNull(_repositorio);
    }

    [Fact]
    public void Constructor_SessionNull()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        new Repository<Entidad>(null);
      });
    }

    [Fact]
    public void Agregar_Correcto()
    {
      var entidad = new Entidad();
      _repositorio.Agregar(entidad);
      _session.Verify(c => c.Save(entidad), Times.Once);
    }

    [Fact]
    public void Agregar_EntidadNull()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        _repositorio.Agregar(null);
      });
      _session.Verify(c => c.Save(It.IsAny<Entidad>()), Times.Never);
    }

    [Fact]
    public void BuscarUno_Correcto()
    {
      var id = Guid.NewGuid();
      _session.Setup(c => c.Get<Entidad>(id))
        .Returns(new Entidad());

      var entidad = _repositorio.BuscarUno(id);

      Assert.NotNull(entidad);
    }

    [Fact]
    public void BuscarUno_NoRegistro()
    {
      var id = Guid.NewGuid();
      _session.Setup(c => c.Get<Entidad>(id))
        .Returns((Entidad)null);
      Assert.Throws<NoRegistroException>(() =>
      {
        _repositorio.BuscarUno(id);
      });
    }
  }
}
