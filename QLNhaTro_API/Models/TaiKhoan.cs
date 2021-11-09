using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhaTro_API.Models
{
    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        public int IdTaiKhoan { get; set; }

        [Display(Name = "HỌ VÀ TÊN")]
        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [Display(Name = "SỐ ĐIỆN THOẠI")]
        [Required]
        [StringLength(10)]
        public string Sdt { get; set; }

        [Display(Name = "ĐỊA CHỈ")]
        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

    }
}
