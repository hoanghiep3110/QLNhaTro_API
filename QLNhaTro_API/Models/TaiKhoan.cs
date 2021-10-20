namespace QLNhaTro_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            HoaDonDichVus = new HashSet<HoaDonDichVu>();
        }

        [Key]
        public int IdTaiKhoan { get; set; }

        [Display(Name = "HỌ VÀ TÊN")]
        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [Display(Name = "SỐ ĐIỆN THOẠI")]
        [Required]
        [StringLength(10)]
        public string Sdt { get; set; }

        [Display(Name = "ĐỊA CHỈ")]
        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonDichVu> HoaDonDichVus { get; set; }
    }
}
