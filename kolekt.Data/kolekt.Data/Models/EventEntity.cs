using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolekt.Data.Models
{
    public class EventEntity
    {
        [Required]
        public Guid Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; private set; }
        [Key]
        public int Sequence { get; private set; }
        public int Version { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public Guid AggregateId { get; set; }
        public string Data { get; set; }
        [StringLength(250)]
        public string AggregateType { get; set; }
    }
}
