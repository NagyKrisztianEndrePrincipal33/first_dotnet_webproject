// <copyright file="BooksInMemoryRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Models;

namespace AspNetSandbox.Services
{
    public class BooksInMemoryRepository : IBookRepository
    {
        private List<Book> books;

        public BooksInMemoryRepository()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                Title = "Magic Book",
                Language = "Spanish",
                Author = "Paolo Coelho",
            });

            books.Add(new Book
            {
                Id = 2,
                Title = "The Witcher",
                Language = "Hungarian",
                Author = "Andrzej Sapkowski",
            });
        }

        public IEnumerable<Book> GettingAllTheBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.Find(book => book.Id == id);
        }

        public void AddingNewBook(Book value)
        {
            int id = books.Count;
            value.Id = id + 1;
            books.Add(value);
        }

        public void UpdatingExistingBook(int id, Book value)
        {
            int index = books.FindIndex(book => book.Id == id);
            if (index == -1)
            {
                return;
            }

            books[index].Title = value.Title;
            books[index].Language = value.Language;
            books[index].Author = value.Author;
        }

        public void DeleteBookById(int id)
        {
            books.Remove(GetBookById(id));
        }
    }
}
