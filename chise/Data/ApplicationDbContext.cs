using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using chise.Models;

namespace chise.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<chise.Models.Person> Person { get; set; } = default!;
        public DbSet<chise.Models.Employee> Employee { get; set; } = default!;
    }
}
