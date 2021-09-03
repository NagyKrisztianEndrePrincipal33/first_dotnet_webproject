using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetSandbox
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private Book[] books;
        public BooksController()
        {
            books = new Book[2];
            books[0] = new Book
            {
                Id = 1,
                Title = "Magic Book",
                Language = "Spanish",
                Author = "Paolo Coelho"
            };

            books[1] = new Book
            {
                Id = 2,
                Title = "The Witcher",
                Language = "Hungarian",
                Author = "Andrzej Sapkowski"
            };
        }
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return  books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
