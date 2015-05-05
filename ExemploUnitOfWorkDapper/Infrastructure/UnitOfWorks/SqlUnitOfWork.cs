using ExemploUnitOfWorkDapper.Infrastructure.UnitOfWorks.Interfaces;
using System.Data.SqlClient;

namespace ExemploUnitOfWorkDapper.Infrastructure.UnitOfWorks
{
    public class SqlUnitOfWork : UnitOfWorkBase, ISqlUnitOfWork
    {

        public SqlUnitOfWork(SqlConnection connection)
            : base(connection)
        {
            //base.SetConnection(new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString));
        }

    }
}