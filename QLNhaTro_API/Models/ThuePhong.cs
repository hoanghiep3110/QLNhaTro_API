namespace QLNhaTro_API.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ThuePhong")]
    public partial class ThuePhong
    {
        [Key]
        public int IdThue { get; set; }

        public int IdKhachHang { get; set; }

        public int IdPhong { get; set; }

        [Required]
        public int TienDatCoc { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime NgayBatDau { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime NgayKetThuc { get; set; }

        [StringLength(255)]
        public string FileHopDong { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
