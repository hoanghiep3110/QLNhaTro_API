using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhaTro_API.Models
{
    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        public int IdKhachHang { get; set; }

        [Display(Name = "HỌ VÀ TÊN")]
        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [Display(Name = "SỐ ĐIỆN THOẠI")]
        [Required]
        [StringLength(255)]
        public string Sdt { get; set; }

        [Display(Name = "GIỚI TÍNH")]
        [StringLength(10)]
        public string GioiTinh { get; set; }

        [Display(Name = "QUÊ QUÁN")]
        [StringLength(255)]
        public string QueQuan { get; set; }

        [Display(Name = "HỘ KHẨU TẠM TRÚ")]
        [StringLength(255)]
        public string HKTT { get; set; }

        [Display(Name = "CMND")]
        [Required]
        [StringLength(10)]
        public string SoCMND { get; set; }
    }
}
