using AuthenticationAuthorization.IRepository;
using AuthenticationAuthorization.Repository;
using Autofac;

namespace AuthenticationAuthorization
{
    public class DependencyContainer
    {
        internal static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<AppUsers>().As<IAppUsers>();
        }
    }
}
