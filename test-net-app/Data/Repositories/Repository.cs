using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testnetapp.Data.Interfaces.Repositories;

namespace testnetapp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                var result = await this._context.Set<T>().AddAsync(entity);

                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await this.GetAsync(id);

                this._context.Set<T>().Remove(entity);

                await this._context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return this._context.Set<T>().AsNoTracking();
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> GetAsync(int id)
        {
            try
            {
                return await this._context.Set<T>().FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = this._context.Set<T>().Update(entity);

                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            catch
            {
                throw;
            }
        }
    }
}
