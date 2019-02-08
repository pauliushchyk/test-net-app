using System.Collections.Generic;
using System.Threading.Tasks;
using testnetapp.Data.Interfaces.Repositories;
using testnetapp.Data.Interfaces.Services;
using testnetapp.Data.Models;

namespace testnetapp.Data.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;

        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tag> CreateAsync(Tag entity)
        {
            return await this._repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await this._repository.DeleteAsync(id);
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await this._repository.GetAllAsync();
        }

        public async Task<Tag> GetAsync(int id)
        {
            return await this._repository.GetAsync(id);
        }

        public async Task<Tag> UpdateAsync(Tag entity)
        {
            return await this._repository.UpdateAsync(entity);
        }
    }
}
