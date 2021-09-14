// <copyright file="BookServiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AspNetSandbox.Models;
using AspNetSandbox.Services;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class BooksInMemoryRepositoryTests
    {
        [Fact]
        public void TestBookService()
        {
            // Assume
            var booksService = new BooksInMemoryRepository();

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
