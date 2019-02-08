using System.Collections.Generic;
using System.Threading.Tasks;

namespace testnetapp.Data.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task<T> UpdateAsync(T entity);
    }
}
