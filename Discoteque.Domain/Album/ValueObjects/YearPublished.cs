namespace Discoteque.Domain.Album.ValueObjects
{
    using Exceptions;
    using Shared.ValueObjects;
    public sealed class YearPublished : IntegerValueObject
    {
        private readonly int _minYear = 1905;
        private readonly int _maxYear = DateTime.Now.Year;
        public YearPublished(int yearPublished) : base(yearPublished) 
        { 
            if (yearPublished < _minYear || yearPublished > _maxYear) throw new InvalidYearException(_minYear, _maxYear);
            
            Value = yearPublished;
        }

        public static implicit operator YearPublished(int yearPublished)
        {
            return new YearPublished(yearPublished);
        }

        public static implicit operator int(YearPublished yearPublished)
        {
            return yearPublished.Value;
        }
    }
}
