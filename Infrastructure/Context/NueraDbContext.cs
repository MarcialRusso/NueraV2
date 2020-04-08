using Microsoft.EntityFrameworkCore;
using NueraVersion2.Infrastructure.Entities;
using NueraVersion2.Infrastructure.Interfaces;

namespace NueraVersion2.Infrastructure.Context
{
    public class NueraDbContext : DbContext, INueraDbContext
    {
        public NueraDbContext(DbContextOptions<NueraDbContext> options) : base(options)
        {
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<HouseholdItem> HouseholdItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>();
            base.OnModelCreating(builder);
        }
    }
}