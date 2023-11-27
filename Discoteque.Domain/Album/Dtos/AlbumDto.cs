namespace Discoteque.Domain.Album.Dtos
{
    using Album.Entities;
    public class AlbumDto
    {
        public string Name { get; set; } = "";
        public int YearPublished { get; set; }
        public Genres Genre { get; set; } = Genres.Unkown;
        public double Cost { get; set; } = 50_000;
        public int ArtistId { get; set; }
    }
}
