using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("AboutPages")]
    public class AboutPage
    {
        [Key] public Guid Id { get; set; }
        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }
        public string? AboutTitle { get; set; }
        public string? AboutDescription { get; set; }
        public string? ProjectNumber { get; set; }
        public string? ProjectTitle { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerTitle { get; set; }
        public string? SupportNumber { get; set; }
        public string? SupportTitle { get; set; }

        public string? TestimonialTitle { get; set; }
        public string? TestimonialDescription { get; set; }

        [NotMapped]
        public List<Testimonial>? Testimonials { get; set; } = new List<Testimonial>();
    }
}
