using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhaTro_API.Models
{
    [Table("HoaDonDichVu")]
    public partial class HoaDonDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonDichVu()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Phong Phong { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
