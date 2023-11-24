namespace Discoteque.Domain.Shared.Exceptions
{
    using Base;

    [Serializable]
    public class NullException : BusinessException
    {
        public NullException() : base("Attribute cannot be null") { }
        public NullException(string message) : base(message) { }
        public NullException(string message, Exception innerException) : base(message, innerException) { }
    }
}
