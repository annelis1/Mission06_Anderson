using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Anderson.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        //[Column("Category")]//make it named Category in the database
        public string? CategoryName { get; set; }
    }
}
