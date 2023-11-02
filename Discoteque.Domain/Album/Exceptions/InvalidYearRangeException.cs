namespace Discoteque.Domain.Album.Exceptions
{
    using Shared.Exceptions;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidYearRangeException : BusinessException
    {
        public InvalidYearRangeException() : base("Invalid Year Range for creating an album")
        {
        }

        public InvalidYearRangeException(string message)
            : base(message)
        {
        }
        public InvalidYearRangeException(short min, short max)
            : base($"The required year range is from {min} to {max}.")
        {
        }

        public InvalidYearRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [ExcludeFromCodeCoverage]
        protected InvalidYearRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
