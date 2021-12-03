using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaTro_API.ModelAPI
{
    public class HoaDonAPI
    {
        public int IdHoaDon { get; set; }

        public int IdPhong { get; set; }

        public string TenPhong { get; set; }

        public int IdKhachHang { get; set; }

        public string HoTen { get; set; }

        public int TienThanhToan { get; set; }

        public bool TrangThaiThanhToan { get; set; }
    }
}