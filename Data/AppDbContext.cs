using Microsoft.EntityFrameworkCore;
using thema1.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MVC_Project.DatabaseActions.DatabaseContent
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Message>()
                .HasKey(m => m.Id);
        }
    }
}
