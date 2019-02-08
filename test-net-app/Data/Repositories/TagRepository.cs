using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testnetapp.Data.Interfaces.Repositories;
using testnetapp.Data.Models;

namespace testnetapp.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationContext _context;

        public TagRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Tag> CreateAsync(Tag entity)
        {
            try
            {
                var result = (await _context.Tags.AddAsync(entity)).Entity;

                await _context.SaveChangesAsync();

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAsync(Tag entity)
        {
            try
            {
                _context.Tags.Remove(entity);

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            try
            {
                return await _context.Tags.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Tag> GetAsync(int id)
        {
            try
            {
                return await _context.Tags.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Tag> UpdateAsync(Tag entity)
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
