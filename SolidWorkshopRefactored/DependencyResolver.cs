using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using SolidWorkshopRefactored.Factory;

namespace SolidWorkshopRefactored
{
    public class DependencyResolver : NinjectModule
    {
        public override void Load()
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            Bind<IEntityRepository>().To<EntityRepository>();
            Bind<IService>().To<Service>();
            Bind<IDbConnection>().To<SqlConnection>().WithConstructorArgument("connectionString", connectionString);
            Bind<IConnectionFactory>().ToFactory();
        }
    }
}
