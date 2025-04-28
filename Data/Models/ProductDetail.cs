using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Data.Models
{
    public class ProductDetail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "SKU không được trống")]
        [StringLength(50, ErrorMessage = "SKU không được vượt quá 50 ký tự")]
        public string SKU { get; set; }

        [StringLength(100)]
        public string Color { get; set; }

        [StringLength(100)]
        public string Size { get; set; }

        public int Stock { get; set; }

        public string ImageUrl { get; set; }

        // Foreign key relationship
        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
