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
        _entidad = new EntidadConcreta { Cadena = "Texto", Entero = 5 };
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
    }
  } 
}
