
namespace Discoteque.Domain.Song.Entities
{
    using Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using Album.Entities;

    public class Song : BaseEntity<int>
    {
        public string Name { get; set; } = "";
        public int Length { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public virtual Album? Album { get; set; }
    }
}
