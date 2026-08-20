using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("ProjectItems")]
    public class ProjectItem
    {
        [Key] public Guid Id { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ButtonTitle { get; set; }
        public string? ButtonUrl { get; set; }

        public Guid? HomePageId { get; set; }
        [ForeignKey(nameof(HomePageId))]
        public virtual HomePage? HomePage { get; set; } = new HomePage();

        public Guid? ProjectPageId { get; set; }
        [ForeignKey(nameof(ProjectPageId))]
        public virtual ProjectPage? ProjectPage { get; set; } = new ProjectPage();
    }
}
