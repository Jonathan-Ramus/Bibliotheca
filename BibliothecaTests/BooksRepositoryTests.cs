using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bibliotheca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheca.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {
        IBooksRepository? repository;
        Book? book1;
        Book? book2;
        Book? book3;
        
        [TestInitialize]
        public void TestInitialize()
        {
            repository = new BooksRepository();
            book1 = new Book("House of Leaves", 599);
            book2 = new Book("Introduction to Algorithms", 1099);
            book3 = new Book("World War Z", 399);
            repository.Add(book1);
            repository.Add(book2);
            repository.Add(book3);
        }
        
        [TestMethod()]
        public void AddTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => repository.Add(null));
            Book book4 = new("A Title", 299, 4);
            Book book5 = new("Another Title", 699, 5);
            Assert.AreEqual(book4, repository.Add(book4));
            Assert.AreEqual(book4, repository.Add(book4)); //Test re-adding same book
            Assert.AreEqual(book5, repository.Add(book5)); //Test proper id increment
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.IsNotNull(repository.Delete(3));
            Assert.IsNull(repository.Delete(3));
        }

        [TestMethod()]
        public void GetTest()
        {
            var list1 = repository.Get();
            var list2 = repository.Get(minPrice: 500);
            var list3 = repository.Get(maxPrice: 500);
            var list4 = repository.Get(sortMethod: SortMethod.PriceDescending);
            var list5 = repository.Get(sortMethod: SortMethod.TitleDescending);
            var list6 = repository.Get(sortMethod: SortMethod.PriceAscending);
            var list7 = repository.Get(sortMethod: SortMethod.TitleAscending);
            Assert.AreEqual(3, list1.Count());
            Assert.AreEqual(2, list2.Count());
            Assert.IsFalse(list2.Contains(book3));
            Assert.AreEqual(1, list3.Count());
            Assert.AreEqual(book3, list3.First());
            Assert.AreEqual(3, list4.Count());
            Assert.AreEqual(book2, list4.First());
            Assert.AreEqual(book3, list4.Last());
            Assert.AreEqual(3, list5.Count());
            Assert.AreEqual(book3, list5.First());
            Assert.AreEqual(book1, list5.Last());
            Assert.AreEqual(3, list6.Count());
            Assert.AreEqual(book3, list6.First());
            Assert.AreEqual(book2, list6.Last());
            Assert.AreEqual(3, list7.Count());
            Assert.AreEqual(book1, list7.First());
            Assert.AreEqual(book3, list7.Last());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Book? queryResult = repository.GetById(3);
            Assert.AreEqual(book3, queryResult);
            Assert.AreNotSame(book3, queryResult);
            queryResult.Title = "New Title";
            queryResult = repository.GetById((int)queryResult.Id);
            Assert.AreEqual("World War Z", queryResult.Title);
            Assert.IsNull(repository.GetById(4));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Book update = new("New Title", 399);
            Book? result = repository.Update(3, update);
            Assert.AreEqual(update, result);
            result = repository.Update(5, update);
            Assert.IsNull(result);
        }
    }
}