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
        public const int None = 0;
        public Book? Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Book? Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Get(Range? priceFilter = null, SortMethod? sortMethod = null)
        {
            throw new NotImplementedException();
        }

        public Book? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Book? Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
