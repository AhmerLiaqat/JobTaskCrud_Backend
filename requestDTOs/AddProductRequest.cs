using System.ComponentModel.DataAnnotations;

namespace JobTaskCrud.requestDTOs
{
    public class AddProductRequest
    {
        [Required]
        [MinLength(4,ErrorMessage = "Product name should have more than three characters.")]
        public string name { get; set; } = string.Empty;
        [Required]
        [Range(100,99999999,ErrorMessage = "Number Must Be between (100 to 99999999)")]
        public decimal price { get; set; }
    }
}
