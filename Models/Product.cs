using System.ComponentModel.DataAnnotations;

namespace JobTaskCrud.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public decimal price { get; set; }
    }
}
