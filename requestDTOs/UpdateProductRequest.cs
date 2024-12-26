using System.ComponentModel.DataAnnotations;

namespace JobTaskCrud.requestDTOs
{
    public class UpdateProductRequest
    {
        [Required]
        [MinLength(4, ErrorMessage = "Product name should have more than three characters.")]
        public string name { get; set; } = string.Empty;
        [Required]
        public decimal price { get; set; }
    }
}
