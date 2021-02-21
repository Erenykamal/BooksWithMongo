using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookservice;
        public BooksController(BookService bookservice)
        {
            _bookservice = bookservice;
        }
        [HttpGet]
        public List<Book> Get()
        {
            return _bookservice.Get();

        }
        [HttpGet("{id}",Name ="GetBook")]
        public Book Get(string id)
        {
            return _bookservice.Get(id);

        }
        [HttpPut]
        public void put(string id,Book book)
        {
             _bookservice.put(id,book);

        }
        [HttpPost]
        public ActionResult<Book> post( Book book)
        {
            
            _bookservice.post(book);
            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);

        }
        [HttpDelete]
        public void Delete (string id)
        {
             _bookservice.Delete(id);

        }
    }
}
