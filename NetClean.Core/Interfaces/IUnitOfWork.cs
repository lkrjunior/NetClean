using System;
using NetClean.Domain.Pessoa;

namespace NetClean.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryBase<PessoaFisica> PessoaFisicaRepository { get; }
        IRepositoryBase<PessoaJuridica> PessoaJuridicaRepository { get; }
        Task<int> SaveAsync();
    }
}