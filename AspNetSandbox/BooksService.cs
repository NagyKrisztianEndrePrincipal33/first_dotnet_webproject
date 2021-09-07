using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox
{
    public class BooksService : IBooksService
    {
        private List<Book> books;
        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                Title = "Magic Book",
                Language = "Spanish",
                Author = "Paolo Coelho"
            });

            books.Add(new Book
            {
                Id = 2,
                Title = "The Witcher",
                Language = "Hungarian",
                Author = "Andrzej Sapkowski"
            });
        }
        public IEnumerable<Book> Get()
        {
            return books;
        }



        public Book Get(int id)
        {
            return books.Single(book => book.Id == id);
        }


        public void Post(Book value)
        {
            int id = books.Count;
            value.Id = id + 1;
            books.Add(value);
        }


        public void Put(int id, string value)
        {

        }


        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
}
