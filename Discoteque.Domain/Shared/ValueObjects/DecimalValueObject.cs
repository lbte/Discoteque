namespace Discoteque.Domain.Shared.ValueObjects
{
    public class DecimalValueObject : ValueObject
    {
        public DecimalValueObject() { }

        protected DecimalValueObject(double doubleValue)
        {
            Value = doubleValue;
        }

        protected double Value { get; set; }
        protected override IEnumerable<object> EqualityComponents
        {
            get { yield return Value; }
        }

        public override int CompareTo(object obj)
        {
            return obj == null ? -1 : Value.CompareTo(((DecimalValueObject)obj).Value);
        }
    }
}
