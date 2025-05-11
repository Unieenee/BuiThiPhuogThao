using Microsoft.EntityFrameworkCore;
using chise.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace chise.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}