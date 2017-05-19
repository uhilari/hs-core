using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HS
{
  public static class ContainerExtensions
  {
    public static IWindsorContainer RegisterCore(this IWindsorContainer container)
    {
      return container
        .CoreDominio();
    }

    public static IWindsorContainer RegisterAppService<TInterfaz, TClass>(this IWindsorContainer container) 
      where TClass: TInterfaz
      where TInterfaz: class
    {
      return container.Register(Component.For<TInterfaz>().ImplementedBy<TClass>().Interceptors(typeof(UnitOfWorkInterceptor)).LifestyleTransient());
    }

    public static IWindsorContainer RegisterDependency<TClass>(this IWindsorContainer container)
      where TClass: class
    {
      return container.Register(Component.For<TClass>().LifestyleTransient());
    }

    public static IWindsorContainer RegisterDependency(this IWindsorContainer container, Type tipoClase)
    {
      return container.Register(Component.For(tipoClase).LifestyleTransient());
    }

    public static IWindsorContainer RegisterDependency<TInterfaz, TClass>(this IWindsorContainer container)
      where TClass: TInterfaz
      where TInterfaz: class
    {
      return container.Register(Component.For<TInterfaz>().ImplementedBy<TClass>().LifestyleTransient());
    }

    public static IWindsorContainer RegisterDependency(this IWindsorContainer container, Type tipoInterfaz, Type tipoClase)
    {
      return container.Register(Component.For(tipoInterfaz).ImplementedBy(tipoClase).LifestyleTransient());
    }

    public static IWindsorContainer CoreAplicacion(this IWindsorContainer container)
    {
      return container
        .RegisterDependency<UnitOfWorkInterceptor>()
        .RegisterDependency<IServiceFactory, ServiceFactory>()
        .RegisterDependency(typeof(IMapper<,>), typeof(Mapper<,>));
    }

    public static IWindsorContainer CoreDominio(this IWindsorContainer container)
    {
      GestorEventos.Activador = new ActivadorDeEventos(container.Kernel);

      return container
        .Register(Component.For<IKernel>().Instance(container.Kernel))
        .RegisterDependency(typeof(IValidador<>), typeof(Validador<>));
    }

    public static IWindsorContainer CorePersistencia(this IWindsorContainer container)
    {
      return container
        .RegisterDependency<IUnitOfWork, NHUnitOfWork>()
        .RegisterDependency(typeof(IRepository<>), typeof(Repository<>))
        .RegisterDependency<IGenericRepository, GenericRepository>();

    }
  }
}
