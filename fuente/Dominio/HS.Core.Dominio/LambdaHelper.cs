using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class LambdaHelper
  {
    public static PropertyInfo GetPropertyInfo<T, S>(Expression<Func<T, S>> expr)
    {
      var member = expr.Body as MemberExpression;
      if (member == null)
        throw new InvalidOperationException("Require un MemberExpression");

      var property = member.Member as PropertyInfo;
      if (property == null)
        throw new InvalidOperationException("Requiere una propiedad");

      return property;
    }
  }
}
