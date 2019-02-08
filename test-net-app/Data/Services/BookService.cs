using System.Collections.Generic;
using System.Threading.Tasks;
using testnetapp.Data.Interfaces.Repositories;
using testnetapp.Data.Interfaces.Services;
using testnetapp.Data.Models;

namespace testnetapp.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            return await this._repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(Book entity)
        {
            await this._repository.DeleteAsync(entity);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await this._repository.GetAllAsync();
        }

        public async Task<Book> GetAsync(int id)
        {
            return await this._repository.GetAsync(id);
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            return await this._repository.UpdateAsync(entity);
        }
    }
}
