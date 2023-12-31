﻿namespace Bibliotheca
{
    public class Book
    {
        public const int TITLE_MIN_LENGTH = 3;
        public const int PRICE_MIN = 1;
        public const int PRICE_MAX = 1200;

        private string _title;
        private int _price;
        
        public int? Id { get; set; }
        
        public string Title
        {
            get { return _title; }
            set { ValidateTitle(value); _title = value; }
        }
        public int Price
        {
            get { return _price; }
            set { ValidatePrice(value); _price = value; }
        }
        
        public Book(string title, int price, int? id = null)
        {
            Id = id;
            _title = title;
            _price = price;
            Validate();
        }

        public Book(Book b)
        {
            this.Id = b.Id;
            _title = b.Title;
            _price = b.Price;
        }

        private void Validate()
        {
            ValidateTitle(_title);
            ValidatePrice(_price);
        }

        private static void ValidateTitle(string? title)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));
            if (title.Length < TITLE_MIN_LENGTH)
            {
                string exceptionMessage = string.Format("Title must be at least {0} characters", TITLE_MIN_LENGTH);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void ValidatePrice(int price)
        {
            if (price < PRICE_MIN || price > PRICE_MAX)
            {
                string exceptionMessage = string.Format("Price must be between {0} and {1}", PRICE_MIN, PRICE_MAX);
                throw new ArgumentOutOfRangeException(exceptionMessage);
            }
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Title: {1}, Price: {2}", Id == null ? "None" : Id, _title, _price);
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Book;
            if (other == null) return false;
            return other.Title == this.Title && other.Price == this.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_title, _price);
        }
    }
}