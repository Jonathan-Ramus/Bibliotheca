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

            Book? exists = _books.FirstOrDefault(b => b == book);
            if (exists != null) return new Book(exists);

            book.Id = _nextId++;
            _books.Add(new Book(book));
            return book;
        }

        public Book? Delete(int id)
        {
            Book? book = GetById(id);
            if (book == null) return null;

            return _books.Remove(book) ? book : null;
        }

        public IEnumerable<Book> Get(int minPrice = Book.PRICE_MIN, int maxPrice = Book.PRICE_MAX, SortMethod? sortMethod = null)
        {
            IEnumerable<Book> result = _books.Where(b => b.Price >= minPrice && b.Price <= maxPrice);
            result = sortMethod switch
            {
                SortMethod.TitleAscending => _books.OrderBy(b => b.Title),
                SortMethod.TitleDescending => _books.OrderByDescending(b => b.Title),
                SortMethod.PriceAscending => _books.OrderBy(b => b.Price),
                SortMethod.PriceDescending => _books.OrderByDescending(b => b.Price),
                _ => result
            };
            return result.ToList().ConvertAll(b => new Book(b));
        }

        public Book? GetById(int id)
        {
            Book? result = _books.FirstOrDefault(b => b.Id == id);
            return result != null ? new Book(result) : null;
        }

        public Book? Update(int id, Book values)
        {
            Book? existing = _books.FirstOrDefault(b => b.Id == id);
            if (existing == null) return null;

            existing.Title = values.Title;
            existing.Price = values.Price;
            return new Book(existing);
        }
    }
}
