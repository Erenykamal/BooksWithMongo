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

        public List<Book> Get()
        {
            return _bookservice.Get();

        }
        public Book Get(string id)
        {
            return _bookservice.Get(id);

        }
        public void put(string id,Book book)
        {
             _bookservice.put(id,book);

        }
        public void Delete (string id)
        {
             _bookservice.Delete(id);

        }
    }
}
