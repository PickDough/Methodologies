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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
