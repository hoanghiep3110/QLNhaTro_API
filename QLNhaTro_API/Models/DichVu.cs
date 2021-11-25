namespace QLNhaTro_API.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DichVu")]
    public partial class DichVu
    {

        [Key]
        public int IdDichVu { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDichVu { get; set; }

        public int DonGia { get; set; }

    }
}
