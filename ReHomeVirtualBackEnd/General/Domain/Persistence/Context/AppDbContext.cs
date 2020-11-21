using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using System;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.General.General.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Diet> Diets { get; set; } 
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Exercise>().ToTable("Exercise");
            builder.Entity<Exercise>().HasKey(p => p.Id);
            builder.Entity<Exercise>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Exercise>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Exercise>().Property(p => p.Description)
                .IsRequired().HasMaxLength(250);

            builder.Entity<Diet>().ToTable("Diet");
            builder.Entity<Diet>().HasKey(p => p.Id);
            builder.Entity<Diet>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Diet>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Diet>().Property(p => p.Description)
                .IsRequired().HasMaxLength(250);
        }
    }

}
