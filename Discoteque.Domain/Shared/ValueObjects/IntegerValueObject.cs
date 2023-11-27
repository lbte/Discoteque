namespace Discoteque.Domain.Shared.ValueObjects
{
    public class IntegerValueObject : ValueObject
    {
        protected IntegerValueObject(int intValue)
        {
            Value = intValue;
        }

        protected int Value { get; set; }
        protected override IEnumerable<object> EqualityComponents
        {
            get { yield return Value; }
        }

        public override int CompareTo(object obj)
        {
            return obj == null ? -1 : Value.CompareTo(((IntegerValueObject)obj).Value);
        }

    }
}
