using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("ServiceCards")]
    public class ServiceCard
    {
        [Key] public Guid Id { get; set; }
        public string? IconClass { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public Guid? ServicePageId { get; set; }
        [ForeignKey(nameof(ServicePageId))]
        public virtual ServicePage? ServicePage { get; set; } = new ServicePage();
    }
}
