using System.Collections.Generic;

namespace AspNetSandbox
{
    public interface IBooksService
    {
        void DeleteBookById(int id);
        IEnumerable<Book> GettingAllTheBooks();
        Book GetBookById(int id);
        void AddingNewBook(Book value);
        void UpdatingExistingBook(int id, Book value)
;
    }
}