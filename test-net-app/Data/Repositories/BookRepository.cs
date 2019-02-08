using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testnetapp.Data.Interfaces.Repositories;
using testnetapp.Data.Models;

namespace testnetapp.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            try
            {
                var result = (await _context.Books.AddAsync(entity)).Entity;

                await _context.SaveChangesAsync();

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAsync(Book entity)
        {
            try
            {
                _context.Books.Remove(entity);

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Book>> GetAllAsync()
        {
            try
            {
                return await _context.Books.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Book> GetAsync(int id)
        {
            try
            {
                return await _context.Books.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return entity;
            }
            catch
            {
                throw;
            }
        }
    }
}
