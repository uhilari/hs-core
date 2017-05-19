using System;
using Xunit;

namespace HS.Core.Dominio.Test
{
  public class EntidadTest
  {
    [Fact]
    public void Equals_Iguales()
    {
      Guid id = Guid.NewGuid();
      EntidadConcreta entidadA = new EntidadConcreta { Id = id };
      EntidadConcreta entidadB = new EntidadConcreta { Id = id };

      Assert.True(entidadA.Equals(entidadB));
    }

    [Fact]
    public void Equals_MismoObjeto()
    {
      EntidadConcreta entidadA = new EntidadConcreta { Id = Guid.NewGuid() };

#pragma warning disable RECS0088 // Comparing equal expression for equality is usually useless
      Assert.True(entidadA.Equals(entidadA));
#pragma warning restore RECS0088 // Comparing equal expression for equality is usually useless
    }

    [Fact]
    public void Equals_Diferentes()
    {
      EntidadConcreta entidadA = new EntidadConcreta { Id = Guid.NewGuid() };
      EntidadConcreta entidadB = new EntidadConcreta { Id = Guid.NewGuid() };

      Assert.False(entidadA.Equals(entidadB));
    }

    [Fact]
    public void Equals_DiferentesSinId()
    {
      EntidadConcreta entidadA = new EntidadConcreta();
      EntidadConcreta entidadB = new EntidadConcreta();

      Assert.False(entidadA.Equals(entidadB));
    }

    [Fact]
    public void Equals_ConOtraClase()
    {
      EntidadConcreta entidadA = new EntidadConcreta { Id = Guid.NewGuid() };
      var entidadB = new { Id = Guid.NewGuid() };

      Assert.False(entidadA.Equals(entidadB));
    }

    [Fact]
    public void Equals_ConNull()
    {
      EntidadConcreta entidadA = new EntidadConcreta { Id = Guid.NewGuid() };

      Assert.False(entidadA.Equals(null));
    }

    [Fact]
    public void OperadorIgual_Iguales()
    {
      Guid id = Guid.NewGuid();
      EntidadConcreta entidadA = new EntidadConcreta { Id = id };
      EntidadConcreta entidadB = new EntidadConcreta { Id = id };

      Assert.True(entidadA == entidadB);
    }

    [Fact]
    public void OperadorIgual_IzqdaNull()
    {
      EntidadConcreta entidadB = new EntidadConcreta { Id = Guid.NewGuid() };

      Assert.False(null == entidadB);
    }

    [Fact]
    public void OperadorIgual_DrchaNull()
    {
      EntidadConcreta entidadA = new EntidadConcreta { Id = Guid.NewGuid() };

      Assert.False(entidadA == null);
    }

    [Fact]
    public void OperadorIgual_AmbosNull()
    {
      EntidadConcreta entidadA = null;
      EntidadConcreta entidadB = null;

      Assert.True(entidadA == entidadB);
    }
  }
}
