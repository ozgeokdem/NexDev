using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("ServicePages")]
    public class ServicePage
    {
        [Key] public Guid Id { get; set; }
        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }

        public virtual ICollection<ServiceCard>? Services { get; set; } = new List<ServiceCard>();
    }
}
