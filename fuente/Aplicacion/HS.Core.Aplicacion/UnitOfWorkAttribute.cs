using System;
using System.Collections.Generic;
using System.Text;

namespace HS
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
  public sealed class UnitOfWorkAttribute : Attribute
  {
  }
}
