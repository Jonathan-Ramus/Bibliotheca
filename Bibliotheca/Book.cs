namespace Bibliotheca
{
    public class Book
    {
        private const int TITLE_MIN_LENGTH = 3;
        private const int PRICE_MIN = 0;
        private const int PRICE_MAX = 1200;

        private string _title;
        private int _price;
        
        public int Id { get; set; }
        
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
        
        public Book(string title, int price, int id = 0)
        {
            Id = id;
            _title = title;
            _price = price;
            Validate();
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
            return string.Format("Id: {0}, Title: {1}, Price: {2}", Id, _title, _price);
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Book;
            if (other == null) return false;
            return other.Id == this.Id && other.Title == this.Title && other.Price == this.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, _title, _price);
        }
    }
}