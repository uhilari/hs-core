using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HS
{
  public static class Extensiones
  {
    public static T NoEsNull<T>(this T entidad, string nombre)
      where T: class
    {
      if (entidad == null)
        throw new ArgumentNullException(nombre);
      return entidad;
    }

    public static string NoEsNull(this string cadena, string nombre)
    {
      if (string.IsNullOrEmpty(cadena))
        throw new ArgumentNullException(nombre);
      return cadena;
    }

    public static string Cadena(this Guid id)
    {
      return Convert.ToBase64String(id.ToByteArray())
        .Replace("/", "-")
        .Replace("+", "_")
        .Replace("=", "");
    }

    public static string Cadena(this Guid? id)
    {
      if (id.HasValue)
        return Cadena(id.Value);
      return null;
    }

    public static bool EsGuid(this string cadena)
    {
      if (string.IsNullOrEmpty(cadena))
        return false;
      return Regex.IsMatch(cadena, "[a-zA-Z0-9_-]{22}");
    }

    public static Guid Guid(this string cadena)
    {
      if (string.IsNullOrEmpty(cadena)) throw new ArgumentNullException(nameof(cadena));
      if (!EsGuid(cadena)) throw new FormatException();

      var tmp = cadena.Replace("-", "/")
        .Replace("_", "+");
      return new Guid(Convert.FromBase64String(tmp + "=="));
    }

    public static Guid? GuidONull(this string cadena)
    {
      if (string.IsNullOrEmpty(cadena))
        return null;

      return Guid(cadena);
    }

    public static string Cadena(this int numero, int longitud)
    {
      if (!EsPositivo(numero)) throw new InvalidOperationException("Numero no puede ser negativo");
      if (!EsPositivo(longitud)) throw new InvalidOperationException("Longitud no puede ser negativo");

      string cadena = numero.ToString();
      while(cadena.Length < longitud)
      {
        cadena = "0" + cadena;
      }
      return cadena;
    }

    public static bool EsPositivo(this int numero)
    {
      return (numero >= 0);
    }

    public static bool EsPositivo(this long numero)
    {
      return (numero >= 0L);
    }

    public static bool EsPositivo(this float numero)
    {
      return (numero >= 0f);
    }

    public static bool EsPositivo(this decimal numero)
    {
      return (numero >= 0m);
    }

    public static ILista<T> ToLista<T>(this IEnumerable<T> enumerable) where T: EntityBase
    {
      var lista = new Lista<T>();
      lista.AddRange(enumerable);
      return lista;
    }

    public static bool EsHijo(this Type tipo, Type tipoBase)
    {
      return tipoBase.IsAssignableFrom(tipo);
    }
  }
}
