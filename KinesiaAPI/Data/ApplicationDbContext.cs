using KinesiaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KinesiaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Patients> Patients { get; set; }
    }
}
