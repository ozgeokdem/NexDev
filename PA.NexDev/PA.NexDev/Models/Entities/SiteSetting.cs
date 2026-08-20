using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("SiteSettings")]
    public class SiteSetting
    {
        [Key] public Guid Id { get; set; }

        public string? SocialTitle { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string? InstagramUrl { get; set; }

        public string? ContactTitle { get; set; }
        public string? Title { get; set; }
        public string? TitleUrl { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
