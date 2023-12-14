
using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;
using System.Reflection.Metadata;

namespace Property.Infrastructure.DbContexts
{
    public class PropertyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<PropertyEntity> Properties { get; set; } = null!;
        public DbSet<AppartmentEntity> Appartments { get; set; } = null!;
        public DbSet<RoomEntity> Rooms { get; set; } = null!;
        public DbSet<ChaletEntity> Chalets { get; set; } = null!;
        //public DbSet<RoomReservationEntity> RoomReservations { get; set; }= null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PropertyInfo.db", b => b.MigrationsAssembly("Property.Infrastructure"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PropertyEntity>()
                .HasOne(pe => pe.Owner)
                .WithMany()
                .HasForeignKey(pe => pe.PropertyOwnerId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed

           modelBuilder.Entity<PropertyEntity>()
                .HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);;
  
            modelBuilder.Entity<PropertyEntity>()
                .HasOne(p => p.UpdatedByUser)
                .WithMany()
                .HasForeignKey(p => p.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChaletEntity>()
                .HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<ChaletEntity>()
                .HasOne(p => p.UpdatedByUser)
                .WithMany()
                .HasForeignKey(p => p.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoomEntity>()
                .HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<RoomEntity>()
                .HasOne(p => p.UpdatedByUser)
                .WithMany()
                .HasForeignKey(p => p.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<RoomReservationEntity>()
                .HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<RoomReservationEntity>()
                .HasOne(p => p.UpdatedByUser)
                .WithMany()
                .HasForeignKey(p => p.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoomReservationPaymentEntity>()
                .HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<RoomReservationPaymentEntity>()
                .HasOne(p => p.UpdatedByUser)
                .WithMany()
                .HasForeignKey(p => p.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<RoomSuppliesEntity>()
                .HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<RoomSuppliesEntity>()
                .HasOne(p => p.UpdatedByUser)
                .WithMany()
                .HasForeignKey(p => p.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SupplyEntity>()
                .HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<SupplyEntity>()
                .HasOne(p => p.UpdatedByUser)
                .WithMany()
                .HasForeignKey(p => p.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppartmentEntity>()
                .HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<AppartmentEntity>()
                .HasOne(p => p.UpdatedByUser)
                .WithMany()
                .HasForeignKey(p => p.UpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

        }


    }

}
