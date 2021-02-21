using BooksApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;
        public BookService(IBookstoreDatabaseSettings bookstoreDatabaseSettings)
        {
            var client = new MongoClient(bookstoreDatabaseSettings.ConnectionString);

            var database = client.GetDatabase(bookstoreDatabaseSettings.DatabaseName);
            _books = database.GetCollection<Book>(bookstoreDatabaseSettings.BooksCollectionName);
        }
        public List<Book> Get() {
            return _books.Find<Book>(Book => true).ToList();

        }
        public Book Get(string Id)
        {
            return _books.Find<Book>(Book =>Book.Id==Id).FirstOrDefault();
        }
        public Book post(Book newBook)
        {
            _books.InsertOne(newBook);
            return newBook;


        }
        public void put(string Id,Book newBook)
        {
            //  Book oldBook=_books.Find<Book>(Book => newBook.Id == Id).FirstOrDefault();
            _books.ReplaceOne(book => book.Id == Id, newBook);
        }
        public void Delete(string Id)
        {
            _books.DeleteOne<Book>(Book => Book.Id == Id);
        }
        public void Delete(Book bookdelete)
        {
            _books.DeleteOne<Book>(Book => Book.Id == bookdelete.Id);
        }

    }
}
