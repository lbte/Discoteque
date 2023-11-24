namespace Discoteque.Domain.Album.ValueObjects
{
    using Shared.Exceptions;
    using Shared.ValueObjects;
    public sealed class Name : StringValueObject
    {
        public Name() { }

        public Name(string name) : base(name)
        {
            if (string.IsNullOrEmpty(name)) throw new EmptyOrWhiteSpaceException(nameof(name));  
            Value = name;
        }

        public static implicit operator Name(string name)
        {
            return new Name(name);
        }

        public static implicit operator string(Name name)
        {
            return name.Value;
        }
    }
}
