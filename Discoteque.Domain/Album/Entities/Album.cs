namespace Discoteque.Domain.Album.Entities
{
    using Artist.Entities;
    using Domain.Album.ValueObjects;
    using Shared;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Album : BaseEntity<int>
    {
        public Name Name { get; set; } = "";
        public YearPublished YearPublished { get; set; } = DateTime.Now.Year;
        public Genres Genre { get; set; } = Genres.Unkown;
        public Cost Cost { get; set; } = 50_000;

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }
    }
}
