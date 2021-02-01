using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Contracts
{
    public interface IBaseDao<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);


        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);


        Task<T> UpdateAsync(T entity);

        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);


        Task<bool> RemoveAsync(Guid id);
    }
}
