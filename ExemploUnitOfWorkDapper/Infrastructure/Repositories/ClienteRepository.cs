using Dapper;
using ExemploUnitOfWorkDapper.Infrastructure.UnitOfWorks.Interfaces;
using ExemploUnitOfWorkDapper.Models;
using System;
using System.Collections.Generic;

namespace ExemploUnitOfWorkDapper.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly ISqlUnitOfWork _unitOfWork;

        public ClienteRepository(ISqlUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            var sql = "select * from Clientes";

            var clientes = _unitOfWork.Connection.Query<Cliente>(sql, null, _unitOfWork.Transaction);

            return clientes;
        }

        public void Adicionar(Cliente cliente)
        {
            var sql = "insert into Clientes values (@ClienteId, @Nome, @Sobrenome, @DataModificacao)";

            _unitOfWork.Connection.Execute(sql, new
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,
                DataModificacao = "1900-01-01"
            }, _unitOfWork.Transaction);
        }

        public void AtualizarData(Guid clienteId, DateTime data)
        {
            var sql = "update Clientes set DataModificacao = @DataModificacao where ClienteId = @ClienteId";

            _unitOfWork.Connection.Execute(sql, new { ClienteId = clienteId, DataModificacao = data }, _unitOfWork.Transaction);
        }

    }
}