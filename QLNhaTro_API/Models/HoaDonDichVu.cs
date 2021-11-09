using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhaTro_API.Models
{
    [Table("HoaDonDichVu")]
    public partial class HoaDonDichVu
    {
        [Key]
        public int IdHoaDon { get; set; }

        public int IdTaiKhoan { get; set; }

        [Display(Name = "PHÒNG")]
        public int IdPhong { get; set; }

        [Display(Name = "kHÁCH HÀNG")]
        public int IdKhachHang { get; set; }

        [Display(Name = "TỔNG TIỀN CẦN THANH TOÁN")]
        [StringLength(10)]
        public string TienThanhToan { get; set; }

        [Display(Name = "TRẠNG THÁI")]
        public bool TrangThaiThanhToan { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Phong Phong { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
