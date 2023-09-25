using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheca
{
    public class BooksRepository : IBooksRepository
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;
        public const int None = 0;
        public Book Add(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            if (_books.Contains(book)) return book;

            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? book = GetById(id);
            if (book == null) throw new ArgumentNullException(nameof(book));

            return _books.Remove(book) ? book : null;
        }

        public IEnumerable<Book> Get(int minPrice = Book.PRICE_MIN, int maxPrice = Book.PRICE_MAX, SortMethod? sortMethod = null)
        {
            throw new NotImplementedException();
        }

        public Book? GetById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public Book? Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
