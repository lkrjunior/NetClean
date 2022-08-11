using System;
namespace NetClean.Domain.Pessoa
{
    public class PessoaFisica : PessoaBase
    {
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
    }
}