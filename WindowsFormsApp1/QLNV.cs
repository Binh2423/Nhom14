using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class QLNV : DbContext
    {
        public QLNV()
            : base("name=QLNV")
        {
        }

        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhongBan> PhongBan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaPB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.MaPB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.NhanVien)
                .WithRequired(e => e.PhongBan)
                .WillCascadeOnDelete(false);
        }
    }
}
