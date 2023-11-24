namespace Discoteque.Domain.Artist.Entities
{
    using Discoteque.Domain.Shared;
    public class Artist : BaseEntity<int>
    {
        public string Name { get; set; } = "";
        /// <summary>
        /// The record company where the artist publishes their work
        /// </summary>
        public string Label { get; set; } = "";
        public bool IsOnTour { get; set; }
    }
}
