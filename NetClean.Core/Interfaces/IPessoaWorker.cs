using System;
using NetClean.Domain.Models.Result;
using NetClean.Domain.Pessoa;

namespace NetClean.Core.Interfaces
{
    public interface IPessoaWorker<T>
        where T : PessoaBase
    {
        Task<CoreResult<T>> GetAsync(int id);
        Task<CoreResult<IEnumerable<T>>> ListAsync();
        Task<CoreResult<T>> DeleteAsync(int id);
        Task<CoreResult<T>> InsertAsync(T entity);
        Task<CoreResult<T>> UpdateAsync(T entity);
    }
}