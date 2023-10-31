using Discoteque.Domain.Album.Entities;

namespace Discoteque.Domain.Album.Dtos
{
    public class AlbumDto
    {
        /// <summary>
        /// Name of the album
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Year the album was published
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The <see cref="Genres"/> the album belongs to
        /// </summary>
        public GenreEnum Genre { get; set; } = GenreEnum.Unkown;

        /// <summary>
        /// The cost of the album
        /// </summary>
        public double Cost { get; set; } = 50_000;

        /// <summary>
        /// The <see cref="Artist"/> id this album belongs to
        /// </summary>
        public int ArtistId { get; set; }
    }
}
