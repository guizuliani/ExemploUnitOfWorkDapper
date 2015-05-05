using ExemploUnitOfWorkDapper.Models;
using System;
using System.Collections.Generic;

namespace ExemploUnitOfWorkDapper.Infrastructure.Repositories
{
    public interface IClienteRepository
    {

        IEnumerable<Cliente> ObterTodos();
        void Adicionar(Cliente cliente);
        void AtualizarData(Guid clienteId, DateTime data);

    }
}
