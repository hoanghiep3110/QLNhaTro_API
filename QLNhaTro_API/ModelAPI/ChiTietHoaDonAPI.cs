using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhaTro_API.ModelAPI
{
    public class ChiTietHoaDonAPI
    {
        public int IdHoaDon { get; set; }

        public string HoTen { get; set; }

        public int IdDichVu { get; set; }

        public string TenDichVu { get; set; }

        public DateTime TuNgay { get; set; }

        public DateTime ToiNgay { get; set; }
        public int? ChiSoCu { get; set; }

        public int? ChiSoMoi { get; set; }

        public int ThanhTien { get; set; }
    }
}