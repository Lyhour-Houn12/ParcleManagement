using Microsoft.EntityFrameworkCore;
using ParcleManagement.Data.entity;
using System;

namespace ParcleManagement.Data.db_migration
{
    public class ParcleDbContext : DbContext
    {
        public ParcleDbContext(DbContextOptions<ParcleDbContext> options)
            : base(options)
        {
        }
        // DbSets
        public DbSet<RoleType> RoleTypes => Set<RoleType>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserDetail> UserDetails => Set<UserDetail>();
        public DbSet<Manager> Managers => Set<Manager>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<ServiceType> ServiceTypes => Set<ServiceType>();
        public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
        public DbSet<Parcel> Parcels => Set<Parcel>();
        public DbSet<ParcelStatusHistory> ParcelStatusHistories => Set<ParcelStatusHistory>();
        public DbSet<DeliveryAssignment> DeliveryAssignments => Set<DeliveryAssignment>();
        public DbSet<DeliveryAttempt> DeliveryAttempts => Set<DeliveryAttempt>();
        public DbSet<ParcelTracking> ParcelTrackings => Set<ParcelTracking>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<VehicleAssignment> VehicleAssignments => Set<VehicleAssignment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ── RoleType ──────────────────────────────────────────────────────────
            modelBuilder.Entity<RoleType>(e =>
            {
                e.HasIndex(r => r.Name).IsUnique();
            });

            // ── User ──────────────────────────────────────────────────────────────
            modelBuilder.Entity<User>(e =>
            {
                e.HasIndex(u => u.Email).IsUnique();

                e.HasOne(u => u.RoleType)
                 .WithMany(r => r.Users)
                 .HasForeignKey(u => u.RoleTypeId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(u => u.UserDetail)
                 .WithOne(d => d.User)
                 .HasForeignKey<UserDetail>(d => d.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // ── Parcel ────────────────────────────────────────────────────────────
            modelBuilder.Entity<Parcel>(e =>
            {
                e.HasIndex(p => p.TrackingNumber).IsUnique();

                // customer (User)
                e.HasOne(p => p.Customer)
                 .WithMany(u => u.CustomerParcels)
                 .HasForeignKey(p => p.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);

                // driver
                e.HasOne(p => p.Driver)
                 .WithMany(d => d.Parcels)
                 .HasForeignKey(p => p.DriverId)
                 .OnDelete(DeleteBehavior.SetNull);

                // current warehouse location
                e.HasOne(p => p.CurrentWarehouse)
                 .WithMany(w => w.Parcels)
                 .HasForeignKey(p => p.CurrentLocationId)
                 .OnDelete(DeleteBehavior.SetNull);

                // service type
                e.HasOne(p => p.ServiceType)
                 .WithMany(s => s.Parcels)
                 .HasForeignKey(p => p.ServiceTypeId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ── ParcelStatusHistory ───────────────────────────────────────────────
            modelBuilder.Entity<ParcelStatusHistory>(e =>
            {
                e.HasOne(h => h.Parcel)
                 .WithMany(p => p.StatusHistories)
                 .HasForeignKey(h => h.ParcelId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(h => h.UpdatedByUser)
                 .WithMany(u => u.UpdatedStatusHistories)
                 .HasForeignKey(h => h.UpdatedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ── DeliveryAssignment ────────────────────────────────────────────────
            modelBuilder.Entity<DeliveryAssignment>(e =>
            {
                e.HasOne(a => a.Parcel)
                 .WithMany(p => p.DeliveryAssignments)
                 .HasForeignKey(a => a.ParcelId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(a => a.Driver)
                 .WithMany(d => d.DeliveryAssignments)
                 .HasForeignKey(a => a.DriverId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(a => a.AssignedByUser)
                 .WithMany(u => u.AssignedByAssignments)
                 .HasForeignKey(a => a.AssignedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ── DeliveryAttempt ───────────────────────────────────────────────────
            modelBuilder.Entity<DeliveryAttempt>(e =>
            {
                e.HasOne(a => a.Parcel)
                 .WithMany(p => p.DeliveryAttempts)
                 .HasForeignKey(a => a.ParcelId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(a => a.Driver)
                 .WithMany(d => d.DeliveryAttempts)
                 .HasForeignKey(a => a.DriverId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ── ParcelTracking ────────────────────────────────────────────────────
            modelBuilder.Entity<ParcelTracking>(e =>
            {
                e.HasOne(t => t.Parcel)
                 .WithMany(p => p.Trackings)
                 .HasForeignKey(t => t.ParcelId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(t => t.Driver)
                 .WithMany(d => d.ParcelTrackings)
                 .HasForeignKey(t => t.DriverId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ── Payment ───────────────────────────────────────────────────────────
            modelBuilder.Entity<Payment>(e =>
            {
                e.HasIndex(p => p.ParcelId).IsUnique(); // one payment per parcel

                e.HasOne(p => p.Parcel)
                 .WithOne(parcel => parcel.Payment)
                 .HasForeignKey<Payment>(p => p.ParcelId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(p => p.PaymentMethod)
                 .WithMany(m => m.Payments)
                 .HasForeignKey(p => p.PaymentMethodId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.ProcessedByUser)
                 .WithMany(u => u.ProcessedPayments)
                 .HasForeignKey(p => p.ProcessedBy)
                 .OnDelete(DeleteBehavior.SetNull);
            });

            // ── Vehicle ───────────────────────────────────────────────────────────
            modelBuilder.Entity<Vehicle>(e =>
            {
                e.HasIndex(v => v.PlateNumber).IsUnique();

                e.HasOne(v => v.VehicleType)
                 .WithMany(t => t.Vehicles)
                 .HasForeignKey(v => v.VehicleTypeId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ── VehicleAssignment ─────────────────────────────────────────────────
            modelBuilder.Entity<VehicleAssignment>(e =>
            {
                e.HasOne(a => a.Vehicle)
                 .WithMany(v => v.VehicleAssignments)
                 .HasForeignKey(a => a.VehicleId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(a => a.Driver)
                 .WithMany(d => d.VehicleAssignments)
                 .HasForeignKey(a => a.DriverId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
