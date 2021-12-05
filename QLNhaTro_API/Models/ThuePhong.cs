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

        [Required]
        public int IdKhachHang { get; set; }

        public int IdPhong { get; set; }

        [Required(ErrorMessage = "Tiền đặt cọc không được để trống ")]
        public int TienDatCoc { get; set; }

        [Required(ErrorMessage =  "Ngày bắt đầu không được để trống ")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NgayBatDau { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc không được để trống ")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NgayKetThuc { get; set; }

        [StringLength(255)]
        public string FileHopDong { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
