namespace QLNhaTro_API.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        public int IdKhachHang { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống ")]
        [StringLength(255)]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống ")]
        [StringLength(255)]
        public string Sdt { get; set; }

        [Required(ErrorMessage = "Giới tính không được để trống ")]
        [StringLength(50)]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Quê quán không được để trống ")]
        [StringLength(255)]
        public string QueQuan { get; set; }

        [Required(ErrorMessage = "Hộ khẩu thường trú không được để trống ")]
        [StringLength(255)]
        public string HKTT { get; set; }

        [StringLength(255)]
        public string SoCMND { get; set; }
        
    }
}
