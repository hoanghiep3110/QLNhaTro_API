namespace QLNhaTro_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonDichVu")]
    public partial class HoaDonDichVu
    {

        [Key]
        public int IdHoaDon { get; set; }

        public int IdTaiKhoan { get; set; }

        public int IdPhong { get; set; }

        public int IdKhachHang { get; set; }

        public int TienThanhToan { get; set; }

        public bool TrangThaiThanhToan { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Phong Phong { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
