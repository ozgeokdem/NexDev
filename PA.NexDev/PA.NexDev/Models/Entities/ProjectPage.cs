using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("ProjectPages")]
    public class ProjectPage
    {
        [Key] public Guid Id { get; set; }
        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }

        public virtual ICollection<ProjectItem> Items { get; set; } = new List<ProjectItem>();
    }
}
