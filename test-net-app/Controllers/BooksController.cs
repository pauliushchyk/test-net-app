using System.Collections.Generic;
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
        private readonly IBookService _bookServcie;

        public BooksController(IBookService bookService)
        {
            this._bookServcie = bookService;
        }

        // GET api/books
        [HttpGet]
        public async Task<List<Book>> GetAsync()
        {
            return await this._bookServcie.GetAllAsync();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<Book> GetAsync(int id)
        {
            return await this._bookServcie.GetAsync(id);
        }

        // POST api/books
        [HttpPost]
        public async Task PostAsync([FromBody] Book book)
        {
            await this._bookServcie.CreateAsync(book);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Book book)
        {
            await this._bookServcie.UpdateAsync(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await this._bookServcie.DeleteAsync(id);
        }
    }
}
