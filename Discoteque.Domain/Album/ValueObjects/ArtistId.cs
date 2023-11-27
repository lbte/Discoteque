using Discoteque.Domain.Shared.ValueObjects;

namespace Discoteque.Domain.Album.ValueObjects
{
    public sealed class ArtistId : IntegerValueObject
    {
        public ArtistId(int artistId) : base(artistId)
        {
            Value = artistId;
        }

        public static implicit operator ArtistId(int artistId)
        {
            return new ArtistId(artistId);
        }

        public static implicit operator int(ArtistId artistId)
        {
            return artistId.Value;
        }
    }
}
