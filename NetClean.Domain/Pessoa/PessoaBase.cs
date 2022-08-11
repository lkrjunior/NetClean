using System;
using NetClean.Domain.Interfaces;

namespace NetClean.Domain.Pessoa
{
    public class PessoaBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}