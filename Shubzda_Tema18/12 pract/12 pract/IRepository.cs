using System.Collections.Generic;
using System.Threading.Tasks;

namespace _12_pract
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}
