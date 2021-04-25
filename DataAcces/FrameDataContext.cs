using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data
{
    public partial class FrameDataContext : DbContext
    {
        public FrameDataContext()
        {
        }

        public FrameDataContext(DbContextOptions<FrameDataContext> options)
            : base(options)
        {
        }

        public DbSet<FrameEntity> Frames { get; set; }
        public DbSet<MaterialEntity> Materials { get; set; }
        public DbSet<FrameTypeEntity> FrameTypes { get; set; }
        public DbSet<MaterialTypeEntity> MaterialsTypes { get; set; }
        public DbSet<MaterialUnitEntity> MaterialUnits { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<FrameParametersEntity> FrameParameters { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
