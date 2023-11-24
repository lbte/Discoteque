namespace Discoteque.Domain.Album.ValueObjects
{
    using Shared.ValueObjects;
    public sealed class Cost : DecimalValueObject
    {
        public Cost() { }

        public Cost(double cost) : base(cost)
        {
            if (cost < 0) throw new ArgumentException("Cost cannot be less than 0");
            Value = cost;
        }

        public static implicit operator Cost(double cost) 
        { 
            return new Cost(cost);
        }

        public static implicit operator double(Cost cost)
        {
            return cost.Value;
        }
    }
}
