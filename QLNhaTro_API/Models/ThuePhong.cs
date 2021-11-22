namespace QLNhaTro_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuePhong")]
    public partial class ThuePhong
    {
        [Key]
        public int IdThue { get; set; }

        public int IdKhachHang { get; set; }

        public int IdPhong { get; set; }

        public int TienDatCoc { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NgayKetThuc { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
