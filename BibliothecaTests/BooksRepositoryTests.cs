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
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
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