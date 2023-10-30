namespace Discoteque.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    public class BaseEntity<TId> where TId : struct
    {
        [Key]
        public TId Id { get; set; }
    }
}
