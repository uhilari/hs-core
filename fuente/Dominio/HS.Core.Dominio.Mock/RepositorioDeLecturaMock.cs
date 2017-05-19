using Moq;
using System;
using System.Collections.Generic;

namespace HS.Core.Dominio.Mock
{
  public class RepositorioDeLecturaMock
  {
    private Dictionary<Guid, object> _repositorio;

    public RepositorioDeLecturaMock()
    {
      _repositorio = new Dictionary<Guid, object>();
    }

    public Mock<IFuturo<T>> PonerObjeto<T>(T valor, Guid id) where T: EntityBase
    {
      var mockFuturo = new Mock<IFuturo<T>>();
      mockFuturo.Setup(c => c.Valor)
        .Returns(valor);
      _repositorio.Add(id, mockFuturo);
      return mockFuturo;
    }

    public void Ejecutar()
    {
    }

    public IFuturo<T> Get<T>(Guid id) where T : EntityBase
    {
      return ((Mock<IFuturo<T>>)_repositorio[id]).Object;
    }
  }
}
