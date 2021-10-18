namespace QLNhaTro_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdHoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDichVu { get; set; }

        [Column(TypeName = "date")]
        public DateTime TuNgay { get; set; }

        [Column(TypeName = "date")]
        public DateTime ToiNgay { get; set; }

        public int? ChiSoCu { get; set; }

        public int? ChiSoMoi { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual HoaDonDichVu HoaDonDichVu { get; set; }
    }
}
