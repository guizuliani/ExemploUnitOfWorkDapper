using ExemploUnitOfWorkDapper.Infrastructure.Repositories;
using ExemploUnitOfWorkDapper.Infrastructure.UnitOfWorks;
using ExemploUnitOfWorkDapper.Infrastructure.UnitOfWorks.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ExemploUnitOfWorkDapper.App_Start
{
    public class SimpleInjectorConfig
    {

        public static void Configure()
        {
            var container = new Container();

            container.RegisterPerWebRequest<ISqlUnitOfWork, SqlUnitOfWork>();
            container.Register<IClienteRepository, ClienteRepository>();
            container.Register<SqlConnection>(() => new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString));

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

    }
}