using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Data;
using AspNetSandbox.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Services
{
    public class DbBooksRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public DbBooksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddingNewBook(Book book)
        {
          this.context.Add(book);
          this.context.SaveChanges();
        }

        public void DeleteBookById(int id)
        {
            var book = this.context.Book.Find(id);
            this.context.Book.Remove(book);
            this.context.SaveChanges();
        }

        public Book GetBookById(int id)
        {
            var book = this.context.Book
                .FirstOrDefault(m => m.Id == id);

            return book;
        }

        public IEnumerable<Book> GettingAllTheBooks()
        {
            return this.context.Book.ToList();
        }

        public void UpdatingExistingBook(int id, Book book)
        {
                    this.context.Update(book);
                    this.context.SaveChanges();
        }
    }
}
