using System.ComponentModel.DataAnnotations.Schema;

namespace PA.NexDev.Models.Entities
{
    [Table("Users")]
    public class User
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
