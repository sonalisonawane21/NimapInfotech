using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NimapInfotech.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn( false)]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [ForeignKey("pk_fk_catprod")]
        public int CategoryId { get; set; }
        [NotMapped]
        public string? CategoryName { get; set; }
    }
}
