using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Social.Domain.Model;

namespace ReHomeVirtualBackEnd.General.General.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Plan> Plans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<AllergyUser> AllergyUsers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

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
            builder.Entity<Plan>().Property(p => p.MaxSession)
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


            builder.Entity<Collaborator>().ToTable("Collaborators");
            builder.Entity<Collaborator>().HasKey(p => p.Id);
            builder.Entity<Collaborator>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Collaborator>().Property(p => p.Collaboratorname)
                .IsRequired().HasMaxLength(80);
            builder.Entity<Collaborator>().Property(p => p.Password)
                .IsRequired().HasMaxLength(80);
            builder.Entity<Collaborator>().Property(p => p.Name)
                .IsRequired().HasMaxLength(100);
            builder.Entity<Collaborator>().Property(p => p.Lastname)
                .IsRequired().HasMaxLength(100);
            builder.Entity<Collaborator>().Property(p => p.Brithday)
                .IsRequired();
            builder.Entity<Collaborator>().Property(p => p.Email)
                .IsRequired().HasMaxLength(10);
            builder.Entity<Collaborator>().Property(p => p.Phone)
                .IsRequired().HasMaxLength(12);
            builder.Entity<Collaborator>().Property(p => p.Address)
                .IsRequired().HasMaxLength(150);
            builder.Entity<Collaborator>().Property(p => p.Active)
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

            builder.Entity<AllergyUser>().ToTable("AllergyUsers");
            builder.Entity<AllergyUser>().HasKey(p => new { p.UserId, p.AllergyId });
            builder.Entity<AllergyUser>().HasOne(p => p.Allergy)
                .WithMany(p => p.AllergyUsers).HasForeignKey(p => p.AllergyId);
            builder.Entity<AllergyUser>().HasOne(p => p.User)
                .WithMany(p => p.AllergyUsers).HasForeignKey(p => p.UserId);

            builder.Entity<Subscription>().ToTable("Subscriptions");
            builder.Entity<Subscription>().HasKey(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subscription>().Property(p => p.Active)
                .IsRequired();
            builder.Entity<Subscription>().Property(p => p.CreateAt)
                .IsRequired();
            builder.Entity<Subscription>().Property(p => p.UpdateAt)
                .IsRequired();
            builder.Entity<Subscription>().Property(p => p.UserId)
                .IsRequired();
          
            builder.Entity<Subscription>().HasOne(p => p.User)
                .WithMany(p => p.Subscriptions).HasForeignKey(p => p.UserId);

            builder.Entity<Complaint>().ToTable("Complaints");
            builder.Entity<Allergy>().HasKey(p => p.Id);
            builder.Entity<Allergy>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Complaint>().Property(p => p.Description)
                .IsRequired().HasMaxLength(250);
            builder.Entity<Complaint>().Property(p => p.UserId)
                .IsRequired();
            builder.Entity<Complaint>().HasOne(p => p.User)
                .WithMany(p => p.Complaints).HasForeignKey(p => p.UserId);
        }
    }

}
