using ExemploUnitOfWorkDapper.Models;
using System.Data.Entity;

namespace ExemploUnitOfWorkDapper.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {

        public DataContext()
            : base("DefaultConnectionString")
        {

        }

        public IDbSet<Cliente> Clientes { get; set; }

    }
}