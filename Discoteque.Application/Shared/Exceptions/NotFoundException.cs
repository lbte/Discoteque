namespace Discoteque.Application.Shared.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("The requested entity was not found")
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [ExcludeFromCodeCoverage]
        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
