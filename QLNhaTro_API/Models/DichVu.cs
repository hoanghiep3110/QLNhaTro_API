using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhaTro_API.Models
{
    [Table("DichVu")]
    public partial class DichVu
    {
        [Key]
        public int IdDichVu { get; set; }

        [Display(Name = "TÊN DỊCH VỤ")]
        [Required]
        [StringLength(50)]
        public string TenDichVu { get; set; }

        [Display(Name = "ĐƠN GIÁ")]
        public int DonGia { get; set; }

    }
}
