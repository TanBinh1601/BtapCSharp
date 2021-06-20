namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        public int IdSP { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; }

        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }

        [Display(Name = "Giá tiền")]
        public decimal? GiaTien { get; set; }

        [Display(Name = "Bộ nhớ trong")]
        public int? BoNho { get; set; }

        [Display(Name = "Ram")]
        public int? Ram { get; set; }

        [Display(Name = "Ảnh")]
        public string HinhAnh { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Hãng sản xuất")]
        public int? IdHang { get; set; }

        [Display(Name = "Hệ điều hành")]
        public int? IdHDH { get; set; }

        public virtual HangSX HangSX { get; set; }

        public virtual HeDH HeDH { get; set; }
    }
}
