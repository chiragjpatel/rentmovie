using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Razor;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime? DateAdded{ get; set; }

        [Display(Name = "No in Stock")]
        [Required]
        [Range(0,20)]
        public int StockQty { get; set; }

        public int AvailableStockQty { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public bool IsDeleted { get; set; }

    }
}