using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
         Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync<TId>(TId id);
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> CreateAsync(T entity);

    }
}
