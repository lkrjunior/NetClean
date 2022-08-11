using System;
namespace NetClean.Domain.Pessoa
{
    public class PessoaJuridica : PessoaBase
    {
        public string Cnpj { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}