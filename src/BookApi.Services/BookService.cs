using BookApi.Core;
using BookApi.Core.Interfaces;

namespace BookApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<Book> Get() => _repository.Get();
        
        public Book? Get(string id) => _repository.Get(id);
        
        public Book Create(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
                
            return _repository.Create(book);
        }
        
        public void Update(string id, Book bookIn)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));
                
            if (bookIn == null)
                throw new ArgumentNullException(nameof(bookIn));
                
            _repository.Update(id, bookIn);
        }
        
        public void Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));
                
            _repository.Remove(id);
        }
    }
} 