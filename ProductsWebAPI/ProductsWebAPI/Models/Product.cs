using System.ComponentModel.DataAnnotations;

namespace ProductsWebAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
    }
}
