using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class BookServiceTest
    {
        [Fact]
        public void TestBookService()
        {
            // Assume
            var booksService = new BooksService();

            // Act
            booksService.AddingNewBook(new Book
            {
                Title = "Test Book NR1",
                Language = "English",
                Author = "Some Author",
            });
            booksService.DeleteBookById(2);
            booksService.AddingNewBook(new Book
            {
                Title = "Test Book NR2",
                Language = "English",
                Author = "Some Author2",
            });

            // Assert
            Assert.Equal("Test Book NR1", booksService.GetBookById(3).Title);
        }
    }
}
