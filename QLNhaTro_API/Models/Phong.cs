namespace QLNhaTro_API.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Phong")]
    public partial class Phong
    {

        [Key]
        public int IdPhong { get; set; }

        [Required]
        [StringLength(255)]
        public string TenPhong { get; set; }

        public int TrangThai { get; set; }

    }
}
