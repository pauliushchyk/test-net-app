using System.Linq;
using System.Threading.Tasks;

namespace testnetapp.Data.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task DeleteAsync(int id);

        IQueryable<T> GetAll();

        Task<T> GetAsync(int id);

        Task<T> UpdateAsync(T entity);
    }
}
