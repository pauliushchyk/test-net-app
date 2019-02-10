using System.Linq;
using System.Threading.Tasks;
using testnetapp.Data.Interfaces.Repositories;
using testnetapp.Data.Interfaces.Services;

namespace testnetapp.Data.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> CreateAsync(T entity)
        {
            return await this._repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await this._repository.DeleteAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return this._repository.GetAll();
        }

        public async Task<T> GetAsync(int id)
        {
            return await this._repository.GetAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await this._repository.UpdateAsync(entity);
        }
    }
}
