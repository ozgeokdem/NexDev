using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("ProjectDetails")]
    public class ProjectDetail
    {
        [Key] public Guid Id { get; set; }
        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? FormProjectName { get; set; }
        public string? FormName { get; set; }
        public string? FormEmail { get; set; }
        public string? FormMessage { get; set; }

        public string? ButtonTitle { get; set; }
    }
}
