using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheca
{
    public abstract class IBooksRepository
    {
        public abstract IEnumerable<Book> Get();
        public abstract Book? GetById();
        public abstract Book? Add(Book book);
        public abstract Book? Delete(Book book);
        public abstract Book? Update(Book book);
    }
}
