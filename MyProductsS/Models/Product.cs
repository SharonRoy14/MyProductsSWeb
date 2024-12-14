using System.ComponentModel.DataAnnotations;

namespace MyProductsS.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")] 
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")] 
        public string ProductName { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")] 
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
