using System.ComponentModel.DataAnnotations;

namespace miniEShop.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ürün adı boş olamaz")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }        
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg";
    }
}
