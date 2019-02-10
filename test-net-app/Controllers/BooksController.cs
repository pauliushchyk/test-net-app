using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testnetapp.Data.Interfaces.Services;
using testnetapp.Data.Models;

namespace test_net_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IService<Book> _servcie;

        public BooksController(IService<Book> _servcie)
        {
            this._servcie = _servcie;
        }

        // GET api/books
        [HttpGet]
        public IQueryable<Book> Get()
        {
            return this._servcie.GetAll();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<Book> GetAsync(int id)
        {
            return await this._servcie.GetAsync(id);
        }

        // POST api/books
        [HttpPost]
        public async Task PostAsync([FromBody] Book book)
        {
            await this._servcie.CreateAsync(book);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Book book)
        {
            await this._servcie.UpdateAsync(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await this._servcie.DeleteAsync(id);
        }
    }
}
