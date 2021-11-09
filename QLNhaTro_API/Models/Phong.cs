using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhaTro_API.Models
{
    [Table("Phong")]
    public partial class Phong
    {
        public Phong()
        {
            HoaDonDichVus = new HashSet<HoaDonDichVu>();
            ThuePhongs = new HashSet<ThuePhong>();
        }

        [Key]
        public int IdPhong { get; set; }

        [Display(Name = "TÊN PHÒNG")]
        [Required]
        [StringLength(255)]
        public string TenPhong { get; set; }

        [Display(Name = "TRẠNG THÁI")]
        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonDichVu> HoaDonDichVus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuePhong> ThuePhongs { get; set; }
    }
}
