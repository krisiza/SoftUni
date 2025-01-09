using ForumApp.Data.Models;
using ForumApp.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options) 
        {
           
        }

        public DbSet<Post> Posts { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());

            base.OnModelCreating(modelBuilder); 
        }   
    }
}
