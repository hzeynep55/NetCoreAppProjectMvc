﻿using System.ComponentModel.DataAnnotations;

namespace NetCoreAppProjectMvc.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="İsim alanı boş bırakılamaz.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Fiyat alanı boş bırakılamaz.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Stok alanı boş bırakılamaz.")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Renk seçimi boş bırakılamaz.")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Yayınlanma tarihi boş bırakılamaz.")]
        public DateTime? PublishDate { get; set; }

       
        public bool isPublish { get; set; }

        [Required(ErrorMessage = "Yayınlanma süresi boş bırakılamaz.")]
        public int? Expire { get; set; }
    }
}
