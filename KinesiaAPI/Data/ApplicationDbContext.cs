using KinesiaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KinesiaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Patients> Patients { get; set; } = null!;
        public DbSet<KinesiaAPI.Models.Entities.Logs> Logs { get; set; } = default!;
        public DbSet<KinesiaAPI.Models.Entities.Assessments> Assessments { get; set; } = default!;
        public DbSet<KinesiaAPI.Models.Entities.ROM> ROM { get; set; } = default!;
    }
}
