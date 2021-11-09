using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhaTro_API.Models
{
    [Table("Phong")]
    public partial class Phong
    {
        [Key]
        public int IdPhong { get; set; }

        [Display(Name = "TÊN PHÒNG")]
        [Required]
        [StringLength(255)]
        public string TenPhong { get; set; }

        [Display(Name = "TRẠNG THÁI")]
        public bool TrangThai { get; set; }

    }
}
