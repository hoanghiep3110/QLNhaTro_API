using System;

namespace QLNhaTro_API.ModelAPI
{
    public class ThuePhongAPI
    {
        public int IdThue { get; set; }

        public int IdKhachHang { get; set; }

        public string HoTen { get; set; }

        public int IdPhong { get; set; }

        public string TenPhong { get; set; }

        public int TienDatCoc { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public string FileHopDong { get; set; }

        public string LinkDownLoad { get; set; }
    }
}