using System.ComponentModel.DataAnnotations;

namespace Mission06___ChrisFowler.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
