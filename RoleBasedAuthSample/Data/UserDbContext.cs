using Microsoft.EntityFrameworkCore;
using RoleBasedAuthSample.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace RoleBasedAuthSample.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adding support for List<string> property in User model

            modelBuilder.Entity<User>()
                .Property(u => u.Roles)
                .HasConversion(
                    u => string.Join(',', u),
                    u => u.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}
