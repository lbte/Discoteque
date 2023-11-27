namespace Discoteque.Domain.Shared.ValueObjects
{
    public class StringValueObject : ValueObject
    {
        public StringValueObject() { }

        protected StringValueObject(string stringObject)
        {
            Value = string.IsNullOrWhiteSpace(stringObject) ? string.Empty : stringObject.Trim();
        }

        public string Value { get; protected set; }
        protected override IEnumerable<object> EqualityComponents
        {
            get { yield return Value; }
        }

        public override int CompareTo(object obj)
        {
            return obj == null ? -1 : string.Compare(Value, ((StringValueObject)obj).Value, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (StringValueObject)obj;
            using var thisValues = EqualityComponents.GetEnumerator();
            using var otherValues = other.EqualityComponents.GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (thisValues.Current is null ^
                    otherValues.Current is null)
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return EqualityComponents
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public override string ToString()
        {
            return !string.IsNullOrWhiteSpace(Value) ? Value : "";
        }
    }
}
