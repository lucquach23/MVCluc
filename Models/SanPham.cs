namespace MVCluc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        public int? MaLoai { get; set; }

        [Key]
        public int MaSP { get; set; }

        [StringLength(200)]
        public string Ten { get; set; }

        public int? Gia { get; set; }

        [StringLength(200)]
        public string Anh { get; set; }

        public string Mota { get; set; }

        public int? KhuyenMai { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }
    }
}
