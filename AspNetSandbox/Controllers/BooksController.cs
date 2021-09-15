// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandbox;
using AspNetSandbox.Data;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandBox.Controllers
{
    /// <summary>Controller class for managing books.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;
        private readonly IHubContext<MessageHub> hubContext;

        public BooksController(IBookRepository repository, IHubContext<MessageHub> hubContext)
        {
            this.repository = repository;
            this.hubContext = hubContext;
        }

        /// <summary>Get all instances of books.</summary>
        /// <returns>Ennumerable of Book objects.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GettingAllTheBooks());
        }

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var book = repository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>Adds books to List of Book objects.</summary>
        /// <param name="book">The book.</param>
        /// <returns>IActionResult. </returns>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                repository.AddingNewBook(book);
                hubContext.Clients.All.SendAsync("BookCreated", book);
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>Update values of book with certain id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The book.</param>
        /// <returns>IActionResult. </returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repository.UpdatingExistingBook(id,book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return Ok(book);
            }

            return BadRequest();
        }

        /// <summary>Removes a book from the List of Book objects.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult. </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.DeleteBookById(id);
            return Ok();
        }
    }
}