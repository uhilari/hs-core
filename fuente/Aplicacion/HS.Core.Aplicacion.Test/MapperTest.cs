using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HS.Core.Aplicacion.Test
{
  public class MapperTest
  {
    public class Base
    {
      protected CustomMapper Mapper { get; }
      protected Mock<IGenericRepository> Repository { get; }

      public Base()
      {
        Repository = new Mock<IGenericRepository>();
        Mapper = new CustomMapper(Repository.Object);
      }
    }

    public class CrearDto: Base
    {
      private EntidadConcreta _entidad;

      public CrearDto()
      {
        var estatica = new EntidadEstatic();
        estatica.SetId(Guid.Parse("31e7cfef-c354-407b-b6ed-60b5240debaa"));
        _entidad = new EntidadConcreta { Cadena = "Texto", Entero = 5, Estatica = estatica };
      }

      [Fact]
      public void Result_NotNull()
      {
        var dto = Mapper.CrearDto(_entidad);
        Assert.NotNull(dto);
      }

      [Fact]
      public void SinMapeo()
      {
        var dto = Mapper.CrearDto(_entidad);
        Assert.Equal(default(int), dto.SoloDto);
      }

      [Fact]
      public void ValorConstante()
      {
        Mapper.PonerDtoConstante();
        var dto = Mapper.CrearDto(_entidad);
        Assert.Equal(35, dto.Edad);
      }

      [Fact]
      public void ValorPropiedad()
      {
        Mapper.PonerDtoPropiedad();
        var dto = Mapper.CrearDto(_entidad);
        Assert.Equal("Texto", dto.Cadena);
      }

      [Fact]
      public void ValorReferencia()
      {
        Mapper.PonerDtoEnlace();
        var dto = Mapper.CrearDto(_entidad);
        Assert.Equal("78-nMVTDe0C27WC1JA3rqg", dto.IdEstatica);
      }
    }

    public class CrearEntity: Base
    {
      public DtoConcreta _dto;

      public CrearEntity()
      {
        _dto = new DtoConcreta { Cadena = "Texto", IdEstatica = "78-nMVTDe0C27WC1JA3rqg" };
      }

      [Fact]
      public void EntidadNoNull()
      {
        var entidad = Mapper.CrearEntity(_dto);
        Assert.NotNull(entidad);
      }

      [Fact]
      public void ValorReferencia()
      {
        Mapper.PonerEntityEnlace();
        Repository.Setup(c => c.Get<EntidadEstatic>(Guid.Parse("31e7cfef-c354-407b-b6ed-60b5240debaa")))
          .Returns(new EntidadEstatic());
        var entidad = Mapper.CrearEntity(_dto);
        Assert.NotNull(entidad.Estatica);
      }
    }
  } 
}
