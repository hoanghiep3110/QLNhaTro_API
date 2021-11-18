namespace QLNhaTro_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [Key]
        public int IdPhong { get; set; }

        [Required]
        [StringLength(255)]
        public string TenPhong { get; set; }

        public bool TrangThai { get; set; }

    }
}
