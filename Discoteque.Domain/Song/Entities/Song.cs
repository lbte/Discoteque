
namespace Discoteque.Domain.Song.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Album.Entities;
    using Discoteque.Domain.Shared;

    public class Song : BaseEntity<int>
    {
        public string Name { get; set; } = "";
        public int Length { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public virtual Album? Album { get; set; }
    }
}
