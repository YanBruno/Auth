using Auth.Domain.Entities;
using Auth.Domain.Infra.Mappings;
using Auth.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Auth.Domain.Infra.DataContexts
{
    public class AuthDataContext : DbContext
    {
        //EF Core
        public AuthDataContext() { }

        public AuthDataContext(DbContextOptions<AuthDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.StringConnection);

        }
    }
}
