namespace Discoteque.Domain.Album.Entities
{
    using Artist.Entities;
    using Domain.Album.ValueObjects;
    using Shared;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Album : BaseEntity<int>
    {
        //public Album() { }
        //public Album(Name name, YearPublished yearPublished, Genres genre, Cost cost, Artist artist)
        //{
        //    Name = name;
        //    YearPublished = yearPublished;
        //    Genre = genre;
        //    Cost = cost;
        //    ArtistId = artist.Id;
        //    Artist = artist;
        //}

        public Name Name { get; set; }
        public YearPublished YearPublished { get; set; }
        public Genres Genre { get; set; }
        public Cost Cost { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }


    }
}
