using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheca
{
    public class BooksRepository : IBooksRepository
    {
        public override Book? Add(Book book)
        {
            throw new NotImplementedException();
        }

        public override Book? Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Book> Get()
        {
            throw new NotImplementedException();
        }

        public override Book? GetById()
        {
            throw new NotImplementedException();
        }

        public override Book? Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
