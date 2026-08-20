using Microsoft.EntityFrameworkCore;
using PA.NexDev.Models.Entities;

namespace PA.NexDev.Models
{
    public class NexDevDbContext : DbContext
    {
        public NexDevDbContext() { }
        public NexDevDbContext(DbContextOptions<NexDevDbContext> options) : base(options) { }

        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<HomePartner> HomePartners { get; set; }
        public DbSet<ProjectDetail> ProjectDetails { get; set; }
        public DbSet<ProjectItem> ProjectItems { get; set; }
        public DbSet<ProjectMessage> ProjectMessages { get; set; }
        public DbSet<ProjectPage> ProjectPages { get; set; }
        public DbSet<ServiceCard> ServiceCards { get; set; }
        public DbSet<ServicePage> ServicePages { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
