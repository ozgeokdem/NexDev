using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("HomePartners")]
    public class HomePartner
    {
        [Key] public Guid Id { get; set; }
        public string? IconClass { get; set; }
        public string? Name { get; set; }
    }
}
