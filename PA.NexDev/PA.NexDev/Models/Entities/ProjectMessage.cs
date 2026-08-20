using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("ProjectMessages")]
    public class ProjectMessage
    {
        [Key] public Guid Id { get; set; }
        public string? ProjeName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public DateTimeOffset? SendDate { get; set; }
        public bool IsReaded { get; set; }
    }
}
