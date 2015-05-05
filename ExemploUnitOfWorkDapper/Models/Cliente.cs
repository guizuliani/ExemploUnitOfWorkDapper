using System;
using System.ComponentModel.DataAnnotations;

namespace ExemploUnitOfWorkDapper.Models
{
    public class Cliente
    {

        public Cliente()
        {
            ClienteId = Guid.NewGuid();
        }

        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataModificacao { get; set; }

    }
}