namespace Discoteque.Domain.Shared.Exceptions
{
    using Base;

    [Serializable]
    public class EmptyOrWhiteSpaceException : BusinessException
    {
        public EmptyOrWhiteSpaceException() : base("Attribute cannot be empty or a whitespace") { }
        public EmptyOrWhiteSpaceException(string attribute) : base($"{attribute} cannot be empty or a whitespace") { }
        public EmptyOrWhiteSpaceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
