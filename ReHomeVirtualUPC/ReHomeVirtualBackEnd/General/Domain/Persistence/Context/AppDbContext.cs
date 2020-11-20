using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
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
        }

        internal Task<Plan> FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
