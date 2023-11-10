namespace Discoteque.Domain.Album.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Artist.Entities;
    using Models;

    public class Album : BaseEntity<int>
    {
        public string Name { get; set; } = "";
        public int YearPublished { get; set; }
        public Genres Genre { get; set; } = Genres.Unkown;
        public double Cost { get; set; } = 50_000;
        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }
    }
}
