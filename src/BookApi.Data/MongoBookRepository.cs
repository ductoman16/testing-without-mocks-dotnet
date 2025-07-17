using BookApi.Core;
using BookApi.Core.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace BookApi.Data
{
    public class MongoBookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

        public MongoBookRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookStoreDb"));
            var database = client.GetDatabase("BookStoreDb");
            _books = database.GetCollection<Book>("Books");
        }

        public List<Book> Get() => _books.Find(book => true).ToList();
        public Book? Get(string id) => _books.Find<Book>(book => book.Id == id).FirstOrDefault();
        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }
        public void Update(string id, Book bookIn) => _books.ReplaceOne(book => book.Id == id, bookIn);
        public void Remove(string id) => _books.DeleteOne(book => book.Id == id);
    }
}
