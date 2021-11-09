using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhaTro_API.Models
{
    [Table("ThuePhong")]
    public partial class ThuePhong
    {
        [Key]
        public int IdThue { get; set; }

        public int IdKhachHang { get; set; }

        public int IdPhong { get; set; }

        public int TienDatCoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKetThuc { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
