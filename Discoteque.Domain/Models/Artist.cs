namespace Discoteque.Domain.Models
{
    public class Artist : BaseEntity<int>
    {
        /// <summary>
        /// Name of the Artist
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The record company where the artist publishes their work
        /// </summary>
        public string Label { get; set; } = "";

        /// <summary>
        /// Boolean to indicate wheter the artist is on tour or not
        /// </summary>
        public bool IsOnTour { get; set; }
    }
}
