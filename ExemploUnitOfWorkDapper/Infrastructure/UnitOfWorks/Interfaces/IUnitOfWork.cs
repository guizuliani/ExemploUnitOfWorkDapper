using System.Data;

namespace ExemploUnitOfWorkDapper.Infrastructure.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork
    {

        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void BeginTransaction();
        void SaveChanges();

    }
}
