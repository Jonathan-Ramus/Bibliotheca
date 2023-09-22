﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bibliotheca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheca.Tests
{
    [TestClass()]
    public class BookTests
    {
        [TestMethod()]
        public void BookTest()
        {
            Book book = new("The Bible", 777);
            Assert.AreEqual(0, book.Id);
            Assert.AreEqual("The Bible", book.Title);
            Assert.AreEqual(777, book.Price);
            Assert.AreEqual("Id: 0, Title: The Bible, Price: 777", book.ToString());

            Book book2 = new("The Bible", 777);
            Assert.AreEqual(book, book2);

            Book book3 = new("House of Leaves", 400, id:3);
            Assert.AreEqual(3, book3.Id);
            Assert.AreNotEqual(book, book3);

            Assert.ThrowsException<ArgumentNullException>(() => new Book(null, 400));
            Assert.ThrowsException<ArgumentException>(() => new Book("Hi", 400));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Book("Agile Samurai", -1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Book("Agile Samurai", 1201));

            Assert.ThrowsException<ArgumentNullException>(() => book.Title = null);
            Assert.ThrowsException<ArgumentException>(() => book.Title = "Hi");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => book.Price = -1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => book.Price = 1201);
            book.Title = "New Title";
            book.Price = 0;
            book.Price = 1200;
        }
    }
}