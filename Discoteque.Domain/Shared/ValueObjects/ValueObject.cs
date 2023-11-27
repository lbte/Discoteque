namespace Discoteque.Domain.Shared.ValueObjects
{
    public abstract class ValueObject : IComparable
    {
        protected abstract IEnumerable<object> EqualityComponents { get; }
        public abstract int CompareTo(object obj);

        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }
            return left is null || left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return EqualityComponents.SequenceEqual(other.EqualityComponents);
        }

        public override int GetHashCode()
        {
            return EqualityComponents
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(ValueObject x, ValueObject y)
        {
            return EqualOperator(x, y);
        }

        public static bool operator !=(ValueObject x, ValueObject y)
        {
            return !(x == y);
        }

        public static bool operator <(ValueObject left, ValueObject right)
        {
            return left is null ? right is not null : left.CompareTo(right) < 0;
        }

        public static bool operator <=(ValueObject left, ValueObject right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(ValueObject left, ValueObject right)
        {
            return left is not null && left.CompareTo(right) > 0;
        }

        public static bool operator >=(ValueObject left, ValueObject right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }
    }
}
