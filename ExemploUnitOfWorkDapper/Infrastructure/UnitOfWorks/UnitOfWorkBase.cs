using ExemploUnitOfWorkDapper.Infrastructure.UnitOfWorks.Interfaces;
using System;
using System.Data;

namespace ExemploUnitOfWorkDapper.Infrastructure.UnitOfWorks
{
    public class UnitOfWorkBase : IUnitOfWork, IDisposable
    {

        private bool _disposed = false;

        public IDbConnection Connection { get; private set; }
        public IDbTransaction Transaction { get; private set; }

        protected UnitOfWorkBase()
        {

        }

        public UnitOfWorkBase(IDbConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("Conexão IDbConnection não informada corretamente.");

            Connection = connection;
        }

        protected void SetConnection(IDbConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("Conexão IDbConnection não informada corretamente.");

            Connection = connection;
        }

        public void BeginTransaction()
        {
            if (Connection == null)
                throw new InvalidOperationException("Conexão IDbConnection não inicializada corretamente.");

            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void SaveChanges()
        {
            if (Connection == null)
                throw new InvalidOperationException("Conexão IDbConnection não inicializada corretamente.");

            if (Transaction == null)
                throw new InvalidOperationException("Transação IDbTransaction não inicializada corretamente.");

            Transaction.Commit();
            Connection.Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if ((Connection != null) && (Connection.State == ConnectionState.Open) && (Transaction != null))
                    {
                        Transaction.Rollback();
                        Connection.Close();
                    }

                    if (Transaction != null)
                        Transaction.Dispose();

                    if (Connection != null)
                        Connection.Dispose();
                }

                _disposed = true;
            }
        }

    }
}