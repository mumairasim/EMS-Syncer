using Microsoft.EntityFrameworkCore;
using Syncer.Data.Entities;

namespace Syncer.Data.DatabaseContext
{
    public class SMSContext : DbContext
    {
        public SMSContext(DbContextOptions<SMSContext> options) : base(options)
        {
        }
        public DbSet<Class> Classes { get; set; }
        public virtual DbSet<School> Schools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }
}
