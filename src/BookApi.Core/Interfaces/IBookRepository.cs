using BookApi.Core;

namespace BookApi.Core.Interfaces
{
    public interface IBookRepository
    {
        List<Book> Get();
        Book? Get(string id);
        Book Create(Book book);
        void Update(string id, Book bookIn);
        void Remove(string id);
    }
} 