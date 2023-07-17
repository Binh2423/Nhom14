namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        public NhanVien()
        {
        }

        public NhanVien(string maNV, string tenNV, DateTime? ngaySinh, string maPB)
        {
            MaNV = maNV;
            TenNV = tenNV;
            NgaySinh = ngaySinh;
            MaPB = maPB;
        }

        [Key]
        [StringLength(6)]
        public string MaNV { get; set; }

        [StringLength(20)]
        public string TenNV { get; set; }

        public DateTime? NgaySinh { get; set; }

        [Required]
        [StringLength(2)]
        public string MaPB { get; set; }

        public virtual PhongBan PhongBan { get; set; }
    }
}
