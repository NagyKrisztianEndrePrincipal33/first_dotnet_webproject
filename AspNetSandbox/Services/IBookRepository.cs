// <copyright file="IBookRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using AspNetSandbox.Models;

namespace AspNetSandbox.Services
{
    public interface IBookRepository
    {
        void DeleteBookById(int id);

        IEnumerable<Book> GettingAllTheBooks();

        Book GetBookById(int id);

        void AddingNewBook(Book value);

        void UpdatingExistingBook(int id, Book value);
    }
}