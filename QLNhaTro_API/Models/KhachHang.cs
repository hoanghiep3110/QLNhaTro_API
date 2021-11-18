namespace QLNhaTro_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        public int IdKhachHang { get; set; }

        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(255)]
        public string Sdt { get; set; }

        [Required]
        [StringLength(50)]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(255)]
        public string QueQuan { get; set; }

        [Required]
        [StringLength(255)]
        public string HKTT { get; set; }

        [Required]
        [StringLength(50)]
        public string SoCMND { get; set; }
    }
}
