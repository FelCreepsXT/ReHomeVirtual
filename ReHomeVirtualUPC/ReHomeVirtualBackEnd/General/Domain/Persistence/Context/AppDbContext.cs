using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using System;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.General.General.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Allergy> Plans { get; set; }
            //builder.ApplySnakeCaseNamingConvention();
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Allergy>().ToTable("Plans");
            builder.Entity<Allergy>().HasKey(p => p.Id);
            builder.Entity<Allergy>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Allergy>().Property(p => p.Name)
                .IsRequired().HasMaxLength(100);
        }
    }

}
