using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.ImplMapper
{
  class OrigenConstante<T> : IOrigen<T>
  {
    private object _valor;

    public OrigenConstante(T valor)
    {
      _valor = valor;
    }

    public T GetValor(object objeto)
    {
      return (T)_valor;
    }
  }
}
