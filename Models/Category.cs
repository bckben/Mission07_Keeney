using System.ComponentModel.DataAnnotations;

namespace Mission07_Keeney.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}