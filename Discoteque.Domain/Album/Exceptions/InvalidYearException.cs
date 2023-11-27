namespace Discoteque.Domain.Album.Exceptions
{
    using Shared.Exceptions.Base;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidYearException : BusinessException
    {
        public InvalidYearException() : base("Invalid year range for an album")
        {
        }

        public InvalidYearException(string message)
            : base(message)
        {
        }
        public InvalidYearException(int min, int max)
            : base($"The required year range is from {min} to {max}.")
        {
        }

        public InvalidYearException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [ExcludeFromCodeCoverage]
        protected InvalidYearException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
