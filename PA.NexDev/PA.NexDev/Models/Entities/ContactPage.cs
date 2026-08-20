using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("ContactPages")]
    public class ContactPage
    {
        [Key] public Guid Id { get; set; }
        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }

        public string? Card1IconClass { get; set; }
        public string? Card1Title { get; set; }
        public string? Card1Description { get; set; }

        public string? Card2IconClass { get; set; }
        public string? Card2Title { get; set; }
        public string? Card2Description { get; set; }

        public string? Card3IconClass { get; set; }
        public string? Card3Title { get; set; }
        public string? Card3Description { get; set; }

        public string? FormName { get; set; }
        public string? FormEmail { get; set; }
        public string? FormSubject { get; set; }
        public string? FormMessage { get; set; }

        public string? FormButtonTitle { get; set; }
    }
}
