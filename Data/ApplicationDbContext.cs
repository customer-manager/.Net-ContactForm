using Microsoft.EntityFrameworkCore;

namespace ContactForm.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ContactFormModel> ContactForms { get; set; }
    }
}

