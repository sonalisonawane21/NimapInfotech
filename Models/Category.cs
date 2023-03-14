using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NimapInfotech.Models
{
    [Table("Category")]
    public class Category
    { 
        [Key]
        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }

        [Required]
        public string? CategoryName { get; set; }

    }
}
