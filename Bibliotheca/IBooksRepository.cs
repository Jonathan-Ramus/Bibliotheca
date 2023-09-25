using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheca
{
    public enum SortMethod
    {
        TitleAscending,
        TitleDescending,
        PriceAscending,
        PriceDescending
    }
    public interface IBooksRepository
    {
        public abstract IEnumerable<Book> Get(int minPrice, int maxPrice, SortMethod? sortMethod);
        public abstract Book? GetById(int id);
        public abstract Book Add(Book book);
        public abstract Book? Delete(int id);
        public abstract Book? Update(Book book);
    }
}
