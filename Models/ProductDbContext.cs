namespace MVCluc.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProductDbContext : DbContext
    {
        public ProductDbContext()
            : base("name=ProductDbContext")
        {
        }

        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSP>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.LoaiSP)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Anh)
                .IsFixedLength();
        }
    }
}
