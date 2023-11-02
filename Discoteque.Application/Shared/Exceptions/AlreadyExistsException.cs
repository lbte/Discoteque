namespace Discoteque.Application.Shared.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [Serializable]
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException() : base("The requested entity already exists in the database.")
        {
        }

        public AlreadyExistsException(string message)
            : base(message)
        {
        }

        public AlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
