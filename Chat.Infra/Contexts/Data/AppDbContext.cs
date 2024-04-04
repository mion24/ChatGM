using Chat.Domain.Contexts.AccountContext.Entities;
using Chat.Infra.Contexts.AccountContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infra.Contexts.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());            
        }
    }
}
