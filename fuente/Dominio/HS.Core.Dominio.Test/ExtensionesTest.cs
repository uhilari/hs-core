using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HS.Core.Dominio.Test
{
  public class ExtensionesTest
  {
    [Fact]
    public void Cadena_1Digito()
    {
      int nro = 5;
      var str = nro.Cadena(6);

      Assert.Equal("000005", str);
    }

    [Fact]
    public void Cadena_3Digitos()
    {
      int nro = 123;
      var str = nro.Cadena(7);

      Assert.Equal("0000123", str);
    }

    [Fact]
    public void Cadena_LongitudMenorDigitos()
    {
      int nro = 1234;
      var str = nro.Cadena(3);

      Assert.Equal("1234", str);
    }

    [Fact]
    public void Cadena_NumeroNegativo()
    {
      int nro = -12;
      Assert.Throws<InvalidOperationException>(() =>
      {
        nro.Cadena(5);
      });
    }

    [Fact]
    public void Cadena_LongitudNegativa()
    {
      int nro = 12;
      Assert.Throws<InvalidOperationException>(() =>
      {
        nro.Cadena(-4);
      });
    }

    [Fact]
    public void EsPositivo_Verdadero()
    {
      int nro = 12;

      Assert.True(nro.EsPositivo());
    }

    [Fact]
    public void EsPositivo_Falso()
    {
      int nro = -12;

      Assert.False(nro.EsPositivo());
    }

    [Fact]
    public void Guid_ArgumentNotNull()
    {
      string cadena = null;
      Assert.Throws<ArgumentNullException>(() =>
      {
        cadena.Guid();
      });
    }

    [Fact]
    public void Guid_StringNotFormat()
    {
      string cadena = "00amyWGc.0y_ze4lIsj2Mw";
      Assert.Throws<FormatException>(() =>
      {
        cadena.Guid();
      });
    }

    [Fact]
    public void Guid_Valido()
    {
      string cadena = "00amyWGct0y_ze4lIsj2Mw";
      Guid id = Guid.Parse("c9a646d3-9c61-4cb7-becd-ee2522c8f633");

      var respuesta = cadena.Guid();

      Assert.Equal(id, respuesta);
    }
  }
}
