using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
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

        public DbSet<Plan> Plans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
            //builder.ApplySnakeCaseNamingConvention();
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Plan>().ToTable("Plans");
            builder.Entity<Plan>().HasKey(p => p.Id);
            builder.Entity<Plan>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Plan>().Property(p => p.Name)
                .IsRequired().HasMaxLength(100);
            builder.Entity<Plan>().Property(p => p.Cost)
                .IsRequired();

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Username)
                .IsRequired().HasMaxLength(80);
            builder.Entity<User>().Property(p => p.Password)
                .IsRequired().HasMaxLength(80);
            builder.Entity<User>().Property(p => p.Name)
                .IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(p => p.Lastname)
                .IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(p => p.Brithday)
                .IsRequired();
            builder.Entity<User>().Property(p => p.Email)
                .IsRequired().HasMaxLength(10);
            builder.Entity<User>().Property(p => p.Phone)
                .IsRequired().HasMaxLength(12);
            builder.Entity<User>().Property(p => p.Address)
                .IsRequired().HasMaxLength(150);
            builder.Entity<User>().Property(p => p.Active)
                .IsRequired();

            builder.Entity<Diet>().ToTable("Diets");
            builder.Entity<Diet>().HasKey(p => p.Id);
            builder.Entity<Diet>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Diet>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Diet>().Property(p => p.Description)
                .IsRequired().HasMaxLength(250);

            builder.Entity<Exercise>().ToTable("Exercises");
            builder.Entity<Exercise>().HasKey(p => p.Id);
            builder.Entity<Exercise>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Exercise>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Exercise>().Property(p => p.Description)
                .IsRequired().HasMaxLength(250);

            builder.Entity<Allergy>().ToTable("Allergies");
            builder.Entity<Allergy>().HasKey(p => p.Id);
            builder.Entity<Allergy>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Allergy>().Property(p => p.Name)
                .IsRequired().HasMaxLength(100);
        }
    }

}
