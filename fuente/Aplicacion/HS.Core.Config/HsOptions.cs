using Castle.Windsor;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public class HsOptions
  {
    public Action<IAppBuilder> PreWebApi { get; set; }
    public Action<IWindsorContainer> CfgContainer { get; set; }
  }
}
