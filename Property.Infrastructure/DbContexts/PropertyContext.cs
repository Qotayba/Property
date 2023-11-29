
using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;
namespace Property.Infrastructure.DbContexts
{
    public class PropertyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<PropertyEntity> Properties { get; set; } = null!;
        public DbSet<AppartmentEntity> Appartments { get; set; } = null!;
        public DbSet<RoomEntity> Rooms { get; set; } = null!;
        public DbSet<ChaletEntity> Chalets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PropertyInfo.db", b => b.MigrationsAssembly("Property.Infrastructure"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
