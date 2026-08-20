using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("HomePages")]
    public class HomePage
    {
        [Key] public Guid Id { get; set; }
        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }

        public string? PartnersTitle { get; set; }
        [NotMapped]
        public List<HomePartner>? Partners { get; set; } = new List<HomePartner>();

        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public string? ProjectButtonTitle { get; set; }
        public string? ProjectButtonUrl { get; set; }

        public virtual ICollection<ProjectItem> Items { get; set; } = new List<ProjectItem>();

        public string? IdeaTitle { get; set; }
        public string? IdeaDescription { get; set; }
        public string? IdeaButtonTitle { get; set; }
        public string? IdeaButtonUrl { get; set; }
    }
}
