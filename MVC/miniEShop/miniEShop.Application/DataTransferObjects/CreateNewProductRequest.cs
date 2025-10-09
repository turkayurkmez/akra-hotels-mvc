using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniEShop.Application.DataTransferObjects
{
    public record CreateNewProductRequest
    {
        [Required(ErrorMessage = "Ürün adı boş olamaz")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg";

        public int? CategoryId { get; set; }
    }

    public record Alternatif([Required] string Name, 
                                        string? Description,
                             [Required] decimal Price, 
                                        int? CategoryId, 
                                        string ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg");
}
