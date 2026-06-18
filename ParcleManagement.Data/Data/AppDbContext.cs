using Microsoft.EntityFrameworkCore;
using ParcleManagement.Data.Models;

namespace ParcleManagement.Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<DeliveryAssignment> DeliveryAssignments { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr =
                    "Host=aws-1-ap-southeast-1.pooler.supabase.com;" +
                    "Database=postgres;" +
                    "Username=postgres.imkjhompqtreemsqdbvc;" +  // note the project ref in username
                    "Password=SanTin0601@@;" +
                    "Port=5432;" +
                    "SSL Mode=Require;" +
                   "Pooling=false";

            optionsBuilder.UseNpgsql(conStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USER
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);

            modelBuilder.Entity<User>()
                .Property(u => u.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(u => u.full_name)
                .HasMaxLength(30);

            // ROLE TYPE
            modelBuilder.Entity<RoleType>()
                .HasKey(r => r.ID);

            modelBuilder.Entity<RoleType>()
                .Property(r => r.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RoleType>()
                .Property(r => r.name)
                .HasMaxLength(30);

            // PARCEL
            modelBuilder.Entity<Parcel>()
                .HasKey(p => p.ID);

            modelBuilder.Entity<Parcel>()
                .Property(p => p.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Parcel>()
                .Property(p => p.sender_name)
                .HasMaxLength(100);

            modelBuilder.Entity<Parcel>()
                .Property(p => p.recipient_name)
                .HasMaxLength(100);

            modelBuilder.Entity<Parcel>()
                .Property(p => p.tracking_id)
                .HasMaxLength(50);

            modelBuilder.Entity<Parcel>()
                .Property(p => p.price)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Parcel>()
                .HasOne(p => p.ServiceType)
                .WithMany(st => st.Parcels)
                .HasForeignKey(p => p.service_type_id)
                .OnDelete(DeleteBehavior.Restrict);

            // SERVICE TYPE
            modelBuilder.Entity<ServiceType>()
                .HasKey(st => st.ID);

            modelBuilder.Entity<ServiceType>()
                .Property(st => st.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ServiceType>()
                .Property(st => st.base_rate_per_kg)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<ServiceType>()
                .Property(st => st.minimum_charge)
                .HasColumnType("decimal(10,2)");

            // USER ROLE (JOIN TABLE)
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserID, ur.RoleTypeID });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.RoleType)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleTypeID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}