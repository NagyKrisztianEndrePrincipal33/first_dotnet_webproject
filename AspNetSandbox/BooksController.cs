// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace AspNetSandbox
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        /// <summary>Initializes a new instance of the <see cref="BooksController" /> class.</summary>
        /// <param name="booksService">The books service.</param>
        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        // GET: api/<BooksController>

        /// <summary>Gets all the books.</summary>
        /// <returns>
        ///   <para>List of books.</para>
        /// </returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return booksService.GettingAllTheBooks();
        }

        // GET api/<BooksController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return booksService.GetBookById(id);
        }

        // POST api/<BooksController>

        /// <summary>Posts the specified book.</summary>
        /// <param name="value">A book object.</param>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            booksService.AddingNewBook(value);
        }

        // PUT api/<BooksController>/5

        /// <summary>Updates a specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The book object.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            booksService.UpdatingExistingBook(id, value);
        }

        // DELETE api/<BooksController>/5

        /// <summary>Deletes the specified book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            booksService.DeleteBookById(id);
        }
    }
}
